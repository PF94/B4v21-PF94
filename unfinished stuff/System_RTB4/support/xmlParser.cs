//#############################################################################
//#
//#   Return to Blockland - Version 4
//#
//#   -------------------------------------------------------------------------
//#
//#      $Rev: 259 $
//#      $Date: 2011-11-05 00:41:50 +0000 (Sat, 05 Nov 2011) $
//#      $Author: Ephialtes $
//#      $URL: http://svn.returntoblockland.com/code/trunk/support/xmlParser.cs $
//#
//#      $Id: xmlParser.cs 259 2011-11-05 00:41:50Z Ephialtes $
//#
//#   -------------------------------------------------------------------------
//#
//#   Support / XML Parser
//#
//#############################################################################
//Register that this module has been loaded
$ORBS::Support::XMLParser = 1;

//*********************************************************
//* XML Parser C/D Methods
//*********************************************************
//- XMLParser::onAdd (construcor method)
function XMLParser::onAdd(%this)
{
   // Member Variables
   %this.depth = 0;
   %this.buffer = "";
   %this.debug = 0;
   
   // Just for jokes - the day this parser complies with XML RFC Standards is the day hell freezes over
   %this.xmlCompliance = "1.0";
   
   // Callbacks
   %this.numCallbacks = 0;
   
   // Document Object Model
   %this.DOM = "";
}

//- XMLParser::onRemove (destructor method)
function XMLParser::onRemove(%this)
{
   %this.freeDOM();
}

//*********************************************************
//* XML Parser Maintenance Methods
//*********************************************************
//- XMLParser::freeBuffer (empties stream buffer and resets depth)
function XMLParser::freeBuffer(%this)
{
   %this.numCallbacks = 0;
   %this.depth = 0;
   %this.buffer = "";
   
   return 1;
}

//- XMLParser::newElement (creates a new element object)
function XMLParser::newElement(%this,%element,%value)
{
   %node = new ScriptGroup()
   {
      class = "XMLObjectModelNode";
      
      parent = %this;
      tag = %element;
   };

   if(%value !$= "")
      %value.cData = xmlEncode(%value);
   
   return %node;
}

//- XMLParser::getTop (gets to the top of an xml tree)
function XMLParser::getTop(%this)
{
   %parent = %this;
   while(isObject(%parent.getGroup()) && %parent.getGroup().class $= "XMLObjectModelNode")
   {
      %parent = %parent.getGroup();
   }
   return %parent;
}

//- XMLParser::freeDOM (destroys xml tree structure)
function XMLParser::freeDOM(%this)
{
   if(isObject(%this.DOM))
   {
      %this.DOM.delete();
      return 1;
   }
   return 0;
}

//*********************************************************
//* XML Parser Hook Methods
//*********************************************************
//- XMLParser::registerHandler (registers a handler for a tag)
function XMLParser::registerHandler(%this,%handle,%procedure,%object)
{
   %this.parseHandler[%handle] = %procedure;
   %this.parseObject[%handle] = %object;
   return 1;
}

//- XMLParser::registerCallback (registers a stream event callback)
function XMLParser::registerCallback(%this,%handle,%node)
{
   %this.callbackHandle[%this.numCallbacks] = %handle;
   %this.callbackNode[%this.numCallbacks] = %node;
   %this.numCallbacks++;
}

//*********************************************************
//* XML Parser Public Usage Methods
//*********************************************************
//- XMLParser::bufferData (buffers data then processes it once a full stanza is retrieved)
function XMLParser::bufferData(%this,%data)
{

	%data = strReplace(%data,"\n","");
    %data = strReplace(%data,"\r","");
   
   if(getSubStr(%data,strLen(%data)-1,1) !$= ">")
      return;

//DEBUG
//echo("xml>> " @ %data);
   
   %this.buffer = %this.buffer@%data;
   %buffer = %this.buffer;
   %depth = 0;

   for(%i=0;%i<strLen(%buffer);%i++)
   {
      %partialBuff = getSubStr(%buffer,%i,strLen(%buffer));
      if(getSubStr(%partialBuff,0,2) $= "<?")
      {
         %i+=(strPos(%partialBuff,"?>")+1);
         continue;
      }
      else if(getSubStr(%partialBuff,0,2) $= "</")
      {
         %tag = getSubStr(%partialBuff,2,strPos(%partialBuff,">")-2);
            
         %i+=strPos(%partialBuff,">");
         %depth--;
      }
      else if(getSubStr(%partialBuff,0,1) $= "<")
      {
         if(strPos(%partialBuff,"/>") $= (strPos(%partialBuff,">")-1))
         {
            %i+=strPos(%partialBuff,">");
            continue;
         }
         
         if((strPos(%partialBuff," ") < strPos(%partialBuff,">")) && strPos(%partialBuff," ") > 0)
            %tag = getSubStr(%partialBuff,1,strPos(%partialBuff," ")-1);
         else
            %tag = getSubStr(%partialBuff,1,strPos(%partialBuff,">")-1);

         %i+=strPos(%partialBuff,">");
         %depth++;
      }
   }

   if(%depth $= 0)
   {
      %this.parseBuffer();
      %this.freeBuffer();
   }
}

