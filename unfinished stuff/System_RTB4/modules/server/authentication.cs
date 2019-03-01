//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 266 $
//#      $Date: 2010-08-04 07:29:41 +0100 (Wed, 04 Aug 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/modules/client/serverControl.cs $
//#
//#      $Id: serverControl.cs 266 2010-08-04 06:29:41Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Server / Authentication
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Server::Authentication = 1;

//*********************************************************
//* Module Class
//*********************************************************
if(isObject(ORBS_Server_Authentication))
{
   ORBS_Server_Authentication.tcp.delete();
   ORBS_Server_Authentication.delete();
}

new ScriptObject(ORBS_Server_Authentication)
{
   // tcp factory
   tcp = ORBS_Networking.createFactory("orbs.daprogs.com","80","/apiRouter.php?d=APISA");
   
   sentMods = false;
};
ORBSGroup.add(ORBS_Server_Authentication);

//*********************************************************
//* API Methods
//*********************************************************
//- ORBS_Server_Authentication::post (posts server information to the orbs master)
function ORBS_Server_Authentication::post(%this)
{
   if(%this.getServerType() !$= "Multiplayer")
      return;
      
   if(!ORBSCO_getPref("SA::Auth"))
      return;
      
   if(isEventPending(%this.postSchedule))
      cancel(%this.postSchedule);
      
   %this.postSchedule = %this.schedule(180000,"post");
   
   %data = %this.tcp.getPostData("POST",$Pref::Server::Port,ClientGroup.getCount(),%this.getPlayerList(),"oRBs");
   
   %this.tcp.post(%data,%this,"onPostReply");
   
   echo("Posting to ORBS server");
}

//- ORBS_Server_Authentication::onPostReply (handles reply from post request)
function ORBS_Server_Authentication::onPostReply(%this,%tcp,%factory,%line)
{
   if(getField(%line,1) $= "1")
      %this.postMods();
}

//- ORBS_Server_Authentication::postMods (sends a list of mods on the server to orbs)
function ORBS_Server_Authentication::postMods(%this)
{
   if(%this.sentMods)
      return;

   %data = %this.tcp.getPostData("POSTMODS",$Pref::Server::Port,%this.getModList());
   
   %this.tcp.post(%data,%this,"onPostModsReply");
}

//- ORBS_Server_Authentication::onPostModsReply (handles reply from postmods request)
function ORBS_Server_Authentication::onPostModsReply(%this,%tcp,%factory,%line)
{
   if(getField(%line,1) $= "1")
      %this.sentMods = true;
}

//*********************************************************
//* Helper Methods
//*********************************************************
//- ORBS_Server_Authentication::getServerType (Establishes what type of server is being hosted)
function ORBS_Server_Authentication::getServerType(%this)
{
   if(isObject(MissionGroup))
   {
      if($Server::LAN)
         return "LAN";
      else
         return "Multiplayer";
   }
   else
      return 0;
}

//- ORBS_Server_Authentication::getPlayerList (Gets an http-friendly list of players)
function ORBS_Server_Authentication::getPlayerList(%this)
{
   for(%i=0;%i<ClientGroup.getCount();%i++)
   {
      %client = ClientGroup.getObject(%i);
      %client_name = %client.netName;
      %client_ip = %client.getAddress();
      
      if(%client.isSuperAdmin)
         %client_state = 2;
      else if(%client.isAdmin)
         %client_state = 1;
      else
         %client_state = 0;
         
      %client_score = %client.score;
      %client_blid = %client.bl_id;
         
      if(%client_ip $= "local")
         %client_state = 3;
      else
         %client_ip = getSubStr(%client_ip,0,strPos(%client_ip,":"));
         
      %playerList = (%playerList $= "") ? %client_name@";"@%client_ip@";"@%client_score@";"@%client_state : %playerList@"~"@%client_name@";"@%client_ip@";"@%client_score@";"@%client_state;
   }
   return %playerList;
}

//- ORBS_Server_Authentication::getModList (Gets a list of mods running on the server)
function ORBS_Server_Authentication::getModList(%this)
{
   %filepath = findFirstFile("Add-Ons/*_*/server.cs");
   while(strlen(%filepath) > 0)
   {
      %zip = getSubStr(%filepath,8,strLen(%filepath)-strLen("/server.cs")-strLen("Add-Ons/"));
      
      if($AddOn__[%zip] $= 1)
      {
         %type = "";
         %id = "";
         %version = "";
         %author = "";
         %title = "";
         
         %fileObject = new FileObject();
         if(%fileObject.openForRead("Add-Ons/"@%zip@"/orbsInfo.txt"))
         {
            %type = "orbs";
            while(!%fileObject.isEOF())
            {
               %line = %fileObject.readLine();
               if(striPos(%line,"id:") !$= -1)
               {
                  %id = getWord(%line,1);
               }
               else if(striPos(%line,"version:") !$= -1)
               {
                  %version = getWord(%line,1);
               }
               else if(striPos(%line,"name:") !$= -1)
               {
                  %type = "orbs2";
               }
            }
            %fileObject.close();
         }
         if(%fileObject.openForRead("Add-Ons/"@%zip@"/description.txt"))
         {
            if(%type $= "")
               %type = "bl";
               
            while(!%fileObject.isEOF())
            {
               %line = %fileObject.readLine();
               if(striPos(%line,"title:") !$= -1)
               {
                  %title = trim(strReplace(%line,getSubStr(%line,0,strPos(%line,":")+1),""));
               }
               else if(striPos(%line,"author:") !$= -1)
               {
                  %author = trim(strReplace(%line,getSubStr(%line,0,strPos(%line,":")+1),""));
               }
            }
            %fileObject.close();
         }
         
         if(%type $= "bl")
            %modArray = %modArray@"bl~"@%title@"~"@%author@"~"@%zip@".zip;";
         else if(%type $= "orbs2")
            %modArray = %modArray@"orbs2~"@%title@"~"@%author@"~"@%zip@".zip;";
         else if(%type $= "orbs")
            %modArray = %modArray@"orbs~"@%id@"~"@%version@"~"@%zip@".zip;";
      }
      %filepath = findNextFile("Add-Ons/*_*/server.cs");
   }
   if(strLen(%modArray) > 0)
      %modArray = getSubStr(%modArray,0,strLen(%modArray)-1);
   return %modArray;
}

//*********************************************************
//* Runtime Code
//*********************************************************
if(!ORBSCO_getPref("SA::Auth"))
   echo("WARNING: Posting to orbs server (server posting disabled)");

//*********************************************************
//* Module Package
//*********************************************************
package ORBS_Modules_Server_Authentication
{
   function postServerTCPObj::connect(%this,%addr)
   {
      Parent::connect(%this,%addr);
      
      ORBS_Server_Authentication.post();
   }
};