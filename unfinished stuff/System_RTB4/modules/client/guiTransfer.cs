//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 266 $
//#      $Date: 2010-08-04 07:29:41 +0100 (Wed, 04 Aug 2010) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/branches/4000/modules/client/serverControl.cs $
//#
//#      $Id: serverControl.cs 266 2010-08-04 06:29:41Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Client / Gui Transfer
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::GuiTransfer = 1;

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::CGUITransfer::Config::MaxControls = 50;
$ORBS::CGUITransfer::Config::MaxElements = 100;
$ORBS::CGUITransfer::Controls = 0;

//*********************************************************
//* Registering Controls
//*********************************************************
//- ORBSCT_registerControl (Registers a GUI)
function ORBSCT_registerControl(%control,%props)
{
   if(ORBSCT_controlRegistered(%control))
      return;
      
   $ORBS::CGUITransfer::Control[$ORBS::CGUITransfer::Controls] = %control;
   $ORBS::CGUITransfer::ControlProps[$ORBS::CGUITransfer::Controls] = %props;
   $ORBS::CGUITransfer::Controls++;
}

//- ORBSCT_controlRegistered (Checks to see if a control has been registered already)
function ORBSCT_controlRegistered(%control)
{
   for(%i=0;%i<$ORBS::CGUITransfer::Controls;%i++)
   {
      if($ORBS::CGUITransfer::Control[%i] $= %control)
         return 1;
   }
   return 0;
}

//- ORBSCT_getControlProps (Gets the properties for a specific control)
function ORBSCT_getControlProps(%control)
{
   for(%i=0;%i<$ORBS::CGUITransfer::Controls;%i++)
   {
      if($ORBS::CGUITransfer::Control[%i] $= %control)
         return $ORBS::CGUITransfer::ControlProps[%i];
   }
   return 0;
}

//- ORBSCT_hasControlGotProps (Checks to see if a control has a certain prop)
function ORBSCT_hasControlGotProp(%control,%prop)
{
    %propList = ORBSCT_getControlProps(%control);
    
    if(%propList $= "")
        return 0;
        
    for(%i=0;%i<getWordCount(%propList);%i++)
    {
        if(getWord(%propList,%i) $= %prop)
            return 1;
    }
    return 0;
}

//- ORBSCT_getControlCRC (Calculates a CRC for server->client comparison)
function ORBSCT_getControlCRC()
{
   for(%i=0;%i<$ORBS::CGUITransfer::Controls;%i++)
   {
      %string = %string@$ORBS::CGUITransfer::Control[%i]@$ORBS::CGUITransfer::ControlProps[%i];
   }
   return getStringCRC(%string);
}

//- ORBSCT_checkValue (checks to see if some dumbass entered his key into the gui somewhere)
function ORBSCT_checkValue(%ctrl)
{
   %script = %ctrl.control.script;

   for(%i=0;%i<%script.numInputs;%i++)
   {
      %ctrl = %script.input[%i];
      if(strPos(%ctrl.getValue(),getKeyId()) >= 0)
      {
         MessageBoxOK("WARNING","NEVER ENTER YOUR BLOCKLAND KEY WHILE ON ANOTHER PLAYER'S SERVER");
         return 0;
      }
   }
   return 1;
}

