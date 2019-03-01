//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 187 $
//#      $Date: 2010-01-21 23:51:47 +0000 (Thu, 21 Jan 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/interface/mods/mainmenu.cs $
//#
//#      $Id: mainmenu.cs 187 2010-01-21 23:51:47Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Interface / Loading Gui Changes
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Interface::Loading = 1;

// Place swatch for info tips on loading gui
function interfaceFunction()
{
   %swatch = new GuiSwatchCtrl(LOAD_TipSwatch)
   {
      profile = GuiDefaultProfile;
      horizSizing = "left";
      vertSizing = "relative";
      position = "342 13";
      extent = "280 395";
      color = "0 0 0 0";
   };
   loadingGui.add(%swatch);
}
interfaceFunction();