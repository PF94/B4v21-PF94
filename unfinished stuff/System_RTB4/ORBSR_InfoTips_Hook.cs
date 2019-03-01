//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 405 $
//#      $Date: 2011-03-05 22:09:06 +0000 (Sat, 05 Mar 2011) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/client.cs $
//#
//#      $Id: client.cs 405 2011-03-05 22:09:06Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Legacy File
//#
//#############################################################################

//Load Real Module
if(!$ORBS::Hooks::InfoTips)
   exec("Add-Ons/System_oRBs/hooks/infoTips.cs");
   
//Set old indication var
$ORBS::ORBSR_InfoTips_Hook = 1;   
   
echo("\c2WARNING: ORBSR_InfoTips_Hook.cs has moved. Please alter to use hooks/infoTips.cs");