//- ORBSCT_setElementProperty (Applies a server-transmitted property to a control)
function ORBSCT_setElementProperty(%ctrl, %prop, %propVal, %incremental)
{
   if(!isObject(%ctrl))
      return;
      
   if(%prop $= "command")
   {
      %ctrl.command = "if(ORBSCT_checkValue($thisControl)){"@ORBSCT_parseCommandParameter(%ctrl,%propVal)@"}";
   }
   else if(%prop $= "closeOnSubmit")
   {
      if(%propVal $= 1 && strPos(%ctrl.command,"canvas.popDialog") < 0)
         %ctrl.command = %ctrl.command@"canvas.popDialog("@%ctrl.control@");";
   }
   else
   {
      if(strPos(%prop,"=>") >= 1)
      {
         %propGet = getSubStr(%prop,0,strPos(%prop,"=>"));
         %propSet = getSubStr(%prop,strPos(%prop,"=>")+2,strLen(%prop));
      }
      else
      {
         %propGet = %propSet = %prop;
      }
      
      if(%incremental)
      { 
         if(strPos(%propGet,"f{") $= 0)
         {
            %propGet = getSubStr(%propGet,2,strLen(%propGet)-3);
            eval("%propValue = "@%ctrl@"."@%propGet@"();");
         }
         else
         {
            eval("%propValue = "@%ctrl@"."@%propGet@";");
         }
         %propValue = strReplace(%propValue,"\\","\\\\");
         %propValue = strReplace(%propValue,"\"","\\\"");
         
         %propVal = %propValue@%propVal;
      }
      
      if(strPos(%propSet,"f{") $= 0)
      {
         %propSet = getSubStr(%propSet,2,strLen(%propSet)-3);
         eval(%ctrl@"."@%propSet@"(\""@%propVal@"\");");
      }
      else
      {
         eval(%ctrl@"."@%propSet@" = \""@%propVal@"\";");
      }
   }
}

//*********************************************************
//* Mission Prep Phase (Phase 1)
//*********************************************************
//- clientCmdMissionStartPhase1 (New mission phase for gui transfer)
function clientCmdMissionPreparePhase1(%crc,%gui,%elements)
{
   //@LEGACY
   if($ORBS::Client::Cache::ServerorbsVersion < 4)
   {
      commandToServer('MissionPreparePhase1Ack',1);
      return;
   }
   
   if($ORBS::CGUITransfer::Cache::isReceiving !$= "")
   {
      echo("\c2*** Prep-Phase 1: Download GUI - Skipped (Not Receiving)");
      commandToServer('MissionPreparePhase1Ack',2);
      return;
   }
      
   if(!$ORBS::Options::GT::Enable)
   {
      $ORBS::CGUITransfer::Cache::isReceiving = 0;
      echo("\c2*** Prep-Phase 1: Download GUI - Skipped (Downloading Disabled)");
      commandToServer('MissionPreparePhase1Ack',2);
      return;
   }    
   else if(%crc !$= ORBSCT_getControlCRC())
   {
      $ORBS::CGUITransfer::Cache::isReceiving = 0;
      echo("\c2*** Prep-Phase 1: Download GUI - Skipped (CRC MISMATCH)");
      commandToServer('MissionPreparePhase1Ack',1);
      return;
   }
   echo("*** Prep-Phase 1: Download GUI");
   commandToServer('MissionPreparePhase1Ack');
   
   LoadingProgress.setValue(0);
   $ORBS::CGUITransfer::Cache::isReceiving = 1;   
   
   $ORBS::CGUITransfer::Cache::Load::GUI = %gui;
   $ORBS::CGUITransfer::Cache::Load::GUIDone = 0;
   $ORBS::CGUITransfer::Cache::Load::Elements = %elements;
   $ORBS::CGUITransfer::Cache::Load::ElementsDone = 0;
   $ORBS::CGUITransfer::Cache::Load::TotalElements = 0;
}

