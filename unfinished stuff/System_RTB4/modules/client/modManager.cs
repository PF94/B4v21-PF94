//#############################################################################
//#
//#   Return to Blockland - Version 3.5
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 108 $
//#      $Date: 2009-09-05 11:39:30 +0100 (Sat, 05 Sep 2009) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/trunk/ORBSC_ModManager.cs $
//#
//#      $Id: ORBSC_ModManager.cs 108 2009-09-05 10:39:30Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Mod Manager (ORBSMM/CModManager)
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::ModManager = 1;

//#####################################################################################################
//
//     _____   _    _   _____   
//    / ____| | |  | | |_   _|  
//   | |  __  | |  | |   | |    
//   | | |_ | | |  | |   | |    
//   | |__| |_| |__| |_ _| |_ _ 
//    \_____(_)\____/(_)_____(_)
//
//
//##################################################################################################### 

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::CModManager::Style::ColorDARKRED = "8B0000";
$ORBS::CModManager::Style::ColorRED = "FF0000";
$ORBS::CModManager::Style::ColorORANGE = "FFA500";
$ORBS::CModManager::Style::ColorBROWN = "A52A2A";
$ORBS::CModManager::Style::ColorYELLOW = "FFFF00";
$ORBS::CModManager::Style::ColorGREEN = "008000";
$ORBS::CModManager::Style::ColorOLIVE = "808000";
$ORBS::CModManager::Style::ColorCYAN = "00FFFF";
$ORBS::CModManager::Style::ColorBLUE = "0000FF";
$ORBS::CModManager::Style::ColorDARKBLUE = "00008B";
$ORBS::CModManager::Style::ColorINDIGO = "4B0082";
$ORBS::CModManager::Style::ColorVIOLET = "EE82EE";
$ORBS::CModManager::Style::ColorWHITE = "FFFFFF";
$ORBS::CModManager::Style::ColorBLACK = "000000";

// Default BL Mods
$ORBS::CModManager::DefaultBLMods = -1;
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Sword";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Spear";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Rocket_Launcher";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Push_Broom";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Horse_Ray";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Guns_Akimbo";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Gun";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Weapon_Bow";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Tank";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Rowboat";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Pirate_Cannon";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Magic_Carpet";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Jeep";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Horse";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Flying_Wheeled_Jeep";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Vehicle_Ball";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Sound_Synth4";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Sound_Phone";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Sound_Beeps";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Script_ClearSpam";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Projectile_Radio_Wave";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Projectile_Pong";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Projectile_Pinball";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Projectile_GravityRocket";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Print_Letters_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Print_2x2r_Monitor3";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Print_2x2r_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Print_2x2f_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Print_1x2f_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Print_1x2f_BLPRemote";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Player_Quake";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Player_No_Jet";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Player_Leap_Jet";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Player_Jump_Jet";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Player_Fuel_Jet";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Particle_Tools";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Particle_Player";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Particle_Grass";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Particle_FX_Cans";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Particle_Basic";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Tutorial";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Slopes";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Slate_Storm_Revised";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Slate_Sea_Revised";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Slate_Desert";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Slate";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Skylands";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_KitchenDark";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Kitchen";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Destruct";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Construct";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_BedroomDark";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Map_Bedroom";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Light_Basic";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Light_Animated";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Item_Skis";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Item_Key";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Face_Mythbusters";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Face_Jirue";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Face_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Emote_Love";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Emote_Hate";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Emote_Confusion";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Emote_Alarm";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Decal_WORM";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Decal_Jirue";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Decal_Hoodie";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Decal_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Brick_V15";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Brick_Large_Cubes";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Brick_Checkpoint";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Brick_Arch";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "Colorset_Default";
$ORBS::CModManager::DefaultBLMod[$ORBS::CModManager::DefaultBLMods++] = "System_oRBs";

//*********************************************************
//* TCP Manager
//*********************************************************
new ScriptGroup(ORBSMM_TCPManager)
{
   tcp[1] = ORBS_Networking.createFactory("orbs.daprogs.com","80","/apiRouter.php?d=APIMS");
   tcp[2] = ORBS_Networking.createFactory("orbs.daprogs.com","80","/apiRouter.php?d=APIMS");
   tcp[3] = ORBS_Networking.createFactory("orbs.daprogs.com","80","/apiRouter.php?d=APIMS");
};
ORBSGroup.add(ORBSMM_TCPManager);

//- ORBSMM_TCPManager::registerResponseHandler (registers a response handler)
function ORBSMM_TCPManager::registerResponseHandler(%this,%cmd,%function)
{
   %this.lineHandler[%cmd] = %function;
   
   if(isFunction(%function@"Start"))
      %this.startHandler[%cmd] = %function@"Start";
      
   if(isFunction(%function@"Stop"))
      %this.stopHandler[%cmd] = %function@"Stop";
}

//- ORBSMM_TCPManager::registerFailHandler (registers a failure handler)
function ORBSMM_TCPManager::registerFailHandler(%this,%cmd,%function)
{
   %this.failHandler[%cmd] = %function;
}

//- ORBSMM_TCPManager::makeRequest (makes a request for the mod manager)
function ORBSMM_TCPManager::makeRequest(%this,%data,%line)
{
   %this.tcp[%line].post(%data,%this,"onLine","onFail","","onEnd");
}

//- ORBSMM_TCPManager::onLine (handles a line from tcp)
function ORBSMM_TCPManager::onLine(%this,%tcp,%factory,%line)
{
   %cmd = getField(%line,0);
   
   if(%tcp.lastCmd !$= %cmd)
   {
      if(%this.startHandler[%cmd] !$= "")
         call(%this.startHandler[%cmd],%tcp);
         
      %tcp.lastCmd = %cmd;
   }
   
   if(%this.lineHandler[%cmd] !$= "")
      call(%this.lineHandler[%cmd],%tcp,getFields(%line,1,getFieldCount(%line)-1),getField(%line,1),getField(%line,2),getField(%line,3),getField(%line,4),getField(%line,5),getField(%line,6),getField(%line,7),getField(%line,8),getField(%line,9),getField(%line,10),getField(%line,11),getField(%line,12),getField(%line,13),getField(%line,14),getField(%line,15));
}

//- ORBSMM_TCPManager::onFail (handles tcp failure)
function ORBSMM_TCPManager::onFail(%this,%tcp,%factory,%reason,%more)
{
   %cmd = getField(%line,0);
   
   if(%this.failHandler[%cmd] !$= "")
      call(%this.failHandler[%cmd],%this,%reason);
}

//- ORBSMM_TCPManager::onEnd (callback from end of receiving)
function ORBSMM_TCPManager::onEnd(%this,%tcp,%factory)
{
   %cmd = %tcp.lastCmd;
   
   if(%this.stopHandler[%cmd] !$= "")
      call(%this.stopHandler[%cmd],%this);
}

//*********************************************************
//* Load TCP Object
//*********************************************************
//- ORBSMM_SendRequest (Compiles arguments into POST string for transfer)
function ORBSMM_SendRequest(%cmd,%line,%arg1,%arg2,%arg3,%arg4,%arg5,%arg6,%arg7,%arg8,%arg9,%arg10)
{
   if($ORBS::Barred::Download)
   {
      ORBSMM_setBarred();
      return;
   }
   
   if(%line $= 1)
      deleteVariables("$ORBS::CModManager::Cache*");
      
   %data = ORBSMM_TCPManager.tcp[1].getPostData(%cmd,%arg1,%arg2,%arg3,%arg4,%arg5,%arg6,%arg7,%arg8,%arg9,%arg10);
   
   ORBSMM_TCPManager.makeRequest(%data,%line);
}

//*********************************************************
//* Special Controllers
//*********************************************************
//- ORBSMM_setBarred (Decides whether you are barred from using the mod manager or not)
function ORBSMM_setBarred()
{
   if($ORBS::Barred::Download)
   {
      if(isObject(ORBSMM_WindowSwatch))
         ORBSMM_WindowSwatch.delete();
         
      if(isObject(ORBSMM_LoadingContentSwatch))
         ORBSMM_LoadingContentSwatch.delete();
         
      ORBSMM_BarredReason.setText("<just:center><font:Verdana Bold:18><color:AAAAAA>"@$ORBS::Barred::Reason);
      ORBSMM_BarredOverlay.setVisible(1);
   }
   else
   {
      ORBSMM_BarredOverlay.setVisible(0);
   }
}

//*********************************************************
//* GUI Callbacks
//*********************************************************
//- ORBS_ModManager::onWake (GUI wake callback, updates browser buttons + auth)
function ORBS_ModManager::onWake(%this)
{
   if(!%this.isOpen())
      return;
      
   ORBSMM_Zones_CheckButtons();
   ORBSMM_Auth_Init();
   
   if(AddOnsGui.isAwake())
      AddOnsGui.onSleep();
   
   if(!$ORBS::CModManager::Cache::OpenDirect)
      ORBSMM_Zones_Refresh();
      
   if($ORBS::CModManager::Cache::CurrentZone $= "")
      ORBSMM_NewsFeedView_Init();
   
   if($AddOn__Weapon_Gun $= "")
      clientUpdateAddonsList();   
   
   if(!ORBSMM_FileCache.refreshed)
      ORBSMM_FileCache.refresh();
   
   if(!ORBSMM_GroupManager.loaded)
      ORBSMM_GroupManager.loadDat();
}

//- ORBS_ModManager::onSleep (GUI sleep callback)
function ORBS_ModManager::onSleep()
{
}

//*********************************************************
//* Forward/Backward Tracking
//*********************************************************
//- ORBSMM_Zones_Track (Tracks current zone and return eval)
function ORBSMM_Zones_Track(%zone,%return,%pagination)
{
   if(!isObject(ORBSMM_ZoneTracker))
   {
      new ScriptObject(ORBSMM_ZoneTracker)
      {
         currZone = -1;
         numZones = 0;
      };
      ORBSGroup.add(ORBSMM_ZoneTracker);
   }
   
   //I have run out of milkshake so thats why the tracking queue will have to
   //be of an indeterminate length... can't work without milkshake
   if(ORBSMM_ZoneTracker.zoneCmd[ORBSMM_ZoneTracker.currZone] !$= %return)
   {
      ORBSMM_ZoneTracker.currZone++;
      ORBSMM_ZoneTracker.zone[ORBSMM_ZoneTracker.currZone] = %zone;
      ORBSMM_ZoneTracker.zoneCmd[ORBSMM_ZoneTracker.currZone] = %return;
      ORBSMM_ZoneTracker.numZones = ORBSMM_ZoneTracker.currZone+1;
   }
   $ORBS::CModManager::Cache::CurrentZone = %zone;
   $ORBS::CModManager::Cache::PaginationTemplate = %pagination;
   
   ORBSMM_Zones_CheckButtons();
}

//- ORBSMM_Zones_Back (Moves back in history)
function ORBSMM_Zones_Back()
{
   if(ORBSMM_ZoneTracker.currZone >= 1)
   {
      ORBSMM_ZoneTracker.currZone--;
      %return = ORBSMM_ZoneTracker.zoneCmd[ORBSMM_ZoneTracker.currZone];
      eval(%return);
   }
   ORBSMM_Zones_CheckButtons();
}

//- ORBSMM_Zones_Forward (Moves forward in history)
function ORBSMM_Zones_Forward()
{
   if(ORBSMM_ZoneTracker.currZone < (ORBSMM_ZoneTracker.numZones-1))
   {
      ORBSMM_ZoneTracker.currZone++;
      %return = ORBSMM_ZoneTracker.zoneCmd[ORBSMM_ZoneTracker.currZone];
      eval(%return);
   }
   ORBSMM_Zones_CheckButtons();
}

//- ORBSMM_Zones_Refresh (Refreshes current page)
function ORBSMM_Zones_Refresh()
{
   if(ORBSMM_ZoneTracker.numZones >= 1)
   {
      %return = ORBSMM_ZoneTracker.zoneCmd[ORBSMM_ZoneTracker.currZone];
      eval(%return);
   }
}

//- ORBSMM_Zones_CheckButtons (checks to see if buttons should be active)
function ORBSMM_Zones_CheckButtons()
{
   ORBSMM_HistoryBack.setActive(0);
   ORBSMM_HistoryForward.setActive(0);
   ORBSMM_Refresh.setActive(1);
   
   if(ORBSMM_ZoneTracker.numZones > 1)
   {
      if(ORBSMM_ZoneTracker.currZone < (ORBSMM_ZoneTracker.numZones-1))
         ORBSMM_HistoryForward.setActive(1);
         
      if(ORBSMM_ZoneTracker.currZone >= 1)
         ORBSMM_HistoryBack.setActive(1);
   }
   
   if(ORBSMM_ZoneTracker.currZone $= "")
      ORBSMM_Refresh.setActive(0);
}

//*********************************************************
//* Package
//*********************************************************
package ORBSC_ModManager
{
   function clientUpdateAddonsList()
   {
      if($AddOn__Weapon_Gun $= "")
         Parent::clientUpdateAddonsList();
   }
   
   function loadMainMenu()
   {
      Parent::loadMainMenu();
      
      if(ORBSCO_getPref("MM::CheckUpdates"))
         ORBSMM_checkForUpdates();
   }
   
   function GuiMLTextCtrl::onUrl(%this,%url)
   {
      %explode = strReplace(%url,"-","\t");
      if(getField(%explode,0) $= "pagination")
      {
         %eval = $ORBS::CModManager::Cache::PaginationTemplate;
         %pageNumber = getField(%explode,1);
         %eval = strReplace(%eval,"%%page%%",%pageNumber);
         
         schedule(10,0,"eval",%eval);
      }
      else if(getField(%explode,0) $= "comment")
      {
         if(getField(%explode,1) $= "pagination")
         {
            if(getField(%explode,2) $= "next")
               ORBSMM_FileView_getCommentPage($ORBS::CModManager::Cache::CommentCurrPage-1);
            else
               ORBSMM_FileView_getCommentPage($ORBS::CModManager::Cache::CommentCurrPage+1);
         }
      }
      else if(getField(%explode,0) $= "download")
      {
         ORBSMM_TransferView_Add(getField(%explode,1));
      }
      else if(getField(%explode,0) $= "file")
      {
         if(!ORBS_ModManager.isOpen())
            ORBSMM_OpenModManager();
         ORBSMM_FileView_Init(getField(%explode,1));
      }
      else if(getField(%explode,0) $= "pack")
      {
         if(!ORBS_ModManager.isOpen())
            ORBSMM_OpenModManager();
         ORBSMM_PackView_Init(getField(%explode,1));
      }
      else if(getField(%explode,0) $= "orbs")
      {
         if(!ORBS_ModManager.isOpen())
            ORBSMM_OpenModManager();
         schedule(10,0,"ORBSMM_FileView_Init",getField(%explode,1));
      }
      else
         Parent::onUrl(%this,%url);
   }
};
activatePackage(ORBSC_ModManager);

//*********************************************************
//* Default Communication Handling
//*********************************************************
//- ORBSMM_Default_onConnected (onConnected Callback)
function ORBSMM_Default_onConnected(%this)
{
}

//- ORBSMM_Default_onReply (onReply Callback)
function ORBSMM_Default_onReply(%this,%line)
{
}

//- ORBSMM_Default_onDisconnected (onDisconnected Callback)
function ORBSMM_Default_onDisconnected(%this)
{
}

//- ORBSMM_Default_onFail (onFail Callback)
function ORBSMM_Default_onFail(%this,%errorCode)
{
}

//*********************************************************
//* GUI Generation Management
//*********************************************************
//- ORBSMM_GUI_Init (Creates intial gui for building into)
function ORBSMM_GUI_Init()
{
   if(isObject(ORBSMM_LoadingContentSwatch))
      ORBSMM_LoadingContentSwatch.delete();
   
   $ORBS::CModManager::GUI::CurrentY = 0;
   
   if(isObject(ORBSMM_WindowSwatch))
      ORBSMM_WindowSwatch.delete();
      
   ORBSMM_WindowOverlay.clear();
   ORBSMM_WindowOverlay.setVisible(0);
      
   %swatch = new GuiSwatchCtrl(ORBSMM_WindowSwatch)
   {
      position = "1 1";
      extent = "679 555";
      color = "255 255 255 255";
   };
   ORBSMM_ModWindow.add(%swatch);
}

//- ORBSMM_GUI_PushControl (Adds control to the swatch)
function ORBSMM_GUI_PushControl(%ctrl,%recalc)
{
   if(!isObject(ORBSMM_WindowSwatch))
      ORBSMM_GUI_Init();
      
   ORBSMM_WindowSwatch.add(%ctrl);
   
   if(%recalc)
   {
      %totalOffset = getWord(%ctrl.position,1) + getWord(%ctrl.extent,1);
      $ORBS::CModManager::GUI::CurrentY = %totalOffset;
      ORBSMM_GUI_Resize();
   }
}

//- ORBSMM_GUI_Resize (Resizes swatch based on Y variable)
function ORBSMM_GUI_Resize()
{
	%PosX = getWord(ORBSMM_WindowSwatch.position,0);
	%PosY = getWord(ORBSMM_WindowSwatch.position,1);
	%ExtX = "679";
   %ExtY = 555;
   
   if($ORBS::CModManager::GUI::CurrentY > %ExtY)
      %ExtY = $ORBS::CModManager::GUI::CurrentY-1;
      
   ORBSMM_WindowSwatch.resize(%PosX,%PosY,%ExtX,%ExtY);
}

//- ORBSMM_GUI_AutoResize (Resizes swatch to fit gui inside)
function ORBSMM_GUI_AutoResize()
{
	%PosX = getWord(ORBSMM_WindowSwatch.position,0);
	%PosY = getWord(ORBSMM_WindowSwatch.position,1);
	%ExtX = "679";
   %ExtY = 555;
   
   for(%i=0;%i<ORBSMM_WindowSwatch.getCount();%i++)
   {
      %ctrl = ORBSMM_WindowSwatch.getObject(%i);
      %extent = getWord(%ctrl.position,1) + getWord(%ctrl.extent,1);
      if(%extent > %ExtY)
         %ExtY = %extent-1;
   }
	ORBSMM_WindowSwatch.resize(%PosX,%PosY,%ExtX,%ExtY);
	
	%ExtY = 1;
   for(%i=0;%i<ORBSMM_WindowSwatch.getCount();%i++)
   {
      %ctrl = ORBSMM_WindowSwatch.getObject(%i);
      %extent = getWord(%ctrl.position,1) + getWord(%ctrl.extent,1);
      if(%extent > %ExtY)
         %ExtY = %extent;
   }	
	$ORBS::CModManager::GUI::CurrentY = %ExtY;
}

//- ORBSMM_GUI_Offset (Offsets GUI in either direction and updates controls)
function ORBSMM_GUI_Offset(%offset)
{
   $ORBS::CModManager::GUI::CurrentY += %offset;
   ORBSMM_GUI_Resize();
}

//- ORBSMM_GUI_FadeIn (Fades a swatch in)
function ORBSMM_GUI_FadeIn(%ctrl)
{
   if(!isObject(%ctrl))
      return;
      
   %color = getWords(%ctrl.color,0,2);
   %alpha = getWord(%ctrl.color,3);
   %alpha += 20;
   if(%alpha > 255)
      %alpha = 255;
   %ctrl.color = %color SPC %alpha;
   
   if(%alpha < 255)
      schedule(50,0,"ORBSMM_GUI_FadeIn",%ctrl);
}

//- ORBSMM_GUI_FadeOut (Fades out a swatch)
function ORBSMM_GUI_FadeOut(%ctrl)
{
   if(!isObject(%ctrl))
      return;
      
   %color = getWords(%ctrl.color,0,2);
   %alpha = getWord(%ctrl.color,3);
   %alpha -= 20;
   if(%alpha < 0)
      %alpha = 0;
   %ctrl.color = %color SPC %alpha;
   
   if(%alpha > 0)
      schedule(50,0,"ORBSMM_GUI_FadeOut",%ctrl);
}

//- ORBSMM_GUI_Load (Shows a loading gui)
function ORBSMM_GUI_Load(%text)
{
   ORBSMM_WindowOverlay.clear();
   ORBSMM_WindowOverlay.setVisible(0);
   
   if(!isObject(ORBSMM_WindowSwatch))
   {
      ORBSMM_GUI_Init();
      ORBSMM_WindowSwatch.color = "0 0 0 0";
   }
      
   if(isObject(ORBSMM_LoadingContentSwatch))
      ORBSMM_LoadingContentSwatch.delete();
      
   if(%text $= "")
      %text = "Downloading Content...";
      
	%swatch = new GuiSwatchCtrl(ORBSMM_LoadingContentSwatch)
	{
	   position = "100 35";
		extent = "679 555";
		color = "255 255 255 150";
		
		new GuiAnimatedBitmapCtrl()
		{
		   horizSizing = "center";
		   vertSizing = "bottom";
		   position = "324 240";
		   extent = "31 31";
		   bitmap = $ORBS::Path@"images/ui/animated/loadRing";
		   framesPerSecond = 15;
		   numFrames = 8;
		};
		
		new GuiMLTextCtrl()
		{
		   horizSizing = "center";
		   position = "140 275";
		   extent = "400 12";
		   profile = ORBS_Verdana12Pt;
		   text = "<just:center><color:555555>"@%text;
		};
	};
   ORBSMM_GUI_PushControl(%swatch);
   ORBS_ModManager.add(%swatch);
}

//- ORBSMM_GUI_FailLoad (Shows a failed loading gui)
function ORBSMM_GUI_FailLoad(%text)
{
   if(isObject(ORBSMM_LoadingContentSwatch))
      ORBSMM_LoadingContentSwatch.delete();
      
   if(%text $= "")
      %text = "An Error Occurred";
      
	%swatch = new GuiSwatchCtrl(ORBSMM_LoadingContentSwatch)
	{
	   fixedPosition = "1 1";
		extent = "680 553";
		color = "235 235 235 255";
		
		new GuiBitmapCtrl()
		{
		   horizSizing = "center";
		   vertSizing = "bottom";
		   position = "324 240";
		   extent = "31 31";
		   bitmap = $ORBS::Path@"images/ui/animated/loadRing_fail";
		};
		
		new GuiMLTextCtrl()
		{
		   horizSizing = "center";
		   position = "40 275";
		   extent = "600 12";
		   profile = ORBS_Verdana12Pt;
		   text = "<just:center><color:555555>"@%text;
		};
	};
   ORBSMM_GUI_PushControl(%swatch);
}

//- ORBSMM_GUI_AnimateStar_Init (Fills a star progressively)
function ORBSMM_GUI_AnimateStar_Init(%ctrl,%stage)
{
   if(!isObject(%ctrl))
      return;
      
   if(!ORBSCO_getPref("MM::Animate"))
   {
      %ctrl.setBitmap($ORBS::Path@"images/icons/star"@%stage);
      return;
   }
      
   %ctrl.currStage = 0;
   ORBSMM_GUI_AnimateStar_Action(%ctrl,%stage);
}

//- ORBSMM_GUI_AnimateStar_Action (Action for star filling)
function ORBSMM_GUI_AnimateStar_Action(%ctrl,%stage)
{
   if(!isObject(%ctrl))
      return;
      
   %ctrl.setBitmap($ORBS::Path@"images/icons/star"@%ctrl.currStage);
   
   if(%ctrl.currStage >= %stage)
      return;
   
   %ctrl.currStage++;
   schedule(50,0,"ORBSMM_GUI_AnimateStar_Action",%ctrl,%stage);
}

//- ORBSMM_GUI_LoadRing_Clear (Clears loadring and schedule)
function ORBSMM_GUI_LoadRing_Clear(%ctrl)
{
   %bitmap = new GuiBitmapCtrl()
   {
      position = %ctrl.position;
      extent = %ctrl.extent;
      bitmap = $ORBS::Path@"images/ui/animated/loadRing_clear";
   };
   %ctrl.getGroup().add(%bitmap);
   %ctrl.delete();
}

//*********************************************************
//* GUI Positioning Functions
//*********************************************************
//- ORBSMM_GUI_CenterVert (Centers ctrlA inside ctrlB)
function ORBSMM_GUI_CenterVert(%ctrlA,%ctrlB)
{
   if(isObject(%ctrlB))
   {
      %maxArea = getWord(%ctrlB.extent,1);
      %height = getWord(%ctrlA.extent,1);

      %yPosition = (%maxArea/2)-(%height/2);
      if(%ctrlB $= %ctrlA.getGroup())
         %ctrlA.position = getWord(%ctrlA.position,0) SPC (%yPosition+getWord(%ctrlB.position,1));
      else
         %ctrlA.position = getWord(%ctrlA.getCanvasPosition(),0) SPC (%yPosition+getWord(%ctrlB.getCanvasPosition(),1));
   }
   else
   {
      %ctrlB = %ctrlA.getGroup();
      %maxArea = getWord(%ctrlB.extent,1);
      %height = getWord(%ctrlA.extent,1);
      
      %yPosition = (%maxArea/2)-(%height/2);
      %ctrlA.position = getWord(%ctrlA.position,0) SPC %yPosition;
   }
}

//- ORBSMM_GUI_CenterHoriz (Centers ctrlA inside ctrlB)
function ORBSMM_GUI_CenterHoriz(%ctrlA,%ctrlB)
{
   if(isObject(%ctrlB))
   {
      %maxArea = getWord(%ctrlB.extent,0);
      %width = getWord(%ctrlA.extent,0);
      
      %xPosition = (%maxArea/2)-(%width/2);
      if(%ctrlB $= %ctrlA.getGroup())
         %ctrlA.position = (%xPosition+getWord(%ctrlB.position,0)) SPC getWord(%ctrlA.position,1);
      else
         %ctrlA.position = (%xPosition+getWord(%ctrlB.getCanvasPosition(),0)) SPC getWord(%ctrlA.getCanvasPosition(),1);
   }
   else
   {
      %ctrlB = %ctrlA.getGroup();
      %maxArea = getWord(%ctrlB.extent,0);
      %width = getWord(%ctrlA.extent,0);
      
      %xPosition = (%maxArea/2)-(%width/2);
      %ctrlA.position = %xPosition SPC getWord(%ctrlA.position,1);
   }
}

//- ORBSMM_GUI_Center (Centers ctrlA inside ctrlB)
function ORBSMM_GUI_Center(%ctrlA,%ctrlB)
{
   ORBSMM_GUI_CenterHoriz(%ctrlA,%ctrlB);
   ORBSMM_GUI_CenterVert(%ctrlA,%ctrlB);
}

//*********************************************************
//* Public GUI Generation Functions
//*********************************************************
//- ORBSMM_GUI_createWindow (Creates an imitation GuiWindowCtrl comprised of resizable bitmaps)
function ORBSMM_GUI_createWindow(%text)
{
   ORBSMM_WindowOverlay.setVisible(1);
   
   %window = new GuiSwatchCtrl()
   {
      extent = "64 64";
      color = "0 0 0 0";
      
      new GuiBitmapCtrl()
      {
         extent = "6 28";
         minExtent = "1 1";
         bitmap = $ORBS::Path@"images/ui/window_topLeft";
      };
      
      new GuiBitmapCtrl()
      {
         position = "6 0";
         extent = "53 28";
         horizSizing = "width";
         bitmap = $ORBS::Path@"images/ui/window_topLoop";
         wrap = 1;
      };
      
      new GuiBitmapCtrl()
      {
         position = "59 0";
         extent = "5 28";
         minExtent = "1 1";
         horizSizing = "left";
         bitmap = $ORBS::Path@"images/ui/window_topRight";
      };
      
      new GuiSwatchCtrl()
      {
         position = "4 31";
         extent = "56 29";
         horizSizing = "width";
         vertSizing = "height";
         color = "235 236 237 255";
      };
      
      new GuiBitmapCtrl()
      {
         position = "0 28";
         extent = "6 5";
         minExtent = "1 1";
         bitmap = $ORBS::Path@"images/ui/content_topLeft";
      };
      
      new GuiBitmapCtrl()
      {
         position = "6 28";
         extent = "52 3";
         minExtent = "1 1";
         horizSizing = "width";
         bitmap = $ORBS::Path@"images/ui/content_top";
         wrap = 1;
      };
      
      new GuiBitmapCtrl()
      {
         position = "58 28";
         extent = "6 5";
         minExtent = "1 1";
         horizSizing = "left";
         bitmap = $ORBS::Path@"images/ui/content_topRight";
      };
      
      new GuiBitmapCtrl()
      {
         position = "0 33";
         extent = "4 24";
         minExtent = "1 1";
         vertSizing = "height";
         bitmap = $ORBS::Path@"images/ui/content_left";
         wrap = 1;
      };
      
      new GuiBitmapCtrl()
      {
         position = "60 33";
         extent = "4 24";
         minExtent = "1 1";
         horizSizing = "left";
         vertSizing = "height";
         bitmap = $ORBS::Path@"images/ui/content_right";
         wrap = 1;
      };
      
      new GuiBitmapCtrl()
      {
         position = "0 57";
         extent = "7 7";
         minExtent = "1 1";
         vertSizing = "top";
         bitmap = $ORBS::Path@"images/ui/content_bottomLeft";
      };
      
      new GuiBitmapCtrl()
      {
         position = "57 57";
         extent = "7 7";
         minExtent = "1 1";
         horizSizing = "left";
         vertSizing = "top";
         bitmap = $ORBS::Path@"images/ui/content_bottomRight";
      };
      
      new GuiBitmapCtrl()
      {
         position = "7 60";
         extent = "50 4";
         minExtent = "1 1";
         horizSizing = "width";
         vertSizing = "top";
         bitmap = $ORBS::Path@"images/ui/content_bottom";
         wrap = 1;
      };
      
      new GuiMLTextCtrl()
      {
         position = "3 5";
         extent = "390 18";
         text = "<color:FAFAFA><just:left><font:Impact:18>  "@%text;
      };
      
      new GuiBitmapButtonCtrl()
      {
         position = "41 7";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/close";
         horizSizing = "left";
         text = " ";
      };
   };
   %window.canvas = %window.getObject(3);
   
   %window.getObject(%window.getCount()-1).command = "ORBSMM_GUI_closeWindow("@%window@");";
   %window.closeButton = %window.getObject(%window.getCount()-1);
   ORBSMM_WindowOverlay.add(%window);
   
   return %window;
}

//- ORBSMM_GUI_closeWindow (Closes a generated window and removes the overlay if necessary)
function ORBSMM_GUI_closeWindow(%window)
{
   %window.delete();
   if(ORBSMM_WindowOverlay.getCount() <= 0)
      ORBSMM_WindowOverlay.setVisible(0);
}

//- ORBSMM_GUI_createMessageBoxOK (Creates an OK message box from the above function)
function ORBSMM_GUI_createMessageBoxOK(%title,%message,%ok)
{
   %window = ORBSMM_GUI_createWindow(%title);
   %window.resize(0,0,300,100);
   ORBSMM_GUI_Center(%window);
   
   %text = new GuiMLTextCtrl()
   {
      position = "10 10";
      extent = "275 12";
      text = "<font:Verdana:12><color:555555>"@%message;
   };
   %window.canvas.add(%text);
   %text.forceReflow();
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "0 35";
      vertSizing = "top";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = %ok@"ORBSMM_GUI_closeWindow("@%window@");";
   };
   %window.canvas.add(%button);
   ORBSMM_GUI_CenterHoriz(%button);
   
   %window.resize(0,0,300,getWord(%text.extent,1)+85);
   ORBSMM_GUI_Center(%window);
}

//- ORBSMM_GUI_createMessageBoxOKCancel (Creates an OK/Cancel message box from the above function)
function ORBSMM_GUI_createMessageBoxOKCancel(%title,%message,%ok,%cancel)
{
   %window = ORBSMM_GUI_createWindow(%title);
   %window.resize(0,0,300,100);
   ORBSMM_GUI_Center(%window);
   
   %text = new GuiMLTextCtrl()
   {
      position = "10 10";
      extent = "275 12";
      text = "<font:Verdana:12><color:555555>"@%message;
   };
   %window.canvas.add(%text);
   %text.forceReflow();
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "88 35";
      vertSizing = "top";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = %ok@"ORBSMM_GUI_closeWindow("@%window@");";
   };
   %window.canvas.add(%button);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "150 35";
      vertSizing = "top";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/cancel";
      command = %cancel@"ORBSMM_GUI_closeWindow("@%window@");";
   };
   %window.canvas.add(%button);
   
   %window.resize(0,0,300,getWord(%text.extent,1)+85);
   ORBSMM_GUI_Center(%window);
}

//- ORBSMM_GUI_createHeader (Creates a standard header with value)
function ORBSMM_GUI_createHeader(%type,%text)
{
   if(%type $= "")
      %type = 1;
     
   if(%type $= 1)
   {
      %borderProfile = ORBSMM_CellLightProfile;
      %bitmapBackground = $ORBS::Path@"images/ui/header_light";
   }
   else
   {
      %borderProfile = ORBSMM_CellDarkProfile;
      %bitmapBackground = $ORBS::Path@"images/ui/header_dark";
   }
      
   %header = new GuiBitmapCtrl()
   {
      position = 0 SPC $ORBS::CModManager::GUI::CurrentY;
      extent = 680 SPC 28;
      bitmap = %bitmapBackground;
      wrap = 1;
      
      new GuiBitmapBorderCtrl()
      {
         profile = %borderProfile;
         horizSizing = "width";
         vertSizing = "height";
         position = 0 SPC 0;
         extent = 680 SPC 28;
      };
   };
   
   if(%text $= "")
   {
      ORBSMM_GUI_PushControl(%header,1);
      return %header;
   }
   
   %ml = new GuiMLTextCtrl()
   {
      profile = ORBSMM_PaginationProfile;
      position = "0 0";
      extent = "678 28";
      text = "<color:888888><font:Arial Bold:15><just:center>"@%text;
   };
   %header.add(%ml);
   ORBSMM_GUI_PushControl(%header,1);
   
   %ml.forceReflow();
   ORBSMM_GUI_Center(%ml);
   
   return %header;
}

//- ORBSMM_GUI_createContent (creates a content row)
function ORBSMM_GUI_createContent(%type,%height,%width1,%width2,%width3,%width4,%width5,%width6,%width7,%width8,%maxWidth)
{
   if(%type $= "")
      %type = 1;
      
   if(%type $= 1)
   {
      %bitmapBackground = $ORBS::Path@"images/ui/cell_gray";
      %borderProfile = ORBSMM_CellLightProfile;
   }
   else if(%type $= 2)
   {
      %bitmapBackground = $ORBS::Path@"images/ui/cell_yellow";
      %borderProfile = ORBSMM_CellYellowProfile;
   }
   
   if(%width1 $= "")
   {
      %width1 = 100;
      %width2 = "";
   }
      
   if(%height $= "")
      %height = 30;
      
   %i = 1;
   while(%width[%i] !$= "")
   {
      %i++;
   }
   %count = %i-1;
   
   if(%maxWidth $= "")
      %maxWidth = 680;

   %container = new GuiBitmapCtrl()
   {
      position = "0" SPC $ORBS::CModManager::GUI::CurrentY;
      extent = %maxWidth SPC %height;
      bitmap = %bitmapBackground;
   };

   %currX = 0;
   for(%i=1;%i<%count+1;%i++)
   {
      %width = (%maxWidth/100)*%width[%i];
      if(strPos(%width,".") >= 0)
         %decimal = getSubStr(%width,strPos(%width,".")+1,strLen(%width));
      %width = mFloor(%width);
      %decimal = "0."@%decimal;

      %remainder += %decimal;
      %remainder = mFloatLength(%remainder,2);
      if(%remainder >= 1)
      {
         %remainder -= 1;
         %header.extent = getWord(%header.extent,0)+1 SPC %height;
         %currX += 1;
      }

      %header = new GuiBitmapBorderCtrl()
      {
         profile = %borderProfile;
         horizSizing = "width";
         vertSizing = "height";
         position = %currX SPC 0;
         extent = %width SPC %height;
      };
      %currX += (%width);
      %container.add(%header);
   }
   ORBSMM_GUI_PushControl(%container,1);
   
   if(mFloatLength(%remainder,0) >= 1)
   {
      %header.extent = getWord(%header.extent,0)+1 SPC %height;
      %header.getObject(0).extent = getWord(%header.extent,0)+1 SPC %height-1;
      %header.getObject(0).getObject(0).extent = getWord(%header.extent,0)-2 SPC %height-2;
   }
   
   return %container;
}

