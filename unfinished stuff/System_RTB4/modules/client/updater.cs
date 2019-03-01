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
//#   Modules / Client / Updater
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::Updater = 1;
	
//*********************************************************
//* Module Class
//*********************************************************
new ScriptObject(ORBS_Client_Updater)
{
   // tcp factory
   tcp = ORBS_Networking.createFactory("orbs.daprogs.com","80","/apiRouter.php?d=APIUM");
};
ORBSGroup.add(ORBS_Client_Updater);
	
//*********************************************************
//* API Methods
//*********************************************************
//- ORBS_Client_Updater::getUpdates (retrieves orbs updates from the server)
function ORBS_Client_Updater::getUpdates(%this)
{
   %data = %this.tcp.getPostData("GETUPDATES",0,$ORBS::Version,$Version);
   
   %this.tcp.post(%data,%this,"onUpdateReply");
}
	
//- ORBS_Client_Updater::onUpdateReply (Reply from version controller)
function ORBS_Client_Updater::onUpdateReply(%this,%tcp,%factory,%line)
{
   if(getField(%line,1))
   {
      %version = getField(%line,2);
      %date = getField(%line,3);
      %filesize = getField(%line,4);
      
      canvas.pushDialog(ORBS_Updater);
      ORBSCU_Version.setText("v"@%version);
      ORBSCU_Date.setText(%date);
      ORBSCU_Size.setText(byteRound(%filesize));
      ORBSCU_Speed.setText("N/A");
      ORBSCU_Done.setText("0kb");
      
      ORBSCU_Progress.setValue(0);
      ORBSCU_ProgressText.setValue("Ready to Download");
      
      ORBSCU_UpdateButton.setActive(1);
      ORBSCU_UpdateButton.command = "ORBS_Client_Updater.downloadUpdate(\""@%version@"\");";
      ORBSCU_ChangeLogButton.command = "ORBS_Client_Updater.getChangeLog(\""@%version@"\");";
   }
}

//- ORBS_Client_Updater::getChangeLog (retrieves change log for specific version)
function ORBS_Client_Updater::getChangeLog(%this,%version)
{
   %data = %this.tcp.getPostData("GETCHANGELOG",%version);
   
   %this.tcp.post(%data,%this,"onChangeLog","","","onChangeLogEnd");
   
   ORBSCU_ChangeLog_Title.setText("Change Log for ORBS v"@%version@":");
   ORBSCU_ChangeLog_Text.setText("");
   
   MessagePopup("Please Wait","Locating Change Log for ORBS v"@%version@"...");
}

//- ORBS_Client_Updater::onChangeLog (handles change log response)
function ORBS_Client_Updater::onChangeLog(%this,%tcp,%factory,%line)
{
   if(getField(%line,1) $= "x")
   {
		ORBS_Client_Updater::onChangeLogEnd(%this,%tcp,%factory);
   }
   else
   {
		if(getField(%line,1) $= 0)
		{
			MessageBoxOK("Oh Dear","The Change Log for this update could not be found. Sorry.");
			MessagePopup("","",1);
		}
		else
			ORBSCU_ChangeLog_Text.setText(ORBSCU_ChangeLog_Text.getText()@getField(%line,1)@"<br>");
	}
}

//- ORBS_Client_Updater::onChangeLogEnd (Callback for end of changelog transmission)
function ORBS_Client_Updater::onChangeLogEnd(%this,%tcp,%factory)
{
   if(ORBSCU_ChangeLog_Text.getText() !$= "")
   {
      canvas.pushDialog(ORBSCU_ChangeLog);
   }
   MessagePopup("","",1);
}
ORBS_Client_Updater.getUpdates();

//*********************************************************
//* Update Downloader
//*********************************************************
//- ORBS_Client_Updater::downloadUpdate (downloads a new version)
function ORBS_Client_Updater::downloadUpdate(%this,%version)
{
   if(!isWriteableFilename("Add-Ons/System_oRBs.zip"))
   {
      MessageBoxOK("Oh Dear!","Your System_oRBs.zip is read-only and cannot be overwritten.\n\nPlease download the latest ORBS manually from our website, or set System_oRBs.zip to not be read-only.");
      return;
   }
   
   if(isObject(ORBS_Client_Updater_TCP))
      ORBS_Client_Updater_TCP.setName("");
   
   %tcp = new TCPObject(ORBS_Client_Updater_TCP)
   {
      version = %version;
   };
   ORBSGroup.add(%tcp);

   %tcp.connect("orbs.daprogs.com:80");
   
   ORBSCU_UpdateButton.setActive(0);
   ORBSCU_ProgressText.setText("Locating Update...");
}

