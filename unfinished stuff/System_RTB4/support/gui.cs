//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 227 $
//#      $Date: 2011-08-13 19:02:06 +0100 (Sat, 13 Aug 2011) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/support/gui.cs $
//#
//#      $Id: gui.cs 227 2011-08-13 18:02:06Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Support / Gui
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Support::GUI = 1;

//*********************************************************
//* Mouse Event Handling
//* -------------------------------------------------------
//* This setup allows mouseEventCtrls to contain other
//* controls within itself that you can mouseover without
//* the engine thinking you left the mouse event ctrl.
//* Its just a looping check to see if you're within the
//* bounds - and performance it'll reduce the number of
//* checks if you've left the mouse afk in the ctrl or
//* something. Shouldn't cause trouble really.
//*********************************************************
//- GuiMouseEventCtrl::onMouseEnter (Hack)
function GuiMouseEventCtrl::onMouseEnter(%this)
{   
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 1)
         if(getSubStr(%this.eventCallbacks,0,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onMouseEnter("@%this@");";
            eval(%command);
         }
}

//- GuiMouseEventCtrl::onMouseLeave (Epic Hack, So bad it makes me sick)
function GuiMouseEventCtrl::onMouseLeave(%this)
{
   if(%this.persistent)
   {
      %position = %this.getCanvasPosition();
      %minX = getWord(%position,0);
      %maxX = getWord(%position,0) + getWord(%this.extent,0);
      %minY = getWord(%position,1);
      %maxY = getWord(%position,1) + getWord(%this.extent,1);
      %curX = getWord(Canvas.getCursorPos(),0);   
      %curY = getWord(Canvas.getCursorPos(),1);

      if(%curX > %minX && %curX < %maxX && %curY > %minY && %curY < %maxY)
      {
         if(%this.checks > 1000)
            %sch = 1000;
         else if(%this.checks > 500)
            %sch = 100;
         else
            %sch = 10;

         %this.schedule(%sch,"onMouseLeave");
         %this.checks++;
         return;
      }
   }
   
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 2)
         if(getSubStr(%this.eventCallbacks,1,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onMouseLeave("@%this@");";
            eval(%command);
            %this.checks = 0;
         }
}

//- GuiMouseEventCtrl::onMouseDown (Hack)
function GuiMouseEventCtrl::onMouseDown(%this)
{
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 3)
         if(getSubStr(%this.eventCallbacks,2,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onMouseDown("@%this@");";
            eval(%command);
         }
}

//- GuiMouseEventCtrl::onMouseUp (Hack)
function GuiMouseEventCtrl::onMouseUp(%this)
{
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 4)
         if(getSubStr(%this.eventCallbacks,3,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onMouseUp("@%this@");";
            eval(%command);
         }
}

//- GuiMouseEventCtrl::onMouseDragged (Hack)
function GuiMouseEventCtrl::onMouseDragged(%this)
{
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 5)
         if(getSubStr(%this.eventCallbacks,4,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onMouseDragged("@%this@");";
            eval(%command);
         }
}

//- GuiMouseEventCtrl::onRightMouseDown (Hack)
function GuiMouseEventCtrl::onRightMouseDown(%this)
{
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 6)
         if(getSubStr(%this.eventCallbacks,5,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onRightMouseDown("@%this@");";
            eval(%command);
         }
}

//- GuiMouseEventCtrl::onRightMouseUp (Hack)
function GuiMouseEventCtrl::onRightMouseUp(%this)
{
   if(%this.eventType !$= "")
      if(strLen(%this.eventCallbacks) >= 7)
         if(getSubStr(%this.eventCallbacks,6,1) $= 1)
         {
            %command = "Event_"@%this.eventType@"::onRightMouseUp("@%this@");";
            eval(%command);
         }
}

//- GuiControl::centerX (Centers %this inside %parent horizontally)
function GuiControl::centerX(%this,%parent)
{
   if(isObject(%parent))
   {
      %maxArea = getWord(%parent.extent,0);
      %width = getWord(%this.extent,0);
      
      %xPosition = (%maxArea/2)-(%width/2);
      if(%parent $= %this.getGroup())
         %this.position = (%xPosition+getWord(%parent.position,0)) SPC getWord(%this.position,1);
      else
         %this.position = (%xPosition+getWord(%parent.getCanvasPosition(),0)) SPC getWord(%this.getCanvasPosition(),1);
   }
   else
   {
      %parent = %this.getGroup();
      %maxArea = getWord(%parent.extent,0);
      %width = getWord(%this.extent,0);
      
      %xPosition = (%maxArea/2)-(%width/2);
      %this.position = %xPosition SPC getWord(%this.position,1);
   }
}

//- GuiControl::centerY (Centers %this inside %parent vertically)
function GuiControl::centerY(%this,%parent)
{
   if(isObject(%parent))
   {
      %maxArea = getWord(%parent.extent,1);
      %height = getWord(%this.extent,1);

      %yPosition = (%maxArea/2)-(%height/2);
      if(%parent $= %this.getGroup())
         %this.position = getWord(%this.position,0) SPC (%yPosition+getWord(%parent.position,1));
      else
         %this.position = getWord(%this.getCanvasPosition(),0) SPC (%yPosition+getWord(%parent.getCanvasPosition(),1));
   }
   else
   {
      %parent = %this.getGroup();
      %maxArea = getWord(%parent.extent,1);
      %height = getWord(%this.extent,1);
      
      %yPosition = (%maxArea/2)-(%height/2);
      %this.position = getWord(%this.position,0) SPC %yPosition;
   }
}

