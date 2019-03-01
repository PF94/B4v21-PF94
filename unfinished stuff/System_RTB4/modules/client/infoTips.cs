//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 187 $
//#      $Date: 2010-01-21 23:51:47 +0000 (Thu, 21 Jan 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/modules/client/guiControl.cs $
//#
//#      $Id: guiControl.cs 187 2010-01-21 23:51:47Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Client / Info Tips
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::InfoTips = 0;

//*********************************************************
//* Requirements
//*********************************************************
if(!$ORBS::Hooks::InfoTips)
   exec($ORBS::Path@"hooks/infoTips.cs");

//*********************************************************
//* Default Tips
//*********************************************************
$ORBS::MCIT::Tips = 0;
$ORBS::MCIT::ORBSTips = $ORBS::MCIT::Tips;

//*********************************************************
//* Info Tip Rendering
//*********************************************************
//- ORBSIT_drawInfoTip (draws an info tip on the loading gui)
function ORBSIT_drawInfoTip()
{
   if(isEventPending($ORBS::MCIT::Schedule))
      cancel($ORBS::MCIT::Schedule);
      
   if(isObject(LOAD_TipTop))
      LOAD_TipTop.delete();
   if(isObject(LOAD_TipMiddle))
      LOAD_TipMiddle.delete();
   if(isObject(LOAD_TipBottom))
      LOAD_TipBottom.delete();
   if(isObject(LOAD_TipText))
      LOAD_TipText.delete();

   if($ORBS::MCIT::Tips < 1)
      return;

   while(%msg $= "")
   {
      if(ORBSCO_getPref("IT::ShowAddons"))
         %tipnum = getRandom(1,$ORBS::MCIT::Tips);
      else
         %tipnum = getRandom(1,$ORBS::MCIT::ORBSTips);
      
      if($ORBS::MCIT::LastTip $= %tipnum)
         continue;      
      
      %tip = $ORBS::MCIT::Tip[%tipnum];
      %msg = getField(%tip,0);
      while(strPos(%msg,"<key:") >= 0)
      {
         %key = getSubStr(%msg,strPos(%msg,"<key:")+5,strLen(%msg));
         %key = getSubStr(%key,0,strPos(%key,">"));
         if(getKeyBind(%key) $= -1)
            %msg = getField(%tip,1);
         else
            %msg = strReplace(%msg,"<key:"@%key@">","<spush><color:FF0000>"@getKeyBind(%key)@"<spop>");
      }
      
      %k++;
      if(%k > 500)
         %msg = "Did you know that I just malfunctioned?\n\nPlease Report It!";
   }
   $ORBS::MCIT::LastTip = %tipnum;

   %bottom = new GuiBitmapCtrl(LOAD_TipBottom)
   {
      profile = GuiDefaultProfile;
      horizSizing = "left";
      vertSizing = "top";
      position = getWord(LOAD_TipSwatch.extent,0)-271 SPC getWord(LOAD_TipSwatch.extent,1)-161;
      extent = "271 161";
      bitmap = $ORBS::Path@"images/ui/tipBottom";
   };
   LOAD_TipSwatch.add(%bottom);

   %text = new GuiMLTextCtrl(LOAD_TipText)
   {
      profile = ORBS_TipTextProfile;
      position = "14 0";
      extent = "190 14";
      text = %msg;
   };
   LOAD_TipSwatch.add(%text);
   %text.forceReflow();
   
   %middle = new GuiBitmapCtrl(LOAD_TipMiddle)
   {
      profile = GuiDefaultProfile;
      horizSizing = "left";
      vertSizing = "top";
      position = getWord(LOAD_TipSwatch.extent,0)-271 SPC getWord(%bottom.position,1)-getWord(%text.extent,1);
      extent = "218" SPC getWord(%text.extent,1);
      bitmap = $ORBS::Path@"images/ui/tipMiddle";
   };
   LOAD_TipSwatch.add(%middle);
   %middle.add(%text);

   %top = new GuiBitmapCtrl(LOAD_TipTop)
   {
      profile = GuiDefaultProfile;
      horizSizing = "left";
      vertSizing = "top";
      position = getWord(LOAD_TipSwatch.extent,0)-271 SPC getWord(%middle.position,1)-33;
      extent = "218 33";
      bitmap = $ORBS::Path@"images/ui/tipTop";
   };
   LOAD_TipSwatch.add(%top);
   
   %msgTime = strLen(%msg)*160;
   if(%msgTime < 8000)
      %msgTime = 8000;
      
   $ORBS::MCIT::Schedule = schedule(%msgTime,0,"ORBSIT_CreateInfoTip");
}

//*********************************************************
//* Support Functions
//*********************************************************
//- getKeyBind (gets a text-version of a keybind)
function getKeyBind(%bindName)
{
   %device = getField(movemap.getBinding(%bindName), 0);

   if(%device $= "")
	   return -1;

   %device = getSubStr(%device, 0, 5);
   %key = getField(movemap.getBinding(%bindName), 1);

   if(%device $= "mouse")
   {
      switch$(%key)
      {
         case "button0":
            %key = "left mouse button";
         case "button1":
            %key = "right mouse button";
         case "button2":
            %key = "middle mouse button";
         default:
            %key = "mouse " @ %key;
      }
   }
   else
   {
      switch$(%key)
      {
         case "space":
            %key = "spacebar";
         case "lshift":
            %key = "left shift";
         case "rshift":
            %key = "right shift";
         case "lalt":
            %key = "left alt";
         case "ralt":
            %key = "right alt";
      }
      
      if(strlen(%key) == 1)
         %key = strUpr(%key);
   }
   return %key;
}

//*********************************************************
//* Packaged Functions
//*********************************************************
package ORBS_Modules_Client_InfoTips
{
   function LoadingGui::onWake(%this)
   {
      Parent::onWake(%this);
      if(ORBSCO_getPref("IT::Enable"))
         ORBSIT_drawInfoTip();
   }
   
   function LoadingGui::onSleep(%this)
   {
      Parent::onSleep(%this);
      
      cancel($ORBS::MCIT::Schedule);
   }
};