//*********************************************************
//* Mission Prep Phase (Phase 2) @LEGACY
//*********************************************************
//- clientCmdMissionStartPhase2 (New mission phase for gui transfer)
function clientCmdMissionPreparePhase2(%crc,%gui,%elements)
{
   if($ORBS::CGUITransfer::Cache::isReceiving !$= "")
   {
      echo("\c2*** Prep-Phase 2: Download GUI - Skipped (Not Receiving)");
      commandToServer('MissionPreparePhase2Ack',2);
      return;
   }
      
   if(!$ORBS::Options::GT::Enable)
   {
      $ORBS::CGUITransfer::Cache::isReceiving = 0;
      echo("\c2*** Prep-Phase 2: Download GUI - Skipped (Downloading Disabled)");
      commandToServer('MissionPreparePhase2Ack',2);
      return;
   }    
   else if(%crc !$= ORBSCT_getControlCRC())
   {
      $ORBS::CGUITransfer::Cache::isReceiving = 0;
      echo("\c2*** Prep-Phase 2: Download GUI - Skipped (CRC MISMATCH)");
      commandToServer('MissionPreparePhase2Ack',1);
      return;
   }
   echo("*** Prep-Phase 2: Download GUI");
   commandToServer('MissionPreparePhase2Ack');
   
   LoadingProgress.setValue(0);
   $ORBS::CGUITransfer::Cache::isReceiving = 1;   
   
   $ORBS::CGUITransfer::Cache::Load::GUI = %gui;
   $ORBS::CGUITransfer::Cache::Load::GUIDone = 0;
   $ORBS::CGUITransfer::Cache::Load::Elements = %elements;
   $ORBS::CGUITransfer::Cache::Load::ElementsDone = 0;
   $ORBS::CGUITransfer::Cache::Load::TotalElements = 0;
}

//*********************************************************
//* GUI Download
//*********************************************************
//- clientCmdORBS_receiveGUI (Begins the transfer of a gui to the client)
function clientCmdORBS_receiveGUI(%name)
{
   if(!$ORBS::CGUITransfer::Cache::isReceiving)
      return;
      
   if($ORBS::CGUITransfer::Cache::Load::GUIDone > $ORBS::CGUITransfer::Config::MaxControls)
   {
      $ORBS::CGUITransfer::Cache::isReceiving = 0;
      return;
   }
   
   $ORBS::CGUITransfer::Cache::Load::TotalElements = 0;
   $ORBS::CGUITransfer::Cache::Load::GUIDone++;
   LoadingProgressTxt.setText("LOADING GUI");
   
   %gui = ORBSCT_GUIManifest.populate(%name);
   $ORBS::CGUITransfer::Cache::Load::CurrDepth = 1;
   $ORBS::CGUITransfer::Cache::Load::CurrGUI = %gui;
}

//- clientcmdORBS_receiveElement (Receives a single element from the server)
function clientCmdORBS_receiveElement(%class,%name,%props,%depth)
{
   if(!$ORBS::CGUITransfer::Cache::isReceiving)
      return;
      
   if($ORBS::CGUITransfer::Cache::Load::TotalElements > $ORBS::CGUITransfer::Config::MaxElements)
      return;
      
   %lastCtrl = $ORBS::CGUITransfer::Cache::Load::LastElement;
   %control = $ORBS::CGUITransfer::Cache::Load::CurrGUI;
   %script = %control.script;
   %manifest = %script.getGroup();
   %props = strReplace(%props,"\r\n","<br>");
   %props = strReplace(%props,"\n","<br>");
   
   if(!ORBSCT_controlRegistered(%class))
      return;
      
   %name = filterString(%name,"ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789_");
   if(%name !$= "")
      %clName = "LMT_"@getRandomString(6);
      
   %ctrl = new (%class)(%clName)
   {
      control = %control;
   };
   
   if(%class $= "GuiWindowCtrl")
      %ctrl.closeCommand = "canvas.popDialog("@%control@");";
   
   if(%clName !$= "")
   {
      %script.serverToClient[%name] = %clName;
      %script.clientToServer[%clName] = %name;
      
      %script.input[%script.numInputs] = %ctrl;
      %script.numInputs++;
   }
   
   %propList = ORBSCT_getControlProps(%class);
   for(%i=0;%i<getFieldCount(%props);%i++)
   {
      %prop = getWord(%propList,%i);
      %propVal = getField(%props,%i);
      
      %propVal = strReplace(%propVal,"\\","\\\\");
      %propVal = strReplace(%propVal,"\"","\\\"");

      if(%prop $= "")
         continue;
      
      ORBSCT_setElementProperty(%ctrl,%prop,%propVal);
   }
   
   if(%depth > $ORBS::CGUITransfer::Cache::Load::CurrDepth)
   {
      %script.depthCtrl[%depth] = %lastCtrl;
      %lastCtrl.add(%ctrl);
   }
   else
      %script.depthCtrl[%depth].add(%ctrl);
      
   $ORBS::CGUITransfer::Cache::Load::CurrDepth = %depth;
   $ORBS::CGUITransfer::Cache::Load::ElementsDone++;
   $ORBS::CGUITransfer::Cache::Load::LastElement = %ctrl;
   $ORBS::CGUITransfer::Cache::Load::TotalElements++;
   LoadingProgress.setValue($ORBS::CGUITransfer::Cache::Load::ElementsDone/$ORBS::CGUITransfer::Cache::Load::Elements);
}