//- ORBSMM_GUI_createSplitHeader (creates a percentage-split header)
function ORBSMM_GUI_createSplitHeader(%type,%width1,%text1,%width2,%text2,%width3,%text3,%width4,%text4,%width5,%text5,%width6,%text6,%width7,%text7,%width8,%text8)
{
   if(%type $= "")
      %type = 1;
      
   if(%type $= 1)
   {
      %bitmapBackground = $ORBS::Path@"images/ui/header_light";
      %borderProfile = ORBSMM_CellLightProfile;
   }
   else
   {
      %bitmapBackground = $ORBS::Path@"images/ui/header_dark";
      %borderProfile = ORBSMM_CellDarkProfile;
   }
      
   %i = 1;
   while(%width[%i] !$= "")
   {
      %i++;
   }
   %count = %i-1;
   
   %height = 28;
   %maxWidth = 680;

   %container = new GuiBitmapCtrl()
   {
      position = "0" SPC $ORBS::CModManager::GUI::CurrentY;
      extent = %maxWidth SPC %height;
      bitmap = %bitmapBackground;
      wrap = 1;
   };

   %currX = 0;
   for(%i=1;%i<%count+1;%i++)
   {
      %width = (%maxWidth/100)*%width[%i];
      if(strPos(%width,".") >= 0)
         %decimal = getSubStr(%width,strPos(%width,".")+1,strLen(%width));
      %width = mFloor(%width);
      %decimal = "0."@%decimal;

      %remainder += %decimal;
      %remainder = mFloatLength(%remainder,2);
      if(%remainder >= 1)
      {
         %remainder -= 1;
         %header.extent = getWord(%header.extent,0)+1 SPC %height;
         %currX += 1;
      }

      %header = new GuiBitmapBorderCtrl()
      {
         profile = %borderProfile;
         horizSizing = "width";
         vertSizing = "height";
         position = %currX SPC 0;
         extent = %width SPC %height;
      };
      %currX += %width;
      %container.add(%header);
      
      if(%text[%i] !$= "")
      {
         %ml = new GuiMLTextCtrl()
         {
            profile = ORBSMM_PaginationProfile;
            position = "0 6";
            vertSizing = "width";
            extent = %width SPC %height;
            text = "<color:888888><font:Arial Bold:15><just:center>"@%text[%i];
         };
         %header.add(%ml);
      }
   }
   ORBSMM_GUI_PushControl(%container,1);
   
   if(mFloatLength(%remainder,0) >= 1)
   {
      %header.extent = getWord(%header.extent,0)+1 SPC %height;
      %header.getObject(0).extent = getWord(%header.extent,0)+1 SPC %height-1;
      %header.getObject(0).getObject(0).extent = getWord(%header.extent,0)-2 SPC %height-2;
   }
   
   return %container;
}

//- ORBSMM_GUI_createFooter (Creates a footer, and adds pagination if necessary)
function ORBSMM_GUI_createFooter(%type)
{      
   %pages = $ORBS::CModManager::Cache::Pagination::NumPages;
   %currPage = $ORBS::CModManager::Cache::Pagination::CurrPage;
   
   if(%pages <= 1)
   {
      ORBSMM_GUI_createSplitHeader(2,"100"," ");   
      return;
   }
 
   %paginationText = "Goto Page ";
   if(%currPage > 1)
      %paginationText = %paginationText @ "<a:pagination-"@%currPage-1@">Previous</a> ";
   %paginationText = %paginationText @ ((%currPage $= 1) ? "<spush><color:666666><font:Verdana Bold:15>[1]<spop>" : "<a:pagination-1>1</a>");
 
   if(%pages > 5)
   {
      %start = getMin(getMax(1, %currPage-4), %pages-5);
      %end = getMax(getMin(%pages, %currPage+4), 6);
      
      %paginationText = %paginationText @ ((%start > 1) ? " <spush><color:DDDDDD><font:Verdana Bold:15>...<spop> " : " ");
      
      for(%i=%start+1;%i<%end;%i++)
      {
         %paginationText = %paginationText @ ((%currPage $= %i) ? "<spush><color:666666><font:Verdana Bold:15>["@%i@"]<spop>" : "<a:pagination-"@%i@">"@%i@"</a>");
         if(%i < %end-1)
            %paginationText = %paginationText @ " ";
      }
      
      %paginationText = %paginationText @ ((%end < %pages) ? " <spush><color:DDDDDD><font:Verdana Bold:15>...<spop> " : " ");
   }
   else
   {
      %paginationText = %paginationText @ " ";
      
      for(%i=2;%i<%pages;%i++)
      {
         %paginationText = %paginationText @ ((%currPage $= %i) ? "<spush><color:666666><font:Verdana Bold:15>["@%i@"]<spop>" : "<a:pagination-"@%i@">"@%i@"</a>");
         if(%i < %pages)
            %paginationText = %paginationText @ " ";
      }
   }
   %paginationText = %paginationText @ ((%currPage $= %i) ? "<spush><color:666666><font:Verdana Bold:15>["@%pages@"]<spop>" : "<a:pagination-"@%pages@">"@%pages@"</a>");
   
   if(%currPage < %pages)
      %paginationText = %paginationText @ " <a:pagination-"@%currPage+1@">Next</a>";
   
   ORBSMM_GUI_createHeader(2,"<font:Verdana Bold:13><color:333333><just:right>"@%paginationText@"  ");
}

//- ORBSMM_GUI_getXPlacement (Calculates next placement from supplied control)
function ORBSMM_GUI_getXPlacement(%ctrl)
{
   %xPlace = getWord(%ctrl.position,0)+(getWord(%ctrl.extent,0));
   return %xPlace;
}

//- ORBSMM_GUI_calcGUIContainer (Calculates extent of container to surround supplied controls)
function ORBSMM_GUI_calcGUIContainer(%ctrl1,%ctrl2,%ctrl3,%ctrl4,%ctrl5,%ctrl6,%ctrl7,%ctrl8)
{
   %i = 1;
   while(%ctrl[%i] !$= "")
   {
      if(getWord(%ctrl[%i].position,0)+getWord(%ctrl[%i].extent,0) > %xMax)
         %xMax = getWord(%ctrl[%i].position,0)+getWord(%ctrl[%i].extent,0);
      if(getWord(%ctrl[%i].extent,1) > %yMax)
         %yMax = getWord(%ctrl[%i].extent,1);
         
      %i++;
   }
   
   %xMax++;
   %yMax+=2;
   return %xMax SPC %yMax;
}

//- ORBSMM_GUI_calcWidthPercent (Calculates width from percentage)
function ORBSMM_GUI_calcWidthPercent(%target,%width1,%width2,%width3,%width4,%width5,%width6,%width7,%width8)
{
   %i = 1;
   while(%width[%i] !$= "")
   {
      %i++;
   }
   %count = %i-1;
   %maxWidth = 680-(%count+1);
   
   for(%i=1;%i<%count+1;%i++)
   {
      %actualWidth[%i] = (%maxWidth/100)*%width[%i];
      if(strPos(%actualWidth[%i],".") >= 0)
         %decimal = getSubStr(%actualWidth[%i],strPos(%actualWidth[%i],".")+1,strLen(%actualWidth[%i]));
      %actualWidth[%i] = mFloor(%actualWidth[%i]);
      
      %decimal = "0."@%decimal;
      %remainder += %decimal;
      %remainder = mFloatLength(%remainder,1);
      if(%remainder >= 1)
      {
         %remainder -= 1;
         %actualWidth[%i-1] = %actualWidth[%i-1]+1;
      }
   }
   return %actualWidth[%target];
}

//- ORBSMM_GUI_createMessage (Creates a standard message with value)
function ORBSMM_GUI_createMessage(%value)
{
   %container = ORBSMM_GUI_createContent(1,"30","100");
   
   %ml = new GuiMLTextCtrl()
   {
      position = "0 5";
      extent = "678 27";
      text = "<color:888888><font:Verdana:12><just:center>"@%value;
   };
   %container.getBottom(1).add(%ml);
   
   %ml.forceReflow();
   %height = getWord(%ml.extent,1)+10;
   %container.resize(getWord(%container.position,0),getWord(%container.position,1),getWord(%container.extent,0),%height);
   ORBSMM_GUI_AutoResize();
   
   return %container;
}

//- ORBSMM_GUI_createRatingSwatch (Creates rating box 88x16 with animated loading stars)
function ORBSMM_GUI_createRatingSwatch(%rating)
{
   %swatch = new GuiSwatchCtrl()
   {
      extent = "88 50";
      color = "0 0 0 0";
   };
   
   if(strPos(%rating,"-") > 0)
   {
      %numRatings = getSubStr(%rating,strPos(%rating,"-")+1,strLen(%rating));
      %rating = getSubStr(%rating,0,strPos(%rating,"-"));
   }
      
   for(%i=0;%i<strLen(%rating);%i++)
   {
      %star = getSubStr(%rating,%i,1);
      
      %stctrl = new GuiBitmapCtrl()
      {
         position = (18*%i) SPC 0;
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/star0";
      };
      %swatch.add(%stctrl);
      ORBSMM_GUI_CenterVert(%stctrl);
      schedule(%i*300,0,"ORBSMM_GUI_AnimateStar_Init",%stctrl,%star);
      if(%numRatings !$= "")
         %stctrl.shift(0,-5);
   }
   if(%numRatings !$= "")
   {
      %s = (%numRatings == 1) ? "" : "s";
      %mlTextCtrl = new GuiMLTextCtrl()
      {
         position = "0 30";
         extent = "88";
         text = "<just:center><font:Arial:12><color:BBBBBB>"@%numRatings@" rating"@%s;
      };
      %swatch.add(%mlTextCtrl);
   }
   return %swatch;
}

//- ORBSMM_GUI_addToMods (Flashes a little plus icon on the YourMods tab to indicate you have a new add-on)
function ORBSMM_GUI_addToMods()
{
   %bitmap = new GuiBitmapCtrl()
   {
      extent = "16 16";
      position = "10 320";
      bitmap = $ORBS::Path@"images/icons/add";
   };
   ORBS_ModManager.add(%bitmap);
   
   %bitmap.setColor("1 1 1 0");
   for(%i=1;%i<6;%i++)
   {
      %bitmap.schedule(%i*30,"setColor","1 1 1 "@%i/5);
   }
   
   for(%i=1;%i<11;%i++)
   {
      %bitmap.schedule((%i*50)+700,"setColor","1 1 1 "@1-(%i/10));
   }
   %bitmap.schedule(2000,"delete");
}

//- ORBSMM_GUI_setTransfers (Sets the number of transfers in the transfer queue and updates gui indicator)
function ORBSMM_GUI_setTransfers(%number)
{
   if(%number <= 0)
      ORBSMM_iconTransfers.setVisible(0);
   else
   {
      ORBSMM_iconTransfers.setVisible(1);
      ORBSMM_iconTransfers_cDigit.setVisible(0);
      ORBSMM_iconTransfers_lDigit.setVisible(0);
      ORBSMM_iconTransfers_rDigit.setVisible(0);
      
      if(%number > 9)
      {
         ORBSMM_iconTransfers_lDigit.setVisible(1);
         ORBSMM_iconTransfers_rDigit.setVisible(1);
         ORBSMM_iconTransfers_lDigit.setValue("<color:FFFFFF><font:Verdana Bold:10><just:center>"@getSubStr(%number,0,1));
         ORBSMM_iconTransfers_rDigit.setValue("<color:FFFFFF><font:Verdana Bold:10><just:center>"@getSubStr(%number,1,1));
      }
      else
      {
         ORBSMM_iconTransfers_cDigit.setVisible(1);
         ORBSMM_iconTransfers_cDigit.setValue("<color:FFFFFF><font:Verdana Bold:10><just:center>"@%number);
      }
   }
}

//#####################################################################################################
//
//                         _ _            _   _             
//       /\               | (_)          | | (_)            
//      /  \   _ __  _ __ | |_  ___  __ _| |_ _  ___  _ __  
//     / /\ \ | '_ \| '_ \| | |/ __|/ _` | __| |/ _ \| '_ \ 
//    / ____ \| |_) | |_) | | | (__| (_| | |_| | (_) | | | |
//   /_/    \_\ .__/| .__/|_|_|\___|\__,_|\__|_|\___/|_| |_|
//            | |   | |                                     
//            |_|   |_|                                     
//
//##################################################################################################### 

//#############################################################################
//#
//#   Transmission Layers
//#
//#############################################################################
//#
//# Layer 1: Browsing
//# Layer 2: Torquejax
//# Layer 3: Transfer Data Gather
//#
//#############################################################################

//#############################################################################
//#
//#   Function manifest for real-time system usage
//#
//#############################################################################
//#
//# + Error Handling                         //> Messages or Errors from server
//# ---------------------------------------------------------------------------
//# - ORBSMM_onMessage()                      //> Center Message
//# - ORBSMM_onError()                        //> Error Box
//# - ORBSMM_onBarred()                       //> Incase you get barred (BAD!)
//#
//# + General Handling                       //> General Callback Routing
//# - ORBSMM_onPagination()                   //> Pagination Callback
//#
//# + Auth                                   //> Logging into your ORBS Profile
//# ---------------------------------------------------------------------------
//# - ORBSMM_Auth_Init()                      //> Entrance
//# - ORBSMM_Auth_onReply()                   //> Reply
//# - ORBSMM_Auth_onFail()                    //> Failure
//#
//# + News Feed View                         //> News Feed View
//# ---------------------------------------------------------------------------
//# - ORBSMM_NewsFeedView_Init()              //> Entrance
//# - ORBSMM_NewsFeedView_onReplyStart()      //> Reply Start
//# - ORBSMM_NewsFeedView_onReply()           //> Reply
//# - ORBSMM_NewsFeedView_onFail()            //> Failure
//#
//# + Category View                          //> Category View
//# ---------------------------------------------------------------------------
//# - ORBSMM_CategoryView_Init()              //> Entrance
//# - ORBSMM_CategoryView_onReplyStart()      //> Reply Start
//# - ORBSMM_CategoryView_onReply()           //> Reply
//# - ORBSMM_CategoryView_onReplyStop()       //> Reply Stop
//# - ORBSMM_CategoryView_onFail()            //> Failure
//#
//# + Section View                           //> Section View
//# ---------------------------------------------------------------------------
//# - ORBSMM_SectionView_Init()               //> Entrance
//# - ORBSMM_SectionView_onReplyStart()       //> Reply Start
//# - ORBSMM_SectionView_onReply()            //> Reply
//# - ORBSMM_SectionView_onReplyStop()        //> Reply Stop
//# - ORBSMM_SectionView_onFail()             //> Failure
//#
//# + File View                              //> File View
//# ---------------------------------------------------------------------------
//# - ORBSMM_FileView_Init()                  //> Entrance
//# - ORBSMM_FileView_onReplyStart()          //> Reply Start
//# - ORBSMM_FileView_onReply()               //> Reply
//# - ORBSMM_FileView_onReplyStop()           //> Reply Stop
//# - ORBSMM_FileView_onFail()                //> Failure
//# - ORBSMM_FileView_Rate()                  //> Submit Rating
//# - ORBSMM_FileView_onRateReply()           //> Rating Reply
//# - ORBSMM_FileView_Report()                //> Report File
//# - ORBSMM_FileView_SendReport()            //> Submits Report
//# - ORBSMM_FileView_onReportReply()         //> Report Reply
//# - ORBSMM_FileView_onReportFail()          //> Report Fail
//#
//# + Packs View
//# ---------------------------------------------------------------------------
//# - ORBSMM_PacksView_Init()                 //> Entrance
//# - ORBSMM_PacksView_onReplyStart()         //> Reply Start
//# - ORBSMM_PacksView_onReply()              //> Reply
//# - RTMBM_PacksView_onFail()               //> Failure
//#
//# + Top List View                          //> Top List View
//# ---------------------------------------------------------------------------
//# - ORBSMM_TopListView_Init()               //> Entrance
//# - ORBSMM_TopListView_onReplyStart()       //> Reply Start
//# - ORBSMM_TopListView_onReply()            //> Reply
//# - ORBSMM_TopListView_onReplyStop()        //> Reply Stop
//# - ORBSMM_TopListView_onFail()             //> Failure
//#
//# + Search View                            //> Search View
//# ---------------------------------------------------------------------------
//# - ORBSMM_SearchView_Init()                //> Entrance
//# - ORBSMM_SearchView_onReplyStart()        //> Reply Start
//# - ORBSMM_SearchView_onReply()             //> Reply
//# - ORBSMM_SearchView_onReplyStop()         //> Reply Stop
//# - ORBSMM_SearchView_onFail()              //> Failure
//# - ORBSMM_SearchView_doSearch()            //> Makes a search request
//# - ORBSMM_SearchView_onSearchReplyStart()  //> Reply Start
//# - ORBSMM_SearchView_onSearchReply()       //> Reply
//# - ORBSMM_SearchView_onSearchReplyStop()   //> Reply End
//# - ORBSMM_SearchView_onSearchReplyFail()   //> Failure
//#
//# + Recent View                            //> Recent View
//# ---------------------------------------------------------------------------
//# - ORBSMM_RecentView_Init()                //> Entrance
//# - ORBSMM_RecentView_onReplyStart()        //> Reply Start
//# - ORBSMM_RecentView_onReply()             //> Reply
//# - ORBSMM_RecentView_onReplyStop()         //> Reply Stop
//# - ORBSMM_RecentView_onFail()              //> Failure
//#
//# + All Files View                         //> All Files View
//# ---------------------------------------------------------------------------
//# - ORBSMM_AllFilesView_Init()              //> Entrance
//# - ORBSMM_AllFilesView_onReplyStart()      //> Reply Start
//# - ORBSMM_AllFilesView_onReply()           //> Reply
//# - ORBSMM_AllFilesView_onReplyStop()       //> Reply Stop
//# - ORBSMM_AllFilesView_onFail()            //> Failure
//#
//#############################################################################

//*********************************************************
//* Error Handling
//*********************************************************
//- ORBSMM_onMessage (General message handler)
function ORBSMM_onMessage(%tcp,%line)
{
}

//- ORBSMM_onError (Error handling)
ORBSMM_TCPManager.registerResponseHandler("ERROR","ORBSMM_onError",1);
function ORBSMM_onError(%tcp,%line)
{
   if(isObject(ORBSMM_LoadingContentSwatch))
   {
      ORBSMM_GUI_FailLoad(%line);
      %tcp.neutralise();
   }
   else
   {
      %tcp.neutralise();
      ORBSMM_GUI_Init();
      ORBSMM_GUI_createMessageBoxOK("Error","<just:center>"@%line);
   }
}

//- ORBSMM_onBarred (Barred)
function ORBSMM_onBarred(%tcp,%line)
{
}

//*********************************************************
//* General Handling
//*********************************************************
//- ORBSMM_onPagination (Pagination Callback)
ORBSMM_TCPManager.registerResponseHandler("PAGINATION","ORBSMM_onPagination",1);
function ORBSMM_onPagination(%tcp,%line)
{
   $ORBS::CModManager::Cache::Pagination::NumPages = getField(%line,0);
   $ORBS::CModManager::Cache::Pagination::CurrPage = getField(%line,1);
}

//*********************************************************
//* Auth
//*********************************************************
//- ORBSMM_Auth_Init (Entrance)
function ORBSMM_Auth_Init()
{
   if($ORBS::CModManager::Session::LoggedIn)
   {
      ORBS_ModManager.setText("Mod Manager - Logged in as "@$ORBS::CModManager::Session::LoginName);
      return;
   }
      
   if($ORBS::Barred::Download)
   {
      ORBS_ModManager.setText("Mod Manager - Barred from Use");
      return;
   }
      
   ORBSMM_SendRequest("AUTH",2);
   ORBS_ModManager.setText("Mod Manager - Logging In...");
}

//- ORBSMM_Auth_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("AUTH","ORBSMM_Auth_onReply");
function ORBSMM_Auth_onReply(%tcp,%line)
{
   if(getField(%line,0) $= "1")
   {
      $ORBS::CModManager::Session::LoggedIn = 1;
      $ORBS::CModManager::Session::LoginName = getField(%line,1);
      ORBS_ModManager.setText("Mod Manager - Logged in as "@$ORBS::CModManager::Session::LoginName);
   }
   else if(getField(%line,0) $= "0")
   {
      if(getField(%line,1) $= "2")
         ORBS_ModManager.setText("Mod Manager - No Account");
      else
         ORBS_ModManager.setText("Mod Manager - Error Occurred");
   }
}

//- ORBSMM_Auth_onFail (Failure)
ORBSMM_TCPManager.registerFailHandler("AUTH","ORBSMM_Auth_onFail");
function ORBSMM_Auth_onFail(%tcp,%error)
{
   ORBS_ModManager.setText("Mod Manager - Connection Failed");
}

//*********************************************************
//* News Feed View
//*********************************************************
//- ORBSMM_NewsFeedView_Init (Entrance)
function ORBSMM_NewsFeedView_Init(%page)
{
   ORBSMM_GUI_Load();
   
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      %item = ORBSMM_FileCache.getObject(%i);
      if(%item.file_platform $= "orbs" && %item.file_id > 0)
      {
         %files = %files@%item.file_id@"-";
      }
   }
   if(strLen(%files) > 1)
      %files = getSubStr(%files,0,strLen(%files)-1);

   ORBSMM_SendRequest("GETNEWS",1,%page,%files);
   ORBSMM_Zones_Track("NewsFeedView","ORBSMM_NewsFeedView_Init("@%page@");","ORBSMM_NewsFeedView_Init(%%page%%);");
}

//- ORBSMM_NewsFeedView_onReplyStart (Reply)
function ORBSMM_NewsFeedView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
}

//- ORBSMM_NewsFeedView_onReplyStop (Reply)
function ORBSMM_NewsFeedView_onReplyStop(%tcp)
{
   $ORBS::CModManager::GUI::CurrentY += 5;
   ORBSMM_GUI_Resize();
}

//- ORBSMM_NewsFeedView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETNEWS","ORBSMM_NewsFeedView_onReply");
function ORBSMM_NewsFeedView_onReply(%tcp,%line)
{
   if(getField(%line,0) $= "NEWS")
   {
      %news_id = getField(%line,1);
      %news_type = getField(%line,2);
      %news_subject = getField(%line,3);
      %news_date = getField(%line,4);
      %news_message = getField(%line,5);
      %news_author = getField(%line,6);
      %news_comments = getField(%line,7);
      
      %control = new GuiSwatchCtrl()
      {
         position = "5" SPC 5+$ORBS::CModManager::GUI::CurrentY;
         extent = "669 228";
         color = "180 185 191 255";
      };
      
      %header = ORBSMM_GUI_createHeader(1," ");
      %control.add(%header);
      %header.resize(1,1,668,28);
      
      %header_text = %header.getObject(1);
      %header_text.setText("<color:888888><font:Arial Bold:15>"@%news_subject);
      %header_text.shift(25,0);
      
      %cellType = 1;
      if(%news_type $= 1)
         %icon = "package_green";
      else if(%news_type $= 2)
      {
         %icon = "package_go";
         %cellType = 2;
      }
      else if(%news_type $= 3)
         %icon = "feed";
      
      %bitmap = new GuiBitmapCtrl()
      {
         position = "0 0";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/"@%icon;
      };
      %header.getBottom().add(%bitmap);
      ORBSMM_GUI_CenterVert(%bitmap);
      %bitmap.shift(3,-1);
      
      %date = new GuiMLTextCtrl()
      {
         profile = "";
         position = "0 6";
         extent = "668 15";
         text = "<color:888888><font:Verdana:12><just:right>"@%news_date;
      };
      %header.add(%date);
      %date.shift(-5,1);
      
      %content = ORBSMM_GUI_createContent(%cellType,171,100);
      %control.add(%content);
      
      %news_message = strreplace(%news_message,"<spcr>","<bitmap:"@$ORBS::Path@"images/icons/bullet_news>");
      %message = new GuiMLTextCtrl()
      {
         profile = "ORBSMM_NewsContentProfile";
         position = "2 4";
         extent = "668 0";
         text = "<color:888888><font:Verdana:12><just:left>"@%news_message@"<br>";
      };
      %content.getBottom(1).add(%message);
      
      ORBSMM_GUI_PushControl(%control);
      %message.forceReflow();
      
      %spacer = new GuiSwatchCtrl()
      {
         position = "0 "@getWord(%message.extent,1)+getWord(%message.position,1)-5;
         extent = "665 1";
         minExtent = "1 1";
         color = "255 255 255 255";
      };
      %content.getBottom(1).add(%spacer);
      if(%cellType $= "cellY")
         %spacer.color = "255 255 150 255";
         
      %spacer = new GuiSwatchCtrl()
      {
         position = "0 "@getWord(%message.extent,1)+getWord(%message.position,1)-6;
         extent = "665 1";
         minExtent = "1 1";
         color = "200 200 200 255";
      };
      if(%cellType $= "cellY")
         %spacer.color = "220 220 100 255";
         
      %content.getBottom(1).add(%spacer);
      %message.setText(%message.getText()@"<br> <font:Verdana Bold:12>by "@%news_author@"<just:right>"@%news_comments@" comments   ");
      %message.forceReflow();
      
      %content.resize(1,29,668,getWord(%message.extent,1)+12);
      
      %control.extent = "669" SPC getWord(%content.extent,1) + getWord(%content.position,1);
      
      $ORBS::CModManager::GUI::CurrentY = getWord(%control.extent,1) + getWord(%control.position,1) + 5;
      ORBSMM_GUI_Resize();
   }
}

//- ORBSMM_NewsFeedView_onFail (Failure)
ORBSMM_TCPManager.registerFailHandler("GETNEWS","ORBSMM_NewsFeedView_onFail");
function ORBSMM_NewsFeedView_onFail(%tcp,%error)
{
   ORBSMM_GUI_FailLoad();
}

//*********************************************************
//* Category View
//*********************************************************
//- ORBSMM_CategoryView_Init (Entrance)
function ORBSMM_CategoryView_Init()
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETCATEGORIES",1);
   ORBSMM_Zones_Track("CategoryView","ORBSMM_CategoryView_Init();");
}

//- ORBSMM_CategoryView_onReplyStart (Reply)
function ORBSMM_CategoryView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
}

//- ORBSMM_CategoryView_onReplyStop (Reply)
function ORBSMM_CategoryView_onReplyStop(%tcp)
{
   //ORBSMM_GUI_createSplitHeader(2,100,"");
   ORBSMM_GUI_createHeader(2);
}

//- ORBSMM_CategoryView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETCATEGORIES","ORBSMM_CategoryView_onReply");
function ORBSMM_CategoryView_onReply(%tcp,%line)
{
   if(getField(%line,0) $= "CATEGORY")
   {
      ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  "@getField(%line,1));
      ORBSMM_GUI_createSplitHeader(1,"70","<font:Arial Bold:15>Section","7","<font:Arial Bold:15>Files","23","<font:Arial Bold:15>Latest Addition");
   }
   else if(getField(%line,0) $= "SECTION")
   {
      %container = ORBSMM_GUI_createContent(1,38,6,64,7,23);
      
      %c_icon = %container.getObject(0);
      %c_information = %container.getObject(1);
      %c_files = %container.getObject(2);
      %c_latest = %container.getObject(3);
      
      %swatch = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = %c_icon.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_icon.add(%swatch);
      
      %icon = new GuiBitmapCtrl()
      {
         extent = "26 26";
         bitmap = $ORBS::Path@"images/icons/section";
      };
      %c_icon.add(%icon);
      ORBSMM_GUI_Center(%icon);

      %swatch = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = %c_information.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_information.add(%swatch);
      
      %text = new GuiMLTextCtrl()
      {
         position = "1 3";
         extent = "307 18";
         text = "<font:Arial Bold:15><color:888888> "@getField(%line,2);
      };
      %c_information.add(%text);
      
      %text = new GuiMLTextCtrl()
      {
         position = "3 19";
         extent = "450 18";
         text = "<font:Verdana:12><color:444444>"@getField(%line,3);
      };
      %c_information.add(%text);
      
      %swatch = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = %c_files.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_files.add(%swatch);
      
      %text = new GuiTextCtrl()
      {
         profile = ORBS_Verdana12PtCenter;
         position = "0 7";
         extent = 100 SPC 18;
         text = "\c1"@getField(%line,5);
      };
      %c_files.add(%text);
      ORBSMM_GUI_Center(%text);
      
      %swatch = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = %c_latest.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_latest.add(%swatch);
      
      %text = new GuiMLTextCtrl()
      {
         position = "0 7";
         extent = 150 SPC 18;
         text = "<just:center><font:Verdana:12><color:888888>"@getField(%line,4);
      };
      %c_latest.add(%text);
      %text.forceReflow();
      ORBSMM_GUI_Center(%text);
      
      %mouseCtrl = new GuiMouseEventCtrl()
      {
         position = %container.position;
         extent = %container.extent;
         
         eventType = "sectionSelect";
         eventCallbacks = "1111000";
         
         sectionID = getField(%line,1);
         container = %container;
      };
      ORBSMM_GUI_PushControl(%mouseCtrl,1);
   }
}

//- Event_sectionSelect::onMouseEnter (MouseEnter Callback)
function Event_sectionSelect::onMouseEnter(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.visible = 1;
   }
}

//- Event_sectionSelect::onMouseLeave (MouseLeave Callback)
function Event_sectionSelect::onMouseLeave(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.visible = 0;
      %swatch.color = "255 255 255 100";
   }
}

//- Event_sectionSelect::onMouseDown (MouseDown Callback)
function Event_sectionSelect::onMouseDown(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.color = "255 230 230 150";
   }
}

//- Event_sectionSelect::onMouseUp (MouseUp Callback)
function Event_sectionSelect::onMouseUp(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.color = "255 255 255 100";
   }   
   ORBSMM_SectionView_Init(%ctrl.sectionID);
}

//- ORBSMM_CategoryView_onFail (Failure)
ORBSMM_TCPManager.registerFailHandler("GETCATEGORIES","ORBSMM_CategoryView_onFail");
function ORBSMM_CategoryView_onFail(%tcp,%error)
{
   if(%error $= "DNS")
      ORBSMM_GUI_FailLoad("Connection Failed");
   else
      ORBSMM_GUI_FailLoad("Connection Failed");
}

//*********************************************************
//* Section View
//*********************************************************
//- ORBSMM_SectionView_Init (Entrance)
function ORBSMM_SectionView_Init(%section,%page)
{
   ORBSMM_GUI_Load();
   
   $ORBS::CModManager::Cache::CurrentSection = %section;
   
   ORBSMM_SendRequest("GETSECTION",1,%section,%page);
   ORBSMM_Zones_Track("SectionView","ORBSMM_SectionView_Init("@%section@",\""@%page@"\");","ORBSMM_SectionView_Init("@%section@",%%page%%);");
}

//- ORBSMM_SectionView_onReplyStart (Reply)
function ORBSMM_SectionView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
}

//- ORBSMM_SectionView_onReplyStop (Reply)
function ORBSMM_SectionView_onReplyStop(%tcp)
{
   if($ORBS::CModManager::Cache::ElementsAdded <= 0)
   {
      ORBSMM_GUI_createMessage("<br>There are no files in this section.<br>");
   }
      
   ORBSMM_GUI_createFooter(1);
}

//- ORBSMM_SectionView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETSECTION","ORBSMM_SectionView_onReply");
function ORBSMM_SectionView_onReply(%tcp,%line)
{
	if(getWord(%line,0) $= "HEADER")
	{
		ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  "@getField(%line,1));
		ORBSMM_GUI_createSplitHeader(1,"58","<font:Arial Bold:15>File","15","<font:Arial Bold:15>Submitter","12","<font:Arial Bold:15>Downloads","15","<font:Arial Bold:15>Rating");
	}
	else if(getWord(%line,0) $= "FILE")
	{  
		$ORBS::CModManager::Cache::ElementsAdded++;

		if(getField(%line,2) $= 1)
			%container = ORBSMM_GUI_createContent(2,50,6,52,15,12,15);
		else
			%container = ORBSMM_GUI_createContent(1,50,6,52,15,12,15);

		%c_icon = %container.getObject(0);     
		%c_information = %container.getObject(1);
		%c_submitter = %container.getObject(2);
		%c_downloads = %container.getObject(3);
		%c_rating = %container.getObject(4);

		if(getField(%line,2) $= 1)
		{
			%swatch = new GuiSwatchCtrl()
			{
				vertSizing = "height";
				position = "0 0";
				extent = %c_icon.extent;
				color = "255 255 255 100";
				visible = 0;
			};
			%c_icon.add(%swatch);
			%swatch = new GuiSwatchCtrl()
			{
				vertSizing = "center";
				extent = "16 32";
				color = "0 0 0 0";
			};
			%c_icon.add(%swatch);
			%icon = new GuiBitmapCtrl()
			{
				position = "0 3";
				extent = "16 16";
				bitmap = $ORBS::Path@"images/icons/"@getField(%line,3);
			};
			%swatch.add(%icon);
			%icon = new GuiBitmapCtrl()
			{
				position = "0 19";
				extent = "16 16";
				bitmap = $ORBS::Path@"images/icons/new";
			};
			%swatch.add(%icon);
			ORBSMM_GUI_Center(%swatch,%c_icon);
		}
		else
		{
			%swatch = new GuiSwatchCtrl()
			{
				vertSizing = "height";
				position = "0 0";
				extent = %c_icon.extent;
				color = "255 255 255 100";
				visible = 0;
			};
			%c_icon.add(%swatch);
			%icon = new GuiBitmapCtrl()
			{
				vertSizing = "center";
				position = "0 0";
				extent = "16 16";
				bitmap = $ORBS::Path@"images/icons/"@getField(%line,3);
			};
			%c_icon.add(%icon);
			ORBSMM_GUI_Center(%icon,%c_icon);
		}
		if(ORBSMM_FileCache.get(getField(%line,1)) && !ORBSMM_FileCache.get(getField(%line,1)).file_isContent)
		{
			%star = new GuiBitmapCtrl()
			{
				position = "24 -2";
				extent = "16 16";
				bitmap = $ORBS::Path@"images/icons/bullet_star";
			};
			%c_icon.add(%star);
		}

		%swatch = new GuiSwatchCtrl()
		{
			vertSizing = "height";
			position = "0 0";
			extent = %c_information.extent;
			color = "255 255 255 100";
			visible = 0;
		};
		%c_information.add(%swatch);
		%text = new GuiMLTextCtrl()
		{
			position = "1 3";
			extent = "327 18";
			text = "<font:Arial Bold:15><color:888888> "@getField(%line,4);
		};
		%c_information.add(%text);

		%mltext = new GuiMLTextCtrl()
		{
			position = "3 18";
			extent = "325 18";
			text = "<font:Verdana:12><color:444444>"@getField(%line,5);
		};
		%c_information.add(%mltext);
		%text = new GuiMLTextCtrl()
		{
			vertSizing = "top";
			position = "3 32";
			extent = "325 18";
			text = "<font:Verdana:12><color:666666>\xBB <color:888888>By "@getField(%line,6);
		};
		%c_information.add(%text);

		%mltext.forceReflow();
		%extent = getWord(%mltext.extent,1);
		%container.resize(getWord(%container.position,0),getWord(%container.position,1),getWord(%container.extent,0),%extent+36);
		ORBSMM_GUI_AutoResize();

		%swatch = new GuiSwatchCtrl()
		{
			vertSizing = "height";
			position = "0 0";
			extent = %c_submitter.extent;
			color = "255 255 255 100";
			visible = 0;
		};
		%c_submitter.add(%swatch);
		%text = new GuiTextCtrl()
		{
			profile = ORBS_Verdana12PtCenter;
			position = "0 7";
			extent = 100 SPC 18;
			text = "\c1"@getField(%line,7);
		};
		%c_submitter.add(%text);
		ORBSMM_GUI_Center(%text);

		%swatch = new GuiSwatchCtrl()
		{
			vertSizing = "height";
			position = "0 0";
			extent = %c_downloads.extent;
			color = "255 255 255 100";
			visible = 0;
		};
		%c_downloads.add(%swatch);
		%text = new GuiMLTextCtrl()
		{
			position = "0 7";
			extent = 150 SPC 18;
			text = "<just:center><font:Verdana:12><color:888888>"@getField(%line,8);
		};
		%c_downloads.add(%text);
		%text.forceReflow();
		ORBSMM_GUI_Center(%text);

		%swatch = new GuiSwatchCtrl()
		{
			vertSizing = "height";
			position = "0 0";
			extent = %c_rating.extent;
			color = "255 255 255 100";
			visible = 0;
		};
		%c_rating.add(%swatch);
		%swatch = ORBSMM_GUI_createRatingSwatch(getField(%line,9));
		%c_rating.add(%swatch);
		ORBSMM_GUI_Center(%swatch);

		%mouseCtrl = new GuiMouseEventCtrl()
		{
			position = %container.position;
			extent = %container.extent;

			eventType = "fileSelect";
			eventCallbacks = "1111000";

			persistent = 1;

			fileID = getField(%line,1);
			fileRecent = getField(%line,2);
			container = %container;
		};
		ORBSMM_GUI_PushControl(%mouseCtrl,1);

		%downloadBtn = new GuiBitmapButtonCtrl()
		{
			position = "375 1";
			extent = "16 16";
			visible = 0;
			bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/downloadSmall";
			text = " ";
			command = "ORBSMM_TransferView_Add("@getField(%line,1)@");";
		};
		%mouseCtrl.add(%downloadBtn);
		%container.dlIcon = %downloadBtn;

		%reportBtn = new GuiBitmapButtonCtrl()
		{
			position = "375" SPC getWord(%mouseCtrl.extent,1)-19;
			extent = "16 16";
			visible = 0;
			bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/reportSmall";
			text = " ";
			command = "ORBSMM_FileView_Report("@getField(%line,1)@");";
		};
		%mouseCtrl.add(%reportBtn);
		%container.rpIcon = %reportBtn;
	}
}  