//- GuiControl::shift (moves a gui in the X or Y)
function GuiControl::shift(%this,%x,%y)
{
   %this.position = vectorAdd(%this.position,%x SPC %y);
}

//- GuiControl::conditionalShiftY (shifts all controls >= %position by %amount in the Y)
function GuiControl::conditionalShiftY(%this,%position,%amount)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      %control = %this.getObject(%i);
      if(getWord(%control.position,1) >= %position)
         %control.shift(0,%amount);
   }
}

//- GuiControl::center (Centers %this inside %parent)
function GuiControl::center(%this,%parent)
{
   %this.centerX(%parent);
   %this.centerY(%parent);
}

//- GuiControl::getCanvasPosition (returns absolute position of a control on the canvas)
function GuiControl::getCanvasPosition(%this)
{
   %targ = %this;
   %x = getWord(%this.position,0);
   %y = getWord(%this.position,1);
   while(isObject(%targ.getGroup()))
   {
      %parent = %targ.getGroup();
      if(%parent.getName() $= "Canvas")
         return %x SPC %y;
         
      %x += getWord(%parent.position,0);
      %y += getWord(%parent.position,1);
      %targ = %parent;
   }
}

//- GuiControl::getPosRelativeTo (gets ctrl pos relative to ctrl)
function GuiControl::getPosRelativeTo(%this,%ctrl)
{
   %targ = %this;
   %x = getWord(%this.position,0);
   %y = getWord(%this.position,1);
   while(isObject(%targ.getGroup()))
   {
      %parent = %targ.getGroup();
      if(%parent.getName() $= "Canvas" || %parent $= %ctrl.getId())
         return %x SPC %y;
         
      %x += getWord(%parent.position,0);
      %y += getWord(%parent.position,1);
      %targ = %parent;
   }
}

//- GuiControl::getAbsPosition (returns absolute position of a control on the parent ctrl)
function GuiControl::getAbsPosition(%this,%ctrl)
{
   %targ = %this;
   %x = getWord(%this.position,0);
   %y = getWord(%this.position,1);
   while(isObject(%targ.getGroup()))
   {
      %parent = %targ.getGroup();

      if(%parent $= %ctrl.getID())
         return %x SPC %y;
         
      %x += getWord(%parent.position,0);
      %y += getWord(%parent.position,1);
      %targ = %parent;
   }
}

//- GuiControl::getLowestPoint (finds the lowest point within a gui)
function GuiControl::getLowestPoint(%this)
{
   %lowest = 0;
   for(%i=0;%i<%this.getCount();%i++)
   {
      %obj = %this.getObject(%i);
      %low = getWord(%obj.position,1) + getWord(%obj.extent,1);
      if(%low > %lowest)
         %lowest = %low;
   }
   return %lowest;
}

//- GuiSwatchCtrl::fade (fades a ctrl in our out depending on args)
function GuiSwatchCtrl::fade(%this,%time,%step,%reverse)
{
   if(%time $= "" || %step $= "")
   {
      echo("\c1<input> (0): GuiSwatchCtrl::fade - wrong number of arguments.");
      echo("\c1<input> (0): usage: ctrl.fade(int time,int step_size,bool reverse)");
      return;
   }
   
   if(!isObject(%this))
      return;
      
   if(%this.alpha $= "")
      %this.alpha = getWord(%this.color,3);
      
   if(%reverse)
   {
      %currAlpha = getWord(%this.color,3);
      if(%currAlpha $= 0)
         %currAlpha = %this.alpha;
      %newAlpha = %currAlpha-%step;
      
      if(%newAlpha <= 0)
      {
         %this.color = getWords(%this.color,0,2) SPC 0;
         return;      
      }
      
      %this.color = getWords(%this.color,0,2) SPC %newAlpha;
      %this.schedule(%time,"fade",%time,%step,%reverse);
   }
   else
   {
      %currAlpha = getWord(%this.color,3);
      if(%currAlpha $= %this.alpha)
      {
         if(%this.alpha $= 0)
            return;
         %newAlpha = 0;
      }
      else
      {
         if(%currAlpha >= %this.alpha)
            return;
            
         %newAlpha = %currAlpha+%step;
         if(%newAlpha >= %this.alpha)
         {
            %this.color = getWords(%this.color,0,2) SPC %this.alpha;
            return;
         }
      }
      %this.color = getWords(%this.color,0,2) SPC %newAlpha;
      %this.schedule(%time,"fade",%time,%step,%reverse);
   }
}

//- GuiMLTextCtrl::fitText (fits text into certain width and adds ...)
function GuiMLTextCtrl::fitText(%this,%text)
{
   %this.setText("");
   %this.forceReflow();
   %height = getWord(%this.extent,1);
   
   %this.setText(%text);
   %this.forceReflow();
   
   while(getWord(%this.extent,1) > %height)
   {
      %text = getSubStr(%text,0,strLen(%text)-1);
      %this.setText(%text@"...");
      %this.forceReflow();
   }
}