//- clientCmdORBS_receiveProperty (Receives a property for the last element)
function clientCmdORBS_receiveProperty(%prop,%propVal,%incremental)
{
   if(!$ORBS::CGUITransfer::Cache::isReceiving)
      return;
      
   %element = $ORBS::CGUITransfer::Cache::Load::LastElement;
   %propList = ORBSCT_getControlProps(%element.getClassName());
   %prop = getWord(%propList,%prop);
   
   %propVal = strReplace(%propVal,"\r\n","<br>");
   %propVal = strReplace(%propVal,"\n","<br>");
   %propVal = strReplace(%propVal,"\\","\\\\");
   %propVal = strReplace(%propVal,"\"","\\\"");
   
   ORBSCT_setElementProperty(%element,%prop,%propVal,%incremental);
}

//- clientCmdORBS_receiveComplete (Ends the gui transfer)
function clientcmdORBS_receiveComplete()
{
   $ORBS::CGUITransfer::Cache::isReceiving = 0;
   ORBSCT_GUIManifest.process();
}

//*********************************************************
//* GUI Data Handling
//*********************************************************
if(!isObject(ORBSCT_GUIManifest))
{
   new ScriptGroup(ORBSCT_GUIManifest)
   {
      guiCount = 0;
      passCount = 0;
   };
   ORBSGroup.add(ORBSCT_GUIManifest);
}

//- ORBSCT_GUIManifest::populate (Creates a new ghost of the server gui)
function ORBSCT_GUIManifest::populate(%this,%name)
{
   %serverName = %name;
   %clientName = "GUI_"@getRandomString(6);
   
   %so = new ScriptObject()
   {
      clientName = %clientName;
      serverName = %serverName;
      numInputs = 0;
   };
   %this.add(%so);
   
   %control = new GuiControl(%clientName)
   {
      profile = "GuiDefaultProfile";
      horizSizing = "right";
      vertSizing = "bottom";
      position = "0 0";
      extent = "640 480";
      minExtent = "8 2";
      visible = "1";
      
      script = %so;
      clientName = %clientName;
      serverName = %serverName;
   };
   %so.gui = %control;
   %so.depthCtrl1 = %control;
   
   %this.serverToClient[%serverName] = %clientName;
   %this.clientToServer[%clientName] = %serverName;
   %this.guiCount++;
   
   return %control;
}

//- ORBSCT_GUIManifest::purge (Removes all the gui ghosts from the client)
function ORBSCT_GUIManifest::purge(%this)
{
    while(%this.getCount() >= 1)
    {
        %gui = %this.getObject(0);
        if(isObject(%gui.gui))
            %gui.gui.delete();
            
        %this.serverToClient[%gui.serverName] = "";
        %this.clientToServer[%gui.clientName] = "";
        
        %gui.delete();
    }
    
    for(%i=0;%i<%this.passCount;%i++)
    {
       %this.pass[%i] = "";
    }
    %this.passCount = 0;
}

