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
//#   Interface / Profiles / Connect Client GUI Profiles
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Interface::Profiles::ConnectClient = 1;

// Connect Client Content Border
if(!isObject(ORBS_ContentBorderProfile)) new GuiControlProfile(ORBS_ContentBorderProfile : GuiBitmapBorderProfile)
{
   bitmap = $ORBS::Path@"images/ui/contentArray";
};

// ORBS Text Edit
if(!isObject(ORBS_CCGroupEditProfile)) new GuiControlProfile(ORBS_CCGroupEditProfile : ORBS_TextEditProfile)
{
   fillColor = "255 255 255 255";
   borderColor = "188 191 193 255";
   fontSize = 12;
   fontType = "Verdana Bold";
   fontColor = "51 51 51 255";
   fontColors[0] = "51 51 51 255";
   fontColors[1] = "0 0 0";
};