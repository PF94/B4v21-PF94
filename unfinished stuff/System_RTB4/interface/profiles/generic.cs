//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 167 $
//#      $Date: 2011-02-27 22:35:06 +0000 (Sun, 27 Feb 2011) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/interface/profiles/generic.cs $
//#
//#      $Id: generic.cs 167 2011-02-27 22:35:06Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Interface / Profiles / Generic GUI Profiles
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Interface::Profiles::Generic = 1;

// ORBS Verdana 12pt Font
if(!isObject(ORBS_Verdana12Pt)) new GuiControlProfile(ORBS_Verdana12Pt)
{
	fontColor = "30 30 30 255";
	fontSize = 12;
	fontType = "Verdana";
	justify = "Left";
   fontColors[1] = "100 100 100";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";   
   fontColorLink = "60 60 60 255";
   fontColorLinkHL = "0 0 0 255";
};

// ORBS Verdana 12pt Auto Font
if(!isObject(ORBS_AutoVerdana12)) new GuiControlProfile(ORBS_AutoVerdana12)
{
   fontColor = "30 30 30 255";
   fontSize = 12;
   fontType = "Verdana";
   justify = "Left";
   fontColors[1] = "100 100 100";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";
   fontColors[5] = "0 0 0";
   autoSizeWidth = true;
   autoSizeHeight = true;
};

// ORBS Verdana 12pt Font Centered
if(!isObject(ORBS_Verdana12PtCenter)) new GuiControlProfile(ORBS_Verdana12PtCenter)
{
	fontColor = "30 30 30 255";
	fontSize = 12;
	fontType = "Verdana";
	justify = "Center";
   fontColors[1] = "100 100 100";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";   
};

// ORBS Header Text
if(!isObject(ORBS_HeaderText)) new GuiControlProfile(ORBS_HeaderText)
{
   fontColor = "30 30 30 255";
   fontSize = 18;
   fontType = "Impact";
   justify = "Left";
   fontColors[1] = "100 100 100";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";   
};

// Profile used for version text on main menu
if(!isObject(ORBS_VersionProfile)) new GuiControlProfile(ORBS_VersionProfile : MM_LeftProfile)
{
   fontOutlineColor = "255 24 24 255";
   justify = "right";
};

// ORBS Checkboxes
if(!isObject(ORBS_CheckBoxProfile)) new GuiControlProfile(ORBS_CheckBoxProfile : GuiCheckBoxProfile)
{
   bitmap = $ORBS::Path@"images/ui/checkboxArray";
};

// Bold Checkbox
if(!isObject(ORBS_CheckBoxBoldProfile)) new GuiControlProfile(ORBS_CheckBoxBoldProfile : GuiCheckBoxProfile)
{
   fontType = "Arial Bold";
};

// ORBS Radio Buttons
if(!isObject(ORBS_RadioButtonProfile)) new GuiControlProfile(ORBS_RadioButtonProfile : GuiCheckBoxProfile)
{
   bitmap = $ORBS::Path@"images/ui/radioArray";
};

// ORBS Popup Menu
if(!isObject(ORBS_PopupProfile)) new GuiControlProfile(ORBS_PopupProfile : GuiPopupMenuProfile)
{
   fillColor = "227 228 230 255";
   borderColor = "189 192 194 255";
   fontSize = 12;
   fontType = "Verdana";
   fontColor = "64 64 64 255";
   fontColors[0] = "64 64 64 255";
};

// ORBS Text Edit
if(!isObject(ORBS_TextEditProfile)) new GuiControlProfile(ORBS_TextEditProfile : GuiTextEditProfile)
{
   fillColor = "255 255 255 255";
   borderColor = "188 191 193 255";
   fontSize = 12;
   fontType = "Verdana";
   fontColor = "64 64 64 255";
   fontColors[0] = "64 64 64 255";
   fontColors[1] = "0 0 0";
};

// ORBS ML Text Edit
if(!isObject(ORBS_MLEditProfile)) new GuiControlProfile(ORBS_MLEditProfile : GuiMLTextEditProfile)
{
   fontSize = 12;
   fontType = "Verdana";
   fontColor = "64 64 64 255";
   fontColors[0] = "64 64 64 255";
};

// ORBS Scroll
if(!isObject(ORBS_ScrollProfile)) new GuiControlProfile(ORBS_ScrollProfile)
{
   fontType = "Book Antiqua";
   fontSize = 22;
   justify = center;
   fontColor = "0 0 0";
   fontColorHL = "130 130 130";
   fontColorNA = "255 0 0";
   fontColors[0] = "0 0 0";
   fontColors[1] = "0 255 0";  
   fontColors[2] = "0 0 255"; 
   fontColors[3] = "255 255 0";
   hasBitmapArray = true;
   
   bitmap = $ORBS::Path@"images/ui/scrollArray";
};