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
//#   Hooks / Gui Transfer
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Hooks::GuiTransfer = 1;

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::RGUITransfer::Controls = 0;

//*********************************************************
//* Registering Controls
//*********************************************************
//- ORBSRT_registerControl (Registers a control)
function ORBSRT_registerControl(%control,%props)
{
   if(ORBSRT_controlRegistered(%control))
      return;
      
   $ORBS::RGUITransfer::Control[$ORBS::RGUITransfer::Controls] = %control;
   $ORBS::RGUITransfer::ControlProps[$ORBS::RGUITransfer::Controls] = %props;
   $ORBS::RGUITransfer::Controls++;
}

//- ORBSRT_controlRegistered (Checks to see if a control has already been registered)
function ORBSRT_controlRegistered(%control)
{
   for(%i=0;%i<$ORBS::RGUITransfer::Controls;%i++)
   {
      if($ORBS::RGUITransfer::Control[%i] $= %control)
         return 1;
   }
   return 0;
}

//- ORBSRT_getControlProps (Gets the properties of a control)
function ORBSRT_getControlProps(%control)
{
   for(%i=0;%i<$ORBS::RGUITransfer::Controls;%i++)
   {
      if($ORBS::RGUITransfer::Control[%i] $= %control)
         return $ORBS::RGUITransfer::ControlProps[%i];
   }
   return 0;
}

//- ORBSRT_getControlCRC (Calculates a CRC for comparison between server & client)
function ORBSRT_getControlCRC()
{
   for(%i=0;%i<$ORBS::RGUITransfer::Controls;%i++)
   {
      %string = %string@$ORBS::RGUITransfer::Control[%i]@$ORBS::RGUITransfer::ControlProps[%i];
   }
   return getStringCRC(%string);
}

//*********************************************************
//* GUI Data Handling
//*********************************************************
if(!isObject(ORBSRT_GUIManifest))
{
   new ScriptGroup(ORBSRT_GUIManifest)
   {
   };
}

//*********************************************************
//* GUI Registration Hook
//*********************************************************
//- ORBS_registerGUI (Registers a gui for transfer to the client)
function ORBS_registerGUI(%path)
{
   if(!isFile(%path))
      return;
      
   %file = new FileObject();
   %file.openForRead(%path);
   %line = %file.readLine();
   if(strPos(%line,"//") >= 0)
      %line = %file.readLine();
   %file.delete();
   
   if(strPos(%line,"new GuiControl") $= 0)
   {
      %controlName = getSubStr(%line,strPos(%line,"(")+1,strLen(%line));
      %controlName = getSubStr(%controlName,0,strPos(%controlName,")"));
   }
   else
   {
      echo("\c2ERROR: Downloadable GUI must start with a GuiControl Object in ORBS_registerGUI ("@%path@")");
      return;
   }
   
   for(%i=0;%i<ORBSRT_GUIManifest.getCount();%i++)
   {
      %obj = ORBSRT_GUIManifest.getObject(%i);
      if(%obj.name $= %controlName)
      {
         %obj.delete();
         break;
      }
   }
   
   if(!isObject(%controlName))
   {
      if($Server::Dedicated)
         ORBSRT_parseGUI(%path);
      else
         exec(%path);
         
      if(!isObject(%controlName))
      {
         echo("\c2ERROR: Execution failed for gui in ORBS_registerGUI ("@%path@")");
         return;
      }
   }
   
   %sg = new ScriptGroup()
   {
      name = %controlName;
      elements = 0;
   };
   ORBSRT_GUIManifest.add(%sg);
   ORBSRT_GUIManifest.items++;
   %controlName.script = %sg;
   
   ORBSRT_traverseGui(%controlName,%controlName,0);
}

