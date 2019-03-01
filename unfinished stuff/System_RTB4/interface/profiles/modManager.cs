//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 266 $
//#      $Date: 2010-08-04 07:29:41 +0100 (Wed, 04 Aug 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/interface/profiles/generic.cs $
//#
//#      $Id: generic.cs 266 2010-08-04 06:29:41Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Interface / Profiles / Mod Manager GUI Profiles
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Interface::Profiles::ModManager = 1;

// Row Styling
if(!isObject(ORBSMM_CellLightProfile)) new GuiControlProfile(ORBSMM_CellLightProfile : GuiBitmapBorderProfile)
{
   bitmap = $ORBS::Path@"images/ui/cellArray_light";
};

// Row Styling
if(!isObject(ORBSMM_CellYellowProfile)) new GuiControlProfile(ORBSMM_CellYellowProfile : ORBSMM_CellLightProfile)
{
   bitmap = $ORBS::Path@"images/ui/cellArray_yellow";
};

// Row Styling
if(!isObject(ORBSMM_CellDarkProfile)) new GuiControlProfile(ORBSMM_CellDarkProfile : ORBSMM_CellLightProfile)
{
   bitmap = $ORBS::Path@"images/ui/cellArray_dark";
};

// Pagination Style
if(!isObject(ORBSMM_PaginationProfile)) new GuiControlProfile(ORBSMM_PaginationProfile)
{
   fontColor = "230 230 230 255";
   fontType = "Verdana Bold";
   fontSize = "12";
   justify = "Center";
   fontColors[1] = "230 230 230";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0"; 
   fontColorLink = "230 230 230 255";
   fontColorLinkHL = "255 255 255 255";
};

// News Content
if(!isObject(ORBSMM_NewsContentProfile)) new GuiControlProfile(ORBSMM_NewsContentProfile)
{
   fontColor = "230 230 230 255";
   fontType = "Verdana Bold";
   fontSize = "12";
   justify = "Center";
   fontColors[1] = "230 230 230";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0"; 
   fontColorLink = "150 150 150 255";
   fontColorLinkHL = "200 200 200 255";
};

// Main Text
if(!isObject(ORBSMM_MainText)) new GuiControlProfile(ORBSMM_MainText)
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

// Middle Text
if(!isObject(ORBSMM_MiddleText)) new GuiControlProfile(ORBSMM_MiddleText)
{
	fontColor = "30 30 30 255";
	fontSize = 14;
	fontType = "Arial";
	justify = "center";
   fontColors[1] = "100 100 100";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";  
};

// Block Text
if(!isObject(ORBSMM_BlockText)) new GuiControlProfile(ORBSMM_BlockText:BlockButtonProfile)
{
   fontColors[1] = "100 100 100";
	justify = "Left"; 
};

// Standard Text
if(!isObject(ORBSMM_GenText)) new GuiControlProfile(ORBSMM_GenText)
{
	fontColor = "30 30 30 255";
	fontSize = 14;
	fontType = "Arial";
	justify = "Left";
   fontColors[1] = "100 100 100";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";  
};

// File View Field Style
if(!isObject(ORBSMM_FieldText)) new GuiControlProfile(ORBSMM_FieldText)
{
	fontColor = "30 30 30 255";
	fontSize = 12;
	fontType = "Verdana Bold";
	justify = "Left";
   fontColors[1] = "150 150 150";
   fontColors[2] = "0 255 0";  
   fontColors[3] = "0 0 255"; 
   fontColors[4] = "255 255 0";   
};

// Progress Style
if(!isObject(ORBSMM_ProgressBar)) new GuiControlProfile(ORBSMM_ProgressBar)
{
   fillColor = "0 200 0 100";
   border = 0; 
};