function Event_drag::onMouseDown(%ctrl)
{
   %offset = getWords(vectorSub(Canvas.getCursorPos(),%ctrl.drag.getCanvasPosition()),0,1);
   beginDrag(%ctrl,%offset);
}

function beginDrag(%ctrl,%offset)
{
   if(isEventPending(%ctrl.sch))
      cancel(%ctrl.sch);
   if(!isObject(%ctrl))
      return;
	
   %ctrl.drag.position = getWords(vectorSub(Canvas.getCursorPos(),%offset),0,1);
   %ctrl.sch = schedule(10,0,"beginDrag",%ctrl,%offset);
}

function returntoplace(%ctrl,%time,%x_pos,%y_pos,%x_chng,%y_chng,%duration)
{
   if(%time $= "")
   {
      %duration = 500;
      %time = 0;
      %x_targ = "50";
      %y_targ = "50";
      %x_pos = getWord(%ctrl.drag.position,0);
      %y_pos = getWord(%ctrl.drag.position,1);
      %x_chng = firstWord(vectorSub(%x_targ,%x_pos));
      %y_chng = firstWord(vectorSub(%y_targ,%y_pos));
   }

   %new_x = mfloor(Anim_EaseInOut(%time,%x_pos,%x_chng,%duration));
   %new_y = mfloor(Anim_EaseInOut(%time,%y_pos,%y_chng,%duration));
   //return;
   %ctrl.drag.position = %new_x SPC %new_y;
   
   //if(%new_x $= 50 && %new_y $= 50)
     // return;   
   if(%time > %duration)
   {
      return;
   }
   
   $sch = schedule(10,0,"returntoplace",%ctrl,%time+10,%x_pos,%y_pos,%x_chng,%y_chng,%duration);
}

function Event_drag::onMouseLeave(%ctrl)
{

}

function Event_drag::onMouseUp(%ctrl)
{
   cancel(%ctrl.sch);
   returntoplace(%ctrl);
}

//- Event_fileSelect::onMouseEnter (MouseEnter Callback)
function Event_fileSelect::onMouseEnter(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount()&&(%i<%ctrl.recurseHover||!%ctrl.recurseHover);%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.visible = 1;
   }
   %container.dlIcon.setVisible(1);
   %container.rpIcon.setVisible(1);
}

//- Event_fileSelect::onMouseLeave (MouseLeave Callback)
function Event_fileSelect::onMouseLeave(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount()&&(%i<%ctrl.recurseHover||!%ctrl.recurseHover);%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.visible = 0;
      %swatch.color = "255 255 255 100";
   }
   %container.dlIcon.setVisible(0);
   %container.rpIcon.setVisible(0);
}

//- Event_fileSelect::onMouseDown (MouseDown Callback)
function Event_fileSelect::onMouseDown(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount()&&(%i<%ctrl.recurseHover||!%ctrl.recurseHover);%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.color = "255 230 230 150";
   }
}

//- Event_fileSelect::onMouseUp (MouseUp Callback)
function Event_fileSelect::onMouseUp(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount()&&(%i<%ctrl.recurseHover||!%ctrl.recurseHover);%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.color = "255 255 255 100";
   }   
   ORBSMM_FileView_Init(%ctrl.fileID);
}

//- ORBSMM_SectionView_onFail (Failure)
ORBSMM_TCPManager.registerFailHandler("GETSECTION","ORBSMM_SectionView_onFail");
function ORBSMM_SectionView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* File View
//*********************************************************
//- ORBSMM_FileView_Init (Entrance)
function ORBSMM_FileView_Init(%id)
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETFILE",1,%id);
   ORBSMM_Zones_Track("FileView","ORBSMM_FileView_Init(\""@%id@"\");");
}

//- ORBSMM_FileView_onReplyStart (Start)
function ORBSMM_FileView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
}

//- ORBSMM_FileView_onReplyStop (Stop Reply)
function ORBSMM_FileView_onReplyStop(%tcp)
{
}

//- ORBSMM_FileView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETFILE","ORBSMM_FileView_onReply");
function ORBSMM_FileView_onReply(%tcp,%line)
{
   if(getField(%line,0) $= "HEAD")
   {
      ORBSMM_GUI_createSplitHeader("cell1","100","<color:FAFAFA><just:left><font:Impact:18>  "@getField(%line,1));
   }
   else if(getField(%line,0) $= "DEFS")
   {
      $ORBS::CModManager::Cache::CurrentFile = getField(%line,1);
   }
   else if(getField(%line,0) $= "FILE")
   {
      ORBSMM_SectionView_onReply(%tcp,%line);
   }
   else if(getField(%line,0) $= "INFO")
   {
      %info = ORBSMM_GUI_createContent(1,30,20,80);
      %label = %info.getObject(0);
      %content = %info.getObject(1);
      
      %label_txt = new GuiMLTextCtrl()
      {
         position = "6 7";
         extent = "128 30";
         text = "<font:Arial Bold:15><color:444444>"@getField(%line,1);
      };
      %label.add(%label_txt);
      
      %content_txt = new GuiMLTextCtrl()
      {
         position = "6 9";
         extent = "530 30";
         text = "<font:Verdana:12><color:666666>"@strTrim(ORBSMM_parseBBCode(getField(%line,2)));
      };
      %content.add(%content_txt);
      %content_txt.forceReflow();
      %extent = getWord(%content_txt.extent,1);
      %info.resize(getWord(%info.position,0),getWord(%info.position,1),getWord(%info.extent,0),%extent+18);
      ORBSMM_GUI_AutoResize();
   }
   else if(getField(%line,0) $= "RATE")
   {
      %info = ORBSMM_GUI_createContent(1,30,20,80);
      %label = %info.getObject(0);
      %content = %info.getObject(1);
      
      %label_txt = new GuiMLTextCtrl()
      {
         position = "6 7";
         extent = "128 30";
         text = "<font:Arial Bold:15><color:444444>Rating:";
      };
      %label.add(%label_txt);
      
      %rating = getSubStr(getField(%line,1),0,5);
      %rating = ORBSMM_GUI_createRatingSwatch(%rating);
      %content.add(%rating);
      ORBSMM_GUI_CenterVert(%rating);
      
      %numRatings = getSubStr(getField(%line,1),6,strLen(getField(%line,1)));
      %s = (%numRatings == 1) ? "" : "s";
      %mlTextCtrl = new GuiMLTextCtrl()
      {
         position = "95 0";
         extent = "88";
         text = "<just:left><font:Arial:12><color:AAAAAA>"@%numRatings@" rating"@%s;
      };
      %content.add(%mlTextCtrl);
      %mlTextCtrl.forceReflow();
      ORBSMM_GUI_CenterVert(%mlTextCtrl);
      %mlTextCtrl.shift(0,1);
      
      $ORBS::CModManager::Cache::FileRatingSwatch = %rating;
      $ORBS::CModManager::Cache::FileRatingText = %mlTextCtrl;
   }
   else if(getField(%line,0) $= "SCREENSHOTS")
   {
      ORBSMM_GUI_createSplitHeader("cell1","100","<color:FAFAFA><just:left><font:Impact:18>  Screenshots");
      
      %collage = getField(%line,9);
      %container = ORBSMM_GUI_createContent(1,140,100).getObject(0);
      
      %sCount = 0;
      %screenMask = (getField(%line,1) !$= "")@(getField(%line,2) !$= "")@(getField(%line,3) !$= "")@(getField(%line,4) !$= "");
      for(%i=0;%i<4;%i++)
      {
         if(getSubStr(%screenMask,%i,1) $= "1")
         {
            %s[%sCount] = %i+1;
            %sCount++;
         }
      }
      
      %ssCon = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = (118*%sCount)+(%sCount*40)-40 SPC "90";
         color = "0 0 0 0";
      };
      %container.add(%ssCon);
      ORBSMM_GUI_Center(%ssCon,%container);
      
      for(%i=0;%i<%sCount;%i++)
      {
         %ss = new GuiSwatchCtrl()
         {
            position = (118*%i)+(%i*40) SPC 0;
            extent = "118 90";
            color = "100 100 100 255";
            
            new GuiSwatchCtrl()
            {
               position = "1 1";
               extent = "116 88";
               color = "255 255 255 255";
               
               new GuiBitmapCtrl()
               {
                  position = "2 2";
                  extent = "112 84";
                  bitmap = $ORBS::Path@"images/ui/checkedGrid";
                  wrap = 1;
                  
                  new GuiSwatchCtrl()
                  {
                     position = "0 0";
                     extent = "112 84";
                     color = "255 255 255 200";
                  };
               };
            };
         };
         %ssCon.add(%ss);
         
         $ORBS::CModManager::Cache::Screen[%i] = %s[%i];
         $ORBS::CModManager::Cache::ScreenControl[%i] = %ss.getObject(0);
         $ORBS::CModManager::Cache::ScreenURL[%i] = getField(%line,%i+1);
         $ORBS::CModManager::Cache::ScreenCaption[%i] = getField(%line,5+%i);
      }
      $ORBS::CModManager::Cache::ScreenCount = %sCount;
      
      if($ORBS::CModManager::PCache::CollageSHA $= getField(%line,9))
      {
         for(%i=0;%i<$ORBS::CModManager::Cache::ScreenCount;%i++)
         {
            %id = $ORBS::CModManager::Cache::Screen[%i];
            %ctrl = $ORBS::CModManager::Cache::ScreenControl[%i];
            
            %img = new GuiSwatchCtrl()
            {
               position = "2 2";
               extent = "112 84";
               color = "255 255 255 255";
               
               new GuiBitmapCtrl()
               {
                  position = "0 0";
                  extent = "224 168";
                  bitmap = "config/client/orbs/cache/collage.png";
               };

               new GuiSwatchCtrl()
               {
                  position = "0 0";
                  extent = "112 84";
                  color = "255 255 255 255";
               };
            };
            %ctrl.clear();
            %ctrl.add(%img);
            
            %swatch = new GuiSwatchCtrl()
            {
               position = "0 0";
               extent = "112 84";
               color = "255 255 255 0";
            };
            %img.add(%swatch);
            
            %mouseCtrl = new GuiMouseEventCtrl()
            {
               position = "0 0";
               extent = "112 84";
               
               eventType = "screenshotSelect";
               eventCallbacks = "1111000";
               
               screenID = %i;
               screenCaption = $ORBS::CModManager::Cache::ScreenCaption[%i];
               swatch = %swatch;
            };
            %img.add(%mouseCtrl);
            
            if(%i $= 1)
               %img.getObject(0).position = "-112 0";
            else if(%i $= 2)
               %img.getObject(0).position = "0 -84";
            else if(%i $= 3)
               %img.getObject(0).position = "-112 -84";
               
            ORBSMM_GUI_FadeOut(%img.getObject(1));
         }
      }
      else
      {
         ORBSMM_ScreenGrabber.getCollage("/forum/downloads/canvas.php?c="@%collage@".png");
         $ORBS::CModManager::PCache::CollageSHA = %collage;
      }
   }
   else if(getField(%line,0) $= "OPTS")
   {
      %content = ORBSMM_GUI_createContent(1,48,45,55);
      %blurb = %content.getObject(0);
      %buttons = %content.getObject(1);
      
      if(getField(%line,1) $= 0)
      {
         %bitmap = "skull-32";
      }
      else if(getField(%line,1) $= 1)
      {
         %bitmap = "icons/medal-32";
         %text = "This file has been approved by our moderators.<br>This means it appears to be safe to use.";
      }
      else if(getField(%line,1) $= 2)
      {
         %bitmap = "pirate-captain-32";
      }
         
      %bmp = new GuiBitmapCtrl()
      {
         position = "15 7";
         extent = "32 32";
         bitmap = $ORBS::Path@"images/icons/"@%bitmap;
      };
      %blurb.add(%bmp);
      
      %txt = new GuiMLTextCtrl()
      {
         position = "40 9";
         extent = "272 24";
         text = "<just:center><font:Verdana:12><color:444444>"@%text;
      };
      %blurb.add(%txt);
      ORBSMM_GUI_CenterVert(%bmp);
      ORBSMM_GUI_CenterVert(%txt);
      
      %swatch = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = "82 25";
         color = "0 0 0 0";
      };
      %currExtent = 182;
      %currPos = 90;
      
      %download = new GuiBitmapButtonCtrl()
      {
         position = "0 0";
         extent = "82 25";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/download";
         text = " ";
         command = "ORBSMM_FileView_Download();";
      };
      %swatch.add(%download);
      
      if(!$ORBS::Barred::Rate)
      {
         %rate = new GuiBitmapButtonCtrl()
         {
            position = %currPos@" 0";
            extent = "82 25";
            bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/addRating";
            text = " ";
            command = "ORBSMM_FileView_Rate();";
         };
         %swatch.add(%rate);
         %swatch.extent = %currExtent-8 SPC 25;
         %currExtent += 90;
         %currPos += 90;
      }
      
      if(!$ORBS::Barred::Comment)
      {
         %comment = new GuiBitmapButtonCtrl()
         {
            position = %currPos@" 0";
            extent = "82 25";
            bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/comment";
            text = " ";
            command = "ORBSMM_FileView_openCommentBox();";
         };
         %swatch.add(%comment);
         %swatch.extent = %currExtent-8 SPC 25;
         %currExtent += 90;
         %currPos += 90;
      }
      
      if($ORBS::CModManager::Session::LoggedIn)
      {
         %report = new GuiBitmapButtonCtrl()
         {
            position = %currPos@" 0";
            extent = "82 25";
            bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/report";
            text = " ";
            command = "ORBSMM_FileView_Report();";
         };
         %swatch.add(%report);
         %swatch.extent = %currExtent-8 SPC 25;
      }
      
      %buttons.add(%swatch);
      ORBSMM_GUI_Center(%swatch);
   }
   else if(getField(%line,0) $= "COMMENTS")
   {
      if(getField(%line,1) <= 0)
      {
         $ORBS::CModManager::Cache::FileFooter = ORBSMM_GUI_createHeader();
         return;
      }

      $ORBS::CModManager::Cache::Comments = getField(%line,1);
      $ORBS::CModManager::Cache::CommentPages = getField(%line,2);
      $ORBS::CModManager::Cache::CommentCurrPage = 1;
      $ORBS::CModManager::Cache::CommentHeader = ORBSMM_GUI_createSplitHeader("cell1","100","<color:FAFAFA><just:left><font:Impact:18>  Comments <font:Arial:12>"@getField(%line,1)@" comment"@((getField(%line,1) == 1) ? "" : "s"));
      
      %container = new GuiSwatchCtrl()
      {
         position = "0 "@$ORBS::CModManager::GUI::CurrentY;
         extent = "680 10";
         color = "255 0 0 255";
      };
      ORBSMM_GUI_PushControl(%container,1);
      
      $ORBS::CModManager::Cache::CommentContainer = %container;
   }
   else if(getField(%line,0) $= "COMMENT")
   {
      ORBSMM_FileView_createComment(getField(%line,1),getField(%line,2),getField(%line,3),getField(%line,4),getField(%line,5),getField(%line,6));
      $ORBS::CModManager::Cache::CommentContainer.extent = "680" SPC $ORBS::CModManager::Cache::CommentContainer.getLowestPoint();
      ORBSMM_GUI_AutoResize();
   }
   else if(getField(%line,0) $= "ENDCOMMENTS")
   {
      $ORBS::CModManager::Cache::CommentFooter = ORBSMM_GUI_createHeader(2," ");
      ORBSMM_FileView_drawCommentPagination();
   }
}

//- ORBSMM_FileView_drawCommentPagination (i am not proud of this horrible, horrible hack)
function ORBSMM_FileView_drawCommentPagination()
{
   if(isObject($ORBS::CModManager::Cache::CommentHeader.pagination))
      $ORBS::CModManager::Cache::CommentHeader.pagination.delete();
   if(isObject($ORBS::CModManager::Cache::CommentFooter.pagination))
      $ORBS::CModManager::Cache::CommentFooter.pagination.delete();

   if($ORBS::CModManager::Cache::CommentPages > 1)
   {
      if($ORBS::CModManager::Cache::CommentCurrPage < $ORBS::CModManager::Cache::CommentPages)
      {
         %text = "<font:Verdana Bold:13><a:comment-pagination-prev>Previous</a>";
      }
      if($ORBS::CModManager::Cache::CommentCurrPage > 1)
      {
         if(%text $= "")
            %text = "<font:Verdana Bold:13><a:comment-pagination-next>Next</a> ";
         else
            %text = "<font:Verdana Bold:13><a:comment-pagination-next>Next</a> | <a:comment-pagination-prev>Previous</a>";
      }
      
      %ctrl = new GuiMLTextCtrl()
      {
         profile = ORBSMM_PaginationProfile;
         position = "477 7";
         extent = "200 13";
         text = "<just:right>"@%text;
      };
      $ORBS::CModManager::Cache::CommentHeader.add(%ctrl);
      $ORBS::CModManager::Cache::CommentHeader.pagination = %ctrl;

      %ctrl = new GuiMLTextCtrl()
      {
         profile = ORBSMM_PaginationProfile;
         position = "477 7";
         extent = "200 13";
         text = "<just:right>"@%text;
      };
      $ORBS::CModManager::Cache::CommentFooter.add(%ctrl);
      $ORBS::CModManager::Cache::CommentFooter.pagination = %ctrl;      
   }
}

//- ORBSMM_FileView_openCommentBox (opens a comment box for users to post comments)
function ORBSMM_FileView_openCommentBox()
{
   %window = ORBSMM_GUI_createWindow("Post a Comment");
   %window.resize(0,0,350,200);
   ORBSMM_GUI_Center(%window);
   
   %background = new GuiSwatchCtrl()
   {
      position = "5 5";
      extent = "318 120";
      color = "200 200 200 255";
      
      new GuiSwatchCtrl()
      {
         position = "1 1";
         extent = "316 118";
         color = "255 255 255 255";
      };
   };
   %window.canvas.add(%background);
   
   %textedit = new GuiScrollCtrl()
   {
      profile = ORBS_ScrollProfile;
      position = "0 5";
      extent = "337 120";
      hScrollBar = "alwaysOff";
      vScrollBar = "alwaysOn";
      childMargin = "8 1";
      
      new GuiMLTextEditCtrl(ORBSMM_FileView_Comment)
      {
         profile = ORBS_MLEditProfile;
         position = "3 1";
         extent = "310 10";
         lineSpacing = 2;
         allowColorChars = 0;
         maxChars = "-1";
         maxBitmapHeight = "-1";
      };
   };
   %window.canvas.add(%textedit);
   
   %textedit.getObject(0).makeFirstResponder(1);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "280 133";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = "ORBSMM_FileView_sendComment("@%window@");";
   };
   %window.canvas.add(%button);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "220 133";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/cancel";
      command = %window.closeButton.command;
   };
   %window.canvas.add(%button);
}

//- ORBSMM_FileView_sendComment (sends a comment for a file)
function ORBSMM_FileView_sendComment(%window)
{
   if(ORBSMM_FileView_Comment.getValue() $= "")
   {
      ORBSMM_GUI_createMessageBoxOK("Ooops","<just:center><br>You have not entered a comment.<br>");
      return;
   }
   
   %overlay = new GuiSwatchCtrl()
   {
      position = "0 0";
      extent = %window.canvas.extent;
      color = "255 255 255 200";
   };
   %window.canvas.add(%overlay);
   
   %bitmap = new GuiAnimatedBitmapCtrl()
   {
      extent = "31 31";
      bitmap = $ORBS::Path@"images/ui/animated/loadRing";
      framesPerSecond = 15;
      numFrames = 8;
   };
   %overlay.add(%bitmap);
   ORBSMM_GUI_Center(%bitmap);
   %bitmap.shift(0,-10);
   
   %mlCtrl = new GuiMLTextCtrl()
   {
      extent = "200 0";
      text = "<just:center><font:Verdana:12><color:666666>Submitting Comment...";
   };
   %overlay.add(%mlCtrl);
   ORBSMM_GUI_Center(%mlCtrl);
   %mlCtrl.shift(0,12);
   
   $ORBS::CModManager::Cache::LoadRing = %bitmap;
   $ORBS::CModManager::Cache::LoadText = %mlCtrl;
   
   ORBSMM_SendRequest("POSTCOMMENT",2,$ORBS::CModManager::Cache::CurrentFile,ORBSMM_FileView_Comment.getValue());
}

//- ORBSMM_FileView_onCommentPosted (a callback when the comment is sent)
ORBSMM_TCPManager.registerResponseHandler("POSTCOMMENT","ORBSMM_FileView_onCommentPosted");
function ORBSMM_FileView_onCommentPosted(%tcp,%line)
{
   ORBSMM_GUI_LoadRing_Clear($ORBS::CModManager::Cache::LoadRing);
   if(getField(%line,0) $= 1)
   {
      if($ORBS::CModManager::Cache::Comments <= 0)
      {
         ORBSMM_Zones_Refresh();
         return;
      }
      
      $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Your comment has been submitted.");
      ORBSMM_FileView_getCommentPage(1);
   }
   else
   {
      $ORBS::CModManager::Cache::LoadRing.setBitmap($ORBS::Path@"images/ui/animated/loadRing_fail");
      if(getField(%line,1) $= 1)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>You are not logged in!");
      else if(getField(%line,1) $= 2)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>File not found.");
      else if(getField(%line,1) $= 3)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>You did not write a comment.");
      else
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Unknown Error Occurred.");
   }
}

//- ORBSMM_FileView_onCommentFail (Fail result from sending a report)
ORBSMM_TCPManager.registerFailHandler("SENDCOMMENT","ORBSMM_FileView_onCommentFail");
function ORBSMM_FileView_onCommentFail(%tcp,%fail)
{
   ORBSMM_GUI_LoadRing_Clear($ORBS::CModManager::Cache::LoadRing);
   $ORBS::CModManager::Cache::LoadRing.setBitmap($ORBS::Path@"images/ui/animated/loadRing_fail");
   $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Connection Failed. Please try again later.");
}

//- ORBSMM_FileView_getCommentPage (gets a page of comments for display)
function ORBSMM_FileView_getCommentPage(%page)
{
   ORBSMM_FileView_collapseComments();
   
   if(isObject($ORBS::CModManager::Cache::CommentHeader.pagination))
      $ORBS::CModManager::Cache::CommentHeader.pagination.delete();
   if(isObject($ORBS::CModManager::Cache::CommentFooter.pagination))
      $ORBS::CModManager::Cache::CommentFooter.pagination.delete();
      
   $ORBS::CModManager::Cache::CommentCurrPage = %page;
   
   schedule(100,0,"ORBSMM_SendRequest","GETCOMMENTPAGE",2,$ORBS::CModManager::Cache::CurrentFile,%page);
}

//- ORBSMM_FileView_onCommentReplyStop (callback when comments are done downloading)
function ORBSMM_FileView_onCommentReplyStop()
{
   ORBSMM_GUI_FadeOut($ORBS::CModManager::Cache::CommentCover);
   $ORBS::CModManager::Cache::CommentCover.clear();
   ORBSMM_FileView_sizeupComments(0,120,getWord($ORBS::CModManager::Cache::CommentContainer.extent,1)-120,1000);
   
   ORBSMM_FileView_drawCommentPagination();
}

//- ORBSMM_FileView_onCommentReply (handler for comment replies)
ORBSMM_TCPManager.registerResponseHandler("GETCOMMENTPAGE","ORBSMM_FileView_onCommentReply");
function ORBSMM_FileView_onCommentReply(%tcp,%line)
{
   if(getField(%line,0) $= "COMMENT")
   {
      ORBSMM_FileView_createComment(getField(%line,1),getField(%line,2),getField(%line,3),getField(%line,4),getField(%line,5),getField(%line,6));
      $ORBS::CModManager::Cache::CommentContainer.extent = "680" SPC $ORBS::CModManager::Cache::CommentContainer.getLowestPoint();
   }
}

//- ORBSMM_FileView_createComment (creates content container for comments)
function ORBSMM_FileView_createComment(%author,%title,%comments,%blid,%date,%message)
{
   %container = ORBSMM_GUI_createContent(1,120,25,75);
   %info = %container.getObject(0);
   %content = %container.getObject(1);      

   %author = new GuiMLTextCtrl()
   {
      position = "6 7";
      extent = "128 30";
      text = "<font:Arial Bold:15><color:666666>"@%author;
   };
   %info.add(%author);

   %title = new GuiMLTextCtrl()
   {
      position = "5 23";
      extent = "128 30";
      text = "<font:Verdana:12><color:888888>"@%title;
   };
   %info.add(%title);

   %data = new GuiMLTextCtrl()
   {
      position = "5 53";
      extent = "128 30";
      text = "<font:Verdana Bold:12><color:888888>Comments: <font:Verdana:12>"@%comments;
   };
   %info.add(%data);

   %data = new GuiMLTextCtrl()
   {
      position = "5 66";
      extent = "128 30";
      text = "<font:Verdana Bold:12><color:888888>Blockland ID: <font:Verdana:12>"@%blid;
   };
   %info.add(%data);

   %date = new GuiMLTextCtrl()
   {
      position = "7 7";
      extent = "300 30";
      text = "<font:Verdana:12><color:AAAAAA>\xBB "@%date;
   };
   %content.add(%date);

   %div = new GuiSwatchCtrl()
   {
      position = "2 25";
      extent = "505 1";
      minExtent = "1 1";
      color = "255 255 255 255";
   };
   %content.add(%div);

   %div = new GuiSwatchCtrl()
   {
      position = "2 24";
      extent = "505 1";
      minExtent = "1 1";
      color = "200 200 200 255";
   };
   %content.add(%div);

   %comment = new GuiMLTextCtrl()
   {
      position = "6 31";
      extent = "500 30";
      text = "<font:Verdana:12><color:666666>"@%message;
   };
   %content.add(%comment);
   
   %comment.forceReflow();
   if((getWord(%comment.extent,1)+50) > 120)
      %container.resize(getWord(%container.position,0),getWord(%container.position,1),getWord(%container.extent,0),getWord(%comment.extent,1)+50);

   %container.vertSizing = "top";
   %container.position = "0" SPC $ORBS::CModManager::Cache::CommentContainer.getLowestPoint();
   $ORBS::CModManager::Cache::CommentContainer.add(%container);
   
   return %container;
}

//- ORBSMM_FileView_collapseComments (creates a loading window over the comments area and collapses it)
function ORBSMM_FileView_collapseComments()
{
   %container = $ORBS::CModManager::Cache::CommentContainer;
   
   %cover = new GuiSwatchCtrl()
   {
      position = %container.position;
      extent = %container.extent;
      color = "255 255 255 0";
      
      new GuiAnimatedBitmapCtrl()
      {
         vertSizing = "center";
         horizSizing = "center";
         extent = "31 31";
         bitmap = $ORBS::Path@"images/ui/animated/loadRing";
         framesPerSecond = 15;
         numFrames = 8;
      };
   };
   ORBSMM_GUI_PushControl(%cover);
   
   ORBSMM_GUI_FadeIn(%cover);
   $ORBS::CModManager::Cache::CommentCover = %cover;
   ORBSMM_FileView_sizedownComments(0,getWord(%container.extent,1),"-"@getWord(%container.extent,1)-120,100);
}

//- ORBSMM_FileView_sizedownComments (resizes the comments area to go real small)
function ORBSMM_FileView_sizedownComments(%time,%begin,%change,%duration)
{
   if(%time $= %duration)
   {
      $ORBS::CModManager::Cache::CommentCover.color = "255 255 255 255";
      $ORBS::CModManager::Cache::CommentContainer.clear();
      return;
   }
   
   %ctrl_con = $ORBS::CModManager::Cache::CommentContainer;   
   %oldExtent = getWord(%ctrl_con.extent,1);
   %newExtent = mceil(Anim_EaseInOut(%time,%begin,%change,%duration));
   %ctrl_con.resize(getWord(%ctrl_con.position,0),getWord(%ctrl_con.position,1),getWord(%ctrl_con.extent,0),%newExtent);
   %ctrl_con.expColSch = schedule(10,0,"ORBSMM_FileView_sizedownComments",%time+10,%begin,%change,%duration);
   
   %ctrl = $ORBS::CModManager::Cache::CommentFooter;
   %ctrl.position = vectorAdd(%ctrl.position,"0" SPC %newExtent-%oldExtent);
   
   %ctrl = $ORBS::CModManager::Cache::CommentCover;
   %ctrl.resize(getWord(%ctrl_con.position,0),getWord(%ctrl_con.position,1),getWord(%ctrl_con.extent,0),getWord(%ctrl_con.extent,1));
   ORBSMM_GUI_AutoResize();
}

//- ORBSMM_FileView_sizeupComments (resizes the comments area to go bigger)
function ORBSMM_FileView_sizeupComments(%time,%begin,%change,%duration)
{
   if(%time $= %duration)
   {
      $ORBS::CModManager::Cache::CommentCover.delete();
      return;
   }
   
   %ctrl = $ORBS::CModManager::Cache::CommentContainer;   
   %oldExtent = getWord(%ctrl.extent,1);
   %newExtent = mceil(Anim_EaseInOut(%time,%begin,%change,%duration));
   %ctrl.resize(getWord(%ctrl.position,0),getWord(%ctrl.position,1),getWord(%ctrl.extent,0),%newExtent);
   %ctrl.expColSch = schedule(10,0,"ORBSMM_FileView_sizeupComments",%time+10,%begin,%change,%duration);
   
   %ctrlF = $ORBS::CModManager::Cache::CommentFooter;
   %ctrlF.position = vectorAdd(%ctrl.position,"0" SPC %newExtent);
   ORBSMM_GUI_AutoResize();
}

//- Event_screenshotSelect::onMouseEnter (MouseEnter Callback)
function Event_screenshotSelect::onMouseEnter(%ctrl)
{
   %ctrl.swatch.color = "255 255 255 100";
}

//- Event_screenshotSelect::onMouseLeave (MouseLeave Callback)
function Event_screenshotSelect::onMouseLeave(%ctrl)
{
   %ctrl.swatch.color = "255 255 255 0";
}

//- Event_screenshotSelect::onMouseDown (MouseDown Callback)
function Event_screenshotSelect::onMouseDown(%ctrl)
{
   %ctrl.swatch.color = "255 255 255 150";
}

//- Event_screenshotSelect::onMouseUp (MouseUp Callback)
function Event_screenshotSelect::onMouseUp(%ctrl)
{
   %ctrl.swatch.color = "255 255 255 100";
   ORBSMM_FileView_ShowScreenshot(%ctrl.screenID,%ctrl.screenCaption);
}

//- ORBSMM_FileView_Download (Downloads the file)
function ORBSMM_FileView_Download()
{
   %file_id = $ORBS::CModManager::Cache::CurrentFile;
   ORBSMM_TransferQueue.addItem(%file_id);
}

//- ORBSMM_FileView_Rate (Opens a window to submit a rating for a file)
function ORBSMM_FileView_Rate()
{
   %window = ORBSMM_GUI_createWindow("Rate");
   %window.resize(0,0,200,80);
   ORBSMM_GUI_Center(%window);
   
   %swatch = new GuiSwatchCtrl()
   {
      position = "0 8";
      color = "0 0 0 0";
      extent = "16 16";
   };
   
   %mlTextCtrl = new GuiMLTextCtrl()
   {
      position = "0 28";
      extent = "200";
      text = "<just:center><font:Arial:12><color:AAAAAA>Click a star to rate";
   };
   %window.canvas.add(%mlTextCtrl);
   %mlTextCtrl.forceReflow();
   ORBSMM_GUI_CenterHoriz(%mlTextCtrl);
   
   $ORBS::CModManager::Cache::RatingText = %mlTextCtrl;
   
   for(%i=0;%i<5;%i++)
   {
      %star = new GuiBitmapCtrl()
      {
         position = (20*%i) SPC 0;
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/star0";
      };
      %swatch.add(%star);
      %swatch.extent = getWord(%star.position,0)+16;
      
      %mouseEvent = new GuiMouseEventCtrl()
      {
         position = vectorSub(%star.position,"2 2");
         extent = "20 20";
         
         eventType = "rateStarSelect";
         eventCallbacks = "1101000";
         
         text = %mlTextCtrl;
         id = %i+1;
         starSwatch = %swatch;
      };
      %swatch.add(%mouseEvent);
   }
   %window.canvas.add(%swatch);
   
   ORBSMM_GUI_CenterHoriz(%swatch);
}

//- Event_rateStarSelect::onMouseEnter (MouseEnter Callback)
function Event_rateStarSelect::onMouseEnter(%ctrl)
{
   %swatch = %ctrl.starSwatch;
   
   for(%i=0;%i<%swatch.getCount();%i++)
   {
      if(%swatch.getObject(%i).getClassName() !$= "GuiBitmapCtrl")
         continue;
         
      if(%numDone $= %ctrl.id)
         break;
      
      %numDone++;
      %swatch.getObject(%i).setBitmap($ORBS::Path@"images/icons/star4");
   }
}

//- Event_rateStarSelect::onMouseLeave (MouseLeave Callback)
function Event_rateStarSelect::onMouseLeave(%ctrl)
{
   %swatch = %ctrl.starSwatch;
   
   for(%i=0;%i<%swatch.getCount();%i++)
   {
      if(%swatch.getObject(%i).getClassName() !$= "GuiBitmapCtrl")
         continue;

      %swatch.getObject(%i).setBitmap($ORBS::Path@"images/icons/star0");
   }
}

//- Event_rateStarSelect::onMouseUp (MouseUp Callback)
function Event_rateStarSelect::onMouseUp(%ctrl)
{
   %swatch = %ctrl.starSwatch;
   
   for(%i=0;%i<%swatch.getCount();%i++)
   {
      if(%swatch.getObject(%i).getClassName() !$= "GuiBitmapCtrl")
         continue;

      if(%numDone $= %ctrl.id)
         break;
      
      %numDone++;
      %swatch.getObject(%i).setBitmap($ORBS::Path@"images/icons/starS");
   }
   %ctrl.text.setValue("<just:center><font:Arial:12><color:AAAAAA>Submitting your rating of "@%ctrl.id@"...");
   
   ORBSMM_SendRequest("ADDRATING",3,$ORBS::CModManager::Cache::CurrentFile,%ctrl.id);
   
   for(%i=0;%i<%swatch.getCount();%i++)
   {
      if(%swatch.getObject(%i).getClassName() !$= "GuiBitmapCtrl")
      {
         %swatch.getObject(%i).delete();
         %i--;
      }
   }
}

