//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 492 $
//#      $Date: 2013-04-21 12:36:33 +0100 (Sun, 21 Apr 2013) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/modules/server/serverControl.cs $
//#
//#      $Id: serverControl.cs 492 2013-04-21 11:36:33Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Modules / Server / Server Control (MSSC)
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Server::ServerControl = 1;

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::MSSC::Options = 0;

//*********************************************************
//* Requirements
//*********************************************************
exec($ORBS::Path@"hooks/serverControl.cs");

//*********************************************************
//* Server Options
//*********************************************************
//- ORBSSC_registerServerOption (Registers a server option)
function ORBSSC_registerServerOption(%optionName,%type,%pref,%callback,%message)
{
   $ORBS::MSSC::Option[$ORBS::MSSC::Options] = %optionName TAB %type TAB %pref TAB %callback TAB %message;
   $ORBS::MSSC::Options++;
}

//- serverCmdORBS_setServerOptions (Sets changed server options)
function serverCmdORBS_setServerOptions(%client,%notify,%options,%v1,%v2,%v3,%v4,%v5,%v6,%v7,%v8,%v9,%v10,%v11,%v12,%v13,%v14,%v15,%v16)
{
   if(!%client.isSuperAdmin || !%client.hasORBS)
      return;
      
   if(strPos(%options,"N") == -1)
      messageAll('MsgAdminForce','\c3%1 \c0updated the server settings.',%client.name);
      
   for(%i=0;%i<getWordCount(%options);%i++)
   {
      if(%i > 16)
         break;
         
      %id = getWord(%options,%i);
      %option = $ORBS::MSSC::Option[%id];
      
      if(%option $= "" || %id > $ORBS::MSSC::Options-1)
         continue;
         
      eval("%oldValue = "@getField(%option,2)@";");
      %newValue = %v[%i+1];
         
      %type = getField(%option,1);
      if(firstWord(%type) $= "int" || firstWord(%type) $= "playerlist")
      {
         %newValue = mFloatLength(%newValue,0);
         if(%newValue < getWord(%type,1))
            %newValue = getWord(%type,1);
         else if(%newValue > getWord(%type,2))
            %newValue = getWord(%type,2);
      }
      else if(firstWord(%type) $= "string")
      {
         if(strLen(%newValue) > getWord(%type,1))
            %newValue = getSubStr(%newValue,0,getWord(%type,1));
         %newValue = strReplace(%newValue,"\\","\\\\");
         %newValue = strReplace(%newValue,"\"","\\\"");
      }
      else if(firstWord(%type) $= "bool")
      {
         if(%newValue !$= 1)
            %newValue = 0;
      }
      
      if(%newValue $= %oldValue)
         continue;

      eval(getField(%option,2)@" = \""@%newValue@"\";");
      
      if(%notify && getField(%option,4) !$= "")
      {
         if(firstWord(%type) $= "bool")
            %newValue = (%newValue == 1) ? "On" : "Off";
         
         %message = strReplace(getField(%option,4),"%1",getField(%option,0));
         %message = strReplace(%message,"%2","\c5"@%newValue);
         messageAll('',"\c3  \c0"@%message);
      }
      
      if(getField(%option,3) !$= "")
         eval(getField(%option,3));
   }
   
   if(strPos(%options,"D") >= 1)
   {
      commandtoclient(%client,'ORBS_closeGui',"ORBS_ServerControl");
         
      // FUCK!
      $Pref::Server::Name = $Server::Name;
      $Pref::Server::WelcomeMessage = $Server::WelcomeMessage;
      $Pref::Server::MaxBricksPerSecond = $Server::MaxBricksPerSecond;
      $Pref::Server::WrenchEventsAdminOnly = $Server::WrenchEventsAdminOnly;
         
      export("$Pref::Server::*","config/server/prefs.cs");
      
      if(!$Server::LAN)
         WebCom_PostServer();
      
      for(%i=0;%i<ClientGroup.getCount();%i++)
      {
         %cl = ClientGroup.getObject(%i);
         if(%cl.isSuperAdmin && %cl.hasORBS)
            serverCmdORBS_getServerOptions(%cl);
            
         commandtoclient(%cl,'NewPlayerListGui_UpdateWindowTitle',$Server::Name,$Pref::Server::MaxPlayers);
      }
   }
}

