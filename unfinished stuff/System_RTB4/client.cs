//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 493 $
//#      $Date: 2013-04-21 12:48:33 +0100 (Sun, 21 Apr 2013) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/client.cs $
//#
//#      $Id: client.cs 493 2013-04-21 11:48:33Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Client Initiation
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Client = 1;
//*********************************************************
//* Debug
//* -------------------------------------------------------
//* Level 0 -> Off
//* Level 1 -> Low
//* Level 2 -> High
//* Level 3 -> API Profiling/Debugging (DO NOT USE)
//*********************************************************
$ORBS::Debug = 0;

//*********************************************************
//* Variables
//*********************************************************
$ORBS::Version = "4.16";
$ORBS::Path = "Add-Ons/System_RTB4/";

//*********************************************************
//* Demo Users
//* -------------------------------------------------------
//* Believe it or not this is here for a reason.
//*********************************************************
if(!isUnlocked())
{
   $ORBS::Client = 0;
   echo("\c2ERROR: ORBS failed to load because you are in demo mode. (what in the hell)");
   return;
}

//*********************************************************
//* ORBS Group for keeping stuff in
//*********************************************************
if(!isObject(ORBSGroup))
   new SimGroup(ORBSGroup);

//*********************************************************
//* Load Prefs
//*********************************************************
exec("./modules/client/options.cs");
ORBSCO_setDefaultPrefs();
if(isFile("config/client/orbs/prefs.cs"))
   exec("config/client/orbs/prefs.cs");
   
//*********************************************************
//* Always enable ORBS
//*********************************************************
if(isFile("config/server/ADD_ON_LIST.cs"))
   exec("config/server/ADD_ON_LIST.cs");
else
   exec("base/server/defaultAddonList.cs");
$AddOn__System_RTB4 = 1;
export("$AddOn__*","config/server/ADD_ON_LIST.cs");

//*********************************************************
//* Load GUI Profiles
//*********************************************************
exec("./interface/profiles/generic.cs");
exec("./interface/profiles/connectClient.cs");
exec("./interface/profiles/infoTips.cs");
exec("./interface/profiles/modManager.cs");

//*********************************************************
//* Load Support
//*********************************************************
exec("./support/fileCache.cs");
exec("./support/functions.cs");
exec("./support/gui.cs");
exec("./support/networking.cs");
exec("./support/overlay.cs");
exec("./support/xmlParser.cs");

//*********************************************************
//* Runtime Functions
//*********************************************************
ORBS_FileCache.refresh();

//*********************************************************
//* Load Interface
//*********************************************************
exec("./interface/overlay.gui");
exec("./interface/mods/addOns.cs");
exec("./interface/mods/joinServer.cs");
exec("./interface/mods/loading.cs");
exec("./interface/mods/mainMenu.cs");
exec("./interface/mods/customGame.cs");
exec("./interface/colorManager.gui");
exec("./interface/connectClient.gui");
exec("./interface/manual.gui");
exec("./interface/modManager.gui");
exec("./interface/modUpdates.gui");
exec("./interface/options.gui");
exec("./interface/serverControl.gui");
exec("./interface/serverInformation.gui");
exec("./interface/updater.gui");

//*********************************************************
//* Load Modules
//*********************************************************
exec("./modules/client/authentication.cs");
exec("./modules/client/colorManager.cs");
exec("./modules/client/connectClient.cs");
exec("./modules/client/guiControl.cs");
exec("./modules/client/guiTransfer.cs");
exec("./modules/client/infoTips.cs");
exec("./modules/client/manual.cs");
exec("./modules/client/modManager.cs");
exec("./modules/client/serverControl.cs");
exec("./modules/client/serverInformation.cs");
exec("./modules/client/updater.cs");

//*********************************************************
//* Activate Packages
//*********************************************************
activatePackage(ORBS_Modules_Client_Authentication);
activatePackage(ORBS_Modules_Client_ColorManager);
activatePackage(ORBS_Modules_Client_ConnectClient);
activatePackage(ORBS_Modules_Client_InfoTips);
activatePackage(ORBS_Modules_Client_GuiTransfer);
activatePackage(ORBS_Modules_Client_ServerControl);
activatePackage(ORBS_Modules_Client_ServerInformation);

//*********************************************************
//* Version Establishment
//*********************************************************
//- clientCmdSendorbsVersion (Receives the server's ORBS version and whether it has ORBS)
function clientCmdSendorbsVersion(%version)
{
   $ORBS::Client::Cache::ServerhasORBS = 1;
   $ORBS::Client::Cache::ServerorbsVersion = firstWord(%version);
}

//*********************************************************
//* Packaged Functions
//*********************************************************
package ORBS_Client
{
   function disconnectedCleanup()
   {
      deleteVariables("$ORBS::Client::Cache::*");
      Parent::disconnectedCleanup();
   }
   
	function onExit()
	{
	   if(ORBSCC_Socket.connected)
	      ORBSCC_Socket.hardDisconnect();
	      
		Parent::onExit();
		echo("Exporting orbs prefs");
		export("$ORBS::Options*","config/client/orbs/prefs.cs");
	}
	
   function GameConnection::setConnectArgs(%a,%b,%c,%d,%e,%f,%g,%h,%i,%j,%k,%l,%m,%n,%o,%p)
   {
      Parent::setConnectArgs(%a,%b,%c,%d,%e,%f,$ORBS::Version,%h,%i,%j,%k,%l,%m,%n,%o,%p);
   }
};
activatePackage(ORBS_Client);