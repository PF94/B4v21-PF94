//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 262 $
//#      $Date: 2011-11-15 19:00:26 +0000 (Tue, 15 Nov 2011) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/support/functions.cs $
//#
//#      $Id: functions.cs 262 2011-11-15 19:00:26Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Support / Functions
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Support::Functions = 1;

//*********************************************************
//* ORBS Specific
//*********************************************************
//- ORBS_addControlMap (adds a control map to the controls list)
function ORBS_addControlMap(%inputDevice,%keys,%name,%command)
{
   if(!$ORBS::addedCatSep)
   {
	   $remapDivision[$remapCount] = "System oRBs";
	   $ORBS::addedCatSep = 1;
   }
   $remapName[$remapCount] = %name;
   $remapCmd[$remapCount] = %command;
   $remapCount++;
}

//*********************************************************
//* Generic
//*********************************************************
//- lastWord (returns the last word in a string)
function lastWord(%string)
{
   return getWord(%string,getWordCount(%string)-1);
}

//- addItemToList (adds an item to a space delimited list)
function addItemToList(%string,%item)
{
	if(hasItemOnList(%string,%item))
		return %string;

	if(%string $= "")
		return %item;
	else
		return %string SPC %item;
}

//- hasItemOnList (checks for an item in a list)
function hasItemOnList(%string,%item)
{
	for(%i=0;%i<getWordCount(%string);%i++)
	{
		if(getWord(%string,%i) $= %item)
			return 1;
	}
	return 0;
}

//- removeItemFromList (removes an item from a space-delimited list)
function removeItemFromList(%string,%item)
{
	if(!hasItemOnList(%string,%item))
		return %string;

	for(%i=0;%i<getWordCount(%string);%i++)
	{
		if(getWord(%string,%i) $= %item)
		{
			if(%i $= 0)
				return getWords(%string,1,getWordCount(%string));
			else if(%i $= getWordCount(%string)-1)
				return getWords(%string,0,%i-1);
			else
				return getWords(%string,0,%i-1) SPC getWords(%string,%i+1,getWordCount(%string));
		}
	}
}

//- SimGroup::swap (swaps the position of two children of a simgroup)
function SimGroup::swap(%this,%a,%b)
{
	%childA = %this.getObject(%a);
	%childB = %this.getObject(%b);

	for(%i=0;%i<%this.getCount();%i++)
	{
		%ctrl = %this.getObject(%i);
		%order[%i] = %ctrl;
	}
	%order[%a] = %childB;
	%order[%b] = %childA;

	for(%i=0;%i<%this.getCount();%i++)
	{
		%this.pushToBack(%order[%i]);
	}
}

//- SimGroup::getTop (gets to the top of an object tree)
function SimGroup::getTop(%this)
{
   %parent = %this;
   while(isObject(%parent.getGroup()))
   {
      %parent = %parent.getGroup();
   }
   return %parent;
}

//- SimGroup::getIndex (returns index position within parent)
function SimGroup::getIndex(%this,%object)
{
   if(!%this.isMember(%object))
      return -1;
      
   for(%i=0;%i<%this.getCount();%i++)
   {
      if(%this.getId() $= %object.getId())
         return %i;
   }
   return -1;
}

//- SimGroup::getBottom (recursively gets to the bottom of an object tree, with %offset being an offset from the bottom)
function SimGroup::getBottom(%this,%offset)
{
   %parent = %this;
   %layer[0] = %parent;

   %k = 1;
   while(%parent.getCount() >= 1)
   {
      %parent = %parent.getObject(0);
      %layer[%k] = %parent;
      %k++;
   }
   if(%offset > %k)
      %offset = %k-1;
      
   return %layer[%k-%offset-1];
}

//- SimGroup::clear (had problems with standard method not doing the job, so overloaded it)
function SimGroup::clear(%this)
{
   while(%this.getCount() > 0)
   {
      %this.getObject(0).delete();
   }
}

//- filterString (removes all characters not in %allowed)
function filterString(%string,%allowed)
{
   for(%i=0;%i<strLen(%string);%i++)
   {
      %char = getSubStr(%string,%i,1);
      if(strPos(%allowed,%char) >= 0)
         %return = %return@%char;
   }
   return %return;
}

//- filterOutString (removes all characters in %disallowed)
function filterOutString(%string,%disallowed)
{
   for(%i=0;%i<strLen(%string);%i++)
   {
      %char = getSubStr(%string,%i,1);
      if(strPos(%disallowed,%char) < 0)
         %return = %return@%char;
   }
   return %return;
}

