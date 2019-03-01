//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 259 $
//#      $Date: 2011-11-05 00:41:50 +0000 (Sat, 05 Nov 2011) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/modules/client/options.cs $
//#
//#      $Id: options.cs 259 2011-11-05 00:41:50Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Client / Options
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::Options = 1;

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::MCO::Options = 0;

//*********************************************************
//* Module Meat
//*********************************************************
//- ORBSCO_registerOption (registers a pref that orbs needs to save/load/manage)
function ORBSCO_registerOption(%varName,%value)
{
   $ORBS::MCO::OptionName[$ORBS::MCO::Options] = %varName;
   $ORBS::MCO::OptionDefault[$ORBS::MCO::Options] = %value;
   $ORBS::MCO::Options++;
}

//- ORBSCO_getPref (returns value of a pref)
function ORBSCO_getPref(%varName)
{
   eval("%return = $ORBS::Options::"@%varName@";");
   
   return %return;
}

//- ORBSCO_setPref (sets value of a pref)
function ORBSCO_setPref(%varName,%value)
{
   eval("$ORBS::Options::"@%varName@" = \""@%value@"\";");
}

//- ORBSCO_setDefaultPrefs (sets the pref values to default prefs)
function ORBSCO_setDefaultPrefs()
{
   for(%i=0;%i<$ORBS::MCO::Options;%i++)
      eval("$ORBS::Options::"@$ORBS::MCO::OptionName[%i]@" = \""@$ORBS::MCO::OptionDefault[%i]@"\";");
}

//- ORBSCO_Save (saves all the settings)
function ORBSCO_Save()
{
   export("$ORBS::Options::*","config/client/orbs/prefs.cs");
}

//*********************************************************
//* GUI Functionality
//*********************************************************
//- ORBS_Options::onWake (options wake)
function ORBS_Options::onWake(%this)
{
   %binding = strReplace(getField(GlobalActionMap.getBinding("ORBS_toggleOverlay"),1)," "," + ");
   
   ORBSCO_Overlay_Keybind.setText("<font:Verdana:12><color:888888><just:right>" @ %binding);
   
   for(%i=0;%i<ORBSCO_Swatch.getCount();%i++)
   {
      %ctrl = ORBSCO_Swatch.getObject(%i);
      if(%ctrl.getClassName() !$= "GuiCheckboxCtrl")
         continue;
         
      %value = ORBSCO_getPref(%ctrl.optionName);

      if(%ctrl.getValue() !$= %value)
         %ctrl.performClick();
   }
}

//- ORBS_Options::onSleep (options sleep)
function ORBS_Options::onSleep(%this)
{
   for(%i=0;%i<ORBSCO_Swatch.getCount();%i++)
   {
      %ctrl = ORBSCO_Swatch.getObject(%i);
      if(%ctrl.getClassName() !$= "GuiCheckboxCtrl")
         continue;

      ORBSCO_setPref(%ctrl.optionName,%ctrl.getValue());
   }
   ORBSCO_Save();
   
   if(isObject(ORBSCO_OV_Remap))
   {
      ORBSCO_OV_Remap.delete();
      ORBSCO_OV_RemapSwatch.setVisible(false);
   }
   ORBS_Client_Authentication.sendPrefs();
}

//- ORBS_Options::toggleDependant (toggles dependant blocker)
function ORBS_Options::toggleDependant(%this,%ctrl)
{
   if(%ctrl.getValue() $= 1)
      %ctrl.optionDependant.setVisible(false);
   else
      %ctrl.optionDependant.setVisible(true);
}

//- ORBS_Options::changeKeybind (opens keybind change window)
function ORBS_Options::changeKeybind(%this)
{
   ORBSCO_OV_RemapSwatch.setVisible(true);
   
   %remapper = new GuiInputCtrl(ORBSCO_OV_Remap);
   ORBSCO_OV_RemapSwatch.add(%remapper);
   %remapper.makeFirstResponder(1);
   
   ORBSCO_OV_RemapText.setText("<font:Verdana:12><color:888888>Please press a key ...");
}

//- ORBSCO_OV_Remap::onInputEvent (captures input and assigns)
function ORBSCO_OV_Remap::onInputEvent(%this,%device,%key)
{
   if(%device $= "mouse0")
      return;
      
   if(getWordCount(%key) $= 1 && strLen(%key) $= 1)
   {
      %disallowed = "ABCDEFGHIJKLMNOPQRSTUVWXYZ123456789[]\\/{};:'\"<>,./?!@#$%^&*-_=+`~";
      for(%i=0;%i<strLen(%disallowed);%i++)
      {
         %char = getSubStr(%disallowed,%i,1);
         if(%char $= %key)
         {
            ORBSCO_OV_RemapText.setText("<font:Verdana:12><color:888888>You can't use that key.");
            return;
         }
      }
   }
      
   ORBSCO_OV_RemapSwatch.setVisible(false);
   ORBSCO_Overlay_Keybind.setText("<font:Verdana:12><color:888888><just:right>" @ strReplace(%key," "," + "));
   
   %binding = GlobalActionMap.getBinding("ORBS_toggleOverlay");
   GlobalActionMap.unbind(getField(%binding,0),getField(%binding,1));
   GlobalActionMap.bind(%device,%key,"ORBS_toggleOverlay");
   
   ORBSCO_setPref("OV::OverlayKeybind",%device TAB %key);
   ORBSCO_Save();
   
   %this.delete();
}

//*********************************************************
//* Register Options
//*********************************************************
ORBSCO_registerOption("OV::OverlayKeybind","keyboard\tctrl tab");
ORBSCO_registerOption("OV::EscapeClose",0);

ORBSCO_registerOption("CA::Auth",1);
ORBSCO_registerOption("CA::ShowOnline",1);
ORBSCO_registerOption("CA::ShowServer",1);

ORBSCO_registerOption("SA::Auth",1);
ORBSCO_registerOption("SA::ShowPlayers",1);

ORBSCO_registerOption("MM::Animate",1);
ORBSCO_registerOption("MM::CheckUpdates",1);

ORBSCO_registerOption("IT::Enable",1);
ORBSCO_registerOption("IT::ShowAddons",1);

ORBSCO_registerOption("GT::Enable",1);

ORBSCO_registerOption("SC::NotifySettings",0);

ORBSCO_registerOption("CC::AutoSignIn",1);
ORBSCO_registerOption("CC::EnableSounds",1);
ORBSCO_registerOption("CC::StickyNotifications",1);
ORBSCO_registerOption("CC::ChatLogging",0);
ORBSCO_registerOption("CC::SeparateOffline",0);
ORBSCO_registerOption("CC::ShowTimestamps",0);
ORBSCO_registerOption("CC::SavePositions",1);
ORBSCO_registerOption("CC::InviteReq",0);
ORBSCO_registerOption("CC::ShowServer",1);
ORBSCO_registerOption("CC::AllowPM",1);
ORBSCO_registerOption("CC::AllowInvites",1);
ORBSCO_registerOption("CC::SignIn::Beep",1);
ORBSCO_registerOption("CC::SignIn::Note",0);
ORBSCO_registerOption("CC::Message::Beep",1);
ORBSCO_registerOption("CC::Message::Note",1);
ORBSCO_registerOption("CC::Join::Beep",1);
ORBSCO_registerOption("CC::Join::Note",0);
ORBSCO_registerOption("CC::PirateMode",0);