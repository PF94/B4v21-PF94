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
//#   Modules / Client / Color Manager
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Modules::Client::ColorManager = 1;

//*********************************************************
//* Extract Default Colorset
//*********************************************************
if(!isFile("Add-Ons/Colorset_Default/colorSet.txt"))
{
   %write = new FileObject();
   %read = new FileObject();
   
   %read.openForRead("Add-Ons/System_oRBs/files/Colorset_Default/description.txt");
   %write.openForWrite("Add-Ons/Colorset_Default/description.txt");
   while(!%read.isEOF())
      %write.writeLine(%read.readLine());
   %write.close();
   %read.close();
   
   %read.openForRead("Add-Ons/System_oRBs/files/Colorset_Default/colorSet.txt");
   %write.openForWrite("Add-Ons/Colorset_Default/colorSet.txt");
   while(!%read.isEOF())
      %write.writeLine(%read.readLine());
   %write.close();
   %read.close();
   
   %write.delete();
   %read.delete();
}

//*********************************************************
//* Variable Declarations
//*********************************************************
$ORBS::MCCM::Colorsets = 0;

//*********************************************************
//* Color Set Gui
//*********************************************************
//- CustomGameGui::clickColorset (button action on menu)
function CustomGameGui::clickColorSet(%this)
{
   %this.hideAllTabs();
   
   CustomGameGui_ColorsetWindow.setVisible(true);
   CustomGameGui_ColorsetHilight.setVisible(true);
}

//- CustomGameGui:createColorsetGui (creates the colorset gui and populates)
function CustomGameGui::createColorsetGui(%this)
{
   CustomGameGui_ColorsetSwatch.clear();
   CustomGameGui_ColorsetPreview.clear();
   
   if(isReadonly("config/server/colorSet.txt"))
   {
      messageBoxOK("Oops!","It appears as though your colorset.txt file is read-only. That means you can't use the color manager feature.\n\nYou can try deleting colorSet.txt in the config/server/ folder to fix this problem.");
      return;
   }
   
   if($ORBS::MCCM::Colorsets <= 0)
      CustomGameGui.loadColorsets();
      
   $ORBS::MCCM::Selected = "";
   %currCS = new FileObject();
   %chckCS = new FileObject();
   for(%i=0;%i<$ORBS::MCCM::Colorsets;%i++)
   {
      %colorSet = "Add-Ons/"@getField($ORBS::MCCM::Colorset[%i],0)@"/colorSet.txt";
      %currCS.openForRead("config/server/colorSet.txt");
      %chckCS.openForRead(%colorSet);
      %match = %colorSet;
      while(!%currCS.isEOF() && !%match !$= "")
      {
         if(%currCS.readLine() !$= %chckCS.readLine())
            %match = "";
         else if(%currCS.isEOF() && !%chckCS.isEOF() || !%currCS.isEOF() && %chckCS.isEOF())
            %match = "";
            
         if(%match $= "")
            break;
      }
      %currCS.close();
      %chckCS.close();
      
      if(%match !$= "")
      {
         $ORBS::MCCM::Selected = %match;
         break;
      }
   }
   %currCS.delete();
   %chckCS.delete();
   
   %k = 0;
   if($ORBS::MCCM::Selected $= "")
   {
      %ctrl = new GuiRadioCtrl()
      {
         profile = "ImpactCheckProfile";
         group = 1;
         
         command = "CustomGameGui.previewColorset(\"config/server/colorSet.txt\");$ORBS::MCCM::Selected = \"config/server/colorSet.txt\";";
      };
      CustomGameGui_ColorsetSwatch.add(%ctrl);
      
      %ctrl.resize(10,0,getWord(CustomGameGui_ColorsetSwatch.extent, 0),%this.fontSize);
      
      %ctrl.setValue(1);
      CustomGameGui.previewColorset("config/server/colorSet.txt");
      
      %k++;
   }
   
   for(%i=$ORBS::MCCM::Colorsets-1;%i>=0;%i--)
   {
      %data = $ORBS::MCCM::Colorset[%i];
      %file = getField(%data,0);
      %name = getField(%data,1);
      
      %ctrl = new GuiRadioCtrl()
      {
         profile = "ImpactCheckProfile";
         group = 1;
         
         command = "CustomGameGui.previewColorset(\"Add-Ons/"@%file@"/colorSet.txt\");$ORBS::MCCM::Selected = \"Add-Ons/"@%file@"/colorSet.txt\";";
      };
      CustomGameGui_ColorsetSwatch.add(%ctrl);
      
      %ctrl.setText(%name);
      %ctrl.resize(10,%k * %this.fontSize,getWord(CustomGameGui_ColorsetSwatch.extent, 0),%this.fontSize);
      
      if("Add-Ons/"@%file@"/colorSet.txt" $= $ORBS::MCCM::Selected)
      {
         %ctrl.setValue(1);
         CustomGameGui.previewColorset($ORBS::MCCM::Selected);
      }
      
      %k++;
   }
   CustomGameGui_ColorsetSwatch.resize(0,0,getWord(CustomGameGui_ColorsetSwatch.extent,0),%k * %this.fontSize);
}