//- ORBSCT_GUIManifest::process (Performs second-pass on parsed data)
function ORBSCT_GUIManifest::process(%this)
{
    for(%i=0;%i<%this.passCount;%i++)
    {
       %pass = %this.pass[%i];
       %control = getField(%pass,0);
       %target = getField(%pass,1);
       %replace = getField(%pass,2);
       
       %replacement = %control.control.script.serverToClient[%target];
       if(%replacement $= "")
         %replacement = ORBSCT_GUIManifest.serverToClient[%target];
       %control.command = strReplace(%control.command,%replace,%replacement);
    }
}

//*********************************************************
//* Server->Client GUI Manips.
//*********************************************************
//- clientCmdORBS_OpenGui (Opens an orbs-transmitted gui)
function clientCmdORBS_OpenGui(%gui)
{
   if(isObject(ORBSCT_GUIManifest.serverToClient[%gui]))
      Canvas.pushDialog(ORBSCT_GUIManifest.serverToClient[%gui]);
   else if(strPos(%gui,"ORBS_") $= 0)
      Canvas.pushDialog(%gui);
}

//- clientCmdORBS_CloseGui (Closes an orbs-transmitted gui)
function clientCmdORBS_CloseGui(%gui)
{
   if(isObject(ORBSCT_GUIManifest.serverToClient[%gui]))
      Canvas.popDialog(ORBSCT_GUIManifest.serverToClient[%gui]);
   else if(strPos(%gui,"ORBS_") $= 0)
      Canvas.popDialog(%gui);
}

//- clientCmdORBS_ToggleGui (Toggles an orbs-transmitted gui)
function clientCmdORBS_ToggleGui(%gui)
{
   if(isObject(ORBSCT_GUIManifest.serverToClient[%gui]))
   {
      %target = ORBSCT_GUIManifest.serverToClient[%gui];
      if(%target.isAwake())
         Canvas.popDialog(%target);
      else
         Canvas.pushDialog(%target);
   }
}