//- XMLParser::parseBuffer (parses buffer and creates DOM)
function XMLParser::parseBuffer(%this)
{
   %buffer = %this.buffer;
   if(strLen(%buffer) <= 0)
      return 0;
      
   if(trim(%buffer) $= "")
      return 0;
   
   %this.createDOM();
   %this.parseStanza(%this.DOM,%buffer,0);
   %this.throwCallbacks(%this.DOM);
}

//- XMLParser::parseStanza (recursive parsing)
function XMLParser::parseStanza(%this,%parent,%stanza,%depth)
{
   if(strLen(%stanza) <= 0)
      return;
      
   %stanza = trimLeading(%stanza);
   if(strPos(%stanza,"/>") < strPos(%stanza,">") && strPos(%stanza,"/>") > 0)
   {
      %openTag = getSubStr(%stanza,1,strPos(%stanza,"/>")-1);
      %selfClose = 1;
   }
   else
      %openTag = getSubStr(%stanza,1,strPos(%stanza,">")-1);
   %tagType = firstWord(%openTag);
   %tagType = strReplace(%tagType,"/","");

   %xmlNode = new ScriptGroup()
   {
      class = "XMLObjectModelNode";
      
      depth = %depth;
      parent = %parent;
      tag = %tagType;
   };
   %parent.add(%xmlNode);
   
   if(%xmlNode.depth > %this.DOM.depth)
      %this.DOM.depth = %xmlNode.depth;
      
   %parent.child[%parent.children] = %xmlNode;
   %parent.children++;
   
   if(getWordCount(%openTag) > 1)
   {
      %attributes = getWords(%openTag,1,getWordCount(%openTag));
      for(%i=0;%i<strLen(%attributes);%i++)
      {
         %attribute = getSubStr(%attributes,%i,strLen(%attributes));
         %attribute = getSubStr(%attribute,0,strPos(%attribute,"="));
         %value = getStringAttrib(%attributes,%attribute);
         
         %xmlNode.attribute[%xmlNode.attributes] = %attribute;
         %xmlNode.attributes++;
         %xmlNode.attrib[%attribute] = xmlDecode(%value);

         %i+=(strLen(%value)+strLen(%attribute)+3);
      }
   }
   
   if(%selfClose)
   {
      if(strLen(%stanza) > (strPos(%stanza,"/>")+2))
         %this.parseStanza(%parent,getSubStr(%stanza,(strPos(%stanza,"/>")+2),strLen(%stanza)),%depth);
      return;
   }
   
   if(strPos(%stanza,">") $= (strPos(%stanza,"/>")+1))
      %endTag = "/>";
   else
   {
      %contents = getSubStr(%stanza,strPos(%stanza,">")+1,strLen(%stanza));
      %endTag = "</"@%tagType@">";
      if(strPos(%contents,%endTag) >= 0)
         %contents = getSubStr(%contents,0,strPos(%contents,%endTag));
      else
         %endTag = ">";

      if(strPos(%contents,"<") >= 0)
      {
         %this.parseStanza(%xmlNode,%contents,%depth+1);
      }
      else  
         %xmlNode.cData = xmlDecode(%contents);
   }
   
   if(strLen(%stanza) > (strPos(%stanza,%endTag)+strLen(%endTag)) && %endTag !$= ">")
   {
      %this.parseStanza(%parent,getSubStr(%stanza,(strPos(%stanza,%endTag)+strLen(%endTag)),strLen(%stanza)),%depth);
   }
}