//- CustomGameGui::loadColorsets (caches the list of available colorsets)
function CustomGameGui::loadColorsets(%this)
{
   $ORBS::MCCM::Colorsets = 0;
	%colorset = FindFirstFile("Add-Ons/Colorset_*/colorSet.txt");
	while(strLen(%colorset) > 0)
	{
      %path = getSubStr(%colorset,0,strLen(%colorset)-12);
      %file = getSubStr(%path,8,strLen(%path)-9);
      
      if(isFile(%path@"description.txt"))
      {  
         %title = "Unnamed Colorset";
         
         %fo = new FileObject();
         if(%fo.openForRead(%path@"description.txt"))
         {
            while(!%fo.isEOF())
            {
               %line = %fo.readLine();
               if(strPos(%line,"Title:") $= 0)
               {
                  %title = getWords(%line,1,getWordCount(%line)-1);
                  break;
               }
            }
            %fo.close();
         }
         else
            echo("\c2ERROR: Unable to open description.txt for reading in "@%file);
            
         $ORBS::MCCM::Colorset[$ORBS::MCCM::Colorsets] = %file TAB %title;
         $ORBS::MCCM::Colorsets++;
      }
      else
         echo("\c2ERROR: Skipped "@%file@" due to missing description.txt");
      
		%colorset = FindNextFile("Add-Ons/Colorset_*/colorSet.txt");
	}
}