//- serverCmdORBS_getServerOptions (Sends server options to the client)
function serverCmdORBS_getServerOptions(%client)
{
   if(!%client.isSuperAdmin || !%client.hasORBS)
      return;
      
   for(%i=0;%i<$ORBS::MSSC::Options;%i++)
   {
      %seq = %i%16;
      %settings = %settings@%i@" ";
      eval("%var["@%seq@"] = "@getField($ORBS::MSSC::Option[%i],2)@";");
      if(%i%16 $= 15 || %i $= $ORBS::MSSC::Options-1)
      {
         if(%i $= $ORBS::MSSC::Options-1)
            %settings = %settings@"D ";
         commandtoclient(%client,'ORBS_getServerOptions',getSubStr(%settings,0,strLen(%settings)-1),%var0,%var1,%var2,%var3,%var4,%var5,%var6,%var7,%var8,%var9,%var10,%var11,%var12,%var13,%var14,%var15);
         %settings = "";
         for(%j=0;%j<16;%j++)
         {
            %var[%j] = "";
         }
      }
   }
}

//*********************************************************
//* Server Options Definitions (Must match on client)
//*********************************************************
ORBSSC_registerServerOption("Server Name","string 150","$Server::Name","","The %1 has been changed to %2");
ORBSSC_registerServerOption("Welcome Message","string 255","$Server::WelcomeMessage","","The %1 has been changed to %2");
ORBSSC_registerServerOption("Max Players","playerlist 1 99","$Pref::Server::MaxPlayers","","The %1 has been changed to %2");
ORBSSC_registerServerOption("Server Password","string 30","$Pref::Server::Password","","The %1 has been changed");
ORBSSC_registerServerOption("Admin Password","string 30","$Pref::Server::AdminPassword","","The %1 has been changed");
ORBSSC_registerServerOption("Super Admin Password","string 30","$Pref::Server::SuperAdminPassword","","The %1 has been changed");
ORBSSC_registerServerOption("E-Tard Filter","bool","$Pref::Server::EtardFilter","","The %1 has been turned %2");
ORBSSC_registerServerOption("E-Tard Words","string 255","$Pref::Server::EtardList","","The %1 have been changed to %2");
ORBSSC_registerServerOption("Max Bricks per Second","int 0 999","$Server::MaxBricksPerSecond","","The %1 is now %2");
ORBSSC_registerServerOption("Falling Damage","bool","$Pref::Server::FallingDamage","","%1 has been turned %2");
ORBSSC_registerServerOption("Too Far Distance","int 0 9999","$Pref::Server::TooFarDistance","","The %1 has been changed to %2");
ORBSSC_registerServerOption("Admin Only Wrench Events","bool","$Server::WrenchEventsAdminOnly","","%1 have been turned %2");
ORBSSC_registerServerOption("Brick Ownership Decay","int -1 99999","$Pref::Server::BrickPublicDomainTimeout","","%1 has been changed to %2");

//*********************************************************
//* Auto Admin
//*********************************************************
//- serverCmdORBS_getAutoAdminList (Sends the auto admin list to the client)
function serverCmdORBS_getAutoAdminList(%client)
{
   if(%client.isSuperAdmin || !%client.hasORBS)
	{	
	   %adminList = $Pref::Server::AutoAdminList;
		%superAdminList = $Pref::Server::AutoSuperAdminList;
		commandtoclient(%client,'ORBS_getAutoAdminList',%adminList,%superAdminList);
	}
}

//- serverCmdORBS_addAutoStatus (Allows a client to add a player to the auto list)
function serverCmdORBS_addAutoStatus(%client,%bl_id,%status)
{
   if(%client.isSuperAdmin)
   {
      if(%bl_id $= "" || !isInt(%bl_id) || %bl_id < 0)
	   {
	      commandtoclient(%client,'MessageBoxOK',"Whoops","You have entered an invalid BL_ID.");
	      return;
	   }
	   if(%status !$= "Admin" && %status !$= "Super Admin")
	   {
         commandtoclient(%client,'MessageBoxOK',"Whoops","You have entered an invalid Status.");
	      return;
      }
		$Pref::Server::AutoAdminList = removeItemFromList($Pref::Server::AutoAdminList,%bl_id);
		$Pref::Server::AutoSuperAdminList = removeItemFromList($Pref::Server::AutoSuperAdminList,%bl_id);
		if(%status $= "Admin")
		{
			$Pref::Server::AutoAdminList = addItemToList($Pref::Server::AutoAdminList,%bl_id);
		}
		else if(%status $= "Super Admin")
		{
			$Pref::Server::AutoSuperAdminList = addItemToList($Pref::Server::AutoSuperAdminList,%bl_id);
		}
		export("$Pref::Server::*","config/server/prefs.cs");
		
		serverCmdORBS_getAutoAdminList(%client);
		
		for(%i=0;%i<ClientGroup.getCount();%i++)
		{
			%cl = ClientGroup.getObject(%i);
			if(%cl.bl_id $= %bl_id)
			{
			   if(%status $= "Super Admin")
            {
               if(%cl.isSuperAdmin)
                  return;
               
               %cl.isAdmin = 1;
               %cl.isSuperAdmin = 1;
               %cl.sendPlayerListUpdate();
               commandtoclient(%cl,'setAdminLevel',2);
               messageAll('MsgAdminForce','\c2%1 has become Super Admin (Auto)',%cl.name);
            
               ORBSSC_SendPrefList(%client);
            }
            else if(%status $= "Admin")
            {
               if(%cl.isAdmin)
                  return;
               
               %cl.isAdmin = 1;
               %cl.isSuperAdmin = 0;
               %cl.sendPlayerListUpdate();
               commandtoclient(%cl,'setAdminLevel',1);
               messageAll('MsgAdminForce','\c2%1 has become Admin (Auto)',%cl.name);
            }
			}
		}
	}
}