//- stringMatch (returns true if contents of %string can be found in %allowed)
function stringMatch(%string,%allowed)
{
   for(%i=0;%i<strLen(%string);%i++)
   {
      %char = getSubStr(%string,%i,1);
      if(strPos(%allowed,%char) < 0)
         return 0;
   }
   return 1;
}

//- isReadonly (determines whether a particular file is read only or not)
function isReadonly(%file)
{
   return (isWriteableFileName(%file) == 0);
}

//- byteRound (rounds bytes to b,mb and kb)
function byteRound(%bytes)
{
	if(%bytes $= "")
		return "0b";

	if(%bytes > 1048576)
//		%result = roundMegs(%bytes/1048576)@"MB";
		%result = mFloatLength(%bytes/1048576,2)@"MB";
	else if(%bytes > 1024)
		%result = mFloatLength(%bytes/1024,2)@"kB";
	else
		%result = %bytes@"b";
	return %result;
}

//- isInt (determines whether or not a string can be considered an integer)
function isInt(%string)
{
   return (%string $= mFloatLength(%string,0));
}

//- trimLeading (removes all leading spaces and html linebreaks)
function trimLeading(%string)
{
   for(%i=0;%i<strLen(%string);%i++)
   {
      if(getSubStr(%string,%i,1) $= " ")
         continue;
      else
         break;
   }
   %string = getSubStr(%string,%i,strLen(%string));
   
   for(%i=0;%i<strLen(%string);%i+=4)
   {
      if(getSubStr(%string,%i,4) $= "<br>")
         continue;
      else
         break;
   }
   return getSubStr(%string,%i,strLen(%string));
}

//- trimTrailing (removes all trailing spaces and html linebreaks)
function trimTrailing(%string)
{
   for(%i=strLen(%string)-1;%i>=0;%i--)
   {
      if(getSubStr(%string,%i,1) $= " ")
         continue;
      else
         break;
   }
   %string = getSubStr(%string,0,%i+1);
   
   for(%i=strLen(%string)-1;%i>=0&&(%i-4)>=0;%i-=4)
   {
      if(getSubStr(%string,%i-3,4) $= "<br>")
         continue;
      else
         break;
   }
   return getSubStr(%string,0,%i+1);
}

//- getRandomString (returns a random string of the specified %length)
function getRandomString(%length)
{
   %numeroalphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
   
   for(%i=0;%i<%length;%i++)
   {
      %string = %string@getSubStr(%numeroalphabet,getRandom(0,strlen(%numeroalphabet)-1),1);
   }
   return %string;
}

//- strTrim (shortcut to trim both trailing and leading)
function strTrim(%string)
{
   %string = trimLeading(%string);
   %string = trimTrailing(%string);
   return %string;
}

//- alphaCompare (determines alphabetic order of two strings)
function alphaCompare(%string1,%string2)
{
   %alphabet = "abcdefghijklmnopqrstuvwxyz";
   
   %longString = %string1;
   %shortString = %string2;
   %longNum = 1;
   %shortNum = 2;
   if(strLen(%string2) > strLen(%string1))
   {
      %longString = %string2;
      %shortString = %string1;
      %longNum = 2;
      %shortNum = 1;
   }
   
   %winString = 1;
   for(%i=0;%i<strLen(%longString);%i++)
   {
      if(%i<strLen(%shortString))
      {
         %longChar = strLwr(getSubStr(%longString,%i,1));
         %shortChar = strLwr(getSubStr(%shortString,%i,1));
         
         if(strPos(%alphabet,%longChar) < strPos(%alphabet,%shortChar))
         {
            %winString = %longNum;
            break;
         }
         else if(strPos(%alphabet,%longChar) > strPos(%alphabet,%shortChar))
         {
            %winString = %shortNum;
            break;
         }
      }
   }
   return %winString;
}

//- Anim_EaseInOut (Easing Animation)
function Anim_EaseInOut(%time,%begin,%change,%duration)
{
   if((%time/=%duration/2) < 1)
      return %change/2 * mPow(%time,3) + %begin;
   return %change/2 * (mPow(%time-2,3) + 2) + %begin;
}