//- ORBSMM_FileView_onRatingReply (Reply from server when submitting a rating)
ORBSMM_TCPManager.registerResponseHandler("ADDRATING","ORBSMM_FileView_onRatingReply");
function ORBSMM_FileView_onRatingReply(%tcp,%line)
{
   %text = $ORBS::CModManager::Cache::RatingText;
   %success = getField(%line,0);
   if(%success)
   {
      %swatch = $ORBS::CModManager::Cache::FileRatingSwatch;
      if(isObject(%swatch))
      {
         %rating = getSubStr(getField(%line,2),0,5);
         %rating = ORBSMM_GUI_createRatingSwatch(%rating);
         %swatch.getGroup().add(%rating);
         ORBSMM_GUI_CenterVert(%rating);
         %swatch.delete();
         
         $ORBS::CModManager::Cache::FileRatingSwatch = %rating;
         
         %numRatings = getSubStr(getField(%line,2),6,strLen(getField(%line,2)));
         %s = (%numRatings == 1) ? "" : "s";
         
         $ORBS::CModManager::Cache::FileRatingText.setValue("<just:left><font:Arial:12><color:AAAAAA>"@%numRatings@" rating"@%s);
      }

      if(isObject(%text))
      {
         %update = getField(%line,1);
         if(%update $= 2)
            %text.setValue("<just:center><font:Arial:12><color:AAAAAA>Your rating has been changed. Thanks!");
         else
            %text.setValue("<just:center><font:Arial:12><color:AAAAAA>Your rating has been saved. Thanks!");
      }
   }
   else
   {
      if(!isObject(%text))
         return;
         
      %error = getField(%line,1);
      if(%error $= 1)
         %text.setValue("<just:center><font:Arial:12><color:AAAAAA>You are not logged in!");
      else if(%error $= 2)
         %text.setValue("<just:center><font:Arial:12><color:AAAAAA>File not found!");
      else if(%error $= 3)
         %text.setValue("<just:center><font:Arial:12><color:AAAAAA>You can't rate your own stuff!");
   }
}

//- ORBSMM_FileView_showScreenshot (Opens a window to show an enlarged screenshot)
function ORBSMM_FileView_showScreenshot(%id,%captionText)
{
   %window = ORBSMM_GUI_createWindow("Screenshot");
   %window.resize(0,0,500,435);
   ORBSMM_GUI_Center(%window);
   
   %img = new GuiBitmapCtrl()
   {
      extent = "500 379";
      bitmap = "";
      visible = 0;
   };
   %window.canvas.add(%img);
   
   %div = new GuiSwatchCtrl()
   {
      position = "0 379";
      extent = "500 3";
      color = "189 192 195 255";
   };
   %window.canvas.add(%div);
   
   %caption = new GuiMLTextCtrl()
   {
      position = "4 385";
      extent = "800 14";
      text = "<color:777777><font:Verdana:12>"@%captionText;
   };
   %window.canvas.add(%caption);
   
   %loading = new GuiAnimatedBitmapCtrl()
   {
      extent = "31 31";
      bitmap = $ORBS::Path@"images/ui/animated/loadRing";
      framesPerSecond = 15;
      numFrames = 8;
   };
   %window.canvas.add(%loading);
   ORBSMM_GUI_Center(%loading);
   
   %url = "/forum/downloads/"@$ORBS::CModManager::Cache::ScreenURL[%id]@".png";
   ORBSMM_ScreenGrabber.getScreenshot(%url,%window);
}

//- ORBSMM_FileView_Report (Opens a form to allow the user to report the file to Mod Reviewers)
function ORBSMM_FileView_Report(%id)
{
   if(%id $= "")
      %id = $ORBS::CModManager::Cache::CurrentFile;
   if(%id $= "")
      %id = 0;
      
   %window = ORBSMM_GUI_createWindow("Report File");
   %window.resize(0,0,400,230);
   ORBSMM_GUI_Center(%window);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 12";
      extent = "";
      text = "<font:Verdana:12><color:555555>Reason:";
   };
   %window.canvas.add(%label);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_Report_Reason)
   {
      profile = ORBS_PopupProfile;
      position = "54 9";
      extent = "130 17";
   };
   %window.canvas.add(%popup);
   %popup.add("Stolen",1);
   %popup.add("Abusive",2);
   %popup.add("Doesn't Work",3);
   %popup.add("Breaks Stuff",4);
   %popup.add("Contains Exploits",5);
   %popup.add("Other",6);
   %popup.setSelected(1);
   
   %label = new GuiMLTextCtrl()
   {
      position = "202 12";
      extent = "";
      text = "<font:Verdana:12><color:555555>Severity:";
   };
   %window.canvas.add(%label);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_Report_Severity)
   {
      profile = ORBS_PopupProfile;
      position = "252 9";
      extent = "130 17";
   };
   %window.canvas.add(%popup);
   %popup.add("Normal",1);
   %popup.add("High",2);
   %popup.add("Critical",3);
   %popup.setSelected(1);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 40";
      extent = "";
      text = "<font:Verdana:12><color:555555>Summary:";
   };
   %window.canvas.add(%label);
   $ORBS::CModManager::Cache::Report::Summary = %label;
   
   %textedit = new GuiTextEditCtrl(ORBSMM_Report_Summary)
   {
      profile = ORBS_TextEditProfile;
      position = "66 38";
      extent = "316 16";
   };
   %window.canvas.add(%textedit);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 64";
      extent = "";
      text = "<font:Verdana:12><color:555555>Description:";
   };
   %window.canvas.add(%label);
   $ORBS::CModManager::Cache::Report::Description = %label;
   
   %textedit = new GuiScrollCtrl()
   {
      profile = ORBS_TextEditProfile;
      position = "9 82";
      extent = "373 73";
      hScrollBar = "alwaysOff";
      vScrollBar = "alwaysOff";
      
      new GuiMLTextEditCtrl(ORBSMM_Report_Description)
      {
         profile = ORBS_MLEditProfile;
         position = "3 1";
         extent = "364 73";
      };
   };
   %window.canvas.add(%textedit);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "324 163";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = "ORBSMM_FileView_SendReport("@%window@","@%id@");";
   };
   %window.canvas.add(%button);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "260 163";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/cancel";
      command = %window.closeButton.command;
   };
   %window.canvas.add(%button);
   
   %buglink = new GuiMLTextCtrl()
   {
      profile = "ORBSMM_NewsContentProfile";
      position = "12 170";
      extent = "236 12";
      text = "<color:AAAAAA>Warning: Abuse will result in a ban.";
   };
   %window.canvas.add(%buglink);
}

//- ORBSMM_FileView_SendReport (Processes + Sends the File Report)
function ORBSMM_FileView_SendReport(%window,%id)
{
   if(ORBSMM_Report_Summary.getValue() $= "")
   {
      $ORBS::CModManager::Cache::Report::Summary.setValue("<font:Verdana Bold:12><color:EE0000>Summary:");
      %errors = 1;
   }
   else
      $ORBS::CModManager::Cache::Report::Summary.setValue("<font:Verdana:12><color:555555>Summary:");

   if(ORBSMM_Report_Description.getValue() $= "")
   {   
      $ORBS::CModManager::Cache::Report::Description.setValue("<font:Verdana Bold:12><color:EE0000>Description:");
      %errors = 1;
   }
   else
      $ORBS::CModManager::Cache::Report::Description.setValue("<font:Verdana:12><color:555555>Description:");
   
   if(%errors)
      return;
   
   %overlay = new GuiSwatchCtrl()
   {
      position = "0 0";
      extent = %window.canvas.extent;
      color = "255 255 255 200";
   };
   %window.canvas.add(%overlay);
   
   %bitmap = new GuiAnimatedBitmapCtrl()
   {
      extent = "31 31";
      bitmap = $ORBS::Path@"images/ui/animated/loadRing";
      framesPerSecond = 15;
      numFrames = 8;
   };
   %overlay.add(%bitmap);
   ORBSMM_GUI_Center(%bitmap);
   %bitmap.shift(0,-10);
   
   %mlCtrl = new GuiMLTextCtrl()
   {
      extent = "200 0";
      text = "<just:center><font:Verdana:12><color:666666>Sending Report...";
   };
   %overlay.add(%mlCtrl);
   ORBSMM_GUI_Center(%mlCtrl);
   %mlCtrl.shift(0,12);
   
   $ORBS::CModManager::Cache::LoadRing = %bitmap;
   $ORBS::CModManager::Cache::LoadText = %mlCtrl;
   
   ORBSMM_SendRequest("SENDREPORT",3,%id,ORBSMM_Report_Reason.getSelected(),ORBSMM_Report_Severity.getSelected(),ORBSMM_Report_Summary.getValue(),ORBSMM_Report_Description.getValue());
}

//- ORBSMM_FileView_onReportReply (Reply from sending a report)
ORBSMM_TCPManager.registerResponseHandler("SENDREPORT","ORBSMM_FileView_onReportReply");
function ORBSMM_FileView_onReportReply(%tcp,%line)
{
   ORBSMM_GUI_LoadRing_Clear($ORBS::CModManager::Cache::LoadRing);
   if(getField(%line,0) $= 1)
   {
      $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Your report has been received.");
   }
   else
   {
      $ORBS::CModManager::Cache::LoadRing.setBitmap($ORBS::Path@"images/ui/animated/loadRing_fail");
      if(getField(%line,1) $= 1)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>You are not logged in!");
      else if(getField(%line,1) $= 2)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>File not found.");
      else
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Unknown Error Occurred.");
   }
}

//- ORBSMM_FileView_onReportFail (Fail result from sending a report)
ORBSMM_TCPManager.registerFailHandler("SENDREPORT","ORBSMM_FileView_onReportFail");
function ORBSMM_FileView_onReportFail(%tcp,%fail)
{
   ORBSMM_GUI_LoadRing_Clear($ORBS::CModManager::Cache::LoadRing);
   $ORBS::CModManager::Cache::LoadRing.setBitmap($ORBS::Path@"images/ui/animated/loadRing_fail");
   $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Connection Failed. Please try again later.");
}

//- ORBSMM_FileView_ReportBug (Opens a form to allow the user to report a bug)
function ORBSMM_FileView_ReportBug(%id)
{
   if(%id $= "")
      %id = $ORBS::CModManager::Cache::CurrentFile;
   if(%id $= "")
      %id = 0;
      
   %window = ORBSMM_GUI_createWindow("Report Bug");
   %window.resize(0,0,400,230);
   ORBSMM_GUI_Center(%window);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 12";
      extent = "";
      text = "<font:Verdana:12><color:555555>Reason:";
   };
   %window.canvas.add(%label);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_Report_Reason)
   {
      profile = ORBS_PopupProfile;
      position = "54 9";
      extent = "130 17";
   };
   %window.canvas.add(%popup);
   %popup.add("Stolen",1);
   %popup.add("Abusive",2);
   %popup.add("Doesn't Work",3);
   %popup.add("Breaks Stuff",4);
   %popup.add("Contains Exploits",5);
   %popup.add("Other",6);
   %popup.setSelected(1);
   
   %label = new GuiMLTextCtrl()
   {
      position = "202 12";
      extent = "";
      text = "<font:Verdana:12><color:555555>Severity:";
   };
   %window.canvas.add(%label);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_Report_Severity)
   {
      profile = ORBS_PopupProfile;
      position = "252 9";
      extent = "130 17";
   };
   %window.canvas.add(%popup);
   %popup.add("Low",0);
   %popup.add("Medium",1);
   %popup.add("High",2);
   %popup.setSelected(0);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 40";
      extent = "";
      text = "<font:Verdana:12><color:555555>Summary:";
   };
   %window.canvas.add(%label);
   $ORBS::CModManager::Cache::Report::Summary = %label;
   
   %textedit = new GuiTextEditCtrl(ORBSMM_Report_Summary)
   {
      profile = ORBS_TextEditProfile;
      position = "66 38";
      extent = "316 16";
   };
   %window.canvas.add(%textedit);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 64";
      extent = "";
      text = "<font:Verdana:12><color:555555>Description:";
   };
   %window.canvas.add(%label);
   $ORBS::CModManager::Cache::Report::Description = %label;
   
   %textedit = new GuiScrollCtrl()
   {
      profile = ORBS_TextEditProfile;
      position = "9 82";
      extent = "373 73";
      hScrollBar = "alwaysOff";
      vScrollBar = "alwaysOff";
      
      new GuiMLTextEditCtrl(ORBSMM_Report_Description)
      {
         profile = ORBS_MLEditProfile;
         position = "3 1";
         extent = "364 73";
      };
   };
   %window.canvas.add(%textedit);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "324 163";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = "ORBSMM_FileView_SendReport("@%window@","@%id@");";
   };
   %window.canvas.add(%button);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "260 163";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/cancel";
      command = %window.closeButton.command;
   };
   %window.canvas.add(%button);
   
   %buglink = new GuiMLTextCtrl()
   {
      profile = "ORBSMM_NewsContentProfile";
      position = "12 170";
      extent = "236 12";
      text = "<a:repoorbsug>Click here to report a bug instead</a>";
   };
   %window.canvas.add(%buglink);
}

//- ORBSMM_FileView_Screenshots (Opens a bigger version of the screenshot viewer to browse them all)
function ORBSMM_FileView_ShowScreenshots(%selector)
{
   %window = ORBSMM_GUI_createWindow("Screenshots");
   %window.resize(0,0,500,375);
   ORBSMM_GUI_Center(%window);
   
   %img = new GuiBitmapCtrl()
   {
      extent = %window.canvas.extent;
      bitmap = "screenshots/BLPetrol";
   };
   %window.canvas.add(%img);
}

//- ORBSMM_FileView_onFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETFILE","ORBSMM_FileView_onFail");
function ORBSMM_FileView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* Packs View
//*********************************************************
//- ORBSMM_PacksView_Init (Entrance)
function ORBSMM_PacksView_Init()
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETPACKS",1);
   ORBSMM_Zones_Track("PacksView","ORBSMM_PacksView_Init();");
}

//- ORBSMM_PacksView_onReplyStart (Reply Start)
function ORBSMM_PacksView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
   ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  Content Packs");
   ORBSMM_GUI_createSplitHeader(1,58,"Pack",17,"Date",10,"Items",15,"Download");
}

//- ORBSMM_PacksView_onReplyStop (Stop Reply)
function ORBSMM_PacksView_onReplyStop(%tcp)
{
   ORBSMM_GUI_createHeader(2," ");
}

//- ORBSMM_PacksView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETPACKS","ORBSMM_PacksView_onReply");
function ORBSMM_PacksView_onReply(%tcp,%line,%arg1,%arg2,%arg3,%arg4,%arg5,%arg6,%arg7)
{
   if(%arg1 $= "PACK")
   {
      %container = ORBSMM_GUI_createContent(1,50,6,52,17,10,15);
      
      %c_icon = %container.getObject(0);
      %c_information = %container.getObject(1);
      %c_date = %container.getObject(2);
      %c_items = %container.getObject(3);
      %c_download = %container.getObject(4);
      
      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_icon.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_icon.add(%swatch);
      %icon = new GuiBitmapCtrl()
      {
         vertSizing = "center";
         position = "0 0";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/"@%arg4;
      };
      %c_icon.add(%icon);
      ORBSMM_GUI_Center(%icon);

      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_information.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_information.add(%swatch);
      %text = new GuiMLTextCtrl()
      {
         position = "1 3";
         extent = "327 18";
         text = "<font:Arial Bold:15><color:888888> "@%arg3;
      };
      %c_information.add(%text);
      
      %mltext = new GuiMLTextCtrl()
      {
         position = "3 18";
         extent = "325 18";
         text = "<font:Verdana:12><color:444444>"@%arg5;
      };
      %c_information.add(%mltext);
      
      %mltext.forceReflow();
      %extent = getWord(%mltext.extent,1);
      %container.resize(getWord(%container.position,0),getWord(%container.position,1),getWord(%container.extent,0),%extent+36);
      ORBSMM_GUI_AutoResize();

      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_date.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_date.add(%swatch);
      %text = new GuiMLTextCtrl()
      {
         position = "0 7";
         extent = 200 SPC 18;
         text = "<just:center><font:Verdana:12><color:888888>"@%arg6;
      };
      %c_date.add(%text);
      %text.forceReflow();
      ORBSMM_GUI_Center(%text);
      
      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_items.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_items.add(%swatch);
      %text = new GuiMLTextCtrl()
      {
         position = "0 7";
         extent = 150 SPC 18;
         text = "<just:center><font:Verdana:12><color:888888>"@%arg7;
      };
      %c_items.add(%text);
      %text.forceReflow();
      ORBSMM_GUI_Center(%text);
      
      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_download.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_download.add(%swatch);
      %button = new GuiBitmapButtonCtrl()
      {
         position = "0 0";
         extent = 82 SPC 25;
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/download";
         command = "ORBSMM_GUI_createMessageBoxOK(\"Damn It\",\"I haven't actually got around to making this work yet, it's a lot of effort. Can we pretend this never happened?\");";
      };
      %c_download.add(%button);
      ORBSMM_GUI_Center(%button);
      
      %mouseCtrl = new GuiMouseEventCtrl()
      {
         position = %container.position;
         extent = vectorSub(%container.extent,getWord(%c_download.extent,0) SPC "0");
         
         eventType = "packSelect";
         eventCallbacks = "1111000";
         
         packID = %arg2;
         container = %container;
      };
      ORBSMM_GUI_PushControl(%mouseCtrl,1);
   }
}

//- Event_packSelect::onMouseEnter (MouseEnter Callback)
function Event_packSelect::onMouseEnter(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.visible = 1;
   }
}

//- Event_packSelect::onMouseLeave (MouseLeave Callback)
function Event_packSelect::onMouseLeave(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.visible = 0;
      %swatch.color = "255 255 255 100";
   }
}

//- Event_packSelect::onMouseDown (MouseDown Callback)
function Event_packSelect::onMouseDown(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.color = "255 230 230 150";
   }
}

//- Event_packSelect::onMouseUp (MouseUp Callback)
function Event_packSelect::onMouseUp(%ctrl)
{
   %container = %ctrl.container;
   for(%i=0;%i<%container.getCount();%i++)
   {
      %parent = %container.getObject(%i);
      %swatch = %parent.getObject(0);
      %swatch.color = "255 255 255 100";
   }   
   ORBSMM_PackView_Init(%ctrl.packID);
}

//- ORBSMM_PacksView_onFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETPACKS","ORBSMM_PacksView_onFail");
function ORBSMM_PacksView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* Packs View
//*********************************************************
//- ORBSMM_PacksView_Init (Entrance)
function ORBSMM_PackView_Init(%id)
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETPACK",1,%id);
   ORBSMM_Zones_Track("PackView","ORBSMM_PackView_Init("@%id@");");
   
   $ORBS::CModManager::Cache::TotalItems = 0;
   $ORBS::CModManager::Cache::ItemsSelected = 0;
}

//- ORBSMM_PackView_onReplyStart (Reply Start)
function ORBSMM_PackView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
}

//- ORBSMM_PackView_onReplyStop (Reply stop)
function ORBSMM_PackView_onReplyStop(%tcp)
{
   ORBSMM_GUI_createHeader(2," ");
}

//- ORBSMM_PackView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETPACK","ORBSMM_PackView_onReply");
function ORBSMM_PackView_onReply(%tcp,%line,%arg1,%arg2,%arg3,%arg4,%arg5,%arg6,%arg7,%arg8,%arg9,%arg10,%arg11)
{
   if(%arg1 $= "HEADER")
   {
      ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  "@%arg2);
      if($ORBS::CModManager::Cache::PackName $= "")
         $ORBS::CModManager::Cache::PackName = %arg2;
   }
   else if(%arg1 $= "SPLITHEADER")
   {
      ORBSMM_GUI_createSplitHeader(1,66,"File",15,"Rating",14,"Downloads",5," ");
   }
   else if(%arg1 $= "FOOTER")
   {
      ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  Download Pack");
      %message = ORBSMM_GUI_createMessage("<br><spush><font:Verdana Bold:12>You can download all the files in this pack by clicking the download button below.<spop><br>You can tick/untick files on the right to pick which ones you want to download.<br><br><br><br><br>");
      
      %downloadButton = new GuiBitmapButtonCtrl()
      {
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/download";
         command = "ORBSMM_PackView_Download();";
      };
      %message.add(%downloadButton);
      ORBSMM_GUI_Center(%downloadButton);
      %downloadButton.shift(0,26);
      
      %itemCount = new GuiMLTextCtrl()
      {
         text = "<color:BBBBBB><font:Arial:12><just:center>"@$ORBS::CModManager::Cache::ItemsSelected@" items";
      };
      %message.add(%itemCount);
      ORBSMM_GUI_Center(%itemCount);
      %itemCount.shift(0,32);
      
      $ORBS::CModManager::Cache::ItemCounter = %itemCount;
   }
   else if(%arg1 $= "INFO")
   {
      %info = ORBSMM_GUI_createContent(1,30,20,80);
      %label = %info.getObject(0);
      %content = %info.getObject(1);
      
      %label_txt = new GuiMLTextCtrl()
      {
         position = "6 7";
         extent = "128 30";
         text = "<font:Arial Bold:15><color:444444>"@%arg2;
      };
      %label.add(%label_txt);
      
      %content_txt = new GuiMLTextCtrl()
      {
         position = "6 9";
         extent = "530 30";
         text = "<font:Verdana:12><color:666666>"@%arg3;
      };
      %content.add(%content_txt);
      %content_txt.forceReflow();
      %extent = getWord(%content_txt.extent,1);
      %info.resize(getWord(%info.position,0),getWord(%info.position,1),getWord(%info.extent,0),%extent+18);
      ORBSMM_GUI_AutoResize();
   }
   else if(%arg1 $= "PACK")
   {
      %container = ORBSMM_GUI_createContent(1,50,6,60,15,14,5);
      
      %c_icon = %container.getObject(0);
      %c_information = %container.getObject(1);
      %c_rating = %container.getObject(2);
      %c_downloads = %container.getObject(3);
      %c_toggle = %container.getObject(4);
      
      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_icon.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_icon.add(%swatch);
      %icon = new GuiBitmapCtrl()
      {
         vertSizing = "center";
         position = "0 0";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/"@%arg3;
      };
      %c_icon.add(%icon);
      if(ORBSMM_FileCache.get(%arg2))
      {
         %star = new GuiBitmapCtrl()
         {
            position = "24 -2";
            extent = "16 16";
            bitmap = $ORBS::Path@"images/icons/bullet_star";
         };
         %c_icon.add(%star);
      }
      ORBSMM_GUI_Center(%icon);

      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_information.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_information.add(%swatch);
      %text = new GuiMLTextCtrl()
      {
         position = "1 3";
         extent = "376 18";
         text = "<font:Arial Bold:15><color:888888> "@%arg4;
      };
      %c_information.add(%text);
      %text = new GuiMLTextCtrl()
      {
         vertSizing = "top";
         position = "3 32";
         extent = "325 18";
         text = "<font:Verdana:12><color:666666>\xBB <color:888888>By "@%arg6;
      };
      %c_information.add(%text);
      
      %mltext = new GuiMLTextCtrl()
      {
         position = "3 18";
         extent = "376 18";
         text = "<font:Verdana:12><color:444444>"@%arg5;
      };
      %c_information.add(%mltext);
      
      %mltext.forceReflow();
      %extent = getWord(%mltext.extent,1);
      %container.resize(getWord(%container.position,0),getWord(%container.position,1),getWord(%container.extent,0),%extent+36);
      ORBSMM_GUI_AutoResize();
      
      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_rating.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_rating.add(%swatch);
      %rating_swatch = ORBSMM_GUI_createRatingSwatch(%arg8);
      %c_rating.add(%rating_swatch);
      ORBSMM_GUI_Center(%rating_swatch);
      
      %swatch = new GuiSwatchCtrl()
      {
         vertSizing = "height";
         position = "0 0";
         extent = %c_downloads.extent;
         color = "255 255 255 100";
         visible = 0;
      };
      %c_downloads.add(%swatch);
      %text = new GuiMLTextCtrl()
      {
         position = "0 7";
         extent = 150 SPC 18;
         text = "<just:center><font:Verdana:12><color:888888>"@%arg9;
      };
      %c_downloads.add(%text);
      %text.forceReflow();
      ORBSMM_GUI_Center(%text);
      
      %mouseCtrl = new GuiMouseEventCtrl()
      {
         position = %container.position;
         extent = 646 SPC restWords(%container.extent);
         
         eventType = "fileSelect";
         eventCallbacks = "1111000";
         
         persistent = 1;         
         
         recurseHover = 4;         
         
         fileID = %arg2;
         container = %container;
      };
      ORBSMM_GUI_PushControl(%mouseCtrl,1);
      
      %downloadBtn = new GuiBitmapButtonCtrl()
      {
         position = "430 1";
         extent = "16 16";
         visible = 0;
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/downloadSmall";
         text = " ";
         command = "ORBSMM_TransferView_Add("@%arg2@");";
      };
      %mouseCtrl.add(%downloadBtn);
      %container.dlIcon = %downloadBtn;
      
      %reportBtn = new GuiBitmapButtonCtrl()
      {
         position = "430" SPC getWord(%mouseCtrl.extent,1)-19;
         extent = "16 16";
         visible = 0;
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/reportSmall";
         text = " ";
         command = "ORBSMM_FileView_Report("@%arg2@");";
      };
      %mouseCtrl.add(%reportBtn);
      %container.rpIcon = %reportBtn;
      
      %checkbox = new GuiCheckboxCtrl()
      {
         profile = ORBS_CheckBoxProfile;
         position = "9 0";
         extent = "138 50";
         text = "";
      };
      %c_toggle.add(%checkbox);
      ORBSMM_GUI_CenterVert(%checkbox);
      %checkbox.command = "ORBSMM_PackView_clickCheckbox("@%checkbox@","@$ORBS::CModManager::Cache::TotalItems@");";

      $ORBS::CModManager::Cache::Item[$ORBS::CModManager::Cache::TotalItems] = %arg2;
      
      if(%arg10 !$= ORBSMM_FileCache.get(%arg2).file_version || !ORBSMM_FileCache.get(%arg2))
      {
         %checkbox.setValue(1);
         $ORBS::CModManager::Cache::ItemDL[$ORBS::CModManager::Cache::TotalItems] = 1;
         $ORBS::CModManager::Cache::ItemsSelected++;
      }
      $ORBS::CModManager::Cache::TotalItems++;
   }
}

//- ORBSMM_PackView_clickCheckbox (Handles selections for pack downloading)
function ORBSMM_PackView_clickCheckbox(%checkbox,%id)
{
   if(%checkbox.getValue() $= 0)
   {
      $ORBS::CModManager::Cache::ItemsSelected--;
      $ORBS::CModManager::Cache::ItemDL[%id] = 0;
   }
   else
   {
      $ORBS::CModManager::Cache::ItemsSelected++;
      $ORBS::CModManager::Cache::ItemDL[%id] = 1;
   }
   
   %s = ($ORBS::CModManager::Cache::ItemsSelected == 1)?"":"s";
   $ORBS::CModManager::Cache::ItemCounter.setValue("<color:BBBBBB><font:Arial:12><just:center>"@$ORBS::CModManager::Cache::ItemsSelected@" item"@%s);
}

//- ORBSMM_PackView_Download (Download selected items in this pack)
function ORBSMM_PackView_Download()
{
   if($ORBS::CModManager::Cache::ItemsSelected <= 0)
   {
      ORBSMM_GUI_createMessageBoxOK("Hmm?","You should probably atleast tick ONE file to download!");
      return;
   }

   if(ORBSMM_GroupManager.hasGroup($ORBS::CModManager::Cache::PackName))
      ORBSMM_GroupManager.deleteGroup($ORBS::CModManager::Cache::PackName);
   %group = ORBSMM_ModsView_createGroup($ORBS::CModManager::Cache::PackName,1);
   for(%i=0;%i<$ORBS::CModManager::Cache::TotalItems;%i++)
   {
      if($ORBS::CModManager::Cache::ItemDL[%i])
      {
         ORBSMM_TransferQueue.addItem($ORBS::CModManager::Cache::Item[%i],0,%group);
      }
   }
}

//- ORBSMM_PackView_onFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETPACK","ORBSMM_PackView_onFail");
function ORBSMM_PackView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* Top List View
//*********************************************************
//- ORBSMM_TopListView_Init (Entrance)
function ORBSMM_TopListView_Init()
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETTOPLIST",1);
   ORBSMM_Zones_Track("TopListView","ORBSMM_TopListView_Init();");
}

//- ORBSMM_TopListView_onReplyStart (Reply Start)
function ORBSMM_TopListView_onReplyStart(%tcp)
{
   ORBSMM_SectionView_onReplyStart(%tcp);
}

//- ORBSMM_TopListView_onReplyStop (Reply Stop)
function ORBSMM_TopListView_onReplyStop(%tcp)
{
   ORBSMM_GUI_createFooter("cell2");
}

//- ORBSMM_TopListView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETTOPLIST","ORBSMM_TopListView_onReply");
function ORBSMM_TopListView_onReply(%tcp,%line)
{
   ORBSMM_SectionView_onReply(%tcp,%line);
}

//- ORBSMM_TopListView_onFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETTOPLISt","ORBSMM_TopListView_onFail");
function ORBSMM_TopListView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* Search View
//*********************************************************
//- ORBSMM_SearchView_Init (Entrance)
function ORBSMM_SearchView_Init()
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETSEARCH",1);
   ORBSMM_Zones_Track("SearchView","ORBSMM_SearchView_Init();");
}

//- ORBSMM_SearchView_onReplyStart (Reply Start)
function ORBSMM_SearchView_onReplyStart(%tcp)
{
   ORBSMM_GUI_Init();
   
   ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  Search Query");
   %content = ORBSMM_GUI_createContent(1,40,30,70);

   %mlText = new GuiMLTextCtrl()
   {
      extent = "200 25";
      text = "<font:Verdana Bold:13><color:444444>Keywords:<br><font:Verdana:12>Enter a keyword to search for.";
   };
   %content.getObject(0).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(3,0);
   
   %textEdit = new GuiTextEditCtrl(ORBSMM_SearchView_Keyword)
   {
      profile = "ORBS_TextEditProfile";
      extent = "200 20";
      altCommand = "ORBSMM_SearchView_doSearch();";
   };
   %content.getObject(1).add(%textEdit);
   ORBSMM_GUI_CenterVert(%textEdit);
   %textEdit.shift(10,0);
   %textEdit.schedule(1,"makeFirstResponder",1);
   
   %content = ORBSMM_GUI_createContent(1,40,30,70);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "200 25";
      text = "<font:Verdana Bold:13><color:444444>Author:<br><font:Verdana:12>Enter a username to search for.";
   };
   %content.getObject(0).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(3,0);
   
   %textEdit = new GuiTextEditCtrl(ORBSMM_SearchView_Author)
   {
      profile = "ORBS_TextEditProfile";
      extent = "200 20";
      altCommand = "ORBSMM_SearchView_doSearch();";
   };
   %content.getObject(1).add(%textEdit);
   ORBSMM_GUI_CenterVert(%textEdit);
   %textEdit.shift(10,0);
   
   ORBSMM_GUI_createSplitHeader(2,"100","<color:FAFAFA><just:left><font:Impact:18>  Search Options");
   
   %content = ORBSMM_GUI_createContent(1,40,25,25,25,25);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "165 25";
      text = "<font:Verdana Bold:13><color:444444>Section:<br><font:Verdana:12>Select a section to search in.";
   };
   %content.getObject(0).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(3,0);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_SearchView_Section)
   {
      profile = "ORBS_PopupProfile";
      extent = "140 17";
   };
   %content.getObject(1).add(%popup);
   ORBSMM_GUI_Center(%popup);
   %popup.add("All",999);
   %popup.setSelected(999);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "165 25";
      text = "<font:Verdana Bold:13><color:444444>Search Alternatives:<br><font:Verdana:12>Search different fields.";
   };
   %content.getObject(2).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(3,0);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "165 25";
      text = "<font:Verdana:12><color:444444>Search Summary";
   };
   %content.getObject(3).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(25,-2);
   
   %checkbox = new GuiCheckboxCtrl(ORBSMM_SearchView_SearchSummary)
   {
      profile = "ORBS_CheckBoxProfile";
      extent = "140 16";
      text = "";
   };
   %content.getObject(3).add(%checkbox);
   ORBSMM_GUI_Center(%checkbox);
   %checkbox.shift(-5,-8);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "165 25";
      text = "<font:Verdana:12><color:444444>Search Description";
   };
   %content.getObject(3).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(25,14);
   
   %checkbox = new GuiCheckboxCtrl(ORBSMM_SearchView_SearchDescription)
   {
      profile = "ORBS_CheckBoxProfile";
      extent = "140 16";
      text = "";
   };
   %content.getObject(3).add(%checkbox);
   ORBSMM_GUI_Center(%checkbox);
   %checkbox.shift(-5,8);
   
   %content = ORBSMM_GUI_createContent(1,40,25,25,25,25);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "165 25";
      text = "<font:Verdana Bold:13><color:444444>Category:<br><font:Verdana:12>Select a category to search in.";
   };
   %content.getObject(0).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(3,0);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_SearchView_Category)
   {
      profile = "ORBS_PopupProfile";
      extent = "140 17";
   };
   %content.getObject(1).add(%popup);
   ORBSMM_GUI_Center(%popup);
   %popup.add("All",999);
   %popup.setSelected(999);
   
   %mlText = new GuiMLTextCtrl()
   {
      extent = "165 25";
      text = "<font:Verdana Bold:13><color:444444>Sort by:<br><font:Verdana:12>Sort your results.";
   };
   %content.getObject(2).add(%mlText);
   ORBSMM_GUI_Center(%mlText);
   %mlText.shift(3,0);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_SearchView_SortBy)
   {
      profile = "ORBS_PopupProfile";
      extent = "70 17";
   };
   %content.getObject(3).add(%popup);
   ORBSMM_GUI_Center(%popup);
   %popup.shift(-40,0);
   %popup.add("Name",0);
   %popup.add("Downloads",1);
   %popup.add("Rating",2);
   %popup.add("Submit Date",3);
   %popup.setSelected(0);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_SearchView_SortDir)
   {
      profile = "ORBS_PopupProfile";
      extent = "70 17";
   };
   %content.getObject(3).add(%popup);
   ORBSMM_GUI_Center(%popup);
   %popup.shift(40,0);
   %popup.add("Ascending",0);
   %popup.add("Descending",1);
   %popup.setSelected(0);
   
   %content = ORBSMM_GUI_createContent(1,60,100);
   
   %button = new GuiBitmapButtonCtrl()
   {
      extent = "82 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/search";
      command = "ORBSMM_SearchView_DoSearch();";
   };
   %content.getObject(0).add(%button);
   ORBSMM_GUI_Center(%button);
   
   ORBSMM_GUI_createSplitHeader("cell1","100"," ");
}

function ORBSMM_SearchView_Category::onSelect(%this,%id,%name)
{
   %selection = ORBSMM_SearchView_Section.getSelected();
   ORBSMM_SearchView_Section.clear();
   ORBSMM_SearchView_Section.add("All",999);
   
   for(%i=1;%i<$ORBS::CModManager::Cache::Secs+1;%i++)
   {
      %sec = $ORBS::CModManager::Cache::Sec[%i];
      if(getField(%sec,2) $= %id || %id $= "999")
         ORBSMM_SearchView_Section.add(getField(%sec,0),getField(%sec,1));
   }
   
   ORBSMM_SearchView_Section.setSelected(%selection);
   if(ORBSMM_SearchView_Section.getSelected() == 0)
      ORBSMM_SearchView_Section.setSelected(999);
}

//- ORBSMM_SearchView_onReplyStop (Reply Stop)
function ORBSMM_SearchView_onReplyStop(%tcp)
{
}

//- ORBSMM_SearchView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETSEARCH","ORBSMM_SearchView_onReply");
function ORBSMM_SearchView_onReply(%tcp,%line)
{
   if(getField(%line,0) $= "CAT")
   {
      $ORBS::CModManager::Cache::Cat[$ORBS::CModManager::Cache::Cats++] = getField(%line,2) TAB getField(%line,1);
      ORBSMM_SearchView_Category.add(getField(%line,2),getField(%line,1));
   }
   else if(getField(%line,0) $= "SEC")
   {
      $ORBS::CModManager::Cache::Sec[$ORBS::CModManager::Cache::Secs++] = getField(%line,3) TAB getField(%line,1) TAB getField(%line,2);
      ORBSMM_SearchView_Section.add(getField(%line,3),getField(%line,1));
   }
}

