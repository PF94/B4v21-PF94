//#############################################################################
//#
//#   Return to Blockland - Version 3.5
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 39 $
//#      $Date: 2009-02-23 10:45:55 +0000 (Mon, 23 Feb 2009) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/trunk/old/ORBSC_ServerInformation.cs $
//#
//#      $Id: ORBSC_ServerInformation.cs 39 2009-02-23 10:45:55Z Ephialtes $
//#
//#      Copyright (c) 2008 - 2010 by Nick "Ephialtes" Matthews
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Client / Server Information
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::ServerInformation = 1;

//*********************************************************
//* Module Class
//*********************************************************
new ScriptObject(ORBS_Client_ServerInformation)
{
   // tcp factory
   tcp = ORBS_Networking.createFactory("orbs.daprogs.com","80","/apiRouter.php?d=APISB");
};
ORBSGroup.add(ORBS_Client_ServerInformation);

//*********************************************************
//* API Methods
//*********************************************************
//- ORBS_Client_ServerInformation::getORBSServers (gets a list of orbs servers from the master)
function ORBS_Client_ServerInformation::getORBSServers(%this)
{
   %data = %this.tcp.getPostData("MASTERORBS");
   
   %this.tcp.post(%data,%this,"onServerReply");
}

//- ORBS_Client_ServerInformation::onServerReply (server reply from master orbs request)
function ORBS_Client_ServerInformation::onServerReply(%this,%tcp,%factory,%line)
{
   %ip = getField(%line,1);
   %port = getField(%line,2);
   
   %search = strReplace(%ip,".","_")@"X"@%port;
   %soIndex = $ServerSOFromIP[%search];
   %so = $ServerSO[%soIndex];

   if(isObject(%so))
   {
      %so.hasORBS = 1;
      %so.display();
   }
   $ORBS::CServerInformation::Cache::ORBSIP[%search] = 1;
}

//- ORBS_Client_ServerInformation::getServerInfo (returns details about a server)
function ORBS_Client_ServerInformation::getServerInfo(%this,%ip,%port)
{
   %data = %this.tcp.getPostData("GETSERVERINFO",%ip,%port);
   
   %this.tcp.post(%data,%this,"onServerInfo","","onServerInfoStart","onServerInfoEnd");
}

//- ORBS_Client_ServerInformation::onServerInfoStart (callback of the start of transmission)
function ORBS_Client_ServerInformation::onServerInfoStart(%this,%tcp,%factory)
{
   ORBSSI_LoadSwatch.setVisible(false);
}

