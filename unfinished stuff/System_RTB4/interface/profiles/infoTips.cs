//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 187 $
//#      $Date: 2010-01-21 23:51:47 +0000 (Thu, 21 Jan 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/interface/profiles/generic.cs $
//#
//#      $Id: generic.cs 187 2010-01-21 23:51:47Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Interface / Profiles / Info Tip GUI Profiles
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Interface::Profiles::InfoTips = 1;

// Tip Text
if(!isObject(ORBS_TipTextProfile)) new GuiControlProfile (ORBS_TipTextProfile)
{
	doFontOutline = 1;
	fontType = "Verdana";
	fontSize = 13;
	fontOutlineColor = "0 0 0 3";
};