//- ORBSMM_SearchView_onReplyFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETSEARCH","ORBSMM_SearchView_onReplyFail");
function ORBSMM_SearchView_onReplyFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//- ORBSMM_SearchView_DoSearch (Starts a search)
function ORBSMM_SearchView_DoSearch(%page,%vars)
{
   if($ORBS::CModManager::Cache::CurrentZone $= "SearchView")
   {
      %keyword = ORBSMM_SearchView_Keyword.getValue();
      %author = ORBSMM_SearchView_Author.getValue();
      %section = ORBSMM_SearchView_Section.getSelected();
      %category = ORBSMM_SearchView_Category.getSelected();
      %searchSummary = ORBSMM_SearchView_SearchSummary.getValue();
      %searchDescription = ORBSMM_SearchView_SearchDescription.getValue();
      %sortBy = ORBSMM_SearchView_SortBy.getSelected();
      %sortDir = ORBSMM_SearchView_SortDir.getSelected();
      %vars = %keyword TAB %author TAB %section TAB %category TAB %searchSummary TAB %searchDescription TAB %sortBy TAB %sortDir;
   }
   else
   {
      %keyword = getField(%vars,0);
      %author = getField(%vars,1);
      %section = getField(%vars,2);
      %category = getField(%vars,3);
      %searchSummary = getField(%vars,4);
      %searchDescription = getField(%vars,5);
      %sortBy = getField(%vars,6);
      %sortDir = getField(%vars,7);
   }
   
   if(%page $= "")
      %page = 1;
   
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("DOSEARCH",1,%keyword,%author,%section,%category,%searchSummary,%searchDescription,%sortBy,%sortDir,%page);
   ORBSMM_Zones_Track("DoSearchView","ORBSMM_SearchView_DoSearch(\""@%page@"\",\""@%vars@"\");","ORBSMM_SearchView_DoSearch(%%page%%,\""@%vars@"\");");
}

//- ORBSMM_SearchView_onSearchReplyStart (Begins Reply)
function ORBSMM_SearchView_onSearchReplyStart(%tcp,%line)
{
   ORBSMM_GUI_Init();
   ORBSMM_GUI_createSplitHeader("cell1","100","<color:FAFAFA><just:left><font:Impact:18>  Search Results");
   ORBSMM_GUI_createSplitHeader("cell2","58","<font:Arial Bold:15>File","15","<font:Arial Bold:15>Submitter","12","<font:Arial Bold:15>Downloads","15","<font:Arial Bold:15>Rating");
}

//- ORBSMM_SearchView_onSearchReplyStop (Stops Reply)
function ORBSMM_SearchView_onSearchReplyStop(%tcp,%line)
{
   ORBSMM_GUI_createFooter();
}

//- ORBSMM_SearchView_onSearchReply (Handle Search Reply)
ORBSMM_TCPManager.registerResponseHandler("DOSEARCH","ORBSMM_SearchView_onSearchReply");
function ORBSMM_SearchView_onSearchReply(%tcp,%line)
{
   if(%line $= 0)
   {
      ORBSMM_GUI_createMessage("<br><br>There were no results.<br><br>");
   }
   else
      ORBSMM_SectionView_onReply(%tcp,%line);
}

//- ORBSMM_SearchView_onSearchReplyFail (Fail)
ORBSMM_TCPManager.registerFailHandler("DOSEARCH","ORBSMM_SearchView_onSearchReplyFail");
function ORBSMM_SearchView_onSearchReplyFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* Recent View
//*********************************************************
//- ORBSMM_RecentView_Init (Entrance)
function ORBSMM_RecentView_Init(%page)
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETRECENT",1,%page);
   ORBSMM_Zones_Track("RecentView","ORBSMM_RecentView_Init(\""@%page@"\");","ORBSMM_RecentView_Init(%%page%%);");
}

//- ORBSMM_RecentView_onReplyStart (Reply Start)
function ORBSMM_RecentView_onReplyStart(%tcp)
{
   ORBSMM_SectionView_onReplyStart(%tcp);
}

//- ORBSMM_RecentView_onReplyStop (Reply Stop)
function ORBSMM_RecentView_onReplyStop(%tcp)
{
   if($ORBS::CModManager::Cache::ElementsAdded <= 0)
      ORBSMM_GUI_createMessage("<br>There have been no files submitted in the past 5 days.<br>");
      
   ORBSMM_GUI_createFooter("cell2");
}

//- ORBSMM_RecentView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETRECENT","ORBSMM_RecentView_onReply");
function ORBSMM_RecentView_onReply(%tcp,%line)
{
   ORBSMM_SectionView_onReply(%tcp,%line);
}

//- ORBSMM_RecentView_onFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETRECENT","ORBSMM_SectionView_onFail");
function ORBSMM_RecentView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* All Files View
//*********************************************************
//- ORBSMM_AllFilesView_Init (Entrance)
function ORBSMM_AllFilesView_Init(%page)
{
   ORBSMM_GUI_Load();
   
   ORBSMM_SendRequest("GETALLFILES",1,%page);
   ORBSMM_Zones_Track("AllFilesView","ORBSMM_AllFilesView_Init(\""@%page@"\");","ORBSMM_AllFilesView_Init(%%page%%);");
}

//- ORBSMM_AllFilesView_onReplyStart (Reply Start)
function ORBSMM_AllFilesView_onReplyStart(%tcp)
{
   ORBSMM_SectionView_onReplyStart(%tcp);
}

//- ORBSMM_AllFilesView_onReplyStop (Reply Stop)
function ORBSMM_AllFilesView_onReplyStop(%tcp)
{
   if($ORBS::CModManager::Cache::ElementsAdded <= 0)
      ORBSMM_GUI_createMessage("<br>There are ... no files? Just assume something has gone horribly wrong.<br>");
      
   ORBSMM_GUI_createFooter("cell2");
}

//- ORBSMM_AllFilesView_onReply (Reply)
ORBSMM_TCPManager.registerResponseHandler("GETALLFILES","ORBSMM_AllFilesView_onReply");
function ORBSMM_AllFilesView_onReply(%tcp,%line)
{
   ORBSMM_SectionView_onReply(%tcp,%line);
}

//- ORBSMM_AllFilesView_onFail (Fail)
ORBSMM_TCPManager.registerFailHandler("GETALLFILES","ORBSMM_AllFilesView_onFail");
function ORBSMM_AllFilesView_onFail(%tcp,%error)
{
   ORBSMM_CategoryView_onFail(%tcp,%error);
}

//*********************************************************
//* Downloads View
//*********************************************************
//- ORBSMM_TransferView_Init (Entrance)
function ORBSMM_TransferView_Init()
{
   ORBSMM_GUI_Init();
   
   ORBSMM_TCPManager.tcp[1].killTCP();
   
   ORBSMM_Zones_Track("TransferView","ORBSMM_TransferView_Init();");
   
   ORBSMM_GUI_createHeader(2,"<color:FAFAFA><just:left><font:Impact:18>  Transfers");
   ORBSMM_GUI_createSplitHeader(1,"88","<font:Arial Bold:15>Add-On","12","<font:Arial Bold:15>Options");
   
   ORBSMM_TransferQueue.updateIndicator();   
   
   if(ORBSMM_TransferQueue.getCount() > 0)
      ORBSMM_TransferView_Draw();
   else
      ORBSMM_GUI_createMessage("<br>There are currently no transfers.<br>");
      
   ORBSMM_GUI_createHeader(2,"");
}

//- ORBSMM_TransferView_Draw (Draws the entire transfer queue to the GUI)
function ORBSMM_TransferView_Draw()
{
   for(%i=0;%i<ORBSMM_TransferQueue.getCount();%i++)
   {
      %queue = ORBSMM_TransferQueue.getObject(%i);

      %row = ORBSMM_GUI_createContent(1,70,10,78,12);
      %icon = %row.getObject(0);
      %info = %row.getObject(1);
      %opts = %row.getObject(2);
      
      if((%i+1) > 9)
      {
         %position = new GuiBitmapCtrl()
         {
            position = "-14 4";
            extent = "64 60";
            bitmap = $ORBS::Path@"images/ui/components/large"@getSubStr(%i+1,0,1);
         };
         %icon.add(%position);

         %position = new GuiBitmapCtrl()
         {
            position = "17 4";
            extent = "64 60";
            bitmap = $ORBS::Path@"images/ui/components/large"@getSubStr(%i+1,1,1);
         };
         %icon.add(%position);
      }
      else
      {
         %position = new GuiBitmapCtrl()
         {
            position = "0 0";
            extent = "64 60";
            bitmap = $ORBS::Path@"images/ui/components/large"@%i+1;
         };
         %icon.add(%position);
         ORBSMM_GUI_Center(%position);
      }
      
      %title = new GuiMLTextCtrl()
      {
         position = "6 4";
         extent = "360 13";
      };
      %info.add(%title);
      
      %desc = new GuiMLTextCtrl()
      {
         position = "6 19";
         extent = "360 13";
      };
      %info.add(%desc);
      
      %speed = new GuiMLTextCtrl()
      {
         position = "259 4";
         extent = "262 12";
      };
      %info.add(%speed);
      
      %done = new GuiMLTextCtrl()
      {
         position = "259 19";
         extent = "262 12";
      };
      %info.add(%done);
      
      %load_bg = new GuiBitmapCtrl()
      {
         position = "0 36";
         extent = "517 26";
         bitmap = $ORBS::Path@"images/ui/progressBarBack";
      };
      %info.add(%load_bg);
      
      %load = new GuiProgressCtrl()
      {
         position = "1 1";
         profile = ORBSMM_ProgressBar;
         extent = "515 24";
      };
      %load_bg.add(%load);
      
      %red = new GuiSwatchCtrl()
      {
         position = "1 1";
         extent = "515 24";
         color = "255 0 0 200";
      };
      %load_bg.add(%red);
      
      %load_ov = new GuiBitmapCtrl()
      {
         extent = "517 26";
         bitmap = $ORBS::Path@"images/ui/progressBarOver";
      };
      %load_bg.add(%load_ov);
      
      %load_txt = new GuiMLTextCtrl()
      {
         extent = "400 12";
      };
      %load_bg.add(%load_txt);
      
      ORBSMM_GUI_CenterHoriz(%load_bg);
      ORBSMM_GUI_Center(%load_txt);
      
      %transfer = new GuiBitmapButtonCtrl()
      {
         position = "5 4";
         extent = "68 18";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/transfer";
      };
      %opts.add(%transfer);
      ORBSMM_GUI_CenterHoriz(%transfer);
      
      %cancel = new GuiBitmapButtonCtrl()
      {
         position = "5 24";
         extent = "68 18";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/remove";
         command = "ORBSMM_TransferView_Remove("@%queue.id@");";
      };
      %opts.add(%cancel);
      ORBSMM_GUI_CenterHoriz(%cancel);
      
      %up = new GuiBitmapButtonCtrl()
      {
         position = "5 44";
         extent = "28 18";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/up";
         command = "ORBSMM_TransferView_MoveUp("@%queue.id@");";
      };
      %opts.add(%up);
      
      %down = new GuiBitmapButtonCtrl()
      {
         position = "35 44";
         extent = "38 18";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/down";
         command = "ORBSMM_TransferView_MoveDown("@%queue.id@");";
      };
      %opts.add(%down);
      
      %queue.g_row = %row;
      %queue.g_title = %title;
      %queue.g_desc = %desc;
      %queue.g_speed = %speed;
      %queue.g_done = %done;
      %queue.g_progress = %load;
      %queue.g_red = %red;
      %queue.g_progress_text = %load_txt;
      %queue.g_transfer = %transfer;
      %queue.g_cancel = %cancel;
      %queue.g_up = %up;
      %queue.g_down = %down;
      %queue.update();
   }
}

//- ORBSMM_TransferView_Add (GUI-handler for downloading files)
function ORBSMM_TransferView_Add(%id)
{
   if(ORBSMM_TransferQueue.getCount() $= 99)
   {
      ORBSMM_GUI_createMessageBoxOK("Oh dear!","You can't download more than 99 files at a time!");
      return;
   }
   
   if(!ORBSMM_TransferQueue.addItem(%id))
      ORBSMM_GUI_createMessageBoxOK("Whooops","You already have this file in your transfers list.");
}

//- ORBSMM_TransferView_Remove (Removes an item)
function ORBSMM_TransferView_Remove(%id)
{
   ORBSMM_TransferQueue.removeItem(%id);
   ORBSMM_TransferView_Init();
}

//- ORBSMM_TransferView_MoveUp (Moves an item in the queue up in the list)
function ORBSMM_TransferView_MoveUp(%id)
{
   %position = ORBSMM_TransferQueue.getItemPos(%id);
   if(%position == 0)
      return;
      
   ORBSMM_TransferQueue.swap(%position,%position-1);
   ORBSMM_TransferView_Init();
}

//- ORBSMM_TransferView_MoveDown (Moves an item in the queue down in the list)
function ORBSMM_TransferView_MoveDown(%id)
{
   %position = ORBSMM_TransferQueue.getItemPos(%id);
   if(%position == ORBSMM_TransferQueue.getCount()-1)
      return;
      
   ORBSMM_TransferQueue.swap(%position,%position+1);
   ORBSMM_TransferView_Init();
}

//- ORBSMM_TransferView_RequestTransfer (Attempts to begin a file transfer)
function ORBSMM_TransferView_RequestTransfer(%id)
{
   if(ORBSMM_FileGrabber.connected || isObject(ORBSMM_FileGrabber.queue))
      ORBSMM_GUI_createMessageBoxOK("Ooops","There is already a file being downloaded. Cancel or wait for that to finish then try again.");
   else
      ORBSMM_FileGrabber.loadItem(%id);
}

//- ORBSMM_TransferView_HaltTransfer (Halts a file transfer)
function ORBSMM_TransferView_HaltTransfer(%id)
{
   if(ORBSMM_FileGrabber.queue !$= ORBSMM_TransferQueue.getObject(%id))
      ORBSMM_GUI_createMessageBoxOK("Ooops","This file is not currently in transfer.");
   else
      ORBSMM_FileGrabber.halt();
}

//- ORBSMM_TransferView_onFileData (On data being returned about a file)
ORBSMM_TCPManager.registerResponseHandler("GETFILEDATA","ORBSMM_TransferView_onFileData");
function ORBSMM_TransferView_onFileData(%tcp,%line,%arg1,%arg2,%arg3,%arg4,%arg5,%arg6)
{
   if(!%item = ORBSMM_TransferQueue.getItem(%arg1))
      return;

      
   %item.live = 1;
      

  if(%arg2 $= 1)
   {
      %item.status = 1;
      
      %item.title = %arg3;
      %item.desc = "Submitted by "@%arg4;
      %item.zip = %arg5;
      %item.filesize = %arg6;
      %item.progress_text = "Waiting to Download";
      
      if(isFile("Add-Ons/"@%arg5) && !isFile("Add-Ons/"@ strReplace(%arg5,".zip","") @"/ORBSContent.txt"))
         %item.content_only = 0;
   }
   else
   {
      if(%arg3 $= 0 || %arg3 $= 2)  //File not Found
      {
         %item.status = 0;
         %item.desc = "File could not be found.";
         %item.progress_text = "File Missing";
      }
      else if(%arg3 $= 1)  //File Failed
      {
         %item.status = 0;
         %item.desc = "File has been failed by a moderator.";
         %item.progress_text = "File in Fail Bin";
      }
      else  //Don't Know
      {
         %item.status = 0;
         %item.desc = "Ambiguous error code was returned from server.";
         %item.progress_text = "Error Occurred";
      }
   }
   %item.update();
   
   ORBSMM_FileGrabber.poke();
}

//- ORBSMM_TransferView_onDataFail (When data fails to be returned)
ORBSMM_TCPManager.registerFailHandler("GETFILEDATA","ORBSMM_TransferView_onDataFail");
function ORBSMM_TransferView_onDataFail(%tcp)
{
   if(!%item = ORBSMM_TransferQueue.getItem(getField(%tcp.t_rawString,0)))
      return;
      
   %item.status = 0;
   %item.desc = "Could not connect to the ORBS Service";
   %item.progress_text = "Unable to Connect";

   %item.update();
}

//*********************************************************
//* Mods View
//*********************************************************
//- ORBSMM_ModsView_Init (Entrance)
function ORBSMM_ModsView_Init(%mode)
{
   ORBSMM_GUI_Init();
   
   ORBSMM_TCPManager.tcp[1].killTCP();
   
   ORBSMM_Zones_Track("ModsView","ORBSMM_ModsView_Init(\""@%mode@"\");");
   
   %header = ORBSMM_GUI_createHeader(2,"<color:FAFAFA><just:left><font:Impact:18>  Your Mods");
   
   %expandBtn = new GuiBitmapButtonCtrl()
   {
      position = "399 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/expand";
      command = "ORBSMM_ModsView_ExpandAll();";
   };
   %header.add(%expandBtn);
   
   %collapseBtn = new GuiBitmapButtonCtrl()
   {
      position = "468 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/collapse";
      command = "ORBSMM_ModsView_CollapseAll();";
   };
   %header.add(%collapseBtn);
   
   %sectionsBtn = new GuiBitmapButtonCtrl()
   {
      position = "537 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/sections";
      command = "ORBSMM_ModsView_Init(\"sections\");";
   };
   %header.add(%sectionsBtn);
   
   %groupsBtn = new GuiBitmapButtonCtrl()
   {
      position = "606 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/groups";
      command = "ORBSMM_ModsView_Init(\"groups\");";
   };
   %header.add(%groupsBtn);
   
   $ORBS::CModManager::Cache::SectionHeader = %header;
   
   if(%mode $= "groups")
      ORBSMM_ModsView_InitGroupsView();
   else
      ORBSMM_ModsView_InitSectionView();

   $ORBS::CModManager::Cache::Section[$ORBS::CModManager::Cache::NumSections] = ORBSMM_GUI_createHeader(2," ");
   $ORBS::CModManager::Cache::NumSections++;
}

//- ORBSMM_ModsView_InitSectionView (section-based view of add-ons)
function ORBSMM_ModsView_InitSectionView()
{
   %header = $ORBS::CModManager::Cache::SectionHeader;
   
   %syncBtn = new GuiBitmapButtonCtrl()
   {
      position = "184 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/sync";
      command = "ORBSMM_ModsView_syncAddons();";
   };
   %header.add(%syncBtn);
   
   %enableBtn = new GuiBitmapButtonCtrl()
   {
      position = "261 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/enableAll";
      command = "ORBSMM_ModsView_EnableAll();";
   };
   %header.add(%enableBtn);
   
   %disableBtn = new GuiBitmapButtonCtrl()
   {
      position = "330 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/disableAll";
      command = "ORBSMM_ModsView_DisableAll();";
   };
   %header.add(%disableBtn);   
   
   $ORBS::CModManager::Cache::NumSections = 0;
   
   %sections = 0;
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      %file = ORBSMM_FileCache.getObject(%i);
      %type = %file.file_type;
      
      if(!%added[%type])
      {
         %added[%type] = 1;
         %files[%type] = 0;
         %section[%sections++] = %type;
      }
      %file[%files[%type]++,%type] = %file;
   }
   
   %sortString = "";      
   for(%i=1;%i<%sections+1;%i++)
   {
      %sortString = %sortString@%i@"=>"@%section[%i]@",";
   }
   %sortString = getSubStr(%sortString,0,strLen(%sortString)-1);
   %sortString = strReplace(sortFields(%sortString),",","\t");
   
   %k = 0;
   for(%i=0;%i<getFieldCount(%sortString);%i++)
   {
      %block = strReplace(getField(%sortString,%i),"=>","\t");
      %key = getField(%block,0);
      %value = getField(%block,1);
      %section[%k++] = %value;
   }
   
   %collapse = 0;
   if($ORBS::CModManager::SectionCollapsed["Default Add-Ons"] $= "" || $ORBS::CModManager::SectionCollapsed["Default Add-Ons"] $= 1)
         %collapse = 1;
   ORBSMM_ModsView_createSectionRow("Default Add-Ons",%collapse);
   
   for(%i=1;%i<%sections+1;%i++)
   {
      if(%section[%i] $= "ORBS2 Add-Ons")
         %hasORBS2AddOns = 1;
      if(%section[%i] $= "Non-ORBS Add-Ons")
         %hasNonORBSAddOns = 1;
      if(%section[%i] $= "Unpackaged Add-Ons")
         %hasUnpackagedAddOns = 1;
      if(%section[%i] $= "Content-Only Add-Ons")
         %hasContentOnlyAddOns = 1;
      if(%section[%i] $= "Default Add-Ons" || %section[%i] $= "Non-ORBS Add-Ons" || %section[%i] $= "ORBS2 Add-Ons" || %section[%i] $= "Unpackaged Add-Ons" || %section[%i] $= "Content-Only Add-Ons")
         continue;
      
      %collapse = 0;
      if($ORBS::CModManager::SectionCollapsed[%section[%i]])
         %collapse = 1;
      
      ORBSMM_ModsView_createSectionRow(%section[%i],%collapse);
   }
   
   if(%hasNonORBSAddOns)
   {
      %collapse = 0;
      if($ORBS::CModManager::SectionCollapsed["Non-ORBS Add-Ons"] $= "" || $ORBS::CModManager::SectionCollapsed["Non-ORBS Add-Ons"] $= 1)
            %collapse = 1;
      ORBSMM_ModsView_createSectionRow("Non-ORBS Add-Ons",%collapse);
   }
   
   if(%hasUnpackagedAddOns)
   {
      %collapse = 0;
      if($ORBS::CModManager::SectionCollapsed["Unpackaged Add-Ons"] $= "" || $ORBS::CModManager::SectionCollapsed["Unpackaged Add-Ons"] $= 1)
            %collapse = 1;
      ORBSMM_ModsView_createSectionRow("Unpackaged Add-Ons",%collapse);
   }
   
   if(%hasORBS2AddOns)
   {
      %collapse = 0;
      if($ORBS::CModManager::SectionCollapsed["ORBS2 Add-Ons"] $= "" || $ORBS::CModManager::SectionCollapsed["ORBS2 Add-Ons"] $= 1)
            %collapse = 1;
      ORBSMM_ModsView_createSectionRow("ORBS2 Add-Ons",%collapse);
   }
   
   if(%hasContentOnlyAddOns)
   {
      %collapse = 0;
      if($ORBS::CModManager::SectionCollapsed["Content-Only Add-Ons"] $= "" || $ORBS::CModManager::SectionCollapsed["Content-Only Add-Ons"] $= 1)
            %collapse = 1;
      ORBSMM_ModsView_createSectionRow("Content-Only Add-Ons",%collapse);
   }
}

//- ORBSMM_ModsView_createSectionRow (creates a section row)
function ORBSMM_ModsView_createSectionRow(%name,%hide)
{
   %files = 0;
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      if(ORBSMM_FileCache.getObject(%i).file_type $= %name)
      {
         %file[%files] = ORBSMM_FileCache.getObject(%i);
         %files++;
      }
   }
   
   if(%files <= 0)
      return;
   
   %container = new GuiSwatchCtrl()
   {
      position = 0 SPC $ORBS::CModManager::GUI::CurrentY;
      extent = "680 28";
      color = "255 255 255 255";
   };
   ORBSMM_GUI_PushControl(%container);
   
   %container.sec_id = $ORBS::CModManager::Cache::NumSections;
   $ORBS::CModManager::Cache::Section[$ORBS::CModManager::Cache::NumSections] = %container;
   $ORBS::CModManager::Cache::NumSections++;
   
   %s = (%files $= 1)?"":"s";
   %header = ORBSMM_GUI_createHeader(1,"<just:left>        "@%name@"  <font:Arial:12>"@%files[%section[%i]]@" Add-On"@%s);
   %container.header = %header;
   %container.name = %name;
   %container.files = %files[%section[%i]];
   %bitmap = new GuiBitmapCtrl()
   {
      position = "5 6";
      extent = "16 16";
      bitmap = $ORBS::Path@"images/icons/arrowDown";
   };
   %header.add(%bitmap);
   %container.add(%header);
   %header.position = "0 0";
   %container.bitmap = %bitmap;
   
   %mouseEvent = new GuiMouseEventCtrl()
   {
      extent = "680 28";
      
      eventType = "sectionClick";
      eventCallbacks = "0001000";
      
      id = $ORBS::CModManager::Cache::NumSections-1;
      type = 1;
      
      container = %container;
   };
   %container.add(%mouseEvent);
   %container.mouseEvent = %mouseEvent;

   %sortString = "";      
   for(%i=0;%i<%files;%i++)
   {
      %sortString = %sortString@%file[%i]@"=>"@%file[%i].file_title@",";
   }
   %sortString = getSubStr(%sortString,0,strLen(%sortString)-1);
   %sortString = strReplace(sortFields(%sortString),",","\t");
   for(%j=0;%j<getFieldCount(%sortString);%j++)
   {
      %field = strReplace(getField(%sortString,%j),"=>","\t");
      %row = ORBSMM_ModsView_createModRow(getField(%field,0));
      if(!isObject(%row))
         continue;
      %container.add(%row);
      %container.bringToFront(%row);
      
      %row.vertSizing = "top";
      %row.position = 0 SPC getWord(%container.extent,1);
      %container.extent = vectorAdd(%container.extent,"0" SPC getWord(%row.extent,1));
   }
   %container.originalHeight = getWord(%container.extent,1);
   
   if(%hide)
   {
      %mouseEvent.type = 2;
      ORBSMM_ModsView_collapseSection($ORBS::CModManager::Cache::NumSections-1,1);
   }
}

//- Event_sectionClick::onMouseUp (callback for clicking on a section header)
function Event_sectionClick::onMouseUp(%this)
{
   if(%this.type $= 1)
   {
      if(ORBSMM_ModsView_collapseSection(%this.id))
      {
         %this.type = 2;
         %secName = $ORBS::CModManager::Cache::Section[%this.id].name;
         $ORBS::CModManager::SectionCollapsed[%secName] = 1;
      }
   }
   else if(%this.type $= 2)
   {
      if(ORBSMM_ModsView_expandSection(%this.id))
      {
         %this.type = 1;
         %secName = $ORBS::CModManager::Cache::Section[%this.id].name;
         $ORBS::CModManager::SectionCollapsed[%secName] = 0;
      }
   }
}

//- ORBSMM_ModsView_createModRow (creates a mod row for the section view)
function ORBSMM_ModsView_createModRow(%cache)
{
   if(!isObject(%cache))
      return;
      
   %content = ORBSMM_GUI_createContent(1,40,6,38,6,50);
   %c_icon = %content.getObject(0);
   %c_info = %content.getObject(1);
   %c_state = %content.getObject(2);
   %c_opts = %content.getObject(3);
   %content.setName("ModsViewRow_"@%cache.file_var);
   %content.file_title = %cache.file_title;   
   
   %icon = new GuiBitmapCtrl()
   {
      extent = "16 16";
      bitmap = $ORBS::Path@"images/icons/"@%cache.file_icon;
   };
   %c_icon.add(%icon);
   ORBSMM_GUI_Center(%icon);
   
   %title_text = new GuiMLTextCtrl()
   {
      position = "2 4";
      extent = "307 18";
      text = "<font:Arial Bold:14><color:777777> "@%cache.file_title;
   };
   %c_info.add(%title_text);
   
   %text = new GuiMLTextCtrl()
   {
      position = "4 20";
      extent = "450 18";
      text = "<font:Verdana:12><color:999999>by "@%cache.file_author;
   };
   %c_info.add(%text);
  
   if(%cache.file_platform $= "orbs" || %cache.file_platform $= "orbs2")
      %title_text.setText(%title_text.text@" <color:999999><font:Arial:12>v"@%cache.file_version);  
  
   if(%cache.file_platform $= "orbs" || %cache.file_isContent)
   { 
      %icon = new GuiBitmapButtonCtrl()
      {
         position = "235 1";
         extent = "16 16";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/eye";
         command = "ORBSMM_FileView_Init("@%cache.file_id@");";
      };
      %c_info.add(%icon);
      
      if(%cache.file_platform $= "orbs")
      {
         %reportBtn = new GuiBitmapButtonCtrl()
         {
            position = "235 18";
            extent = "16 16";
            text = " ";
            bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/reportSmall";
            command = "ORBSMM_FileView_Report("@%cache.file_id@");";
         };
         %c_info.add(%reportBtn);
      }
   }
   
   %enabled = $AddOn__[%cache.file_var];
   if(%cache.file_isContent)
   {
      %swatch = new GuiSwatchCtrl()
      {
         position = %c_state.position;
         extent = %c_state.extent;
         color = "150 150 150 50";
      };
      %c_state.getGroup().add(%swatch);
      
      %icon = new GuiBitmapCtrl()
      {
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/tickGray";
         swatch = %swatch;
      };
      %c_state.add(%icon);
   }
   else if(%enabled $= 1 || %cache.file_special !$= "")
   {
      %swatch = new GuiSwatchCtrl()
      {
         position = %c_state.position;
         extent = %c_state.extent;
         color = "0 255 0 50";
      };
      %c_state.getGroup().add(%swatch);
      
      %icon = new GuiBitmapCtrl()
      {
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/tick";
         swatch = %swatch;
      };
      %c_state.add(%icon);
   }
   else
   {
      %swatch = new GuiSwatchCtrl()
      {
         position = %c_state.position;
         extent = %c_state.extent;
         color = "255 0 0 50";
      };
      %c_state.getGroup().add(%swatch);
      
      %icon = new GuiBitmapCtrl()
      {
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/cross";
         swatch = %swatch;
      };
      %c_state.add(%icon);
   }
   ORBSMM_GUI_Center(%icon);
   
   if(%cache.file_isContent)
   {
      %btnLeft = new GuiBitmapButtonCtrl()
      {
         position = "7 6";
         extent = "82 25";
         text = " ";
         command = "ORBSMM_TransferView_Add(\""@%cache.file_id@"\");";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/downloadContent";
      };
      %c_opts.add(%btnLeft);
   }
   else if(%cache.file_special $= "clientside")
   {
      %btnLeft = new GuiBitmapCtrl()
      {
         position = "7 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/client_i";
      };
      %c_opts.add(%btnLeft);
   }
   else if(%cache.file_special $= "map")
   {
      %btnLeft = new GuiBitmapCtrl()
      {
         position = "7 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/map_i";
      };
      %c_opts.add(%btnLeft);
   }
   else if(%cache.file_special $= "decal")
   {
      %btnLeft = new GuiBitmapCtrl()
      {
         position = "7 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/decal_i";
      };
      %c_opts.add(%btnLeft);
   }
   else if(%cache.file_special $= "colorset")
   {
      %btnLeft = new GuiBitmapCtrl()
      {
         position = "7 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/colorset_i";
      };
      %c_opts.add(%btnLeft);
   }
   else
   {
      if(%enabled $= 1)
      {
         %btnLeft = new GuiBitmapButtonCtrl()
         {
            position = "7 6";
            extent = "82 25";
            text = " ";
            command = "ORBSMM_ModsView_DisableAddon(\""@%cache.file_var@"\");";
            bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/disable";
         };
         %c_opts.add(%btnLeft);
      }
      else
      {
         %btnLeft = new GuiBitmapButtonCtrl()
         {
            position = "7 6";
            extent = "82 25";
            text = " ";
            command = "ORBSMM_ModsView_EnableAddon(\""@%cache.file_var@"\");";
            bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/enable";
         };
         %c_opts.add(%btnLeft);
      }
   }
   
   if(%cache.file_isContent)
   {
      %btnA = new GuiBitmapCtrl()
      {
         position = "87 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/placeholder_n";
      };
      %c_opts.add(%btnA);

      %btnB = new GuiBitmapCtrl()
      {
         position = "167 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/placeholder_n";
      };
      %c_opts.add(%btnB);
   }
   else if(%cache.file_platform $= "orbs")
   {      
      %btnBug = new GuiBitmapButtonCtrl()
      {
         position = "87 6";
         extent = "82 25";
         text = " ";
         command = "ORBSMM_ModsView_Report("@%cache.file_id@");";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/sendBug";
      };
      %c_opts.add(%btnBug);

      %btnUpdate = new GuiBitmapButtonCtrl()
      {
         position = "167 6";
         extent = "82 25";
         text = " ";
         command = "ORBSMM_ModsView_updateAddon("@%cache@","@%content@");";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/update";
      };
      %c_opts.add(%btnUpdate);
   }
   else
   {  
      %btnBug = new GuiBitmapCtrl()
      {
         position = "87 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/sendBug_i";
      };
      %c_opts.add(%btnBug);

      %btnUpdate = new GuiBitmapCtrl()
      {
         position = "167 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/update_i";
      };
      %c_opts.add(%btnUpdate);
   }
   
   if(!%cache.file_default)
   {
      %btnDelete = new GuiBitmapButtonCtrl()
      {
         position = "247 6";
         extent = "82 25";
         text = " ";
         command = "ORBSMM_GUI_createMessageBoxOKCancel(\"Are you sure?\",\"<just:center>Are you sure you want to permanently delete the selected add-on?\",\"ORBSMM_ModsView_deleteAddon("@%cache@","@%content@");\");";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/delete";
      };
      %c_opts.add(%btnDelete);
   }
   else
   {
      %btnDelete = new GuiBitmapCtrl()
      {
         position = "247 6";
         extent = "82 25";
         text = " ";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/delete_i";
      };
      %c_opts.add(%btnDelete);
   }
   %cache.physical_row = %content;
   
   return %content;
}

//- ORBSMM_ModsView_insertModRow (inserts a mod row live into the mods view)
function ORBSMM_ModsView_insertModRow(%cache)
{
   for(%i=0;%i<$ORBS::CModManager::Cache::NumSections-1;%i++)
   {
      %sec = $ORBS::CModManager::Cache::Section[%i];
      if(%sec.name $= %cache.file_type)
      {
         %targetSection = %sec;
         break;
      }
   }
   
   if(!isObject(%targetSection))
   {
      ORBSMM_Zones_Refresh();
      return;
   }
   else
   {
      %targetSection.files++;
      %s = (%targetSection.files == 1) ? "" : "s";
      %targetSection.header.getObject(1).setText("<color:888888><font:Arial Bold:15><just:left>        "@%targetSection.name@"  <font:Arial:12>"@%targetSection.files@" Add-On"@%s);
      
      %content = ORBSMM_ModsView_createModRow(%cache,1);
      ORBSMM_GUI_Offset(-(getWord(%content.extent,1)));
      
      for(%i=0;%i<%targetSection.getCount();%i++)
      {
         %row = %targetSection.getObject(0);
         if(!%targetSection.isMember(%content))
         {
            if(alphaCompare(%cache.file_title,%row.file_title) $= 2)
            {
               %row.position = vectorSub(%row.position,0 SPC getWord(%content.extent,1));
               %targetSection.add(%content);
               %targetSection.pushToBack(%content);
               %content.vertSizing = "top";
               %content.position = vectorAdd(%row.position,0 SPC getWord(%content.extent,1));
               %i++;
            }
            else if(%i $= %targetSection.getCount()-2)
            {
               %targetSection.add(%content);
               %targetSection.pushToBack(%content);
               %content.vertSizing = "top";
               %content.position = vectorSub("0 28",0 SPC getWord(%content.extent,1));
               %i++;
            }
         }
         else if(%row.file_title !$= "")
         {          
            %row.position = vectorSub(%row.position,0 SPC getWord(%content.extent,1));
         }
         %targetSection.pushToBack(%row);
      }
      %targetSection.originalHeight = vectorAdd(%targetSection.originalHeight,getWord(%content.extent,1));
      %sec_id = %targetSection.sec_id;
      
      if(%targetSection.mouseEvent.type $= 1)
      {
         %targetSection.resize(getWord(%targetSection.position,0),getWord(%targetSection.position,1),getWord(%targetSection.extent,0),getWord(%targetSection.extent,1)+getWord(%content.extent,1));
         for(%i=0;%i<$ORBS::CModManager::Cache::NumSections;%i++)
         {
            %sec = $ORBS::CModManager::Cache::Section[%i];
            if(%i > %sec_id)
               %sec.position = vectorAdd(%sec.position,0 SPC getWord(%content.extent,1));         
         }
      }
   }
}

