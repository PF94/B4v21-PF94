//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 274 $
//#      $Date: 2012-07-15 10:55:52 +0100 (Sun, 15 Jul 2012) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/support/networking.cs $
//#
//#      $Id: networking.cs 274 2012-07-15 09:55:52Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Support / Networking
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Support::Networking = 1;

//*********************************************************
//* Module Class
//*********************************************************
new ScriptGroup(ORBS_Networking)
{
   cookie = "";
};
ORBSGroup.add(ORBS_Networking);

//- ORBS_Networking::createFactory (creates a new tcp factory)
function ORBS_Networking::createFactory(%this,%host,%port,%resource)
{
   %factory = new ScriptGroup()
   {
      class = "ORBS_TCPFactory";
      
      host = %host;
      port = %port;
      resource = %resource;
      
      headers = 0;
   };
   %factory.setHeader("Host",%host);
   %factory.setHeader("User-Agent","ORBS/4.0");
   %factory.setHeader("Connection","close");
   
   %this.add(%factory);
   
   return %factory;
}

//*********************************************************
//* Factory Methods
//*********************************************************
//- ORBS_TCPFactory::setHeader (sets a header)
function ORBS_TCPFactory::setHeader(%this,%header,%value)
{
   if(%this.header[%header] !$= "")
   {
      %this.header[%header] = %value;
      return %this;
   }
   %this.header[%header] = %value;
   %this.header[%this.headers] = %header;
   %this.headers++;
   
   return %this;
}

//- ORBS_TCPFactory::getHeader (returns header value)
function ORBS_TCPFactory::getHeader(%this,%header)
{
   return %this.header[%header];
}

//- ORBS_TCPFactory::getPostData (puts data into string)
function ORBS_TCPFactory::getPostData(%this,%cmd,%d1,%d2,%d3,%d4,%d5,%d6,%d7,%d8,%d9,%d10,%d11)
{
   if(%d11 !$= "")
   {
      error("Only 10 arguments accepted in ORBS_TCPFactory::getPostData");
      return "";
   }
   
   if(%cmd $= "")
      return "";
   
   %data = "n=" @ urlEnc($pref::Player::NetName) @ "&b=" @ getNumKeyID() @ "&c=" @ urlEnc(%cmd) @ "&";
   for(%i=1;%i<11;%i++)
   {
      %data = %data @ "arg" @ %i @ "=" @ urlEnc(%d[%i]) @ "&";
   }
   return getSubStr(%data,0,strLen(%data)-1);
}

//- ORBS_TCPFactory::get (makes a GET request)
function ORBS_TCPFactory::get(%this,%data,%module,%successCallback,%failCallback,%startCallback,%endCallback)
{
   %request = "GET " @ %this.resource @ "&" @ %data @ " HTTP/1.1\r\n";

   if(ORBS_Networking.cookie !$= "")
      %request = %request @ "Cookie: " @ ORBS_Networking.cookie @ "\r\n";
      
   for(%i=0;%i<%this.headers;%i++)
   {
      %header = %this.header[%i];
      %request = %request @ %header @ ": " @ %this.header[%header] @ "\r\n";
   }
   %request = %request @ "\r\n";
   
   %this.request(%request,%module,%successCallback,%failCallback,%startCallback,%endCallback);
}

//- ORBS_TCPFactory::get (makes a POST request)
function ORBS_TCPFactory::post(%this,%data,%module,%successCallback,%failCallback,%startCallback,%endCallback)
{
   %request = "POST " @ %this.resource @ " HTTP/1.1\r\n";
   
   %request = %request @ "Content-Length: " @ strlen(%data) @ "\r\n";
   %request = %request @ "Content-Type: application/x-www-form-urlencoded\r\n";
   
   if(ORBS_Networking.cookie !$= "")
      %request = %request @ "Cookie: " @ ORBS_Networking.cookie @ "\r\n";
      
   for(%i=0;%i<%this.headers;%i++)
   {
      %header = %this.header[%i];
      %request = %request @ %header @ ": " @ %this.header[%header] @ "\r\n";
   }
   %request = %request @ "\r\n" @ %data;
   
   %this.request(%request,%module,%successCallback,%failCallback,%startCallback,%endCallback);
}

//- ORBS_TCPFactory::request (sets up a request using the data built in one of the request methods)
function ORBS_TCPFactory::request(%this,%request,%module,%lineCallback,%failCallback,%startCallback,%endCallback)
{
   %tcp = new TCPObject(ORBS_TCPObject)
   {
      connected = false;
      receiving = false;
      
      dead = false;
      
      request = %request;
      
      module = %module;
      lineCallback = %lineCallback;
      failCallback = %failCallback;
      startCallback = %startCallback;
      endCallback = %endCallback;
      
      factory = %this;
      
      orbs = true;
   };
   %this.add(%tcp);
   
   %tcp.connect(%this.host @ ":" @ %this.port);
}