//- XMLParser::throwCallbacks (throws callbacks from stanza parsing)
function XMLParser::throwCallbacks(%this,%node)
{
   for(%i=0;%i<%node.children;%i++)
   {
      %child = %node.child[%i];
      if(%this.parseHandler[%child.tag] !$= "")
      {
         if(isObject(%this.parseObject[%child.tag]))
            eval(%this.parseHandler[%child.tag]@"("@%this.parseObject[%child.tag]@",\""@%this@"\",\""@%child@"\");");
         else
            eval(%this.parseHandler[%child.tag]@"(\""@%this@"\",\""@%child@"\");");
      }
      
      if(%child.children >= 1)
         %this.throwCallbacks(%child);

      if(%this.parseHandler["/"@%child.tag] !$= "")
      {
         if(isObject(%this.parseObject["/"@%child.tag]))
            eval(%this.parseHandler["/"@%child.tag]@"("@%this.parseObject["/"@%child.tag]@",\""@%this@"\",\""@%child@"\");");
         else
            eval(%this.parseHandler["/"@%child.tag]@"(\""@%this@"\",\""@%child@"\");");
      }
   }
}

//*********************************************************
//* XML Parser Debugging Methods
//*********************************************************
//- XMLParser::dumpXML (Outputs DOM of parser to filepath)
function XMLParser::dumpXML(%this,%file)
{
   %fo = new FileObject();
   %fo.openForWrite(%file);
   %fo.writeLine("<?xml version=\"1.0\"?>");
   %this.dumpXMLNode(%this.DOM,%fo);
   %fo.close();
   %fo.delete();
}

//- XMLParser::dumpXMLNode (Recursive tree-traversal dump procedure)
function XMLParser::dumpXMLNode(%this,%node,%file)
{
   for(%i=0;%i<%node.children;%i++)
   {
      %child = %node.child[%i];
      %tab = "";
      for(%k=0;%k<%child.depth;%k++)
      {
         %tab = %tab@"\t";
      }
      for(%j=0;%j<%child.attributes;%j++)
      {
         %attrib = %child.attribute[%j];
         %value = %child.attrib[%attrib];
         %attributeString = %attributeString@" "@%child.attribute[%j]@"=\""@%value@"\"";
      }
      if(%child.children >= 1)
      {
         %file.writeLine(%tab@"<"@%child.tag@%attributeString@">");
         %this.dumpXMLNode(%child,%file);
         %file.writeLine(%tab@"</"@%child.tag@">");
      }
      else
      {
         if(%child.cData !$= "")
            %file.writeLine(%tab@"<"@%child.tag@%attributeString@">"@%child.cData@"</"@%child.tag@">");
         else
            %file.writeLine(%tab@"<"@%child.tag@%attributeString@"/>");
      }
   }
}

//*********************************************************
//* XML Parser DOM Management
//*********************************************************
//- XMLParser::createDOM (spawns a new DOM for the parser)
function XMLParser::createDOM(%this)
{
   %this.freeDOM();
   
   %this.DOM = new ScriptGroup()
   {
      class = "XMLObjectModel";
      parser = %this;
   };
   %this.add(%this.DOM);
}

//*********************************************************
//* DOM Methods
//*********************************************************
//- XMLObjectModel::onAdd (add callback to set default values)
function XMLObjectModel::onAdd(%this)
{
   %this.stanzaData = "";
   %this.children = 0;
   %this.depth = 0;
}

//- XMLObjectModel::toString (converts contents of DOM to string)
function XMLObjectModel::toString(%this,%free)
{
   return XMLObjectModelNode::toString(%this,%free);
}

//- XMLObjectModelNode::onAdd (add callback to set default values)
function XMLObjectModelNode::onAdd(%this)
{
   %this.attributes = 0;
   %this.children = 0;
}

//- XMLObjectModelNode::getAttribute (gets a node attribute)
function XMLObjectModelNode::getAttribute(%this,%attrib)
{
   return %this.attrib[%attrib];
}

//- XMLObjectModelNode::setsAttribute (sets a node attribute)
function XMLObjectModelNode::setAttribute(%this,%attrib,%value)
{
   %this.attribute[%this.attributes] = %attrib;
   %this.attributes++;
   
   %this.attrib[%attrib] = xmlEncode(%value);
   return %this;
}

//- XMLObjectModelNode::setsAttributes (sets a bunch of node attributes)
function XMLObjectModelNode::setAttributes(%this,%attrib,%value)
{
   %this.attrib[%attrib] = xmlEncode(%value);
   return %this;
}

//- XMLObjectModelNode::getTop (gets to the top of an xml tree)
function XMLObjectModelNode::getTop(%this)
{
   %parent = %this;
   while(isObject(%parent.getGroup()) && %parent.getGroup().class $= "XMLObjectModelNode")
   {
      %parent = %parent.getGroup();
   }
   return %parent;
}