//- ORBSMM_ModsView_collapseAll (collapses all the sections)
function ORBSMM_ModsView_collapseAll()
{
   for(%i=0;%i<$ORBS::CModManager::Cache::NumSections;%i++)
   {
      if(ORBSMM_ModsView_collapseSection(%i,1))
      {
         %sec = $ORBS::CModManager::Cache::Section[%i];
         %sec.mouseEvent.type = 2;
         $ORBS::CModManager::SectionCollapsed[%sec.name] = 1;
      }
   }
}

//- ORBSMM_ModsView_collapseSection (collapses a mod view section)
function ORBSMM_ModsView_collapseSection(%id,%noAnimate)
{
   %sec = $ORBS::CModManager::Cache::Section[%id];
   if(%sec.sec_id $= "")
      return;
      
   if(!ORBSCO_getPref("MM::Animate") || %noAnimate)
   {
      %sec.bitmap.position = "4 5";
      %sec.bitmap.setBitmap($ORBS::Path@"images/icons/arrowRight");
      ORBSMM_ModsView_instantCollapseSection(%id);
      return 1;
   }

   if(!isEventPending(%sec.expColSch))
   {
      %sec.bitmap.position = "4 5";
      %sec.bitmap.setBitmap($ORBS::Path@"images/icons/arrowRight");
      if(%sec.files > 3)
         %time = 400;
      else
         %time = 100*%sec.files;
         
      if(%sec.files <= 0)
         %time = 100;
         
      ORBSMM_ModsView_doCollapse(%id,0,getWord(%sec.extent,1),(28-getWord(%sec.extent,1))-1,%time);
      return 1;
   }
   return 0;
}

//- ORBSMM_ModsView_doCollapse (looping function to animate the section collapsing)
function ORBSMM_ModsView_doCollapse(%id,%time,%begin,%change,%duration)
{
   if(%time $= %duration)
      return;

   %sec = $ORBS::CModManager::Cache::Section[%id];
   if(!isObject(%sec))
      return;
      
   %oldExtent = getWord(%sec.extent,1);
   %newExtent = mceil(Anim_EaseInOut(%time,%begin,%change,%duration));
   %sec.resize(getWord(%sec.position,0),getWord(%sec.position,1),getWord(%sec.extent,0),%newExtent);
   %sec.expColSch = schedule(10,0,"ORBSMM_ModsView_doCollapse",%id,%time+10,%begin,%change,%duration);
   
   for(%i=%id+1;%i<$ORBS::CModManager::Cache::NumSections;%i++)
   {
      %sec = $ORBS::CModManager::Cache::Section[%i];
      %sec.position = vectorAdd(%sec.position,"0" SPC %newExtent-%oldExtent);
   }
   ORBSMM_GUI_AutoResize();
}

//- ORBSMM_ModsView_instantCollapseSection (Instantly collapses a section)
function ORBSMM_ModsView_instantCollapseSection(%id)
{
   %sec = $ORBS::CModManager::Cache::Section[%id];
   if(!isObject(%sec))
      return;

   %oldExtent = getWord(%sec.extent,1);
   %sec.resize(getWord(%sec.position,0),getWord(%sec.position,1),680,28);

   for(%i=%id+1;%i<$ORBS::CModManager::Cache::NumSections;%i++)
   {
      %sec = $ORBS::CModManager::Cache::Section[%i];
      %sec.position = vectorAdd(%sec.position,"0" SPC 28-%oldExtent);
   }
   ORBSMM_GUI_AutoResize();
}

//- ORBSMM_ModsView_expandAll (expands all the sections)
function ORBSMM_ModsView_expandAll()
{
   for(%i=0;%i<$ORBS::CModManager::Cache::NumSections;%i++)
   {
      if(ORBSMM_ModsView_expandSection(%i,1))
      {
         %sec = $ORBS::CModManager::Cache::Section[%i];
         %sec.mouseEvent.type = 1;
         $ORBS::CModManager::SectionCollapsed[%sec.name] = 0;
      }
   }
}

//- ORBSMM_ModsView_expandSection (Expands a section)
function ORBSMM_ModsView_expandSection(%id,%noAnimate)
{
   %sec = $ORBS::CModManager::Cache::Section[%id];
   if(%sec.sec_id $= "")
      return;
      
   if(!ORBSCO_getPref("MM::Animate") || %noAnimate)
   {
      %sec.bitmap.position = "5 6";
      %sec.bitmap.setBitmap($ORBS::Path@"images/icons/arrowDown");
      ORBSMM_ModsView_instantExpandSection(%id);
      return 1;
   }
   
   if(!isEventPending(%sec.expColSch))
   {
      %sec.bitmap.position = "5 6";
      %sec.bitmap.setBitmap($ORBS::Path@"images/icons/arrowDown");
      if(%sec.files > 3)
         %time = 400;
      else
         %time = 100*%sec.files;
         
      if(%sec.files <= 0)
         %time = 100;
         
      ORBSMM_ModsView_doExpand(%id,0,getWord(%sec.extent,1),%sec.originalHeight-28,%time);
      return 1;
   }
   return 0;
}

//- ORBSMM_ModsView_doExpand (looping function to animate the section expanding)
function ORBSMM_ModsView_doExpand(%id,%time,%begin,%change,%duration)
{
   if(%time $= %duration)
      return;

   %sec = $ORBS::CModManager::Cache::Section[%id];
   if(!isObject(%sec))
      return;
      
   %oldExtent = getWord(%sec.extent,1);
   %newExtent = mceil(Anim_EaseInOut(%time,%begin,%change,%duration));
   %sec.resize(getWord(%sec.position,0),getWord(%sec.position,1),getWord(%sec.extent,0),%newExtent);
   %sec.expColSch = schedule(10,0,"ORBSMM_ModsView_doExpand",%id,%time+10,%begin,%change,%duration);
   
   for(%i=%id+1;%i<$ORBS::CModManager::Cache::NumSections;%i++)
   {
      %sec = $ORBS::CModManager::Cache::Section[%i];
      %sec.position = vectorAdd(%sec.position,"0" SPC %newExtent-%oldExtent);
   }
   ORBSMM_GUI_AutoResize();
}

//- ORBSMM_ModsView_instantExpandSection (Instantly expands a section)
function ORBSMM_ModsView_instantExpandSection(%id)
{
   %sec = $ORBS::CModManager::Cache::Section[%id];
   if(!isObject(%sec))
      return;

   %oldExtent = getWord(%sec.extent,1);
   %sec.resize(getWord(%sec.position,0),getWord(%sec.position,1),680,%sec.originalHeight);
   %newExtent = getWord(%sec.extent,1);

   for(%i=%id+1;%i<$ORBS::CModManager::Cache::NumSections;%i++)
   {
      %sec = $ORBS::CModManager::Cache::Section[%i];
      %sec.position = vectorAdd(%sec.position,"0" SPC %newExtent-%oldExtent);
   }
   ORBSMM_GUI_AutoResize();
}

//- ORBSMM_ModsView_EnableAll (enables all add-ons)
function ORBSMM_ModsView_EnableAll()
{
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      %file = ORBSMM_FileCache.getObject(%i);
      
      if(%file.file_special $= "colorset" || %file.file_special $= "decal" || %file.file_special $= "map" || %file.file_special $= "clientside")
         continue;
         
      $AddOn__[%file.file_var] = 1;
   }
   export("$AddOn__*","config/server/ADD_ON_LIST.cs");
   
   ORBSMM_ModsView_Init();
}

//- ORBSMM_ModsView_DisableAll (disables all add-ons)
function ORBSMM_ModsView_DisableAll()
{
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      %file = ORBSMM_FileCache.getObject(%i);
      
      if(%file.file_special $= "colorset" || %file.file_special $= "decal" || %file.file_special $= "map" || %file.file_special $= "clientside")
         continue;
         
      $AddOn__[%file.file_var] = 0;
   }
   export("$AddOn__*","config/server/ADD_ON_LIST.cs");
   
   ORBSMM_ModsView_Init();
}

//- ORBSMM_ModsView_EnableAddon (Sets an add-on to enabled and updates gui)
function ORBSMM_ModsView_EnableAddon(%var)
{
   $AddOn__[%var] = 1;
   export("$AddOn__*","config/server/ADD_ON_LIST.cs");
   
   %container = "ModsViewRow_"@%var;
   %c_state = %container.getObject(2);
   %c_opts = %container.getObject(3);
   
   %c_state.getObject(0).setBitmap($ORBS::Path@"images/icons/tick");
   %c_state.getObject(0).swatch.color = "0 255 0 50";
   
   %c_opts.getObject(0).setBitmap($ORBS::Path@"images/ui/buttons/modManager/interface/disable");
   %c_opts.getObject(0).command = "ORBSMM_ModsView_DisableAddon(\""@%var@"\");";
}

//- ORBSMM_ModsView_DisableAddon (Sets an add-on to disabled and updates gui)
function ORBSMM_ModsView_DisableAddon(%var)
{
   $AddOn__[%var] = 0;
   export("$AddOn__*","config/server/ADD_ON_LIST.cs");
   
   %container = "ModsViewRow_"@%var;
   %c_state = %container.getObject(2);
   %c_opts = %container.getObject(3);

   %c_state.getObject(0).setBitmap($ORBS::Path@"images/icons/cross");
   %c_state.getObject(0).swatch.color = "255 0 0 50";
   
   %c_opts.getObject(0).setBitmap($ORBS::Path@"images/ui/buttons/modManager/interface/enable");
   %c_opts.getObject(0).command = "ORBSMM_ModsView_EnableAddon(\""@%var@"\");";
}

//- ORBSMM_ModsView_Report (Opens a form to allow the user to report a bug in the addon)
function ORBSMM_ModsView_Report(%id)
{
   if(%id $= "")
   {
      ORBSMM_GUI_createMessageBoxOK("Ooops","You have not selected a file to report a bug for.");
      return;
   }
      
   %window = ORBSMM_GUI_createWindow("Report Bug");
   %window.resize(0,0,400,200);
   ORBSMM_GUI_Center(%window);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 10";
      extent = "";
      text = "<font:Verdana:12><color:555555>Summary:";
   };
   %window.canvas.add(%label);
   $ORBS::CModManager::Cache::Report::Summary = %label;
   
   %textedit = new GuiTextEditCtrl(ORBSMM_Report_Summary)
   {
      profile = ORBS_TextEditProfile;
      position = "66 8";
      extent = "316 16";
   };
   %window.canvas.add(%textedit);
   
   %label = new GuiMLTextCtrl()
   {
      position = "10 34";
      extent = "";
      text = "<font:Verdana:12><color:555555>Description:";
   };
   %window.canvas.add(%label);
   $ORBS::CModManager::Cache::Report::Description = %label;
   
   %label = new GuiMLTextCtrl()
   {
      position = "202 34";
      extent = "";
      text = "<font:Verdana:12><color:555555>Severity:";
   };
   %window.canvas.add(%label);
   
   %popup = new GuiPopupMenuCtrl(ORBSMM_Report_Severity)
   {
      profile = ORBS_PopupProfile;
      position = "252 31";
      extent = "130 17";
   };
   %window.canvas.add(%popup);
   %popup.add("Low",1);
   %popup.add("Medium",2);
   %popup.add("High",3);
   %popup.setSelected(1);
   
   %textedit = new GuiScrollCtrl()
   {
      profile = ORBS_TextEditProfile;
      position = "9 52";
      extent = "373 73";
      hScrollBar = "alwaysOff";
      vScrollBar = "alwaysOff";
      
      new GuiMLTextEditCtrl(ORBSMM_Report_Description)
      {
         profile = ORBS_MLEditProfile;
         position = "3 1";
         extent = "364 73";
      };
   };
   %window.canvas.add(%textedit);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "324 133";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = "ORBSMM_ModsView_SendReport("@%window@","@%id@");";
   };
   %window.canvas.add(%button);
   
   %button = new GuiBitmapButtonCtrl()
   {
      position = "260 133";
      extent = "58 25";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/cancel";
      command = %window.closeButton.command;
   };
   %window.canvas.add(%button);
   
   %buglink = new GuiMLTextCtrl()
   {
      profile = "ORBSMM_NewsContentProfile";
      position = "12 140";
      extent = "236 12";
      text = "<color:AAAAAA>Warning: Abuse will result in a ban.";
   };
   %window.canvas.add(%buglink);
}

//- ORBSMM_ModsView_SendReport (Processes + Sends the File Report)
function ORBSMM_ModsView_SendReport(%window,%id)
{
   if(ORBSMM_Report_Summary.getValue() $= "")
   {
      $ORBS::CModManager::Cache::Report::Summary.setValue("<font:Verdana Bold:12><color:EE0000>Summary:");
      %errors = 1;
   }
   else
      $ORBS::CModManager::Cache::Report::Summary.setValue("<font:Verdana:12><color:555555>Summary:");

   if(ORBSMM_Report_Description.getValue() $= "")
   {   
      $ORBS::CModManager::Cache::Report::Description.setValue("<font:Verdana Bold:12><color:EE0000>Description:");
      %errors = 1;
   }
   else
      $ORBS::CModManager::Cache::Report::Description.setValue("<font:Verdana:12><color:555555>Description:");
   
   if(%errors)
      return;
   
   %overlay = new GuiSwatchCtrl()
   {
      position = "0 0";
      extent = %window.canvas.extent;
      color = "255 255 255 200";
   };
   %window.canvas.add(%overlay);
   
   %bitmap = new GuiAnimatedBitmapCtrl()
   {
      extent = "31 31";
      bitmap = $ORBS::Path@"images/ui/animated/loadRing";
      framesPerSecond = 15;
      numFrames = 8;
   };
   %overlay.add(%bitmap);
   ORBSMM_GUI_Center(%bitmap);
   %bitmap.shift(0,-10);
   
   %mlCtrl = new GuiMLTextCtrl()
   {
      extent = "200 0";
      text = "<just:center><font:Verdana:12><color:666666>Sending Report...";
   };
   %overlay.add(%mlCtrl);
   ORBSMM_GUI_Center(%mlCtrl);
   %mlCtrl.shift(0,12);
   
   $ORBS::CModManager::Cache::LoadRing = %bitmap;
   $ORBS::CModManager::Cache::LoadText = %mlCtrl;
   
   %details = ORBSMM_FileCache.get(%id);
   ORBSMM_SendRequest("SENDBUGREPORT",3,%id,%details.file_version,ORBSMM_Report_Summary.getValue(),ORBSMM_Report_Description.getValue(),$Version,$ORBS::Version,ORBSMM_Report_Severity.getSelected());
}

//- ORBSMM_ModsView_onReportReply (Reply from sending a report)
ORBSMM_TCPManager.registerResponseHandler("SENDBUGREPORT","ORBSMM_ModsView_onReportReply");
function ORBSMM_ModsView_onReportReply(%tcp,%line)
{
   ORBSMM_GUI_LoadRing_Clear($ORBS::CModManager::Cache::LoadRing);
   if(getField(%line,0) $= 1)
   {
      $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Your report has been received.");
   }
   else
   {
      $ORBS::CModManager::Cache::LoadRing.setBitmap($ORBS::Path@"images/ui/animated/loadRing_fail");
      if(getField(%line,1) $= 1)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>You are not logged in!");
      else if(getField(%line,1) $= 2)
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>File not found.");
      else
         $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Unknown Error Occurred.");
   }
}

//- ORBSMM_ModsView_onReportFail (Fail result from sending a report)
ORBSMM_TCPManager.registerFailHandler("SENDBUGREPORT","ORBSMM_ModsView_onReportFail");
function ORBSMM_ModsView_onReportFail(%tcp,%fail)
{
   ORBSMM_GUI_LoadRing_Clear($ORBS::CModManager::Cache::LoadRing);
   $ORBS::CModManager::Cache::LoadRing.setBitmap($ORBS::Path@"images/ui/animated/loadRing_fail");
   $ORBS::CModManager::Cache::LoadText.setValue("<just:center><font:Verdana:12><color:666666>Connection Failed. Please try again later.");
}

//- ORBSMM_ModsView_updateAddon (Checks for updates for a certain add-on)
function ORBSMM_ModsView_updateAddon(%cache,%content)
{
   if(%cache.checkingForUpdates)
      return;
      
   %cache.checkingForUpdates = 1;
   
   %content.getObject(0).getObject(0).setVisible(0);
   %ring = new GuiAnimatedBitmapCtrl()
   {
      extent = "26 26";
      bitmap = $ORBS::Path@"images/ui/animated/loadRing";
      framesPerSecond = 15;
      numFrames = 8;
   };
   %content.getObject(0).add(%ring);
   ORBSMM_GUI_Center(%ring);
   %content.getObject(1).getObject(1).oldValue = %content.getObject(1).getObject(1).getValue();
   %content.getObject(1).getObject(1).setValue("<font:Verdana:12><color:999999>Checking for Updates...");
   
   ORBSMM_SendRequest("GETUPDATE",3,%cache.file_id,%cache.file_version,%content);
}

//- ORBSMM_ModsView_onUpdateReply (Reply Handler)
ORBSMM_TCPManager.registerResponseHandler("GETUPDATE","ORBSMM_ModsView_onUpdateReply");
function ORBSMM_ModsView_onUpdateReply(%tcp,%line)
{
   %file_id = getField(%line,0);

   %content = getField(%line,2);
   
   ORBSMM_FileCache.get(%file_id).checkingForUpdates = 0;

   if(!isObject(%content))
      return;
      
   %content.getObject(0).getObject(0).setVisible(1);
   %content.getObject(0).getObject(1).delete();

//   if(%line $= 1)
   if(getField(%line,1) $= 1)
   {
      ORBSMM_GUI_createMessageBoxOKCancel("Update Found!","An update has been found for this add-on, would you like to download it now?","ORBSMM_TransferQueue.addItem("@%file_id@");","");
      %content.getObject(1).getObject(1).setValue("<font:Verdana:12><color:999999>An update was found.");
   }
   else
   {
      %content.getObject(1).getObject(1).setValue("<font:Verdana:12><color:FF6666>No updates were found ...");
   }
   schedule(2000,0,"ORBSMM_ModsView_resetDesc",%content.getObject(1).getObject(1));
}

//- ORBSMM_ModsView_resetDesc (Resets control value)
function ORBSMM_ModsView_resetDesc(%ctrl)
{
   if(!isObject(%ctrl))
      return;
      
   %ctrl.setValue(%ctrl.oldValue);
}

//- ORBSMM_ModsView_deleteAddon (Action to remove a row and alter the gui)
function ORBSMM_ModsView_deleteAddon(%cache,%row,%noDel)
{
   %section = %row.getGroup();
   %id = %section.sec_id;
   %extent = getWord(%row.extent,1);
   %pos = getWord(%row.position,1);
   %row.delete();
   
   %section.files--;
   %s = (%section.files == 1) ? "" : "s";
   %section.header.getObject(1).setText("<color:888888><font:Arial Bold:15><just:left>        "@%section.name@"  <font:Arial:12>"@%section.files@" Add-On"@%s);

   if(%section.getCount() <= 2)
   {
      %extent = getWord(%section.extent,1);
      %section.delete();

      for(%i=%id+1;%i<$ORBS::CModManager::Cache::NumSections;%i++)
      {
         %sec = $ORBS::CModManager::Cache::Section[%i];
         %sec.position = vectorSub(%sec.position,"0" SPC %extent);
      }
   }
   else
   {
      for(%i=0;%i<%section.getCount()-1;%i++)
      {
         %row = %section.getObject(%i);
         if(getWord(%row.position,1) > %pos)
            %row.position = vectorSub(%row.position,0 SPC %extent);
      }
      
      %section.extent = vectorSub(%section.extent,0 SPC %extent);
      %section.originalHeight -= %extent;

      for(%i=%id+1;%i<$ORBS::CModManager::Cache::NumSections;%i++)
      {
         %sec = $ORBS::CModManager::Cache::Section[%i];
         %sec.position = vectorSub(%sec.position,"0" SPC %extent);
      }
      
      for(%i=0;%i<%section.getCount()-1;%i++)
      {
         %row = %section.getObject(%i);
         if(%row.getClassName() $= "GuiMouseEventCtrl")
         {
            %section.pushToBack(%row);
            continue;
         }
      }
   }
   ORBSMM_GUI_AutoResize();

   if(!%noDel)
   {
      %filepath = %cache.file_path;
      fileDelete(%filepath);
      %cache.delete();
      
      for(%i=0;%i<ORBSMM_GroupManager.getCount();%i++)
      {
         %group = ORBSMM_GroupManager.getObject(%i);
         %group.removeItem(%cache);
      }
   }
}

//- ORBSMM_ModsView_syncAddons (Attempts to match old add-ons to the new system)
function ORBSMM_ModsView_syncAddons()
{
   %window = ORBSMM_GUI_createWindow("Sync Add-Ons");
   %window.resize(0,0,600,500);
   %window.setName("ORBSMM_SyncAddons");
   ORBSMM_GUI_Center(%window);
   
   %text = new GuiMLTextCtrl()
   {
      position = "8 8";
      extent = "580 1";
      text = "<color:666666><font:Arial:13>ORBS has attempted to find matches for all your ORBS v2 Add-Ons that exist on the ORBS v3 Downloads System. Below are the results turned up by our matching process which checks the name of zip files and file titles. Please check the following:<br><br>        <bitmap:add-ons/System_oRBs/images/icons/bullet_news>That you either have a direct match of filename, or a close match of file title.<br>        <bitmap:add-ons/System_oRBs/images/icons/bullet_news>That the authors are the same as the add-on you are trying to sync.<br><br>Select the match you'd like to use, and then press the sync button to download them. Note that the old versions of your files will be deleted so if you still want them, take a copy before completing this process.";
   };
   %window.canvas.add(%text);
   
   %parent = new GuiSwatchCtrl()
   {
      position = "10 120";
      extent = "560 300";
      color = "200 200 200 255";
      
      new GuiSwatchCtrl()
      {
         position = "1 1";
         extent = "558 298";
         color = "245 245 245 255";
      };
   };
   %window.canvas.add(%parent);
   
   %scroll = new GuiScrollCtrl()
   {
      profile = ORBS_ScrollProfile;
      position = "10 120";
      extent = "574 300";
      hScrollBar = "AlwaysOff";
      
      new GuiSwatchCtrl(ORBSMM_SyncMods_Window)
      {
         position = "1 1";
         extent = "558 298";
         color = "0 0 0 0";
         
         new GuiSwatchCtrl()
         {
            position = "1 1";
            extent = "558 30";
            color = "0 0 0 0";
            
            new GuiSwatchCtrl()
            {
               position = "0 0";
               extent = "243 30";
               color = "215 215 215 255";
               
               new GuiMLTextCtrl()
               {
                  position = "35 8";
                  extent = "172 14";
                  text = "<just:center><color:888888><font:Arial Bold:14>Non-Synchronised Add-On";
               };
            };
            
            new GuiSwatchCtrl()
            {
               position = "244 0";
               extent = "40 30";
               color = "215 215 215 255";
            };
            
            new GuiSwatchCtrl()
            {
               position = "285 0";
               extent = "271 30";
               color = "215 215 215 255";
               
               new GuiMLTextCtrl()
               {
                  position = "35 8";
                  extent = "172 14";
                  text = "<just:center><color:888888><font:Arial Bold:14>Closest ORBS Match";
               };
            };
         };
      };
   };
   %window.canvas.add(%scroll);
   
   %syncBtn = new GuiBitmapButtonCtrl()
   {
      position = "255 430";
      extent = "82 25";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/syncMods";
      command = "ORBSMM_ModsView_syncComplete();";
      text = " ";
   };
   %window.canvas.add(%syncBtn);
   
   %loadOverlay = new GuiSwatchCtrl()
   {
      position = "11 121";
      extent = "558 298";
      color = "255 255 255 150";
      
		new GuiAnimatedBitmapCtrl()
		{
		   position = "263 133";
		   extent = "31 31";
		   bitmap = $ORBS::Path@"images/ui/animated/loadRing";
		   framesPerSecond = 15;
		   numFrames = 8;
		};
   };
   %window.canvas.add(%loadOverlay);
   $ORBS::CModManager::Sync::LoadOverlay = %loadOverlay;
   
   ORBSMM_ModsView_syncStart();
}

//- ORBSMM_ModsView_syncStart (starts the sync process)
function ORBSMM_ModsView_syncStart()
{
   $ORBS::CModManager::Sync::CurrFile = 0;
   $ORBS::CModManager::Sync::NumFiles = 0;
   $ORBS::CModManager::SyncResults::CBoxes = 0;
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      %file = ORBSMM_FileCache.getObject(%i);
      if(%file.file_platform !$= "orbs" && %file.file_type !$= "Default Add-Ons" &&  !%file.file_isContent)
      {
         $ORBS::CModManager::Sync::File[$ORBS::CModManager::Sync::NumFiles] = %file.file_path;
         $ORBS::CModManager::Sync::NumFiles++;
      }
   }
   
   if($ORBS::CModManager::Sync::NumFiles > 0)
      ORBSMM_ModsView_syncProcess();
   else
      ORBSMM_GUI_createMessageBoxOK("Oh Dear","You don't have any Add-Ons that need to be synchronised!");
}

//- ORBSMM_ModsView_syncProcess (attempts to sync a single add-on)
function ORBSMM_ModsView_syncProcess()
{
   if(!isObject(ORBSMM_SyncMods_Window))
      return;
      
   if($ORBS::CModManager::Sync::CurrFile >= $ORBS::CModManager::Sync::NumFiles)
   {
      ORBSMM_ModsView_syncFinish();
      return;
   }
      
   %target = $ORBS::CModManager::Sync::File[$ORBS::CModManager::Sync::CurrFile];
   if(isObject(ORBSMM_FileCache.getByPath(%target)))
   {
      %file = ORBSMM_FileCache.getByPath(%target);
      ORBSMM_SendRequest("SYNCADDON",3,%file.file_zip,%file.file_title,%file);
      $ORBS::CModManager::Sync::CurrFile++;
   }
}

//- ORBSMM_ModsView_onReplyStop (sync reply is done so lets do the next)
function ORBSMM_ModsView_syncReplyStop()
{
   ORBSMM_ModsView_syncProcess();
}

//- ORBSMM_ModsView_syncReply (sync reply from the server)
ORBSMM_TCPManager.registerResponseHandler("SYNCADDON","ORBSMM_ModsView_syncReply");
function ORBSMM_ModsView_syncReply(%tcp,%line,%find)
{
   if(!isObject(ORBSMM_SyncMods_Window))
      return;
      
   %cache = getField(%tcp.t_rawString,2);
   
   if(%find)
      ORBSMM_ModsView_syncDisplay(1,%cache,getField(%line,1),getField(%line,2),getField(%line,3),getField(%line,4),getField(%line,5),getField(%line,6));
   else
      ORBSMM_ModsView_syncDisplay(0,%cache);
}

//- ORBSMM_ModsView_syncDisplay (adds a result to the sync gui)
function ORBSMM_ModsView_syncDisplay(%find,%cache,%file_id,%file_icon,%file_title,%file_author,%file_zip,%match)
{
   %rows = ORBSMM_SyncMods_Window.getCount()-1;
   %ySpace = (%rows*40) + (%rows+1) + 31;
   
   %container = new GuiSwatchCtrl()
   {
      position = "1" SPC %ySpace;
      extent = "556 40";
      color = "0 0 0 0";
   };
   ORBSMM_SyncMods_Window.add(%container);
   ORBSMM_SyncMods_Window.resize(1,1,558,%ySpace+40+1);
   
   %icon = new GuiSwatchCtrl()
   {
      position = "0 0";
      extent = "40 40";
      color = "230 230 230 255";
      
      new GuiBitmapCtrl()
      {
         position = "12 12";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/"@%cache.file_icon;
      };
   };
   %container.add(%icon);
   
   %info = new GuiSwatchCtrl()
   {
      position = "41 0";
      extent = "202 40";
      color = "230 230 230 255";
      
      new GuiMLTextCtrl()
      {
         position = "4 1";
         extent = "300 1";
         text = "<font:Arial Bold:14><color:777777>"@%cache.file_title;
      };
      
      new GuiMLTextCtrl()
      {
         position = "3 12";
         extent = "300 1";
         text = "<font:Arial:13><color:888888>by "@%cache.file_author;
      };
      
      new GuiMLTextCtrl()
      {
         position = "4 25";
         extent = "300 1";
         text = "<font:Arial:13><color:AAAAAA>"@%cache.file_zip;
      };
   };
   %container.add(%info);
   
   %icon = new GuiSwatchCtrl()
   {
      position = "244 0";
      extent = "40 40";
      color = "230 230 230 255";
      
      new GuiBitmapCtrl()
      {
         position = "0 12";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/bar_gray";
      };

      new GuiBitmapCtrl()
      {
         position = "8 12";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/bar_gray";
      };
      
      new GuiBitmapCtrl()
      {
         position = "16 12";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/bar_gray";
      };
      
      new GuiBitmapCtrl()
      {
         position = "24 12";
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/bar_gray";
      };
   };
   %container.add(%icon);
   
   %icon.getObject(0).setBitmap($ORBS::Path@"images/icons/bar_red");
   
   if(%find)
   {
      if(%match <= 50)
         %icon.getObject(0).setBitmap($ORBS::Path@"images/icons/bar_red");
      else if(%match < 70)
      {
         %icon.getObject(0).setBitmap($ORBS::Path@"images/icons/bar_yellow");
         %icon.getObject(1).setBitmap($ORBS::Path@"images/icons/bar_yellow");
      }
      else if(%match < 100)
      {
         %icon.getObject(0).setBitmap($ORBS::Path@"images/icons/bar_yellow");
         %icon.getObject(1).setBitmap($ORBS::Path@"images/icons/bar_yellow");
         %icon.getObject(2).setBitmap($ORBS::Path@"images/icons/bar_yellow");
      }
      else if(%match $= 100)
      {
         %icon.getObject(0).setBitmap($ORBS::Path@"images/icons/bar_green");
         %icon.getObject(1).setBitmap($ORBS::Path@"images/icons/bar_green");
         %icon.getObject(2).setBitmap($ORBS::Path@"images/icons/bar_green");
         %icon.getObject(3).setBitmap($ORBS::Path@"images/icons/bar_green");
      }
      
      %icon = new GuiSwatchCtrl()
      {
         position = "285 0";
         extent = "40 40";
         color = "230 230 230 255";
         
         new GuiBitmapCtrl()
         {
            position = "12 12";
            extent = "16 16";
            bitmap = $ORBS::Path@"images/icons/"@%file_icon;
         };
      };
      %container.add(%icon);
      
      %info = new GuiSwatchCtrl()
      {
         position = "326 0";
         extent = "202 40";
         color = "230 230 230 255";
         
         new GuiMLTextCtrl()
         {
            position = "4 1";
            extent = "300 1";
            text = "<font:Arial Bold:14><color:777777>"@%file_title;
         };
         
         new GuiMLTextCtrl()
         {
            position = "3 12";
            extent = "300 1";
            text = "<font:Arial:13><color:888888>by "@%file_author;
         };
         
         new GuiMLTextCtrl()
         {
            position = "4 25";
            extent = "300 1";
            text = "<font:Arial:13><color:AAAAAA>"@%file_zip;
         };
      };
      %container.add(%info);
      
      %tick = new GuiSwatchCtrl()
      {
         position = "529 0";
         extent = "27 40";
         color = "230 230 230 255";
         
         new GuiCheckboxCtrl()
         {
            profile = ORBS_CheckBoxProfile;
            position = "8 5";
            text = " ";
         };
      };
      %container.add(%tick);
      
      if(%match $= 100)
         %tick.getObject(0).setValue(1);
         
      %tick.getObject(0).cache = %cache;
      %tick.getObject(0).syncTarget = %file_id;
      $ORBS::CModManager::SyncResults::CBox[$ORBS::CModManager::SyncResults::CBoxes] = %tick.getObject(0);
      $ORBS::CModManager::SyncResults::CBoxes++;
   }
   else
   {
      %info = new GuiSwatchCtrl()
      {
         position = "285 0";
         extent = "243 40";
         color = "230 230 230 255";
         
         new GuiMLTextCtrl()
         {
            position = "24 3";
            extent = "195 32";
            text = "<font:Impact:32><color:D5D5D5><just:center>No Matches";
         };
      };
      %container.add(%info);
      
      %tick = new GuiSwatchCtrl()
      {
         position = "529 0";
         extent = "27 40";
         color = "230 230 230 255";
         
         new GuiCheckboxCtrl()
         {
            profile = ORBS_CheckBoxProfile;
            position = "8 5";
            text = " ";
         };
         
         new GuiSwatchCtrl()
         {
            position = "0 0";
            extent = "27 40";
            color = "0 0 0 20";
         };
      };
      %container.add(%tick);
   }
}

//- ORBSMM_ModsView_syncFinish (sync is complete so display results)
function ORBSMM_ModsView_syncFinish()
{
   $ORBS::CModManager::Sync::LoadOverlay.delete();
   
   %rows = ORBSMM_SyncMods_Window.getCount()-1;
   %ySpace = (%rows*40) + (%rows+1) + 31;
   
   %swatch = new GuiSwatchCtrl()
   {
      position = "1" SPC %ySpace;
      extent = "556 30";
      color = "215 215 215 255";
   };
   ORBSMM_SyncMods_Window.add(%swatch);
   ORBSMM_SyncMods_Window.resize(1,1,558,%ySpace+31);
}

//- ORBSMM_ModsView_syncComplete (process selected files)
function ORBSMM_ModsView_syncComplete()
{
   if($ORBS::CModManager::SyncResults::CBoxes <= 0)
   {
      ORBSMM_GUI_closeWindow(ORBSMM_SyncAddons);
      ORBSMM_GUI_createMessageBoxOK("Oh Dear","No matches could be found for your add-ons.");
      return;
   }
   
   for(%i=0;%i<$ORBS::CModManager::SyncResults::CBoxes;%i++)
   {
      if($ORBS::CModManager::SyncResults::CBox[%i].getValue() $= 1)
         %ticked++;
   }
   
   if(%ticked <= 0)
   {
      ORBSMM_GUI_createMessageBoxOK("Hmm?","You have not selected any add-ons to sync.");
      return;
   }
   
   for(%i=0;%i<$ORBS::CModManager::SyncResults::CBoxes;%i++)
   {
      if($ORBS::CModManager::SyncResults::CBox[%i].getValue() $= 1)
      {
         %cbox = $ORBS::CModManager::SyncResults::CBox[%i];
         %cache = %cbox.cache;
         %file = %cbox.syncTarget;
         
         fileDelete(%cache.file_path);
         %cache.delete();
         
         ORBSMM_TransferView_Add(%file);
      }
   }
   ORBSMM_TransferView_Init();
}

//- ORBSMM_ModsView_InitGroupsView (initates the groups view)
function ORBSMM_ModsView_InitGroupsView()
{
   %header = $ORBS::CModManager::Cache::SectionHeader;
   
   %header.getObject(1).setText("<color:FAFAFA><just:left><font:Impact:18>  Your Groups");
   
   %syncBtn = new GuiBitmapButtonCtrl()
   {
      position = "184 4";
      extent = "68 18";
      text = " ";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/create";
      command = "ORBSMM_ModsView_createGroupAsk();";
   };
   %header.add(%syncBtn);   
   
   $ORBS::CModManager::Cache::NumSections = 0;   
   
   if(ORBSMM_GroupManager.getCount() <= 0)
   {
      ORBSMM_GUI_createMessage("<br><br>You do not have any Add-On Groups.<br><br>");
      return;
   }
   else
   {
      %sortString = "";
      for(%i=0;%i<ORBSMM_GroupManager.getCount();%i++)
      {
         %group = ORBSMM_GroupManager.getObject(%i);
         %sortString = %sortString@%group.getID()@"=>"@%group.name@",";
      }
      %sortString = getSubStr(%sortString,0,strLen(%sortString)-1);
      %sortString = strReplace(sortFields(%sortString),",","\t");
      
      for(%i=0;%i<getFieldCount(%sortString);%i++)
      {
         %sort = strReplace(getField(%sortString,%i),"=>","\t");
         %id = getField(%sort,0);
         %name = getField(%sort,1);
         
         if($ORBS::CModManager::SectionCollapsed["G_"@%name])
            ORBSMM_ModsView_createGroupRow(%id,1);
         else
            ORBSMM_ModsView_createGroupRow(%id,0);
      }
   }
}