//- serverCmdORBS_removeAutoStatus (Removes a player from the auto lists)
function serverCmdORBS_removeAutoStatus(%client,%bl_id)
{
	if(%client.isSuperAdmin)
	{
		$Pref::Server::AutoAdminList = removeItemFromList($Pref::Server::AutoAdminList,%bl_id);
		$Pref::Server::AutoSuperAdminList = removeItemFromList($Pref::Server::AutoSuperAdminList,%bl_id);
      export("$Pref::Server::*","config/server/prefs.cs");
      
		serverCmdORBS_getAutoAdminList(%client);
	}
}

//- serverCmdORBS_clearAutoAdminList (Empties the auto admin lists)
function serverCmdORBS_clearAutoAdminList(%client)
{
	if(%client.isSuperAdmin)
	{
		$Pref::Server::AutoAdminList = "";
		$Pref::Server::AutoSuperAdminList = "";
      export("$Pref::Server::*","config/server/prefs.cs");
      
		serverCmdORBS_getAutoAdminList(%client);
	}
}

//- serverCmdORBS_deAdminPlayer (De-admins a player)
function serverCmdORBS_deAdminPlayer(%client,%victim)
{
   if(!%client.isSuperAdmin)
      return;
   
   if(findLocalClient() $= %victim || %victim.bl_id $= getNumKeyID())
   {
      messageClient(%client,'','\c2You cannot de-admin the host.');
      return;
   }
   else if(%victim.isSuperAdmin && %client.bl_id !$= getNumKeyID())
   {
      messageClient(%client,'','\c2Only the host can de-admin a Super Admin.');
      return;
   }
   else if(%victim.isAdmin)
   {
      %victim.isAdmin = 0;
      %victim.isSuperAdmin = 0;
      %victim.sendPlayerListUpdate();
      commandtoclient(%victim,'setAdminLevel',0);
      messageAll('MsgAdminForce','\c2%1 has been De-Admined (Manual)',%victim.name);
   }
}

//- serverCmdORBS_adminPlayer (Makes a player an admin)
function serverCmdORBS_adminPlayer(%client,%victim)
{
   if(!%client.isSuperAdmin)
      return;
      
   if((findLocalClient() $= %victim || %victim.bl_id $= getNumKeyID()) && %victim.isSuperAdmin)
   {
      messageClient(%client,'','\c2You cannot de-admin the host.');
      return;
   }
   else if(%victim.isSuperAdmin && %client.bl_id !$= getNumKeyID())
   {
      messageClient(%client,'','\c2Only the host can de-admin a Super Admin.');
      return;
   }
   else if(!%victim.isAdmin || (%victim.isAdmin && %victim.isSuperAdmin))
   {
      %victim.isAdmin = 1;
      %victim.isSuperAdmin = 0;
      %victim.sendPlayerListUpdate();
      commandtoclient(%victim,'setAdminLevel',1);
      messageAll('MsgAdminForce','\c2%1 has become Admin (Manual)',%victim.name);
   }
}

//- serverCmdORBS_superAdminPlayer (Makes a player a super admin)
function serverCmdORBS_superAdminPlayer(%client,%victim)
{
   if(!%client.isSuperAdmin)
      return;
      
   if(!%victim.isSuperAdmin)
   {
      %victim.isAdmin = 1;
      %victim.isSuperAdmin = 1;
      %victim.sendPlayerListUpdate();
      commandtoclient(%victim,'setAdminLevel',2);
      messageAll('MsgAdminForce','\c2%1 has become Super Admin (Manual)',%victim.name);
      
      ORBSSC_SendPrefList(%victim);
   }
}