//*********************************************************
//* DOM Traversal
//*********************************************************
//- XMLObjectModelNode::find (linear search/traversal of xml sub-tree)
function XMLObjectModelNode::find(%this,%path)
{
   %path = strReplace(%path,"/","\t");
   %newPath = strReplace(getFields(%path,1,getFieldCount(%path)),"\t","/");
   
   if(getField(%path,0) $= "" && getField(%path,1) !$= "")
   {
      %this.find(%newPath);
      return;
   }
      
   for(%i=0;%i<%this.children;%i++)
   {
      if(%this.child[%i].tag $= getField(%path,0))
      {
         if(%newPath !$= "")
            %found = %this.child[%i].find(%newPath);
         else
            %found = %this.child[%i];
      }
   }

   if(%found $= "" && %this.parent)
   {
      %parent = %this.parent;
      for(%i=0;%i<%parent.children;%i++)
      {
         if(%parent.child[%i].cData $= getField(%path,0))
         {
            %found = %parent.child[%i];
         }
      }
   }
   
   if(%found $= "")
      %found = 0;
      
   return %found;
}

//*********************************************************
//* XML Construction
//*********************************************************
//- XMLObjectModelNode::newElement (chainable tree depth incremental element creation)
function XMLObjectModelNode::newElement(%this,%element,%value,%append)
{
   %node = new ScriptGroup()
   {
      class = "XMLObjectModelNode";
      
      parent = %this;
      tag = %element;
   };
   %this.add(%node);
   
   %this.child[%this.children] = %node;
   %this.children++;
   
   if(%value !$= "")
      %node.cData = xmlEncode(%value);
   
   if(%append)
      return %this;
   else
      return %node;
}

//- XMLObjectModelNode::merge (merges another node into this node)
function XMLObjectModelNode::merge(%this,%node)
{
   if(%node.class !$= %this.class)
      return %this;
      
   %this.add(%node);
   %this.child[%this.children] = %node;
   %this.children++;
   
   return %this;
}

//- XMLObjectModelNode::toString (returns string version of xml tree)
function XMLObjectModelNode::toString(%this)
{
   %output = %output@"<"@%this.tag;
   for(%i=0;%i<%this.attributes;%i++)
   {
      %attrib = %this.attribute[%i];
      %value = %this.attrib[%attrib];
      
      %output = %output@" "@%attrib@"=\""@%value@"\"";
   }
   
   if(%this.children > 0)
   {
      %output = %output@">";
      
      for(%i=0;%i<%this.children;%i++)
      {
         %output = %output@%this.child[%i].toString();
      }
      %output = %output@"</"@%this.tag@">";
   }
   else
   {
      if(%this.cData !$= "")
         %output = %output@">"@%this.cData@"</"@%this.tag@">";
      else if(%this.attributes > 0)
         %output = %output@" />";
      else
         %output = %output@"/>";
   }
   return %output;
}

//*********************************************************
//* Support Functions
//*********************************************************
//- hasStringAttrib (string manipulation, checks for attribute-looking things)
function hasStringAttrib(%string,%field)
{
   %search = %field@"=\"";
   if(strPos(%string,%search) >= 0)
   {
      return 1;
   }
   else
      return 0;
}

//- getStringAttrib (string manipulation, gets attribute from string)
function getStringAttrib(%string,%field)
{
   %string = strReplace(%string,"\\\"","&quot;");
   
   %search = %field@"=\"";
   %search2 = %field@"='";
   if(strPos(%string,%search) >= 0)
   {
      %data = getSubStr(%string,(strPos(%string,%search)+strLen(%search)),strLen(%string));
      %data = getSubStr(%data,0,strPos(%data,"\""));
      return strReplace(%data,"&quot;","\\\"");
   }
   else if(strPos(%string,%search2) >= 0)
   {
      %data = getSubStr(%string,(strPos(%string,%search2)+strLen(%search2)),strLen(%string));
      %data = getSubStr(%data,0,strPos(%data,"'"));
      return strReplace(%data,"&quot;","\\\"");
   }
   else
      return 0;
}

//- xmlEncode (encodes certain characters to be xml-safe)
function xmlEncode(%string)
{
   %string = strReplace(%string,"&","&amp;");
   %string = strReplace(%string,"'","&apos;");
   %string = strReplace(%string,"<","&lt;");
   %string = strReplace(%string,">","&gt;");
   %string = strReplace(%string,"\"","&quot;");
   
   return %string;
}

//- xmlDecode (decodes certain xml-safe characters)
function xmlDecode(%string)
{
   %string = strReplace(%string,"&apos;","'");
   %string = strReplace(%string,"&lt;","<");
   %string = strReplace(%string,"&gt;",">");
   %string = strReplace(%string,"&quot;","\"");
   %string = strReplace(%string,"&amp;","&");
   
   return %string;
}