function ORBSMM_ModsView_createGroupRow(%group,%hide)
{
   %container = new GuiSwatchCtrl()
   {
      position = 0 SPC $ORBS::CModManager::GUI::CurrentY;
      extent = "680 28";
      color = "255 255 255 255";
   };
   ORBSMM_GUI_PushControl(%container);
   
   %container.sec_id = $ORBS::CModManager::Cache::NumSections;
   $ORBS::CModManager::Cache::Section[$ORBS::CModManager::Cache::NumSections] = %container;
   $ORBS::CModManager::Cache::NumSections++;
   
   %s = (%group.items $= 1)?"":"s";
   %header = ORBSMM_GUI_createHeader(1,"<just:left>        "@%group.name@"  <font:Arial:12>"@%group.items@" Add-On"@%s);
   
   %container.header = %header;
   %container.name = "G_"@%group.name;
   %container.files = %group.items;
   %bitmap = new GuiBitmapCtrl()
   {
      position = "5 6";
      extent = "16 16";
      bitmap = $ORBS::Path@"images/icons/arrowDown";
   };
   %header.add(%bitmap);
   %container.add(%header);
   %header.position = "0 0";
   %container.bitmap = %bitmap;
   
   %mouseEvent = new GuiMouseEventCtrl()
   {
      extent = "610 28";
      
      eventType = "sectionClick";
      eventCallbacks = "0001000";
      
      id = $ORBS::CModManager::Cache::NumSections-1;
      type = 1;
      
      container = %container;
   };
   %container.add(%mouseEvent);
   %container.mouseEvent = %mouseEvent;
   
   %add = new GuiBitmapButtonCtrl()
   {
      position = "620 5";
      extent = "16 16";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/add";
      text = " ";
      command = "ORBSMM_ModsView_groupAddonSelect("@%group@");";
   };
   %header.add(%add);
   
   %remove = new GuiBitmapButtonCtrl()
   {
      position = "640 5";
      extent = "16 16";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/removeSmall";
      text = " ";
      command = "ORBSMM_ModsView_removeGroup("@%group@");";
   };
   %header.add(%remove);

   %content = ORBSMM_GUI_createContent(1,40,100);
   %container.add(%content);
   %container.bringToFront(%content);
   
   %content.vertSizing = "top";
   %content.position = 0 SPC getWord(%container.extent,1);
   ORBSMM_ModsView_renderGroupContent(%content,%group);
   
   if(%hide)
   {
      %mouseEvent.type = 2;
      ORBSMM_ModsView_collapseSection($ORBS::CModManager::Cache::NumSections-1,1);
   }
}

//- ORBSMM_ModsView_renderGroupContent (renders the mod rows in the content control)
function ORBSMM_ModsView_renderGroupContent(%content,%group)
{
   if(%group.items <= 0)
   {
      %icon = new GuiBitmapCtrl()
      {
         position = "20" SPC ((%j*31)+15);
         extent = "16 16";
         bitmap = $ORBS::Path@"images/icons/help";
      };
      %content.add(%icon);
      
      %text = new GuiMLTextCtrl()
      {
         position = "40" SPC ((%j*31)+17);
         extent = "400 10";
         text = "<font:Verdana:12><color:888888>It looks like you don't have any add-ons in this group!";
      };
      %content.add(%text);

      %content.resize(getWord(%content.position,0),getWord(%content.position,1),getWord(%content.extent,0),getWord(%icon.position,1)+31);
      %content.getGroup().extent = vectorAdd(%content.getGroup().extent,"0" SPC getWord(%content.extent,1));
      %content.getGroup().originalHeight = getWord(%content.getGroup().extent,1);
      ORBSMM_GUI_AutoResize();
      return;
   }
   
   %sortString = "";
   for(%i=0;%i<%group.items;%i++)
   {
      %sortString = %sortString@%group.item[%i]@"=>"@%group.item[%i].file_title@",";
   }
   %sortString = getSubStr(%sortString,0,strLen(%sortString)-1);
   %sortString = strReplace(sortFields(%sortString),",","\t");
   
   for(%j=0;%j<getFieldCount(%sortString);%j++)
   {
      %field = strReplace(getField(%sortString,%j),"=>","\t");
      %id = getField(%field,0);

      if(%id.file_type $= "Unpackaged Add-Ons")
         %icon = $ORBS::Path@"images/icons/help";
      else if(%id.file_platform $= "bl")
         %icon = $ORBS::Path@"images/icons/blLogo";
      else
         %icon = $ORBS::Path@"images/icons/orbsLogo";

      %icon = new GuiBitmapCtrl()
      {
         position = "20" SPC ((%j*31)+15);
         extent = "16 16";
         bitmap = %icon;
      };
      %content.add(%icon);
      
      %text = new GuiMLTextCtrl()
      {
         position = "40" SPC ((%j*31)+17);
         extent = "400 10";
         text = "<font:Verdana Bold:12><color:666666>"@%id.file_title@" <font:Verdana:12><color:888888>by "@%id.file_author;
      };
      %content.add(%text);
      
      %text = new GuiMLTextCtrl()
      {
         position = "350" SPC ((%j*31)+17);
         extent = "400 10";
         text = "<font:Verdana Bold:12><color:666666>"@%id.file_type;
      };
      %content.add(%text);
      
      %text = new GuiMLTextCtrl()
      {
         position = "460" SPC ((%j*31)+17);
         extent = "400 10";
         text = "<font:Verdana:12><color:666666>"@%id.file_zip;
      };
      %content.add(%text);
      
      %remove = new GuiBitmapButtonCtrl()
      {
         position = "640" SPC ((%j*31)+15);
         extent = "16 16";
         bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/removeSmall";
         text = " ";
         command = "ORBSMM_ModsView_removeItem("@%group@","@%id@");";
      };
      %content.add(%remove);      
      
      if(%j > 0)
      {
         %divider = new GuiBitmapCtrl()
         {
            position = "15" SPC ((%j*31)+7);
            extent = "650 2";
            bitmap = $ORBS::Path@"images/ui/cellDivider_light";
         };  
         %content.add(%divider);
      }
   }
   %content.resize(getWord(%content.position,0),getWord(%content.position,1),getWord(%content.extent,0),getWord(%icon.position,1)+31);
   %content.getGroup().extent = vectorAdd(%content.getGroup().extent,"0" SPC getWord(%content.extent,1));
   %content.getGroup().originalHeight = getWord(%content.getGroup().extent,1);
   ORBSMM_GUI_AutoResize();
}

//- ORBSMM_ModsView_createGroupAsk (creates a prompt to make a group)
function ORBSMM_ModsView_createGroupAsk()
{
   %window = ORBSMM_GUI_createWindow("Create a Group");
   %window.resize(0,0,275,110);
   ORBSMM_GUI_Center(%window);
   
   %text = new GuiMLTextCtrl()
   {
      position = "5 5";
      extent = "300 10";
      text = "<font:Verdana:12><color:888888>Please enter a name for your new Group:";
   };
   %window.canvas.add(%text);
   
   %edit = new GuiTextEditCtrl()
   {
      profile = ORBS_TextEditProfile;
      position = "6 21";
      extent = "256 16";
      accelerator = "enter";
      altCommand = "ORBSMM_ModsView_createGroup($thisControl.getValue());ORBSMM_GUI_closeWindow("@%window@");";
   };
   %window.canvas.add(%edit);

   %button = new GuiBitmapButtonCtrl()
   {
      position = "205 43";
      extent = "58 25";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      text = " ";
      command = "ORBSMM_ModsView_createGroup("@%edit@".getValue());ORBSMM_GUI_closeWindow("@%window@");";
   };
   %window.canvas.add(%button);
}

//- ORBSMM_ModsView_createGroup (creates a new group)
function ORBSMM_ModsView_createGroup(%name,%skip)
{
   if(%name $= "")
   {
      if(!%skip)
      {
         ORBSMM_GUI_createMessageBoxOK("Ooops","You have not entered a name for your new group.");
         ORBSMM_ModsView_createGroupAsk();
      }
      return;
   }
   
   if(%group = ORBSMM_GroupManager.addGroup(%name))
   {
      if(!%skip)
         ORBSMM_ModsView_groupAddonSelect(%group,1);
      return %group;
   }
   else
   {
      if(!%skip)
         ORBSMM_GUI_createMessageBoxOK("Oh No!","You've already got a group called "@%name@".");
      return 0;
   }
}

//- ORBSMM_ModsView_groupAddonSelect (allows selection of included add-ons)
function ORBSMM_ModsView_groupAddonSelect(%group,%closeDelete)
{
   %window = ORBSMM_GUI_createWindow("Add-On Selector");
   %window.resize(0,0,315,500);
   ORBSMM_GUI_Center(%window);
   
   if(%closeDelete)
   {
      %window.closeButton.command = %window.closeButton.command@%group@".delete();ORBSMM_GroupManager.saveDat();";
   }
  
   %text = new GuiMLTextCtrl()
   {
      position = "8 8";
      extent = "280 1";
      text = "<color:666666><font:Arial:13>Browse the list and tick/untick the add-ons you want to be in this group. You can have as many as you want.";
   };
   %window.canvas.add(%text);
   
   %parent = new GuiSwatchCtrl()
   {
      position = "7 40";
      extent = "277 380";
      color = "200 200 200 255";
      
      new GuiSwatchCtrl()
      {
         position = "1 1";
         extent = "275 378";
         color = "245 245 245 255";
      };
   };
   %window.canvas.add(%parent);
   
   %scroll = new GuiScrollCtrl()
   {
      profile = ORBS_ScrollProfile;
      position = "7 40";
      extent = "292 379";
      hScrollBar = "AlwaysOff";
      
      new GuiSwatchCtrl(ORBSMM_GroupSelect_Window)
      {
         position = "1 1";
         extent = "558 298";
         color = "0 0 0 0";
         
         new GuiSwatchCtrl()
         {
            position = "1 1";
            extent = "558 30";
            color = "0 0 0 0";
            
            new GuiSwatchCtrl()
            {
               position = "0 0";
               extent = "242 30";
               color = "215 215 215 255";
               
               new GuiMLTextCtrl()
               {
                  position = "35 8";
                  extent = "172 14";
                  text = "<just:center><color:888888><font:Arial Bold:14>Add-On";
               };
            };
            
            new GuiSwatchCtrl()
            {
               position = "243 0";
               extent = "30 30";
               color = "215 215 215 255";
            };
         };
      };
   };
   %window.canvas.add(%scroll);
   
   %allBtn = new GuiBitmapButtonCtrl()
   {
      position = "10 432";
      extent = "21 18";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/all";
      command = "ORBSMM_ModsView_selectAll("@%window@");";
      text = " ";
   };
   %window.canvas.add(%allBtn);
   
   %enabledBtn = new GuiBitmapButtonCtrl()
   {
      position = "32 435";
      extent = "50 15";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/enabled";
      command = "ORBSMM_ModsView_selectEnabled("@%window@");";
      text = " ";
   };
   %window.canvas.add(%enabledBtn);  
   
   %enabledBtn = new GuiBitmapButtonCtrl()
   {
      position = "83 435";
      extent = "34 15";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/none";
      command = "ORBSMM_ModsView_selectNone("@%window@");";
      text = " ";
   };
   %window.canvas.add(%enabledBtn);  
   
   %okBtn = new GuiBitmapButtonCtrl()
   {
      position = "225 430";
      extent = "58 25";
      bitmap = $ORBS::Path@"images/ui/buttons/modManager/interface/ok";
      command = "ORBSMM_ModsView_saveAddOnSelection("@%window@","@%group@");";
      text = " ";
   };
   %window.canvas.add(%okBtn);
   
   %numCats = 0;
   $ORBS::CModManager::GroupSelect::CBoxes = 0;
   for(%i=0;%i<ORBSMM_FileCache.getCount();%i++)
   {
      %cache = ORBSMM_FileCache.getObject(%i);
      if(%cache.file_special !$= "")
         continue;
         
      %sorter[%cache.file_type] = %sorter[%cache.file_type]@%cache@"=>"@%cache.file_title@",";
       
      if(!%added[%cache.file_type])
      {
         %cat[%numCats] = %cache.file_type;
         %numCats++;
         
         %added[%cache.file_type] = 1;
      }
   }
   
   for(%i=0;%i<%numCats;%i++)
   {
      %catSorter = %catSorter@%i@"=>"@%cat[%i]@",";
   }
   %catSorter = getSubStr(%catSorter,0,strLen(%catSorter)-1);
   %cats = strReplace(sortFields(%catSorter),",","\t");
   
   for(%i=0;%i<getFieldCount(%cats);%i++)
   {
      %cat = strReplace(getField(%cats,%i),"=>","\t");
      
      if(%sorter[getField(%cat,1)] $= "")
         continue;      
      
      %rows = ORBSMM_GroupSelect_Window.getCount()-1;
      %ySpace = (%rows*40) + (%rows+1) + 31;
      
      %container = new GuiSwatchCtrl()
      {
         position = "1" SPC %ySpace;
         extent = "275 40";
         color = "0 0 0 0";
      };
      ORBSMM_GroupSelect_Window.add(%container);
      ORBSMM_GroupSelect_Window.resize(1,1,558,%ySpace+40);
      
      %check = new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = "273 40";
         color = "225 225 225 255";
         
         new GuiBitmapCtrl()
         {
            position = "8 12";
            extent = "16 16";
            bitmap = $ORBS::Path@"images/icons/arrowRight";
         };
         
         new GuiMLTextCtrl()
         {
            position = "24 14";
            extent = "200 16";
            text = "<font:Arial Bold:14><color:888888> "@getField(%cat,1);
         };
         
         new GuiCheckboxCtrl()
         {
            profile = ORBS_CheckBoxProfile;
            position = "251 13";
            extent = "16 16";
            text = " ";
            catBox = getField(%cat,1);
            command = "ORBSMM_ModsView_clickGroupCat($thisControl);";
            numEnabled = 0;
            numItems = 0;
         };
      };
      %container.add(%check);
      %catCheck = %check.getObject(2);
      $ORBS::CModManager::GroupSelect::CBox[$ORBS::CModManager::GroupSelect::CBoxes] = %check.getObject(2);
      $ORBS::CModManager::GroupSelect::CBoxes++;
      
      %sorter[getField(%cat,1)] = getSubStr(%sorter[getField(%cat,1)],0,strLen(%sorter[getField(%cat,1)])-1);
      %mods = strReplace(sortFields(%sorter[getField(%cat,1)]),",","\t");
      
      for(%j=0;%j<getFieldCount(%mods);%j++)
      {
         %mod = strReplace(getField(%mods,%j),"=>","\t");
         %cache = getField(%mod,0);
            
         %rows = ORBSMM_GroupSelect_Window.getCount()-1;
         %ySpace = (%rows*40) + (%rows+1) + 31;
         
         %container = new GuiSwatchCtrl()
         {
            position = "1" SPC %ySpace;
            extent = "275 40";
            color = "0 0 0 0";
         };
         ORBSMM_GroupSelect_Window.add(%container);
         ORBSMM_GroupSelect_Window.resize(1,1,558,%ySpace+40);
         
         %icon = new GuiSwatchCtrl()
         {
            position = "0 0";
            extent = "40 40";
            color = "230 230 230 255";
            
            new GuiBitmapCtrl()
            {
               position = "12 12";
               extent = "16 16";
               bitmap = $ORBS::Path@"images/icons/"@%cache.file_icon;
            };
         };
         %container.add(%icon);
         
         %info = new GuiSwatchCtrl()
         {
            position = "41 0";
            extent = "201 40";
            color = "230 230 230 255";
            
            new GuiMLTextCtrl()
            {
               position = "4 1";
               extent = "300 1";
               text = "<font:Arial Bold:14><color:777777>"@%cache.file_title;
            };
            
            new GuiMLTextCtrl()
            {
               position = "3 12";
               extent = "300 1";
               text = "<font:Arial:13><color:888888>by "@%cache.file_author;
            };
            
            new GuiMLTextCtrl()
            {
               position = "4 25";
               extent = "300 1";
               text = "<font:Arial:13><color:AAAAAA>"@%cache.file_zip;
            };
         };
         %container.add(%info);
         
         %check = new GuiSwatchCtrl()
         {
            position = "243 0";
            extent = "30 40";
            color = "230 230 230 255";
            
            new GuiCheckBoxCtrl()
            {
               profile = ORBS_CheckBoxProfile;
               position = "8 12";
               extent = "16 16";
               text = " ";
               catCheck = %catCheck;
               command = "ORBSMM_ModsView_clickGroupMod($thisControl);";
            };
         };
         %container.add(%check);

         if(%group.hasItem(%cache.file_zipname))
         {
            %check.getObject(0).setValue(1);
            %catCheck.numEnabled++;
         }
         %catCheck.numItems++;            
            
         %check.getObject(0).cache = %cache;
         $ORBS::CModManager::GroupSelect::CBox[$ORBS::CModManager::GroupSelect::CBoxes] = %check.getObject(0);
         $ORBS::CModManager::GroupSelect::CBoxes++;
      }
      
      if(%catCheck.numEnabled >= %catCheck.numItems)
         %catCheck.setValue(1);
   }
}

//- ORBSMM_ModsView_clickGroupCat (click for a category box of the selector)
function ORBSMM_ModsView_clickGroupCat(%this)
{
   for(%i=0;%i<$ORBS::CModManager::GroupSelect::CBoxes;%i++)
   {
      %cbox = $ORBS::CModManager::GroupSelect::CBox[%i];
      if(%cbox.cache.file_type $= %this.catBox)
      {
         %cbox.setValue(%this.getValue());   
         %this.numEnabled++;
      }
   }
   
   if(%this.numEnabled > %this.numItems)
      %this.numEnabled = %this.numItems;
}

//- ORBSMM_ModsView_clickGroupMod (click for a mod in a category of the selector)
function ORBSMM_ModsView_clickGroupMod(%this)
{
   if(%this.getValue() $= 1)
      %this.catCheck.numEnabled++;
   else
      %this.catCheck.numEnabled--;
      
   if(%this.catCheck.numEnabled >= %this.catCheck.numItems)
   {
      %this.catCheck.numEnabled = %this.catCheck.numItems;
      %this.catCheck.setValue(1);
   }
   else
      %this.catCheck.setValue(0);
}

//- ORBSMM_ModsView_selectAll (checks all boxes in the group add-on selector)
function ORBSMM_ModsView_selectAll(%window)
{
   for(%i=0;%i<$ORBS::CModManager::GroupSelect::CBoxes;%i++)
   {
      %cbox = $ORBS::CModManager::GroupSelect::CBox[%i];
      %cbox.setValue(1);
      if(%cbox.numItems !$= "")
         %cbox.numEnabled = %cbox.numItems;
   }
}

//- ORBSMM_ModsView_selectEnabled (checks all boxes that are currently enabled)
function ORBSMM_ModsView_selectEnabled(%window)
{
   ORBSMM_ModsView_selectNone();
   for(%i=0;%i<$ORBS::CModManager::GroupSelect::CBoxes;%i++)
   {
      %cbox = $ORBS::CModManager::GroupSelect::CBox[%i];
      if($AddOn__[%cbox.cache.file_var] $= 1)
      {
         %cbox.setValue(1);
         ORBSMM_ModsView_clickGroupMod(%cbox);
      }
   }
}

//- ORBSMM_ModsView_selectNone (unchecks all boxes in the group add-on selector)
function ORBSMM_ModsView_selectNone(%window)
{
   for(%i=0;%i<$ORBS::CModManager::GroupSelect::CBoxes;%i++)
   {
      %cbox = $ORBS::CModManager::GroupSelect::CBox[%i];
      %cbox.setValue(0);
      if(%cbox.numItems !$= "")
         %cbox.numEnabled = 0;
   }
}

//- ORBSMM_ModsView_saveAddOnSelection (saves the current selection of add-ons)
function ORBSMM_ModsView_saveAddOnSelection(%window,%group)
{
   %group.items = 0;
   for(%i=0;%i<$ORBS::CModManager::GroupSelect::CBoxes;%i++)
   {
      %cbox = $ORBS::CModManager::GroupSelect::CBox[%i];
      if(%cbox.getValue() $= 1 && %cbox.cache !$= "")
      {
         %group.item[%group.items] = %cbox.cache;
         %group.items++;
      }
   }
   ORBSMM_GroupManager.saveDat();
   ORBSMM_GUI_closeWindow(%window);
   schedule(1,0,"ORBSMM_ModsView_Init","groups");
}

//- ORBSMM_ModsView_removeItem (removes an item from a group)
function ORBSMM_ModsView_removeItem(%group,%id)
{
   %group.removeItem(%id);
   
   ORBSMM_GroupManager.saveDat();
   schedule(1,0,"ORBSMM_ModsView_Init","groups");
}

//- ORBSMM_ModsView_removeGroup (removes a group)
function ORBSMM_ModsView_removeGroup(%id,%conf)
{
   if(!%conf)
   {
      ORBSMM_GUI_createMessageBoxOKCancel("Fo real?","Are you sure you want to delete this group:<br><br><lmargin:10>"@%id.name@" containing "@%id.items@" add-ons?","ORBSMM_ModsView_removeGroup("@%id@",1);");
      return;
   }
   %id.delete();
   ORBSMM_GroupManager.saveDat();
   schedule(1,0,"ORBSMM_ModsView_Init","groups");
}

//*********************************************************
//* Update Manager
//*********************************************************
//- ORBSMM_checkForUpdates (searches for updates for add-ons the user has)
function ORBSMM_checkForUpdates()
{
   %fo = new FileObject();
   
   %filepath = findFirstFile("Add-Ons/*_*/orbsInfo.txt");
   while(strlen(%filepath) > 0)
   {
      %f_id = "";
      %f_version = "";
      %fo.openForRead(%filepath);
      
      %oldMod = 0;
      while(!%fo.isEOF())
      {
         %line = %fo.readLine();
         if(strPos(%line,"Name:") $= 0)
         {
            %oldMod = 1;
            break;
         }
         if(getWord(%line,0) $= "id:")
            %f_id = getWord(%line,1);
         if(getWord(%line,0) $= "version:")
            %f_version = getWord(%line,1);
      }
      %fo.close();
      
      if(%oldMod)
      {
         %filepath = findNextFile("Add-Ons/*_*/orbsInfo.txt");
         continue;
      }

      if(%f_id > 0 && %f_version > 0)
      {
         %files = %files@%f_id@"-"@%f_version@".";
      }
      %filepath = findNextFile("Add-Ons/*_*/orbsInfo.txt");
   }
   %fo.delete();

   if(strLen(%files) > 1)
      %files = getSubStr(%files,0,strLen(%files)-1);
   else
      return;

   ORBSMM_SendRequest("GETUPDATES",1,%files);
}

//- ORBSMM_onModUpdatesStart (callback for start of transmission)
function ORBSMM_onModUpdatesStart()
{
   ORBS_ModUpdates_Window.clear();
   ORBS_ModUpdates_Window.resize(1,1,332,201);
   
   $ORBS::CModManager::ModUpdates = 0;
}

//- ORBSMM_onModUpdates (reply after requesting updates)
ORBSMM_TCPManager.registerResponseHandler("GETUPDATES","ORBSMM_onModUpdates");
function ORBSMM_onModUpdates(%tcp,%line)
{
   if(getField(%line,0) $= 1)
   {
      Canvas.pushDialog(ORBS_ModUpdates);
      
      $ORBS::CModManager::ModUpdate[$ORBS::CModManager::ModUpdates] = getField(%line,1);
      $ORBS::CModManager::ModUpdates++;
      ORBSMM_UpdateManager_addUpdate(getField(%line,2),getField(%line,3),getField(%line,4),getField(%line,5),getField(%line,6),getField(%line,7));
   }
}

//- ORBSMM_UpdateManager_addUpdate (adds an update row to the gui)
function ORBSMM_UpdateManager_addUpdate(%icon,%title,%authors,%version,%date,%currVersion)
{
   %count = ORBS_ModUpdates_Window.getCount();
   %position = (45*%count) + %count;
   
   %container = new GuiSwatchCtrl()
   {
      position = "0" SPC %position;
      extent = "332 45";
      color = "0 0 0 0";
      
      new GuiSwatchCtrl()
      {
         position = "0 0";
         extent = "45 45";
         color = "220 220 220 255";
         
         new GuiBitmapCtrl()
         {
            position = "14 14";
            extent = "16 16";
            bitmap = "Add-Ons/System_oRBs/images/icons/"@%icon;
         };
      };
      
      new GuiSwatchCtrl()
      {
         position = "46 0";
         extent = "300 45";
         color = "210 210 210 255";
         
         new GuiMLTextCtrl()
         {
            position = "4 2";
            extent = "280 23";
            text = "<font:Arial Bold:14><color:666666>"@%title@"<just:right><font:Arial:13>You have version "@%currVersion;
         };
         
         new GuiMLTextCtrl()
         {
            position = "4 15";
            extent = "300 23";
            text = "<font:Arial:13><color:888888>"@%authors;
         };
         
         new GuiMLTextCtrl()
         {
            position = "4 30";
            extent = "280 23";
            text = "<font:Verdana Bold:12><color:777777>Version "@%version@"<just:right><font:Arial:13>"@%date;
         };
      };
   };
   ORBS_ModUpdates_Window.add(%container);
   ORBS_ModUpdates_Window.resize(1,1,332,getWord(%container.position,1)+getWord(%container.extent,1));
}

//- ORBSMM_downloadUpdates (downloads all updates found)
function ORBSMM_downloadUpdates()
{
   for(%i=0;%i<$ORBS::CModManager::ModUpdates;%i++)
   {
      ORBSMM_TransferView_Add($ORBS::CModManager::ModUpdate[%i]);
   }
   Canvas.popDialog(ORBS_ModUpdates);
   ORBSMM_OpenModManager();
   ORBSMM_TransferView_Init();
}

//#####################################################################################################
//
//     _____                              _   
//    / ____|                            | |  
//   | (___  _   _ _ __  _ __   ___  _ __| |_ 
//    \___ \| | | | '_ \| '_ \ / _ \| '__| __|
//    ____) | |_| | |_) | |_) | (_) | |  | |_ 
//   |_____/ \__,_| .__/| .__/ \___/|_|   \__|
//                | |   | |                   
//                |_|   |_|                   
//
//
//##################################################################################################### 

//*********************************************************
//* Group Class
//*********************************************************
if(!isObject(ORBSMM_GroupManager))
{
   new ScriptGroup(ORBSMM_GroupManager);
   ORBSGroup.add(ORBSMM_GroupManager);
}

//- ORBSMM_GroupManager::load (loads the existing groups.dat file)
function ORBSMM_GroupManager::loadDat(%this)
{
   %this.clear();
   %this.numGroups = 0;
   %this.loaded = 1;
   
   if(isFile("config/client/orbs/groups.dat"))
   {
      %fo = new FileObject();
      if(%fo.openForRead("config/client/orbs/groups.dat"))
      {
         while(!%fo.isEOF())
         {
            %number++;
            %line = %fo.readLine();
         
            if(%number%2)
            {
               %group = %this.addGroup(%line);
               
               if(!isObject(%group))
               {
                  %fo.readLine();
                  continue;
               }
            }
            else
            {
               if(!isObject(%group))
               {
                  %fo.delete();
                  echo("\c2ERROR: Parse error in groups.dat (ORBSMM_GroupManager::load)");
                  return;
               }
               
               %line = strReplace(%line,",","\t");
               for(%i=0;%i<getFieldCount(%line);%i++)
               {
                  %group.addItem(getField(%line,%i));
               }
            }
         }
      }
      %fo.delete();
   }
}

//- ORBSMM_GroupManager::save (saves the group manager)
function ORBSMM_GroupManager::saveDat(%this)
{
   %fo = new FileObject();
   if(!%fo.openForWrite("config/client/orbs/groups.dat"))
   {
      echo("\c2ERROR: Unable to write to groups.dat (ORBSMM_GroupManager::save)");
      %fo.delete();
      return;
   }
   
   for(%i=0;%i<%this.getCount();%i++)
   {
      %itemLine = "";
      %group = %this.getObject(%i);
      %fo.writeLine(%group.name);
      for(%j=0;%j<%group.items;%j++)
      {
         %itemLine = %itemLine@%group.item[%j].file_zipname@",";
      }
      if(%itemLine !$= "")
         %itemLine = getSubStr(%itemLine,0,strLen(%itemLine)-1);
      %fo.writeLine(%itemLine);
   }
   %fo.close();
   %fo.delete();
}

//- ORBSMM_GroupManager::addGroup (creates a new group)
function ORBSMM_GroupManager::addGroup(%this,%name)
{
   if(%this.hasGroup(%name))
      return 0;
      
   %group = new ScriptObject()
   {
      class = "ORBS_Group";
      
      name = %name;
      items = 0;
   };
   %this.add(%group);
   
   return %group;
}

//- ORBSMM_GroupManager::hasGroup (checks if a group exists)
function ORBSMM_GroupManager::hasGroup(%this,%name)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).name $= %name)
         return 1;
   }
   return 0;
}

//- ORBSMM_GroupManager::deleteGroup (deletes an existing group)
function ORBSMM_GroupManager::deleteGroup(%this,%name)
{
   if(!%this.hasGroup(%name))
      return 0;
      
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).name $= %name)
      {
         %this.getObject(%i).delete();
         %this.saveDat();
         return 1;
      }
   }
   return 0;
}

//- ORBS_Group::addItem (adds an item to a group)
function ORBS_Group::addItem(%this,%zip)
{
   if(%this.hasItem(%zip))
      return;
      
   if(ORBSMM_FileCache.getByZip(%zip))
   {
      %this.item[%this.items] = ORBSMM_FileCache.getByZip(%zip);
      %this.items++;
   }
}

//- ORBS_Group::hasItem (checks if this group already has this item)
function ORBS_Group::hasItem(%this,%zip)
{
   for(%i=0;%i<%this.items;%i++)
   {
      if(%this.item[%i].file_zipname $= %zip)
         return 1;
   }
   return 0;
}

//- ORBS_Group::removeItem (removes an item from a group)
function ORBS_Group::removeItem(%this,%id)
{
   if(!%this.hasItem(%id.file_zipname))
      return;

   %k = 0;
   for(%i=0;%i<%this.items;%i++)
   {
      if(%this.item[%i] $= %id)
         continue;
      %this.item[%k] = %this.item[%i];
      %k++;
   }
   %this.items--;
}

//*********************************************************
//* Transfer Queue
//*********************************************************
if(!isObject(ORBSMM_TransferQueue))
{
   new ScriptGroup(ORBSMM_TransferQueue);
   ORBSGroup.add(ORBSMM_TransferQueue);
}

//- ORBSMM_TransferQueue::items (Dumps out a list of items in the queue)
function ORBSMM_TransferQueue::items(%this)
{
   echo(%this.getCount()@" items");
   echo("----------------------------------------");
}

//- ORBSMM_TransferQueue::getItem (Returns the scriptobject of the file id in the transfer list)
function ORBSMM_TransferQueue::getItem(%this,%id)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).id $= %id)
         return %this.getObject(%i);
   }
   return 0;
}

//- ORBSMM_TransferQueue::getItemPos (Gets the physical item position in the transfer queue)
function ORBSMM_TransferQueue::getItemPos(%this,%id)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).id $= %id)
         return %i;
   }
   return 0;
}

//- ORBSMM_TransferQueue::hasItem (Returns whether queue has an item with the specified id in the queue)
function ORBSMM_TransferQueue::hasItem(%this,%id)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).id $= %id)
         return %this.getObject(%i);
   }
   return 0;
}

//- ORBSMM_TransferQueue::updateIndicator (Updates the indicator on the transfers button with number of transfers)
function ORBSMM_TransferQueue::updateIndicator(%this)
{
   ORBSMM_GUI_setTransfers(%this.getCount());
}

//- ORBSMM_TransferQueue::addItem (Adds a file id to the transfer queue and grabs the data for it)
function ORBSMM_TransferQueue::addItem(%this,%id,%contentOnly,%group)
{
   if(%this.hasItem(%id))
      return 0;
      
   %item = new ScriptObject()
   {
      class = "TransferItem";
      
      id = %id;
      title = "File "@%id;
      desc = "Downloading Details...";
      progress_text = "Downloading Details...";
      
      content_only = %contentOnly;      
      
      zip = "";
      
      speed = "0b/s";
      progress = 0;
      filesize = 0;
      completed = 0;
      
      status = 1;
      
      live = 0;
      
      group = %group;
   };
   %this.add(%item);
   
   %item.update();
   ORBSMM_SendRequest("GETFILEDATA",3,%id);
   
   %this.updateIndicator();

   ORBSMM_FileGrabber.poke();   
   
   return %item;
}

//- TransferItem::update (Updates the physical gui with new information in the transfer item object)
function TransferItem::update(%this,%force)
{
   if($ORBS::CModManager::Cache::CurrentZone $= "TransferView" && ORBS_ModManager.isOpen())
   {
      if(%force || !isObject(%this.g_row))
         ORBSMM_TransferView_Init();
      else
      {
         %this.g_title.setValue("<color:666666><font:Verdana Bold:13>"@%this.title);
         %this.g_desc.setValue("<color:999999><font:Verdana Bold:12>"@%this.desc);
         
         %this.g_speed.setValue("<just:right><color:999999><font:Verdana:12>"@%this.speed);
         %this.g_done.setValue("<just:right><color:999999><font:Verdana:12>"@byteRound(%this.done)@"/"@byteRound(%this.filesize));
         
         %this.g_progress.setValue(%this.progress/100);
         
         %this.g_transfer.setActive(1);
         %this.g_cancel.setActive(1);
         %this.g_up.setActive(1);         
         %this.g_down.setActive(1);
         
         for(%i=0;%i<ORBSMM_TransferQueue.getCount();%i++)
         {
            if(ORBSMM_TransferQueue.getObject(%i) $= %this)
               break;
         }
         
         if(%i == 0)
            %this.g_up.setActive(0);
         if(%i == ORBSMM_TransferQueue.getCount()-1)
            %this.g_down.setActive(0);
         
         if(%this.completed)
         {
            %this.g_transfer.setActive(0);
            %this.g_cancel.setActive(0);
            %this.g_up.setActive(0);
            %this.g_down.setActive(0);
         }
         
         if(%this.transferring)
         {
            %this.g_transfer.setBitmap($ORBS::Path@"images/ui/buttons/modManager/interface/cancelTransfer");
            %this.g_transfer.command = "ORBSMM_TransferView_HaltTransfer("@%i@");";
         }
         else
         {
            %this.g_transfer.setBitmap($ORBS::Path@"images/ui/buttons/modManager/interface/transfer");
            %this.g_transfer.command = "ORBSMM_TransferView_RequestTransfer("@%i@");";
         }
         
         if(%this.status == 1)
         {
            %this.g_progress.setVisible(1);
            %this.g_red.setVisible(0);
            %this.g_progress_text.setValue("<just:center><font:Verdana:12><color:999999>"@%this.progress_text);
         }
         else if(%this.status == 0)
         {
            %this.g_progress.setValue(0);
            %this.g_progress.setVisible(0);
            %this.g_red.setVisible(1);
            %this.g_progress_text.setValue("<just:center><font:Verdana Bold:12><color:FFEEEE>"@%this.progress_text);
         }
      }
   }
   
   if(ORBS_ServerInformation.isAwake())
   {
      if(!isObject(%this.sg_statusSW))
         return;
         
      %this.sg_statusSW.setVisible(1);
      %this.sg_dlBtn.setVisible(1);
      
      if(%this.transferring)
      {
         %this.sg_dlBtn.setVisible(0);
      }
      %this.sg_statusSW.getObject(0).setValue("<font:Verdana:12><color:999999>"@%this.progress_text);
         
      for(%i=0;%i<%this.sg_progStd.getCount();%i++)
      {
         if(%this.progress >= ((100/8)*(%i+1)))
            %this.sg_progStd.getObject(%i).setBitmap($ORBS::Path@"images/icons/bullet_green");
      }
         
      if(%this.status == 1)
      {
         %this.sg_progStd.setVisible(1);
         %this.sg_progRed.setVisible(0);
      }
      else if(%this.status == 0)
      {
         %this.sg_progRed.setVisible(1);
         %this.sg_progStd.setVisible(0);
      }
      
      if(%this.completed)
      {
         %this.sg_indicator.setBitmap($ORBS::Path@"images/icons/tick");
      }
   }
   
   if(Canvas.getContent().getName() $= "LoadingGui")
   {
      if(!%this.live)
      {
         LoadingProgressTxt.setText("RETRIEVING ORBS ADD-ON DETAILS");
         return;
      }

      if(%this.transferring)
      {
         %addonsDone = $ORBS::CContentDownload::Addons-ORBSMM_TransferQueue.getCount();
         LoadingProgress.setValue((%addonsDone/$ORBS::CContentDownload::Addons) + ((1/$ORBS::CContentDownload::Addons) * (%this.progress/100)));
      }
      
      if(ORBSMM_TransferQueue.getObject(0) $= %this)
         LoadingProgressTxt.setText("Downloading " @ %this.zip @ " ...");
         
      if(%this.completed && %this.id = $ORBS::CContentDownload::Cache::Map)
      {
         if(isFile($ORBS::CContentDownload::Cache::MapImage@".png") || isFile($ORBS::CContentDownload::Cache::MapImage@".jpg"))
            LOAD_MapPicture.setBitmap($ORBS::CContentDownload::Cache::MapImage);
      }
   }
}