//*********************************************************
//* Helper Functions
//*********************************************************
//- ORBSCT_parseCommandParameter (Rebuilds & filters command param to be safe - this is a bitch to debug so debugging calls have been left in)
function ORBSCT_parseCommandParameter(%ctrl,%p)
{
   %stringLength = strLen(%p);
   
   if(%stringLength <= 3)
   {
      echo("\c2ERROR: Invalid \"command\" value for control in GUI Transfer");
      return;
   }
   
   for(%i=0;%i<%stringLength;%i++)
   {
      //echo("\c2"@%p);
      if(strPos(%p,"(",%i) > %i)
      {
         %functionName = getSubStr(%p,%i,strPos(%p,"(",%i)-%i);
         if(%functionName $= "commandtoserver")
         {
            //echo("\c1 + pass #1");
            %i = strPos(%p,"(",%i)+1;
            if(getSubStr(%p,%i,1) $= "'")
            {
               //echo("\c1 + pass #2");
               %i++;
               %command = filterString(getSubStr(%p,%i,strPos(%p,"'",%i)-%i),"ABCDEFGHIJKLMNOPQRSTUVWXYZ01234567890_abcdefghijklmnopqrstuvwxyz");
               %i = strPos(%p,"'",%i)+1;
               %result = %result@"commandtoserver('"@%command@"'";               
               while(getSubStr(%p,%i,1) $= " ")
               {
                  %p = getSubStr(%p,0,%i)@getSubStr(%p,%i+1,strLen(%p));
               }
               
               if(getSubStr(%p,%i,1) $= ")")
               {
                  //echo("\c1 + close bracket reached");
                  %result = %result@");";
                  %i += 1;
               }
               else if(getSubStr(%p,%i,1) $= ",")
               {
                  %result = %result@",";
                  //echo("\c1 + comma detected");
                  while(strPos(%p,",",%i) >= 0)
                  {
                     %i++;
                     //echo("\c1   + top of loop");
                     //hl(%p,%i,"     ");
                     while(getSubStr(%p,%i,1) $= " ")
                     {
                        %p = getSubStr(%p,0,%i)@getSubStr(%p,%i+1,strLen(%p));
                     }

                     if(getSubStr(%p,%i,1) $= "'")
                     {
                        //echo("\c1     + single quote param");
                     }
                     else if(getSubStr(%p,%i,1) $= "\"")
                     {
                        //echo("\c1     + double quote param");
                        
                        %i++;
                        %k = 0;
                        while(%k < strLen(%p))
                        {
                           %char = getSubStr(%p,%i+%k,1);
                           if(%ignoreNext)
                           {
                              %k++;
                              %ignoreNext = 0;
                              continue;
                           }
                           if(%char $= "\"")
                           {
                              //echo("\c1     + arg["@%args@"]: "@ getSubStr(%p,%i,%k));
                              %arg[%command,%args] = getSubStr(%p,%i,%k);
                              %args[%command]++;
                              %result = %result@"\""@getSubStr(%p,%i,%k)@"\"";
                              break;
                           }
                           if(%char $= "\\")
                              %ignoreNext = 1;
                           %k++;
                        }
                        %i+=%k+1;
                        if(getSubStr(%p,%i,2) $= ");")
                        {
                           %i++;
                           %result = %result@");";
                           
                           %p = getSubStr(%p,%i++,strLen(%p));
                           %stringLength = strLen(%p);
                           %i = -1;
                           break;
                        }
                        else
                           %result = %result@",";
                     }
                     else
                     {
                        //echo("\c1     + unquoted param");
                        if(strPos(%p,",",%i) < strPos(%p,");",%i) && strPos(%p,",",%i) !$= -1)
                           %search = ",";
                        else
                           %search = ");";

                        %argumentContent = getSubStr(%p,%i,strLen(%p));
                        %argumentContent = trim(getSubStr(%argumentContent,0,strPos(%argumentContent,%search)));
                        %i+=strLen(%argumentContent)+strLen(%search)-1;
                        if(strPos(strlwr(%argumentContent),".getvalue()") >= 1)
                        {
                           %controlName = getSubStr(%argumentContent,0,strPos(%argumentContent,"."));
                           %controlName = filterString(%controlName,"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_");
                           if(strLen(%controlName) >= 1)
                           {
                              %result = %result@"<!"@%controlName@"!>.getValue()"@%search;
                              
                              ORBSCT_GUIManifest.pass[ORBSCT_GUIManifest.passCount] = %ctrl TAB %controlName TAB "<!"@%controlName@"!>";
                              ORBSCT_GUIManifest.passCount++;
                              //echo("\c1     + arg[] is getValue param");
                           }
                           else
                           {
                              echo("\c2ERROR: Invalid commandtoserver call in \"command\" value for control in GUI Transfer");
                              return;
                           }
                        }
                        else
                        {
                           %argumentContent = filterString(%argumentContent,"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_");
                           if(strLen(%argumentContent) >= 1)
                           {
                              //echo("\c1     + arg["@%args@"]: "@%argumentContent);
                              %arg[%command,%args] = %argumentContent;
                              %args[%command]++;
                              %result = %result@%argumentContent@%search;
                           }
                           else
                           {
                              echo("\c2ERROR: Invalid commandtoserver call in \"command\" value for control in GUI Transfer");
                              return;
                           }
                        }
                        
                        if(%search $= ");")
                        {
                           %p = getSubStr(%p,%i++,strLen(%p));
                           %stringLength = strLen(%p);
                           %i = -1;
                           break;
                        }
                     }
                  }
               }
               else
               {
                  echo("\c2ERROR: Invalid commandtoserver call in \"command\" value for control in GUI Transfer");
                  return;
               }
            }
            else
            {
               echo("\c2ERROR: Invalid commandtoserver call in \"command\" value for control in GUI Transfer (No single quotations?)");
               return;
            }
            %return = %return@"commandtoserver('"@%command@"'";
         }
         else if(%functionName $= "canvas.popDialog")
         {
            %controlName = getSubStr(%p,strPos(%p,"(",%i),strLen(%p));
            %controlName = getSubStr(%controlName,0,strPos(%controlName,")"));
            %controlName = filterString(%controlName,"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_");
            
            %result = %result@"canvas.popDialog(<!"@%controlName@"!>);";
            
            ORBSCT_GUIManifest.pass[ORBSCT_GUIManifest.passCount] = %ctrl TAB %controlName TAB "<!"@%controlName@"!>";
            ORBSCT_GUIManifest.passCount++;
            
            %p = getSubStr(%p,strPos(%p,";")+1,strLen(%p));
            %stringLength = strLen(%p);
            %i = -1;
         }
         else if(%functionName $= "canvas.pushDialog")
         {
            %controlName = getSubStr(%p,strPos(%p,"(",%i),strLen(%p));
            %controlName = getSubStr(%controlName,0,strPos(%controlName,")"));
            %controlName = filterString(%controlName,"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz_");
            
            %result = %result@"canvas.pushDialog(<!"@%controlName@"!>);";     
            
            ORBSCT_GUIManifest.pass[ORBSCT_GUIManifest.passCount] = %ctrl TAB %controlName TAB "<!"@%controlName@"!>";
            ORBSCT_GUIManifest.passCount++;   
            
            %p = getSubStr(%p,strPos(%p,";")+1,strLen(%p));
            %stringLength = strLen(%p);
            %i = -1;
         }
         else
         {
            echo("\c2ERROR: Invalid function called in \"command\" value for control in GUI Transfer");
            return;
         }
      }
      else
      {
         echo("\c2ERROR: Invalid \"command\" value for control in GUI Transfer (No brackets?)");
         return;
      }
   }
   return %result;
}

