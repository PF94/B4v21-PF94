//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 492 $
//#      $Date: 2013-04-21 12:36:33 +0100 (Sun, 21 Apr 2013) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/modules/client/serverControl.cs $
//#
//#      $Id: serverControl.cs 492 2013-04-21 11:36:33Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Client / Server Control
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::ServerControl = 1;

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::MCSC::OptionCats = 0;
$ORBS::MCSC::Options = 0;

//*********************************************************
//* Gui Initialisation
//*********************************************************
if(!$ORBS::MCSC::AppliedMaps)
{
   ORBS_addControlMap("keyboard","ctrl s","Server Control","ORBSSC_ToggleSC");
   $ORBS::MCSC::AppliedMaps = 1;
}

//- ORBSSC_ToggleSC (Toggles the server control window)
function ORBSSC_ToggleSC(%val)
{
   if(!%val)
      return;
      
   if($IamAdmin !$= 2)
      return;
      
   if(!$ORBS::Client::Cache::ServerhasORBS)
      return;
      
   if(ORBS_ServerControl.isAwake())
      canvas.popDialog(ORBS_ServerControl);
   else
      canvas.pushDialog(ORBS_ServerControl);
}

//*********************************************************
//* Option Registration
//*********************************************************
//- ORBSSC_cacheServerOption (Creates a manifest of options for the server to reference - what a mess!)
function ORBSSC_cacheServerOption(%optionName,%type,%style,%description,%category)
{
   if($ORBS::MCSC::Options[%category] $= "")
   {
      $ORBS::MCSC::OptionCat[$ORBS::MCSC::OptionCats] = %category;
      $ORBS::MCSC::OptionCats++;
      
      $ORBS::MCSC::Options[%category] = 0;
   }
   $ORBS::MCSC::CatOption[%category,$ORBS::MCSC::Options[%category]] = %optionName TAB %type TAB %style TAB %description TAB $ORBS::MCSC::Options;
   $ORBS::MCSC::Option[$ORBS::MCSC::Options] = %optionName TAB %type TAB %style TAB %description;
   $ORBS::MCSC::Options++;
   $ORBS::MCSC::Options[%category]++;
}

//*********************************************************
//* Server Options Definitions (Must match on server)
//*********************************************************
ORBSSC_cacheServerOption("Server Name","string 150","100 7 200 18","The Server Name is what is displayed to people who are browsing for servers to join.","Main Settings");
ORBSSC_cacheServerOption("Welcome Message","string 255","100 7 200 18","The Welcome Message is what is sent to users when they join the server. %1 is replaced with the player's name.","Main Settings");
ORBSSC_cacheServerOption("Max Players","playerlist 1 99","100 7 84 16","The Max Players is the max ammount of people allowed in the server. This includes the Server Host and the Admin. You can set this to less than the current number of players in the server.","Main Settings");
ORBSSC_cacheServerOption("Server Password","string 30","100 7 200 18","The Server Password prevents people without the password from joining the server.","Main Settings");
ORBSSC_cacheServerOption("Admin Password","string 30","100 7 200 18","The Admin Password allows people to enter a password to become Admin.","Main Settings");
ORBSSC_cacheServerOption("Super Admin Password","string 30","130 7 170 18","The Super Admin Password allows people to enter a password to become a Super Admin.","Main Settings");
ORBSSC_cacheServerOption("E-Tard Filer","bool","80 0 140 30","The E-Tard Filter prevents people from saying words in the e-tard word list.","Chat Settings");
ORBSSC_cacheServerOption("E-Tard Words","string 255","80 7 220 18","Words should be separated by commas. A space before and after means it must be a whole word, not a part of a bigger one.","Chat Settings");
ORBSSC_cacheServerOption("Max Bricks per Second","int 0 999","200 7 100 18","The Max Bricks per Second is how many bricks users are allowed to place per second. For fast macroing, this should be set to 0.","Gameplay Settings");
ORBSSC_cacheServerOption("Falling Damage","bool","200 0 140 30","Falling Damage means falling from large heights will kill players.","Gameplay Settings");
ORBSSC_cacheServerOption("\"Too Far\" Distance for Building","int 0 9999","200 7 100 18","The Too Far distance is how close people have to be to their ghost brick to plant it.","Gameplay Settings");
ORBSSC_cacheServerOption("Wrench Events Admin Only","bool","200 0 140 30"," Wrench Events can be made Admin Only by using this setting.","Gameplay Settings");
ORBSSC_cacheServerOption("Bricks lose ownership after (minutes)","int -1 99999","200 7 100 18","This will make bricks lose their ownership if the owner is gone for more than the number of minutes in the box. This means any player will be able to build on or destroy those bricks. -1 disables this.","Gameplay Settings");