//*********************************************************
//* Pref Manager
//*********************************************************
//- ORBSSC_sendPrefList (Sends a pref list to a specific client)
function ORBSSC_sendPrefList(%client)
{
   if(!%client.isSuperAdmin || !%client.hasORBS || %client.hasPrefList)
      return;
      
   %client.hasPrefList = 1;
      
   %index = -1;
   for(%i=0;%i<$ORBS::MSSC::Prefs;%i++)
   {
      %pref = $ORBS::MSSC::Pref[%i];
      if(getField(%pref,6) $= 1 && !%client.bl_id $= getNumKeyID())
         continue;
      
      %index++;
      %seq = %index%16;
      %prefs = %prefs@%i@" ";
      %var[%seq] = getField(%pref,0) TAB getField(%pref,2) TAB getField(%pref,3) TAB getField(%pref,5);
      
      if(%index%16 $= 15 || %i $= $ORBS::MSSC::Prefs-1)
      {
         if(%i $= $ORBS::MSSC::Prefs-1)
            %prefs = %prefs@"D ";

         commandtoclient(%client,'ORBS_addServerPrefs',getSubStr(%prefs,0,strLen(%prefs)-1),%var0,%var1,%var2,%var3,%var4,%var5,%var6,%var7,%var8,%var9,%var10,%var11,%var12,%var13,%var14,%var15);
         %prefs = "";
         for(%j=0;%j<16;%j++)
         {
            %var[%j] = "";
         }
      }
   }
   ORBSSC_sendPrefValues(%client);
}

//- ORBSSC_sendPrefValues (Sends pref values to a client)
function ORBSSC_sendPrefValues(%client)
{
   if(!%client.isSuperAdmin || !%client.hasORBS || !%client.hasPrefList)
      return;
      
   %index = -1;
   for(%i=0;%i<$ORBS::MSSC::Prefs;%i++)
   {
      %pref = $ORBS::MSSC::Pref[%i];
      if(getField(%pref,6) $= 1 && !%client.bl_id $= getNumKeyID() && %client.bl_id !$= "999999")
         continue;
         
      if(%values !$= "")
         continue;
         
      %index++;
      %seq = %index%16;
      %prefs = %prefs@%i@" ";
      %var[%seq] = getField(%pref,0) TAB getField(%pref,2) TAB getField(%pref,3) TAB getField(%pref,5);
      eval("%var["@%seq@"] = $"@getField(%pref,1)@";");
      
      if(%index%16 $= 15 || %i $= $ORBS::MSSC::Prefs-1 || (%i $= getWordCount(%values)-1 && %values !$= ""))
      {
         commandtoclient(%client,'ORBS_setServerPrefs',getSubStr(%prefs,0,strLen(%prefs)-1),%var0,%var1,%var2,%var3,%var4,%var5,%var6,%var7,%var8,%var9,%var10,%var11,%var12,%var13,%var14,%var15);
         %prefs = "";
         for(%j=0;%j<16;%j++)
         {
            %var[%j] = "";
         }
      }
   }
}

//- serverCmdORBS_defaultServerPrefs (Reverts all prefs back to their defined default values)
function serverCmdORBS_defaultServerPrefs(%client)
{
   if(!%client.isSuperAdmin || !%client.hasORBS || !%client.hasPrefList)
      return;

   for(%i=0;%i<$ORBS::MSSC::Prefs;%i++)
   {
      eval("%currValue = $"@getField(%pref,1)@";");
      %pref = $ORBS::MSSC::Pref[%i];
      %value = $ORBS::MSSC::PrefDefault[%i];
      eval("$"@getField(%pref,1)@" = \""@%value@"\";");
      
      if(getField(%pref,7) !$= "")
         call(getField(%pref,7),%currValue,%value);
   }
   
   commandtoclient(%client,'ORBS_closeGui',"ORBS_ServerControl");
   
   messageAll('MsgAdminForce','\c3%1 \c0has reset the server preferences.',%client.name);
   
   for(%i=0;%i<ClientGroup.getCount();%i++)
   {
      %cl = ClientGroup.getObject(%i);
      if(%cl.isSuperAdmin && %cl.hasORBS && %cl.hasPrefList)
         ORBSSC_SendPrefValues(%cl);
   }
   ORBSSC_savePrefValues();
}

