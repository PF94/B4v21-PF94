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
//#   Interface / Custom Game Gui Changes
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Interface::CustomGame = 1;

// Place color manager button on start mission gui
function interfaceFunction()
{
   %btn = new GuiBitmapButtonCtrl(CustomGameGui_ColorSetButton) {
      profile = "ImpactForwardButtonProfile";
      horizSizing = "relative";
      vertSizing = "relative";
      position = "0 159";
      extent = "160 34";
      minExtent = "8 2";
      enabled = "1";
      visible = "1";
      clipToParent = "1";
      command = "CustomGameGui.clickColorSet();";
      text = "Color Sets > ";
      groupNum = "-1";
      buttonType = "PushButton";
      bitmap = "base/client/ui/btnBlank";
      lockAspectRatio = "0";
      alignLeft = "0";
      overflowImage = "0";
      mKeepCached = "0";
      mColor = "255 255 255 255";
   };
   CustomGameGui.add(%btn);
   
   %hl = new GuiSwatchCtrl(CustomGameGui_ColorsetHilight) {
      profile = "GuiDefaultProfile";
      horizSizing = "relative";
      vertSizing = "relative";
      position = "0 159";
      extent = "160 34";
      minExtent = "8 2";
      enabled = "1";
      visible = "0";
      clipToParent = "1";
      color = "255 255 255 128";
   };
   CustomGameGui.add(%hl);
   
   %window = new GuiSwatchCtrl(CustomGameGui_ColorsetWindow) {
      profile = "GuiDefaultProfile";
      horizSizing = "relative";
      vertSizing = "relative";
      position = "160 40";
      extent = "480 410";
      minExtent = "8 2";
      enabled = "1";
      visible = "0";
      clipToParent = "1";
      color = "0 0 0 0";
      
      new GuiScrollCtrl(CustomGameGui_ColorsetScroll) {
         profile = "ImpactScrollProfile";
         horizSizing = "relative";
         vertSizing = "relative";
         position = "0 0";
         extent = "270 410";
         minExtent = "8 2";
         enabled = "1";
         visible = "1";
         clipToParent = "1";
         willFirstRespond = "0";
         hScrollBar = "alwaysOff";
         vScrollBar = "alwaysOn";
         constantThumbHeight = "0";
         childMargin = "0 0";
         rowHeight = "81";
         columnWidth = "30";
         
         new GuiSwatchCtrl(CustomGameGui_ColorsetSwatch) {
            profile = "GuiDefaultProfile";
            horizSizing = "relative";
            vertSizing = "relative";
            position = "0 0";
            extent = "270 400";
            minExtent = "8 2";
            enabled = "1";
            visible = "1";
            clipToParent = "1";
            color = "0 0 0 0";
         };
      };
      
      new GuiSwatchCtrl() {
         profile = "GuiDefaultProfile";
         horizSizing = "relative";
         vertSizing = "relative";
         position = "270 0";
         extent = "210 410";
         minExtent = "8 2";
         enabled = "1";
         visible = "1";
         clipToParent = "1";
         color = "0 0 0 128";
         
         new GuiSwatchCtrl(CustomGameGui_ColorsetPreview) {
            profile = "GuiDefaultProfile";
            horizSizing = "right";
            vertSizing = "bottom";
            position = "0 0";
            extent = "10 10";
            minExtent = "8 2";
            enabled = "1";
            visible = "1";
            clipToParent = "1";
            color = "0 0 0 0";
         };
      };
   };
   CustomGameGui.add(%window);
}
interfaceFunction();