//*********************************************************
//* Prefs Registration
//*********************************************************
//- ORBSSC_cacheServerPref (Creates a manifest of prefs for the server to reference)
function ORBSSC_cacheServerPref(%id,%prefName,%category,%type,%requiresRestart)
{
   if($ORBS::MCSC::Cache::DownloadedServerPrefs)
      return;
      
   if($ORBS::MCSC::Cache::Prefs[%category] $= "")
   {
      $ORBS::MCSC::Cache::PrefCat[$ORBS::MCSC::Cache::PrefCats] = %category;
      $ORBS::MCSC::Cache::PrefCats++;
      
      $ORBS::MCSC::Cache::Prefs[%category] = 0;
   }
   $ORBS::MCSC::Cache::CatPref[%category,$ORBS::MCSC::Cache::Prefs[%category]] = %id TAB %prefName TAB %type TAB %requiresRestart;
   $ORBS::MCSC::Cache::Pref[$ORBS::MCSC::Cache::Prefs] = %id TAB %prefName TAB %type TAB %requiresRestart;
   $ORBS::MCSC::Cache::Prefs++;
   $ORBS::MCSC::Cache::Prefs[%category]++;
}

//*********************************************************
//* Main Control
//*********************************************************
//- ORBS_ServerControl::onWake (onwake callback for gui)
function ORBS_ServerControl::onWake(%this)
{
   for(%i=3;%i<%this.getObject(0).getCount();%i++)
   {
      %pane = %this.getObject(0).getObject(%i);
      if(%pane.visible)
      {
         %activePane = %pane.getName();
         break;
      }
   }
   
   if(!isObject(%activePane))
   {
      ORBS_ServerControl.setTab(1);
      %activePane = "ORBSSC_Pane1";
      return;
   }
   %call = %activePane@"::onView("@%activePane.getID()@");";
   eval(%call);
}

//- ORBS_ServerControl::setTab (Sets the tab for the server control window)
function ORBS_ServerControl::setTab(%this,%id)
{
   for(%i=5;%i<%this.getObject(0).getCount();%i++)
   {
      %pane = %this.getObject(0).getObject(%i);
      %pane.visible = 0;
   }
   %pane = "ORBSSC_Pane"@%id;
   %pane.visible = 1;
   %call = %pane@"::onView("@%pane@");";
   eval(%call);
   
   $ORBS::MCSC::Cache::currentTab = %id;
}

//*********************************************************
//* Server Options (SO) Pane 1
//*********************************************************
//- ORBSSC_Pane1::onView (Callback for viewing Pane 1)
function ORBSSC_Pane1::onView(%this)
{
   ORBSSC_applySettingsToControls();
   
   commandtoserver('ORBS_getServerOptions');
   ORBSSC_SO_Tip.setText("Click a Setting Name to view some information about it.");
}