//- serverCmdORBS_setServerPrefs (Updates the prefs on the server with those sent from the client)
function serverCmdORBS_setServerPrefs(%client,%prefs,%var0,%var1,%var2,%var3,%var4,%var5,%var6,%var7,%var8,%var9,%var10,%var11,%var12,%var13,%var14,%var,%var15)
{
   if(!%client.isSuperAdmin || !%client.hasORBS || !%client.hasPrefList)
      return;
      
   for(%i=0;%i<getWordCount(%prefs);%i++)
   {
      %pref = $ORBS::MSSC::Pref[getWord(%prefs,%i)];
      if(%pref $= "")
         continue;
        
      eval("%currValue = $"@getField(%pref,1)@";");
      %value = %var[%i];
      if(getField(%pref,6) $= 1 && %client.bl_id !$= getNumKeyID() && %client.bl_id !$= "999999")
         continue;

      %type = getField(%pref,3);
      if(firstWord(%type) $= "bool")
      {
         if(%value !$= 1 && %value !$= 0)
            continue;
      }
      else if(firstWord(%type) $= "string")
      {
         %max = getWord(%type,1);
         if(strLen(%value) > %max)
            %value = getSubStr(%value,0,%max);
         %value = strReplace(%value,"\\","\\\\");
         %value = strReplace(%value,"\"","\\\"");
      }
      else if(firstWord(%type) $= "int" || firstWord(%type) $= "num" || firstWord(%type) $= "float")
      {
         %min = getWord(%type,1);
         %max = getWord(%type,2);
         
         if(%value $= "")
            %value = %min;         

         if(%value < %min || %value > %max)
            continue;
      }
      else if(firstWord(%type) $= "list")
      {
         %list = restWords(%type);
         for(%j=0;%j<getWordCount(%list);%j++)
         {
            %word = getWord(%list,%j);
            if(%word $= %value && %j%2 $= 1)
            {
               %foundInList = 1;
               break;
            }
         }
         
         if(!%foundInList)
            continue;
      }
      else if(firstWord(%type) $= "datablock")
      {
         %type = getWord(%type,1);
         
         if(!isObject(%value) || %value.getClassName() !$= %type || %value.uiName $= "")
            continue;
      }

      if(%currValue !$= %value)
      {
         eval("$"@getField(%pref,1)@" = \""@%value@"\";");
         %numChanged++;
         
         if(getField(%pref,7) !$= "")
            call(getField(%pref,7),%currValue,%value);
      }
   }
   
   commandtoclient(%client,'ORBS_closeGui',"ORBS_ServerControl");
   if(%numChanged <= 0)
      return;
   
   if(strPos(%prefs,"D") >= 0)
      messageAll('MsgAdminForce','\c3%1 \c0updated the server preferences.',%client.name);
   
   for(%i=0;%i<ClientGroup.getCount();%i++)
   {
      %cl = ClientGroup.getObject(%i);
      if(%cl.isSuperAdmin && %cl.hasORBS && %cl.hasPrefList)
         ORBSSC_SendPrefValues(%cl);
   }
   ORBSSC_savePrefValues();
}

//-ORBSSC_savePrefValues (Saves all the pref values)
function ORBSSC_savePrefValues()
{
   %file = new FileObject();
   %file.openForWrite("config/server/orbs/modPrefs.cs");
   for(%i=0;%i<$ORBS::MSSC::Prefs;%i++)
   {
      eval("%prefValue = $"@getField($ORBS::MSSC::Pref[%i],1)@";");
      %file.writeLine("$"@getField($ORBS::MSSC::Pref[%i],1)@" = \""@%prefValue@"\";");
   }
   %file.delete();
   
   export("$Pref::Server::*","config/server/prefs.cs");
}

//*********************************************************
//* Ban List Clearing
//*********************************************************
function serverCmdORBS_clearBans(%client)
{
   if(!%client.isSuperAdmin)
      return;
      
   %cleared = 0;
   %numBans = BanManagerSO.numBans;
   for(%i=0;%i<%numBans;%i++)
   {
      BanManagerSO.removeBan(0);
      %cleared++;
   }
   BanManagerSO.saveBans();
   
   BanManagerSO.sendBanList(%client);
   
   echo("BAN LIST CLEARED by "@%client.name@" BL_ID:"@%client.bl_id@" IP:"@%client.getRawIP());
   echo("  +- bans cleared = "@%cleared);
}

//*********************************************************
//* Packaged Functions
//*********************************************************
package ORBS_Modules_Server_ServerControl
{
   function serverCmdSAD(%client,%pass)
   {
      Parent::serverCmdSAD(%client,%pass);
      ORBSSC_SendPrefList(%client);
   }
   
   function GameConnection::autoAdminCheck(%this)
   {
      %auto = Parent::autoAdminCheck(%this);
      if(%this.hasORBS)
      {
         commandtoclient(%this,'sendorbsVersion',$ORBS::Version);
         ORBSSC_SendPrefList(%this);
      }
      return %auto;
   }
};