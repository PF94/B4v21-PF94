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
//#   Modules / Server / Gui Transfer
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Server::GuiTransfer = 1;

//*********************************************************
//* Required Modules
//*********************************************************
if(!$ORBS::Hooks::GuiTransfer)
   exec($ORBS::Path@"hooks/guiTransfer.cs");

//*********************************************************
//* Transfer Management/Handling
//*********************************************************
//- GameConnection::transmitGUI (Transmits a gui to the client)
function GameConnection::transmitGUI(%client,%gui,%element)
{
   if(!isObject(%client))
      return;
 
   if(%gui $= "")
      %gui = 0;
   if(%element $= "")
      %element = -1;
 
   if(%gui >= ORBSRT_GUIManifest.getCount())
   {
      %client.onGUIDone();
      return;
   } 
   
   if(%element $= -1)
   {
      commandtoclient(%client,'ORBS_receiveGUI',ORBSRT_GUIManifest.getObject(%gui).name);
   }
   else
   {
      %control = ORBSRT_GUIManifest.getObject(%gui).elementClass[%element];   
      %name = ORBSRT_GUIManifest.getObject(%gui).elementName[%element];   
      %props = ORBSRT_GUIManifest.getObject(%gui).elementProps[%element];
      %depth = ORBSRT_GUIManifest.getObject(%gui).elementDepth[%element];
      if(strLen(%props) > 255)
      {
         %reAllocs = 0;
         %strAlloc = mFloor(getFieldCount(%props)/255);
         for(%i=0;%i<getFieldCount(%props);%i++)
         {
            if(strLen(getField(%props,%i)) > %strAlloc)
            {
               %reAlloc[%reAllocs] = %i;
               %reAllocs++;
               %newProps = %newProps@"\t";
            }
            else
               %newProps = %newProps@getField(%props,%i)@"\t";
         }
         %newProps = getSubStr(%newProps,0,strLen(%newProps)-1);
         commandtoclient(%client,'ORBS_receiveElement',%control,%name,%props,%depth);
         
         for(%i=0;%i<%reAllocs;%i++)
         {
            %prop = %reAlloc[%i];
            %propVal = getField(%props,%prop);
            if(strLen(%propVal) > 255)
            {
               %inc = 0;
               %buffer = strLen(%propVal);
               while(%buffer > 0)
               {
                  if(%buffer > 255)
                     %sendBytes = 255;
                  else
                     %sendBytes = %buffer;
                  %propSend = getSubStr(%propVal,0,%sendBytes);
                  commandtoclient(%client,'ORBS_receiveProperty',%prop,%propSend,%inc);
                  %inc = 1;
                  %buffer -= %sendBytes;
                  %propVal = getSubStr(%propVal,%sendBytes,strLen(%propVal));
               }
            }
            else
               commandtoclient(%client,'ORBS_receiveProperty',%prop,%propVal);
         }
      }
      else
      {
         commandtoclient(%client,'ORBS_receiveElement',%control,%name,%props,%depth);
      }
   }
   %element++;
   
   if(%element >= ORBSRT_GUIManifest.getObject(%gui).elements)
   {
      %gui++;
      %element = -1;
   }
   %client.schedule(5,"transmitGUI",%gui,%element);
}

//- GameConnection::onGUIDone (Callback when gui is completely downloaded)
function GameConnection::onGUIDone(%client)
{
   %client.currentPhase = 0;
   %client.hasDownloadedGUI = 1;
   commandToClient(%client,'ORBS_receiveComplete');
   commandToClient(%client,'MissionStartPhase1',$missionSequence,$Server::MissionFile);
}

//*********************************************************
//* Module Package
//*********************************************************
package ORBS_Modules_Server_GUITransfer
{
   function GameConnection::loadMission(%this)
   {
      if(%this.isAIControlled())
      {
         Parent::loadMission(%this);
      }
      else
      {
         if(%this.hasORBS)
         {
            %this.currentPhase = -1;
            
            //@LEGACY
            if(%this.orbsVersion < 4)
            {
               %this.currentPreparePhase = 1;
               commandToClient(%this,'MissionPreparePhase2',ORBSRT_getControlCRC(),ORBSRT_GUIManifest.getCount(),ORBSRT_GUIManifest.elements);
            }
            else
            {
               %this.currentPreparePhase = 0;
               commandToClient(%this,'MissionPreparePhase1',ORBSRT_getControlCRC(),ORBSRT_GUIManifest.getCount(),ORBSRT_GUIManifest.elements);
            }
            echo("*** Sending mission load to client: " @ $Server::MissionFile);
         }
         else
            Parent::loadMission(%this);
      }
   }
   
   function serverCmdMissionPreparePhase1Ack(%client,%skip)
   {
      if(%client.currentPhase !$= "-1" || %client.currentPreparePhase !$= "0")
         return;
         
      //@LEGACY
      if(%client.orbsVersion < 4)
      {
         %client.currentPreparePhase = 1;
         commandToClient(%client,'MissionPreparePhase2',ORBSRT_getControlCRC(),ORBSRT_GUIManifest.getCount(),ORBSRT_GUIManifest.elements);
         return;
      }
         
      if(%skip)
      {
         %client.currentPhase = 0;
         commandToClient(%client,'MissionStartPhase1',$missionSequence,$Server::MissionFile);
         return;
      }
         
      %client.currentPreparePhase = 1;
      %client.transmitGUI();
   }
   
   //@LEGACY
   function serverCmdMissionPreparePhase2Ack(%client,%skip)
   {
      if(%client.currentPhase !$= "-1" || %client.currentPreparePhase !$= "1")
         return;

      if(%skip)
      {
         %client.currentPhase = 0;
         commandToClient(%client,'MissionStartPhase1',$missionSequence,$Server::MissionFile);
         return;
      }

      %client.currentPreparePhase = 2;
      %client.transmitGUI();
   }
};