//- ORBS_TCPFactory::getTCP (gets the active tcp object if it exists)
function ORBS_TCPFactory::getTCP(%this,%index)
{
   if(!%index)
      %index = 0;
      
   for(%i=0;%i<%this.getCount();%i++)
   {
      %obj = %this.getObject(%i);
      if(%obj.getClassName() $= "TCPObject" && !%obj.dead)
      {
         %index--;
         if(%index < 0)
            return %obj;
      }
   }
   return false;
}

//- ORBS_TCPFactory::killTCP (kills the active tcp)
function ORBS_TCPFactory::killTCP(%this)
{
   if(%tcp = %this.getTCP())
      %tcp.dead = true;
}

//*********************************************************
//* TCP Object Methods
//*********************************************************
//- ORBS_TCPObject::onConnected (onConnected callback)
function ORBS_TCPObject::onConnected(%this)
{      
   if(%this.dead)
      return;
      
   if($ORBS::Debug)
      echo("\c4>> TCP Connected");

   %this.connected = true;      
   
   %this.makeRequest();
}

//- ORBS_TCPObject::onLine (onLine callback)
function ORBS_TCPObject::onLine(%this,%line)
{
   if(%this.dead)
      return;
      
   if($ORBS::Debug)
      echo("\c2>> TCP Line Received ("@%line@")");
      
   if(%this.httpResponseCode $= "")
   {
      %this.httpResponseCode = getWord(%line,1);
      
      if(%this.httpResponseCode !$= "200")
      {
         if(%this.failCallback !$= "")
            eval(%this.module.getName()@"::"@%this.failCallback@"("@%this.module.getID()@","@%this@","@%this.factory@",\"HTTP\",\""@%this.httpResponseCode@"\");");
         %this.dead = true;
         return;
      }
   }
   
   if(%line $= "END")
   {
      if(%this.endCallback !$= "")
         eval(%this.module.getName()@"::"@%this.endCallback@"("@%this.module.getID()@","@%this@","@%this.factory@");");
         
      %this.receiving = false;
      %this.dead = true;
      return;
   }
   
   if(getField(%line,0) $= "NOTIFY")
   {
      echo("\c2"@getFields(%line,1,getFieldCount(%line)));
      return;
   }
   
   %escapedLine = strReplace(%line,"\\","\\\\");
   %escapedLine = strReplace(%escapedLine,"\"","\\\"");
      
   if(%this.receiving)
      if(%this.lineCallback !$= "")
         eval(%this.module.getName()@"::"@%this.lineCallback@"("@%this.module.getID()@","@%this@","@%this.factory@",\""@%escapedLine@"\");");

   if(!%this.receiving)
   {
      if(%line $= "")
      {
         %this.receiving = true;
         
         if(%this.startCallback !$= "")
            eval(%this.module.getName()@"::"@%this.startCallback@"("@%this.module.getID()@","@%this@","@%this.factory@");");
      }
      else
      {
         if(firstWord(%line) $= "Set-Cookie:")
            ORBS_Networking.cookie = restWords(%line);
      }
   }
}

//- ORBS_TCPObject::onConnectFailed (onConnectFailed callback)
function ORBS_TCPObject::onConnectFailed(%this)
{
   if(%this.dead)
      return;
      
   if($ORBS::Debug)
      echo("\c2>> TCP Connect Failed");
   
   if(%this.failCallback !$= "")
      eval(%this.module.getName()@"::"@%this.failCallback@"("@%this.module@","@%this@","@%this.factory@",\"Fail\");");
}

//- ORBS_TCPObject::onDNSFailed (onDNSFailed callback)
function ORBS_TCPObject::onDNSFailed(%this)
{
   if(%this.dead)
      return;
   
   if($ORBS::Debug)
      echo("\c2>> TCP DNS Failed");
   
   if(%this.failCallback !$= "")
      eval(%this.module.getName()@"::"@%this.failCallback@"("@%this.module@","@%this@","@%this.factory@",\"DNS\");");
}

//- ORBS_TCPObject::onDisconnect (onDisconnect callback)
function ORBS_TCPObject::onDisconnect(%this)
{
   %this.delete();
}

//- ORBS_TCPObject::makeRequest (makes a pre-defined request)
function ORBS_TCPObject::makeRequest(%this)
{
   if(!%this.connected || %this.dead)
      return;
      
   if($ORBS::Debug)
      echo("\c5>> TCP Data Sent");
      
   if($ORBS::Debug > 1)
      echo("\c5"@strReplace(%this.request,"\r\n","\r\n\c5"));
      
   %this.send(%this.request);
}