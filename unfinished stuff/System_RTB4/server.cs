//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 493 $
//#      $Date: 2013-04-21 12:48:33 +0100 (Sun, 21 Apr 2013) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/server.cs $
//#
//#      $Id: server.cs 493 2013-04-21 11:48:33Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Server Initiation
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Server = 1;

//*********************************************************
//* Variables
//*********************************************************
$ORBS::Version = "4.16";
$ORBS::Path = "Add-Ons/System_oRBs/";

//*********************************************************
//* Demo Users
//* -------------------------------------------------------
//* Believe it or not this is here for a reason.
//*********************************************************
if(!isUnlocked())
{
   $ORBS::Server = 0;
   echo("\c2ERROR: ORBS failed to load because you are in demo mode.");
   return;
}

//*********************************************************
//* ORBS Group for keeping stuff in
//*********************************************************
if(!isObject(ORBSGroup))
   new SimGroup(ORBSGroup);
   
//*********************************************************
//* Dedicated Init
//*********************************************************
if($Server::Dedicated)
   exec("./dedicated.cs");

//*********************************************************
//* Load Modules
//*********************************************************
exec("./modules/server/authentication.cs");
exec("./modules/server/guiTransfer.cs");
exec("./modules/server/serverControl.cs");

//*********************************************************
//* Activate Packages
//*********************************************************
activatePackage(ORBS_Modules_Server_Authentication);
activatePackage(ORBS_Modules_Server_GuiTransfer);
activatePackage(ORBS_Modules_Server_ServerControl);

//*********************************************************
//* Packaged Functions
//*********************************************************
package ORBS_Server
{
   function GameConnection::onConnectRequest(%this,%a,%b,%c,%d,%e,%f,%g,%h,%i,%j,%k,%l,%m,%n,%o,%p)
   {
      if(%g !$= "")
      {
         %this.hasORBS = 1;
         %this.orbsVersion = firstWord(%g);
      }
      Parent::onConnectRequest(%this,%a,%b,%c,%d,%e,%f,%g,%h,%i,%j,%k,%l,%m,%n,%o,%p);
   }
};
activatePackage(ORBS_Server);