//- ORBS_Client_ServerInformation::onServerInfo (callback for server info request)
function ORBS_Client_ServerInformation::onServerInfo(%this,%tcp,%factory,%line)
{
   %type = getField(%line,1);
   %data = getField(%line,2);
   if(%type $= "PLIST")
   {
      %players = strReplace(%data,"~","\t");
      for(%i=0;%i<getFieldCount(%players);%i++)
      {
         %player = strReplace(getField(%players,%i),";","\t");

         %status = getField(%player,2);
         if(%status $= 3)
            %status = "H";
         else if(%status $= 2)
            %status = "S";
         else if(%status $= 1)
            %status = "A";
         else
            %status = "-";
         
         ORBSSI_PlayerList.addRow(getField(%player,2),getField(%player,2) TAB %status TAB getField(%player,0) TAB getField(%player,3) TAB getField(%player,1),0);
      }
   }
   else if(%type $= "MLIST")
   {
      %mods = strReplace(%data,";","\t");
      for(%i=0;%i<getFieldCount(%mods);%i++)
      {
         %mod = strReplace(getField(%mods,%i),"~","\t");

         if(getField(%mod,0) $= "orbs")
         {
            %mod_id = getField(%mod,1);
            %mod_title = getField(%mod,2);
            %mod_author = "by "@getField(%mod,3);
            %mod_zip = getField(%mod,4);
            %mod_content = getField(%mod,5);
         }
         else
         {
            %mod_id = "";
            %mod_title = getField(%mod,1);
            %mod_author = getField(%mod,2);
            %mod_zip = getField(%mod,3);
            %mod_content = 0;
         }
         
         %yPosition = ((ORBSSI_ModWindow.getCount()/3)*44)+(ORBSSI_ModWindow.getCount()/3);
         if(%mod_zip $= "")
            continue;
            
         if(%mod_title $= "")
            %mod_title = "Unnamed Add-On";
            
         if(%mod_author $= "")
            %mod_author = "Unknown Author";
            
         %mod_icon = (getField(%mod,0) $= "orbs" || getField(%mod,0) $= "orbs2") ? "orbsLogo" : "blLogo";
            
         if(isFile("Add-Ons/"@%mod_zip) || isFile("Add-Ons/"@getSubStr(%mod_zip,0,strLen(%mod_zip)-4)@"/description.txt"))
         {
            %mod_gotIcon = "tick";
            %mod_got = 1;
         }
         else
         {
            %mod_gotIcon = "cross";
            %mod_got = 0;
         }
         
         %iconSw = new GuiSwatchCtrl()
         {
            position = "0" SPC %yPosition;
            extent = "42 44";
            color = "210 210 210 255";
            
            new GuiBitmapCtrl()
            {
               position = "13 14";
               extent = "16 16";
               bitmap = $ORBS::Path@"images/icons/"@%mod_icon;
            };
         };
         ORBSSI_ModWindow.add(%iconSw);
         
         %infoSw = new GuiSwatchCtrl()
         {
            position = "43" SPC %yPosition;
            extent = "297 44";
            color = "220 220 220 255";
            
            new GuiMLTextCtrl()
            {
               position = "4 3";
               extent = "290 19";
               text = "<font:Arial Bold:14><color:444444>"@%mod_title@"<br><color:666666><font:Verdana:12>"@%mod_author@"<br><color:888888>"@%mod_zip;
            };
         };
         ORBSSI_ModWindow.add(%infoSw);
         
         if(getField(%mod,0) $= "orbs" && %mod_content)
         {
            %plug = new GuiBitmapCtrl()
            {
               position = "-2 -1";
               extent = "16 16";
               bitmap = $ORBS::Path@"images/icons/bullet_plugin";
            };
            %iconSw.add(%plug);
            
            %infoSw.getObject(0).setText(%infoSw.getObject(0).getText()@"<just:right><font:Verdana:12><color:999999>(contains content)");
            
            if(!%mod_got)
            {
               %dl = new GuiBitmapButtonCtrl()
               {
                  position = "274 8";
                  extent = "16 16";
                  text = " ";
                  bitmap = $ORBS::Path@"images/ui/buttons/serverInformation/disk";
               };
               %infoSw.add(%dl);
               %infoSw.sg_dlBtn = %dl;
            }
            
            %statusSw = new GuiSwatchCtrl()
            {
               position = "1 30";
               extent = "200 14";
               color = "220 220 220 255";
               visible = 0;
               
               new GuiMLTextCtrl()
               {
                  position = "3 0";
                  extent = "200 12";
                  text = "<font:Verdana Bold:12><color:666666>Hi";
               };
            };
            %infoSw.add(%statusSw);
            %infoSw.sg_statusSW = %statusSw;
            
            %progStd = new GuiSwatchCtrl()
            {
               position = "195 26";
               extent = "100 16";
               color = "220 220 220 255";
               visible = 0;
            };
            %infoSw.add(%progStd);
            %infoSw.sg_progStd = %progStd;
            
            for(%k=0;%k<8;%k++)
            {
               %dot = new GuiBitmapCtrl()
               {
                  position = %progStd.getCount()*12 SPC 0;
                  extent = "16 16";
                  bitmap = $ORBS::Path@"images/icons/bullet_gray";
               };
               %progStd.add(%dot);
            }
            
            %progRed = new GuiSwatchCtrl()
            {
               position = "195 26";
               extent = "100 16";
               color = "220 220 220 255";
               visible = 0;
            };
            %infoSw.add(%progRed);
            %infoSw.sg_progRed = %progRed;
            
            for(%k=0;%k<8;%k++)
            {
               %dot = new GuiBitmapCtrl()
               {
                  position = %progRed.getCount()*12 SPC 0;
                  extent = "16 16";
                  bitmap = $ORBS::Path@"images/icons/bullet_red";
               };
               %progRed.add(%dot);
            }
         }
         
         %optSw = new GuiSwatchCtrl()
         {
            position = "341" SPC %yPosition;
            extent = "42 44";
            color = "220 220 220 255";
            
            new GuiBitmapCtrl()
            {
               position = "13 14";
               extent = "16 16";
               bitmap = $ORBS::Path@"images/icons/"@%mod_gotIcon;
            };
         };
         ORBSSI_ModWindow.add(%optSw);
         
         %infoSw.sg_dlBtn.command = "ORBSSI_downloadContent("@%mod_id@","@%infoSw@","@%optSw.getObject(0)@");";
         
         if(ORBSMM_TransferQueue.hasItem(%mod_id))
         {
            %queue = ORBSMM_TransferQueue.getItem(%mod_id);
            
            %queue.sg_progStd = %infoSw.sg_progStd;
            %queue.sg_progRed = %infoSw.sg_progRed;
            %queue.sg_statusSW = %infoSw.sg_statusSW;
            %queue.sg_indicator = %optSw.getObject(0);
            %queue.sg_dlBtn = %infoSw.sg_dlBtn;
            
            %queue.update();
         }
      }
      %yPosition += 44;
      if(%yPosition < 292)
         %yPosition = 292;
      ORBSSI_ModWindow.resize(0,0,383,%yPosition);
   }
   else if(%type $= "0")
   {
      ORBSSI_FailSwatch.setVisible(true);
   }
}