//*********************************************************
//* Module Package
//*********************************************************
package ORBS_Modules_Client_GuiTransfer
{
   function clientCmdMissionStartPhase1(%a,%b,%c,%d)
   {
     $ORBS::CGUITransfer::Cache::isReceiving = 0;
     Parent::clientCmdMissionStartPhase1(%a,%b,%c,%d);
   }
    
   function disconnectedCleanup()
   {
     ORBSCT_GUIManifest.purge();
     deleteVariables("$ORBS::CGUITransfer::Cache*");
     Parent::disconnectedCleanup();
   }
};

//*********************************************************
//* Transfer Definitions
//*
//* - Must match on server or it will halt + disable
//*   transfers, so no changing these (not that you would)
//*********************************************************
ORBSCT_registerControl("GuiBitmapButtonCtrl","profile horizSizing vertSizing position extent text bitmap mColor command closeOnSubmit");
ORBSCT_registerControl("GuiButtonCtrl","profile horizSizing vertSizing position extent text=>f{setText} command closeOnSubmit");
ORBSCT_registerControl("GuiBitmapCtrl","profile horizSizing vertSizing position extent bitmap");
ORBSCT_registerControl("GuiTextEditCtrl","profile horizSizing vertSizing position extent");
ORBSCT_registerControl("GuiTextCtrl","profile horizSizing vertSizing position extent f{getValue}=>f{setText}");
ORBSCT_registerControl("GuiMLTextCtrl","profile horizSizing vertSizing position extent f{getValue}=>f{setText}");
ORBSCT_registerControl("GuiCheckboxCtrl","profile horizSizing vertSizing position extent");
ORBSCT_registerControl("GuiSwatchCtrl","profile horizSizing vertSizing position extent color");
ORBSCT_registerControl("GuiWindowCtrl","profile horizSizing vertSizing position extent text=>f{setText} resizeWidth resizeHeight canMove canClose canMinimize canMaximize minSize");
ORBSCT_registerControl("GuiScrollCtrl","profile horizSizing vertSizing position extent hScrollBar vScrollBar childMargin rowHeight columnWidth");