//- ORBSSC_Pane1::render (Draws the list of items)
function ORBSSC_Pane1::render()
{
   %ctrl = ORBSSC_SO_Swatch.getID();
   %ctrl.clear();
   %y = 1;
   
   for(%i=0;%i<$ORBS::MCSC::OptionCats;%i++)
   {
      %category = $ORBS::MCSC::OptionCat[%i];

      %header = new GuiSwatchCtrl() {
         profile = "GuiDefaultProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "2 "@%y;
         extent = "330 30";
         minExtent = "8 2";
         visible = "1";
         color = "0 0 0 50";
         
         new GuiTextCtrl() {
            profile = "ORBS_HeaderText";
            horizSizing = "right";
            vertSizing = "center";
            position = "5 6";
            extent = "200 18";
            minExtent = "8 2";
            visible = "1";
            text = "\c1"@%category;
            maxLength = "255";
         };
      };
      %ctrl.add(%header);
      %ctrl.resize(0,1,316,%y+31);
      %y+=31;
      
      for(%k=0;%k<$ORBS::MCSC::Options[%category];%k++)
      {
         %option = $ORBS::MCSC::CatOption[%category,%k];
         
         if(%k%2 $= 0)
            %color = "0 0 0 10";
         else
            %color = "0 0 0 0";
            
         %ctrlRow = new GuiSwatchCtrl() {
            profile = "GuiDefaultProfile";
            horizSizing = "right";
            vertSizing = "bottom";
            position = "2 "@%y;
            extent = "353 29";
            minExtent = "8 2";
            visible = "1";
            color = %color;
            
            new GuiTextCtrl() {
               profile = "GuiTextProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "5 5";
               extent = "66 18";
               minExtent = "8 2";
               visible = "1";
               text = "\c2"@getField(%option,0)@":";
               maxLength = "255";
            };
         };
         %ctrl.add(%ctrlRow);
         
         %type = getField(%option,1);
         %style = getField(%option,2);
         %settingTip = new GuiBitmapButtonCtrl()
         {
            position = "2 "@%y;
            extent = getWord(%style,0)-10@" 29";
            bitmap = "base/client/ui/button1";
            text = " ";
            mColor = "0 0 0 0";
            command = "ORBSSC_displaySettingTip("@getField(%option,4)@");";
         };
         %ctrl.add(%settingTip);
         
         %inputName = "ORBS_MCSC_Opt"@getField(%option,4);
         if(firstWord(%type) $= "string")
         {
            %input = new GuiTextEditCtrl(%inputName) {
               profile = "ORBS_TextEditProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = getWords(%style,0,1);
               extent = getWords(%style,2,3);
               minExtent = "8 2";
               visible = "1";
               maxLength = getWord(%type,1);
               historySize = "0";
               password = "0";
               tabComplete = "0";
               sinkAllKeyEvents = "0";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "int")
         {
            %input = new GuiTextEditCtrl(%inputName) {
               profile = "ORBS_TextEditProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = getWords(%style,0,1);
               extent = getWords(%style,2,3);
               minExtent = "8 2";
               visible = "1";
               maxLength = "50";
               historySize = "0";
               password = "0";
               tabComplete = "0";
               sinkAllKeyEvents = "0";
               fieldMin = getWord(%type,1);
               fieldMax = getWord(%type,2);
               command = "ORBSSC_PF_ValidateInt($ThisControl);";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "bool")
         {
            %input = new GuiCheckboxCtrl(%inputName) {
               profile = "ORBS_CheckboxProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = getWords(%style,0,1);
               extent = getWords(%style,2,3);
               minExtent = "8 2";
               visible = "1";
               text = " ";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "playerlist")
         {
            %input = new GuiPopupMenuCtrl(%inputName) {
               profile = "ORBS_PopupProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = getWords(%style,0,1);
               extent = getWords(%style,2,3);
               minExtent = "8 2";
               visible = "1";
               text = " ";
            };
            %ctrlRow.add(%input);
            
            for(%l=getWord(%type,1);%l<=getWord(%type,2);%l++)
            {
               %s = "s";
               if(%l $= 1)
                  %s = "";
               %input.add(%l@" Player"@%s,%l);
            }
         }
         %ctrl.resize(0,1,316,%y+30);
         %y+=30;
      }
   }
}

//- ORBSSC_displaySettingTip (Allows user to click a setting and view details on it)
function ORBSSC_displaySettingTip(%id)
{
   ORBSSC_SO_Tip.setText(getField($ORBS::MCSC::Option[%id],3));
}

//- clientCmdORBS_getServerOptions (Response from server when requesting settings)
function clientCmdORBS_getServerOptions(%options,%v1,%v2,%v3,%v4,%v5,%v6,%v7,%v8,%v9,%v10,%v11,%v12,%v13,%v14,%v15,%v16)
{
   for(%i=0;%i<getWordCount(%options);%i++)
   {
      if(getWord(%options,%i) $= "D")
      {
         $ORBS::MCSC::Cache::DownloadedServerOptions = 1;
         continue;
      }
      
      %oldSetting = $ORBS::MCSC::Value[getWord(%options,%i)];
      %value = %v[%i+1];
      %value = strReplace(%value,"\c0","\\c0");
      %value = strReplace(%value,"\c1","\\c1");
      %value = strReplace(%value,"\c2","\\c2");
      %value = strReplace(%value,"\c3","\\c3");
      %value = strReplace(%value,"\c4","\\c4");
      %value = strReplace(%value,"\c5","\\c5");
      %value = strReplace(%value,"\c6","\\c6");
      %value = strReplace(%value,"\c7","\\c7");
      %value = strReplace(%value,"\c8","\\c8");
      %value = strReplace(%value,"\c9","\\c9");
      %value = strReplace(%value,"\n","\\n");
      $ORBS::MCSC::Value[getWord(%options,%i)] = %value;
      %ctrl = "ORBS_MCSC_Opt"@getWord(%options,%i);
      
      if(ORBS_ServerControl.isAwake() && $ORBS::MCSC::Cache::currentTab $= 1)
      {
         if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
            %oldValue = %ctrl.getSelected();
         else
            %oldValue = %ctrl.getValue();
         
         if(%oldSetting !$= %oldValue && $ORBS::MCSC::Cache::DownloadedServerOptions)
         {
            MessageBoxYesNo("Uh Oh!","Another user has changed some settings that you have changed but not saved. Would you like to replace your changes with the new values?","ORBSSC_applySettingsToControls();");
         }
         else
         {
            if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
               %ctrl.setSelected(%value);
            else
               %ctrl.setValue(%value);
         }
      }
   }
}

//- ORBSSC_applySettingsToControls (Applies all the cached server options to their controls)
function ORBSSC_applySettingsToControls()
{
   for(%i=0;%i<$ORBS::MCSC::Options;%i++)
   {
      %option = $ORBS::MCSC::Option[%i];
      %ctrl = "ORBS_MCSC_Opt"@%i;

      if(!isObject(%ctrl))
         continue;
         
      %value = $ORBS::MCSC::Value[%i];
      
      if(firstWord(getField(%option,1)) $= "playerlist")
         %ctrl.setSelected(%value);
      else
         %ctrl.setValue(%value);
   }
}

//- ORBSSC_Pane1::saveOptions (Save all the changes and send to the server)
function ORBSSC_Pane1::saveOptions(%this)
{
   for(%i=0;%i<$ORBS::MCSC::Options;%i++)
   {
      %option = $ORBS::MCSC::Option[%i];
      %ctrl = "ORBS_MCSC_Opt"@%i;
      if(firstWord(getField(%option,1)) $= "playerlist")
         %value = %ctrl.getSelected();
      else
         %value = %ctrl.getValue();
         
      if($ORBS::MCSC::Value[%i] !$= %value)
      {
         %changes = %changes@%i@" ";
      }
   }
   
   if(getWordCount(%changes) >= 1 && strLen(%changes) >= 2)
   {
      %changes = getSubStr(%changes,0,strLen(%changes)-1);
      
      for(%i=0;%i<getWordCount(%changes);%i++)
      {
         %option = $ORBS::MCSC::Option[getWord(%changes,%i)];
         %ctrl = "ORBS_MCSC_Opt"@getWord(%changes,%i);
         if(firstWord(getField(%option,1)) $= "playerlist")
            %value = %ctrl.getSelected();
         else
            %value = %ctrl.getValue();
         %seq = %i%16;
         
         %var[%seq] = %value;
         %options = %options@getWord(%changes,%i)@" ";
         
         if(%i%16 $= 15 || %i $= getWordCount(%changes)-1)
         {
            if(%numSent > 0)
               %options = %options@"N ";
            if(%i $= getWordCount(%changes)-1)
               %options = %options@"D ";
            %numSent++;
            commandtoserver('ORBS_setServerOptions',$ORBS::Options::SC::NotifySettings,getSubStr(%options,0,strLen(%options)-1),%var0,%var1,%var2,%var3,%var4,%var5,%var6,%var7,%var8,%var9,%var10,%var11,%var12,%var13,%var14,%var,%var15);
            %options = "";
            for(%j=0;%j<16;%j++)
            {
               %var[%j] = "";
            }
         }
      }
   }
   else
   {
      MessageBoxOK("Ooops","You have not made any changes to save.");
      return;
   }
}

//*********************************************************
//* Auto Admin (AA) Pane 2
//*********************************************************
//- ORBSSC_Pane2::onView (Callback for viewing Pane 2)
function ORBSSC_Pane2::onView(%this)
{
	commandtoserver('ORBS_getAutoAdminList');

	ORBSSC_AA_RemoveAuto.setVisible(1);
	ORBSSC_AA_Add_Status.clear();
	ORBSSC_AA_Add_Status.add("Admin",0);
	ORBSSC_AA_Add_Status.add("Super Admin",1);
	ORBSSC_AA_Add_Status.setSelected(0);
	ORBSSC_AA_Add_ID.setValue("");
	ORBSSC_AA_AddStatus.setVisible(0);
	
	ORBSSC_AA_PlayerList.clear();
	for(%i=0;%i<NPL_List.rowCount();%i++)
	{
	   %row = getFields(NPL_List.getRowText(%i),0,1) TAB getField(NPL_List.getRowText(%i),3);
	   %id = NPL_List.getRowId(%i);
      ORBSSC_AA_PlayerList.addRow(%id,%row);
	}
}

//- ORBSSC_AA_AdminList::onSelect
function ORBSSC_AA_AdminList::onSelect(%this,%id,%text)
{
	ORBSSC_AA_RemoveAuto.setVisible(0);
}

//- ORBSSC_Pane2::addAutoStatus (Adds a person as an auto admin)
function ORBSSC_Pane2::addAutoStatus(%this)
{
	%bl_id = ORBSSC_AA_Add_ID.getValue();
	%status = ORBSSC_AA_Add_Status.getValue();

	if(%bl_id $= "" || %bl_id < 0)
		messageBoxOK("Whoopsie Daisy","You haven't entered a valid BL_ID.");
	else if(%status !$= "Admin" && %status !$= "Super Admin")
		messageBoxOK("Whoopsie Daisy","You haven't selected a valid Status.");
	else if(!isInt(%bl_id))
		messageBoxOK("Whoopsie Daisy","You have entered an invalid BL_ID.");
	else
	{
		ORBSSC_AA_Add_Status.setSelected(0);
		ORBSSC_AA_Add_ID.setValue("");
		ORBSSC_AA_AddStatus.setVisible(0);
		commandToServer('ORBS_addAutoStatus',%bl_id,%status);
	}
}

//- ORBSSC_Pane2::removeAutoStatus (Removes a person from the auto admin list)
function ORBSSC_Pane2::removeAutoStatus(%this)
{
	%bl_id = getField(ORBSSC_AA_AdminList.getValue(),0);
	if(%bl_id  $= "")
		messageBoxOK("Whoopsie Daisy","You haven't selected a valid BL_ID.");
	else
		commandToServer('ORBS_removeAutoStatus',%bl_id);
}

//- clientCmdORBS_getAutoAdminList (Gets the contents of the server admin/super admin lists)
function clientCmdORBS_getAutoAdminList(%adminList,%superAdminList)
{
	ORBSSC_AA_AdminList.clear();
	for(%i=0;%i<getWordCount(%superAdminList);%i++)
	{
		%id = getWord(%superAdminList,%i);
		if(%id $= "")
		   continue;
		if(ORBSSC_AA_AdminList.findTextIndex(%id TAB "Super Admin") $= -1 && %id >= 0)
			ORBSSC_AA_AdminList.addRow(%k++,%id TAB "Super Admin");
	}
	for(%i=0;%i<getWordCount(%adminList);%i++)
	{
		%id = getWord(%adminList,%i);
		if(%id $= "")
		   continue;
		if(ORBSSC_AA_AdminList.findTextIndex(%id TAB "Admin") $= -1 && ORBSSC_AA_AdminList.findTextIndex(%id TAB "Super Admin") $= -1 && %id >= 0)
			ORBSSC_AA_AdminList.addRow(%k++,%id TAB "Admin");
	}
	ORBSSC_AA_AdminList.sortNumerical(0,1);
	ORBSSC_AA_RemoveAuto.setVisible(1);
}

//- ORBSSC_Pane2::clearAll (Clears all the auto admin entries)
function ORBSSC_Pane2::clearAll(%this,%confirm)
{
	if(!%confirm)
	{
		MessageBoxYesNo("Really?","Are you sure you want to delete ALL the Auto Admin Entries?","ORBSSC_Pane2::clearAll("@%this@",1);","");
		return;
	}
	commandtoserver('ORBS_clearAutoAdminList');
}

//- ORBSSC_Pane2::addFromList (Adds a selected player to the auto admin list)
function ORBSSC_Pane2::addFromList(%this)
{
   ORBSSC_AA_AddStatus.setVisible(1);
   ORBSSC_AA_Add_ID.setValue(getField(ORBSSC_AA_PlayerList.getValue(),2));
}

//- ORBSSC_Pane2::deAdmin (De-admins a player)
function ORBSSC_Pane2::deAdmin(%this)
{
   %sel = ORBSSC_AA_PlayerList.getSelectedID();
   if(%sel $= "-1")
   {
      messageBoxOK("Ooops","You need to select someone from the right list to De-Admin.");
      return;
   }
   commandtoserver('ORBS_DeAdminPlayer',%sel);
}

//- ORBSSC_Pane2::admin (Sets a player to admin)
function ORBSSC_Pane2::admin(%this)
{
   %sel = ORBSSC_AA_PlayerList.getSelectedID();
   if(%sel $= "-1")
   {
      messageBoxOK("Ooops","You need to select someone from the right list to Admin.");
      return;
   }
   commandtoserver('ORBS_AdminPlayer',%sel);
}

//- ORBSSC_Pane2::superAdmin (Sets a player to super admin)
function ORBSSC_Pane2::superAdmin(%this)
{
   %sel = ORBSSC_AA_PlayerList.getSelectedID();
   if(%sel $= "-1")
   {
      messageBoxOK("Ooops","You need to select someone from the right list to Super Admin.");
      return;
   }
   commandtoserver('ORBS_SuperAdminPlayer',%sel);
}

//*********************************************************
//* Preferences (PF) Pane 3
//*********************************************************
//- ORBSSC_Pane3::onView (Callback for viewing Pane 3)
function ORBSSC_Pane3::onView(%this)
{
   ORBSSC_applyPrefsToControls();
}

//- ORBSSC_Pane3::render (Draws the list of items)
function ORBSSC_Pane3::render()
{
   %ctrl = ORBSSC_SP_Swatch.getID();
   %ctrl.clear();
   %y = 1;
   
   if($ORBS::MCSC::Cache::PrefCats <= 0)
   {
      ORBSSC_SP_Swatch.resize(0,1,316,280);
      %txt = new GuiTextCtrl()
      {
         profile = ORBS_AutoVerdana12;
         position = "48 132";
         text = "This server has no preferences to manage.";
         horizSizing = "center";
         vertSizing = "center";
      };
      ORBSSC_SP_Swatch.add(%txt);
      return;
   }
   
   for(%i=0;%i<$ORBS::MCSC::Cache::PrefCats;%i++)
   {
      %category = $ORBS::MCSC::Cache::PrefCat[%i];
      
      %header = new GuiSwatchCtrl() {
         profile = "GuiDefaultProfile";
         horizSizing = "right";
         vertSizing = "bottom";
         position = "2 "@%y;
         extent = "330 30";
         minExtent = "8 2";
         visible = "1";
         color = "0 0 0 50";
         
         new GuiTextCtrl() {
            profile = "ORBS_HeaderText";
            horizSizing = "right";
            vertSizing = "center";
            position = "5 6";
            extent = "200 18";
            minExtent = "8 2";
            visible = "1";
            text = "\c1"@%category;
            maxLength = "255";
         };
      };
      %ctrl.add(%header);
      %ctrl.resize(0,1,316,%y+31);
      %y+=31;
      
      for(%k=0;%k<$ORBS::MCSC::Cache::Prefs[%category];%k++)
      {
         %pref = $ORBS::MCSC::Cache::CatPref[%category,%k];
         
         if(%k%2 $= 0)
            %color = "0 0 0 10";
         else
            %color = "0 0 0 0";
            
         if(getField(%pref,3))
            %star = "*";
         else
            %star = "";
            
         %ctrlRow = new GuiSwatchCtrl() {
            profile = "GuiDefaultProfile";
            horizSizing = "right";
            vertSizing = "bottom";
            position = "2 "@%y;
            extent = "353 29";
            minExtent = "8 2";
            visible = "1";
            color = %color;
            
            new GuiTextCtrl() {
               profile = "GuiTextProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "5 5";
               extent = "66 18";
               minExtent = "8 2";
               visible = "1";
               text = "\c2"@getField(%pref,1)@%star@":";
               maxLength = "255";
            };
         };
         %ctrl.add(%ctrlRow);
         
         %type = getField(%pref,2);
         %inputName = "ORBSSC_SP_Pref"@getField(%pref,0);
         if(firstWord(%type) $= "string")
         {
            %input = new GuiTextEditCtrl(%inputName) {
               profile = "ORBS_TextEditProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "150 7";
               extent = "150 16";
               minExtent = "8 2";
               visible = "1";
               maxLength = getWord(%type,1);
               historySize = "0";
               password = "0";
               tabComplete = "0";
               sinkAllKeyEvents = "0";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "int")
         {
            %input = new GuiTextEditCtrl(%inputName) {
               profile = "ORBS_TextEditProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "150 7";
               extent = "150 16";
               minExtent = "8 2";
               visible = "1";
               maxLength = strLen(getWord(%type,2));
               historySize = "0";
               password = "0";
               tabComplete = "0";
               sinkAllKeyEvents = "0";
               fieldMin = getWord(%type,1);
               fieldMax = getWord(%type,2);
               command = "ORBSSC_PF_ValidateInt($ThisControl);";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "num")  //basically int with support for decimals
         {
            %input = new GuiTextEditCtrl(%inputName) {
               profile = "ORBS_TextEditProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "150 7";
               extent = "150 16";
               minExtent = "8 2";
               visible = "1";
               maxLength = strLen(getWord(%type,2))+1;
               historySize = "0";
               password = "0";
               tabComplete = "0";
               sinkAllKeyEvents = "0";
               fieldMin = getWord(%type,1);
               fieldMax = getWord(%type,2);
               command = "ORBSSC_PF_ValidateNum($ThisControl);";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "float")
         {
            %inputnameB = %inputname@"_ChildText";

            %input = new GuiSliderCtrl(%inputName) {
               profile = "GuiSliderProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "150 5";
               extent = "100 20";
               minExtent = "8 2";
               visible = "1";
               ticks = "12";
               snap = "0";
               range = getWord(%type, 1) SPC getWord(%type, 2);
               textbox = %inputnameB;
               command = "ORBSSC_PF_ValidateFloat($ThisControl);";
            };
            %ctrlRow.add(%input);

            %inputB = new GuiTextCtrl(%inputnameB) {
               profile = "GuiTextProfile";
               horizSizing = "right";
               VertSizing = "bottom";
               position = "255 5";
               text = " ";
               visible = "1";
            };
            %ctrlRow.add(%inputB);
         }
         else if(firstWord(%type) $= "bool")
         {
            %input = new GuiCheckboxCtrl(%inputName) {
               profile = "ORBS_CheckboxProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "156 1";
               extent = "140 30";
               minExtent = "8 2";
               visible = "1";
               text = " ";
            };
            %ctrlRow.add(%input);
         }
         else if(firstWord(%type) $= "list")
         {
            %input = new GuiPopupMenuCtrl(%inputName) {
               profile = "ORBS_PopupProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "150 7";
               extent = "150 16";
               minExtent = "8 2";
               visible = "1";
               text = " ";
            };
            %ctrlRow.add(%input);
            
            for(%l=1;%l<getWordCount(%type);%l+=2)
            {
               %input.add(getWord(%type,%l),getWord(%type,%l+1));
            }
         }
         else if(firstWord(%type) $= "datablock")
         {
            %input = new GuiPopupMenuCtrl(%inputName) {
               profile = "ORBS_PopupProfile";
               horizSizing = "right";
               vertSizing = "bottom";
               position = "150 7";
               extent = "150 16";
               minExtent = "8 2";
               visible = "1";
               text = " ";
            };
            %ctrlRow.add(%input);
            
            %dataGroup = ServerConnection;
            if(DataBlockGroup.getCount() > 0)
               %dataGroup = DataBlockGroup;
            for(%l=0;%l<%dataGroup.getCount();%l++)
            {
               %object = %dataGroup.getObject(%l);
               if(%object.getClassName() $= lastWord(%type) && %object.uiName !$= "")
                  %input.add(%object.uiName, %object.getId());
            }
         }
         %ctrl.resize(0,1,316,%y+30);
         %y+=30;
      }
   }
}

//- clientCmdORBS_addServerPrefs (Response from server to populate prefs menu)
function clientCmdORBS_addServerPrefs(%prefs,%v1,%v2,%v3,%v4,%v5,%v6,%v7,%v8,%v9,%v10,%v11,%v12,%v13,%v14,%v15,%v16)
{
   for(%i=0;%i<getWordCount(%prefs);%i++)
   {
      if(getWord(%prefs,%i) $= "D")
      {
         $ORBS::MCSC::Cache::DownloadedServerPrefs = 1;
         ORBSSC_Pane3::render();
         return;
      }
      ORBSSC_cacheServerPref(getWord(%prefs,%i),getField(%v[%i+1],0),getField(%v[%i+1],1),getField(%v[%i+1],2),getField(%v[%i+1],3));
   }
}

//- clientCmdORBS_setServerPrefs (Response from server to cache prefs values on the client)
function clientCmdORBS_setServerPrefs(%prefs,%v1,%v2,%v3,%v4,%v5,%v6,%v7,%v8,%v9,%v10,%v11,%v12,%v13,%v14,%v15,%v16)
{
   for(%i=0;%i<getWordCount(%prefs);%i++)
   {
      %oldPref = $ORBS::MCSC::Cache::PrefValue[getWord(%prefs,%i)];
      %value = %v[%i+1];
      $ORBS::MCSC::Cache::PrefValue[getWord(%prefs,%i)] = %value;
      %ctrl = "ORBSSC_SP_Pref"@getWord(%prefs,%i);
      
      if(ORBS_ServerControl.isAwake() && $ORBS::MCSC::Cache::currentTab $= 3)
      {
         if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
            %oldValue = %ctrl.getSelected();
         else
            %oldValue = %ctrl.getValue();
               
         if(%value !$= %oldValue && $ORBS::MCSC::Cache::DownloadedServerPrefs)
         {
            MessageBoxYesNo("Uh Oh!","Another user has changed some prefs that you have changed but not saved. Would you like to replace your changes with the new values?","ORBSSC_applyPrefsToControls();");
         }
         else
         {
            if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
               %ctrl.setSelected(%value);
            else
               %ctrl.setValue(%value);
         }
      }
   }
}

//- ORBSSC_applyPrefsToControls (Applies all the cached server prefs to their controls)
function ORBSSC_applyPrefsToControls()
{
   for(%i=0;%i<$ORBS::MCSC::Cache::Prefs;%i++)
   {
      %pref = $ORBS::MCSC::Cache::Pref[%i];
      %ctrl = "ORBSSC_SP_Pref"@%i;
      if(!isObject(%ctrl))
         continue;
         
      %value = $ORBS::MCSC::Cache::PrefValue[%i];
      
      if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
         %ctrl.setSelected(%value);
      else
         %ctrl.setValue(%value);
         
      if(isObject(%ctrl.textbox)) //currently, the only pref that uses this is the slider
         ORBSSC_PF_ValidateFloat(%ctrl);
   }
}

//- ORBSSC_Pane3::saveOptions (Saves all the pref changes)
function ORBSSC_Pane3::saveOptions()
{
   for(%i=0;%i<$ORBS::MCSC::Cache::Prefs;%i++)
   {
      %pref = $ORBS::MCSC::Cache::Pref[%i];
      %ctrl = "ORBSSC_SP_Pref"@%i;
      if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
         %value = %ctrl.getSelected();
      else
         %value = %ctrl.getValue();
      %storedValue = $ORBS::MCSC::Cache::PrefValue[%i];
      
      if(%value !$= %storedValue)
      {
         %changes = %changes@%i@" ";
      }
   }
   
   if(getWordCount(%changes) >= 1 && strLen(%changes) >= 1)
   {
      %changes = getSubStr(%changes,0,strLen(%changes)-1);
      
      for(%i=0;%i<getWordCount(%changes);%i++)
      {
         %ctrl = "ORBSSC_SP_Pref"@getWord(%changes,%i);
         if(%ctrl.getClassName() $= "GuiPopupMenuCtrl")
            %value = %ctrl.getSelected();
         else
            %value = %ctrl.getValue();
         %seq = %i%16;
         
         %var[%seq] = %value;
         %prefs = %prefs@getWord(%changes,%i)@" ";
         
         if(%i%16 $= 15 || %i $= getWordCount(%changes)-1)
         {
            if(%numSent > 0)
               %prefs = %prefs@"N ";
            if(%i $= getWordCount(%changes)-1)
               %prefs = %prefs@"D ";
            %numSent++;
            commandtoserver('ORBS_setServerPrefs',getSubStr(%prefs,0,strLen(%prefs)-1),%var0,%var1,%var2,%var3,%var4,%var5,%var6,%var7,%var8,%var9,%var10,%var11,%var12,%var13,%var14,%var,%var15);
            %prefs = "";
            for(%j=0;%j<16;%j++)
            {
               %var[%j] = "";
            }
         }
      }
   }
   else
   {
      MessageBoxOK("Ooops","You have not made any changes to save.");
      return;
   }
}

//- ORBSSC_Pane3::resetOptions (Resets all options back to defaults)
function ORBSSC_Pane3::resetOptions(%this,%confirm)
{
	if(!%confirm)
	{
		MessageBoxYesNo("Really?","Are you sure you want to reset ALL the server preferences to their default values?","ORBSSC_Pane3::resetOptions("@%this@",1);","");
		return;
	}
	commandtoserver('ORBS_defaultServerPrefs');
}

//- ORBSSC_PF_ValidateInt (Checks whether a value is a valid integer)
function ORBSSC_PF_ValidateInt(%ctrl)
{
   if(%ctrl.getValue() $= "")
      return;
   if(%ctrl.getValue() $= "-")
      return;      
      
   %value = mFloatLength(%ctrl.getValue(),0);
   
   if(%value > %ctrl.fieldMax)
      %value = %ctrl.fieldMax;
      
   if(%value < %ctrl.fieldMin)
      %value = %ctrl.fieldMin;
      
   %ctrl.setValue(%value);
}

//- ORBSSC_PF_ValidateNum (Validates "real numbers" - Implemented by Wheatley BL_ID 11953)
function ORBSSC_PF_ValidateNum(%ctrl)
{
   if(%ctrl.getValue() $= "")
      return;
   if(%ctrl.getValue() $= "-")
      return;   
   
   %decPos = strPos(%ctrl.getValue(), ".");
   %floatLen = strLen(getSubStr(%ctrl.getValue(), %decPos+1, 2));
   if(%decPos != -1 && %floatLen != 0)
   {
      %value = mFloatLength(%ctrl.getValue(),%floatLen);
   
      if(%value > %ctrl.fieldMax)
         %value = %ctrl.fieldMax;
      
      if(%value < %ctrl.fieldMin)
         %value = %ctrl.fieldMin;
   }
   else 
   {
      %value = %ctrl.getValue();
   }
      
   %ctrl.setValue(%value);
}

//- ORBSSC_PF_ValidateFloat (Validates floats - Implemented by Wheatley BL_ID 11953)
function ORBSSC_PF_ValidateFloat(%ctrl)
{
   %value = mFloatLength(%ctrl.getValue(),1); //round it to 1 decimal place
   %value = mFloatLength(%value, 3); //add some zeros to make it look nice for the textbox
   %ctrl.setValue(%value);
   %ctrl.textbox.setText(%value);
}

//*********************************************************
//* Ban List Clearing
//*********************************************************
//- unBanGui::clickClear (clears all the bans on the banlist)
function unBanGui::clickClear(%this,%confirm)
{
	if(!%confirm)
	{
		MessageBoxYesNo("Really?","Are you sure you want to clear ALL the bans on the server ban list?","unBanGui::clickClear("@%this@",1);","");
		return;
	}
	unBan_list.clear();
	commandtoserver('ORBS_clearBans');
}

//*********************************************************
//* Packaged Functions
//*********************************************************
package ORBS_Modules_Client_ServerControl
{
   function disconnectedCleanup()
   {
     ORBSSC_SO_Swatch.clear();
     deleteVariables("$ORBS::MCSC::Cache*");
     Parent::disconnectedCleanup();
   }
   
   function clientCmdSendorbsVersion(%version)
   {   
      Parent::clientCmdSendorbsVersion(%version);
      
      ORBSSC_Pane1.render();
      ORBSSC_Pane3.render();
      
      $ORBS::MCSC::Cache::PrefCats = 0;
      $ORBS::MCSC::Cache::Prefs = 0;
   }
    
   function adminGui::onWake(%this)
   {
      Parent::onWake(%this);
      
      if(isObject(orbsServerControlBtn))
      {
         if($IamAdmin !$= 2 || $ORBS::Client::Cache::ServerhasORBS !$= 1)
            orbsServerControlBtn.delete();
         return;
      }
      
      if($IamAdmin !$= 2 || $ORBS::Client::Cache::ServerhasORBS !$= 1)
         return;
         
      %btn = new GuiBitmapButtonCtrl(orbsServerControlBtn)
      {
         profile = BlockButtonProfile;
         horizSizing = "left";
         vertSizing = "bottom";
         position = "211 305";
         extent = "121 38";
         command = "canvas.pushDialog(ORBS_ServerControl);";
         text = "Server Settings >>";
         bitmap = "base/client/ui/button1";
         mcolor = "100 255 50 255";
      };
      adminGui.getObject(0).add(%btn);
   }
   
   function unBanGui::onWake(%this)
   {
      Parent::onWake(%this);
      
      if(isObject(orbsClearBansBtn))
      {
         if($IamAdmin !$= 2 || $ORBS::Client::Cache::ServerhasORBS !$= 1)
            orbsClearBansBtn.delete();
         return;
      }
      
      if($IamAdmin !$= 2 || $ORBS::Client::Cache::ServerhasORBS !$= 1)
         return;
         
      %btn = new GuiBitmapButtonCtrl(orbsClearBansBtn)
      {
         profile = BlockButtonProfile;
         horizSizing = "left";
         vertSizing = "bottom";
         position = "502 100";
         extent = "91 38";
         command = "unBanGui.clickClear();";
         text = "Clear All";
         bitmap = "base/client/ui/button2";
         mcolor = "255 0 0 255";
      };
      unBanGui.getObject(0).add(%btn);
   }
   
   function NewPlayerListGui::update(%this,%client,%name,%blid,%isAdmin,%isSuperAdmin,%score)
   {
      Parent::update(%this,%client,%name,%blid,%isAdmin,%isSuperAdmin,%score);
      
      if($ORBS::MCSC::Cache::currentTab $= 2)
         ORBSSC_Pane2::onView(ORBSSC_Pane2);
   }
};