//*********************************************************
//* Script Parsing (Fucking dedicated servers...)
//*********************************************************
function ORBSRT_parseGUI(%gui)
{
   %fileObject = new FileObject();
   if(!%fileObject.openForRead(%gui))
   {
      echo("\c2ERROR: Unable to open \""@%gui@"\" for parsing in ORBSRT_parseGui");
      %fileObject.delete();
      return 0;
   }
   
   %depth = 0;
   while(!%fileObject.isEOF())
   {
      %line = trim(%fileObject.readLine());
      
      if(getSubStr(%line,0,2) $= "//" || %line $= "")
         continue;
         
      if(getSubStr(%line,0,3) $= "new" && strPos(%line,"{") > -1)
      {
         %type = getWord(%line,1);
         %type = getSubStr(%type,0,strPos(%type,"("));
      
         %ctrlName = getSubStr(%line,strPos(%line,"(")+1,strLen(%line));
         %ctrlName = getSubStr(%ctrlName,0,strPos(%ctrlName,")"));      
         
         %so = new ScriptGroup(%ctrlName)
         {
            class = "Script_GUI"; //Awesome hack
         };
         %so.className = %type;
         
         if(isObject(%parent[%depth]))
         {
            if(%depth $= 0)
            {
               echo("\c2ERROR: You can only have one gui control at a depth of 0 in a gui file ("@%gui@")");
               %parent[0].delete();
               %fileObject.delete();
               return;
            }
            else
               %parent[%depth].add(%so);
         }
         %depth++;
         %parent[%depth] = %so;
         
         %inObject = 1;
         continue;
      }
      
      if(%inObject)
      {
         if(%line $= "};")
         {
            %depth--;
            %inObject = 0;
            continue;
         }

         if(strPos(%line," = \"") > 0 && strPos(%line,"\";") > 1)
         {
            %attrib = getSubStr(%line,0,strPos(%line," = \""));
            %value = getSubStr(%line,strPos(%line," = \"")+4,strLen(%line));
            %value = getSubStr(%value,0,strLen(%value)-2);
            eval(%so@"."@%attrib@" = \""@%value@"\";");
         }
      }
   }
   %fileObject.delete();
}

//*********************************************************
//* Recursive GUI Analysis
//*********************************************************
//- ORBSRT_traverseGui (Creates a manifest of details about the gui)
function ORBSRT_traverseGui(%ctrl,%top,%depth)
{
   if(!isObject(%ctrl))
      return;
      
   %script = %top.script;
   if(!isObject(%script))
      return;
   
   %depth++;
   for(%i=0;%i<%ctrl.getCount();%i++)
   {
      %cCtrl = %ctrl.getObject(%i);

      %classname = %cCtrl.getClassName();      
      if(ORBSRT_controlRegistered(%classname))
      {
         %script.elementClass[%script.elements] = %classname;
         %script.elementName[%script.elements] = %cCtrl.getName();         
         
         %elementProps = "";
         %propList = ORBSRT_getControlProps(%classname);
         for(%j=0;%j<getWordCount(%propList);%j++)
         {
            %prop = getWord(%propList,%j);
            if(strPos(%prop,"=>") >= 1)
            {
               %prop = getSubStr(%prop,0,strPos(%prop,"=>"));
            }
            if(strPos(%prop,"f{") $= 0)
            {
               %prop = getSubStr(%prop,2,strLen(%prop)-3);
               eval("%propValue = "@%cCtrl@"."@%prop@"();");
            }
            else
            {
               eval("%propValue = "@%cCtrl@"."@%prop@";");
            }
            %elementProps = %elementProps@%propValue;
            if(%j < getWordCount(%propList)-1)
               %elementProps = %elementProps@"\t";
         }
         %script.elementProps[%script.elements] = %elementProps;
         %script.elementDepth[%script.elements] = %depth;
         %script.elements++;
         ORBSRT_GUIManifest.elements++;
         
         ORBSRT_traverseGui(%cCtrl,%top,%depth);
      }
   }
}

//*********************************************************
//* Script_GUI support methods
//*********************************************************
//- Script_GUI::getClassName (returns class name of mock object)
function Script_GUI::getClassName(%this)
{
   return %this.className;
}

//- Script_GUI::getValue (returns text value of mock object)
function Script_GUI::getValue(%this)
{
   return %this.text;
}

//*********************************************************
//* Transfer Definitions
//*
//* - Must match on client or it will halt + disable
//*   transfers, so no changing these!
//*********************************************************
ORBSRT_registerControl("GuiBitmapButtonCtrl","profile horizSizing vertSizing position extent text bitmap mColor command closeOnSubmit");
ORBSRT_registerControl("GuiButtonCtrl","profile horizSizing vertSizing position extent text=>f{setText} command closeOnSubmit");
ORBSRT_registerControl("GuiBitmapCtrl","profile horizSizing vertSizing position extent bitmap");
ORBSRT_registerControl("GuiTextEditCtrl","profile horizSizing vertSizing position extent");
ORBSRT_registerControl("GuiTextCtrl","profile horizSizing vertSizing position extent f{getValue}=>f{setText}");
ORBSRT_registerControl("GuiMLTextCtrl","profile horizSizing vertSizing position extent f{getValue}=>f{setText}");
ORBSRT_registerControl("GuiCheckboxCtrl","profile horizSizing vertSizing position extent");
ORBSRT_registerControl("GuiSwatchCtrl","profile horizSizing vertSizing position extent color");
ORBSRT_registerControl("GuiWindowCtrl","profile horizSizing vertSizing position extent text=>f{setText} resizeWidth resizeHeight canMove canClose canMinimize canMaximize minSize");
ORBSRT_registerControl("GuiScrollCtrl","profile horizSizing vertSizing position extent hScrollBar vScrollBar childMargin rowHeight columnWidth");