//- ORBS_Client_ServerInformation::onServerInfoEnd (end of data)
function ORBS_Client_ServerInformation::onServerInfoEnd(%this,%tcp,%factory)
{
   ORBSSI_PlayerList.sort(0,0);
}

//*********************************************************
//* Interface Methods
//*********************************************************
//- ORBS_ServerInformation::onSleep (callback for closing of gui)
function ORBS_ServerInformation::onSleep()
{
   ORBS_Client_ServerInformation.tcp.killTCP();
}

//- ORBSSI_downloadContent (adds this file to the download queue for the mod manager)
function ORBSSI_downloadContent(%id,%info,%icon)
{
   %queue = ORBSMM_TransferQueue.addItem(%id,1);
   if(!isObject(%queue))
   {
      MessageBoxOK("Ooops","You are already downloading this add-on.");
      return;
   }
   
   %queue.sg_progStd = %info.sg_progStd;
   %queue.sg_progRed = %info.sg_progRed;
   %queue.sg_statusSW = %info.sg_statusSW;
   %queue.sg_indicator = %icon;
   %queue.sg_dlBtn = %info.sg_dlBtn;
   
   %queue.update();
}

//- joinServerGui::info (retrieves specific info on the selected server)
function joinServerGui::info(%this)
{
   %address = getField(JS_serverList.getValue(),9);
   %ip = getSubStr(%address,0,strPos(%address,":"));
   %port = getSubStr(%address,strPos(%address,":")+1,strLen(%address));
   
   Canvas.pushDialog(ORBS_ServerInformation);
   ORBSSI_LoadSwatch.setVisible(true);
   ORBSSI_FailSwatch.setVisible(false);
   ORBSSI_PlayerList.clear();
   
   ORBSSI_ModScroll.clear();
   %modSwatch = new GuiSwatchCtrl(ORBSSI_ModWindow)
   {
      position = "0 0";
      extent = "383 292";
      color = "0 0 0 0";
   };
   ORBSSI_ModScroll.add(%modSwatch);
   
   ORBS_Client_ServerInformation.getServerInfo(%ip,%port);
}

//*********************************************************
//* Module Package
//*********************************************************
package ORBS_Modules_Client_ServerInformation
{
   function queryMasterTCPObj::connect(%this,%host)
   {
      Parent::connect(%this,%host);
      
      ORBS_Client_ServerInformation.getORBSServers();
   }
   
   function ServerInfoSO_Add(%a,%b,%c,%d,%e,%f,%g,%h,%i,%j)
   {
      Parent::ServerInfoSO_Add(%a,%b,%c,%d,%e,%f,%g,%h,%i,%j);
      
      %search = strReplace(strReplace(%a,":","X"),".","_");
      if($ORBS::CServerInformation::Cache::ORBSIP[%search])
      {
         %soIndex = $ServerSOFromIP[%search];
         %so = $ServerSO[%soIndex];
         if(isObject(%so))
         {
            %so.hasORBS = 1;
            %so.display();
         }
      }
   }
   
   function ServerSO::serialize(%this)
   {
      %serialized = Parent::serialize(%this);
      
      if(%this.hasORBS)
         %hasORBS = "Yes";
      else
         %hasORBS = "No";
      
      return %serialized@"\t"@%hasORBS;
   }
};