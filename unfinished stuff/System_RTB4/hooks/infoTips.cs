//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 205 $
//#      $Date: 2010-04-10 22:53:37 +0100 (Sat, 10 Apr 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/hooks/serverControl.cs $
//#
//#      $Id: serverControl.cs 205 2010-04-10 21:53:37Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Hooks / Info Tips
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Hooks::InfoTips = 1;

//*********************************************************
//* The Meat
//*********************************************************
//- ORBS_addInfoTip (allows add-ons to add their own info tips)
function ORBS_addInfoTip(%tip,%nobindtip,%category)
{
   if(%tip $= "")
   {
      echo("\c2ERROR: No tip specified in ORBS_addInfoTip");
      return 0;
   }
   
   //category is deprecated for ???
   
   $ORBS::MCIT::Tip[$ORBS::MCIT::Tips++] = %tip TAB %nobindtip;
   
   return 1;
}