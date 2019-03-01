//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 266 $
//#      $Date: 2010-08-04 07:29:41 +0100 (Wed, 04 Aug 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/support/xmlParser.cs $
//#
//#      $Id: xmlParser.cs 266 2010-08-04 06:29:41Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Support / Overlay
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Support::Overlay = 1;

//*********************************************************
//* Functionality
//*********************************************************
//- ORBS_toggleOverlay (toggles the orbs overlay)
function ORBS_toggleOverlay(%trigger)
{
   if(%trigger)
      return;
   
   ORBS_Overlay.toggleOverlay();
}

//- ORBS_escapeOverlay (escapes the orbs overlay)
function ORBS_escapeOverlay(%trigger)
{
   if(%trigger)
      return;
   
   ORBS_Overlay.escapeOverlay();
}

//- ORBS_Overlay::toggleOverlay (toggles the orbs overlay)
function ORBS_Overlay::toggleOverlay(%this)
{
   if(%this.isAwake())
      %this.fadeOut();
   else
      %this.fadeIn();
}

//- ORBS_Overlay::fadeIn (fades the overlay into view)
function ORBS_Overlay::fadeIn(%this)
{
   Canvas.pushDialog(%this);
   
   for(%i=0;%i<%this.getCount();%i++)
   {
      %ctrl = %this.getObject(%i);
      if(%ctrl.getName() !$= "")
         if(isFunction(%ctrl.getName(),"onWake"))
            %ctrl.onWake();
   }
}

//- ORBS_Overlay::fadeOut (fades the overlay out of view)
function ORBS_Overlay::fadeOut(%this)
{
   Canvas.popDialog(%this);
   
   for(%i=0;%i<%this.getCount();%i++)
   {
      %ctrl = %this.getObject(%i);
      if(%ctrl.getName() !$= "")
         if(isFunction(%ctrl.getName(),"onWake"))
            %ctrl.onSleep();
   }
}

//- ORBS_Overlay::escape (closes windows/overlay)
function ORBS_Overlay::escapeOverlay(%this)
{
   if(ORBS_Options.isAwake() && ORBSCO_OV_RemapSwatch.isVisible())
   {
      ORBSCO_OV_RemapSwatch.setVisible(false);
      ORBSCO_OV_Remap.delete();
      return;
   }
   
   if(!ORBSCO_getPref("OV::EscapeClose"))
   {
      %this.fadeOut();
      return;
   }
   
   for(%i=%this.getCount()-1;%i>=0;%i--)
   {
      %window = %this.getObject(%i);
      if(%window.getClassName() $= "GuiWindowCtrl" && %window.isVisible())
         break;
   }
   
   if(%i < 0)
   {
      %this.fadeOut();
      return;
   }
   
   if(%window.overlayCloseCommand !$= "")
      eval(%window.overlayCloseCommand);
   else
      eval(%window.closeCommand);
}

//*********************************************************
//* Callbacks
//*********************************************************
//- ORBS_Overlay::onWake (makes sure all ctrls fit on the overlay)
function ORBS_Overlay::onWake(%this)
{
   %xDim = getWord(getRes(), 0);
   %yDim = getWord(getRes(), 1);

   for(%i=0;%i<%this.getCount();%i++)
   {
      %ctrl = %this.getObject(%i);
      if(%ctrl.getClassName() !$= "GuiWindowCtrl")
         continue;
         
      if(%ctrl.session && %ctrl.session.class $= "ORBSCC_RoomSession" && %ctrl.session.positionOnWake)
      {
         %ctrl.session.positionWindow();
         continue;
      }
      
      %xCurr = getWord(%ctrl.position,0);
      %yCurr = getWord(%ctrl.position,1);
      %xExt = getWord(%ctrl.extent,0);
      %yExt = getWord(%ctrl.extent,1);
      if($ORBS::Options::WindowPosition[%ctrl.getName()] !$= "")
      {
         %xCurr = getWord($ORBS::Options::WindowPosition[%ctrl.getName()],0);
         %yCurr = getWord($ORBS::Options::WindowPosition[%ctrl.getName()],1);
         %xExt = getWord($ORBS::Options::WindowExtent[%ctrl.getName()],0);
         %yExt = getWord($ORBS::Options::WindowExtent[%ctrl.getName()],1);
      }
      %xBound = %xCurr + %xExt;
      %yBound = %yCurr + %yExt;
      
      if(%xExt > %xDim)
         %xExt = %xDim;
      if(%yExt > %yDim)
         %yExt = %yDim;
      if(%xBound > %xDim)
         %xCurr = %xDim - %xExt;
      if(%yBound > %yDim)
         %yCurr = %yDim - %yExt;
      if(%xCurr < 0)
         %xCurr = 0;
      if(%yCurr < 0)
         %yCurr = 0;
         
      %ctrl.resize(%xCurr,%yCurr,%xExt,%yExt);
   }
   
   GlobalActionMap.bind("keyboard","escape","ORBS_escapeOverlay");
}

//- ORBS_Overlay::onSleep (does random things)
function ORBS_Overlay::onSleep(%this)
{
   if(AddOnsGui.isAwake())
      AddOnsGui.onWake();
      
   GlobalActionMap.unbind("keyboard","escape");
   
   for(%i=0;%i<%this.getCount();%i++)
   {
      %ctrl = %this.getObject(%i);
      if(%ctrl.getClassName() !$= "GuiWindowCtrl")
         continue;
         
      if(%ctrl.getName() !$= "")
      {
         $ORBS::Options::WindowPosition[%ctrl.getName()] = %ctrl.position;
         $ORBS::Options::WindowExtent[%ctrl.getName()] = %ctrl.extent;
      }
      else if(%ctrl.session && %ctrl.session.class $= "ORBSCC_RoomSession")
      {
         %store = ORBSCC_RoomOptionsManager.getRoomStore(%ctrl.session.name);
         %store.window_position = %ctrl.position;
         %store.window_extent = %ctrl.extent;
      }
   }
   ORBSCO_Save();
   ORBSCC_RoomOptionsManager.store();
}

//*********************************************************
//* Usage
//*********************************************************
//- ORBS_Overlay::push (sets ctrl to visible on overlay)
function ORBS_Overlay::push(%this,%ctrl)
{
   if(%this.isMember(%ctrl))
   {
      %ctrl.setVisible(true);
      %ctrl.onWake();
      
      %this.pushToBack(%ctrl);
   }
}

//- ORBS_Overlay::toggle (toggles ctrl invisibility)
function ORBS_Overlay::toggle(%this,%ctrl)
{
   if(%this.isMember(%ctrl))
   {
      if(%ctrl.isVisible())
      {
         %ctrl.setVisible(false);
         %ctrl.onSleep();
      }
      else
      {
         %ctrl.setVisible(true);
         %ctrl.onWake();
         
         %this.pushToBack(%ctrl);
      }
   }
}

//- ORBS_Overlay::pop (sets ctrl to invisible on overlay)
function ORBS_Overlay::pop(%this,%ctrl)
{
   if(%this.isMember(%ctrl))
   {
      %ctrl.setVisible(false);
      %ctrl.onSleep();
   }
}

//*********************************************************
//* Key Binds
//*********************************************************
GlobalActionMap.bind(getField(ORBSCO_getPref("OV::OverlayKeybind"),0),getField(ORBSCO_getPref("OV::OverlayKeybind"),1),"ORBS_toggleOverlay");

//- Unbind ORBS v3 IRC
%binding = moveMap.getBinding("ORBSIC_toggleIRC");
if(%binding)
   moveMap.unbind(getField(%binding,0),getField(%binding,1));