//- ORBS_Client_Updater_TCP::onConnected (Connection success callback)
function ORBS_Client_Updater_TCP::onConnected(%this)
{
	$lskip = 0;
   %content = "c=DLUPDATE&n="@$Pref::Player::NetName@"&arg1="@%this.version@"&"@$ORBS::Connection::Session;
   %contentLen = strLen(%content);
   
   %this.send("POST /apiRouter.php?d=APIUM HTTP/1.0\r\nHost: orbs.daprogs.com\r\nUser-Agent: Torque/1.0\r\nContent-Type: application/x-www-form-urlencoded\r\nContent-Length: "@%contentLen@"\r\n\r\n"@%content@"\r\n");
//   %this.send("GET /orbs/4.06/System_oRBs.zip HTTP/1.0\r\nHost: orbs.daprogs.com\r\nConnection: Close\r\nAccept-Encoding: identity\r\nUser-Agent: Torque/1.0\r\n\r\n");
// %this.send("GET" SPC %this.dir SPC "HTTP/1.1\nHost:" SPC %this.server @ "\r\nConnection: Close\r\nAccept-Encoding: identity\r\nUser-Agent: Torque/1.0\r\n\r\n");
}
//- ORBS_Client_Updater_TCP::onLine (Callback for line response)
function ORBS_Client_Updater_TCP::onLine(%this,%line)
{
   if(strPos(%line,"404 Not Found") >= 0)
   {
      MessageBoxOK("Error!","An error occured with the updater service and the update could not be located3.");
      canvas.popDialog(ORBS_Updater);
      return;
   }
   
   if(strPos(%line,"DL-Result:") $= 0)
   {
      %this.dlResult = getWord(%line,1);
      if(getWord(%line,1) $= 0)
      {
         MessageBoxOK("Error!","An error occured with the updater service and the update could not be located1.");
         Canvas.popDialog(ORBS_Updater);
         return;
      }
   }
   
   if(strPos(%line,"Content-Length:") $= 0)
      %this.contentSize = getWord(%line,1);
      
	if(%line $= "")
	{
		if($lskip == 0)
		{
			$lskip = 1;
		}
		else
		{
			if(%this.dlResult !$= 1)
			{
				MessageBoxOK("Error!","An error occured with the updater service and the update could not be located2.");
				Canvas.popDialog(ORBS_Updater);
				return;
			}
		%this.setBinarySize(%this.contentSize);
		}
	}
}

//- ORBS_Client_Updater_TCP::onBinChunk (On binary chunk received)
function ORBS_Client_Updater_TCP::onBinChunk(%this,%chunk)
{
   if(%this.timeStarted $= "")
      %this.timeStarted = getSimTime();
      
   if(%chunk >= %this.contentSize)
   {
      if(isWriteableFilename("Add-Ons/System_oRBs.zip"))
      {
         %this.saveBufferToFile("Add-Ons/System_oRBs.zip.new");
         %this.disconnect();
         
         ORBSCU_Progress.setValue(1);
         ORBSCU_ProgressText.setText("Download Complete");
         ORBSCU_Speed.setText("N/A");
         ORBSCU_Done.setText(byteRound(%this.contentSize));
         
         if(fileDelete("Add-Ons/System_oRBs.zip"))
         {
            fileCopy("Add-Ons/System_oRBs.zip.new","Add-Ons/System_oRBs.zip");
            fileDelete("Add-Ons/System_oRBs.zip.new");
            
            MessageBoxOK("Huzzah!","You have successfully downloaded ORBS v"@%this.version@".\n\nBlockland must now close to complete the install.","quit();");
         }
         else
         {
            MessageBoxOK("Whoops!","Unable to delete System_oRBs.zip to replace it with the new version.\n\nPlease go to your Add-Ons folder and replace System_oRBs.zip with System_oRBs.zip.new to complete the update.");
         }
      }
      else
      {
         MessageBoxOK("Oh Dear!","Unable to save ORBS v"@%this.version@". Your System_oRBs.zip is read-only and cannot be overwritten.\n\nPlease download the latest ORBS manually from the website.");
      }
   }
   else
   {
      ORBSCU_Progress.setValue(%chunk/%this.contentSize);
      ORBSCU_ProgressText.setText(mFloor((%chunk/%this.contentSize)*100)@"%");
      ORBSCU_Speed.setText(mFloatLength(%chunk/(getSimTime()-%this.timeStarted),2)@"kb/s");
      ORBSCU_Done.setText(byteRound(%chunk));
   }
}

//- ORBS_Client_Updater_TCP::onDisconnect (disconnected callback)
function ORBS_Client_Updater_TCP::onDisconnect(%this)
{
   %this.delete();
}