//- sortFields (Probably like, the hackiest sorting method ever - I cant be bothered to write a proper one)
function sortFields(%fields)
{
   %fields = strReplace(%fields,",","\t");
   %list = new GuiTextListCtrl();
   for(%i=0;%i<getFieldCount(%fields);%i++)
   {
      %field = strReplace(getField(%fields,%i),"=>","\t");
      %list.addRow(getField(%field,0),getField(%field,1));
   }
   %list.sort(0);
   
   for(%i=0;%i<%list.rowCount();%i++)
   {
      %return = %return@%list.getRowId(%i)@"=>"@%list.getRowText(%i)@",";
   }
   %list.delete();
   
   if(strLen(%return) > 0)
      %return = getSubStr(%return,0,strLen(%return)-1);
      
   return %return;
}

//- getFileContents (returns the entire contents of a file in a delimited string)
function getFileContents(%file)
{
   %IO = new FileObject();
   if(%IO.openForRead(%file))
   {
      while(!%IO.isEOF())
      {
         %return = (%return $= "") ? %IO.readLine() : %return TAB %IO.readLine();
      }
      %IO.delete();
      return %return;
   }
   else
      return 0;
}

//- filterKey (locates bl key-like strings)
function filterKey(%string)
{
   %string = strReplace(%string,"-","\t");
   %string = strReplace(%string," ","\t");
   
   %stageCheck = 0;
   for(%i=0;%i<getFieldCount(%string);%i++)
   {
      if(stringMatch(getField(%string,%i),"ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789"))
      {
         if(%stageCheck $= 0)
         {
            if(strlen(getField(%string,%i)) $= 5)
            {
               %stageCheck++;
            }
         }
         else
         {
            if(strlen(getField(%string,%i)) $= 4)
            {
               %stageCheck++;
               
               if(%stageCheck > 3)
                  return 1;
            }
            else
            {
               %stageCheck = 0;
            }
         }
      }
      else
         %stageCheck = 0;
   }
   return 0;
}

//- timeDiffString (gets time difference as string)
function timeDiffString(%timeA,%timeB)
{
   %unit[0] = 60 * 60 * 24 * 365;
   %unit[1] = 60 * 60 * 24 * 30;
   %unit[2] = 60 * 60 * 24 * 7;
   %unit[3] = 60 * 60 * 24;
   %unit[4] = 60 * 60;
   %unit[5] = 60;
   %unit[6] = 1;
   
   %name[0] = "year";
   %name[1] = "month";
   %name[2] = "week";
   %name[3] = "day";
   %name[4] = "hour";
   %name[5] = "minute";
   %name[6] = "second";
   
   %diff = %timeA - %timeB;
   if(%diff == 0)
      return "A moment";
   else if(%diff == 1)
      return "1 second";
   else if(%diff < 60)
      return %diff SPC "seconds";
      
   for(%i=0;%i<7;%i++)
   {
      %secs = %unit[%i];
      %name = %name[%i];
      
      if((%count = mFloor(%diff/%secs)) != 0)
         break;
   }
   return (%count == 1) ? "1" SPC %name : %count SPC %name@"s";
}

//- numberFormat (formats a number with commas)
function numberFormat(%number)
{
   if(strLen(%number) <= 3)
      return %number;
      
   %k = 0;
   for(%i=strLen(%number)-1;%i>0;%i--)
   {
      if(%k%3 $= 2)
         %number = getSubStr(%number,0,%i)@","@getSubStr(%number,%i,1000);
      %k++;
   }
   return %number;
}

//- parseLinks (converts urls into torque ml links)
function parseLinks(%string)
{
   %wordCount = getWordCount(%string);
   for(%i=0;%i<%wordCount;%i++)
      %words[%i] = getWord(%string,%i);
    
   for(%i=0;%i<%wordCount;%i++)
   {
      if(getSubStr(%words[%i],0,7) $= "http://")
         %words[%i] = "<a:"@strReplace(%words[%i],"http://","")@">"@%words[%i]@"</a>";
      else if(getSubStr(%words[%i],0,8) $= "https://")
         %words[%i] = "<a:"@strReplace(%words[%i],"https://","")@">"@%words[%i]@"</a>";
      else if(getSubStr(%words[%i],0,6) $= "ftp://")
         %words[%i] = "<a:"@strReplace(%words[%i],"ftp://","")@">"@%words[%i]@"</a>";
   }
   
   %string = "";
   for(%i=0;%i<%wordCount;%i++)
   {
      %string = %string@%words[%i]@" ";
   }
   return trim(%string);
}