//- CustomGameGui::previewColorset (generates a preview for the selected colorset)
function CustomGameGui::previewColorset(%this, %filepath)
{
   CustomGameGui_ColorsetPreview.clear();
   
   %file = new FileObject();
   if(%file.openForRead(%filepath))
   {
      while(!%file.isEOF())
      {
         %line = %file.readLine();
         if(%line !$= "" && strPos(%line,"DIV:") !$= 0)
            %numRows++;
         else if(strPos(%line,"DIV:") $= 0)
         {
            %numCols++;
            if(%numRows > %maxRows)
               %maxRows = %numRows;
               
            %numRows = 0;
         }
      }
   }
   %file.close();
   
   %numCols += 2;
   %maxRows += 2;
   
   %dimension = mFloor(getWord(CustomGameGui_ColorsetPreview.getGroup().extent,0)/%numCols);
   if((%maxRows * %dimension) > getWord(CustomGameGui_ColorsetPreview.getGroup().extent,1))
      %dimension = mFloor(getWord(CustomGameGui_ColorsetPreview.getGroup().extent,1)/%maxRows);
      
   %extent = %dimension SPC %dimension;
   
   if(%file.openForRead(%filepath))
   {
      while(!%file.isEOF())
      {
         %line = %file.readLine();
         if(%line !$= "" && strPos(%line,"DIV:") !$= 0)
         {
            %r = getWord(%line,0);
            %g = getWord(%line,1);
            %b = getWord(%line,2);
            %a = getWord(%line,3);

            if(!isInt(getWord(%line,0)))
            {
               %r = mFloor(%r*255);
               %g = mFloor(%g*255);
               %b = mFloor(%b*255);
               %a = mFloor(%a*255);
            }
            %color = %r SPC %g SPC %b SPC %a;

            %xPos = (%currCol*%dimension);
            %yPos = (%currRow*%dimension);
            
            if(%a < 255)
            {
               %b = new GuiBitmapCtrl()
               {
                  profile = "GuiDefaultProfile";
                  position = %xPos SPC %yPos;
                  extent = %extent;
                  bitmap = $ORBS::Path @ "images/ui/checkedGrid";
                  wrap = true;
               };
               CustomGameGui_ColorsetPreview.add(%b);
            }
            
            %c = new GuiSwatchCtrl()
            {
               profile = "GuiDefaultProfile";
               position = %xPos SPC %yPos;
               extent = %extent;
               color = %color;
            };
            CustomGameGui_ColorsetPreview.add(%c);
            
            %d = new GuiBitmapCtrl()
            {
               profile = "GuiDefaultProfile";
               position = %xPos SPC %yPos;
               extent = %extent;
               bitmap = "base/client/ui/btnColor_n";
            };
            CustomGameGui_ColorsetPreview.add(%d);
            %currRow++;
            
            if(%currRow > %maxRow)
               %maxRow = %currRow;
         }
         else if(strPos(%line,"DIV:") $= 0)
         {
            %currRow = 0;
            %currCol++;
         }
      }
   }
   CustomGameGui_ColorsetPreview.extent = (%currcol*%dimension) SPC (%maxRow*%dimension);
   
   %file.close();
   %file.delete();
   
   %xpos = (mFloor(getWord(CustomGameGui_ColorsetPreview.getGroup().extent,0)/2))-(mFloor(getWord(CustomGameGui_ColorsetPreview.extent,0)/2));
   %ypos = (mFloor(getWord(CustomGameGui_ColorsetPreview.getGroup().extent,1)/2))-(mFloor(getWord(CustomGameGui_ColorsetPreview.extent,1)/2));
   CustomGameGui_ColorsetPreview.position = %xpos SPC %ypos;
}

//- CustomGameGui::saveColorset (replaces colorset.txt with selected one)
function CustomGameGui::saveColorset(%this)
{
   %sel = $ORBS::MCCM::Selected;
   
   if(%sel $= "")
      return;

   %input = new FileObject();
   %output = new FileObject();
   if(%input.openForRead(%sel))
   {
      if(%output.openForWrite("config/server/colorSet.txt"))
      {
         while(!%input.isEOF())
         {
            %output.writeLine(%input.readLine());
         }
         %output.close();
      }
      else
         MessageBoxOK("ERROR","Color set could not be saved because your colorSet.txt was invalid.");

      %input.close();
   }
   else
      MessageBoxOK("ERROR","Color set could not be saved because the selection was invalid.");
      
   %input.delete();
   %output.delete();
}

//*********************************************************
//* Color Set Menu Packaging
//*********************************************************
package ORBS_Modules_Client_ColorManager
{
   function CustomGameGui::onRender(%this)
   {
      Parent::onRender(%this);
      
      %this.createColorsetGui();
   }
   
   function CustomGameGui::hideAllTabs(%this)
   {
      Parent::hideAllTabs(%this);
      
      CustomGameGui_ColorsetHilight.setVisible(false);
      CustomGameGui_ColorsetWindow.setVisible(false);
   }
   
   function CustomGameGui::clickSelect(%this)
   {
      Parent::clickSelect(%this);
      
      %this.saveColorset();
   }
};