//- ORBSMM_TransferQueue::removeItem (Removes an item from the transfer queue)
function ORBSMM_TransferQueue::removeItem(%this,%id)
{
   if(%item = %this.getItem(%id))
   {
      if(ORBSMM_FileGrabber.halted && ORBSMM_FileGrabber.halter $= %item)
         ORBSMM_FileGrabber.halted = 0;
         
      %position = %this.getItemPos(%id);
      %item.delete();
      if(%position < ORBSMM_TransferQueue.getCount())
         ORBSMM_TransferQueue.pushToBack(ORBSMM_TransferQueue.getObject(%position));
      if($ORBS::CModManager::Cache::CurrentZone $= "TransferView" && ORBS_ModManager.isOpen())
         ORBSMM_TransferView_Init();
      %this.updateIndicator();
      
      if(Canvas.getContent().getName() $= "LoadingGui")
         if(%this.getCount() <= 0)
         {
            $ORBS::CContentDownload::Cache::Downloading = 0;
            commandtoserver('MissionPreparePhase1End');
         }
   }
}

//*********************************************************
//* Add-Ons Cache (No more RM faggotry)
//*********************************************************
if(!isObject(ORBSMM_FileCache))
{
   new ScriptGroup(ORBSMM_FileCache)
   {
      class = "FileCache";
      
      refreshTime = 0;
   };
   ORBSGroup.add(ORBSMM_FileCache);
}

//- FileCache::refresh (Refreshes the list of files discovered by the FC)
function FileCache::refresh(%this)
{
   %this.clear();
   %this.refreshTime = getSimTime();
   
   for(%i=0;%i<ORBS_FileCache.getCount();%i++)
   {
      %file = ORBS_FileCache.getObject(%i);
      %this.addPath(%file.path);
   }
   %this.refreshed = 1;
}

//- FileCache::list (Lits all files in the cache)
function FileCache::list(%this)
{
   echo(%this.getCount());
   echo("-----------------------------------------------");
   for(%i=0;%i<%this.getCount();%i++)
   {
      echo(%this.getObject(%i).file_path SPC "\c2" @ %this.getObject(%i).file_zipname@"\c0 ("@%this.getObject(%i).file_type@")");
   }
   echo("");
}

//- FileCache::addPath (Adds a path to the file cache)
function FileCache::addPath(%this,%filepath)
{
   if(!ORBS_FileCache.hasPath(%filepath))
      ORBS_FileCache.addPath(%filepath);
      
   if(!ORBS_FileCache.hasPath(%filepath))
      return false;
   
   %masterCache = ORBS_FileCache.getByPath(%filepath);   
   
   if(%this.exists(%filepath))
   {
      %oldCacheId = %this.getByPath(%filepath);
      %this.removeFile(%filepath);
   }
   
   %file = new ScriptObject()
   {
      //standard props
      file_zip = %masterCache.zip;
      file_zipname = %masterCache.zipname;
      file_path = %masterCache.path;
      file_title = %masterCache.title;
      file_author = %masterCache.author;
      file_desc = %masterCache.description;
      file_size = %masterCache.filesize;
      file_var = %masterCache.variableName;
      
      //management props
      file_platform = %masterCache.platform;
      file_isContent = %masterCache.isContent;
      
      //public props
      file_type = %masterCache.type;         
      
      //orbs props
      file_id = %masterCache.id;
      file_icon = %masterCache.icon;
      file_version = %masterCache.version;
   };
   %this.add(%file);

   if(!isFile(%filepath))
   {
      %file.file_type = "Unpackaged Add-Ons";
      %file.file_icon = "help";
      %file.file_default = 1;
   }
   else if(%file.file_isContent)
   {
      %file.file_type = "Content-Only Add-Ons";
      %file.file_icon = "package_green";
   }
   else if(!%file.file_id)
   {
      for(%i=0;%i<$ORBS::CModManager::DefaultBLMods;%i++)
      {
         %file.file_type = "Non-ORBS Add-Ons";
         %mod = $ORBS::CModManager::DefaultBLMod[%i];
         if(%mod $= fileBase(%filepath))
         {
            %file.file_default = 1;
            %file.file_type = "Default Add-Ons";
            break;
         }
      }
      %file.file_icon = "blLogo";
      %file.file_platform = "bl";
   }
      
   if(%file.file_platform $= "orbs2")
   {
     %file.file_icon = "link_break";
     %file.file_type = "ORBS2 Add-Ons";
   }
      
   if(getSubStr(fileBase(%filepath),0,4) $= "Map_")
      %file.file_special = "map";
   else if(getSubStr(fileBase(%filepath),0,6) $= "Decal_" || getSubStr(fileBase(%filepath),0,5) $= "Face_")
      %file.file_special = "decal";
   else if(isFile("Add-Ons/"@fileBase(%filepath)@"/client.cs") && !isFile("Add-Ons/"@fileBase(%filepath)@"/server.cs"))
      %file.file_special = "clientside";
   else if(getSubStr(fileBase(%filepath),0,9) $= "Colorset_")
      %file.file_special = "colorset";
   else
      %file.file_special = "";
         
   if(!clientIsValidAddOn(fileBase(%filepath),1))
      return;
      
   if(%oldCacheId !$= "")
   {
      for(%i=0;%i<ORBSMM_GroupManager.getCount();%i++)
      {
         %group = ORBSMM_GroupManager.getObject(%i);
         for(%j=0;%j<%group.items;%j++)
         {
            if(%group.item[%j] $= %oldCacheId)
               %group.item[%j] = %file;
         }
      }
   }
   return %file;
}

//- FileCache::get (Returns the cache record for the file id)
function FileCache::get(%this,%id)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).file_id $= %id)
         return %this.getObject(%i);
   }
   return 0;
}

//- FileCache::getByPath (Returns the cache record for the filepath)
function FileCache::getByPath(%this,%path)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).file_path $= %path)
         return %this.getObject(%i);
   }
   return 0;
}

//- FileCache::getByZip (Returns the cache record for the zip)
function FileCache::getByZip(%this,%zip)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).file_zipname $= %zip)
         return %this.getObject(%i);
   }
   return 0;
}

//- FileCache::exists (Checks to see if the file cache knows about a file)
function FileCache::exists(%this,%filepath)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).file_path $= %filepath)
         return 1;
   }
   return 0;
}

//- FileCache::removeFile (Removes a file from the cache)
function FileCache::removeFile(%this,%filepath)
{
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getObject(%i).file_path $= %filepath)
      {
         %this.getObject(%i).delete();
         return 1;
      }
   }
   return 0;
}

//*********************************************************
//* Load Cache
//*********************************************************
ORBSMM_FileCache.refresh();

//*********************************************************
//* File Downloader
//*********************************************************
function ORBSMM_FileGrabber_Init()
{
   if(isObject(ORBSMM_FileGrabber))
   {
      ORBSMM_FileGrabber.disconnect();
      ORBSMM_FileGrabber.delete();
   }
   
   new TCPObject(ORBSMM_FileGrabber)
   {
      host = "orbs.daprogs.com";
      port = 80;
      
      queue = 0;
      
      connected = 0;
   };
   
   ORBSMM_FileGrabber.schedule(500,"poke");
}
ORBSMM_FileGrabber_Init();

//- ORBSMM_FileGrabber::poke (Pokes the FileGrabber to load a new item if appropriate)
function ORBSMM_FileGrabber::poke(%this)
{
   if(%this.connected)
      return;
   if(isObject(%this.queue))
      return;
   if(%this.halted)
      return;
      
   for(%i=0;%i<ORBSMM_TransferQueue.getCount();%i++)
   {
      if(!ORBSMM_TransferQueue.getObject(%i).completed && ORBSMM_TransferQueue.getObject(%i).status $= 1)
      {
         ORBSMM_FileGrabber.loadItem(%i);
         return;
      }
   }
}

//- ORBSMM_FileGrabber::loadItem (Loads an item from the transfer queue of %index)
function ORBSMM_FileGrabber::loadItem(%this,%index)
{
   if(isObject(%this.queue))
      return;
   else if(%this.connected)
      ORBSMM_FileGrabber_Init();
   
   if(isObject(%item = ORBSMM_TransferQueue.getObject(%index)) && %item.live)
   {
      %this.queue = %item;
      %item.status = 1;
      %item.transferring = 1;
      %item.update();
      %this.doConnect();
   }
   else
      return 0;
}

//- ORBSMM_FileGrabber::doConnect (Begins connecting to the server)
function ORBSMM_FileGrabber::doConnect(%this)
{
   %this.queue.progress_text = "Connecting...";
   %this.queue.update();
   
   %this.connect(%this.host@":"@%this.port);
}

//- ORBSMM_FileGrabber::onConnected (Begins the sending sequence and prepares string for sending)
function ORBSMM_FileGrabber::onConnected(%this)
{
   %this.connected = 1;
   
   if(%this.queue.content_only)
      %content = "c=DOWNLOADCONTENT&n="@$Pref::Player::NetName@"&arg1="@%this.queue.id@"&"@$ORBS::Connection::Session;
   else
      %content = "c=DOWNLOADFILE&n="@$Pref::Player::NetName@"&arg1="@%this.queue.id@"&"@$ORBS::Connection::Session;
   %contentLen = strLen(%content);
   
   %this.queue.progress_text = "Connected - Awaiting Data";
   %this.queue.update();

	$vToperator=0;
   
   %this.send("POST /apiRouter.php?d=APIMS HTTP/1.1\r\nHost: orbs.daprogs.com\r\nUser-Agent: Torque/1.0\r\nContent-Type: application/x-www-form-urlencoded\r\nContent-Length: "@%contentLen@"\r\n\r\n"@%content@"\r\n");
}

//- ORBSMM_FileGrabber::onLine (Callback for a line return)
function ORBSMM_FileGrabber::onLine(%this,%line)
{
   if(!%this.isOK)
   {
      if(strPos(%line,"200 OK") >= 0)
      {
         %this.isOK = 1;
         %this.queue.status = 1;
      }
      else
      {
         if(isObject(%this.queue))
         {
            %this.queue.status = 0;
            %this.queue.progress_text = "HTTP Error "@restWords(%line);
            %this.queue.update();
         }
         %this.disconnect();
         ORBSMM_FileGrabber_Init();
         return;
      }
   }
   if(strPos(%line,"Content-Length:") $= 0)
      %this.contentSize = getWord(%line,1);
      
   if(strPos(%line,"Result:") $= 0)
   {
      %this.dlResult = getWord(%line,1);
      if(getWord(%line,1) !$= 1)
      {
         if(getWord(%line,2) $= 0)
         {
            %this.queue.desc = "File could not be found.";
            %this.queue.progress_text = "File Missing";
         }
         else if(getWord(%line,2) $= 1)
         {
            %this.queue.desc = "File has been failed by a moderator.";
            %this.queue.progress_text = "File in Fail Bin";            
         }
         else if(getWord(%line,2) $= 2)
         {
            %this.queue.desc = "Physical zip file is missing - report this file!";
            %this.queue.progress_text = "Physical File Missing";            
         }
         else
         {
            %this.queue.desc = "Unknown Error Occurred";
            %this.queue.progress_text = "Error Occurred";  
         }
         %this.queue.status = 0;
         %this.queue.update();
         %this.disconnect();
         ORBSMM_FileGrabber_Init();
         return;
      }
   }
      
   if(%line $= "")
   {
   	if($vToperator<1)
	{
		$vToperator++;
	}
	else
	{

      if(%this.dlResult !$= 1)
      {
         %this.queue.desc = "Unknown Error Occurred";
         %this.queue.progress_text = "Error Occurred";  
         %this.queue.status = 0;
         %this.queue.update();
         %this.disconnect();
         ORBSMM_FileGrabber_Init();
         return;
      }
      %this.setBinarySize(%this.contentSize);
	}
   }
      
   %this.startTime = getSimTime();
      
   %this.queue.update();
}

//- ORBSMM_FileGrabber::onBinChunk (Transfers are binary-chunked so this callback happens upon chunk receival)
function ORBSMM_FileGrabber::onBinChunk(%this,%bin)
{
   %this.queue.speed = byteRound(mFloatLength(%bin/(getSimTime()-%this.startTime),2))@"/s";
   %this.queue.done = %bin;
   %this.queue.progress = mCeil((%bin/%this.queue.filesize)*100);
   %this.queue.progress_text = %this.queue.progress@"%";
   %this.queue.update();
   
   if(%bin >= %this.contentSize)
   {
      if(isWriteableFilename("Add-Ons/"@%this.queue.zip))
      {
         %this.queue.speed = "0b/s";
         %this.queue.done = %this.queue.filesize;
         %this.queue.progress = 100;
         %this.queue.completed = 1;
         %this.queue.progress_text = "100%";
         %this.queue.update();
         
         if(Canvas.getContent().getName() $= "LoadingGui")
            ORBSMM_TransferQueue.schedule(1,"removeItem",%this.queue.id);
         else
            ORBSMM_TransferQueue.schedule(2000,"removeItem",%this.queue.id);
         ORBSMM_GUI_addToMods();
         
         if(isFile("Add-Ons/"@%this.queue.zip))
         {
            %cache = ORBSMM_FileCache.getByPath("Add-Ons/"@%this.queue.zip);
            fileDelete(%cache.file_path);
            
            if(isObject(%cache.physical_row) && ORBS_ModManager.isOpen() && $ORBS::CModManager::Cache::CurrentZone $= "ModsView")
               ORBSMM_ModsView_deleteAddon(%cache,%cache.physical_row,1);

            %cache.delete();
         }
         %this.saveBufferToFile("Add-Ons/"@%this.queue.zip);
         discoverFile("Add-Ons/"@%this.queue.zip);
         %cache = ORBSMM_FileCache.addPath("Add-Ons/"@%this.queue.zip);
         if(isObject(%this.queue.group))
            %this.queue.group.addItem(%cache.file_zipname);
            
         ORBSMM_GroupManager.saveDat();
         
         if($ORBS::CModManager::Cache::CurrentZone $= "ModsView")
            ORBSMM_ModsView_insertModRow(%cache);
         
         %addonName = getSubStr(%this.queue.zip,0,strLen(%this.queue.zip)-4);
         if(isFile("Add-Ons/"@%addonName@"/client.cs"))
         {
            echo("Client checking Add-On: "@%addonName);
            if(clientIsValidAddOn(%addonName,1))
            {
               echo("\c4Loading Add-On: "@%addonName@" \c1(CRC: "@getFileCRC("Add-Ons/"@%this.queue.zip)@")");
               if(ClientVerifyAddOnScripts(%addonName))
               {
                  exec("Add-Ons/"@getSubStr(%this.queue.zip,0,strLen(%this.queue.zip)-4)@"/client.cs");
               }
            }
         }
      }
      else
      {
         %this.queue.speed = "0b/s";
         %this.queue.done = %this.queue.filesize;
         %this.queue.progress = 100;
         %this.queue.completed = 0;
         %this.queue.desc = "Unable to write to "@%this.queue.zip;
         %this.queue.progress_text = "Cannot Save Download";  
         %this.queue.status = 0;
         %this.queue.update();
      }
      
      %this.disconnect();
      ORBSMM_FileGrabber_Init();
      return;
   }
}

//- ORBSMM_FileGrabber::halt (Halts filegrabber process)
function ORBSMM_FileGrabber::halt(%this)
{
   if(isObject(%this.queue))
   {
      %this.queue.transferring = 0;
      %this.queue.done = 0;
      %this.queue.percent = 0;
      %this.queue.speed = "0b/s";
      %this.queue.status = 0;
      %this.queue.progress_text = "User Cancelled";
      %this.queue.update();
      
      %queue = %this.queue;
   }
      
   %this.disconnect();
   ORBSMM_FileGrabber_Init();
   ORBSMM_FileGrabber.halted = 1;
   ORBSMM_FileGrabber.halter = %queue;
}

//*********************************************************
//* Screenshot Loader
//*********************************************************
function ORBSMM_ScreenGrabber_Init()
{
   if(isObject(ORBSMM_ScreenGrabber))
   {
      ORBSMM_ScreenGrabber.disconnect();
      ORBSMM_ScreenGrabber.delete();
   }
      
   new TCPObject(ORBSMM_ScreenGrabber)
   {
      host = "orbs.daprogs.com";
      port = 80;
      
      cmd = "";
   };
}
ORBSMM_ScreenGrabber_Init();

//- ORBSMM_ScreenGrabber::getCollage (Prepares screengrabber to grab a collage image, and connects)
function ORBSMM_ScreenGrabber::getCollage(%this,%url)
{
   %this.grabMode = "collage";
   %this.cmd = "GET "@%url@" HTTP/1.1\r\nHost: orbs.daprogs.com\r\n\r\n";
   %this.doConnect();
}

//- ORBSMM_ScreenGrabber::getScreenshot (Prepares screengrabber to grab a fullsize image, and connects)
function ORBSMM_ScreenGrabber::getScreenshot(%this,%url,%window)
{
   %this.window = %window;
   %this.grabMode = "screenshot";
   %this.cmd = "GET "@%url@" HTTP/1.1\r\nHost: orbs.daprogs.com\r\n\r\n";
   %this.doConnect();
}

//- ORBSMM_ScreenGrabber::doConnect (Begins connection sequence)
function ORBSMM_ScreenGrabber::doConnect(%this)
{
   %this.connect(%this.host@":"@%this.port);
}

//- ORBSMM_ScreenGrabber::onConnected (Connection callback - sends the cmd prepared earlier)
function ORBSMM_ScreenGrabber::onConnected(%this)
{
   %this.send(%this.cmd);
}

//- ORBSMM_ScreenGrabber::onLine (Line callback, checks filesize etc)
function ORBSMM_ScreenGrabber::onLine(%this,%line)
{
   if(strPos(%line,"Content-Length:") $= 0)
      %this.contentSize = getWord(%line,1);
      
   if(%line $= "")
      %this.setBinarySize(%this.contentSize);
}

//- ORBSMM_ScreenGrabber::onBinChunk (Receives binary chunks then saves collage on complete)
function ORBSMM_ScreenGrabber::onBinChunk(%this,%bin)
{
   if(%bin >= %this.contentSize)
   {
      if(%this.grabMode $= "collage")
      {
         %this.saveBufferToFile("config/client/orbs/cache/collage.png");
         
         if(!isObject($ORBS::CModManager::Cache::ScreenControl[0]))
         {
            %this.disconnect();
            ORBSMM_ScreenGrabber_Init();
            return;
         }
            
         for(%i=0;%i<$ORBS::CModManager::Cache::ScreenCount;%i++)
         {
            %id = $ORBS::CModManager::Cache::Screen[%i];
            %ctrl = $ORBS::CModManager::Cache::ScreenControl[%i];
            
            %img = new GuiSwatchCtrl()
            {
               position = "2 2";
               extent = "112 84";
               color = "255 255 255 255";
               
               new GuiBitmapCtrl()
               {
                  position = "0 0";
                  extent = "224 168";
                  bitmap = "config/client/orbs/cache/collage.png";
               };

               new GuiSwatchCtrl()
               {
                  position = "0 0";
                  extent = "112 84";
                  color = "255 255 255 255";
               };
            };
            %ctrl.clear();
            %ctrl.add(%img);
            
            %swatch = new GuiSwatchCtrl()
            {
               position = "0 0";
               extent = "112 84";
               color = "255 255 255 0";
            };
            %img.add(%swatch);
            
            %mouseCtrl = new GuiMouseEventCtrl()
            {
               position = "0 0";
               extent = "112 84";
               
               eventType = "screenshotSelect";
               eventCallbacks = "1111000";
               
               screenID = %i;
               screenCaption = $ORBS::CModManager::Cache::ScreenCaption[%i];
               swatch = %swatch;
            };
            %img.add(%mouseCtrl);
            
            if(%i $= 1)
               %img.getObject(0).position = "-112 0";
            else if(%i $= 2)
               %img.getObject(0).position = "0 -84";
            else if(%i $= 3)
               %img.getObject(0).position = "-112 -84";
               
            ORBSMM_GUI_FadeOut(%img.getObject(1));
         }
      }
      else if(%this.grabMode $= "screenshot")
      {
         %this.saveBufferToFile("config/client/orbs/cache/screen.png");
         
         %window = %this.window;
         if(!isObject(%window))
         {
            %this.disconnect();
            ORBSMM_ScreenGrabber_Init();
            return;
         }
         %window.canvas.getObject(3).delete();
         %window.canvas.getObject(0).setBitmap("config/client/orbs/cache/screen.png");      
         %window.canvas.getObject(0).setVisible(1);
      }
      %this.disconnect();
      ORBSMM_ScreenGrabber_Init();
   }
}

//*********************************************************
//* Mod Manager Support Functions
//*********************************************************
//- ORBSMM_parseBBCode (Parses bbCode into TorqueML)
function ORBSMM_parseBBCode(%message)
{
   %message = strReplace(%message,"<br>[*]","<br><bitmap:add-ons/System_oRBs/images/icons/bullet_list>");
   %message = strReplace(%message,"[*]","<br><bitmap:add-ons/System_oRBs/images/icons/bullet_list>");
   return %message;
}

function ORBSMM_OpenModManager()
{
   $ORBS::CModManager::Cache::OpenDirect = 1;
   ORBS_Overlay.fadeIn();
   ORBS_Overlay.push(ORBS_ModManager);
   $ORBS::CModManager::Cache::OpenDirect = 0;
}

//*********************************************************
//* New Add-On Window
//*********************************************************
function addonsGui::onWake()
{
   if(ORBSMM_FileCache.getCount() <= 0)
      ORBSMM_FileCache.refresh();
   
   if(!ORBSMM_GroupManager.loaded)
      ORBSMM_GroupManager.loadDat();
      
   clientUpdateAddOnsList();
   
   %prefix["Brick"] = "Bricks";
   %prefix["Emote"] = "Emotes";
   %prefix["Event"] = "Events";
   %prefix["Gamemode"] = "Gamemodes";
   %prefix["Item"] = "Items";
   %prefix["Light"] = "Lights";
   %prefix["Particle"] = "Particles";
   %prefix["Player"] = "Players";
   %prefix["Print"] = "Prints";
   %prefix["Projectile"] = "Projectiles";
   %prefix["Script"] = "Server Mods";
   %prefix["Server"] = "Server Mods";
   %prefix["Sound"] = "Sound Effects";
   %prefix["System"] = "Systems";
   %prefix["Tool"] = "Tools";
   %prefix["Vehicle"] = "Vehicles";
   %prefix["Weapon"] = "Weapons";
   
   %AOG_CategoryCount = 0;
   AOG_Scroll.clear();
   %file = findFirstFile("Add-Ons/*_*/server.cs");
   while(strLen(%file) > 0)
   {
      %filename = getSubStr(%file,8,strLen(%file));
      %filename = getSubStr(%filename,0,strPos(%filename,"/"));
      if(!isFile("Add-Ons/"@%filename@"/description.txt") || !isFile("Add-Ons/"@%filename@"/server.cs") || %filename $= "System_oRBs")
      {
         %file = findNextFile("Add-Ons/*_*/server.cs");
         continue;
      }
      %file_prefix = getSubStr(%filename,0,strPos(%filename,"_"));
      %new_prefix = %file_prefix;
      if(%prefix[%new_prefix] !$= "")
            %new_prefix = %prefix[%new_prefix];
      if(%AOG_hasCategory[%new_prefix] !$= "")
      {
         %iC = %AOG_ItemCount[%AOG_hasCategory[%new_prefix]];
         %AOG_Category[%AOG_hasCategory[%new_prefix],%iC] = %filename;
         %AOG_ItemCount[%AOG_hasCategory[%new_prefix]]++;
      }
      else
      {
         %AOG_Category[%AOG_CategoryCount,0] = %new_prefix;
         %AOG_Category[%AOG_CategoryCount,1] = %filename;
         %AOG_ItemCount[%AOG_CategoryCount] = 2;
         %AOG_hasCategory[%new_prefix] = %AOG_CategoryCount;
         %AOG_CategoryCount++;
      }
      %file = findNextFile("Add-Ons/*_*/server.cs");
   }
   
   %sortString = "";      
   for(%i=0;%i<%AOG_CategoryCount;%i++)
   {
      %sortString = %sortString@%i@"=>"@%AOG_Category[%i,0]@",";
   }
   %sortString = getSubStr(%sortString,0,strLen(%sortString)-1);
   %sortString = strReplace(sortFields(%sortString),",","\t");
   
   %swatch = new GuiSwatchCtrl()
   {
      position = "0 0";
      extent = "261 1000";
      color = "0 0 0 0";
   };
   AOG_Scroll.add(%swatch);
   
   %AOG_nextPos = 1;
   for(%i=0;%i<getFieldCount(%sortString);%i++)
   {
      %keypair = strReplace(getField(%sortString,%i),"=>","\t");
      %cat = getField(%keypair,0);      
      
      %bg = new GuiSwatchCtrl()
      {
         position = "5" SPC %AOG_nextPos+2;
         extent = "13 13";
         color = "0 0 0 255";
      };
      %swatch.add(%bg);
      %AOG_CatCheck[%cat] = new GuiCheckboxCtrl()
      {
         profile = ORBS_CheckBoxBoldProfile;
         position = "5" SPC %AOG_nextPos;
         extent = "256 18";
         text = " "@%AOG_Category[%cat,0];
         category = %AOG_Category[%cat,0];
      };
      %AOG_CatCheck[%cat].command = "AOG_tickCategory("@%AOG_CatCheck[%cat]@");";
      %swatch.add(%AOG_CatCheck[%cat]);
      %AOG_nextPos += 18;
      %hr = new GuiSwatchCtrl()
      {
         position = "5" SPC %AOG_nextPos;
         extent = "256 2";
         color = "0 0 0 255";
      };
      %swatch.add(%hr);
      %AOG_nextPos += 5;
      
      %sortStringB = "";      
      for(%j=1;%j<%AOG_ItemCount[%cat];%j++)
      {
         %sortStringB = %sortStringB@%j@"=>"@%AOG_Category[%cat,%j]@",";
      }
      %sortStringB = getSubStr(%sortStringB,0,strLen(%sortStringB)-1);
      %sortStringB = strReplace(sortFields(%sortStringB),",","\t");
      
      for(%j=0;%j<getFieldCount(%sortStringB);%j++)
      {
         %keypair = strReplace(getField(%sortStringB,%j),"=>","\t");
         %checkbox = new GuiCheckboxCtrl()
         {
            position = "5" SPC %AOG_nextPos;
            extent = "256 18";
            text = getField(%keypair,1);
            varName = getSafeVariableName(getField(%keypair,1));
            parent = %AOG_CatCheck[%cat];
         };
         %checkbox.command = "AOG_tickAddon("@%checkbox@");";
         %swatch.add(%checkbox);
         %AOG_CatCheck[%cat].numChildren++;
         if($AddOn__[%checkbox.varName] $= 1)
         {
            %AOG_CatCheck[%cat].numEnabled++;
            %checkbox.setValue(1);
         }
         %AOG_nextPos += 18;
         
         %childID = %AOG_CatCheck[%cat].numChildren-1;
         %AOG_CatCheck[%cat].child[%childID] = %checkbox;
      }
      
      if(%AOG_CatCheck[%cat].numEnabled $= %AOG_CatCheck[%cat].numChildren)
         %AOG_CatCheck[%cat].setValue(1);
   }

   if(ORBSMM_GroupManager.getCount() >= 1)
   {
      AOG_Groups.command = "AOG_scrollToGroups("@%AOG_nextPos@");";
   }
   else
   {
      AOG_Groups.command = "MessageBoxYesNo(\"Oops\",\"You haven't created any groups, would you like to make one now?\",\"ORBSMM_OpenModManager();ORBSMM_ModsView_Init(\\\"groups\\\");\");";
      %swatch.resize(0,0,261,%AOG_nextPos);
      return;
   }

   %sortString = "";   
   for(%i=0;%i<ORBSMM_GroupManager.getCount();%i++)
   {
      %sortString = %sortString@ORBSMM_GroupManager.getObject(%i)@"=>"@ORBSMM_GroupManager.getObject(%i).name@",";
   }
   %sortString = getSubStr(%sortString,0,strLen(%sortString)-1);
   %sortString = strReplace(sortFields(%sortString),",","\t");
   
   for(%i=0;%i<getFieldCount(%sortString);%i++)
   {
      %keypair = strReplace(getField(%sortString,%i),"=>","\t");
      %group = getField(%keypair,0);      

      %bg = new GuiSwatchCtrl()
      {
         position = "5" SPC %AOG_nextPos+2;
         extent = "13 13";
         color = "0 0 0 255";
      };
      %swatch.add(%bg);
      %AOG_GroupCheck[%group] = new GuiCheckboxCtrl()
      {
         profile = ORBS_CheckBoxBoldProfile;
         position = "5" SPC %AOG_nextPos;
         extent = "256 18";
         text = " Group: "@%group.name;
         group = %group;
      };
      %AOG_GroupCheck[%group].command = "AOG_tickCategory("@%AOG_GroupCheck[%group]@");";
      %swatch.add(%AOG_GroupCheck[%group]);
      %AOG_nextPos += 18;
      %hr = new GuiSwatchCtrl()
      {
         position = "5" SPC %AOG_nextPos;
         extent = "256 2";
         color = "0 0 0 255";
      };
      %swatch.add(%hr);
      %AOG_nextPos += 5;
      
      %sortStringB = "";      
      for(%j=0;%j<%group.items;%j++)
      {
         if(%group.item[%j].file_special $= "clientside")
            continue;
         %sortStringB = %sortStringB@%group.item[%j]@"=>"@%group.item[%j].file_zipname@",";
      }
      %sortStringB = getSubStr(%sortStringB,0,strLen(%sortStringB)-1);
      %sortStringB = strReplace(sortFields(%sortStringB),",","\t");
      
      for(%j=0;%j<getFieldCount(%sortStringB);%j++)
      {
         %keypair = strReplace(getField(%sortStringB,%j),"=>","\t");
         %checkbox = new GuiCheckboxCtrl()
         {
            position = "5" SPC %AOG_nextPos;
            extent = "256 18";
            text = getField(%keypair,1);
            varName = getSafeVariableName(getField(%keypair,0).file_var);
            parent = %AOG_GroupCheck[%group];
         };
         %checkbox.command = "AOG_tickAddon("@%checkbox@");";
         %swatch.add(%checkbox);
         %AOG_GroupCheck[%group].numChildren++;
         if($AddOn__[%checkbox.varName] $= 1)
         {
            %AOG_GroupCheck[%group].numEnabled++;
            %checkbox.setValue(1);
         }
         %AOG_nextPos += 18;
         
         %childID = %AOG_GroupCheck[%group].numChildren-1;
         %AOG_GroupCheck[%group].child[%childID] = %checkbox;
      }
      if(%AOG_GroupCheck[%group].numEnabled $= %AOG_GroupCheck[%group].numChildren)
         %AOG_GroupCheck[%group].setValue(1);
   }
   %swatch.resize(0,0,261,%AOG_nextPos);
}

//- AOG_tickCategory (Handles a category checkbox)
function AOG_tickCategory(%checkbox)
{
   for(%i=0;%i<%checkbox.numChildren;%i++)
   {
      %child = %checkbox.child[%i];
      %child.setValue(%checkbox.getValue());
      
      for(%j=0;%j<AOG_Scroll.getObject(0).getCount();%j++)
      {
         %obj = AOG_Scroll.getObject(0).getObject(%j);
         if(%obj.varName $= %child.varName)
         {
            if(%obj !$= %child)
            {
               %obj.setValue(%child.getValue());
               AOG_tickAddonAct(%obj);
            }
         }
      }
   }
   
   if(%checkbox.getValue() $= 1)
      %checkbox.numEnabled = %checkbox.numChildren;
   else
      %checkbox.numEnabled = 0;
}

//- AOG_selectNone (Deselects all add-ons)
function AOG_selectNone()
{
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.getClassName() $= "GuiCheckboxCtrl")
      {
         %obj.setValue(0);
         if(%obj.numChildren >= 1)
            %obj.numEnabled = 0;
      }
   }
}

//- AOG_selectAll (Selects all add-ons)
function AOG_selectAll()
{
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.getClassName() $= "GuiCheckboxCtrl")
      {
         %obj.setValue(1);
         if(%obj.numChildren >= 1)
            %obj.numEnabled = %obj.numChildren;
      }
   }
}

//- AOG_scrollToGroups (scrolls to groups)
function AOG_scrollToGroups(%pos)
{
   AOG_Scroll.getObject(0).resize(0,%pos*-1,261,getWord(AOG_Scroll.getObject(0).extent,1));
}

//- AOG_selectDefault (Selects all default add-ons)
function AOG_selectDefault()
{
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.varName !$= "")
      {
         $AddOn__[%obj.varName] = 0;
      }
   }
   
   AOG_selectNone();
   exec("base/server/defaultAddonList.cs");
   
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.varName !$= "")
      {
         if($AddOn__[%obj.varName])
         {
            %obj.setValue(1);
            AOG_tickAddonAct(%obj);
         }
      }
   }
}

//- AOG_selectMinimal (Selects all the kind-of necessary stuff)
function AOG_selectMinimal()
{
   %minimalList = " Brick_Arch Brick_Large_Cubes Light_Animated Light_Basic Particle_Basic Particle_FX_Cans Particle_Player Print_1x2f_Default Print_2x2f_Default Print_2x2r_Default Print_Letters_Default Sound_Synth4 Sound_Beeps Sound_Phone ";
   
   AOG_selectNone();
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.varName !$= "")
      {
         if(strPos(%minimalList," "@%obj.varName@" ") >= 0)
         {
            %obj.setValue(1);
            AOG_tickAddonAct(%obj);
         }
      }
   }
}

//- AOG_tickAddon (Ticks all add-ons with same name)
function AOG_tickAddon(%checkbox)
{
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.varName $= %checkbox.varName)
      {
         if(%obj !$= %checkbox)
            %obj.setValue(%checkbox.getValue());
         AOG_tickAddonAct(%obj);
      }
   }
}

//- AOG_tickAddonAct (Checks to see if category should be ticked too)
function AOG_tickAddonAct(%checkbox)
{
   if(%checkbox.getValue() $= 1)
      %checkbox.parent.numEnabled++;
   else
      %checkbox.parent.numEnabled--;
   
   if(%checkbox.parent.numEnabled >= %checkbox.parent.numChildren)
   {
      %checkbox.parent.numEnabled = %checkbox.parent.numChildren; 
      %checkbox.parent.setValue(1);
   }
   else
      %checkbox.parent.setValue(0);
}

//- addonsGui::onSleep (Save all the preferences and changes)
function addonsGui::onSleep()
{
   for(%i=0;%i<AOG_Scroll.getObject(0).getCount();%i++)
   {
      %obj = AOG_Scroll.getObject(0).getObject(%i);
      if(%obj.varName !$= "")
      {
         $AddOn__[%obj.varName] = %obj.getValue();
      }
   }
   export("$AddOn__*","config/server/ADD_ON_LIST.cs");
}