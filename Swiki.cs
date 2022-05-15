'From Squeak6.0alpha of 6 May 2022 [latest update: #21736] on 15 May 2022 at 5:53:22 pm'!
Object subclass: #AniAccess
	instanceVariableNames: 'allLevel usersLevel groupToLevel'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #AniGroup
	instanceVariableNames: 'module id name beSignedIn password ipColl'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #AniGroupsModule
	instanceVariableNames: 'dir idToGroup sema'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
StringHolder subclass: #ComSwikiLauncher
	instanceVariableNames: 'package port ports isShutdown startStopButton portButton module'
	classVariableNames: 'AutoCorrectMissingPages ValidPorts'
	poolDictionaries: ''
	category: 'Swiki-Comanche'!

!ComSwikiLauncher commentStamp: '<historical>' prior: 0!
ComSwikiLauncher

This class provides a morphic interface to launch Swiki on Comanche.
In Morphic, doIt: (ComSwikiLauncher openAsMorph)
In MVC, doIt: (ComSwikiLauncher openMVCView)

BUTTON EXPLANATION
start/stop server button
	press on this button to start or stop the Swiki server on the given port.
save & exit button
	once everything is set up, this button will save and quit and turn
	the swiki on at the next reboot. This is not to be confused with 'save
	and quit' which does not restart the server.
port button
	press on this when the server is inactive to change the port number.
	Note: 80 is the default port for a web server, but many systems will
		not allow a user to use it (Windows NT, Unix)

TO EDIT SWIKI
start the server
bring up ComSwiki Launcher's menu
	press on the button next to X
chose 'open swiki browser...'
!

Object subclass: #IdFormatter
	instanceVariableNames: 'idBlock startBlock transitionBlock endBlock formatter settings'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Formatting'!

!IdFormatter commentStamp: '<historical>' prior: 0!
IdFormatter

This formatter is used by LineFormatter to format text.

SPECIFIC INSTANCES:
anchor: places an anchor for lines beginning with '@'
append: adds an append area for lines beginning with '+'
appendRender: removes an append area for render
break: adds '<hr>' for lines beginning with '_'
heading: makes headings out of lines beginning with '!!'
leaveAlone: leaves the text as it is
list: makes lists out of lines beginning with '-' or '#'
preformatted: makes text beginning with '=' into equal length font
saveAppend: adds a specific text to a line beginning with '+'
table: makes a table out of lines beginning with '|'
text: (default) adds '<br>' to the end of the line!

Object subclass: #LineFormatter
	instanceVariableNames: 'exceptions formatters storeID convertToCrlf'
	classVariableNames: 'CR LF'
	poolDictionaries: ''
	category: 'Swiki-Formatting'!

!LineFormatter commentStamp: '<historical>' prior: 0!
LineFormatter

This formatter is used to format text. Exceptions are processed using their own formatters. They are later placed in their former positions. Formatters are assigned based on the value that follows cr. There is also a default formatter.

SPECIFIC INSTANCES:
appendFormatter: used to add append text to the swiki text
renderFormatter: used to convert the raw text to the rendered HTML text
showFormatter: used to convert the raw text to the view HTML text!

Object subclass: #RSSDocument
	instanceVariableNames: 'title link description items creationTime'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #SwikiBookContext
	instanceVariableNames: 'request response shelf book'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Comanche'!
StringHolder subclass: #SwikiBrowser
	instanceVariableNames: 'shelf bookList bookListIndex functionList functionListIndex categoryList categoryListIndex elementList elementListIndex booksAsHierarchy'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Comanche'!

!SwikiBrowser commentStamp: '<historical>' prior: 0!
SwikiBrowser

this is a browser to edit the swikis.

To open, use the ComSwikiLauncher:
1. Start the server.
2. Chose "open swiki browser..." from the window menu (next to the X)!

Object subclass: #SwikiColorScheme
	instanceVariableNames: 'directory fileServer templates altTags buttonEnding activeButton emoteEnding mimeEnding'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiColorScheme commentStamp: '<historical>' prior: 0!
SwikiColorScheme

are used by Swikis to reference buttons and graphics.

INSTANCE VARIABLES:
directory = the corresponding SwikiDirectory
fileServer = the corresponding SwikiFileServer
templates = a dictionary mapping names of templates to the templates (such as beforeButtons)
altTags = a dictionary mapping image names to their ALTernate tag (from tags.xml)
buttonEnding = the suffix of button files (such as .gif)
activeButton = a boolean that is true if the button should have a rollover
emoteEnding = the suffix of emote (happy, sad, etc.) files (such as .gif)
mimeEnding = the suffix of mime types (image, video, audio, etc.)!

Object subclass: #SwikiEntry
	instanceVariableNames: 'name modificationTime creationTime'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiEntry commentStamp: '<historical>' prior: 0!
SwikiEntry

is similar to FileEntry, but more lightweight. This contains the information that is associated with a specific file or directory. This is an abstract class; it holds the joint features of SwikiFile and SwikiDirectory.

INSTANCE VARIABLES:
name = name of the file (a String)
modificationTime = when the file was last modified (a number)
creationTime = when the file was created (a number)!

SwikiEntry subclass: #SwikiDirectory
	instanceVariableNames: 'dir dirServeCache dirRefsCache fileServeCache fileRefsCache'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiDirectory commentStamp: '<historical>' prior: 0!
SwikiDirectory

is a cacheing file directory that allows you to reference and serve files in it.

INSTANCE VARIABLES:
dir = the corresponding FileDirectory
dirServeCache = a dictionary mapping relative HTTP paths to the corresponding subdirectories
dirRefsCache = a dictionary mapping directory names to the corresponding directories
fileServeCache = a dictionary mapping relative HTTP paths to the corresponding files
fileRefsCache = a dictionary mapping file names to the corresponding SwikiFileVersions!

SwikiEntry subclass: #SwikiFile
	instanceVariableNames: 'fileSize versions'
	classVariableNames: 'MimeToClass'
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiFile commentStamp: '<historical>' prior: 0!
SwikiFile

contains the information that is associated with a specific file. During instance creation, the correct subclass of SwikiFile is chosen according to MIME type.

INSTANCE VARIABLES:
fileSize = size of the file in bytes
versions = the SwikiFileVersions that this file belongs to

CLASS VARIABLES:
MimeToClass = a dictionary of MIMETypes to the subclasses of SwikiFile that handle them!

Object subclass: #SwikiFileServer
	instanceVariableNames: 'refFileDict serveFileDict refFileBlock refDirectoryBlock refMissingFileBlock serveFileBlock serveDirectoryBlock serveMissingFileBlock'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiFileServer commentStamp: '<historical>' prior: 0!
SwikiFileServer

is a pluggable functionality module. It is used by the Swiki to reference or serve files and directories in different ways.

INSTANCE VARIABLES:
refFileDict = a Dictionary of classes to the block used to reference them
serveFileDict = a Dictionary of classes to the block used to serve them
refFileBlock = a block that determines how to reference a SwikiFile
refDirectoryBlock = a block that determines how to reference a SwikiDirectory
refMissingFileBlock = a block that determines how to reference a missing file
serveFileBlock = a block that determines how to serve a SwikiFile or SwikiImage
serveDirectoryBlock = a block that determines how to serve a SwikiDirectory
serveMissingFileBlock = a block that determines how to serve a missing file!

StandardFileStream subclass: #SwikiFileStream
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Storage'!
OrderedCollection subclass: #SwikiFileVersions
	instanceVariableNames: 'name mimeType'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiFileVersions commentStamp: '<historical>' prior: 0!
SwikiFileVersions

is a subclass of OrderedCollection that holds all versions of a Swiki file.

INSTANCE VARIABLES:
name = the full name of the file (this may be an alias for the actual file name)
mimeType = the mimeType for the files!

SwikiFile subclass: #SwikiImage
	instanceVariableNames: 'width height'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiImage commentStamp: '<historical>' prior: 0!
SwikiImage

is a file entry for an image (usually, a file that ends with gif, jpeg, jpg, or png). It includes width and height as further instance variables.

INSTANCE VARIABLES:
width = the width of the image (as a number)
height = the height of the image (as a number)!

Object subclass: #SwikiModule
	instanceVariableNames: 'shelf'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Comanche'!

!SwikiModule commentStamp: 'Je77 12/2/2005 09:09' prior: 0!
SwikiModule

This class gets Comanche to talk to swiki.

In the folder for the swiki, several things are of significants:

	settings.xml		The XML file which contains the settings
	security.xml		The XML file which contains the security
	setup.xml		The XML file which contains the setup
	schemes.xml		The XML file which contains the schemes and forms
	log.txt			The log file if 'logging' is set to 'local' in the setup file
	browser.log		The log file of the SwikiBrowser
	addresses		This directory contains the valid addresses
	templates		This directory contains the valid templates
	actions			This directory contains the valid actions
	pages			This directory contains the swiki pages
	uploads			This directory contains the uploads
	rendered		This directory will contain the rendered swiki if the swiki is rendered
	surveys			This directory contains the surveys from different votes.
	groups			This directory contains the access control groups for AniAniWeb
!

Object subclass: #SwikiPageContext
	instanceVariableNames: 'request response shelf book page'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Comanche'!
Object subclass: #SwikiRSSModule
	instanceVariableNames: 'urlToRss sema'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #SwikiRequest
	instanceVariableNames: 'book page address security settings'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Structure'!

!SwikiRequest commentStamp: '<historical>' prior: 0!
SwikiRequest

This is an abstract class that is sent into a SwikiShelf to be processed to create a response.

INSTANCE VARIABLES:
book = the name of the book it might belong to
page = the index of the page it might belong to
address = the possible addressing for the element
security = a SwikiSecurityMember
settings = a dictionary for the process to put things so that others along the process path can use them.!

SwikiRequest subclass: #HttpSwikiRequest
	instanceVariableNames: 'raw'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Comanche'!

!HttpSwikiRequest commentStamp: '<historical>' prior: 0!
HttpSwikiRequest

This subclass of SwikiRequest is sent by the SwikiModule to the SwikiShelf for processing. The HttpSwikiRequest is created from the HTTPRequest, which becomes the raw instance variable.

book, page, and address are determined like this:
	The url is tokenized by /.
	The first element is the book.
	If the second element is a number, then it is the page.
	The next element is the address.
!

Object subclass: #SwikiSchemeReadWriter
	instanceVariableNames: ''
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #SwikiSecurityMember
	instanceVariableNames: 'settings privileges'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!

!SwikiSecurityMember commentStamp: '<historical>' prior: 0!
SwikiSecurityMember

This class provides the members that will belong to the SwikiSecurityModule. These are passed along with the request for identification and security reasons.

INSTANCE VARIABLES:
settings = a Dictionary (user, password, and ip are the settings that are used by the security module)
privileges = a SwikiSecurityPrivileges (this determines what capabilities this user has)
!

Object subclass: #SwikiSecurityModule
	instanceVariableNames: 'aclDict ipColl default'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!

!SwikiSecurityModule commentStamp: '<historical>' prior: 0!
SwikiSecurityModule

This is what a 'security.xml' file is supposed to look like:

**********************************************************
<?xml version="1.0"?>
<security>
<default priv="defaultPrivilege" />
<group priv="groupPrivilege">
<member>
<m type="user">userName</m>
<m type="password">passWord</m>
<m type="ip">IPNumber</m>
...
</member>
...
</group>
...
</security>
**********************************************************

'...'						means that there can be several of the type proceeding it.
defaultPrivilege			the privilege of the default group (for example: 'Read Only')
groupPrivilege			the privilege of the specific group (for example: 'Write')
userName				the user name that the user must enter
passWord				the password the user must enter
IPNumber				the IPNumber of the user
!

Object subclass: #SwikiSecurityPrivileges
	instanceVariableNames: 'name default pageAddresses bookAddresses shelfAddresses other'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!

!SwikiSecurityPrivileges commentStamp: '<historical>' prior: 0!
SwikiSecurityPrivileges

This class provides privileges for the various servers and modules to inspect. Try the category testing to figure out which one is right for the purpose.

If a privilege of the type does exist, the instance returns (default not). If the privilege of the type does not exist, the instance returns (default).

INSTANCE VARIABLES:
name = the name of the privilege. This identifies the privilege.
default = the default value as to whether something is allowed
pageAddresses = the list of exceptions to the default value having to do with page addresses
bookAddresses = the list of exceptions to the default value having to do with book addresses
other = the list of exceptions to the default value not having to do with addresses !

Object subclass: #SwikiShelfContext
	instanceVariableNames: 'request response shelf'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Comanche'!
Object subclass: #SwikiStorage
	instanceVariableNames: 'dir dict'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Storage'!

!SwikiStorage commentStamp: '<historical>' prior: 0!
SwikiStorage

Subclass this to determine the storage mechanisms for a Swiki.
By default, these rules apply:
	addresses are Smalltalk blocks that get compiled at run time
	templates are text files indicating actions with <? and ?>
	actions are Smalltalk blocks that get compiled at run time!

Object subclass: #SwikiStructure
	instanceVariableNames: 'name storage settings modules sema'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Structure'!

!SwikiStructure commentStamp: '<historical>' prior: 0!
SwikiStructure

This is a basis class that shares the common functionalities for NuSwikiPage, SwikiBook, SwikiShelf, and SwikiSubBook

INSTANCE VARIABLES:
name = the name of the object
storage = a type of SwikiStorage that is used to initialize and store new values
settings = a dictionary of save values
modules = a dictionary of run-time values that will not be saved
sema = a Semaphore used for saving!

SwikiStructure subclass: #NuSwikiPage
	instanceVariableNames: 'id versionId date time user text'
	classVariableNames: 'BadCharTable'
	poolDictionaries: ''
	category: 'Swiki-Structure'!

!NuSwikiPage commentStamp: '<historical>' prior: 0!
NuSwikiPage

This is a class for swiki pages that are part of a SwikiBook.

INSTANCE VARIABLES:
id = numerical ID of the page
versionId = the version of the page. 1 indicates the first version. 0 indicates the current version.
date = the last date the page was edited
time = the last time the page was edited
user = the last user to edit the page
text = an object that contains information on how to get the text for the page!

SwikiStructure subclass: #SwikiBook
	instanceVariableNames: 'setup children pages nameToPage pageAddresses bookAddresses privAddresses pageTemplates bookTemplates pageActions bookActions'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Structure'!

!SwikiBook commentStamp: '<historical>' prior: 0!
SwikiBook

A Swiki is a container for pages and a way to access those pages. 'process: request response: response shelf: shelf' processes the request to fill in the necessary parts of the response.

INSTANCE VARIABLES:
setup = a place to keep all the start-up information for the book.
pages = The SwikiPages of this book
children = the SwikiBooks that inherit from this book
pageAddresses = The ways a page can be addressed (dictionary of strings to blocks)
bookAddresses = The ways the book can be addressed (dictionary of strings to blocks)
privAddresses = These are private addresses that are not determined by the URL
	there are several normal usages:
	create = for creating new swikis
	filter = for security filtering
	initialize = for initializing the swiki
	log = for logging
	search = for searching the pages
	security = returns the security possibilities
	settings = return the settings possibilities
pageActions = The actions that can be used for a page (dictionary of strings to blocks)
bookActions = The actions that can be used for the book (dictionary of strings to blocks)
pageTemplates = The templates that are specific to the page; they can call either page or book actions (dictionary of strings to strings)
bookTemplates = The templates that are specific to the book; they can call book actions (dictionary of strings to strings)!

SwikiStructure subclass: #SwikiShelf
	instanceVariableNames: 'nameToBook privAddresses shelfAddresses bookTemplates shelfTemplates bookActions shelfActions'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Structure'!

!SwikiShelf commentStamp: '<historical>' prior: 0!
SwikiShelf

This is how a swiki is accessed. Processing the request and the return together. The shelf directs the process to the correct book.

INSTANCE VARIABLES:
books = the SwikiBooks of this shelf
shelfAddresses = The ways the shelf can be addressed (dictionary of strings to blocks)
privAddresses = These are private addresses that are not determined by the URL
bookTemplates = The templates that are specific to a book (dictionary of strings to strings)
shelfTemplates = The templates that are specific to the shelf (dictionary of strings to strings)
bookActions = The actions that can be used for a book (dictionary of strings to blocks)
shelfActions = The actions that can be used for the shelf (dictionary of strings to blocks)
!

SwikiBook subclass: #SwikiSubBook
	instanceVariableNames: 'parent'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Structure'!

!SwikiSubBook commentStamp: '<historical>' prior: 0!
SwikiSubBook

this is a SwikiBook that inherits its properties from another SwikiBook.

INSTANCE VARIABLES:
parent = the SwikiBook that the swiki inherits from!

SwikiDirectory subclass: #SwikiSubDirectory
	instanceVariableNames: 'containingDirectory'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-FileServer'!

!SwikiSubDirectory commentStamp: '<historical>' prior: 0!
SwikiSubDirectory

is a sub-directory. Thus, it has all the features of a SwikiDirectory, but it also has a containingDirectory.

INSTANCE VARIABLES:
containingDirectory = the SwikiDirectory which contains this instance (may be nil)!

Object subclass: #SwikiSurveyEntry
	instanceVariableNames: 'id module keyToVotes name from to'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #SwikiSurveyModule
	instanceVariableNames: 'nameToSurvey dir sema'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #SwikiUser
	instanceVariableNames: 'module id settings name'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #SwikiUsersModule
	instanceVariableNames: 'dir idToUser nameToUser sema'
	classVariableNames: ''
	poolDictionaries: ''
	category: 'Swiki-Modules'!
Object subclass: #TextFormatter
	instanceVariableNames: 'match formattingArray'
	classVariableNames: 'CrToCrlf CrlfToCr DecodeFromXmlCr DecodeFromXmlCrlf EncodeToStrictXmlCr EncodeToStrictXmlCrlf EncodeToXmlCr EncodeToXmlCrlf'
	poolDictionaries: ''
	category: 'Swiki-Formatting'!

!TextFormatter commentStamp: '<historical>' prior: 0!
TextFormatter

This is a general text formatter. You create an instance which is a text formatter. Then, using 'format:' you format a text to get a formatted stream back.

There are two type of formatting that can be added: mapping and action. A mapping is when an original in the text gets replaced with the replacement in the formatted stream. An action is when the text between the two elements is send into the code block and the result is sent to the formatted stream. In case of conflict, the longer match wins; for instance, in a SwikiFormatter, '----' might match to '<HR>', while '-' might match to '<LI>'.!

TextFormatter subclass: #BookTemplateFormatter
	instanceVariableNames: ''
	classVariableNames: 'SwikiFormatter'
	poolDictionaries: ''
	category: 'Swiki-Formatting'!

!BookTemplateFormatter commentStamp: '<historical>' prior: 0!
BookTemplateFormatter

This specialty TextFormatter is created for a SwikiBook to use in processing templates. It takes elements between '<?' and '?>' and executes the actions associated with the text inbetween.!

TextFormatter subclass: #PageFormatter
	instanceVariableNames: 'storeID'
	classVariableNames: 'ToSafeAlias ToSafeLocation ToStrictSafeAlias'
	poolDictionaries: ''
	category: 'Swiki-Formatting'!

!PageFormatter commentStamp: '<historical>' prior: 0!
PageFormatter

This formatter is used to format the page text at various points in the swiki architecture.

SPECIFIC INSTANCES:
editFormatter: used to convert the raw page text to the edit text
saveFormatter: used to convert the edit text from the user to the raw text for the file
updateFormatter: used to update pages after a new page was created

CLASS VARIABLES:
ToSafeUrl: converts normal text into something that can be put into a url without messing up the url
FromSafeUrl: does the opposite of ToSageUrl
RemoveLf: removes all instances of Lf
RemoveCrLf: removes all instances of Cr, Lf or CrLf
ToSafeAlias: converts a swiki url text and converts the special symbols (<>@*&)!

TextFormatter subclass: #ShelfTemplateFormatter
	instanceVariableNames: ''
	classVariableNames: 'SwikiFormatter'
	poolDictionaries: ''
	category: 'Swiki-Formatting'!

!ShelfTemplateFormatter commentStamp: '<historical>' prior: 0!
ShelfTemplateFormatter

This specialty TextFormatter is created for a SwikiShelf to use in processing templates. It takes elements between '<?' and '?>' and executes the actions associated with the text inbetween.!

SwikiStorage subclass: #XmlSwikiStorage
	instanceVariableNames: ''
	classVariableNames: 'AssocDict TextCacheLimit TypesDict'
	poolDictionaries: ''
	category: 'Swiki-Storage'!

!XmlSwikiStorage commentStamp: '<historical>' prior: 0!
XmlSwikiStorage
Use streams for versions (to conserve memory) and strings for current version (for speed).

This is the first implementation of storage for Swiki. It primarily uses XML. Here are the rules as they apply.

PAGES
The current version is placed in the #.xml file. The previous versions are stored in the #.old file. This is the general pattern for these files:
	<?xml version="1.0"?>
	<page>
	<version date="..." time="..." user="..." />
	<settings>
	<s name="..." type="...">...</s>
	...
	</settings>
	<name>...</name>
	<text>...</text>
	</page>

SETTINGS
The settings are placed in the settings.xml file. This is the general pattern for these files:
	<?xml version="1.0"?>
	<settings>
	<s name="..." type="...">...</s>
	...
	</settings>
The setting types are boolean (true or false), number (a number), text (a String), coll (a collection of numbers), and code (Squeak code).!


!AniAccess methodsFor: 'initializing'!
initializeFromPage: page
	| groupIdAndLevel |	
	allLevel _ page settingsAt: 'acAll' ifAbsent: [2].
	usersLevel _ page settingsAt: 'acUsers' ifAbsent: [4].
	groupToLevel _ Dictionary new.
	((page settingsAt: 'acGroups' ifAbsent: ['']) findTokens: ' 	') do: [:token |
		groupIdAndLevel _ token findTokens: '->'.
		(groupIdAndLevel size = 2) ifTrue: [groupToLevel
			at: ((groupIdAndLevel at: 1) asNumber)
			put: ((groupIdAndLevel at: 2) asNumber)]]! !

!AniAccess methodsFor: 'testing'!
hasPasswordRequest: aSwikiRequest
	"TODO"
	^false! !

!AniAccess methodsFor: 'testing'!
hiddenToAll
	usersLevel > 1 ifTrue: [^false].
	groupToLevel keysAndValuesDo: [:group :level | level > 1 ifTrue: [^false]].
	^true! !

!AniAccess methodsFor: 'testing'!
showPageButtonsToRequest: request book: book
	"show the buttons if the request could potentially edit with password"
	| module |
	((self accessLevelForRequest: request) > 2) ifTrue: [^true].
	"Try to see if they can join with password"
	module _ book modulesAt: 'groups'.
	groupToLevel keysAndValuesDo: [:groupId :level |
		(level > 2) ifTrue: [
			(module groupAtId: groupId) canJoinWithPassword
				ifTrue: [^true]]].
	^false! !

!AniAccess methodsFor: 'testing'!
showUploadLockButtonToRequest: request book: book
	"show the buttons if the request could potentially upload with password"
	| module |
	((self accessLevelForRequest: request) > 3) ifTrue: [^true].
	"Try to see if they can join with password"
	module _ book modulesAt: 'groups'.
	groupToLevel keysAndValuesDo: [:groupId :level |
		(level > 3) ifTrue: [
			(module groupAtId: groupId) canJoinWithPassword
				ifTrue: [^true]]].
	^false! !

!AniAccess methodsFor: 'testing'!
unaccessableToAll
	allLevel > 0 ifTrue: [^false].
	usersLevel > 0 ifTrue: [^false].
	groupToLevel keysAndValuesDo: [:group :level | level > 0 ifTrue: [^false]].
	^true! !

!AniAccess methodsFor: 'testing'!
uneditableToAll
	allLevel > 2 ifTrue: [^false].
	usersLevel > 2 ifTrue: [^false].
	groupToLevel keysAndValuesDo: [:group :level | level > 2 ifTrue: [^false]].
	^true! !

!AniAccess methodsFor: 'testing'!
unuploadableToAll
	allLevel > 3 ifTrue: [^false].
	usersLevel > 3 ifTrue: [^false].
	groupToLevel keysAndValuesDo: [:group :level | level > 3 ifTrue: [^false]].
	^true! !

!AniAccess methodsFor: 'accessing'!
accessLevelForRequest: request
	| level test |
	request isOwner ifTrue: [^5].
	level _ request security ifNil: [allLevel] ifNotNil: [self usersLevel].
	request groupIds do: [:groupId |
		test _ groupToLevel at: groupId ifAbsent: [0].
		(test > level) ifTrue: [level _ test]].
	^level! !

!AniAccess methodsFor: 'accessing'!
allLevel
	^allLevel! !

!AniAccess methodsFor: 'accessing'!
levelForGroup: group
	^groupToLevel at: (group id) ifAbsent: [0]! !

!AniAccess methodsFor: 'accessing'!
usersLevel
	^usersLevel = 0
		ifTrue: [allLevel]
		ifFalse: [usersLevel]! !

!AniAccess methodsFor: 'utility'!
printALChoicesForAllOn: stream
	stream
		nextPutAll: '<tr><td valign=top>all visitors&nbsp;</td><td valign=top><select name="acAll" onChange="acAllChange()"><option'.
	(allLevel = 0) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>0: none';
		nextPutAll: String crlf;
		nextPutAll: '<option'.
	(allLevel = 1) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>1: hidden';
		nextPutAll: String crlf;
		nextPutAll: '<option'.
	(allLevel = 2) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>2: view';
		nextPutAll: String crlf;
		nextPutAll: '<option'.
	(allLevel = 3) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>3: edit';
		nextPutAll: String crlf;
		nextPutAll: '<option'.
	(allLevel = 4) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>4: upload';
		nextPutAll: String crlf;
		nextPutAll: '</select></td></tr>';
		nextPutAll: String crlf.! !

!AniAccess methodsFor: 'utility'!
printALChoicesForGroup: group on: stream
	| level startLevel |
	level _ groupToLevel at: (group id) ifAbsent: [0].
	startLevel _ group beSignedIn
		ifTrue: [usersLevel]
		ifFalse: [allLevel].
	stream
		nextPutAll: '<tr><td valign=top>::&nbsp;';
		nextPutAll: group showName;
		nextPutAll: '&nbsp;</td><td valign=top><select name="ac';
		nextPutAll: group showId;
		nextPutAll: '"><option'.
	(level = 0) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>------';
		nextPutAll: String crlf.
	(startLevel < 1) ifTrue: [
		stream
			nextPutAll: '<option'.
		(level = 1) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>1: hidden';
			nextPutAll: String crlf].
	(startLevel < 2) ifTrue: [
		stream
			nextPutAll: '<option'.
		(level = 2) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>2: view';
			nextPutAll: String crlf].
	(startLevel < 3) ifTrue: [
		stream
			nextPutAll: '<option'.
		(level = 3) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>3: edit';
			nextPutAll: String crlf].
	(startLevel < 4) ifTrue: [
		stream
			nextPutAll: '<option'.
		(level = 4) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>4: upload';
			nextPutAll: String crlf].
	stream
		nextPutAll: '</select></td></tr>';
		nextPutAll: String crlf! !

!AniAccess methodsFor: 'utility'!
printALChoicesForUsersOn: stream
	stream
		nextPutAll: '<tr><td valign=top>signed-in users&nbsp;</td><td valign=top><select name="acUsers" onChange="acUsersChange()"><option'.
	(usersLevel = 0) ifTrue: [stream
		nextPutAll: ' selected'].
	stream
		nextPutAll: '>------';
		nextPutAll: String crlf.
	(allLevel < 1) ifTrue: [
		stream
			nextPutAll: '<option'.
		(usersLevel = 1) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>1: hidden';
			nextPutAll: String crlf].
	(allLevel < 2) ifTrue: [
		stream
			nextPutAll: '<option'.
		(usersLevel = 2) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>2: view';
			nextPutAll: String crlf].
	(allLevel < 3) ifTrue: [
		stream
			nextPutAll: '<option'.
		(usersLevel = 3) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>3: edit';
			nextPutAll: String crlf].
	(allLevel < 4) ifTrue: [
		stream
			nextPutAll: '<option'.
		(usersLevel = 4) ifTrue: [stream
			nextPutAll: ' selected'].
		stream
			nextPutAll: '>4: upload';
			nextPutAll: String crlf].
	stream
		nextPutAll: '</select></td></tr>';
		nextPutAll: String crlf! !


!AniAccess class methodsFor: 'utility'!
levelForDescription: aString
	^aString caseOf: {
		['1: hidden']->[1].
		['2: view']->[2].
		['3: edit']->[3].
		['4: upload']->[4]}
		otherwise: [0]! !

!AniAccess class methodsFor: 'instance creation'!
newFromPage: aSwikiPage
	^self new
		initializeFromPage: aSwikiPage;
		yourself! !


!AniGroup methodsFor: 'accessing'!
password
	^password! !

!AniGroup methodsFor: 'storage'!
asXml
	| document entry group ipsXml |
	group _ XMLElement named: 'group' attributes: (Dictionary new).
	group
		attributeAt: #name put: self name;
		attributeAt: #beSignedIn put: beSignedIn asString.
	password ifNotNil: [
		entry _ XMLElement named: 'password' attributes: Dictionary new.
		entry contents add: (XMLStringNode string: password).
		group addElement: entry].
	ipColl isEmpty ifFalse: [
		ipsXml _ XMLElement named: 'ips' attributes: (Dictionary new).
		ipColl do: [:ip |
			entry _ XMLElement named: 'ip' attributes: (Dictionary new).
			entry attributeAt: 'number' put: (SwikiSecurityModule toIpString: (ip at: 1)).
			entry attributeAt: 'mask' put: (SwikiSecurityModule toIpString: (ip at: 2)).
			ipsXml addElement: entry].
		group addElement: ipsXml].
	document _ XMLDocument new.
	document version: '1.0'.
	document addElement: group.
	^document! !

!AniGroup methodsFor: 'storage'!
delete
	"Delete file"
	| fileName |
	fileName _ id asString, '.xml'.
	module forbidWriting.
	(module dir fileExists: fileName) ifTrue: [
		module dir deleteFileNamed: fileName].
	module permitWriting.
	module removeGroupId: id! !

!AniGroup methodsFor: 'storage'!
save
	| text fileName |
	"Save as XML"
	text _ String streamContents: [:stream | self asXml printXMLOn: (XMLWriter on: stream)].
	"Save text onto file"
	fileName _ id asString, '.xml'.
	module forbidWriting.
	(module dir fileExists: fileName) ifTrue: [
		module dir deleteFileNamed: fileName].
	(module dir fileNamed: fileName)
		nextPutAll: text;
		close.
	module permitWriting! !

!AniGroup methodsFor: 'testing'!
canJoinWithPassword
	^self beSignedIn
		ifTrue: [false]
		ifFalse: [password notNil]! !

!AniGroup methodsFor: 'testing'!
isUserAMember: request response: response shelf: shelf book: book
	| check |
	check _ book name, '-', self showId.
	^request security settingsIncludes: check! !

!AniGroup methodsFor: 'testing'!
isVisitorAMember: request response: response shelf: shelf book: book
	| ipInt |
	"Check IPs"
	ipColl isEmpty ifFalse: [
		ipInt _ 0.
		request user do: [:i | ipInt _ (ipInt*256) + i].
		ipColl do: [:ipArr | ((ipInt bitAnd: (ipArr at: 2)) = (ipArr at: 1))
			ifTrue: [^true]]].
	"Check passwords"
	^(request settingsAt: 'passwords' ifAbsent: [OrderedCollection new]) includes: password! !

!AniGroup methodsFor: 'as yet unclassified'!
beSignedIn
	^beSignedIn! !

!AniGroup methodsFor: 'as yet unclassified'!
id
	^id! !

!AniGroup methodsFor: 'as yet unclassified'!
name
	^name! !

!AniGroup methodsFor: 'as yet unclassified'!
showIPs
	^String streamContents: [:stream |
		ipColl do: [:ip | stream
			nextPutAll: (SwikiSecurityModule toIpString: (ip at: 1));
			nextPut: $/;
			nextPutAll: (SwikiSecurityModule toIpString: (ip at: 2));
			nextPutAll: String crlf]]! !

!AniGroup methodsFor: 'as yet unclassified'!
showId
	^id asString! !

!AniGroup methodsFor: 'as yet unclassified'!
showName
	^TextFormatter encodeToXmlCrlf: name! !

!AniGroup methodsFor: 'as yet unclassified'!
showStrictName
	^TextFormatter encodeToStrictXmlCrlf: name! !

!AniGroup methodsFor: 'as yet unclassified'!
showStrictPassword
	^password
		ifNil: ['']
		ifNotNil: [TextFormatter encodeToStrictXmlCrlf: password]! !

!AniGroup methodsFor: 'initialization'!
id: anInteger
	id _ anInteger! !

!AniGroup methodsFor: 'initialization'!
initializeFromRequest: request
	| newIps first second |
	"Initialize group from a SwikiRequest"
	name _ request fieldsKey: 'name'.
	beSignedIn _ request fieldsAsBooleanKey: 'beSignedIn'.
	password _ request fieldsKey: 'password' ifAbsent: [''].
	password isEmpty ifTrue: [password _ nil].
	"update ipColl"
	newIps _ request fieldsKey: 'addresses' ifAbsent: [''].
	ipColl _ OrderedCollection new.
	(newIps findTokens: (' 	', String crlf)) do: [:line |
		first _ line copyUpTo: $/.
		second _ line copyAfterLast: $/.
		((SwikiSecurityModule isIpString: first) and:
			[SwikiSecurityModule isIpString: second]) ifTrue: [
				first _ SwikiSecurityModule toIpNumber: first.
				second _ SwikiSecurityModule toIpNumber: second.
				ipColl add: (Array
					with: (first bitAnd: second)
					with: second)]]! !

!AniGroup methodsFor: 'initialization'!
initializeFromXml: xml
	| document |
	document _ xml elements at: 1.
	name _ document attributeAt: 'name'.
	beSignedIn _ (document attributeAt: 'beSignedIn') = true.
	password _ nil.
	ipColl _ OrderedCollection new.
	document elements do: [:element | (element name) caseOf: {
		['password']->[
			password _ (element contents at: 1) string].
		['ips']->["initialize ipColl"
			element elements do: [:ipElement | ipColl add: (Array
				with: (SwikiSecurityModule toIpNumber: (ipElement attributeAt: 'number'))
				with: (SwikiSecurityModule toIpNumber: (ipElement attributeAt: 'mask')))]]}]! !

!AniGroup methodsFor: 'initialization'!
module: anAniGroupsModule
	module _ anAniGroupsModule! !

!AniGroup methodsFor: 'utility'!
updateFromRequest: request
	| idString newIps first second |
	"Update the group from a SwikiRequest"
	idString _ id asString.
	name _ request fieldsKey: ('name', idString).
	beSignedIn _ request fieldsAsBooleanKey: ('beSignedIn', idString).
	password _ request fieldsKey: ('password', idString) ifAbsent: [''].
	password isEmpty ifTrue: [password _ nil].
	"update ipColl"
	newIps _ request fieldsKey: ('addresses', idString) ifAbsent: [''].
	ipColl _ OrderedCollection new.
	(newIps findTokens: (' 	', String crlf)) do: [:line |
		first _ line copyUpTo: $/.
		second _ line copyAfterLast: $/.
		((SwikiSecurityModule isIpString: first) and:
			[SwikiSecurityModule isIpString: second]) ifTrue: [
				first _ SwikiSecurityModule toIpNumber: first.
				second _ SwikiSecurityModule toIpNumber: second.
				ipColl add: (Array
					with: (first bitAnd: second)
					with: second)]]! !


!AniGroup class methodsFor: 'as yet unclassified'!
newFromXml: xml
	^self new
		initializeFromXml: xml;
		yourself! !

!AniGroup class methodsFor: 'instance creation'!
newFromRequest: request
	^self new
		initializeFromRequest: request;
		yourself! !


!AniGroupsModule methodsFor: 'storage'!
forbidWriting
	sema wait! !

!AniGroupsModule methodsFor: 'storage'!
permitWriting
	sema signal! !

!AniGroupsModule methodsFor: 'accessing'!
dir
	^dir! !

!AniGroupsModule methodsFor: 'accessing'!
groupAtId: id
	^idToGroup at: id! !

!AniGroupsModule methodsFor: 'accessing'!
groups
	^idToGroup values! !

!AniGroupsModule methodsFor: 'accessing'!
groupsWithPassword: password
	^self groups select: [:group | group password = password]! !

!AniGroupsModule methodsFor: 'accessing'!
removeGroupId: id
	idToGroup removeKey: id! !

!AniGroupsModule methodsFor: 'utility'!
addNewGroup: group
	| id |
	id _ 1.
	[idToGroup includesKey: id] whileTrue: [id _ id + 1].
	group id: id.
	group module: self.
	idToGroup at: id put: group! !

!AniGroupsModule methodsFor: 'utility'!
newRequest: request response: response shelf: shelf book: book
	| members check users group |
	users _ (shelf modulesAt: 'users') users.

	"Create and save the new group"
	group _ AniGroup newFromRequest: request.
	self addNewGroup: group.
	group save.

	"update group membership"
	members _ request fieldsKey: 'members' ifAbsent: [''].
	members _ members findTokens: (' ,	', String crlf).
	members _ members collect: [:i | i asLowercase].
	members _ members asSet.
	check _ book name, '-', group showId.
	users do: [:user |
		(members includes: user address asLowercase) ifTrue: [user
			settingsAt: check put: true;
			save]]! !

!AniGroupsModule methodsFor: 'utility'!
updateRequest: request response: response shelf: shelf book: book
	| members check users |
	users _ (shelf modulesAt: 'users') users.
	self groups do: [:group |
		(request fieldsHasKey: ('name', group showId)) ifTrue: [
			(request fieldsAsBooleanKey: ('delete', group showId) ifAbsent: [false])
				ifTrue: [
					"delete this group"
					group delete.
					"update group membership"
					check _ book name, '-', group showId.
					users do: [:user | (user settingsIncludes: check)
						ifTrue: [user
							settingsRemove: check;
							save]]]
				ifFalse: [
					"update this group"			
					group updateFromRequest: request; save.
					"update group membership"
					members _ request fieldsKey: ('members', group showId) ifAbsent: [''].
					members _ members findTokens: (' ,	', String crlf).
					members _ members collect: [:i | i asLowercase].
					members _ members asSet.
					check _ book name, '-', group showId.
					users do: [:user | (user settingsIncludes: check)
						ifTrue: [(members includes: user address asLowercase) ifFalse: [user
							settingsRemove: check;
							save]]
						ifFalse: [(members includes: user address asLowercase) ifTrue: [user
							settingsAt: check put: true;
							save]]]
					]]]! !

!AniGroupsModule methodsFor: 'processing'!
process: request response: response shelf: shelf book: book
	| groups |
	groups _ OrderedCollection new.
	"Check each group for membership"
	request security
		ifNil: ["Check Visitor Status"
			request settingsAt: 'passwords' put: request cookiePasswords.
			idToGroup keysAndValuesDo: [:id :group |
				(group isVisitorAMember: request response: response shelf: shelf book: book)
					ifTrue: [groups add: id]]]
		ifNotNil: ["Check User Status"
			idToGroup keysAndValuesDo: [:id :group |
				(group isUserAMember: request response: response shelf: shelf book: book)
					ifTrue: [groups add: id]]].
	request settingsAt: 'groups' put: groups! !

!AniGroupsModule methodsFor: 'initialization'!
dir: aFileDirectory
	dir _ aFileDirectory.
	dir assureExistence! !

!AniGroupsModule methodsFor: 'initialization'!
initialize
	| id group |
	sema _ Semaphore forMutualExclusion.
	idToGroup _ Dictionary new.
	dir fileNames do: [:fName | (fName endsWith: '.xml') ifTrue: [
		id _ fName copyFrom: 1 to: (fName size - 4).
		id _ id asNumber.
		group _ AniGroup newFromXml: (XMLDOMParser parseDocumentFrom: (dir fileNamed: fName)).
		group id: id.
		group module: self.
		idToGroup at: id put: group]]! !


!AniGroupsModule class methodsFor: 'as yet unclassified'!
onDir: aFileDirectory
	^self basicNew
		dir: aFileDirectory;
		initialize;
		yourself! !


!ComSwikiLauncher methodsFor: 'accessing'!
isShutdown
	^isShutdown ifNil: [false] ifNotNil: [isShutdown]! !

!ComSwikiLauncher methodsFor: 'accessing'!
isShutdown: boolean
	(self isShutdown = boolean) ifFalse: [
		isShutdown _ boolean.
		self changed: #isShutdown]! !

!ComSwikiLauncher methodsFor: 'accessing'!
package: aSymbol
	package _ aSymbol! !

!ComSwikiLauncher methodsFor: 'accessing'!
port: anInteger
	port _ anInteger.
	portButton label: self portText.
	self changed: #portText! !

!ComSwikiLauncher methodsFor: 'accessing'!
ports: col
	ports _ col.
	port _ col at: 1.! !

!ComSwikiLauncher methodsFor: 'buttons'!
portButton: aMorph
	portButton _ aMorph.
	portButton label: self portText! !

!ComSwikiLauncher methodsFor: 'buttons'!
portText
	^'port: ', (port asString)! !

!ComSwikiLauncher methodsFor: 'buttons'!
startStopButton: aMorph
	startStopButton _ aMorph.
	startStopButton label: self startStopLabel! !

!ComSwikiLauncher methodsFor: 'buttons'!
startStopLabel
	^(self isOn)
		ifTrue: ['stop server']
		ifFalse: ['start server']! !

!ComSwikiLauncher methodsFor: 'initialize-release'!
initialize
	self ports: ValidPorts.
	super initialize.! !

!ComSwikiLauncher methodsFor: 'action'!
changePort
	| index |

	self isOn ifFalse: [index _ 1.
		1 to: (ports size) do: [:i | (ports at: i) = port ifTrue: [index _ i + 1]].
		(ports size < index) ifTrue: [index _ 1].
		self port: (ports at: index)]! !

!ComSwikiLauncher methodsFor: 'action'!
debugMode
	(HttpService serviceOnPort: port) setDebugMode! !

!ComSwikiLauncher methodsFor: 'action'!
deploymentMode
	(HttpService serviceOnPort: port) setDeploymentMode! !

!ComSwikiLauncher methodsFor: 'action'!
isOn
	^ (HttpService
		serviceOnPort: port
		ifAbsent: []) notNil! !

!ComSwikiLauncher methodsFor: 'action'!
isPort
	^false! !

!ComSwikiLauncher methodsFor: 'action'!
openSwikiBrowser
	| shelf label |
	label _ port = 80
				ifTrue: ['Swiki Browser']
				ifFalse: ['Swiki Browser: ' , port asString].
	module ifNil: [Smalltalk isMorphic
						ifFalse: [PopUpMenu notify: 'Start the server'].
					^ self].
shelf _ module shelf.
	Smalltalk isMorphic
		ifTrue: [(SwikiBrowser asMorphOnShelf: shelf label: label) openInWorld]
		ifFalse: [SwikiBrowser asMVCOnShelf: shelf label: label]! !

!ComSwikiLauncher methodsFor: 'action'!
shutdown
	self class shutdown! !

!ComSwikiLauncher methodsFor: 'action'!
startServer
	"To Start Swiki on Comanche:"
	Socket initializeNetwork.
	module _ SwikiModule perform: package.
	module
		ifNil: [self error: 'Did not start!!'].
	((HttpService on: port named: package asString , '-' , port asString)
		plug: module) start.
	startStopButton label: self startStopLabel.
	self class allInstancesDo: [:each | each changed: #startStopLabel.
									each changed: #isOn]! !

!ComSwikiLauncher methodsFor: 'action'!
stopServer
	"To End Swiki on Comanche:"
	| service shelf |
	Smalltalk garbageCollect.
	shelf _ module shelf.
	"module"
	(SwikiBrowser allInstances
			select: [:browser | browser shelf = shelf]) size > 0
		ifTrue: [PopUpMenu notify: 'Before stopping the server, you
need to close the Swiki Brower'.
			^ self].
	(service _ HttpService
				serviceOnPort: port
				ifAbsent: [])
		ifNotNil: [service unregister].
	module _ nil.
	Smalltalk garbageCollect.
	startStopButton label: self startStopLabel.
	self class allInstancesDo: [:each | each changed: #startStopLabel.
										each changed: #isOn]! !

!ComSwikiLauncher methodsFor: 'action'!
toggleState
	(self isOn)
		ifTrue: [self stopServer]
		ifFalse: [self startServer]! !

!ComSwikiLauncher methodsFor: 'looks'!
defaultBackgroundColor
	^Color yellow! !

!ComSwikiLauncher methodsFor: 'looks'!
initialExtent
	^300@50! !

!ComSwikiLauncher methodsFor: 'window menu'!
addModelItemsToWindowMenu: aMenu
	(self isOn) ifTrue: [
		aMenu addLine.
		aMenu add: 'open swiki browser...' target: self action: #openSwikiBrowser.
		(HttpService serviceOnPort: port) isDebugMode
			ifTrue: [aMenu add: 'turn debug mode off' target: self action: #deploymentMode]
			ifFalse: [aMenu add: 'turn debug mode on' target: self action: #debugMode]].
	^super addModelItemsToWindowMenu: aMenu! !


!ComSwikiLauncher class methodsFor: 'initialize-release'!
initialize
	ValidPorts _ OrderedCollection new.
	ValidPorts add: 80.
	ValidPorts add: 8000.
	ValidPorts add: 8080.
	ValidPorts add: 8888.
	self autoCorrectMissingPages: true! !

!ComSwikiLauncher class methodsFor: 'private'!
shutdown
	self allInstances do: [:launcher |
		launcher isShutdown: true.
		launcher isOn ifTrue: [launcher stopServer]].
	Smalltalk snapshot: true andQuit: true.
	self allInstances do: [:launcher |
		launcher startServer.
		launcher isShutdown: false]! !

!ComSwikiLauncher class methodsFor: 'utility'!
autoCorrectMissingPages
	^AutoCorrectMissingPages! !

!ComSwikiLauncher class methodsFor: 'utility'!
autoCorrectMissingPages: aBoolean
	AutoCorrectMissingPages _ aBoolean! !

!ComSwikiLauncher class methodsFor: 'utility'!
convertOldATA
	"Convert Addresses, Templates, and Actions from Beta to Release"
	| dir bookOrShelfDir |
	dir _ FileDirectory default directoryNamed: 'swiki'.
	dir directoryNames do: [:dName |
		bookOrShelfDir _ dir directoryNamed: dName.
		(bookOrShelfDir directoryExists: 'addresses') ifTrue: [
			self convertOldATADirectory: (bookOrShelfDir directoryNamed: 'addresses')].
		(bookOrShelfDir directoryExists: 'templates') ifTrue: [
			self convertOldATADirectory: (bookOrShelfDir directoryNamed: 'templates')].
		(bookOrShelfDir directoryExists: 'actions') ifTrue: [
			self convertOldATADirectory: (bookOrShelfDir directoryNamed: 'actions')]]
! !

!ComSwikiLauncher class methodsFor: 'utility'!
convertOldATADirectory: dir
	| id xmlMeta subDir |
	id _ 1.
	xmlMeta _ WriteStream on: String new.
	xmlMeta
		nextPutAll: '<?xml version="1.0"?>';
		nextPut: Character cr;
		nextPutAll: '<meta>';
		nextPut: Character cr.
	dir fileNames do: [:fName |
		((fName endsWith: '.book') or: [fName endsWith: '.page']) ifTrue: [
			xmlMeta
				nextPutAll: '<file id="';
				nextPutAll: id asString;
				nextPutAll: '" type="';
				nextPutAll: (fName copyAfterLast: $.);
				nextPutAll: '" name="';
				nextPutAll: (fName copyUpTo: $.);
				nextPutAll: '" />';
				nextPut: Character cr.
			dir rename: fName toBe: id asString.
			id _ id + 1]].
	dir directoryNames do: [:dName |
		subDir _ dir directoryNamed: dName.
		subDir fileNames do: [:fName |
			((fName endsWith: '.book') or: [fName endsWith: '.page']) ifTrue: [
				xmlMeta
					nextPutAll: '<file id="';
					nextPutAll: id asString;
					nextPutAll: '" type="';
					nextPutAll: (fName copyAfterLast: $.);
					nextPutAll: '" name="';
					nextPutAll: (fName copyUpTo: $.);
					nextPutAll: '" category="';
					nextPutAll: dName;
					nextPutAll: '" />';
					nextPut: Character cr.
				dir rename: (subDir fullNameFor: fName) toBe: id asString.
				id _ id + 1]].
		dir deleteDirectory: dName].
	xmlMeta
		nextPutAll: '</meta>'.
	(dir newFileNamed: 'meta.xml')
		nextPutAll: xmlMeta contents;
		close
! !

!ComSwikiLauncher class methodsFor: 'utility'!
convertOldPages
	"Conversion method used to convert old Swikis (pre-Beta 11) to the new file format.
	This is to be run after the new server is up and running."
	| oldAlerts newAlerts |
	NuSwikiPage allInstances do: [:page |
		(page settingsIncludes: 'alerts')	ifTrue: [
			oldAlerts _ page settingsAt: 'alerts'.
			newAlerts _ ''.
			(oldAlerts isKindOf: String) ifFalse: [
				oldAlerts do: [:address | newAlerts _ newAlerts, ', ', address].
				newAlerts _ newAlerts copyFrom: 3 to: (newAlerts size).
				page settingsAt: 'alerts' put: newAlerts]].
		page text: (page text).
		page write]! !

!ComSwikiLauncher class methodsFor: 'instance creation'!
openAsMorph
	^self openAsMorphPackage: #swikiWebServer! !

!ComSwikiLauncher class methodsFor: 'instance creation'!
openAsMorphPackage: package
	| instance window aColor startStopButton shutdownButton portButton |

	"Instance of ComSwiki Launcher"
	instance _ self new.
	instance package: package.
	"Display Morph"
	window _ (SystemWindow labelled: 'ComSwiki Launcher') model: instance.
	aColor _ Color colorFrom: instance defaultBackgroundColor.
	"Start/Stop Button"
	startStopButton _ PluggableButtonMorph on: instance getState: #isOn action: #toggleState.
	instance startStopButton: startStopButton.
	startStopButton askBeforeChanging: true.
	startStopButton color: aColor; onColor: (Color red) offColor: (Color green).
	window addMorph: startStopButton frame: (0@0 corner: 0.35@1).
	"Shutdown Button"
	shutdownButton _ PluggableButtonMorph on: instance getState: #isShutdown action: #shutdown.
	shutdownButton label: 'save & exit'; askBeforeChanging: true.
	shutdownButton color: aColor; onColor: aColor darker offColor: aColor.
	window addMorph: shutdownButton frame: (0.35@0 corner: 0.7@1).
	"Port Button"
	portButton _ PluggableButtonMorph on: instance getState: #isPort action: #changePort.
	instance portButton: portButton.
	portButton askBeforeChanging: true.
	portButton color: aColor; onColor: aColor offColor: aColor.
	window addMorph: portButton frame: (0.7@0 corner: 1@1).
	"Add to World"
	window openInWorld.! !

!ComSwikiLauncher class methodsFor: 'instance creation'!
openMVCView
	^self openMVCViewPackage: #swikiWebServer! !

!ComSwikiLauncher class methodsFor: 'instance creation'!
openMVCViewPackage: package
	"ComSwikiLauncher openMVCViewPackage: #swikiWebServer."
	| instance window aColor startStopButton shutdownButton portButton openSwikiBrowserButton |

	"Instance of ComSwiki Launcher"
	instance _ self new.
	instance package: package.
	"Display View"
	window _ StandardSystemView new model: instance.
	window label: 'ComSwiki Launcher'.

	aColor _ Color colorFrom: instance defaultBackgroundColor.
	"Start/Stop Button"
	startStopButton _ PluggableButtonView on: instance getState: #isOn action: #toggleState label: #startStopLabel.
	instance startStopButton: startStopButton.
	startStopButton askBeforeChanging: true.
	startStopButton
		backgroundColor: aColor;
		borderWidth: 1.
		"; onColor: (Color red) offColor: (Color green)."
	window addSubView: startStopButton.

	"Shutdown Button"
	shutdownButton _ PluggableButtonView on: instance getState: #isShutdown action: #shutdown.
	shutdownButton label: 'save & exit'; askBeforeChanging: true.
	shutdownButton
		backgroundColor: aColor;
		borderWidth: 1.
		"; onColor: aColor darker offColor: aColor."
	window addSubView: shutdownButton toRightOf: startStopButton.

	"Port Button"
	portButton _ PluggableButtonView on: instance getState: #isPort action: #changePort label: #portText.
	instance portButton: portButton.
	portButton askBeforeChanging: true.
	portButton
		backgroundColor: aColor;
		borderWidth: 1.
		"; onColor: aColor offColor: aColor."
	window addSubView: portButton toRightOf: shutdownButton.

	"OpenSwikiBrowserButton"
	openSwikiBrowserButton _ PluggableButtonView on: instance getState: nil action: #openSwikiBrowser.
	openSwikiBrowserButton label: 'SwikiBrowser'.
	openSwikiBrowserButton
		backgroundColor: aColor;
		borderWidth: 1.
	window addSubView: openSwikiBrowserButton toRightOf: portButton.


	"open window"
	window controller open! !


!IdFormatter methodsFor: 'accessing'!
endBlock: aBlock
	endBlock _ aBlock! !

!IdFormatter methodsFor: 'accessing'!
formatter: aBlock
	formatter _ aBlock! !

!IdFormatter methodsFor: 'accessing'!
idBlock: aBlock
	idBlock _ aBlock! !

!IdFormatter methodsFor: 'accessing'!
settingsAt: key put: value
	settings ifNil: [settings _ Dictionary new].
	settings at: key put: value.! !

!IdFormatter methodsFor: 'accessing'!
startBlock: aBlock
	startBlock _ aBlock! !

!IdFormatter methodsFor: 'accessing'!
transitionBlock: aBlock
	transitionBlock _ aBlock! !

!IdFormatter methodsFor: 'private'!
id: text
	^(idBlock copy fixTemps) value: text! !

!IdFormatter methodsFor: 'processing'!
endAfter: oldId on: stream text: text request: request response: response shelf: shelf book: book page: page
	| id strippedText |

	id _ self id: text.
	((text size) > (id size))
		ifTrue: [strippedText _ text copyFrom: (id size + 1) to: text size]
		ifFalse: [strippedText _ ''].
	stream nextPutAll: ((transitionBlock copy fixTemps) value: oldId value: id).
	stream nextPutAll: ((formatter copy fixTemps) valueWithArguments: (Array with: strippedText with: request with: response with: shelf with: book with: page)).
	stream nextPutAll: ((endBlock copy fixTemps) value: id).
	^id! !

!IdFormatter methodsFor: 'processing'!
singleOn: stream text: text request: request response: response shelf: shelf book: book page: page
	| id strippedText |

	id _ self id: text.
	((text size) > (id size))
		ifTrue: [strippedText _ text copyFrom: (id size + 1) to: text size]
		ifFalse: [strippedText _ ''].
	stream nextPutAll: ((startBlock copy fixTemps) value: id).
	stream nextPutAll: ((formatter copy fixTemps) valueWithArguments: (Array with: strippedText with: request with: response with: shelf with: book with: page)).
	stream nextPutAll: ((endBlock copy fixTemps) value: id).
	^id! !

!IdFormatter methodsFor: 'processing'!
startOn: stream text: text request: request response: response shelf: shelf book: book page: page
	| id strippedText |

	id _ self id: text.
	((text size) > (id size))
		ifTrue: [strippedText _ text copyFrom: (id size + 1) to: text size]
		ifFalse: [strippedText _ ''].
	stream nextPutAll: ((startBlock copy fixTemps) value: id).
	stream nextPutAll: ((formatter copy fixTemps) valueWithArguments: (Array with: strippedText with: request with: response with: shelf with: book with: page)).
	^id! !

!IdFormatter methodsFor: 'processing'!
transitionAfter: oldId on: stream text: text request: request response: response shelf: shelf book: book page: page
	| id strippedText |

	id _ self id: text.
	((text size) > (id size))
		ifTrue: [strippedText _ text copyFrom: (id size + 1) to: text size]
		ifFalse: [strippedText _ ''].
	stream nextPutAll: ((transitionBlock copy fixTemps) value: oldId value: id).
	stream nextPutAll: ((formatter copy fixTemps) valueWithArguments: (Array with: strippedText with: request with: response with: shelf with: book with: page)).
	^id! !


!IdFormatter class methodsFor: 'utility'!
appendFormat: text request: request response: response shelf: shelf book: book page: page
	| append content today |
	content _ String streamContents: [:stream |
		(text includes: $_) ifTrue: [
			"_ means appends are seperated by lines"
			stream
				nextPutAll: '_';
				nextPutAll: String cr].
		(text includes: $@) ifTrue: [
			"@ means appends include timestamps"
			today _ Date today.
			stream
				nextPutAll: '<tt><em>';
				nextPutAll: today weekday;
				nextPutAll: ', ';
				nextPutAll: today dayOfMonth asString;
				nextPutAll: ' ';
				nextPutAll: today monthName;
				nextPutAll: ' ';
				nextPutAll: today year asString;
				nextPutAll: ', '.
			Time now printOn: stream.
			(request security isKindOf: SwikiUser) ifTrue: [stream
				nextPutAll: ', ';
				nextPutAll: (TextFormatter encodeToXmlCr: request security name)].
			(request security isKindOf: SwikiSecurityMember) ifTrue: [
				request security user ifNotNil: [stream
					nextPutAll: ', ';
					nextPutAll: (request security user asString)]].
			stream
				nextPutAll: '</em></tt>';
				nextPutAll: String cr].
		stream
			nextPutAll: ((book settingsAt: 'saveFormatter') format: (request fieldsKey: 'append') request: request response: response shelf: shelf book: book page: page);
			nextPutAll: String cr].
	"+ means appends are self replicating
	^ means append areas stay at top and appends go down"
	append _ text, String cr.
	^((text occurrencesOf: $+) > 1)
		ifTrue: [append, content, append]
		ifFalse: [(text includes: $^)
			ifTrue: [append, content]
			ifFalse: [content, append]]! !

!IdFormatter class methodsFor: 'instance creation'!
anchor
	| instance |

	instance _ self new.
	instance idBlock: [:text | '@'].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	instance formatter: [:text :request :response :shelf :book :page | '<a name="', (PageFormatter toSafeLocation: text), '"></a>', String cr].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
append
	| instance |

	instance _ self new.
	instance idBlock: [:text | '+'].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	"- means appends show up without an append area"
	instance formatter: [:text :request :response :shelf :book :page | book formatPageTemplate: ((text includes: $-) ifTrue: ['appendSansArea'] ifFalse: ['append']) request: request response: response shelf: shelf page: page].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
appendRender
	| instance |

	instance _ self new.
	instance idBlock: [:text | '+'].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	instance formatter: [:text :request :response :shelf :book :page | ''].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
break
	| instance |

	instance _ self new.
	instance idBlock: [:text | '_'].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	instance formatter: [:text :request :response :shelf :book :page | (book formatBookAction: 'bar' request: request response: response shelf: shelf), String cr].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
heading: formatter
	| instance |

	instance _ self new.
	instance idBlock: [:text | (text beginsWith: '!!!!')
		ifTrue: [(text beginsWith: '!!!!!!')
			ifTrue: ['!!!!!!']
			ifFalse: ['!!!!']]
		ifFalse: ['!!']].
	instance startBlock: [:id | '<h', (4 - id size) asString, '>'].
	instance endBlock: [:id | '</h', (4 - id size) asString, '>', String cr].
	instance transitionBlock: [:idOld :idNew | '</h', (4 - idOld size) asString, '>', String cr, '<h', (4 - idNew size) asString, '>'].
	instance formatter: [:text :request :response :shelf :book :page | formatter format: text request: request response: response shelf: shelf book: book page: page].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
leaveAlone
	| instance |

	instance _ self new.
	instance idBlock: [:text | ''].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	instance formatter: [:text :request :response :shelf :book :page | text, String cr].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
list: formatter
	| instance match return |

	instance _ self new.
	instance idBlock: [:text | return _ 1.
		[(text size >= return) and: [((text at: return) = $-) or: [(text at: return) = $#]]]
			whileTrue: [return _ return + 1].
		text copyFrom: 1 to: (return-1)].
	instance startBlock: [:id | return _ ''.
		id do: [:char | (char = $-)
			ifTrue: [return _ return, '<ul>', String cr]
			ifFalse: [return _ return, '<ol>', String cr]].
		return].
	instance endBlock: [:id | return _ ''.
		id do: [:char | (char = $-)
			ifTrue: [return _ '</ul>', String cr, return]
			ifFalse: [return _ '</ol>', String cr, return]].
		return].
	instance transitionBlock: [:idOld :idNew | return _ ''.
		match _ 1.
		[((idOld size >= match) and: [idNew size >= match]) and: [(idOld at: match) = (idNew at: match)]] whileTrue: [match _ match + 1].
		(idOld size > (match - 1)) ifTrue: [(idOld copyFrom: match to: idOld size) do: [:char | (char = $-) ifTrue: [return _ '</ul>', String cr, return] ifFalse: [return _ '</ol>', String cr, return]]].
		(idNew size > (match - 1)) ifTrue: [(idNew copyFrom: match to: idNew size) do: [:char | (char = $-) ifTrue: [return _ return, '<ul>', String cr] ifFalse: [return _ return, '<ol>', String cr]]].
		return].
	instance formatter: [:text :request :response :shelf :book :page | '<li>', (formatter format: text request: request response: response shelf: shelf book: book page: page), String cr].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
preformatted: formatter
	| instance |

	instance _ self new.
	instance idBlock: [:text | '='].
	instance startBlock: [:id | '<pre>'].
	instance endBlock: [:id | '</pre>', String cr].
	instance transitionBlock: [:idOld :idNew | String cr].
	instance formatter: [:text :request :response :shelf :book :page | formatter format: text request: request response: response shelf: shelf book: book page: page].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
saveAppend
	| instance |

	instance _ self new.
	instance idBlock: [:text | ''].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	instance formatter: [:text :request :response :shelf :book :page |
		"Add appendId setting"
		(request settingsIncludes: 'appendId')
			ifTrue: [request settingsAt: 'appendId' put: 1 + (request settingsAt: 'appendId')]
			ifFalse: [request settingsAt: 'appendId' put: 1].
		((request settingsAt: 'appendId') = (request fieldsAsNumberKey: 'appendId'))
			ifTrue: [(request settingsIncludes: 'formId')
				ifTrue: [((request settingsAt: 'formId') = (request fieldsKey: 'formId'))
					ifTrue: [
						request settingsAt: 'appendSuccess' put: true.
						self appendFormat: text request: request response: response shelf: shelf book: book page: page]
					ifFalse: [text, String cr]]
				ifFalse: [
					request settingsAt: 'appendSuccess' put: true.
					self appendFormat: text request: request response: response shelf: shelf book: book page: page]]
			ifFalse: [text, String cr]].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
table: formatter
	| instance return |

	instance _ self new.
	instance idBlock: [:text | '|'].
	instance startBlock: [:id | '<table border=1 cellspacing=0 cellpadding=5>', String cr, '<tr>'].
	instance endBlock: [:id | '</tr>', String cr, '</table>', String cr].
	instance transitionBlock: [:idOld :idNew | '</tr>', String cr, '<tr>'].
	instance formatter: [:text :request :response :shelf :book :page | return _ ''.
		(text findTokens: '|') do: [:token | return _ return, '<td>', (formatter format: token request: request response: response shelf: shelf book: book page: page), '</td>'].
		return].
	^instance! !

!IdFormatter class methodsFor: 'instance creation'!
text: formatter
	| instance |

	instance _ self new.
	instance idBlock: [:text | ''].
	instance startBlock: [:id | ''].
	instance endBlock: [:id | ''].
	instance transitionBlock: [:idOld :idNew | ''].
	instance formatter: [:text :request :response :shelf :book :page | (formatter format: text request: request response: response shelf: shelf book: book page: page), '<br>', String cr].
	^instance! !


!LineFormatter methodsFor: 'accessing'!
addDefaultFormatter: anIdFormatter
	(formatters = nil) ifTrue: [formatters _ Dictionary new].
	formatters at: LF put: anIdFormatter! !

!LineFormatter methodsFor: 'accessing'!
addExceptionFrom: startsWith to: endsWith using: formatter
	| element |

	(exceptions = nil) ifTrue: [exceptions _ OrderedCollection new].
	element _ Array new: 3.
	element
		at: 1 put: startsWith;
		at: 2 put: endsWith;
		at: 3 put: formatter.
	exceptions add: element.! !

!LineFormatter methodsFor: 'accessing'!
addFormatter: anIdFormatter at: char
	(formatters = nil) ifTrue: [formatters _ Dictionary new].
	formatters at: char put: anIdFormatter! !

!LineFormatter methodsFor: 'accessing'!
convertToCrlf: aBoolean
	convertToCrlf _ aBoolean! !

!LineFormatter methodsFor: 'accessing'!
exceptions
	^exceptions! !

!LineFormatter methodsFor: 'accessing'!
formatters
	^formatters! !

!LineFormatter methodsFor: 'accessing'!
storeID
	^storeID! !

!LineFormatter methodsFor: 'accessing'!
storeID: id
	storeID _ id! !

!LineFormatter methodsFor: 'private'!
combine: formattedText with: exceptionCollection
	| i return pos1 pos2 |

	i _ 0.
	return _ WriteStream on: (String new: (formattedText size * 2)).
	pos1 _ 1.
	[(pos2 _ formattedText indexOf: LF startingAt: pos1 ifAbsent: [0]) == 0] whileFalse: [
		(pos1 = pos2) ifFalse: [return nextPutAll: (formattedText copyFrom: pos1 to: (pos2 - 1))].
		return nextPutAll: (exceptionCollection at: (i _ i + 1) ifAbsent: ['']).
		pos1 _ pos2 + 1].
	(pos1 > formattedText size) ifFalse: [return nextPutAll: (formattedText copyFrom: pos1 to: formattedText size)].
	^return contents! !

!LineFormatter methodsFor: 'private'!
formattedTextFrom: text request: request response: response shelf: shelf book: book page: page
	| return start end coll types id |

	return _ ReadWriteStream on: (String new: text size).
	coll _ OrderedCollection new.
	types _ OrderedCollection new.
	start _ 1.
	[start <= (text size)] whileTrue: [
		end _ text indexOf: CR startingAt: start ifAbsent: [end _ text size + 1].
		coll add: ((start = end) ifTrue: [''] ifFalse: [text copyFrom: start to: end-1]).
		start _ end + 1].
	(coll size = 0) ifTrue: [^return contents].
	coll do: [:element | types add: (self typeFrom: element)].
	(coll size = 1) ifTrue: [(types at: 1) singleOn: return text: (coll at: 1) request: request response: response shelf: shelf book: book page: page.
		^return contents].
	((types at: 2) = (types at: 1))
		ifTrue: [id _ (types at: 1) startOn: return text: (coll at: 1) request: request response: response shelf: shelf book: book page: page]
		ifFalse: [id _ (types at: 1) singleOn: return text: (coll at: 1) request: request response: response shelf: shelf book: book page: page].
	(coll size > 2) ifTrue: [
		2 to: (coll size - 1) do: [:i | ((types at: i) = (types at: i+1))
			ifTrue: [((types at: i) = (types at: i-1))
				ifTrue: [id _ (types at: i) transitionAfter: id on: return text: (coll at: i) request: request response: response shelf: shelf book: book page: page]
				ifFalse: [id _ (types at: i) startOn: return text: (coll at: i) request: request response: response shelf: shelf book: book page: page]]
			ifFalse: [((types at: i) = (types at: i-1))
				ifTrue: [id _ (types at: i) endAfter: id on: return text: (coll at: i) request: request response: response shelf: shelf book: book page: page]
				ifFalse: [id _ (types at: i) singleOn: return text: (coll at: i) request: request response: response shelf: shelf book: book page: page]]]].
	((types last) = (types at: (types size - 1)))
		ifTrue: [id _ (types last) endAfter: id on: return text: (coll last) request: request response: response shelf: shelf book: book page: page]
		ifFalse: [id _ (types last) singleOn: return text: (coll last) request: request response: response shelf: shelf book: book page: page].
	^return contents
! !

!LineFormatter methodsFor: 'private'!
splitTextAndExceptionsFrom: text request: request response: response shelf: shelf book: book page: page
	| col formatterText start tempStart matchStart matchException matchEnd matchText |

	col _ OrderedCollection new.
	formatterText _ ReadWriteStream on: (String new: text size).
	start _ 1.
	[start <= (text size)] whileTrue: [
		matchStart _ text size.
		matchException _ nil.
		exceptions do: [:exception | tempStart _ text findString: (exception at: 1) startingAt: start.
			((tempStart > 0) and: [tempStart < matchStart]) ifTrue: [matchStart _ tempStart.
				matchException _ exception]].
		matchException
			ifNil: ["No more found"
				formatterText nextPutAll: (text copyFrom: start to: text size).
				start _ text size + 1]
			ifNotNil: [
				(start = matchStart) ifFalse: [formatterText nextPutAll: (text copyFrom: start to: matchStart-1)].
				formatterText nextPut: LF.
				matchEnd _ text findString: (matchException at: 2) startingAt: matchStart.
				(matchEnd = 0)
					ifTrue: ["End of text"
						matchText _ text copyFrom: (matchStart + (matchException at: 1) size) to: text size.
						start _ text size + 1]
					ifFalse: [
						matchText _ text copyFrom: (matchStart + (matchException at: 1) size) to: (matchEnd - 1).
						start _ matchEnd + (matchException at: 2) size].
				col add: (((matchException at: 3) copy fixTemps) valueWithArguments: (Array with: matchText with: request with: response with: shelf with: book with: page))]].
	^Array with: formatterText contents with: col! !

!LineFormatter methodsFor: 'private'!
storeString
	"Overwrite of Object method to save space for storing"
	(storeID) ifNotNil: ["Check to make sure this storeID is valid"
		(self class respondsTo: storeID)
			ifTrue: [^'(', self class asString, ' ', storeID asString, ')']].
	^super storeString! !

!LineFormatter methodsFor: 'private'!
typeFrom: text
	^(text size = 0)
		ifTrue: [formatters at: LF]
		ifFalse: [formatters at: (text at: 1) ifAbsent: [formatters at: LF]]! !

!LineFormatter methodsFor: 'processing'!
format: text request: request response: response shelf: shelf book: book page: page
	| textAndException crText |

	"textAndException will be a 2 element array with the readToFormatText and the exceptionCollection"
	textAndException _ self splitTextAndExceptionsFrom: text request: request response: response shelf: shelf book: book page: page.
	crText _ self combine: (self formattedTextFrom: textAndException first request: request response: response shelf: shelf book: book page: page) with: textAndException last.
	^convertToCrlf
		ifTrue: [TextFormatter crToCrlf: crText]
		ifFalse: [crText]! !


!LineFormatter class methodsFor: 'instance creation'!
appendFormatter
	| instance |

	instance _ self new.
	instance storeID: #appendFormatter.
	instance convertToCrlf: false.
	instance addExceptionFrom: '<html>' to: '</html>' using: [:text :request :response :shelf :book :page | '<html>', (TextFormatter crlfToCr: text), '</html>'].
	instance addExceptionFrom: '<HTML>' to: '</HTML>' using: [:text :request :response :shelf :book :page | '<HTML>', (TextFormatter crlfToCr: text), '</HTML>'].
	instance addExceptionFrom: '<code>' to: '</code>' using: [:text :request :response :shelf :book :page | '<code>', (TextFormatter crlfToCr: text), '</code>'].
	instance addExceptionFrom: '<CODE>' to: '</CODE>' using: [:text :request :response :shelf :book :page | '<CODE>', (TextFormatter crlfToCr: text), '</CODE>'].
	instance addExceptionFrom: '<?' to: '?>' using: [:text :request :response :shelf :book :page | '<?', (TextFormatter crlfToCr: text), '?>'].
	instance addFormatter: (IdFormatter saveAppend) at: $+.
	instance addDefaultFormatter: (IdFormatter leaveAlone).
	^instance! !

!LineFormatter class methodsFor: 'instance creation'!
renderFormatter
	| instance textFormatter listFormatter |

	instance _ self new.
	instance storeID: #renderFormatter.
	instance convertToCrlf: true.
	textFormatter _ PageFormatter new.
	textFormatter
		initialize;
		addRenderInternalLinks;
		addTagIntegrity;
		addShowSpecialCharacters;
		addRenderUploadLinks.
	instance addExceptionFrom: '<html>' to: '</html>' using: [:text :request :response :shelf :book :page | TextFormatter crToCrlf: text].
	instance addExceptionFrom: '<HTML>' to: '</HTML>' using: [:text :request :response :shelf :book :page | TextFormatter crToCrlf: text].
	instance addExceptionFrom: '<code>' to: '</code>' using: [:text :request :response :shelf :book :page | '<pre>', (TextFormatter encodeToXmlCrlf: text), '</pre>'].
	instance addExceptionFrom: '<CODE>' to: '</CODE>' using: [:text :request :response :shelf :book :page | '<pre>', (TextFormatter encodeToXmlCrlf: text), '</pre>'].
	instance addFormatter: (IdFormatter break) at: $_.
	instance addFormatter: (IdFormatter anchor) at: $@.
	instance addFormatter: (IdFormatter appendRender) at: $+.
	instance addFormatter: (IdFormatter heading: textFormatter) at: $!!.
	listFormatter _ IdFormatter list: textFormatter.
	instance addFormatter: (listFormatter) at: $-.
	instance addFormatter: (listFormatter) at: $#.
	instance addFormatter: (IdFormatter table: textFormatter) at: $|.
	instance addFormatter: (IdFormatter preformatted: textFormatter) at: $=.
	instance addDefaultFormatter: (IdFormatter text: textFormatter).
	^instance! !

!LineFormatter class methodsFor: 'instance creation'!
showFormatter
	| instance textFormatter listFormatter |

	instance _ self new.
	instance storeID: #showFormatter.
	instance convertToCrlf: true.
	textFormatter _ PageFormatter new.
	textFormatter
		initialize;
		addInternalLinks;
		addTagIntegrity;
		addShowSpecialCharacters;
		addUploadLinks.
	instance addExceptionFrom: '<html>' to: '</html>' using: [:text :request :response :shelf :book :page | TextFormatter crToCrlf: text].
	instance addExceptionFrom: '<HTML>' to: '</HTML>' using: [:text :request :response :shelf :book :page | TextFormatter crToCrlf: text].
	instance addExceptionFrom: '<code>' to: '</code>' using: [:text :request :response :shelf :book :page | '<pre>', (TextFormatter encodeToXmlCrlf: text), '</pre>'].
	instance addExceptionFrom: '<CODE>' to: '</CODE>' using: [:text :request :response :shelf :book :page | '<pre>', (TextFormatter encodeToXmlCrlf: text), '</pre>'].
	instance addExceptionFrom: '<?' to: '?>' using: [:text :request :response :shelf :book :page | 
		self pluginText: text request: request response: response shelf: shelf book: book page: page].
	instance addFormatter: (IdFormatter break) at: $_.
	instance addFormatter: (IdFormatter anchor) at: $@.
	instance addFormatter: (IdFormatter append) at: $+.
	instance addFormatter: (IdFormatter heading: textFormatter) at: $!!.
	listFormatter _ IdFormatter list: textFormatter.
	instance addFormatter: (listFormatter) at: $-.
	instance addFormatter: (listFormatter) at: $#.
	instance addFormatter: (IdFormatter table: textFormatter) at: $|.
	instance addFormatter: (IdFormatter preformatted: textFormatter) at: $=.
	instance addDefaultFormatter: (IdFormatter text: textFormatter).
	^instance! !

!LineFormatter class methodsFor: 'utility'!
numberOrNilFromString: aStringOrNil
	aStringOrNil ifNil: [^nil].
	aStringOrNil isAllDigits ifFalse: [^nil].
	aStringOrNil isEmpty ifTrue: [^nil].
	^aStringOrNil asNumber! !

!LineFormatter class methodsFor: 'utility'!
parseFunctionAndOptionsFromText: text
	| state function options currentParse key |
	"start state"
	state _ 1.
	options _ Dictionary new.
	currentParse _ WriteStream on: String new.
	"Parse the text"
	text do: [:char | state caseOf: {
		[1]->["Awaiting function"
			(' 	' includes: char) ifFalse: [
				state _ 2.
				currentParse nextPut: char]].
		[2]->["function"
			(' 	' includes: char)
				ifTrue: ["Set function"
					function _ currentParse contents asLowercase.
					currentParse _ WriteStream on: String new.
					state _ 3]
				ifFalse: [currentParse nextPut: char]].
		[3]->["Awaiting key"
			(' 	' includes: char) ifFalse: [
				state _ 4.
				currentParse nextPut: char]].
		[4]->["key"
			(' 	' includes: char)
				ifTrue: ["Add as true option"
					options at: (currentParse contents asLowercase) put: ''.
					currentParse _ WriteStream on: String new.
					state _ 3]
				ifFalse: [(char = $=)
					ifTrue: ["Establish key"
						key _ currentParse contents asLowercase.
						state _ 5.
						currentParse _ WriteStream on: String new]
					ifFalse: [currentParse nextPut: char]]].
		[5]->["Awaiting value"
			(' 	' includes: char)
				ifTrue: ["Add as blank option"
					options at: key put: ''.
					state _ 3]
				ifFalse: [(char = $")
					ifTrue: ["Await multi-word value"
						state _ 6]
					ifFalse: ["Await single-word value"
						currentParse nextPut: char.
						state _ 7]]].
		[6]->["Multi-word value"
			(char = $")
				ifTrue: ["Set option"
					options at: key put: currentParse contents.
					state _ 3.
					currentParse _ WriteStream on: String new]
				ifFalse: [currentParse nextPut: char]].
		[7]->["Single-word value"
			(' 	' includes: char)
				ifTrue: ["Set option"
					options at: key put: currentParse contents.
					state _ 3.
					currentParse _ WriteStream on: String new]
				ifFalse: [currentParse nextPut: char]]}].
	"End Parsing based on state"
	state caseOf: {
		[1]->["Awaiting function"
			function _ ''].
		[2]->["function"
			function _ currentParse contents asLowercase].
		[3]->["Awaiting options"
			"Do nothing"].
		[4]->["key"
			options at: (currentParse contents asLowercase) put: ''].
		[5]->["Awaiting value"
			options at: key put: ''].
		[6]->["Multi-word value"
			options at: key put: currentParse contents].
		[7]->["Single-word value"
			options at: key put: currentParse contents]}.
	^Array with: function with: options! !

!LineFormatter class methodsFor: 'utility'!
pluginText: text request: request response: response shelf: shelf book: book page: page
	| functionAndOptions function |
	functionAndOptions _ self parseFunctionAndOptionsFromText: text.
	request settingsAt: 'options' put: (functionAndOptions at: 2).
	function _ (functionAndOptions at: 1), '-plugin'.
	^(book hasPageAction: function)
		ifTrue: [book formatPageAction: function request: request response: response shelf: shelf page: page]
		ifFalse: ['<b>Unknown function: ', (TextFormatter encodeToStrictXmlCr: (functionAndOptions at: 1)), '</b>']! !

!LineFormatter class methodsFor: 'initialize-release'!
initialize
	CR _ Character cr.
	LF _ Character lf! !


!RSSDocument methodsFor: 'initializing'!
initializeFromXml: xml
	| main channel itemTitle itemLink itemDescription itemCreator itemDate |
	creationTime _ Time totalSeconds.
	main _ xml elements at: 1.
	channel _ main elementAt: #channel ifAbsent: [^self error: 'Ill formed'].
	title _ (channel elementAt: #title ifAbsent: [^self error: 'Ill formed']) contentString.
	link _ (channel elementAt: #link ifAbsent: [^self error: 'Ill formed']) contentString.
	description _ (channel elementAt: #description ifAbsent: [^self error: 'Ill formed']) contentString.
	items _ (main name = #rss)
		ifTrue: [channel]
		ifFalse: [(main name = #rdf:RDF)
			ifTrue: [main]
			ifFalse: [^self error: 'Not a supported format']].
	items _ items elements select: [:element | element name = #item].
	items _ items collect: [:element |
		itemTitle _ (element elementAt: #title ifAbsent: [^self error: 'Ill formed']) contentString.
		itemLink _ (element elementAt: #link ifAbsent: [^self error: 'Ill formed']) contentString.
		itemDescription _ element elementAt: #description ifAbsent: [nil].
		itemDescription ifNotNil: [itemDescription _ itemDescription contentString].
		itemCreator _ element elementAt: #dc:creator ifAbsent: [nil].
		itemCreator ifNotNil: [itemCreator _ itemCreator contentString].
		itemDate _ element elementAt: #dc:date ifAbsent: [nil].
		itemDate ifNotNil: [
			itemDate _ itemDate contentString findTokens: '-'.
			itemDate _ (itemDate size > 2)
				ifTrue: [Date
					newDay: ((itemDate at: 3) asInteger)
					month: ((itemDate at: 2) asInteger)
					year: ((itemDate at: 1) asInteger)]
				ifFalse: [nil]].
		Array with: itemTitle with: itemLink with: itemDescription with: itemCreator with: itemDate].! !

!RSSDocument methodsFor: 'accessing'!
description
	^description! !

!RSSDocument methodsFor: 'accessing'!
link
	^link! !

!RSSDocument methodsFor: 'accessing'!
title
	^title! !

!RSSDocument methodsFor: 'testing'!
hasExpiredHours: hours
	^Time totalSeconds > ((hours * 3600) + creationTime)! !

!RSSDocument methodsFor: 'testing'!
hasExpiredMinutes: minutes
	^Time totalSeconds > ((minutes * 60) + creationTime)! !

!RSSDocument methodsFor: 'processing'!
itemsDo: aBlock
	"items is an array of #(title link description creator date)
	creator and date may both be nil"
	items do: [:i | aBlock valueWithArguments: i]! !

!RSSDocument methodsFor: 'processing'!
itemsMax: anInteger do: aBlock
	"items is an array of #(title link description creator date)
	creator and date may both be nil"
	((items size <= anInteger) or: [anInteger = 0])
		ifTrue: [items do: [:i | aBlock valueWithArguments: i]]
		ifFalse: [(items copyFrom: 1 to: anInteger) do: [:i | aBlock valueWithArguments: i]]! !


!RSSDocument class methodsFor: 'instance creation'!
fromXml: xmlDocument
	| return |
	return _ self new.
	return initializeFromXml: xmlDocument.
	^return! !


!SwikiBrowser methodsFor: 'accessing'!
shelf
	^shelf! !

!SwikiBrowser methodsFor: 'accessing'!
shelf: aSwikiShelf
	shelf _ aSwikiShelf! !

!SwikiBrowser methodsFor: 'category list'!
category
	(categoryListIndex = 0) ifTrue: [^nil].
	^categoryList at: categoryListIndex! !

!SwikiBrowser methodsFor: 'category list'!
categoryList
	^categoryList ifNil: [^OrderedCollection new] ifNotNil: [categoryList]! !

!SwikiBrowser methodsFor: 'category list'!
categoryListIndex
	^categoryListIndex ifNil: [0] ifNotNil: [categoryListIndex]! !

!SwikiBrowser methodsFor: 'category list'!
categoryListIndex: anInteger
	categoryListIndex _ anInteger.
	self changed: #categoryListIndex.
	self updateElementList! !

!SwikiBrowser methodsFor: 'category list'!
updateCategoryList
	| function |
	function _ self function.
	function ifNil: [
		categoryList _ OrderedCollection new.
		categoryListIndex _ 0.
		self changed: #categoryList.
		self updateElementList.
		^self].
	(self isSelectingABook) ifTrue: [function caseOf: {
		['addresses (book)']->["Book Address Categories"
			categoryList _ self book storage categoriesBookFunction: 'addresses' type: 'book'.
 			categoryListIndex _ 1].
		['addresses (page)']->["Page Address Categories"
			categoryList _ self book storage categoriesBookFunction: 'addresses' type: 'page'.
 			categoryListIndex _ 1].
		['addresses (priv)']->["Private Address Categories"
			categoryList _ self book storage categoriesBookFunction: 'addresses' type: 'priv'.
 			categoryListIndex _ 1].
		['templates (book)']->["Book Templates Categories"
			categoryList _ self book storage categoriesBookFunction: 'templates' type: 'book'.
 				categoryListIndex _ 1].
		['templates (page)']->["Page Templates Categories"
			categoryList _ self book storage categoriesBookFunction: 'templates' type: 'page'.
 				categoryListIndex _ 1].
		['actions (book)']->["Book Actions Categories"
			categoryList _ self book storage categoriesBookFunction: 'actions' type: 'book'.
 				categoryListIndex _ 1].
		['actions (page)']->["Page Actions Categories"
			categoryList _ self book storage categoriesBookFunction: 'actions' type: 'page'.
 				categoryListIndex _ 1].
		['settings']->["Settings"
			categoryList _ OrderedCollection with: '-- all --'.
			categoryListIndex _ 1].
		['setup']->["Setup"
			categoryList _ OrderedCollection with: '-- all --'.
			categoryListIndex _ 1]}
		otherwise: [self error: (function, ' is not a valid function.')]].
	(self isSelectingAShelf) ifTrue: [function caseOf: {
		['addresses (shelf)']->["Shelf Address Categories"
			categoryList _ shelf storage categoriesShelfFunction: 'addresses' type: 'shelf'.
 			categoryListIndex _ 1].
		['addresses (priv)']->["Private Address Categories"
			categoryList _ shelf storage categoriesShelfFunction: 'addresses' type: 'priv'.
 			categoryListIndex _ 1].
		['templates (shelf)']->["Shelf Templates Categories"
			categoryList _ shelf storage categoriesShelfFunction: 'templates' type: 'shelf'.
 				categoryListIndex _ 1].
		['templates (book)']->["Book Templates Categories"
			categoryList _ shelf storage categoriesShelfFunction: 'templates' type: 'book'.
 				categoryListIndex _ 1].
		['actions (shelf)']->["Shelf Actions Categories"
			categoryList _ shelf storage categoriesShelfFunction: 'actions' type: 'shelf'.
 				categoryListIndex _ 1].
		['actions (book)']->["Book Actions Categories"
			categoryList _ shelf storage categoriesShelfFunction: 'actions' type: 'book'.
 				categoryListIndex _ 1].
		['settings']->["Settings"
			categoryList _ OrderedCollection with: '-- all --'.
			categoryListIndex _ 1]}
		otherwise: [self error: (function, ' is not a valid function.')]].
	self changed: #categoryList.
	self updateElementList! !

!SwikiBrowser methodsFor: 'element list'!
contentFromBookElement
	| book element |
	book _ self book.
	element _ elementList at: elementListIndex.
	^self function caseOf:
		{['addresses (book)']->["Book Address"
			book storage bookFunction: 'addresses' type: 'book' name: element].
		['addresses (page)']->["Page Address"
			book storage bookFunction: 'addresses' type: 'page' name: element].
		['addresses (priv)']->["Private Address"
			book storage bookFunction: 'addresses' type: 'priv' name: element].
		['templates (book)']->["Book Template"
			book storage bookFunction: 'templates' type: 'book' name: element].
		['templates (page)']->["Page Template"
			book storage bookFunction: 'templates' type: 'page' name: element].
		['actions (book)']->["Book Action"
			book storage bookFunction: 'actions' type: 'book' name: element].
		['actions (page)']->["Page Action"
			book storage bookFunction: 'actions' type: 'page' name: element].
		['settings']->["Settings"
			(book settingsAt: element) storeString].
		['setup']->["Setup"
			(book setup at: element) storeString]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list'!
contentFromShelfElement
	| element |
	element _ elementList at: elementListIndex.
	^self function caseOf:
		{['addresses (shelf)']->["Shelf Address"
			shelf storage shelfFunction: 'addresses' type: 'shelf' name: element].
		['addresses (priv)']->["Private Address"
			shelf storage shelfFunction: 'addresses' type: 'priv' name: element].
		['templates (shelf)']->["Shelf Template"
			shelf storage shelfFunction: 'templates' type: 'shelf' name: element].
		['templates (book)']->["Book Template"
			shelf storage shelfFunction: 'templates' type: 'book' name: element].
		['actions (shelf)']->["Shelf Action"
			shelf storage shelfFunction: 'actions' type: 'shelf' name: element].
		['actions (book)']->["Book Action"
			shelf storage shelfFunction: 'actions' type: 'book' name: element].
		['settings']->["Settings"
			(shelf settingsAt: element) storeString]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list'!
element
	^elementList at: elementListIndex! !

!SwikiBrowser methodsFor: 'element list'!
elementList
	^elementList ifNil: [^OrderedCollection new] ifNotNil: [elementList]! !

!SwikiBrowser methodsFor: 'element list'!
elementListForBook
	| book category |
	book _ self book.
	category _ self category.
	self function caseOf:
		{['addresses (book)']->["Book Address Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'addresses' type: 'book'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'addresses' type: 'book'].
			^book storage bookFunction: 'addresses' type: 'book' category: category].
		['addresses (page)']->["Page Address Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'addresses' type: 'page'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'addresses' type: 'page'].
			^book storage bookFunction: 'addresses' type: 'page' category: category].
		['addresses (priv)']->["Private Address Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'addresses' type: 'priv'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'addresses' type: 'priv'].
			^book storage bookFunction: 'addresses' type: 'priv' category: category].
		['templates (book)']->["Book Templates Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'templates' type: 'book'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'templates' type: 'book'].
			^book storage bookFunction: 'templates' type: 'book' category: category].
		['templates (page)']->["Page Templates Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'templates' type: 'page'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'templates' type: 'page'].
			^book storage bookFunction: 'templates' type: 'page' category: category].
		['actions (book)']->["Book Actions Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'actions' type: 'book'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'actions' type: 'book'].
			^book storage bookFunction: 'actions' type: 'book' category: category].
		['actions (page)']->["Page Actions Categories"
			(category = '-- all --') ifTrue: [
				^book storage allBookFunction: 'actions' type: 'page'].
			(category = 'as yet unclassified') ifTrue: [
				^book storage ayuBookFunction: 'actions' type: 'page'].
			^book storage bookFunction: 'actions' type: 'page' category: category].
		['settings']->["Settings"
			^book rawSettings keys asSortedCollection: [:a :b | a asLowercase < b asLowercase]].
		['setup']->["Setup"
			^book setup keys asSortedCollection: [:a :b | a asLowercase < b asLowercase]]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list'!
elementListForShelf
	| category |
	category _ self category.
	self function caseOf: {
		['addresses (shelf)']->["Shelf Address Categories"
			(category = '-- all --') ifTrue: [
				^shelf storage allShelfFunction: 'addresses' type: 'shelf'].
			(category = 'as yet unclassified') ifTrue: [
				^shelf storage ayuShelfFunction: 'addresses' type: 'shelf'].
			^shelf storage shelfFunction: 'addresses' type: 'shelf' category: category].
		['addresses (priv)']->["Private Address Categories"
			(category = '-- all --') ifTrue: [
				^shelf storage allShelfFunction: 'addresses' type: 'priv'].
			(category = 'as yet unclassified') ifTrue: [
				^shelf storage ayuShelfFunction: 'addresses' type: 'priv'].
			^shelf storage shelfFunction: 'addresses' type: 'priv' category: category].
		['templates (shelf)']->["Shelf Templates Categories"
			(category = '-- all --') ifTrue: [
				^shelf storage allShelfFunction: 'templates' type: 'shelf'].
			(category = 'as yet unclassified') ifTrue: [
				^shelf storage ayuShelfFunction: 'templates' type: 'shelf'].
			^shelf storage shelfFunction: 'templates' type: 'shelf' category: category].
		['templates (book)']->["Book Templates Categories"
			(category = '-- all --') ifTrue: [
				^shelf storage allShelfFunction: 'templates' type: 'book'].
			(category = 'as yet unclassified') ifTrue: [
				^shelf storage ayuShelfFunction: 'templates' type: 'book'].
			^shelf storage shelfFunction: 'templates' type: 'book' category: category].
		['actions (shelf)']->["Shelf Actions Categories"
			(category = '-- all --') ifTrue: [
				^shelf storage allShelfFunction: 'actions' type: 'shelf'].
			(category = 'as yet unclassified') ifTrue: [
				^shelf storage ayuShelfFunction: 'actions' type: 'shelf'].
			^shelf storage shelfFunction: 'actions' type: 'shelf' category: category].
		['actions (book)']->["Book Actions Categories"
			(category = '-- all --') ifTrue: [
				^shelf storage allShelfFunction: 'actions' type: 'book'].
			(category = 'as yet unclassified') ifTrue: [
				^shelf storage ayuShelfFunction: 'actions' type: 'book'].
			^shelf storage shelfFunction: 'actions' type: 'book' category: category].
		['settings']->["Settings"
			^shelf settings keys asSortedCollection: [:a :b | a asLowercase < b asLowercase]]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list'!
elementListIndex
	^elementListIndex ifNil: [0] ifNotNil: [elementListIndex]! !

!SwikiBrowser methodsFor: 'element list'!
elementListIndex: anInteger
	elementListIndex _ anInteger.
	self changed: #elementListIndex.
	(elementListIndex = 0) ifTrue: [
		contents _ ''.
		self changed: #contents.
		^self].
	(self isSelectingABook) ifTrue: [
		contents _ self contentFromBookElement.
		self changed: #contents.
		^self].
	(self isSelectingAShelf) ifTrue: [
		contents _ self contentFromShelfElement.
		self changed: #contents.
		^self]! !

!SwikiBrowser methodsFor: 'element list'!
updateElementList
	(categoryListIndex = 0)
		ifTrue: [elementList _ OrderedCollection new]
		ifFalse: [
			self isSelectingABook ifTrue: [elementList _ self elementListForBook].
			self isSelectingAShelf ifTrue: [elementList _ self elementListForShelf]].
	elementListIndex _ 0.
	self changed: #elementList.
	contents _ ''.
	self changed: #contents! !

!SwikiBrowser methodsFor: 'initialization'!
initialize
	super initialize.
	bookListIndex _ 0.
	functionListIndex _ 0.
	categoryListIndex _ 0.
	elementListIndex _ 0.
	booksAsHierarchy _ false! !

!SwikiBrowser methodsFor: 'category list menu'!
addBookATACategory
	| response |
	(response _ FillInTheBlank request: 'Please type new category name' initialAnswer: 'category name') isEmpty ifTrue: [^self].
	self book storage addBookFunction: self ata type: self type category: response.
	self updateCategoryList.
	self categoryListIndex: (categoryList indexOf: response)! !

!SwikiBrowser methodsFor: 'category list menu'!
addShelfATACategory
	| response |
	(response _ FillInTheBlank request: 'Please type new category name' initialAnswer: 'category name') isEmpty ifTrue: [^self].
	shelf storage addShelfFunction: self ata type: self type category: response.
	self updateCategoryList.
	self categoryListIndex: (categoryList indexOf: response)! !

!SwikiBrowser methodsFor: 'category list menu'!
bookATACategoryListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new category"
	labels add: 'new category...'.
	selections add: #addBookATACategory.
	"Selected item"
	self category caseOf:
		{[nil]->["No selection"].
		['-- all --']->["All is selected"].
		['as yet unclassified']->[
			lines add: (labels size).
			"Rename category"
			labels add: 'rename...'.
			selections add: #renameBookATACategory]}
		otherwise: [
			lines add: (labels size).
			"Rename category"
			labels add: 'rename...'.
			selections add: #renameBookATACategory.
			"Remove category"
			labels add: 'remove'.
			selections add: #removeBookATACategory].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'category list menu'!
bookCategoryListMenu: aMenu
	self function caseOf:
		{['addresses (book)']->["Book Address"
			^self bookATACategoryListMenu: aMenu].
		['addresses (page)']->["Page Address"
			^self bookATACategoryListMenu: aMenu].
		['addresses (priv)']->["Private Address"
			^self bookATACategoryListMenu: aMenu].
		['templates (book)']->["Book Template"
			^self bookATACategoryListMenu: aMenu].
		['templates (page)']->["Page Template"
			^self bookATACategoryListMenu: aMenu].
		['actions (book)']->["Book Action"
			^self bookATACategoryListMenu: aMenu].
		['actions (page)']->["Page Action"
			^self bookATACategoryListMenu: aMenu].
		['settings']->["Settings"
			^nil].
		['setup']->["Setup"
			^nil].
		[nil]->["No Function"
			^nil]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'category list menu'!
categoryListMenu: aMenu
	self isSelectingABook ifTrue: [^self bookCategoryListMenu: aMenu].
	self isSelectingAShelf ifTrue: [^self shelfCategoryListMenu: aMenu].
	^nil! !

!SwikiBrowser methodsFor: 'category list menu'!
removeBookATACategory
	"Remove category"
	self book storage deleteBookFunction: self ata type: self type category: self category.
	self updateCategoryList.
	self categoryListIndex: 0! !

!SwikiBrowser methodsFor: 'category list menu'!
removeShelfATACategory
	"Remove category"
	shelf storage deleteShelfFunction: self ata type: self type category: self category.
	self updateCategoryList.
	self categoryListIndex: 0! !

!SwikiBrowser methodsFor: 'category list menu'!
renameBookATACategory
	| category response |
	category _ self category.
	(response _ FillInTheBlank request: 'Please type new category name' initialAnswer: category) isEmpty ifTrue: [^self].
	(category = response) ifTrue: [^self].
	(category = 'as yet unclassified') ifTrue: [category _ nil].
	self book storage renameBookFunction: self ata type: self type category: category to: response.
	self updateCategoryList.
	self categoryListIndex: (categoryList indexOf: response)! !

!SwikiBrowser methodsFor: 'category list menu'!
renameShelfATACategory
	| category response |
	category _ self category.
	(response _ FillInTheBlank request: 'Please type new category name' initialAnswer: category) isEmpty ifTrue: [^self].
	(category = response) ifTrue: [^self].
	(category = 'as yet unclassified') ifTrue: [category _ nil].
	shelf storage renameShelfFunction: self ata type: self type category: category to: response.
	self updateCategoryList.
	self categoryListIndex: (categoryList indexOf: response)! !

!SwikiBrowser methodsFor: 'category list menu'!
shelfATACategoryListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new category"
	labels add: 'new category...'.
	selections add: #addShelfATACategory.
	"Selected item"
	self category caseOf:
		{[nil]->["No selection"].
		['-- all --']->["All is selected"].
		['as yet unclassified']->[
			lines add: (labels size).
			"Rename category"
			labels add: 'rename...'.
			selections add: #renameShelfATACategory]}
		otherwise: [
			lines add: (labels size).
			"Rename category"
			labels add: 'rename...'.
			selections add: #renameShelfATACategory.
			"Remove category"
			labels add: 'remove'.
			selections add: #removeShelfATACategory].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'category list menu'!
shelfCategoryListMenu: aMenu
	self function caseOf:
		{['addresses (shelf)']->["Shelf Address"
			^self shelfATACategoryListMenu: aMenu].
		['addresses (priv)']->["Private Address"
			^self shelfATACategoryListMenu: aMenu].
		['templates (shelf)']->["Shelf Template"
			^self shelfATACategoryListMenu: aMenu].
		['templates (book)']->["Book Template"
			^self shelfATACategoryListMenu: aMenu].
		['actions (shelf)']->["Book Action"
			^self shelfATACategoryListMenu: aMenu].
		['actions (book)']->["Page Action"
			^self shelfATACategoryListMenu: aMenu].
		['settings']->["Settings"
			^nil].
		[nil]->["No Function"
			^nil]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'book list'!
book
	^(shelf books select: [:book | book name = self bookName]) first! !

!SwikiBrowser methodsFor: 'book list'!
bookList
	bookList ifNil: [self createBookList].
	^bookList! !

!SwikiBrowser methodsFor: 'book list'!
bookListIndex
	^bookListIndex ifNil: [0] ifNotNil: [bookListIndex]! !

!SwikiBrowser methodsFor: 'book list'!
bookListIndex: anInteger
	bookListIndex _ anInteger.
	self changed: #bookListIndex.
	self updateFunctionList! !

!SwikiBrowser methodsFor: 'book list'!
bookName
	^(bookList at: bookListIndex) withBlanksTrimmed! !

!SwikiBrowser methodsFor: 'book list'!
createBookList
	booksAsHierarchy
		ifTrue: [
			bookList _ OrderedCollection new.
			((shelf books select: [:book | book hasParent not]) asSortedCollection: [:a :b | a name asLowercase < b name asLowercase]) do: [:book |
				bookList addAll: (self hierarchyForBook: book indent: '')]]
		ifFalse: [bookList _ ((shelf books collect: [:book | book name]) asSortedCollection: [:a :b | a asLowercase < b asLowercase]) asOrderedCollection].
	bookList addFirst: '[shelf]'! !

!SwikiBrowser methodsFor: 'book list'!
isSelectingABook
	^bookListIndex > 1! !

!SwikiBrowser methodsFor: 'book list'!
isSelectingAShelf
	^bookListIndex = 1! !

!SwikiBrowser methodsFor: 'contents' stamp: 'xw 5/14/2022 11:54'!
bookContents: input notifying: aController
	| inputString inputCode book |
	inputString _ input asString.
	book _ self book.
	self function caseOf:
		{['addresses (book)']->["Book Address"
			Parser new parse: (ReadStream on: inputString) class: SwikiBookContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf :book |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			book bookAddresses at: self element put: inputCode.
			book storage bookFunction: 'addresses' type: 'book' name: self element content: inputString.
			contents _ inputString.
			^true].
		['addresses (page)']->["Page Address"
			Parser new parse: (ReadStream on: inputString) class: SwikiPageContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf :book :page |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			book pageAddresses at: self element put: inputCode.
			book storage bookFunction: 'addresses' type: 'page' name: self element content: inputString.
			contents _ inputString.
			^true].
		['addresses (priv)']->["Private Address"
			Parser new parse: (ReadStream on: inputString) class: SwikiBookContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf :book |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			book privAddresses at: self element put: inputCode.
			book storage bookFunction: 'addresses' type: 'priv' name: self element content: inputString.
			contents _ inputString.
			^true].
		['templates (book)']->["Book Template"
			book bookTemplates at: self element put: (TextFormatter crToCrlf: inputString).
			book storage bookFunction: 'templates' type: 'book' name: self element content: inputString.
			contents _ inputString.
			^true].
		['templates (page)']->["Page Template"
			book pageTemplates at: self element put: (TextFormatter crToCrlf: inputString).
			book storage bookFunction: 'templates' type: 'page' name: self element content: inputString.
			contents _ inputString.
			^true].
		['actions (book)']->["Book Action"
			Parser new parse: (ReadStream on: inputString) class: SwikiBookContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf :book |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			book bookActions at: self element put: inputCode.
			book storage bookFunction: 'actions' type: 'book' name: self element content: inputString.
			contents _ inputString.
			^true].
		['actions (page)']->["Page Action"
			Parser new parse: (ReadStream on: inputString) class: SwikiPageContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf :book :page |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			book pageActions at: self element put: inputCode.
			book storage bookFunction: 'actions' type: 'page' name: self element content: inputString.
			contents _ inputString.
			^true].
		['settings']->["Settings"
			inputCode _ Compiler evaluate: inputString notifying: aController logged: false.
			inputCode ifNil: [^false].
			book rawSettings at: self element put: inputCode.
			book writeSettings.
			contents _ aController text asString.
			^true].
		['setup']->["Setup"
			inputCode _ Compiler evaluate: inputString notifying: aController logged: false.
			inputCode ifNil: [^false].
			book setup at: self element put: inputCode.
			shelf storage writeSetupForBook: book.
			contents _ aController text asString.
			^true]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'contents'!
contents: input notifying: aController
	(elementListIndex = 0) ifTrue: ["Nothing is selected to update"
		PopUpMenu notify: 'This text cannot be accepted
in this part of the browser'.
		^false].
	[self isSelectingABook ifTrue: [^self bookContents: input notifying: aController].
	self isSelectingAShelf ifTrue: [^self shelfContents: input notifying: aController]]
		on: OutOfScopeNotification do: [:ex | ex resume: true].
	^true! !

!SwikiBrowser methodsFor: 'contents'!
contentsMenu: aMenu shifted: shifted
| shiftMenu |
^ shifted 
	ifFalse: [aMenu 
		labels: 
'find...(f)
find again (g)
set search string (h)
do again (j)
undo (z)
copy (c)
cut (x)
paste (v)
paste...
do it (d)
print it (p)
inspect it (i)
accept (s)
cancel (l)
more...' 
		lines: #(3 5 9 12 14)
		selections: #(find findAgain setSearchString
again undo
copySelection cut paste pasteRecent
doIt printIt inspectIt
accept cancel
shiftedYellowButtonActivity)]

	ifTrue: [shiftMenu _ ParagraphEditor shiftedYellowButtonMenu.
		aMenu 
			labels: shiftMenu labelString 
			lines: shiftMenu lineArray
			selections: shiftMenu selections]! !

!SwikiBrowser methodsFor: 'contents' stamp: 'xw 5/14/2022 11:55'!
shelfContents: input notifying: aController
	| inputString inputCode |
	inputString _ input asString.
	self function caseOf:
		{['addresses (shelf)']->["Shelf Address"
			Parser new parse: (ReadStream on: inputString) class: SwikiShelfContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			shelf shelfAddresses at: self element put: inputCode.
			shelf storage shelfFunction: 'addresses' type: 'shelf' name: self element content: inputString.
			contents _ inputString.
			^true].
		['addresses (priv)']->["Private Address"
			Parser new parse: (ReadStream on: inputString) class: SwikiShelfContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			shelf privAddresses at: self element put: inputCode.
			shelf storage shelfFunction: 'addresses' type: 'priv' name: self element content: inputString.
			contents _ inputString.
			^true].
		['templates (shelf)']->["Shelf Template"
			shelf shelfTemplates at: self element put: (TextFormatter crToCrlf: inputString).
			shelf storage shelfFunction: 'templates' type: 'shelf' name: self element content: inputString.
			contents _ inputString.
			^true].
		['templates (book)']->["Book Template"
			shelf bookTemplates at: self element put: (TextFormatter crToCrlf: inputString).
			shelf storage shelfFunction: 'templates' type: 'book' name: self element content: inputString.
			contents _ inputString.
			^true].
		['actions (shelf)']->["Shelf Action"
			Parser new parse: (ReadStream on: inputString) class: SwikiShelfContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			shelf shelfActions at: self element put: inputCode.
			shelf storage shelfFunction: 'actions' type: 'shelf' name: self element content: inputString.
			contents _ inputString.
			^true].
		['actions (book)']->["Book Action"
			Parser new parse: (ReadStream on: inputString) class: SwikiBookContext noPattern: true notifying: aController ifFail: [^false].
			inputString _ aController text asString.
			inputCode _ Compiler evaluate: ('[:request :response :shelf :book |', inputString, ']') notifying: aController logged: false.
			inputCode ifNil: [^false].
			shelf bookActions at: self element put: inputCode.
			shelf storage shelfFunction: 'actions' type: 'book' name: self element content: inputString.
			contents _ inputString.
			^true].
		['settings']->["Settings"
			inputCode _ Compiler evaluate: inputString notifying: aController logged: false.
			inputCode ifNil: [^false].
			shelf settingsAt: self element put: inputCode.
			shelf writeSettings.
			contents _ aController text asString.
			^true]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list menu'!
bookATAElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new element"
	labels add: ('new ', self ataSingle, '...').
	selections add: #newBookATAElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Move element"
		labels add: 'move to...'.
		selections add: #moveBookATAElement.
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameBookATAElement.
		"Rename element"
		labels add: 'remove'.
		selections add: #removeBookATAElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'element list menu'!
bookActionElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Senders of"
	labels add: 'senders of'.
	selections add: #sendersBookAction.
	lines add: (labels size).
	"Add a new element"
	labels add: ('new ', self ataSingle, '...').
	selections add: #newBookATAElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Move element"
		labels add: 'move to...'.
		selections add: #moveBookATAElement.
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameBookATAElement.
		"Remove element"
		labels add: 'remove'.
		selections add: #removeBookATAElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'element list menu'!
bookElementListMenu: aMenu
	self function caseOf:
		{['addresses (book)']->["Book Address"
			^self bookATAElementListMenu: aMenu].
		['addresses (page)']->["Page Address"
			^self bookATAElementListMenu: aMenu].
		['addresses (priv)']->["Private Address"
			^self bookATAElementListMenu: aMenu].
		['templates (book)']->["Book Template"
			^self bookATAElementListMenu: aMenu].
		['templates (page)']->["Page Template"
			^self bookATAElementListMenu: aMenu].
		['actions (book)']->["Book Action"
			^self bookActionElementListMenu: aMenu].
		['actions (page)']->["Page Action"
			^self bookActionElementListMenu: aMenu].
		['settings']->["Settings"
			^self bookSettingsElementListMenu: aMenu].
		['setup']->["Setup"
			^self bookSetupElementListMenu: aMenu].
		[nil]->["No Function"
			^nil]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list menu'!
bookSettingsElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new element"
	labels add: ('new setting...').
	selections add: #newBookSettingElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameBookSettingElement.
		"Remove element"
		labels add: 'remove'.
		selections add: #removeBookSettingElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'element list menu'!
bookSetupElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new element"
	labels add: ('new setup...').
	selections add: #newBookSetupElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameBookSetupElement.
		"Remove element"
		labels add: 'remove'.
		selections add: #removeBookSetupElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'element list menu'!
elementListMenu: aMenu
	self isSelectingABook ifTrue: [^self bookElementListMenu: aMenu].
	self isSelectingAShelf ifTrue: [^self shelfElementListMenu: aMenu].
	^nil! !

!SwikiBrowser methodsFor: 'element list menu'!
moveBookATAElement
	| categories lines select category |
	categories _ categoryList copy.
	lines _ OrderedCollection new.
	categories remove: '-- all --'.
	(categories includes: 'as yet unclassified') ifTrue: [
		categories remove: 'as yet unclassified'].
	(self category = 'as yet unclassified') ifFalse: [
		(self category = '-- all --') ifFalse: [
			categories remove: self category]].
	lines add: categories size.
	categories add: 'as yet unclassified'.
	select _ (PopUpMenu labelArray: categories lines: lines)
				startUpWithCaption: 'move to category'.
	(select = 0) ifTrue: [^self].
	select _ categories at: select.
	(select = 'as yet unclassified')
		ifTrue: [self book storage moveBookFunction: self ata type: self type name: self element]
		ifFalse: [self book storage moveBookFunction: self ata type: self type name: self element toCategory: select].
	category _ self category.
	self updateCategoryList.
	self categoryListIndex: (categoryList indexOf: category)! !

!SwikiBrowser methodsFor: 'element list menu'!
moveShelfATAElement
	| categories lines select category |
	categories _ categoryList copy.
	lines _ OrderedCollection new.
	categories remove: '-- all --'.
	(categories includes: 'as yet unclassified') ifTrue: [
		categories remove: 'as yet unclassified'].
	(self category = 'as yet unclassified') ifFalse: [
		(self category = '-- all --') ifFalse: [
			categories remove: self category]].
	lines add: categories size.
	categories add: 'as yet unclassified'.
	select _ (PopUpMenu labelArray: categories lines: lines)
				startUpWithCaption: 'move to category'.
	(select = 0) ifTrue: [^self].
	select _ categories at: select.
	(select = 'as yet unclassified')
		ifTrue: [shelf storage moveShelfFunction: self ata type: self type name: self element]
		ifFalse: [shelf storage moveShelfFunction: self ata type: self type name: self element toCategory: select].
	category _ self category.
	self updateCategoryList.
	self categoryListIndex: (categoryList indexOf: category)! !

!SwikiBrowser methodsFor: 'element list menu'!
newBookATAElement
	| response book inACategory |
	(response _ FillInTheBlank request: ('Please name new ', self ataSingle) initialAnswer: '') isEmpty ifTrue: [^self].
	book _ self book.
	inACategory _ self category caseOf: {
		['as yet unclassified']->[false].
		['-- all --']->[false]}
		otherwise: [true].
	"Add to book function"
	self function caseOf: {
		['addresses (book)']->[(book bookAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book bookAddresses at: response put: (Compiler evaluate: '[:request :response :shelf :book |]')]].
		['addresses (page)']->[(book pageAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book pageAddresses at: response put: (Compiler evaluate: '[:request :response :shelf :book :page |]')]].
		['addresses (priv)']->[(book privAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book privAddresses at: response put: (Compiler evaluate: '[:request :response :shelf :book |]')]].
		['templates (book)']->[(book bookTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book bookTemplates at: response put: '']].
		['templates (page)']->[(book pageTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book pageTemplates at: response put: '']].
		['actions (book)']->[(book bookActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book bookActions at: response put: (Compiler evaluate: '[:request :response :shelf :book |]')]].
		['actions (page)']->[(book pageActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book pageActions at: response put: (Compiler evaluate: '[:request :response :shelf :book :page |]')]]}
		otherwise: [self error: (self function, ' is not a valid function.')].
	"Add to storage"
	inACategory
		ifTrue: [book storage addBookFunction: self ata type: self type name: response category: self category]
		ifFalse: [book storage addBookFunction: self ata type: self type name: response].
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
newBookSettingElement
	| response book |
	(response _ FillInTheBlank request: ('Please name new setting') initialAnswer: '') isEmpty ifTrue: [^self].
	book _ self book.
	(book rawSettingsIncludes: response) ifTrue: [
		^PopUpMenu notify: 'That name is already taken'].
	book settingsAt: response put: ''.
	book writeSettings.
	"Update List"
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
newBookSetupElement
	| response book |
	(response _ FillInTheBlank request: ('Please name new setup') initialAnswer: '') isEmpty ifTrue: [^self].
	book _ self book.
	(book setup includesKey: response) ifTrue: [
		^PopUpMenu notify: 'That name is already taken'].
	book setup at: response put: ''.
	shelf storage writeSetupForBook: book.
	"Update List"
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
newShelfATAElement
	| response inACategory |
	(response _ FillInTheBlank request: ('Please name new ', self ataSingle) initialAnswer: '') isEmpty ifTrue: [^self].
	inACategory _ self category caseOf: {
		['as yet unclassified']->[false].
		['-- all --']->[false]}
		otherwise: [true].
	"Add to shelf function"
	self function caseOf: {
		['addresses (shelf)']->[(shelf shelfAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf shelfAddresses at: response put: (Compiler evaluate: '[:request :response :shelf |]')]].
		['addresses (priv)']->[(shelf privAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf privAddresses at: response put: (Compiler evaluate: '[:request :response :shelf |]')]].
		['templates (shelf)']->[(shelf shelfTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf shelfTemplates at: response put: '']].
		['templates (book)']->[(shelf bookTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf bookTemplates at: response put: '']].
		['actions (shelf)']->[(shelf shelfActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf shelfActions at: response put: (Compiler evaluate: '[:request :response :shelf |]')]].
		['actions (book)']->[(shelf bookActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf bookActions at: response put: (Compiler evaluate: '[:request :response :shelf :book |]')]]}
		otherwise: [self error: (self function, ' is not a valid function.')].
	"Add to storage"
	inACategory
		ifTrue: [shelf storage addShelfFunction: self ata type: self type name: response category: self category]
		ifFalse: [shelf storage addShelfFunction: self ata type: self type name: response].
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
newShelfSettingElement
	| response |
	(response _ FillInTheBlank request: ('Please name new setting') initialAnswer: '') isEmpty ifTrue: [^self].
	(shelf settingsIncludes: response) ifTrue: [
		^PopUpMenu notify: 'That name is already taken'].
	shelf settingsAt: response put: ''.
	shelf writeSettings.
	"Update List"
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
removeBookATAElement
	| book element |
	book _ self book.
	element _ self element.
	self function caseOf: {
		['addresses (book)']->["Remove book address"
			book bookAddresses removeKey: element.
			book storage deleteBookFunction: 'addresses' type: 'book' name: element].
		['addresses (page)']->["Remove page address"
			book pageAddresses removeKey: element.
			book storage deleteBookFunction: 'addresses' type: 'page' name: element].
		['addresses (priv)']->["Remove priv address"
			book privAddresses removeKey: element.
			book storage deleteBookFunction: 'addresses' type: 'priv' name: element].
		['templates (book)']->["Remove book template"
			book bookTemplates removeKey: element.
			book storage deleteBookFunction: 'templates' type: 'book' name: element].
		['templates (page)']->["Remove page template"
			book pageTemplates removeKey: element.
			book storage deleteBookFunction: 'templates' type: 'page' name: element].
		['actions (book)']->["Remove book action"
			book bookActions removeKey: element.
			book storage deleteBookFunction: 'actions' type: 'book' name: element].
		['actions (page)']->["Remove page action"
			book pageActions removeKey: element.
			book storage deleteBookFunction: 'actions' type: 'page' name: element]}
		otherwise: [self error: (self function, ' is not a valid function.')].
	"Update element list"
	self updateElementList.
	self elementListIndex: 0! !

!SwikiBrowser methodsFor: 'element list menu'!
removeBookSettingElement
	(self book)
		rawSettingsRemove: (self element);
		writeSettings.
	"Update element list"
	self updateElementList.
	self elementListIndex: 0! !

!SwikiBrowser methodsFor: 'element list menu'!
removeBookSetupElement
	| book |
	book _ self book.
	book setup removeKey: self element.
	shelf storage writeSetupForBook: book.
	"Update element list"
	self updateElementList.
	self elementListIndex: 0! !

!SwikiBrowser methodsFor: 'element list menu'!
removeShelfATAElement
	| element |
	element _ self element.
	self function caseOf: {
		['addresses (shelf)']->["Remove shelf address"
			shelf shelfAddresses removeKey: element.
			shelf storage deleteShelfFunction: 'addresses' type: 'shelf' name: element].
		['addresses (priv)']->["Remove priv address"
			shelf privAddresses removeKey: element.
			shelf storage deleteShelfFunction: 'addresses' type: 'priv' name: element].
		['templates (shelf)']->["Remove shelf template"
			shelf shelfTemplates removeKey: element.
			shelf storage deleteShelfFunction: 'templates' type: 'shelf' name: element].
		['templates (book)']->["Remove book template"
			shelf bookTemplates removeKey: element.
			shelf storage deleteShelfFunction: 'templates' type: 'book' name: element].
		['actions (shelf)']->["Remove shelf action"
			shelf shelfActions removeKey: element.
			shelf storage deleteShelfFunction: 'actions' type: 'shelf' name: element].
		['actions (book)']->["Remove book action"
			shelf bookActions removeKey: element.
			shelf storage deleteShelfFunction: 'actions' type: 'book' name: element]}
		otherwise: [self error: (self function, ' is not a valid function.')].
	"Update element list"
	self updateElementList.
	self elementListIndex: 0! !

!SwikiBrowser methodsFor: 'element list menu'!
removeShelfSettingElement
	shelf
		settingsRemove: (self element);
		writeSettings.
	"Update element list"
	self updateElementList.
	self elementListIndex: 0! !

!SwikiBrowser methodsFor: 'element list menu'!
renameBookATAElement
	| response element book |
	(response _ FillInTheBlank request: ('Please name new ', self ataSingle) initialAnswer: self element) isEmpty ifTrue: [^self].
	element _ self element.
	(response = element) ifTrue: [^self].
	book _ self book.
	self function caseOf: {
		['addresses (book)']->[(book bookAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book bookAddresses at: response put: (book bookAddresses removeKey: element)]].
		['addresses (page)']->[(book pageAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book pageAddresses at: response put: (book pageAddresses removeKey: element)]].
		['addresses (priv)']->[(book privAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book privAddresses at: response put: (book privAddresses removeKey: element)]].
		['templates (book)']->[(book bookTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book bookTemplates at: response put: (book bookTemplates removeKey: element)]].
		['templates (page)']->[(book pageTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book pageTemplates at: response put: (book pageTemplates removeKey: element)]].
		['actions (book)']->[(book bookActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book bookActions at: response put: (book bookActions removeKey: element)]].
		['actions (page)']->[(book pageActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [book pageActions at: response put: (book pageActions removeKey: element)]]}
		otherwise: [self error: (self function, ' is not a valid function.')].
	"move in storage"
	book storage renameBookFunction: self ata type: self type name: element to: response.
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
renameBookSettingElement
	| response element book |
	element _ self element.	
	(response _ FillInTheBlank request: ('Please name new setting') initialAnswer: element) isEmpty ifTrue: [^self].
	(response = element) ifTrue: [^self].
	book _ self book.
	(book rawSettingsIncludes: response) ifTrue: [
		^PopUpMenu notify: 'That name is already taken'].
	book settingsAt: response put: (book settingsAt: element).
	book rawSettingsRemove: element.
	book writeSettings.
	"Update element list"
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
renameBookSetupElement
	| response element book |
	element _ self element.	
	(response _ FillInTheBlank request: ('Please name new setup') initialAnswer: element) isEmpty ifTrue: [^self].
	(response = element) ifTrue: [^self].
	book _ self book.
	(book setup includesKey: response) ifTrue: [
		^PopUpMenu notify: 'That name is already taken'].
	book setup
		at: response put: (book setup at: element);
		removeKey: element.
	shelf storage writeSetupForBook: book.
	"Update element list"
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
renameShelfATAElement
	| response element |
	(response _ FillInTheBlank request: ('Please name new ', self ataSingle) initialAnswer: self element) isEmpty ifTrue: [^self].
	element _ self element.
	(response = element) ifTrue: [^self].
	self function caseOf: {
		['addresses (shelf)']->[(shelf shelfAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf shelfAddresses at: response put: (shelf shelfAddresses removeKey: element)]].
		['addresses (priv)']->[(shelf privAddresses includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf privAddresses at: response put: (shelf privAddresses removeKey: element)]].
		['templates (shelf)']->[(shelf shelfTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf shelfTemplates at: response put: (shelf shelfTemplates removeKey: element)]].
		['templates (book)']->[(shelf bookTemplates includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf bookTemplates at: response put: (shelf bookTemplates removeKey: element)]].
		['actions (shelf)']->[(shelf shelfActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf shelfActions at: response put: (shelf shelfActions removeKey: element)]].
		['actions (book)']->[(shelf bookActions includesKey: response)
			ifTrue: [^PopUpMenu notify: 'That name is already taken']
			ifFalse: [shelf bookActions at: response put: (shelf bookActions removeKey: element)]]}
		otherwise: [self error: (self function, ' is not a valid function.')].
	"move in storage"
	shelf storage renameShelfFunction: self ata type: self type name: element to: response.
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
renameShelfSettingElement
	| response element |
	element _ self element.	
	(response _ FillInTheBlank request: ('Please name new setting') initialAnswer: element) isEmpty ifTrue: [^self].
	(response = element) ifTrue: [^self].
	(shelf settingsIncludes: response) ifTrue: [
		^PopUpMenu notify: 'That name is already taken'].
	shelf settingsAt: response put: (shelf settingsAt: element).
	shelf settingsRemove: element.
	shelf writeSettings.
	"Update element list"
	self updateElementList.
	self elementListIndex: (elementList indexOf: response)! !

!SwikiBrowser methodsFor: 'element list menu'!
sendersBookAction
	| myBook books action result return |
	action _ '<?', self element, '?>'.
	myBook _ self book.
	books _ myBook allChildren.
	books add: myBook.
	[myBook hasParent] whileTrue: [
		myBook _ myBook parent.
		books add: myBook].
	result _ OrderedCollection new.
	(self function = 'actions (book)') ifTrue: [
		books do: [:book | book bookTemplates keysAndValuesDo: [:key :template |
			((template findString: action) = 0) ifFalse: [
				result add: (Array with: book with: 'book' with: key)]]]].
	books do: [:book | book pageTemplates keysAndValuesDo: [:key :template |
		((template findString: action) = 0) ifFalse: [
			result add: (Array with: book with: 'page' with: key)]]].
	return _ WriteStream on: String new.
	return
		nextPutAll: (result size asString);
		nextPutAll: ' MATCHES'.
	result do: [:arr | return
		nextPut: Character cr;
		nextPutAll: (arr at: 1) name;
		nextPutAll: ': ';
		nextPutAll: (arr at: 2);
		nextPutAll: ' template named ';
		nextPutAll: (arr at: 3)].
	(Workspace new)
		openLabel: ('Senders of ', action);
		contents: return contents;
		contentsChanged
		! !

!SwikiBrowser methodsFor: 'element list menu'!
sendersShelfAction
	| action result return |
	action _ '<?', self element, '?>'.
	result _ OrderedCollection new.
	(self function = 'actions (shelf)') ifTrue: [
		shelf shelfTemplates keysAndValuesDo: [:key :template |
			((template findString: action) = 0) ifFalse: [
				result add: (Array with: 'shelf' with: key)]]].
	shelf bookTemplates keysAndValuesDo: [:key :template |
		((template findString: action) = 0) ifFalse: [
			result add: (Array with: 'book' with: key)]].
	return _ WriteStream on: String new.
	return
		nextPutAll: (result size asString);
		nextPutAll: ' MATCHES'.
	result do: [:arr | return
		nextPut: Character cr;
		nextPutAll: (arr at: 1);
		nextPutAll: ' template named ';
		nextPutAll: (arr at: 2)].
	(Workspace new)
		openLabel: ('Senders of ', action);
		contents: return contents;
		contentsChanged
		! !

!SwikiBrowser methodsFor: 'element list menu'!
shelfATAElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new element"
	labels add: ('new ', self ataSingle, '...').
	selections add: #newShelfATAElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Move element"
		labels add: 'move to...'.
		selections add: #moveShelfATAElement.
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameShelfATAElement.
		"Rename element"
		labels add: 'remove'.
		selections add: #removeShelfATAElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'element list menu'!
shelfActionElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Senders of"
	labels add: 'senders of'.
	selections add: #sendersShelfAction.
	lines add: (labels size).
	"Add a new element"
	labels add: ('new ', self ataSingle, '...').
	selections add: #newShelfATAElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Move element"
		labels add: 'move to...'.
		selections add: #moveShelfATAElement.
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameShelfATAElement.
		"Rename element"
		labels add: 'remove'.
		selections add: #removeShelfATAElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'element list menu'!
shelfElementListMenu: aMenu
	self function caseOf:
		{['addresses (shelf)']->["Shelf Address"
			^self shelfATAElementListMenu: aMenu].
		['addresses (priv)']->["Private Address"
			^self shelfATAElementListMenu: aMenu].
		['templates (shelf)']->["Shelf Template"
			^self shelfATAElementListMenu: aMenu].
		['templates (book)']->["Book Template"
			^self shelfATAElementListMenu: aMenu].
		['actions (shelf)']->["Book Action"
			^self shelfActionElementListMenu: aMenu].
		['actions (book)']->["Page Action"
			^self shelfActionElementListMenu: aMenu].
		['settings']->["Settings"
			^self shelfSettingsElementListMenu: aMenu].
		[nil]->["No Function"
			^nil]}
		otherwise: [self error: (self function, ' is not a valid function.')]! !

!SwikiBrowser methodsFor: 'element list menu'!
shelfSettingsElementListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"Add a new element"
	labels add: ('new setting...').
	selections add: #newShelfSettingElement.
	"Selected item"
	(elementListIndex = 0) ifFalse: [
		lines add: (labels size).
		"Rename element"
		labels add: 'rename...'.
		selections add: #renameShelfSettingElement.
		"Remove element"
		labels add: 'remove'.
		selections add: #removeShelfSettingElement].
	^aMenu labels: labels lines: lines selections: selections! !

!SwikiBrowser methodsFor: 'book list menu'!
bookListMenu: aMenu
	| labels lines selections |
	labels _ OrderedCollection new.
	lines _ OrderedCollection new.
	selections _ OrderedCollection new.
	"List as Hierarchy"
	labels add: (booksAsHierarchy
		ifTrue: ['sort alphabetically']
		ifFalse: ['sort as hierarchy']).
	selections add: #toggleBooksAsHierarchy.
	self isSelectingABook ifTrue: [
		"inspect & explore"
		lines add: labels size.
		labels add: 'inspect'.
		selections add: #inspectBook.
		labels add: 'explore'.
		selections add: #exploreBook.
		"reload"
		lines add: labels size.
		labels add: 'reload'.
		selections add: #reloadBook.
		(self book hasChildren) ifFalse: [
			"remove"
			lines add: labels size.
			labels add: 'remove'.
			selections add: #removeBook]].
	self isSelectingAShelf ifTrue: [
		"inspect & explore"
		lines add: labels size.
		labels add: 'inspect'.
		selections add: #inspectShelf.
		labels add: 'explore'.
		selections add: #exploreShelf.
		"reload"
		lines add: labels size.
		labels add: 'reload'.
		selections add: #reloadShelf].
	^aMenu labels: labels lines: lines selections: selections
! !

!SwikiBrowser methodsFor: 'book list menu'!
exploreBook
	self isSelectingABook ifTrue: [self book explore]
! !

!SwikiBrowser methodsFor: 'book list menu'!
exploreShelf
	shelf explore! !

!SwikiBrowser methodsFor: 'book list menu'!
inspectBook
	self isSelectingABook ifTrue: [self book inspect]
! !

!SwikiBrowser methodsFor: 'book list menu'!
inspectShelf
	shelf inspect! !

!SwikiBrowser methodsFor: 'book list menu'!
reloadBook
	| book |
	Cursor execute showWhile: [
		book _ self book.
		book formatPrivAddress: 'stop' request: nil response: nil shelf: shelf.
		book loadFrom: shelf.
		book formatPrivAddress: 'initialize' request: nil response: nil shelf: shelf.
		"Update list"
		bookList _ nil.
		self changed: #bookList.
		2 to: bookList size do: [:i | ((bookList at: i) withBlanksTrimmed = book name)
			ifTrue: [self bookListIndex: i]]]! !

!SwikiBrowser methodsFor: 'book list menu'!
reloadShelf
	Cursor execute showWhile: [
		shelf reload.
		self changed: #bookList.
		self bookListIndex: 1]! !

!SwikiBrowser methodsFor: 'book list menu'!
removeBook
	| book |
	book _ self book.
	shelf books remove: book.
	book formatPrivAddress: 'stop' request: nil response: nil shelf: shelf.
	book hasParent ifTrue: [book parent removeChild: book].
	bookList _ nil.
	self changed: #bookList.
	self bookListIndex: 0.
	PopUpMenu notify: ('It is now safe to (re)move the ', book name, String cr, 'directory to permanently remove that Swiki.')
! !

!SwikiBrowser methodsFor: 'book list menu'!
toggleBooksAsHierarchy
	| bookName |
	booksAsHierarchy _ booksAsHierarchy not.
	(bookListIndex > 1) ifTrue: [
		bookName _ self bookName].
	bookList _ nil.
	self changed: #bookList.
	(bookListIndex < 2) ifTrue: [^self].
	"Select same book"
	2 to: (bookList size) do: [:i |
		(bookName = (bookList at: i) withBlanksTrimmed) ifTrue: [
			^self bookListIndex: i]]! !

!SwikiBrowser methodsFor: 'private'!
defaultBackgroundColor
	^Color r: 0.6 g: 1.0 b: 0.8! !

!SwikiBrowser methodsFor: 'private'!
hierarchyForBook: book indent: indent
	| return |
	return _ OrderedCollection new.
	return add: (indent, book name).
	book hasChildren ifFalse: [^return].
	(book children asSortedCollection: [:a :b | a name asLowercase < b name asLowercase])
		do: [:child | return addAll: (self hierarchyForBook: child indent: (indent, '  '))].
	^return! !

!SwikiBrowser methodsFor: 'private'!
put: aText
	aText asString inspect.
	^true "accepted"! !

!SwikiBrowser methodsFor: 'function list'!
ata
	"addresses, templates, or actions"
	^self function copyUpTo: $ ! !

!SwikiBrowser methodsFor: 'function list'!
ataSingle
	"address, template, or action"
	^self ata caseOf: {
		['addresses']->['address'].
		['templates']->['template'].
		['actions']->['action']}
		otherwise: [self error: 'ataSingle is only valid for addresses, templates, and actions']! !

!SwikiBrowser methodsFor: 'function list'!
function
	(functionListIndex = 0) ifTrue: [^nil].
	functionListIndex ifNil: [^nil].
	^self functionList at: functionListIndex! !

!SwikiBrowser methodsFor: 'function list'!
functionList
	^functionList ifNil: [^OrderedCollection new] ifNotNil: [functionList]! !

!SwikiBrowser methodsFor: 'function list'!
functionListIndex
	^functionListIndex ifNil: [0] ifNotNil: [functionListIndex]! !

!SwikiBrowser methodsFor: 'function list'!
functionListIndex: anInteger
	functionListIndex _ anInteger.
	self changed: #functionListIndex.
	self updateCategoryList! !

!SwikiBrowser methodsFor: 'function list'!
type
	^self function caseOf: {
		['addresses (shelf)']->['shelf'].
		['addresses (book)']->['book'].
		['addresses (page)']->['page'].
		['addresses (priv)']->['priv'].
		['templates (shelf)']->['shelf'].
		['templates (book)']->['book'].
		['templates (page)']->['page'].
		['actions (shelf)']->['shelf'].
		['actions (book)']->['book'].
		['actions (page)']->['page']}
		otherwise: ['']

! !

!SwikiBrowser methodsFor: 'function list'!
updateFunctionList
	functionList _ self bookListIndex caseOf:
		{[0]->[OrderedCollection new].
		[1]->["Shelf Functions"
			#('addresses (shelf)'
			'addresses (priv)'
			'templates (shelf)'
			'templates (book)'
			'actions (shelf)'
			'actions (book)'
			'settings')]}
		otherwise: ["Book Functions"
			#('addresses (book)'
			'addresses (page)'
			'addresses (priv)'
			'templates (book)'
			'templates (page)'
			'actions (book)'
			'actions (page)'
			'settings'
			'setup')].
	functionListIndex _ 0.
	self changed: #functionList.
	self updateCategoryList! !


!SwikiBrowser class methodsFor: 'instance creation'!
asMVCOnShelf: aSwikiShelf
	^self asMVCOnShelf: aSwikiShelf label: 'Swiki Browser'! !

!SwikiBrowser class methodsFor: 'instance creation'!
asMVCOnShelf: aSwikiShelf label: label 
	| aSwikiBrowser topView bookListView categoryListView functionListView elementListView contentsArea topViewSize subViewSize backgroundColor |
	backgroundColor := Color paleBlue.
	topViewSize := 0 @ 0 extent: 800 @ 600.
	subViewSize := 0 @ 0 extent: topViewSize width / 4 @ (topViewSize height / 3).

	aSwikiBrowser := self new shelf: aSwikiShelf.
	topView := (StandardSystemView new label: label)
				model: aSwikiShelf.
	topView window: topViewSize.
	topView backgroundColor: backgroundColor.

	"book list"
	bookListView := PluggableListView
				on: aSwikiBrowser
				list: #bookList
				selected: #bookListIndex
				changeSelected: #bookListIndex:
				menu: #bookListMenu:.
	bookListView window: subViewSize.
	topView addSubView: bookListView.

	"function list"
	functionListView := PluggableListView
				on: aSwikiBrowser
				list: #functionList
				selected: #functionListIndex
				changeSelected: #functionListIndex:
				menu: nil.
	functionListView window: subViewSize.
	topView addSubView: functionListView toRightOf: bookListView.

	"category list"
	categoryListView := PluggableListView
				on: aSwikiBrowser
				list: #categoryList
				selected: #categoryListIndex
				changeSelected: #categoryListIndex:
				menu: #categoryListMenu:.
	categoryListView window: subViewSize.
	topView addSubView: categoryListView toRightOf: functionListView.

	"element list"
	elementListView := PluggableListView
				on: aSwikiBrowser
				list: #elementList
				selected: #elementListIndex
				changeSelected: #elementListIndex:
				menu: #elementListMenu:.
	elementListView window: subViewSize.
	topView addSubView: elementListView toRightOf: categoryListView.

	"content area"
	contentsArea := PluggableTextView
				on: aSwikiBrowser
				text: #contents
				accept: #contents:notifying:
				readSelection: #contentsSelection
				menu: #contentsMenu:shifted:.
	topView addSubView: contentsArea below: bookListView.

	topView controller open! !

!SwikiBrowser class methodsFor: 'instance creation'!
asMorphOnShelf: aSwikiShelf
	^self asMorphOnShelf: aSwikiShelf label: 'Swiki Browser'! !

!SwikiBrowser class methodsFor: 'instance creation'!
asMorphOnShelf: aSwikiShelf label: label
	| aSwikiBrowser window |
	aSwikiBrowser _ self new shelf: aSwikiShelf.
	window _ (SystemWindow labelled: label) model: aSwikiBrowser.
	"book list"
	window addMorph: (PluggableListMorph on: aSwikiBrowser list: #bookList selected: #bookListIndex changeSelected: #bookListIndex: menu: #bookListMenu:) frame: (0@0 corner: 0.25@0.3).
	"function list"
	window addMorph: (PluggableListMorph on: aSwikiBrowser list: #functionList selected: #functionListIndex changeSelected: #functionListIndex: menu: nil) frame: (0.25@0 corner: 0.5@0.3).
	"category list"
	window addMorph: (PluggableListMorph on: aSwikiBrowser list: #categoryList selected: #categoryListIndex changeSelected: #categoryListIndex: menu: #categoryListMenu:) frame: (0.5@0 corner: 0.75@0.3).
	"element list"
	window addMorph: (PluggableListMorph on: aSwikiBrowser list: #elementList selected: #elementListIndex changeSelected: #elementListIndex: menu: #elementListMenu:) frame: (0.75@0 corner: 1@0.3).
	"content area"
	window addMorph: (PluggableTextMorph on: aSwikiBrowser text: #contents accept: #contents:notifying: readSelection: #contentsSelection menu: #contentsMenu:shifted:) frame: (0@0.3 corner: 1@1).
	^window! !


!SwikiColorScheme methodsFor: 'accessing'!
directory
	^directory! !

!SwikiColorScheme methodsFor: 'accessing'!
directory: aSwikiDirectory
	directory _ aSwikiDirectory! !

!SwikiColorScheme methodsFor: 'accessing'!
fileServer
	^fileServer! !

!SwikiColorScheme methodsFor: 'accessing'!
fileServer: fs
	fileServer _ fs! !

!SwikiColorScheme methodsFor: 'initialization'!
initialize
	self initializeTemplates.
	self initializeEndings.
	self initializeAltTags! !

!SwikiColorScheme methodsFor: 'initialization'!
initializeAltTags
	| file pos1 pos2 |
	altTags _ Dictionary new.
	(file _ directory fileRefsCacheAt: 'tags.xml' ifAbsent: [nil]) ifNotNil: [
		(directory readOnlyFile: file last) contentsOfEntireFile linesDo: [:line |
			(line beginsWith: '<button name="') ifTrue: [
				pos1 _ line findString: '" alt="' startingAt: 15.
				pos2 _ line findString: '" />' startingAt: (pos1 + 7).
				altTags
					at: (line copyFrom: 15 to: (pos1 - 1))
					put: (line copyFrom: (pos1 + 7) to: (pos2 - 1))]]]! !

!SwikiColorScheme methodsFor: 'initialization'!
initializeEndings
	"default ending is .gif"
	buttonEnding _ (directory fileRefsExists: 'top.gif')
		ifTrue: ['.gif']
		ifFalse: [(directory fileRefsExists: 'top.png')
			ifTrue: ['.png']
			ifFalse: [(directory fileRefsExists: 'top.jpg')
				ifTrue: ['.jpg']
				ifFalse: ['.gif']]].
	activeButton _ directory fileRefsExists: ('topact', buttonEnding).
	emoteEnding _ (directory fileRefsExists: 'happy.gif')
		ifTrue: ['.gif']
		ifFalse: [(directory fileRefsExists: 'happy.png')
			ifTrue: ['.png']
			ifFalse: [(directory fileRefsExists: 'happy.jpg')
				ifTrue: ['.jpg']
				ifFalse: ['.gif']]].
	mimeEnding _ (directory fileRefsExists: 'folder.gif')
		ifTrue: ['.gif']
		ifFalse: [(directory fileRefsExists: 'folder.png')
			ifTrue: ['.png']
			ifFalse: [(directory fileRefsExists: 'folder.jpg')
				ifTrue: ['.jpg']
				ifFalse: ['.gif']]]! !

!SwikiColorScheme methodsFor: 'initialization'!
initializeTemplates
	| name template |
	templates _ Dictionary new.
	directory filesAlphabetically do: [:versions |
		name _ versions name.
		(name endsWith: '.sm') ifTrue: ["Swiki Markup"
			name _ name copyUpToLast: $..
			template _ (directory readOnlyFile: versions last) contentsOfEntireFile.
			template _ TextFormatter crToCrlf: template.
			templates at: name put: template]]! !

!SwikiColorScheme methodsFor: 'templates'!
formatTemplate: templateName request: request response: response shelf: shelf
	^(ShelfTemplateFormatter swikiFormatter) format: (templates at: templateName ifAbsent: [^'']) request: request response: response shelf: shelf! !

!SwikiColorScheme methodsFor: 'templates'!
formatTemplate: templateName request: request response: response shelf: shelf book: book
	^(BookTemplateFormatter swikiFormatter) format: (templates at: templateName ifAbsent: [^'']) request: request response: response shelf: shelf book: book! !

!SwikiColorScheme methodsFor: 'templates'!
formatTemplate: templateName request: request response: response shelf: shelf book: book page: page
	^(BookTemplateFormatter swikiFormatter) format: (templates at: templateName ifAbsent: [^'']) request: request response: response shelf: shelf book: book page: page! !

!SwikiColorScheme methodsFor: 'buttons'!
altFor: button ifAbsent: block
	^altTags at: button ifAbsent: block! !

!SwikiColorScheme methodsFor: 'buttons'!
button: button
	^self button: button alt: (self altFor: button ifAbsent: ['Missing Alternate Tag'])! !

!SwikiColorScheme methodsFor: 'buttons'!
button: button alt: altText
	^directory referenceFileNamed: (button, buttonEnding)
		fs: fileServer
		options: (Dictionary new
			at: 'border' put: 0;
			at: 'alt' put: altText;
			yourself)! !

!SwikiColorScheme methodsFor: 'buttons'!
button: button link: link
	^self button: button link: link alt: (self altFor: button ifAbsent: ['Missing Alternate Tag'])! !

!SwikiColorScheme methodsFor: 'buttons'!
button: button link: link alt: altText
	| imgref |
	activeButton
		ifTrue: ["With rollovers"
			imgref _ directory referenceFileNamed: (button, buttonEnding)
				fs: fileServer
				options: (Dictionary new
					at: 'border' put: 0;
					at: 'alt' put: altText;
					at: 'name' put: button;
					yourself).
			^String streamContents: [:stream | stream
				nextPutAll: '<a href="';
				nextPutAll: link;
				nextPutAll: '" title="';
				nextPutAll: altText;
				nextPutAll: '" onMouseOver="rollOver(''', button, ''', true)" onMouseOut="rollOver(''', button, ''', false)">';
				nextPutAll: imgref;
				nextPutAll: '</a>']]
		ifFalse: ["Without rollovers"
			imgref _ directory referenceFileNamed: (button, buttonEnding)
				fs: fileServer
				options: (Dictionary new
					at: 'border' put: 0;
					at: 'alt' put: altText;
					yourself).
			^String streamContents: [:stream | stream
				nextPutAll: '<a href="';
				nextPutAll: link;
				nextPutAll: '" title="';
				nextPutAll: altText;
				nextPutAll: '">';
				nextPutAll: imgref;
				nextPutAll: '</a>']]! !

!SwikiColorScheme methodsFor: 'buttons'!
button: button title: title
	^directory referenceFileNamed: (button, buttonEnding)
		fs: fileServer
		options: (Dictionary new
			at: 'border' put: 0;
			at: 'alt' put: title;
			at: 'title' put: title;
			yourself)! !

!SwikiColorScheme methodsFor: 'buttons'!
emote: emote
	^directory referenceFileNamed: (emote, emoteEnding)
		fs: fileServer
		options: (Dictionary new
			at: 'border' put: 0;
			at: 'alt' put: (self altFor: emote ifAbsent: ['Missing Alternate Tag']);
			yourself)! !

!SwikiColorScheme methodsFor: 'buttons'!
mime: mime alt: altTag
	^directory referenceFileNamed: (mime, mimeEnding)
		fs: fileServer
		options: (Dictionary new
			at: 'border' put: 0;
			at: 'alt' put: altTag;
			yourself)! !


!SwikiColorScheme class methodsFor: 'instance creation'!
on: aSwikiDirectory fileServer: fs
	| instance |
	instance _ self basicNew.
	instance
		directory: aSwikiDirectory;
		fileServer: fs;
		initialize.
	^instance! !


!SwikiEntry methodsFor: 'accessing'!
creationDate
	^Date fromSeconds: creationTime! !

!SwikiEntry methodsFor: 'accessing'!
creationTime
	^Time fromSeconds: (creationTime \\ 86400)! !

!SwikiEntry methodsFor: 'accessing'!
creationTimeInSeconds
	^creationTime! !

!SwikiEntry methodsFor: 'accessing'!
httpName
	^name encodeForHTTP! !

!SwikiEntry methodsFor: 'accessing'!
modificationDate
	^Date fromSeconds: modificationTime! !

!SwikiEntry methodsFor: 'accessing'!
modificationDateString
	^NuSwikiPage printDate: self modificationDate! !

!SwikiEntry methodsFor: 'accessing'!
modificationTime
	^Time fromSeconds: (modificationTime \\ 86400)! !

!SwikiEntry methodsFor: 'accessing'!
modificationTimeString
	^NuSwikiPage printTime: self modificationTime! !

!SwikiEntry methodsFor: 'accessing'!
name
	^name! !

!SwikiEntry methodsFor: 'accessing'!
rawCreationTime
	^creationTime! !

!SwikiEntry methodsFor: 'accessing'!
rawModificationTime
	^modificationTime! !

!SwikiEntry methodsFor: 'accessing'!
strictXmlName
	^TextFormatter encodeToStrictXmlCrlf: name! !

!SwikiEntry methodsFor: 'accessing'!
xmlName
	^TextFormatter encodeToXmlCrlf: name! !

!SwikiEntry methodsFor: 'testing'!
isAnImage
	^false! !

!SwikiEntry methodsFor: 'testing'!
isOlderThan: anotherEntry
	^self creationTimeInSeconds <= anotherEntry creationTimeInSeconds! !

!SwikiEntry methodsFor: 'testing'!
isValid
	^true! !

!SwikiEntry methodsFor: 'initialization' stamp: 'xw 5/11/2022 21:58'!
fromDirectoryEntry: entry
	name := entry name.
	creationTime := entry creationTime.
	modificationTime := entry modificationTime.! !


!SwikiDirectory methodsFor: 'accessing'!
backgroundImage
	| files item |
	files _ OrderedCollection new.
	#('background.gif' 'background.jpg' 'background.jpeg' 'background.png') do: [:i |
		(item _ self fileVersionsAt: i) ifNotNil: [
			item _ item last.
			item isAnImage ifTrue: [
				files add: item]]].
	files isEmpty ifTrue: [^nil].
	(files size = 1) ifTrue: [files at: 1].
	"Sort by Age"
	files _ files asSortedCollection: [:a :b | (a rawCreationTime) > (b rawCreationTime)].
	^files first! !

!SwikiDirectory methodsFor: 'accessing'!
bannerImage
	| files item |
	files _ OrderedCollection new.
	#('banner.gif' 'banner.jpg' 'banner.jpeg' 'banner.png') do: [:i |
		(item _ self fileVersionsAt: i) ifNotNil: [
			item _ item last.
			item isAnImage ifTrue: [
				files add: item]]].
	files isEmpty ifTrue: [^nil].
	(files size = 1) ifTrue: [^files at: 1].
	"Sort by Age"
	files _ files asSortedCollection: [:a :b | (a rawCreationTime) > (b rawCreationTime)].
	^files first! !

!SwikiDirectory methodsFor: 'accessing'!
bannerLeftImage
	| files item |
	files _ OrderedCollection new.
	#('bannerLeft.gif' 'bannerLeft.jpg' 'bannerLeft.jpeg' 'bannerLeft.png') do: [:i |
		(item _ self fileVersionsAt: i) ifNotNil: [
			item isAnImage ifTrue: [
				files add: item]]].
	files isEmpty ifTrue: [^nil].
	(files size = 1) ifTrue: [^files at: 1].
	"Sort by Age"
	files _ files asSortedCollection: [:a :b | (a last rawCreationTime) > (b last rawCreationTime)].
	^files first! !

!SwikiDirectory methodsFor: 'accessing'!
bannerRightImage
	| files item |
	files _ OrderedCollection new.
	#('bannerRight.gif' 'bannerRight.jpg' 'bannerRight.jpeg' 'bannerRight.png') do: [:i |
		(item _ self fileVersionsAt: i) ifNotNil: [
			item isAnImage ifTrue: [
				files add: item]]].
	files isEmpty ifTrue: [^nil].
	(files size = 1) ifTrue: [^files at: 1].
	"Sort by Age"
	files _ files asSortedCollection: [:a :b | (a last rawCreationTime) > (b last rawCreationTime)].
	^files first! !

!SwikiDirectory methodsFor: 'accessing'!
dir
	^dir! !

!SwikiDirectory methodsFor: 'accessing'!
dir: aFileDirectory
	dir _ aFileDirectory! !

!SwikiDirectory methodsFor: 'accessing'!
directoriesAlphabetically
	^dirRefsCache values asSortedCollection: [:a :b | (a name asLowercase) < (b name asLowercase)]! !

!SwikiDirectory methodsFor: 'accessing'!
fileSize
	| return |
	return _ 0.
	dirServeCache valuesDo: [:subDir | return _ return + subDir fileSize].
	fileServeCache valuesDo: [:file | return _ return + file fileSize].
	^return! !

!SwikiDirectory methodsFor: 'accessing'!
fileVersionsAt: key
	^fileRefsCache at: key ifAbsent: [nil]! !

!SwikiDirectory methodsFor: 'accessing'!
filesAlphabetically
	^fileRefsCache values asSortedCollection: [:a :b | (a name asLowercase) < (b name asLowercase)]! !

!SwikiDirectory methodsFor: 'accessing'!
httpPath
	^''! !

!SwikiDirectory methodsFor: 'accessing'!
localHttpPath
	^''! !

!SwikiDirectory methodsFor: 'accessing'!
size
	^(fileRefsCache size) + (dirRefsCache size)! !

!SwikiDirectory methodsFor: 'referencing'!
referenceDirFs: fs options: dict
	^fs referenceDirectory: self options: dict! !

!SwikiDirectory methodsFor: 'referencing'!
referenceFileNamed: aFileName fs: fs options: dict
	| versionEntry |
	^(versionEntry _ fileRefsCache at: aFileName ifAbsent: [nil])
		ifNil: [fs referenceMissingFileNamed: aFileName onDir: self options: dict]
		ifNotNil: [fs referenceFile: versionEntry onDir: self options: dict]! !

!SwikiDirectory methodsFor: 'testing'!
directoryExists: dirName
	^dirRefsCache includesKey: dirName! !

!SwikiDirectory methodsFor: 'testing'!
fileExists: fileName
	^dir fileExists: fileName! !

!SwikiDirectory methodsFor: 'testing'!
fileRefsExists: fileName
	^fileRefsCache includesKey: fileName! !

!SwikiDirectory methodsFor: 'testing'!
fileServeExists: fileName
	^fileServeCache includesKey: fileName! !

!SwikiDirectory methodsFor: 'testing'!
isASubDirectory
	^false! !

!SwikiDirectory methodsFor: 'serving'!
serveDirFs: fs options: dict
	^fs serveDirectory: self options: dict! !

!SwikiDirectory methodsFor: 'serving'!
serveFilePath: aFilePath fs: fs options: dict
	| fileEntry |
	^(fileEntry _ fileServeCache at: aFilePath ifAbsent: [nil])
		ifNil: [fs serveMissingFilePath: aFilePath onDir: self options: dict]
		ifNotNil: [fs serveFile: fileEntry onDir: self options: dict]! !

!SwikiDirectory methodsFor: 'serving'!
servePath: aPath fs: fs options: dict
	| dirPath filePath dirEntry |
	(aPath includes: $/) ifFalse: [^(aPath = '')
		ifTrue: [self serveDirFs: fs options: dict]
		ifFalse: [self serveFilePath: aPath fs: fs options: dict]].
	(aPath last = $/) ifTrue: [^(dirEntry _ dirServeCache at: aPath ifAbsent: [nil])
		ifNil: [filePath _ (aPath copyUpTo: '/'), '/'.
			(dirEntry _ dirServeCache at: filePath ifAbsent: [nil])
				ifNil: [fs serveMissingFilePath: aPath onDir: self options: dict]
				ifNotNil: [dirEntry servePath: (aPath copyFrom: (filePath size + 1) to: (aPath size)) fs: fs options: dict]]
		ifNotNil: [dirEntry serveDirFs: fs options: dict]].
	dirPath _ (aPath copyUpToLast: $/), '/'.
	(dirEntry _ dirServeCache at: dirPath ifAbsent: [nil]) ifNotNil: [
		^dirEntry serveFilePath: (aPath copyAfterLast: $/) fs: fs options: dict].
	filePath _ (aPath copyUpTo: '/'), '/'.
	^(dirEntry _ dirServeCache at: filePath ifAbsent: [nil])
		ifNil: [fs serveMissingFilePath: aPath onDir: self options: dict]
		ifNotNil: [dirEntry servePath: (aPath copyFrom: (filePath size + 1) to: (aPath size)) fs: fs options: dict]
! !

!SwikiDirectory methodsFor: 'file operations'!
addAliasFrom: key to: value
	| aliasFile |
	aliasFile _ dir fileNamed: '.aliases'.
	aliasFile setToEnd.
	aliasFile
		nextPutAll: key;
		nextPut: $	;
		nextPutAll: value;
		nextPutAll: String crlf;
		close! !

!SwikiDirectory methodsFor: 'file operations'!
aliasDict
	| return key value |
	return _ Dictionary new.
	(dir fileExists: '.aliases') ifFalse: [^return].
	((dir readOnlyFileNamed: '.aliases') contentsOfEntireFile findTokens: String crlf)
		do: [:lineEntry | (lineEntry includes: $	) ifTrue: [
			key _ lineEntry copyUpTo: $	.
			value _ lineEntry copyFrom: (key size + 2) to: (lineEntry size).
			return at: key put: value]].
	^return! !

!SwikiDirectory methodsFor: 'file operations'!
deleteFileNamed: fileName
	"Delete all versions of this file"
	(fileRefsCache at: fileName ifAbsent: [OrderedCollection new]) do: [:version |
		dir deleteFileNamed: version name.
		fileServeCache removeKey: version httpName].
	fileRefsCache removeKey: fileName! !

!SwikiDirectory methodsFor: 'file operations' stamp: 'xw 5/11/2022 22:10'!
fileEntries
	^(dir entries select: [:entry | (entry isDirectory) not and: [(entry name) ~= '.aliases']]) collect: [:entry | SwikiFile fromDirectoryEntry: entry onDir: dir]! !

!SwikiDirectory methodsFor: 'file operations' stamp: 'xw 5/11/2022 22:13'!
moveFileNamed: fullPath toFileName: fileName
	| rootName actualFileName versions entry fromFile toFile |
	rootName _ self class rootNameFor: fileName.
	(versions _ fileRefsCache at: rootName ifAbsent: [nil])
		ifNil: [actualFileName _ dir checkName: rootName fixErrors: true.
			(rootName = actualFileName) ifFalse: ["Add alias"
				self addAliasFrom: actualFileName to: rootName]]
		ifNotNil: [actualFileName _ versions nextVersionName].
	"Move file to new location"
	[dir rename: fullPath toBe: actualFileName] ifError: [:err :rcvr |
		"Copy and delete instead"
		fromFile _ FileStream readOnlyFileNamed: fullPath.
		toFile _ dir newFileNamed: actualFileName.
		dir copyFile: fromFile toFile: toFile.
		fromFile close.
		toFile close.
		FileDirectory deleteFilePath: fullPath].
	"Get and Add Entry"
	entry := SwikiFile fromDirectoryEntry: (dir entryAt: actualFileName) onDir: dir.
	self addToFileRefsCache: entry at: rootName.
	self addToFileServeCache: entry at: entry name.
	"Return Versions"
	^fileRefsCache at: rootName! !

!SwikiDirectory methodsFor: 'file operations'!
moveVersions: versions to: newDir
	versions do: [:file |
		newDir moveFileNamed: (dir fullNameFor: file name) toFileName: versions name]! !

!SwikiDirectory methodsFor: 'file operations' stamp: 'xw 5/15/2022 16:35'!
readOnlyFile: aSwikiFile
	^ SwikiFileStream readOnlyFileNamed: aSwikiFile name inDirectory: self dir! !

!SwikiDirectory methodsFor: 'file operations'!
thumbnailOf: versions size: size
	"Return a JPEG SwikiImage for the thumbnail that matches the image;
	in case of error, return nil"
	| image thumbnailName thumbnail form |

	image _ versions last.
	thumbnailName	_ String streamContents: [:stream |
		versions name do: [:char | (char = $.)
			ifTrue: [stream nextPut: $-]
			ifFalse: [stream nextPut: char]].
		stream
			nextPut: $-;
			nextPutAll: size x asString;
			nextPut: $x;
			nextPutAll: size y asString;
			nextPutAll: '.jpeg'].
	thumbnail _ self fileRefsCacheAt: thumbnailName ifAbsent: [nil].
	thumbnail ifNotNil: [
		"check to make sure this thumbnail is appropriate"
		thumbnail _ thumbnail last.
		(image isOlderThan: thumbnail) ifTrue: [^thumbnail].
		"if not appropriate, delete thumbnail"
		self deleteFileNamed: thumbnailName].
	"Try to create the thumbnail"
	(image spaceInMemory < (Smalltalk garbageCollect - 2000000)) ifFalse: [
		"Cannot create thumbnail, because of insufficient memory"
		^nil].
	[form _ ImageReadWriter formFromStream: (self readOnlyFile: image).
	form _ form scaledToSize: size.
	JPEGReadWriter2 putForm: form onStream: (self dir newFileNamed: thumbnailName).
	self initializeFileNamed: thumbnailName.
	thumbnail _ self fileRefsCacheAt: thumbnailName ifAbsent: ["Weird error"^nil].
	^thumbnail last] ifError: [:a :b | ^nil]! !

!SwikiDirectory methodsFor: 'initialization'!
initialize
	"Fill Directories and Files"
	self initializeDirectories.
	self initializeFiles! !

!SwikiDirectory methodsFor: 'initialization' stamp: 'xw 5/11/2022 22:15'!
initializeDirectories
	| subSwikiDir |
	"Initialize Caches"
	dirServeCache _ Dictionary new.
	dirRefsCache _ Dictionary new.
	"Add subSwikiDirs"
	(dir entries select: [:entry | entry isDirectory]) do: [:entry |
		subSwikiDir := SwikiSubDirectory fromDirectoryEntry: entry onDir: (dir directoryNamed: (entry name)) containingDirectory: self.
		"dirRefsCache"
		self addToDirRefsCache: subSwikiDir at: subSwikiDir name]! !

!SwikiDirectory methodsFor: 'initialization' stamp: 'xw 5/11/2022 22:13'!
initializeFileNamed: fileName
	| entry aliasDict rootName |
	entry := SwikiFile fromDirectoryEntry: (self dir directoryEntryFor: fileName) onDir: self dir.
	aliasDict _ self aliasDict.
	rootName _ entry rootName.
	(entry name = rootName)
		ifFalse: [rootName _ aliasDict at: entry name ifAbsent: [rootName]].
	self addToFileRefsCache: entry at: (aliasDict at: rootName ifAbsent: [rootName]).
	self addToFileServeCache: entry at: (entry name)! !

!SwikiDirectory methodsFor: 'initialization'!
initializeFiles
	| aliasDict rootName |
	"Initialize Caches"
	fileServeCache _ Dictionary new.
	fileRefsCache _ Dictionary new.
	"Add Files"
	aliasDict _ self aliasDict.
	self fileEntries do: [:entry | rootName _ entry rootName.
		(entry name = rootName)
			ifFalse: [rootName _ aliasDict at: entry name ifAbsent: [rootName]].
		self addToFileRefsCache: entry at: (aliasDict at: rootName ifAbsent: [rootName]).
		self addToFileServeCache: entry at: (entry name)]! !

!SwikiDirectory methodsFor: 'cacheing'!
addToDirRefsCache: aSubSwikiDir at: key
	dirRefsCache at: key put: aSubSwikiDir
	! !

!SwikiDirectory methodsFor: 'cacheing'!
addToDirServeCache: aSubSwikiDir at: key
	dirServeCache at: key put: aSubSwikiDir! !

!SwikiDirectory methodsFor: 'cacheing'!
addToFileRefsCache: entry at: fullName
	| versions |
	(versions _ fileRefsCache at: fullName ifAbsent: [nil]) ifNil: [
		versions _ SwikiFileVersions named: fullName.
		fileRefsCache at: fullName put: versions].
	versions addEntry: entry! !

!SwikiDirectory methodsFor: 'cacheing'!
addToFileServeCache: entry at: key
	fileServeCache at: key put: entry! !

!SwikiDirectory methodsFor: 'cacheing' stamp: 'xw 5/11/2022 22:15'!
directoryNamed: dirName
	| subSwikiDir |
	^self directoryNamed: dirName ifAbsent: ["Create One"
		dir createDirectory: dirName.
		subSwikiDir := SwikiSubDirectory fromDirectoryEntry: (dir entryAt: dirName) onDir: (dir directoryNamed: dirName) containingDirectory: self.
		self addToDirRefsCache: subSwikiDir at: subSwikiDir name.
		subSwikiDir]! !

!SwikiDirectory methodsFor: 'cacheing'!
directoryNamed: dirName ifAbsent: aBlock
	^dirRefsCache at: dirName ifAbsent: aBlock! !

!SwikiDirectory methodsFor: 'cacheing'!
fileRefsCacheAt: key ifAbsent: block
	^fileRefsCache at: key ifAbsent: block! !

!SwikiDirectory methodsFor: 'cacheing'!
fileServeCacheAt: key ifAbsent: block
	^fileServeCache at: key ifAbsent: block! !


!SwikiEntry class methodsFor: 'private'!
rootNameFor: aString
	| tokens return ignore |
	tokens _ aString findTokens: '.'.
	(tokens size = 1) ifTrue: [^tokens at: 1].
	return _ WriteStream on: String new.
	return nextPutAll: (tokens at: 1).
	tokens _ tokens copyFrom: 2 to: tokens size.
	ignore _ true.
	tokens do: [:token | (ignore and: [token isAllDigits])
		ifTrue: [ignore _ false]
		ifFalse: [return
			nextPut: $.;
			nextPutAll: token]].
	^return contents! !

!SwikiEntry class methodsFor: 'utility'!
validFileNameFromFileLocation: aString
	^(aString unescapePercents findTokens: ':/\') last reject: [:i | 
		"No HTML/HTTP characters allowed"
		'&<>"?*' includes: i]! !

!SwikiEntry class methodsFor: 'instance creation' stamp: 'xw 5/11/2022 21:58'!
fromDirectoryEntry: entry
	^self basicNew fromDirectoryEntry: entry! !


!SwikiDirectory class methodsFor: 'instance creation' stamp: 'xw 5/11/2022 22:11'!
fromDirectoryEntry: entry onDir: dir
	| instance |
	instance := self fromDirectoryEntry: entry.
	instance dir: dir.
	instance initialize.
	^instance! !

!SwikiDirectory class methodsFor: 'instance creation' stamp: 'xw 5/11/2022 22:14'!
onDir: dir
	^self fromDirectoryEntry: (dir containingDirectory entryAt: (dir pathParts last)) onDir: dir! !


!SwikiFile methodsFor: 'accessing'!
fileSize
	^fileSize! !

!SwikiFile methodsFor: 'accessing'!
fileSizeInWords
	^self class fileSizeToWords: fileSize! !

!SwikiFile methodsFor: 'accessing'!
mimeType
	^versions mimeType! !

!SwikiFile methodsFor: 'accessing'!
referenceStyle
	^'file'! !

!SwikiFile methodsFor: 'accessing'!
rootName
	^self class rootNameFor: name! !

!SwikiFile methodsFor: 'accessing'!
version
	| tokens |
	"Files have versions of the form myfile.3.ext, where 3 is the version.
	A file without a numbered extension has version of 0"
	tokens _ name findTokens: '.'.
	(tokens size = 1) ifTrue: [^0].
	(tokens at: 2) isAllDigits ifFalse: [^0].
	^(tokens at: 2) asNumber! !

!SwikiFile methodsFor: 'accessing'!
versions
	^versions! !

!SwikiFile methodsFor: 'accessing'!
versions: aSwikiFileVersions
	versions _ aSwikiFileVersions! !

!SwikiFile methodsFor: 'initialization'!
dir: dir mimeType: mimeType
	"Sub-classes can overwrite this"! !

!SwikiFile methodsFor: 'initialization' stamp: 'xw 5/11/2022 21:58'!
fromDirectoryEntry: entry
	super fromDirectoryEntry: entry.
	fileSize := entry fileSize.! !


!SwikiFile class methodsFor: 'initialize-release'!
handlesMime: aMimeType
	MimeToClass at: aMimeType put: self! !

!SwikiFile class methodsFor: 'initialize-release'!
initialize
	MimeToClass _ Dictionary new! !

!SwikiFile class methodsFor: 'utility'!
fileSizeToWords: numberOfBytes
	(numberOfBytes < 1000) ifTrue: [^numberOfBytes asString, ' b'].
	(numberOfBytes < 10000) ifTrue: [^((numberOfBytes // 100) / 10) asFloat asString, ' kb'].
	(numberOfBytes < 1000000) ifTrue: [^(numberOfBytes // 1000) asString, ' kb'].
	(numberOfBytes < 10000000) ifTrue: [^((numberOfBytes // 100000) / 10) asFloat asString, ' Mb'].
	^(numberOfBytes // 1000000) asString, ' Mb'! !

!SwikiFile class methodsFor: 'instance creation' stamp: 'xw 5/11/2022 22:11'!
fromDirectoryEntry: entry onDir: dir
	| mime instance |
	mime := MIMEDocument guessTypeFromName: (entry name).
	instance := (MimeToClass at: mime ifAbsent: [SwikiFile]) fromDirectoryEntry: entry.
	instance dir: dir mimeType: mime.
	instance isValid ifFalse: [
		instance := SwikiFile fromDirectoryEntry: entry.
		instance dir: dir mimeType: mime].
	^instance! !


!SwikiFileServer methodsFor: 'accessing'!
refDirectoryBlock: aBlock
	refDirectoryBlock _ aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
refFileBlock: aBlock
	refFileBlock _ aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
refFileDictAt: aClass put: aBlock
	refFileDict at: aClass put: aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
refImageBlock: aBlock
	self refFileDictAt: SwikiImage put: aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
refMissingFileBlock: aBlock
	refMissingFileBlock _ aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
serveDirectoryBlock: aBlock
	serveDirectoryBlock _ aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
serveFileBlock: aBlock
	serveFileBlock _ aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
serveFileDictAt: aClass put: aBlock
	serveFileDict at: aClass put: aBlock! !

!SwikiFileServer methodsFor: 'accessing'!
serveMissingFileBlock: aBlock
	serveMissingFileBlock _ aBlock! !

!SwikiFileServer methodsFor: 'serving'!
serveDirectory: aSwikiDir options: dict
	^serveDirectoryBlock copy fixTemps value: aSwikiDir value: dict! !

!SwikiFileServer methodsFor: 'serving'!
serveFile: aSwikiFile onDir: aSwikiDir options: dict
	^(serveFileDict at: aSwikiFile class ifAbsent: [serveFileBlock]) copy fixTemps value: aSwikiFile value: aSwikiDir value: dict! !

!SwikiFileServer methodsFor: 'serving'!
serveMissingFilePath: path onDir: aSwikiDir options: dict
	^serveMissingFileBlock copy fixTemps value: path value: aSwikiDir value: dict! !

!SwikiFileServer methodsFor: 'initialization'!
initialize
	refFileDict _ Dictionary new.
	serveFileDict _ Dictionary new! !

!SwikiFileServer methodsFor: 'referencing'!
referenceDirectory: aSwikiDir options: dict
	^refDirectoryBlock copy fixTemps value: aSwikiDir value: dict! !

!SwikiFileServer methodsFor: 'referencing'!
referenceFile: aSwikiFile onDir: aSwikiDir options: dict
	^(refFileDict at: (aSwikiFile last class) ifAbsent: [refFileBlock]) copy fixTemps value: aSwikiFile value: aSwikiDir value: dict! !

!SwikiFileServer methodsFor: 'referencing'!
referenceMissingFileNamed: aString onDir: aSwikiDir options: dict
	^refMissingFileBlock copy fixTemps value: aString value: aSwikiDir value: dict! !


!SwikiFileServer class methodsFor: 'instance creation'!
new
	^super new initialize! !


!SwikiFileStream methodsFor: 'string functions' stamp: 'xw 5/15/2022 17:51'!
bufferSize
	^5000! !

!SwikiFileStream methodsFor: 'string functions' stamp: 'xw 5/15/2022 17:51'!
copyFrom: pos1 to: pos2
	self position: pos1 - 1.
	^self next: pos2 - pos1 + 1! !

!SwikiFileStream methodsFor: 'string functions' stamp: 'xw 5/15/2022 17:53'!
findString: subString
	"Answer the index of subString within the receiver, starting at start. If
	the receiver does not contain subString, answer 0."
	^self findString: subString startingAt: 1.! !

!SwikiFileStream methodsFor: 'string functions' stamp: 'xw 5/15/2022 17:51'!
findString: subString startingAt: start
	^self findString: subString startingAt: start caseSensitive: true! !

!SwikiFileStream methodsFor: 'string functions' stamp: 'xw 5/15/2022 17:51'!
findString: subString startingAt: start caseSensitive: caseSensitive
	"Use buffers to find the subString on this stream"
	| buffer pos return |
	pos _ start - 1.
	[self atEnd] whileFalse: [
		self position: pos.
		buffer _ self next: self bufferSize.
		return _ buffer findString: subString startingAt: 1 caseSensitive: caseSensitive.
		(return = 0) ifFalse: [
			self position: 0.
			^pos + return].
		pos _ pos + buffer size - subString size].
	^0! !


!SwikiFileStream class methodsFor: 'file creation' stamp: 'xw 5/15/2022 16:18'!
fileNamed: fileName inDirectory: directory
	^ self fileNamed: (directory fullNameFor: fileName)! !

!SwikiFileStream class methodsFor: 'file creation' stamp: 'xw 5/15/2022 16:05'!
newFileNamed: fileName inDirectory: directory
	^ self newFileNamed: (directory fullNameFor: fileName)! !

!SwikiFileStream class methodsFor: 'file creation' stamp: 'xw 5/15/2022 16:21'!
oldFileNamed: fileName inDirectory: directory
	^ self oldFileNamed: (directory fullNameFor: fileName)! !

!SwikiFileStream class methodsFor: 'file creation' stamp: 'xw 5/15/2022 16:04'!
readOnlyFileNamed: fileName inDirectory: directory
	^ self readOnlyFileNamed: (directory fullNameFor: fileName)! !


!SwikiFileVersions methodsFor: 'accessing'!
addEntry: aSwikiEntry
	| version size |
	aSwikiEntry versions: self.
	version _ aSwikiEntry version.
	size _ self size.
	"Pad collection, so that entries can be added in incorrect order"
	(size = version) ifTrue: [^self add: aSwikiEntry].
	(size > version) ifTrue: [^self at: (version + 1) put: aSwikiEntry].
	[self size = version] whileFalse: [self add: nil].
	self add: aSwikiEntry! !

!SwikiFileVersions methodsFor: 'accessing'!
httpName
	^name encodeForHTTP! !

!SwikiFileVersions methodsFor: 'accessing'!
mimeType
	^mimeType! !

!SwikiFileVersions methodsFor: 'accessing'!
mimeType: mime
	mimeType _ mime! !

!SwikiFileVersions methodsFor: 'accessing'!
name
	^name! !

!SwikiFileVersions methodsFor: 'accessing'!
name: aString
	name _ aString! !

!SwikiFileVersions methodsFor: 'accessing'!
nextVersionName
	| tokens return |
	tokens _ self first rootName findTokens: '.'.
	return _ WriteStream on: String new.
	return
		nextPutAll: (tokens at: 1);
		nextPut: $.;
		nextPutAll: (self size asString).
	(tokens size = 1) ifFalse: [2 to: tokens size do: [:i | return
		nextPut: $.;
		nextPutAll: (tokens at: i)]].
	^return contents! !

!SwikiFileVersions methodsFor: 'accessing'!
pluginReference
	^'<?', (self last referenceStyle), ' src="', self name, '"?>'! !

!SwikiFileVersions methodsFor: 'accessing'!
strictXmlName
	^TextFormatter encodeToStrictXmlCrlf: name! !

!SwikiFileVersions methodsFor: 'accessing'!
xmlName
	^TextFormatter encodeToXmlCrlf: name! !

!SwikiFileVersions methodsFor: 'testing'!
isAnImage
	^self last isAnImage! !


!SwikiFileVersions class methodsFor: 'instance creation'!
named: aString
	^self new name: aString; mimeType: (MIMEDocument guessTypeFromName: aString)! !


!SwikiImage methodsFor: 'accessing'!
height
	^height! !

!SwikiImage methodsFor: 'accessing'!
referenceStyle
	^'image'! !

!SwikiImage methodsFor: 'accessing'!
size
	^Point x: width y: height! !

!SwikiImage methodsFor: 'accessing'!
thumbnailSizeWidth: maxWidth height: maxHeight
	^maxWidth
		ifNil: [maxHeight
			ifNil: [self size]
			ifNotNil: ["Scale by maxHeight"
				(height > maxHeight) ifFalse: [^self size].
				Point x: ((width * maxHeight / height) rounded) y: maxHeight]]
		ifNotNil: [maxHeight
			ifNil: ["Scale by maxWidth"
				(width > maxWidth) ifFalse: [^self size].
				Point x: maxWidth y: ((height * maxWidth / width) rounded)]
			ifNotNil: [((width * maxHeight) > (height * maxWidth))
				ifTrue: ["Scale by maxWidth"
					(width > maxWidth) ifFalse: [^self size].
					Point x: maxWidth y: ((height * maxWidth / width) rounded)]
				ifFalse: ["Scale by maxHeight"
					(height > maxHeight) ifFalse: [^self size].
					Point x: ((width * maxHeight / height) rounded) y: maxHeight]]]! !

!SwikiImage methodsFor: 'accessing'!
width
	^width! !

!SwikiImage methodsFor: 'testing'!
isAnImage
	^true! !

!SwikiImage methodsFor: 'testing'!
isValid
	(width = nil) ifTrue: [^false].
	(height = nil) ifTrue: [^false].
	^super isValid! !

!SwikiImage methodsFor: 'testing'!
spaceInMemory
	"the amount of memory in bytes required to load this image"
	^width * height * 3! !

!SwikiImage methodsFor: 'initialization'!
dir: dir mimeType: mimeType
	| fileStream |
	"Get Width and Height information from file stream.
	On error, width and height become nil"
	fileStream _ dir readOnlyFileNamed: name.
	(mimeType = 'image/gif') ifTrue: [
		[self getWHFromGifStream: fileStream]
			ifError: [:a :b | width _ nil. height _ nil]].
	(mimeType = 'image/jpeg') ifTrue: [
		[self getWHFromJpegStream: fileStream]
			ifError: [:a :b | width _ nil. height _ nil]].
	(mimeType = 'image/png') ifTrue: [
		[self getWHFromPngStream: fileStream]
			ifError: [:a :b | width _ nil. height _ nil]].
	fileStream close! !

!SwikiImage methodsFor: 'initialization'!
getWHFromGifStream: stream
	"Get Width and Height from a GIF image"
	| reader |
	reader _ GIFReadWriter new on: stream.
	(reader hasMagicNumber: 'GIF87a' asByteArray) ifFalse: [
		(reader hasMagicNumber: 'GIF89a' asByteArray) ifFalse: [
			"Not a valid gif"
			^self]].
	width _ reader readWord.
	height _ reader readWord! !

!SwikiImage methodsFor: 'initialization'!
getWHFromJpegStream: stream
	"Get Width and Height from a JPEG image"
	stream binary.
	stream next: 4.
	stream next: ((stream next bitShift: 8) + (stream next) - 2).
	[#(16rFFC0 16rFFC1 16rFFC2 16rFFC3 16rFFC5 16rFFC6 16rFFC7 16rFFC9 16rFFCA 16rFFCB 16rFFCD 16rFFCE 16rFFCF) includes: ((stream next bitShift: 8) + (stream next))] whileFalse: [
		stream next: ((stream next bitShift: 8) + (stream next) - 2)].
	stream next: 3.
	height _ (stream next bitShift: 8) + (stream next).
	width _ (stream next bitShift: 8) + (stream next)! !

!SwikiImage methodsFor: 'initialization'!
getWHFromPngStream: stream
	"Get Width and Height from a PNG image"
	stream binary.
	(stream size > 24) ifTrue: ["Check to make sure it is a PNG"
		((stream next: 8) = (ByteArray withAll: #(137 80 78 71 13 10 26 10))) ifTrue: [
			stream next: 8.
			width _ (stream next bitShift: 24) + (stream next bitShift: 16) + (stream next bitShift: 8) + (stream next).
			height _ (stream next bitShift: 24) + (stream next bitShift: 16) + (stream next bitShift: 8) + (stream next)]]! !


!SwikiImage class methodsFor: 'initialize-release'!
initialize
	self handlesMime: 'image/png'.
	self handlesMime: 'image/jpeg'.
	self handlesMime: 'image/gif'! !


!SwikiModule methodsFor: 'accessing'!
shelf
	^shelf! !

!SwikiModule methodsFor: 'accessing'!
shelf: aSwikiShelf
	shelf _ aSwikiShelf! !

!SwikiModule methodsFor: 'processing'!
filter: rawRequest
	^HttpSwikiRequest fromHttpRequest: rawRequest! !

!SwikiModule methodsFor: 'processing'!
processHttpRequest: rawRequest 
	| request response |
	request := self filter: rawRequest.
	response := Dictionary new.
	shelf process: request response: response.
	^self responseFrom: response! !

!SwikiModule methodsFor: 'processing' stamp: 'xw 5/13/2022 21:05'!
responseFrom: dict 
	| response content |
	response _ HttpResponse new.
	"header status"
	response status: (dict at: 'headerStatus' ifAbsent: [#ok]).
	"connection"
	"response fieldAt: 'Connection' put: (dict at: 'connection' ifAbsent: ['close'])."
	"cacheing"
	(dict at: 'cacheing' ifAbsent: [false])
		ifTrue: [response
			fieldAt: 'Cache-Control' put: 'public';
			"Last modified put in sometime in the past, so that Safari will cache."
			fieldAt: 'Last-Modified' put: 'Sat, 1 Jan 2005 00:00:00 GMT']
		ifFalse: [response
			fieldAt: 'Pragma' put: 'no-cache';
			fieldAt: 'Expires' put: '0';
			fieldAt: 'Cache-Control' put: 'no-cache'].
	"location (in case of redirect)"
	(dict includesKey: 'location') ifTrue: [response
		fieldAt: 'Location' put: (dict at: 'location')].
	"authenticate (in case of unauthorized)"
	(dict includesKey: 'authenticate') ifTrue: [response
		fieldAt: 'WWW-Authenticate' put: (dict at: 'authenticate')].
	"content type"
	response contentType: (dict at: 'contentType' ifAbsent: ['text/html; charset=iso-8859-1']).
	"contents"
	content _ dict at: 'content'.
	(content isKindOf: String)
		ifTrue: [response contents: (ReadStream on: content)]
		ifFalse: [(content isKindOf: BlockClosure)
			ifTrue: [response _ response asHttpPartialResponseBlock: content]
			ifFalse: [response contents: content]].
	"return the response to be served"
	^ response! !

!SwikiModule methodsFor: 'processing'!
stop
	^shelf stopProcessing! !


!SwikiModule class methodsFor: 'priorities' stamp: 'Je77 12/11/2005 17:12'!
defaultPriority

	^Processor userBackgroundPriority! !

!SwikiModule class methodsFor: 'priorities' stamp: 'Je77 12/11/2005 17:12'!
searchPriority

	^self defaultPriority - 1! !

!SwikiModule class methodsFor: 'instance creation'!
swikiWebServer
	| instance |
	instance _ self new.
	instance shelf: (SwikiShelf new
		name: 'swiki';
		storage: (XmlSwikiStorage fromDir: (FileDirectory default directoryNamed: 'swiki'));
		load;
		yourself).
	^instance! !


!SwikiRSSModule methodsFor: 'accessing'!
rssAtUrl: url expireHours: hours
	| rss new |
	rss _ urlToRss at: url ifAbsent: [nil].
	rss ifNil: ["Document does not exist yet"
		"Get content at url"
		sema wait.
		[rss _ self class httpGetDocument: url]
			ifError: [:a :b | sema signal. ^#httpGetFailed].
		sema signal.
		"Parse xml"
		[rss _ XMLDOMParser parseDocumentFrom: (ReadStream on: rss content)]
			ifError: [:a :b | ^#xmlParseFailed].
"		[rss _ RSSDocument fromXml: rss]
			ifError: [:a :b | ^#xmlToRssFailed]." rss _ RSSDocument fromXml: rss.
		"return RSS document"
		urlToRss at: url put: rss.
		^rss].
	(rss hasExpiredHours: hours) ifTrue: ["Document has expired"
		"Get content at url"
		sema wait.
		[new _ HTTPSocket httpGetDocument: url]
			ifError: [:a :b | sema signal. ^rss].
		sema signal.
		"Parse xml"
		[new _ XMLDOMParser parseDocumentFrom: (ReadStream on: new content)]
			ifError: [:a :b | ^rss].
		[new _ RSSDocument fromXml: new]
			ifError: [:a :b | ^rss].
		"return RSS document"
		urlToRss at: url put: new.
		^new].
	^rss
! !

!SwikiRSSModule methodsFor: 'initialization'!
initialize
	sema _ Semaphore forMutualExclusion.
	urlToRss _ Dictionary new! !


!SwikiRSSModule class methodsFor: 'utility'!
defaultPort
	^HTTPSocket defaultPort! !

!SwikiRSSModule class methodsFor: 'utility'!
httpGetDocument: url

	| serverName serverAddr port sock header length bare page list firstData 
aStream index connectToHost connectToPort type newUrl crlf |
	crlf _ String crlf.
	Socket initializeNetwork.
	bare _ (url asLowercase beginsWith: 'http://') 
		ifTrue: [url copyFrom: 8 to: url size]
		ifFalse: [url].
	bare _ bare copyUpTo: $#.  "remove fragment, if specified"
	serverName _ bare copyUpTo: $/.
	page _ bare copyFrom: serverName size + 1 to: bare size.
	(serverName includes: $:) 
		ifTrue: [ index _ serverName indexOf: $:.
			port _ (serverName copyFrom: index+1 to: serverName size) asNumber.
			serverName _ serverName copyFrom: 1 to: index-1. ]
		ifFalse: [ port _ self defaultPort ].
	page size = 0 ifTrue: [page _ '/'].


	connectToHost _ serverName.
	connectToPort _ port.
	
	serverAddr _ NetNameResolver addressForName: connectToHost timeout: 20.
	serverAddr ifNil: [self error: 'Could not resolve the server name.'].

3 timesRepeat: [
	sock _ HTTPSocket new.
	sock connectTo: serverAddr port: connectToPort.
	(sock waitForConnectionUntil: (Socket deadlineSecs: 30)) ifFalse: [
		Socket deadServer: connectToHost.  sock destroy.
		^ self error: 'Server is not responding'].
	sock sendCommand: 'GET ', page, ' HTTP/1.0', crlf,
		'ACCEPT: text/html', crlf,	"Always accept plain text"
		'User-Agent: Squeak 1.31', crlf,
		'Host: ', serverName, ':', port printString, crlf.	"blank line 
automatically added"

	list _ sock getResponseUpTo: crlf, crlf ignoring: (String cr).
	header _ list at: 1.
	"Transcript show: page; cr; show: header; cr."
	firstData _ list at: 3.
	header isEmpty 
		ifTrue: [aStream _ 'server aborted early']
		ifFalse: [
			"dig out some headers"
			sock header: header.
			length _ sock getHeader: 'content-length'.
			length ifNotNil: [ length _ length asNumber ].
			type _ sock getHeader: 'content-type'.
			sock responseCode first = $3 ifTrue: [
				newUrl _ sock getHeader: 'location'.
				newUrl ifNotNil: [ 
					sock destroy.
					newUrl _ self expandUrl: newUrl ip: serverAddr port: connectToPort.
					^self httpGetDocument: newUrl]].
			aStream _ sock getRestOfBuffer: firstData totalLength: length.
			sock responseCode = '401' ifTrue: [^ header, aStream contents].
			].
	sock destroy.	"Always OK to destroy!!"
	aStream class ~~ String ifTrue: [
 		^ MIMEDocument contentType: type content: aStream contents url: url].
	aStream = 'server aborted early' ifFalse: [
		]
	].

	^self error: 'some other bad thing happened!!'! !

!SwikiRSSModule class methodsFor: 'instance creation'!
newModule
	^self new
		initialize
		yourself! !


!SwikiRequest methodsFor: 'settings'!
settings
	^settings! !

!SwikiRequest methodsFor: 'settings'!
settingsAt: key
	^settings at: key! !

!SwikiRequest methodsFor: 'settings'!
settingsAt: key ifAbsent: block
	^settings at: key ifAbsent: block! !

!SwikiRequest methodsFor: 'settings'!
settingsAt: key put: value
	^settings at: key put: value! !

!SwikiRequest methodsFor: 'settings'!
settingsIncludes: key
	^settings includesKey: key! !

!SwikiRequest methodsFor: 'settings'!
settingsRemove: key
	settings removeKey: key ifAbsent: []! !

!SwikiRequest methodsFor: 'accessing'!
address
	^address! !

!SwikiRequest methodsFor: 'accessing'!
book
	^book! !

!SwikiRequest methodsFor: 'accessing'!
page
	^page! !

!SwikiRequest methodsFor: 'accessing'!
security
	^security! !

!SwikiRequest methodsFor: 'accessing'!
security: aSwikiSecurityMember
	security _ aSwikiSecurityMember! !

!SwikiRequest methodsFor: 'initializing'!
initialize
	settings _ Dictionary new! !

!SwikiRequest methodsFor: 'utility'!
canAppend
	^(self fieldsKey: 'append' ifAbsent: [^false]) notEmpty! !


!HttpSwikiRequest methodsFor: 'initializing'!
fromHttpRequest: rawRequest
	| tokens |
	raw _ rawRequest.
	tokens _ (raw url copyUpTo: $?) findTokens: '/.'.
	(tokens size = 0) ifTrue: [^self].
	book _ tokens at: 1.
	(tokens size = 1) ifTrue: [address _ 'default'.
		^self].
	(tokens at: 2) isAllDigits
		ifTrue: [page _ (tokens at: 2) asNumber.
			address _ (tokens size > 2) ifTrue: [tokens at: 3] ifFalse: ['default']]
		ifFalse: [address _ tokens at: 2]! !

!HttpSwikiRequest methodsFor: 'accessing'!
raw
	^raw! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsAsBooleanKey: aKey
	^self fieldsAsBooleanKey: aKey ifAbsent: [false]! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsAsBooleanKey: aKey ifAbsent: block
	(raw postFields)
		ifNil: [(raw getFields)
			ifNil: [^block value]
			ifNotNil: [^(raw getFields at: aKey ifAbsent: [^block value]) = 'true']]
		ifNotNil: [^(raw postFields at: aKey ifAbsent: [
			(raw getFields)
				ifNil: [^block value]
				ifNotNil: [^(raw getFields at: aKey ifAbsent: [^block value]) = 'true']]) = 'true']! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsAsNumberKey: aKey
	^self fieldsAsNumberKey: aKey ifAbsent: [0]! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsAsNumberKey: aKey ifAbsent: block
	(raw postFields)
		ifNil: [(raw getFields)
			ifNil: [^block value]
			ifNotNil: [^(raw getFields at: aKey ifAbsent: [^block value]) asNumber]]
		ifNotNil: [^(raw postFields at: aKey ifAbsent: [
			(raw getFields)
				ifNil: [^block value]
				ifNotNil: [^(raw getFields at: aKey ifAbsent: [^block value]) asNumber]]) asNumber]! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsHasKey: aKey
	^(raw postFields)
		ifNil: [(raw getFields)
			ifNil: [false]
			ifNotNil: [raw getFields includesKey: aKey]]
		ifNotNil: [(raw postFields includesKey: aKey)
			ifTrue: [true]
			ifFalse: [(raw getFields)
				ifNil: [false]
				ifNotNil: [raw getFields includesKey: aKey]]]! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsKey: aKey
	^self fieldsKey: aKey ifAbsent: ['']! !

!HttpSwikiRequest methodsFor: 'fields'!
fieldsKey: aKey ifAbsent: block
	^(raw postFields)
		ifNil: [(raw getFields)
			ifNil: [block value]
			ifNotNil: [raw getFields at: aKey ifAbsent: block]]
		ifNotNil: [raw postFields at: aKey ifAbsent: [
			(raw getFields)
				ifNil: [block value]
				ifNotNil: [raw getFields at: aKey ifAbsent: block]]]! !

!HttpSwikiRequest methodsFor: 'references'!
referenceShelf: shelf address: theAddress
	^'/', theAddress! !

!HttpSwikiRequest methodsFor: 'references'!
referenceShelf: shelf book: theBook
	^'/', theBook name! !

!HttpSwikiRequest methodsFor: 'references'!
referenceShelf: shelf book: theBook address: theAddress
	^'/', theBook name, '/', theAddress! !

!HttpSwikiRequest methodsFor: 'references'!
referenceShelf: shelf book: theBook page: thePage
	^'/', theBook name, '/', (thePage id asString)! !

!HttpSwikiRequest methodsFor: 'references'!
referenceShelf: shelf book: theBook page: thePage address: theAddress
	^'/', theBook name, '/', (thePage id asString), '.', theAddress! !

!HttpSwikiRequest methodsFor: 'user authentication'!
clearCookiePasswords
	raw setCookieName: #AniPasswords
		value: 'x'
		path: '/'! !

!HttpSwikiRequest methodsFor: 'user authentication'!
clearPassword
	raw clearPassword! !

!HttpSwikiRequest methodsFor: 'user authentication'!
cookiePasswords
	| return |
	return _ raw cookies at: #AniPasswords ifAbsent: ['x'].
	(return = 'x') ifTrue: [^OrderedCollection new].
	return _ return findTokens: '<>'.
	^return collect: [:i | TextFormatter decodeFromXmlCr: i]! !

!HttpSwikiRequest methodsFor: 'user authentication'!
getUsername
	^raw getUsername! !

!HttpSwikiRequest methodsFor: 'user authentication'!
hasUserObject
	^raw userObject notNil! !

!HttpSwikiRequest methodsFor: 'user authentication'!
isUsername: aUsername password: aPassword
	^raw isUsername: aUsername password: aPassword! !

!HttpSwikiRequest methodsFor: 'user authentication'!
setCookiePasswords: coll
	raw setCookieName: #AniPasswords
		value: (String streamContents: [:stream |
			coll do: [:password | stream
				nextPutAll: (TextFormatter encodeToXmlCr: password);
				nextPut: $>]])
		path: '/'! !

!HttpSwikiRequest methodsFor: 'user authentication'!
setUsername: aUsername password: aPassword
	^raw setUsername: aUsername password: aPassword! !

!HttpSwikiRequest methodsFor: 'user authentication'!
userObject
	^raw userObject! !

!HttpSwikiRequest methodsFor: 'user authentication'!
userObject: anObject
	raw userObject: anObject! !

!HttpSwikiRequest methodsFor: 'utility'!
canProcessPublic: aPage inBook: aBook
	address _ self address.
	^(aPage accessLevelForRequest: self) caseOf: {
		[0]->[false].
		[3]->[#('default' 'vote' 'append' 'appendHere' 'new' 'newPage' 'newPageSave' 'edit' 'save' 'history' 'version' 'diff' 'print' 'rss') includes: self address].
		[4]->[#('default' 'vote' 'append' 'appendHere' 'new' 'newPage' 'newPageSave' 'edit' 'save' 'upload' 'attach' 'attachImage' 'history' 'version' 'diff' 'print' 'rss') includes: self address]}
		otherwise: [#('default' 'vote' 'append' 'appendHere' 'print' 'rss') includes: self address]! !

!HttpSwikiRequest methodsFor: 'utility'!
canProcessUser: aPage inBook: aBook
	address _ self address.
	^(aPage accessLevelForRequest: self) caseOf: {
		[0]->[false].
		[3]->[#('default' 'vote' 'append' 'appendHere' 'new' 'newPage' 'newPageSave' 'edit' 'save' 'history' 'version' 'diff' 'print' 'rss') includes: self address].
		[4]->[#('default' 'vote' 'append' 'appendHere' 'new' 'newPage' 'newPageSave' 'edit' 'save' 'upload' 'attach' 'attachImage' 'history' 'version' 'diff' 'print' 'rss') includes: self address]}
		otherwise: [#('default' 'vote' 'append' 'appendHere' 'saveAlert' 'print' 'rss') includes: self address]! !

!HttpSwikiRequest methodsFor: 'utility'!
formText
	| texts index |
	(self fieldsHasKey: 'text1') ifFalse: [^''].
	texts _ Dictionary new.
	index _ 1.
	[self fieldsHasKey: ('text', index asString)]
		whileTrue: [texts at: (index asString) put: (self fieldsKey: ('text', index asString)).
			index _ index + 1].
	^texts! !

!HttpSwikiRequest methodsFor: 'utility'!
groupIds
	^self settingsAt: 'groups' ifAbsent: [OrderedCollection new]! !

!HttpSwikiRequest methodsFor: 'utility'!
groupIds: coll
	self settingsAt: 'groupIds' put: coll! !

!HttpSwikiRequest methodsFor: 'utility'!
hasTextKeys
	^(self fieldsHasKey: 'text') or: [self fieldsHasKey: 'text1']! !

!HttpSwikiRequest methodsFor: 'utility'!
isFramesCapable
	^((raw header at: 'user-agent' ifAbsent: [^false]) asLowercase beginsWith: 'lynx') not! !

!HttpSwikiRequest methodsFor: 'utility'!
isOwner
	^self settingsAt: 'isOwner' ifAbsent: [false]! !

!HttpSwikiRequest methodsFor: 'utility'!
linkablePagesInBook: aSwikiBook
	| pageAccessLevels |
	"owner can link all pages"
	self isOwner ifTrue: [^aSwikiBook pages].
	pageAccessLevels _ self pageAccessLevelsFor: self inBook: aSwikiBook.
	^aSwikiBook pages select: [:i | (pageAccessLevels at: i id) > 1]! !

!HttpSwikiRequest methodsFor: 'utility'!
pageAccessLevelsFor: request inBook: aSwikiBook
	"Cache it and use lazy initialization"
	^self settingsAt: 'pageAccessLevels' ifAbsent: [
		self settingsAt: 'pageAccessLevels' put:
			(aSwikiBook pages collect: [:i | i accessLevelForRequest: request]).
		self settingsAt: 'pageAccessLevels']! !

!HttpSwikiRequest methodsFor: 'utility'!
text
	^self fieldsKey: 'text' ifAbsent: [self formText]! !

!HttpSwikiRequest methodsFor: 'utility'!
textIncludesAnyOf: collection
	| text |
	collection isEmpty ifTrue: [^false].
	text _ self text.
	text _ (text isKindOf: String)
		ifTrue: [text]
		ifFalse: [String streamContents: [:stream |
			text do: [:textItem | stream nextPutAll: textItem]]].
	text _ text, (self fieldsKey: 'append' ifAbsent: ['']).
	collection do: [:test |
		(text includesSubString: test) ifTrue: [^true]].
	^false! !

!HttpSwikiRequest methodsFor: 'utility'!
url
	^raw url! !

!HttpSwikiRequest methodsFor: 'utility'!
user
	"Give IP address since this is the closest that an HttpRequest without login, password."
	^raw remoteAddress! !

!HttpSwikiRequest methodsFor: 'utility'!
userID
	"Should be refactored"
	| userID i |
	userID _ raw header at: 'authorization' ifAbsent: [^nil].
	(userID notNil and: [(i _ userID findString: 'Basic ') > 0])
		ifTrue: [userID _ userID copyFrom: i+6 to: userID size]
		ifFalse: [userID _ nil].
	^userID! !

!HttpSwikiRequest methodsFor: 'utility'!
viewablePagesInBook: aSwikiBook
	| pageAccessLevels |
	"owner can view all pages"
	self isOwner ifTrue: [^aSwikiBook pages].
	pageAccessLevels _ self pageAccessLevelsFor: self inBook: aSwikiBook.
	^aSwikiBook pages select: [:i | (pageAccessLevels at: i id) > 0]! !


!HttpSwikiRequest class methodsFor: 'instance creation'!
fromHttpRequest: rawRequest
	^self new initialize; fromHttpRequest: rawRequest! !


!SwikiSchemeReadWriter class methodsFor: 'utility'!
schemesToXml: schemes
	| return |
	return _ WriteStream on: String new.
	return
		nextPutAll: '<?xml version="1.0"?>
<schemes>
'.
	schemes do: [:scheme |
		return
			nextPutAll: '<scheme name="';
			nextPutAll: (TextFormatter encodeToStrictXmlCr: (scheme at: 1));
			nextPutAll: '" next="';
			nextPutAll: (TextFormatter encodeToStrictXmlCr: (scheme at: 4));
			nextPutAll: '">';
			nextPutAll: String cr.
		"Text Forms"
		(scheme at: 2) do: [:form | return
			nextPutAll: '<form name="';
			nextPutAll: (TextFormatter encodeToStrictXmlCr: form);
			nextPutAll: '" type="text" />';
			nextPutAll: String cr].
		"Project Forms"
		(scheme at: 3) do: [:form | return
			nextPutAll: '<form name="';
			nextPutAll: (TextFormatter encodeToStrictXmlCr: form);
			nextPutAll: '" type="project" />';
			nextPutAll: String cr].
		return
			nextPutAll: '</scheme>';
			nextPutAll: String cr].
	^return
		nextPutAll: '</schemes>';
		contents! !

!SwikiSchemeReadWriter class methodsFor: 'utility'!
xmlToSchemes: xml
	| pos1 pos2 pos3 pos4 return scheme formsXml textForms projectForms |
	return _ OrderedCollection new.
	pos2 _ xml findString: '<schemes>'.
	[0 = (pos1 _ xml findString: '<scheme name="' startingAt: pos2)] whileFalse: [
		scheme _ Array new: 4.
		pos2 _ xml findString: '" next="' startingAt: pos1.
		scheme at: 1 put: (TextFormatter decodeFromXmlCr: (xml
			copyFrom: (pos1 + 14) to: (pos2 - 1))).
		pos1 _ xml findString: '">' startingAt: pos2.
		scheme at: 4 put: (TextFormatter decodeFromXmlCr: (xml
			copyFrom: (pos2 + 8) to: (pos1 -1))).
		pos2 _ xml findString: '</scheme>' startingAt: pos1.
		formsXml _ xml copyFrom: (pos1 + 2) to: (pos2 - 1).
		textForms _ OrderedCollection new.
		projectForms _ OrderedCollection new.
		pos4 _ 1.
		[0 = (pos3 _ formsXml findString:  '<form name="' startingAt: pos4)] whileFalse: [
			pos4 _ formsXml findString: '" type="' startingAt: pos3.
			(((formsXml at: (pos4 + 8)) =  $t) ifTrue: [textForms] ifFalse: [projectForms])
				add: (TextFormatter decodeFromXmlCr: (formsXml
				copyFrom: (pos3 + 12) to: (pos4 - 1)))].
		scheme
			at: 2 put: textForms;
			at: 3 put: projectForms.
		return add: scheme].
	^return! !


!SwikiSecurityMember methodsFor: 'storage'!
asXml
	| return |
	return _ '<member>', String cr.
	settings keysAndValuesDo: [:key :value | return _ return, '<m type="', (TextFormatter encodeToStrictXmlCr: key), '">', (TextFormatter encodeToXmlCr: value), '</m>', String cr].
	^return, '</member>'! !

!SwikiSecurityMember methodsFor: 'accessing'!
ip
	^(self settingsAt: 'ip' ifAbsent: [^nil]) asNumber! !

!SwikiSecurityMember methodsFor: 'accessing'!
mask
	^(self settingsAt: 'mask' ifAbsent: [^16rFFFFFFFF]) asNumber! !

!SwikiSecurityMember methodsFor: 'accessing'!
password
	^self settingsAt: 'password' ifAbsent: [nil]! !

!SwikiSecurityMember methodsFor: 'accessing'!
privileges
	^privileges! !

!SwikiSecurityMember methodsFor: 'accessing'!
privileges: privs
	privileges _ privs! !

!SwikiSecurityMember methodsFor: 'accessing'!
settingsAt: key ifAbsent: block
	^settings at: key ifAbsent: block! !

!SwikiSecurityMember methodsFor: 'accessing'!
settingsAt: key put: setting
	settings at: key put: setting! !

!SwikiSecurityMember methodsFor: 'accessing'!
user
	^self settingsAt: 'user' ifAbsent: [nil]! !

!SwikiSecurityMember methodsFor: 'testing'!
handlesBookAddress: test
	^privileges handlesBookAddress: test! !

!SwikiSecurityMember methodsFor: 'testing'!
handlesOther: test
	^privileges handlesOther: test! !

!SwikiSecurityMember methodsFor: 'testing'!
handlesPageAddress: test
	^privileges handlesPageAddress: test! !

!SwikiSecurityMember methodsFor: 'testing'!
handlesShelfAddress: test
	^privileges handlesShelfAddress: test! !

!SwikiSecurityMember methodsFor: 'initializing'!
initialize
	settings _ Dictionary new.! !


!SwikiSecurityMember class methodsFor: 'instance creation'!
fromXml: xml
	| instance pos1 pos2 type |

	instance _ self new.
	instance initialize.
	"Get Member Settings"
	pos1 _ (xml findString: '<member>') + 8.
	pos1 _ xml findString: '<m' startingAt: pos1.
	[pos1 > 0] whileTrue: [
		pos1 _ (xml findString: 'type="' startingAt: pos1) + 6.
		pos2 _ (xml findString: '"' startingAt: pos1) - 1.
		type _ TextFormatter decodeFromXmlCrlf: ((xml copyFrom: pos1 to: pos2) asLowercase).
		pos1 _ (xml findString: '>' startingAt: pos2) + 1.
		pos2 _ (xml findString: '<' startingAt: pos1) - 1.
		instance settingsAt: type put: (TextFormatter decodeFromXmlCrlf: (xml copyFrom: pos1 to: pos2)).
		pos1 _ xml findString: '<m' startingAt: pos2].
	^instance
! !

!SwikiSecurityMember class methodsFor: 'instance creation'!
new
	^super new initialize! !


!SwikiSecurityModule methodsFor: 'storage'!
asXml
	| return privDict |
	return _ '<?xml version="1.0"?>
<security>
<default priv="', (default privileges name), '" />
'.
	privDict _ Dictionary new.
	self members do: [:member | (privDict includesKey: (member privileges))
		ifTrue: [(privDict at: (member privileges)) add: member]
		ifFalse: [privDict at: (member privileges) put: (OrderedCollection with: member)]].
	privDict keysAndValuesDo: [:priv :members |
		return _ return, '<group priv="', (priv name), '">', String cr.
		members do: [:member | return _ return, member asXml, String cr].
		return _ return, '</group>', String cr].
	^return, '</security>'! !

!SwikiSecurityModule methodsFor: 'storage'!
fromXml: xml withDict: dict
	| pos1 pos2 pos3 priv members member |
	"Get Default Swiki Security Member"
	pos1 _ xml findString: '<default priv="'.
	pos2 _ xml findString: '" />' startingAt: pos1.
	default _ SwikiSecurityMember new.
	priv _ dict at: (xml copyFrom: (pos1 + 15) to: (pos2 - 1)).
	default privileges: priv.
	[(pos1 _ xml findString: '<group priv="' startingAt: pos1) = 0] whileFalse: [
		pos2 _ xml findString: '">' startingAt: pos1.
		priv _ dict at: (xml copyFrom: (pos1 + 13) to: (pos2 - 1)).
		pos1 _ xml findString: '</group>' startingAt: pos2.
		members _ xml copyFrom: (pos2 + 2) to: (pos1 - 1).
		pos3 _ 1.
		[(pos2 _ members findString: '<member>' startingAt: pos3) = 0] whileFalse: [
			pos3 _ members findString: '</member>' startingAt: pos2.
			member _ SwikiSecurityMember fromXml: (members copyFrom: pos2 to: (pos3 + 8)).
			member privileges: priv.
			self addMember: member]].! !

!SwikiSecurityModule methodsFor: 'accessing'!
aclDict
	^aclDict! !

!SwikiSecurityModule methodsFor: 'accessing'!
addACLMember: member
	aclDict at: (self class encode: (member user) password: (member password)) put: member! !

!SwikiSecurityModule methodsFor: 'accessing'!
addIPMember: member
	ipColl add: (Array with: (member mask) with: (member ip) with: member)! !

!SwikiSecurityModule methodsFor: 'accessing'!
addMember: member
	(member user) ifNotNil: [self addACLMember: member].
	(member ip) ifNotNil: [self addIPMember: member]! !

!SwikiSecurityModule methodsFor: 'accessing'!
default
	^default! !

!SwikiSecurityModule methodsFor: 'accessing'!
default: defaultMember
	default _ defaultMember! !

!SwikiSecurityModule methodsFor: 'accessing'!
ipColl
	^ipColl! !

!SwikiSecurityModule methodsFor: 'accessing'!
members
	| members |

	members _ OrderedCollection new.
	aclDict valuesDo: [:member | members add: member].
	ipColl do: [:element | (members includes: (element at: 3)) ifFalse: [
		members add: (element at: 3)]].
	^members! !

!SwikiSecurityModule methodsFor: 'initializing'!
initialize
	aclDict _ Dictionary new.
	ipColl _ OrderedCollection new! !

!SwikiSecurityModule methodsFor: 'processing'!
filterIP: request
	| ipInt |

	(ipColl size = 0) ifTrue: [^request security: default].
	ipInt _ 0.
	request user do: [:i | ipInt _ (ipInt*256) + i].
	ipColl do: [:ipArr | ((ipInt bitAnd: (ipArr at: 1)) = (ipArr at: 2))
		ifTrue: [^request security: (ipArr at: 3)]].
	^request security: default! !

!SwikiSecurityModule methodsFor: 'processing'!
process: request response: response shelf: shelf
	| address userID |	

	(address _ request address) ifNil: [address _ 'default'].
	(userID _ request userID) ifNotNil: ["Process by UserID"
		request security: (aclDict at: userID ifAbsent: [default]).
		((request fieldsHasKey: 'book')
			ifTrue: [request security handlesBookAddress: address]
			ifFalse: [request security handlesShelfAddress: address])
			ifTrue: [^true]].
	"Process by IP"
	self filterIP: request.
	^(request fieldsHasKey: 'book')
		ifTrue: [request security handlesBookAddress: address]
		ifFalse: [request security handlesShelfAddress: address]! !

!SwikiSecurityModule methodsFor: 'processing'!
process: request response: response shelf: shelf book: book
	| address userID |

	"Get Address"
	address _ request address.
	address _ (request page)
		ifNil: [(book hasBookAddress: address)
			ifTrue: [address]
			ifFalse: ['default']]
		ifNotNil: [(book hasPageAddress: address)
			ifTrue: [address]
			ifFalse: ['default']].
	(userID _ request userID) ifNotNil: ["Process by UserID"
		request security: (aclDict at: userID ifAbsent: [default]).
		((request page)
			ifNil: [request security handlesBookAddress: address]
			ifNotNil: [request security handlesPageAddress: address])
			ifTrue: [^true]].
	"Process by IP"
	self filterIP: request.
	^(request page)
		ifNil: [request security handlesBookAddress: address]
		ifNotNil: [request security handlesPageAddress: address]! !


!SwikiSecurityModule class methodsFor: 'utility'!
encode: nameString password: pwdString
	"Encode per RFC1421 of the username:password combination."

	| clear code clearSize idx map |
	clear := (nameString, ':', pwdString) asByteArray.
	clearSize := clear size.
	[ clear size \\ 3 ~= 0 ] whileTrue: [ clear := clear, #(0) ].
	idx := 1.
	map := 'ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789+/'.
	code := WriteStream on: ''.
	[ idx < clear size ] whileTrue: [ code 
		nextPut: (map at: (clear at: idx) // 4 + 1);
		nextPut: (map at: (clear at: idx) \\ 4 * 16 + ((clear at: idx + 1) // 16) + 1);
   		nextPut: (map at: (clear at: idx + 1) \\ 16 * 4 + ((clear at: idx + 2) // 64) + 1);
   		nextPut: (map at: (clear at: idx + 2) \\ 64 + 1).
		idx := idx + 3 ].
	code := code contents.
	idx := code size.
	clear size - clearSize timesRepeat: [ code at: idx put: $=. idx := idx - 1].
	^code! !

!SwikiSecurityModule class methodsFor: 'utility'!
isIpString: aString
	| tokens asNumber |
	tokens _ aString findTokens: '.'.
	(tokens size = 4) ifFalse: [^false].
	tokens do: [:token | "Check for 0..255"
		token isAllDigits ifFalse: [^false].
		asNumber _ token asNumber.
		(asNumber < 256) ifFalse: [^false].
		(asNumber >= 0) ifFalse: [^false]].
	^true! !

!SwikiSecurityModule class methodsFor: 'utility'!
toIpNumber: string
	| return |
	return _ 0.
	(string findTokens: '.') do: [:i | (i isAllDigits)
		ifTrue: [return _ (256 * return) + (i asNumber)]].
	^return! !

!SwikiSecurityModule class methodsFor: 'utility'!
toIpString: int
	| one two three four |
	two _ int // 256.
	one _ int - (256 * two).
	three _ two // 256.
	two _ two - (256 * three).
	four _ three // 256.
	three _ three - (256 * four).
	^four asString, '.', three asString, '.', two asString, '.', one asString! !

!SwikiSecurityModule class methodsFor: 'instance creation'!
fromXml: xml withDict: dict
	| instance |
	instance _ self new.
	instance fromXml: xml withDict: dict.
	^instance! !

!SwikiSecurityModule class methodsFor: 'instance creation'!
new
	^super new initialize! !


!SwikiSecurityPrivileges methodsFor: 'initializing'!
initialize
	default _ true.
	other _ OrderedCollection new.
	pageAddresses _ OrderedCollection new.
	bookAddresses _ OrderedCollection new.
	shelfAddresses _ OrderedCollection new! !

!SwikiSecurityPrivileges methodsFor: 'accessing'!
addAddress: priv
	| tokens |

	tokens _ priv findTokens: '.'.
	(tokens size = 2) ifFalse: [^false].
	((tokens at: 2) = 'page') ifTrue: [
		pageAddresses add: (tokens at: 1).
		^true].
	((tokens at: 2) = 'book') ifTrue: [
		bookAddresses add: (tokens at: 1).
		^true].
	((tokens at: 2) = 'shelf') ifTrue: [
		shelfAddresses add: (tokens at: 1).
		^true].
	^false! !

!SwikiSecurityPrivileges methodsFor: 'accessing'!
addOther: priv
	other add: priv.
	^true! !

!SwikiSecurityPrivileges methodsFor: 'accessing'!
default
	^default! !

!SwikiSecurityPrivileges methodsFor: 'accessing'!
default: aBoolean
	default _ aBoolean! !

!SwikiSecurityPrivileges methodsFor: 'accessing'!
name
	^name! !

!SwikiSecurityPrivileges methodsFor: 'accessing'!
name: aString
	name _ aString! !

!SwikiSecurityPrivileges methodsFor: 'testing'!
handlesBookAddress: test
	(bookAddresses includes: test)
		ifTrue: [^default not]
		ifFalse: [^default]! !

!SwikiSecurityPrivileges methodsFor: 'testing'!
handlesOther: test
	(other includes: test)
		ifTrue: [^default not]
		ifFalse: [^default]! !

!SwikiSecurityPrivileges methodsFor: 'testing'!
handlesPageAddress: test
	(pageAddresses includes: test)
		ifTrue: [^default not]
		ifFalse: [^default]! !

!SwikiSecurityPrivileges methodsFor: 'testing'!
handlesShelfAddress: test
	(shelfAddresses includes: test)
		ifTrue: [^default not]
		ifFalse: [^default]! !


!SwikiSecurityPrivileges class methodsFor: 'instance creation'!
named: aName default: aBoolean
	^(self new)
		initialize;
		name: aName;
		default: aBoolean;
		yourself! !


!SwikiStorage methodsFor: 'shelf (load)'!
createBook: book
	dir createDirectory: book name.
	self writeSetupForBook: book! !

!SwikiStorage methodsFor: 'shelf (load)'!
loadActionsForShelf: shelf
	| actionsDir metaColl content |
	actionsDir _ dir directoryNamed: 'default'.
	(actionsDir directoryExists: 'actions') ifFalse: [^self].
	actionsDir _ actionsDir directoryNamed: 'actions'.
	metaColl _ self getMetaCollForDir: actionsDir.
	dict at: 'actions' put: metaColl.
	metaColl do: [:arr |
		content _ (actionsDir readOnlyFileNamed: (arr at: 1)) contentsOfEntireFile.
		(arr at: 2) caseOf: {
			['book']->[shelf bookActions at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf :book | ', content , ']')].
			['shelf']->[shelf shelfActions at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf | ', content , ']')]}
			otherwise: ["ignore"]].! !

!SwikiStorage methodsFor: 'shelf (load)'!
loadAddressesForShelf: shelf
	| addressesDir metaColl content |
	addressesDir _ dir directoryNamed: 'default'.
	(addressesDir directoryExists: 'addresses') ifFalse: [^self].
	addressesDir _ addressesDir directoryNamed: 'addresses'.
	metaColl _ self getMetaCollForDir: addressesDir.
	dict at: 'addresses' put: metaColl.
	metaColl do: [:arr |
		content _ (addressesDir readOnlyFileNamed: (arr at: 1)) contentsOfEntireFile.
		(arr at: 2) caseOf: {
			['priv']->[shelf privAddresses at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf | ', content , ']')].
			['shelf']->[shelf shelfAddresses at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf | ', content , ']')]}
			otherwise: ["ignore"]].! !

!SwikiStorage methodsFor: 'shelf (load)'!
loadSettingsForShelf: shelf
	shelf settings: Dictionary new! !

!SwikiStorage methodsFor: 'shelf (load)'!
loadShelf: shelf
	self
		loadSettingsForShelf: shelf;
		loadAddressesForShelf: shelf;
		loadTemplatesForShelf: shelf;
		loadActionsForShelf: shelf! !

!SwikiStorage methodsFor: 'shelf (load)'!
loadTemplatesForShelf: shelf
	| templatesDir metaColl content |
	templatesDir _ dir directoryNamed: 'default'.
	(templatesDir directoryExists: 'templates') ifFalse: [^self].
	templatesDir _ templatesDir directoryNamed: 'templates'.
	metaColl _ self getMetaCollForDir: templatesDir.
	dict at: 'templates' put: metaColl.
	metaColl do: [:arr |
		content _ (templatesDir readOnlyFileNamed: (arr at: 1)) contentsOfEntireFile.
		"Use Internet Line Endings"
		content _ TextFormatter crToCrlf: content.
		(arr at: 2) caseOf: {
			['book']->[shelf bookTemplates at: (arr at: 3) put: content].
			['shelf']->[shelf shelfTemplates at: (arr at: 3) put: content]}
			otherwise: ["ignore"]].! !

!SwikiStorage methodsFor: 'book (load)'!
loadActionsForBook: book 
	| actionsDir metaColl content |
	(dir directoryExists: 'actions') ifFalse: [^self].
	actionsDir _ dir directoryNamed: 'actions'.
	metaColl _ self getMetaCollForDir: actionsDir.
	dict at: 'actions' put: metaColl.
	metaColl do: [:arr |
		content _ (actionsDir readOnlyFileNamed: (arr at: 1)) contentsOfEntireFile.
		(arr at: 2) caseOf: {
			['book']->[book bookActions at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf :book | ', content , ']')].
			['page']->[book pageActions at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf :book :page | ', content , ']')]}
			otherwise: ["ignore"]].! !

!SwikiStorage methodsFor: 'book (load)'!
loadAddressesForBook: book 
	| addressesDir metaColl content |
	(dir directoryExists: 'addresses') ifFalse: [^self].
	addressesDir _ dir directoryNamed: 'addresses'.
	metaColl _ self getMetaCollForDir: addressesDir.
	dict at: 'addresses' put: metaColl.
	metaColl do: [:arr |
		content _ (addressesDir readOnlyFileNamed: (arr at: 1)) contentsOfEntireFile.
		(arr at: 2) caseOf: {
			['priv']->[book privAddresses at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf :book | ', content , ']')].
			['book']->[book bookAddresses at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf :book | ', content , ']')].
			['page']->[book pageAddresses at: (arr at: 3) put: (Compiler evaluate: '[:request :response :shelf :book :page | ', content , ']')]}
			otherwise: ["ignore"]].! !

!SwikiStorage methodsFor: 'book (load)'!
loadBook: book
	self
		loadSettingsForBook: book;
		loadAddressesForBook: book;
		loadTemplatesForBook: book;
		loadActionsForBook: book! !

!SwikiStorage methodsFor: 'book (load)'!
loadSettingsForBook: book
	book rawSettings: Dictionary new! !

!SwikiStorage methodsFor: 'book (load)'!
loadTemplatesForBook: book 
	| templatesDir metaColl content |
	(dir directoryExists: 'templates') ifFalse: [^self].
	templatesDir _ dir directoryNamed: 'templates'.
	metaColl _ self getMetaCollForDir: templatesDir.
	dict at: 'templates' put: metaColl.
	metaColl do: [:arr |
		content _ (templatesDir readOnlyFileNamed: (arr at: 1)) contentsOfEntireFile.
		"Use Internet Line Endings"
		content _ TextFormatter crToCrlf: content.
		(arr at: 2) caseOf: {
			['book']->[book bookTemplates at: (arr at: 3) put: content].
			['page']->[book pageTemplates at: (arr at: 3) put: content]}
			otherwise: ["ignore"]].! !

!SwikiStorage methodsFor: 'book (load)'!
writeSettingsForBook: book! !

!SwikiStorage methodsFor: 'shelf (browser)'!
addShelfFunction: function type: type category: category
	(dict includesKey: (function, type))
		ifTrue: [(dict at: (function, type)) add: category]
		ifFalse: [dict at: (function, type) put: (OrderedCollection with: category)]! !

!SwikiStorage methodsFor: 'shelf (browser)'!
addShelfFunction: function type: type name: name
	^self addShelfFunction: function type: type name: name category: nil! !

!SwikiStorage methodsFor: 'shelf (browser)'!
addShelfFunction: function type: type name: name category: category
	| dDir fDir fileNames id coll |
	dDir _ dir directoryNamed: 'default'.
	(dDir directoryExists: function) ifFalse: [dDir createDirectory: function].	
	fDir _ dDir directoryNamed: function.
	fileNames _ fDir fileNames.
	id _ 1.
	[fileNames includes: id asString] whileTrue: [id _ id + 1].
	coll _ dict at: function ifAbsent: [dict at: function put: OrderedCollection new].
	coll add: (Array with: id asString with: type with: name with: category).
	(fDir newFileNamed: id asString) close.
	"Remove category from empty categories"
	(category notNil and: [dict includesKey: (function, type)]) ifTrue: [
		(dict at: (function, type)) remove: category ifAbsent: []].
	"Update meta and browser log files"
	self putMetaColl: coll forDir: fDir.
	self logChangeShelfFunction: function type: type name: name! !

!SwikiStorage methodsFor: 'shelf (browser)'!
allShelfFunction: function type: type
	| return |
	return _ dict at: function ifAbsent: [^OrderedCollection new].
	return _ return select: [:arr | (arr at: 2) = type] thenCollect: [:arr | arr at: 3].
	^return asSortedCollection: [:a :b | a asLowercase < b asLowercase]! !

!SwikiStorage methodsFor: 'shelf (browser)'!
ayuShelfFunction: function type: type
	"As Yet Unclassified"
	| return |
	return _ dict at: function ifAbsent: [^OrderedCollection new].
	return _ return
		select: [:arr | ((arr at: 2) = type) and: [(arr at: 4) isNil]]
		thenCollect: [:arr | arr at: 3].
	^return asSortedCollection: [:a :b | a asLowercase < b asLowercase]! !

!SwikiStorage methodsFor: 'shelf (browser)'!
categoriesShelfFunction: function type: type
	| metaColl return ayu |
	metaColl _ dict at: function ifAbsent: [^(OrderedCollection with: '-- all --')].
	ayu _ false.
	return _ SortedCollection sortBlock: [:a :b | a asLowercase < b asLowercase].
	metaColl do: [:arr | ((arr at: 2) = type) ifTrue: [(arr at: 4)
		ifNil: [ayu _ true]
		ifNotNil: [(return includes: (arr at: 4)) ifFalse: [
			return add: (arr at: 4)]]]].
	"Add Empty Categories"
	(dict includesKey: (function, type)) ifTrue: [
		(dict at: (function, type)) do: [:cat |
			(return includes: cat) ifFalse: [return add: cat]]].
	return _ return asOrderedCollection.
	return addFirst: '-- all --'.
	ayu ifTrue: [return add: 'as yet unclassified'].
	^return! !

!SwikiStorage methodsFor: 'shelf (browser)'!
deleteShelfFunction: function type: type category: category
	| coll |
	coll _ dict at: function.
	coll do: [:arr | ((arr at: 4) = category) ifTrue: [
		arr at: 4 put: nil]].
	self putMetaColl: coll forDir: ((dir directoryNamed: 'default') directoryNamed: function).! !

!SwikiStorage methodsFor: 'shelf (browser)'!
deleteShelfFunction: function type: type name: name
	| coll fDir |
	coll _ OrderedCollection new.
	fDir _ (dir directoryNamed: 'default') directoryNamed: function.
	(dict at: function) do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name])
		ifTrue: [fDir deleteFileNamed: (arr at: 1)]
		ifFalse: [coll add: arr]].
	dict at: function put: coll.
	"Update meta and browser log files"
	self putMetaColl: coll forDir: fDir.
	self logDeleteShelfFunction: function type: type name: name! !

!SwikiStorage methodsFor: 'shelf (browser)'!
moveShelfFunction: function type: type name: name
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name])
		ifTrue: [arr at: 4 put: nil]].
	self putMetaColl: coll forDir: ((dir directoryNamed: 'default') directoryNamed: function)! !

!SwikiStorage methodsFor: 'shelf (browser)'!
moveShelfFunction: function type: type name: name toCategory: category
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name])
		ifTrue: [arr at: 4 put: category]].
	self putMetaColl: coll forDir: ((dir directoryNamed: 'default') directoryNamed: function)! !

!SwikiStorage methodsFor: 'shelf (browser)'!
renameShelfFunction: function type: type category: fromName to: toName
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 4) = fromName])
		ifTrue: [arr at: 4 put: toName]].
	self putMetaColl: coll forDir: ((dir directoryNamed: 'default') directoryNamed: function)! !

!SwikiStorage methodsFor: 'shelf (browser)'!
renameShelfFunction: function type: type name: fromName to: toName
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = fromName])
		ifTrue: [arr at: 3 put: toName]].
	"Update meta and browser log files"
	self putMetaColl: coll forDir: ((dir directoryNamed: 'default') directoryNamed: function).
	self logDeleteShelfFunction: function type: type name: fromName.
	self logChangeShelfFunction: function type: type name: toName! !

!SwikiStorage methodsFor: 'shelf (browser)'!
shelfFunction: function type: type category: category
	| return |
	return _ dict at: function ifAbsent: [^OrderedCollection new].
	return _ return
		select: [:arr | ((arr at: 2) = type) and: [(arr at: 4) = category]]
		thenCollect: [:arr | arr at: 3].
	^return asSortedCollection: [:a :b | a asLowercase < b asLowercase]! !

!SwikiStorage methodsFor: 'shelf (browser)'!
shelfFunction: function type: type name: name
	| coll |
	coll _ dict at: function ifAbsent: [
		self error: (function, ' does not contain ', name, ' of type ', type)].
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name]) ifTrue: [
		^(((dir directoryNamed: 'default') directoryNamed: function) readOnlyFileNamed: (arr at: 1))
			contentsOfEntireFile]]! !

!SwikiStorage methodsFor: 'shelf (browser)'!
shelfFunction: function type: type name: name content: content
	| coll fDir file |
	coll _ dict at: function ifAbsent: [
		self error: (function, ' does not contain ', name, ' of type ', type)].
	fDir _ (dir directoryNamed: 'default') directoryNamed: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name]) ifTrue: [
		fDir deleteFileNamed: (arr at: 1).
		file _ fDir newFileNamed: (arr at: 1).
		file nextPutAll: content.
		file close.
		"Update browser log"
		self logChangeShelfFunction: function type: type name: name]]! !

!SwikiStorage methodsFor: 'accessing'!
dir
	^dir! !

!SwikiStorage methodsFor: 'accessing'!
dir: aFileDirectory
	dir _ aFileDirectory.
	dict _ Dictionary new! !

!SwikiStorage methodsFor: 'book (logging)'!
logChangeBookFunction: function type: type name: name
	(dir fileNamed: 'browser.log')
		setToEnd;
		nextPutAll: (Date today asString);
		nextPut: Character tab;
		nextPutAll: (Time now asString);
		nextPut: Character tab;
		nextPutAll: 'changeBookFunction';
		nextPut: Character tab;
		nextPutAll: function;
		nextPut: Character tab;
		nextPutAll: type;
		nextPut: Character tab;
		nextPutAll: name;
		nextPut: Character cr;
		close
! !

!SwikiStorage methodsFor: 'book (logging)'!
logDeleteBookFunction: function type: type name: name
	(dir fileNamed: 'browser.log')
		setToEnd;
		nextPutAll: (Date today asString);
		nextPut: Character tab;
		nextPutAll: (Time now asString);
		nextPut: Character tab;
		nextPutAll: 'deleteBookFunction';
		nextPut: Character tab;
		nextPutAll: function;
		nextPut: Character tab;
		nextPutAll: type;
		nextPut: Character tab;
		nextPutAll: name;
		nextPut: Character cr;
		close
! !

!SwikiStorage methodsFor: 'book (browser)'!
addBookFunction: function type: type category: category
	(dict includesKey: (function, type))
		ifTrue: [(dict at: (function, type)) add: category]
		ifFalse: [dict at: (function, type) put: (OrderedCollection with: category)]! !

!SwikiStorage methodsFor: 'book (browser)'!
addBookFunction: function type: type name: name
	^self addBookFunction: function type: type name: name category: nil! !

!SwikiStorage methodsFor: 'book (browser)'!
addBookFunction: function type: type name: name category: category
	| fDir fileNames id coll |
	(dir directoryExists: function) ifFalse: [dir createDirectory: function].	
	fDir _ dir directoryNamed: function.
	fileNames _ fDir fileNames.
	id _ 1.
	[fileNames includes: id asString] whileTrue: [id _ id + 1].
	coll _ dict at: function ifAbsent: [dict at: function put: OrderedCollection new].
	coll add: (Array with: id asString with: type with: name with: category).
	(fDir newFileNamed: id asString) close.
	"Remove category from empty categories"
	(category notNil and: [dict includesKey: (function, type)]) ifTrue: [
		(dict at: (function, type)) remove: category ifAbsent: []].
	"Update meta and browser log files"
	self putMetaColl: coll forDir: fDir.
	self logChangeBookFunction: function type: type name: name! !

!SwikiStorage methodsFor: 'book (browser)'!
allBookFunction: function type: type
	| return |
	return _ dict at: function ifAbsent: [^OrderedCollection new].
	return _ return select: [:arr | (arr at: 2) = type] thenCollect: [:arr | arr at: 3].
	^return asSortedCollection: [:a :b | a asLowercase < b asLowercase]
! !

!SwikiStorage methodsFor: 'book (browser)'!
ayuBookFunction: function type: type
	"As Yet Unclassified"
	| return |
	return _ dict at: function ifAbsent: [^OrderedCollection new].
	return _ return
		select: [:arr | ((arr at: 2) = type) and: [(arr at: 4) isNil]]
		thenCollect: [:arr | arr at: 3].
	^return asSortedCollection: [:a :b | a asLowercase < b asLowercase]! !

!SwikiStorage methodsFor: 'book (browser)'!
bookFunction: function type: type category: category
	| return |
	return _ dict at: function ifAbsent: [^OrderedCollection new].
	return _ return
		select: [:arr | ((arr at: 2) = type) and: [(arr at: 4) = category]]
		thenCollect: [:arr | arr at: 3].
	^return asSortedCollection: [:a :b | a asLowercase < b asLowercase]! !

!SwikiStorage methodsFor: 'book (browser)'!
bookFunction: function type: type name: name
	| coll |
	coll _ dict at: function ifAbsent: [
		self error: (function, ' does not contain ', name, ' of type ', type)].
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name]) ifTrue: [
		^((dir directoryNamed: function) readOnlyFileNamed: (arr at: 1))
			contentsOfEntireFile]]! !

!SwikiStorage methodsFor: 'book (browser)'!
bookFunction: function type: type name: name content: content
	| coll fDir file |
	coll _ dict at: function ifAbsent: [
		self error: (function, ' does not contain ', name, ' of type ', type)].
	fDir _ dir directoryNamed: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name]) ifTrue: [
		fDir deleteFileNamed: (arr at: 1).
		file _ fDir newFileNamed: (arr at: 1).
		file nextPutAll: content.
		file close.
		"Update browser log"
		self logChangeBookFunction: function type: type name: name]]! !

!SwikiStorage methodsFor: 'book (browser)'!
categoriesBookFunction: function type: type
	| metaColl return ayu |
	metaColl _ dict at: function ifAbsent: [^(OrderedCollection with: '-- all --')].
	ayu _ false.
	return _ SortedCollection sortBlock: [:a :b | a asLowercase < b asLowercase].
	metaColl do: [:arr | ((arr at: 2) = type) ifTrue: [(arr at: 4)
		ifNil: [ayu _ true]
		ifNotNil: [(return includes: (arr at: 4)) ifFalse: [
			return add: (arr at: 4)]]]].
	"Add Empty Categories"
	(dict includesKey: (function, type)) ifTrue: [
		(dict at: (function, type)) do: [:cat |
			(return includes: cat) ifFalse: [return add: cat]]].
	return _ return asOrderedCollection.
	return addFirst: '-- all --'.
	ayu ifTrue: [return add: 'as yet unclassified'].
	^return! !

!SwikiStorage methodsFor: 'book (browser)'!
deleteBookFunction: function type: type category: category
	| coll |
	coll _ dict at: function.
	coll do: [:arr | ((arr at: 4) = category) ifTrue: [
		arr at: 4 put: nil]].
	self putMetaColl: coll forDir: (dir directoryNamed: function).! !

!SwikiStorage methodsFor: 'book (browser)'!
deleteBookFunction: function type: type name: name
	| coll fDir |
	coll _ OrderedCollection new.
	fDir _ dir directoryNamed: function.
	(dict at: function) do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name])
		ifTrue: [fDir deleteFileNamed: (arr at: 1)]
		ifFalse: [coll add: arr]].
	dict at: function put: coll.
	"Update meta and browser log files"
	self putMetaColl: coll forDir: fDir.
	self logDeleteBookFunction: function type: type name: name! !

!SwikiStorage methodsFor: 'book (browser)'!
moveBookFunction: function type: type name: name
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name])
		ifTrue: [arr at: 4 put: nil]].
	self putMetaColl: coll forDir: (dir directoryNamed: function)! !

!SwikiStorage methodsFor: 'book (browser)'!
moveBookFunction: function type: type name: name toCategory: category
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = name])
		ifTrue: [arr at: 4 put: category]].
	self putMetaColl: coll forDir: (dir directoryNamed: function)! !

!SwikiStorage methodsFor: 'book (browser)'!
renameBookFunction: function type: type category: fromName to: toName
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 4) = fromName])
		ifTrue: [arr at: 4 put: toName]].
	self putMetaColl: coll forDir: (dir directoryNamed: function)! !

!SwikiStorage methodsFor: 'book (browser)'!
renameBookFunction: function type: type name: fromName to: toName
	| coll |
	coll _ dict at: function.
	coll do: [:arr | (((arr at: 2) = type) and: [(arr at: 3) = fromName])
		ifTrue: [arr at: 3 put: toName]].
	"Update meta and browser log files"
	self putMetaColl: coll forDir: (dir directoryNamed: function).
	self logDeleteBookFunction: function type: type name: fromName.
	self logChangeBookFunction: function type: type name: toName! !

!SwikiStorage methodsFor: 'pages'!
multipleTextFrom: aPage
	^self subclassResponsibility
! !

!SwikiStorage methodsFor: 'pages'!
simpleTextFrom: aPage
	^self subclassResponsibility
! !

!SwikiStorage methodsFor: 'pages'!
textFrom: aPage
	| text |
	text _ aPage rawText.
	(text isKindOf: Array) ifTrue: [^self simpleTextFrom: aPage].
	(text isKindOf: Dictionary) ifTrue: [^self multipleTextFrom: aPage].
	^''
! !

!SwikiStorage methodsFor: 'private'!
getMetaCollForDir: aDir
	self subclassResponsibility! !

!SwikiStorage methodsFor: 'private'!
putMetaColl: coll forDir: aDir
	self subclassResponsibility! !

!SwikiStorage methodsFor: 'shelf (logging)'!
logChangeShelfFunction: function type: type name: name
	((dir directoryNamed: 'default') fileNamed: 'browser.log')
		setToEnd;
		nextPutAll: (Date today asString);
		nextPut: Character tab;
		nextPutAll: (Time now asString);
		nextPut: Character tab;
		nextPutAll: 'changeShelfFunction';
		nextPut: Character tab;
		nextPutAll: function;
		nextPut: Character tab;
		nextPutAll: type;
		nextPut: Character tab;
		nextPutAll: name;
		nextPut: Character cr;
		close
! !

!SwikiStorage methodsFor: 'shelf (logging)'!
logDeleteShelfFunction: function type: type name: name
	((dir directoryNamed: 'default') fileNamed: 'browser.log')
		setToEnd;
		nextPutAll: (Date today asString);
		nextPut: Character tab;
		nextPutAll: (Time now asString);
		nextPut: Character tab;
		nextPutAll: 'deleteShelfFunction';
		nextPut: Character tab;
		nextPutAll: function;
		nextPut: Character tab;
		nextPutAll: type;
		nextPut: Character tab;
		nextPutAll: name;
		nextPut: Character cr;
		close
! !


!SwikiStorage class methodsFor: 'testing class hierarchy'!
handlesBookStorage
	^false! !

!SwikiStorage class methodsFor: 'testing class hierarchy'!
handlesPageStorage
	^false! !

!SwikiStorage class methodsFor: 'instance creation'!
fromDir: aFileDirectory
	^self new dir: aFileDirectory! !


!SwikiStructure methodsFor: 'accessing'!
name
	^name! !

!SwikiStructure methodsFor: 'accessing'!
name: aString
	name _ aString! !

!SwikiStructure methodsFor: 'settings'!
settings
	^settings! !

!SwikiStructure methodsFor: 'settings'!
settings: anObject
	settings _ anObject! !

!SwikiStructure methodsFor: 'settings'!
settingsAt: key
	^settings at: key! !

!SwikiStructure methodsFor: 'settings'!
settingsAt: key ifAbsent: block
	^settings at: key ifAbsent: block! !

!SwikiStructure methodsFor: 'settings'!
settingsAt: key put: value
	^settings at: key put: value! !

!SwikiStructure methodsFor: 'settings'!
settingsIncludes: key
	^settings includesKey: key! !

!SwikiStructure methodsFor: 'settings'!
settingsRemove: key
	^settings removeKey: key ifAbsent: []! !

!SwikiStructure methodsFor: 'storage'!
critical: aBlock
	^sema critical: aBlock! !

!SwikiStructure methodsFor: 'storage'!
forbidWriting
	sema wait! !

!SwikiStructure methodsFor: 'storage'!
permitWriting
	sema signal! !

!SwikiStructure methodsFor: 'storage'!
storage
	^storage! !

!SwikiStructure methodsFor: 'storage'!
storage: aSwikiStorage
	storage _ aSwikiStorage! !

!SwikiStructure methodsFor: 'modules'!
modules
	^modules! !

!SwikiStructure methodsFor: 'modules'!
modules: anObject
	modules _ anObject! !

!SwikiStructure methodsFor: 'modules'!
modulesAt: key
	^modules at: key! !

!SwikiStructure methodsFor: 'modules'!
modulesAt: key ifAbsent: block
	^modules at: key ifAbsent: block! !

!SwikiStructure methodsFor: 'modules'!
modulesAt: key put: value
	modules at: key put: value! !

!SwikiStructure methodsFor: 'modules'!
modulesIncludes: key
	^modules includesKey: key! !

!SwikiStructure methodsFor: 'modules'!
modulesRemove: key
	^modules removeKey: key ifAbsent: []! !

!SwikiStructure methodsFor: 'utility'!
asExplorerString
	^super asExplorerString, '--', name! !

!SwikiStructure methodsFor: 'utility'!
defaultLabelForInspector
	^super defaultLabelForInspector, ': ', name! !

!SwikiStructure methodsFor: 'initialization'!
initialize
	modules _ Dictionary new.
	settings _ Dictionary new.
	sema _ Semaphore forMutualExclusion! !


!NuSwikiPage methodsFor: 'formatters'!
appendFormat: oldText request: request response: response shelf: shelf book: book
	| formatter newText |

	"is a form"
	(self isAForm) ifTrue: [^self formAppendFormat: oldText request: request response: response shelf: shelf book: book].
	"is not a form"
	formatter _ self settingsAt: 'appendFormatter' ifAbsent: [book settingsAt: 'appendFormatter' ifAbsent: [^nil]].
	newText _ (formatter format: oldText request: request response: response shelf: shelf book: book page: self).
	"delete extra cr formed from appendFormatter"
	(newText endsWith: String cr) ifTrue: [(newText size > 1) ifTrue: [
		newText _ newText copyFrom: 1 to: (newText size - 1)]].
	^self text: newText! !

!NuSwikiPage methodsFor: 'formatters'!
appendFormatRequest: request response: response shelf: shelf book: book
	^self appendFormat: (self text) request: request response: response shelf: shelf book: book! !

!NuSwikiPage methodsFor: 'formatters'!
editFormat: aString request: request response: response shelf: shelf book: book
	| formatter |

	formatter _ self settingsAt: 'editFormatter' ifAbsent: [book settingsAt: 'editFormatter' ifAbsent: [^aString]].
	^formatter format: aString request: request response: response shelf: shelf book: book page: self! !

!NuSwikiPage methodsFor: 'formatters'!
editFormatRequest: request response: response shelf: shelf book: book
	^self editFormat: (self text) request: request response: response shelf: shelf book: book! !

!NuSwikiPage methodsFor: 'formatters'!
formAppendFormat: texts request: request response: response shelf: shelf book: book
	| formatter newText element |

	formatter _ self settingsAt: 'appendFormatter' ifAbsent: [book settingsAt: 'appendFormatter' ifAbsent: [^nil]].
	newText _ Dictionary new.
	texts keysAndValuesDo: [:key :value |
		request settingsRemove: 'appendId'.
		request settingsAt: 'formId' put: key.
		element _ (formatter format: value request: request response: response shelf: shelf book: book page: self).
		"delete extra cr formed from appendFormatter"
		(element endsWith: String cr) ifTrue: [(element size > 1) ifTrue: [
			element _ element copyFrom: 1 to: (element size - 1)]].
		newText at: key put: element].
	^self text: newText! !

!NuSwikiPage methodsFor: 'formatters'!
formSaveFormat: texts request: request response: response shelf: shelf book: book
	| formatter newText |

	formatter _ self settingsAt: 'saveFormatter' ifAbsent: [book settingsAt: 'saveFormatter' ifAbsent: [^nil]].
	newText _ Dictionary new.
	texts keysAndValuesDo: [:key :value | value translateWith: BadCharTable. "Fix for Lynx"
		newText at: key put: (formatter format: value request: request response: response shelf: shelf book: book page: self)].
	^self text: newText! !

!NuSwikiPage methodsFor: 'formatters'!
formUpdateFormat: texts request: request response: response shelf: shelf book: book
	| formatter newText |

	formatter _ self settingsAt: 'updateFormatter' ifAbsent: [book settingsAt: 'updateFormatter' ifAbsent: [^nil]].
	newText _ Dictionary new.
	texts keysAndValuesDo: [:key :value | newText at: key put: (formatter format: value request: request response: response shelf: shelf book: book page: self)].
	self text: newText.
	[self write] fork
! !

!NuSwikiPage methodsFor: 'formatters'!
renderFormat: aString request: request response: response shelf: shelf book: book
	| formatter |

	formatter _ self settingsAt: 'renderFormatter' ifAbsent: [book settingsAt: 'renderFormatter' ifAbsent: [^aString]].
	^formatter format: aString request: request response: response shelf: shelf book: book page: self! !

!NuSwikiPage methodsFor: 'formatters'!
renderFormatRequest: request response: response shelf: shelf book: book
	^self renderFormat: (self text) request: request response: response shelf: shelf book: book! !

!NuSwikiPage methodsFor: 'formatters'!
saveFormat: newText request: request response: response shelf: shelf book: book
	| formatter |

	(self class isFormText: newText) ifTrue: [^self formSaveFormat: newText request: request response: response shelf: shelf book: book].
	formatter _ self settingsAt: 'saveFormatter' ifAbsent: [book settingsAt: 'saveFormatter' ifAbsent: [^nil]].
	newText translateWith: BadCharTable. "Fix for Lynx"
	^self text: (formatter format: newText request: request response: response shelf: shelf book: book page: self)! !

!NuSwikiPage methodsFor: 'formatters'!
showFormat: aString request: request response: response shelf: shelf book: book
	| formatter |
	formatter _ self settingsAt: 'showFormatter' ifAbsent: [book settingsAt: 'showFormatter' ifAbsent: [^aString]].
	^formatter format: aString request: request response: response shelf: shelf book: book page: self! !

!NuSwikiPage methodsFor: 'formatters'!
showFormatRequest: request response: response shelf: shelf book: book
	^self showFormat: self text request: request response: response shelf: shelf book: book! !

!NuSwikiPage methodsFor: 'formatters'!
updateFormat: updateText request: request response: response shelf: shelf book: book
	| formatter |

	"is a form"
	(self isAForm) ifTrue: [^self formUpdateFormat: updateText request: request response: response shelf: shelf book: book].
	"is not a form"
	formatter _ self settingsAt: 'updateFormatter' ifAbsent: [book settingsAt: 'updateFormatter' ifAbsent: [^nil]].
	self text: (formatter format: updateText request: request response: response shelf: shelf book: book page: self).
	self write! !

!NuSwikiPage methodsFor: 'formatters'!
updateFormatRequest: request response: response shelf: shelf book: book
	^self updateFormat: self text request: request response: response shelf: shelf book: book! !

!NuSwikiPage methodsFor: 'accessing'!
date
	^date! !

!NuSwikiPage methodsFor: 'accessing'!
date: aDate
	date _ aDate! !

!NuSwikiPage methodsFor: 'accessing'!
editName
	| return |
	return _ self name.
	(self settingsIncludes: 'showName') ifTrue: [
		return _ return, '>', (self settingsAt: 'showName')].
	^TextFormatter encodeToStrictXmlCrlf: return! !

!NuSwikiPage methodsFor: 'accessing'!
id
	^id! !

!NuSwikiPage methodsFor: 'accessing'!
id: anInteger
	id _ anInteger! !

!NuSwikiPage methodsFor: 'accessing'!
printDate
	^self class printDate: date! !

!NuSwikiPage methodsFor: 'accessing'!
printDateForRSS
	^String streamContents: [:stream |
		date dayMonthYearDo: [:day :month :year | stream
			nextPutAll: year asString;
			nextPut: $-;
			nextPutAll: month asString;
			nextPut: $-;
			nextPutAll: day asString]]! !

!NuSwikiPage methodsFor: 'accessing'!
printTime
	^self class printTime: time! !

!NuSwikiPage methodsFor: 'accessing'!
rawText
	^text! !

!NuSwikiPage methodsFor: 'accessing'!
showName
	^(self settingsIncludes: 'showName')
		ifTrue: [self settingsAt: 'showName']
		ifFalse: [self showName: name]! !

!NuSwikiPage methodsFor: 'accessing'!
showName: theText
	^PageFormatter toSafeAlias: theText! !

!NuSwikiPage methodsFor: 'accessing'!
showNameCroppedTo: maximumLength
	| croppedName |
	croppedName _ (name size > maximumLength)
		ifTrue: [(name copyFrom: 1 to: (maximumLength - 2)), '...']
		ifFalse: [name].
	^self showName: croppedName! !

!NuSwikiPage methodsFor: 'accessing'!
showStrictName
	^PageFormatter toStrictSafeAlias: name! !

!NuSwikiPage methodsFor: 'accessing'!
storage
	^storage! !

!NuSwikiPage methodsFor: 'accessing'!
storage: aSwikiStorage
	storage _ aSwikiStorage! !

!NuSwikiPage methodsFor: 'accessing'!
text
	^(text isKindOf: String)
		ifTrue: [text]
		ifFalse: [(text isKindOf: Dictionary)
			ifTrue: [((text values at: 1) isKindOf: String)
				ifTrue: [text]
				ifFalse: [storage textFrom: self]]
			ifFalse: [storage textFrom: self]]! !

!NuSwikiPage methodsFor: 'accessing'!
text: anObject
	text _ anObject! !

!NuSwikiPage methodsFor: 'accessing'!
textKey: key
	^(text isKindOf: Dictionary)
		ifTrue: [((text values at: 1) isKindOf: String)
			ifTrue: [text at: key ifAbsent: ['']]
			ifFalse: [storage textKey: key from: self]]
		ifFalse: ['']! !

!NuSwikiPage methodsFor: 'accessing'!
time
	^time! !

!NuSwikiPage methodsFor: 'accessing'!
time: aTime
	time _ aTime! !

!NuSwikiPage methodsFor: 'accessing'!
user
	^user! !

!NuSwikiPage methodsFor: 'accessing'!
user: aString
	user _ aString! !

!NuSwikiPage methodsFor: 'accessing'!
versionId
	^versionId! !

!NuSwikiPage methodsFor: 'accessing'!
versionId: anInteger
	"0 means current version"
	versionId _ anInteger! !

!NuSwikiPage methodsFor: 'storage'!
backup
	storage backupPage: self! !

!NuSwikiPage methodsFor: 'storage'!
version: vid
	"Returns the XmlSwikiPage version.
	If the version does not exist, return nil."
	| version |
	(vid > 0) ifFalse: [^nil].
	version _ self class new id: id; versionId: vid; storage: storage.
	(storage loadPage: version) ifNil: [^nil].
	^version! !

!NuSwikiPage methodsFor: 'storage'!
versions
	^storage loadVersionsFrom: self! !

!NuSwikiPage methodsFor: 'storage'!
wipe
	storage wipePage: self! !

!NuSwikiPage methodsFor: 'storage'!
write
	storage writePage: self! !

!NuSwikiPage methodsFor: 'utility (ani)'!
accessControl
	^self modulesAt: 'ac'! !

!NuSwikiPage methodsFor: 'utility (ani)'!
accessControl: anAniAccess
	self modulesAt: 'ac' put: anAniAccess! !

!NuSwikiPage methodsFor: 'utility (ani)'!
hasParent
	^self settingsIncludes: 'parent'! !

!NuSwikiPage methodsFor: 'utility (ani)'!
inheritance
	| return currentPage |
	return _ OrderedCollection new.
	currentPage _ self.
	[currentPage notNil] whileTrue: [
		return add: currentPage.
		currentPage _ currentPage parent].
	^return! !

!NuSwikiPage methodsFor: 'utility (ani)'!
inheritsAccessControl
	self hasParent ifFalse: [^false].
	^(self settingsIncludes: 'acAll') not! !

!NuSwikiPage methodsFor: 'utility (ani)'!
newParent: newParent
	"If it is the same, do nothing"
	(newParent = self parent) ifTrue: [^self].
	newParent
		ifNil: ["Remove the Parent"
			self settingsRemove: 'parent'.
			self modulesRemove: 'parent']
		ifNotNil: ["Change Parent"
			"Check to make sure that there is no circular parentage"
			(newParent inheritance includes: self) ifTrue: [^self].
			self settingsAt: 'parent' put: newParent id.
			self parent: newParent].
	"reinitialize access control if necessary"
	self inheritsAccessControl ifTrue: [self
		modulesRemove: 'ac';
		initializeAccessControl].! !

!NuSwikiPage methodsFor: 'utility (ani)'!
parent: aSwikiPage
	self modulesAt: 'parent' put: aSwikiPage! !

!NuSwikiPage methodsFor: 'utility (ani)'!
parentId
	^self settingsAt: 'parent'! !

!NuSwikiPage methodsFor: 'testing'!
isAForm
	^storage isAComplexPage: self! !

!NuSwikiPage methodsFor: 'testing'!
textContains: aString caseSensitive: caseSensitive
	| tempText |

	tempText _ self text.
	(tempText isKindOf: Dictionary)
		ifTrue: [tempText valuesDo: [:value | (value includesSubstring: aString caseSensitive: caseSensitive) ifTrue: [^true]].
			^false]
		ifFalse: [^tempText  includesSubstring: aString caseSensitive: caseSensitive]! !

!NuSwikiPage methodsFor: 'utility'!
alertsFrom: request
	| tokens alerts |

	tokens _ (request fieldsKey: 'alerts') findTokens: String crlf, ' ;,'.
	(tokens size > 0)
		ifTrue: [self settingsAt: 'alerts' put: ((tokens size = 1)
			ifTrue: [tokens at: 1]
			ifFalse: [alerts _ tokens at: 1.
				2 to: (tokens size) do: [:i | alerts _ alerts, ', ', (tokens at: i)].
				alerts])]
		ifFalse: [self settingsRemove: 'alerts'].! !

!NuSwikiPage methodsFor: 'utility'!
clearRefsCache
	settings removeKey: 'referenceCache' ifAbsent: []! !

!NuSwikiPage methodsFor: 'utility'!
defaultLabelForInspector
	^ super defaultLabelForInspector, ': ', id asString! !

!NuSwikiPage methodsFor: 'utility'!
isOKtoSaveFrom: request
	request hasTextKeys ifFalse: [^false].
	^self isText! !

!NuSwikiPage methodsFor: 'utility'!
isOlderThan: request
	| editTime |

	editTime _ request fieldsAsNumberKey: 'edittime' ifAbsent: [^true].
	editTime _ Time dateAndTimeFromSeconds: editTime.
	((editTime at: 1) < date) ifTrue: [^false].
	((editTime at: 1) = date) ifTrue: [((editTime at: 2) < time) ifTrue: [^false]].
	^true! !

!NuSwikiPage methodsFor: 'utility'!
isText
	^self settingsAt: 'isText' ifAbsent: [true]! !

!NuSwikiPage methodsFor: 'utility'!
lastVersionsNotUser: badUser
	self versions reverseDo: [:version |
		(version user = badUser) ifFalse: [^version]].
	^nil! !

!NuSwikiPage methodsFor: 'utility'!
lastVersionsNotUsers: badUserSet
	self versions reverseDo: [:version |
		(badUserSet includes: version user) ifFalse: [^version]].
	^nil! !

!NuSwikiPage methodsFor: 'utility'!
lockState
	(self settingsAt: 'lock' ifAbsent: [false]) ifTrue: [^#Locked].
	(self settingsAt: 'open' ifAbsent: [false]) ifTrue: [^#Open].
	^#Unlocked! !

!NuSwikiPage methodsFor: 'utility'!
lockStateString
	(self settingsAt: 'lock' ifAbsent: [false]) ifTrue: [^'Locked'].
	(self settingsAt: 'open' ifAbsent: [false]) ifTrue: [^'Open'].
	^'Unlocked'! !

!NuSwikiPage methodsFor: 'utility'!
nameUnique: aString book: book
	"First, strip aString of anything that would be bad."
	"Then, name the page uniquely."
	| stripped copy split showName |

	split _ aString findString: '>'.
	(split < 2)
		ifTrue: ["No alias"
			stripped _ NuSwikiPage safePageNameFor: aString.
			self settingsRemove: 'showName']
		ifFalse: ["Name of page includes an alias"
			stripped _ aString copyFrom: 1 to: (split - 1).
			stripped _ NuSwikiPage safePageNameFor: stripped.
			(aString size > split)
				ifTrue: [
					showName _ aString copyFrom: (split + 1) to: (aString size).
					self settingsAt: 'showName' put: showName]
				ifFalse: [
					self settingsRemove: 'showName']].
	"Check for aString to be empty"
	stripped isEmpty ifTrue: [
		copy _ 1.
		[book hasPageNamed: ('#', copy asString)] whileTrue: [copy _ copy + 1].
		self name: ('#', copy asString).
		^self].
	"Only change the name if it isn't the same"
	(stripped = name) ifTrue: [^self].
	"Check if the page already exists"
	(book hasPageNamed: stripped) ifTrue: ["Check for names of aString, ' #X'."
		copy _ 2.
		[book hasPageNamed: (stripped, ' #', copy asString)] whileTrue: [copy _ copy + 1].
		stripped _ stripped, ' #', copy asString].
	book renamePage: self to: stripped! !

!NuSwikiPage methodsFor: 'utility'!
passwordFrom: request response: response shelf: shelf book: book
	| password |

	password _ request fieldsKey: 'password'
		ifAbsent: [^self "Need a password to effectively run this"].
	(request fieldsKey: 'lock') caseOf: {
		['unlocked']->["Remove all locks"
			self settingsRemove: 'lock'.
			self settingsRemove: 'open'.
			self settingsRemove: 'lockPassword'].
		['locked']->["Add a lock"
			self settingsAt: 'lock' put: true.
			self settingsRemove: 'open'.
			"If it is using the admin password, then don't store the password"
			(password = (book modulesAt: 'lockPassword' ifAbsent: [nil]))
				ifTrue: [self settingsRemove: 'lockPassword']
				ifFalse: [self settingsAt: 'lockPassword' put: password]].
		['open']->["Add an open block"
			self settingsRemove: 'lock'.
			self settingsAt: 'open' put: true.
			"If it is using the admin password, then don't store the password"
			(password = (book modulesAt: 'lockPassword' ifAbsent: [nil]))
				ifTrue: [self settingsRemove: 'lockPassword']
				ifFalse: [self settingsAt: 'lockPassword' put: password]]}
		otherwise: ["This should not happen, so ignore it"].! !

!NuSwikiPage methodsFor: 'utility'!
passwordMatches: request response: response shelf: shelf book: book
	| password |

	password _ request fieldsKey: 'password' ifAbsent: [^false].
	(self settingsIncludes: 'lockPassword')
		ifTrue: [((self settingsAt: 'lockPassword') = password) ifTrue: [^true]].
	((book modulesAt: 'lockPassword') = password) ifTrue: [^true].
	^false! !

!NuSwikiPage methodsFor: 'utility'!
reverseVersionsUsing: block
	| versions return size |

	versions _ self versions.
	size _ versions size.
	(size = 0) ifTrue: [^''].
	return _ WriteStream on: String new.
	1 to: size do: [:i | return nextPutAll: (block value: (versions at: (size + 1 - i)))].
	^return contents! !

!NuSwikiPage methodsFor: 'utility'!
revertTo: anotherPageVersion book: book
	self
		nameUnique: (anotherPageVersion name) book: book;
		date: anotherPageVersion date;
		time: anotherPageVersion time;
		user: anotherPageVersion user;
		text: anotherPageVersion text;
		settings: anotherPageVersion settings! !

!NuSwikiPage methodsFor: 'utility'!
sendAlerts: request response: response shelf: shelf book: book
	| sender alertText server receivers |

	"Try to send alerts only if there are receivers"
	receivers _ (settings at: 'alerts' ifAbsent: [^self]) findTokens: ', '.
	receivers isEmpty ifTrue: [^self].

	sender _ self settingsAt: 'alertSender' ifAbsent: [
		book settingsAt: 'alertSender' ifAbsent: [^self]].
	server _ self settingsAt: 'alertServer' ifAbsent: [
		book settingsAt: 'alertServer' ifAbsent: [^self]].
	alertText _ TextFormatter crlfToCr: (book formatPageTemplate: 'alert' request: request response: response shelf: shelf page: self).
	[SMTPClient deliverMailFrom: sender to: receivers text: alertText usingServer: server]
		ifError: [:a :b | "No error for bad e-mail addresses"]
! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
accessLevelForRequest: request
	^self accessControl accessLevelForRequest: request! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
alerts
	^self modulesAt: 'alerts'! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
alerts: coll
	self modulesAt: 'alerts' put: coll! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
alertsIncludesUser: aniUser
	^self alerts includes: aniUser id! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
alertsInheritsForUser: aniUser
	| userId alerts |
	userId _ (aniUser id) asString.
	alerts _ self settingsAt: 'alerts' ifAbsent: [^true].
	(alerts findTokens: ' 	') do: [:token |
		(((token findTokens: '->') at: 1) = userId) ifTrue: [^false]].
	^true! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
childrenInBook: book
	^book pages select: [:page | page parent = self]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
initializeAccessControl
	"check to see whether it has already been initialized"
	(self modulesIncludes: 'ac') ifTrue: [^self].

	self accessControl: ((self settingsIncludes: 'acAll')
		ifTrue: ["initialize"
			AniAccess newFromPage: self]
		ifFalse: [self hasParent
			ifTrue: [self parent initializeAccessControl.
				self parent accessControl]
			ifFalse: [AniAccess newFromPage: self]])! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
initializeAlertsBook: book
	| alerts userIdAndAlert userId alertsSetting |

	"inherit alerts from parent page"
	alerts _ self hasParent
		ifTrue: [self parent alerts copy]
		ifFalse: [Set new].
	(self settingsIncludes: 'alerts') ifTrue: [
		"Upgrade Alerts: can be removed"
		alertsSetting _ self settingsAt: 'alerts'.
		(alertsSetting isKindOf: String) ifFalse: [
			alertsSetting _ String streamContents: [:stream | alertsSetting do: [:i | stream
				nextPutAll: i asString;
				nextPutAll: '->true ']].
			self settingsAt: 'alerts' put: alertsSetting].

		((self settingsAt: 'alerts') findTokens: ' 	') do: [:token |
			userIdAndAlert _ token findTokens: '->'.
			userId _ (userIdAndAlert at: 1) asNumber.
			('true' = (userIdAndAlert at: 2 ifAbsent: ['true']))
				ifTrue: [alerts add: userId]
				ifFalse: [alerts remove: userId ifAbsent: []]]].
	self modulesAt: 'alerts' put: alerts.
	"initialize children"
	(book childrenOf: self) do: [:page |
		page initializeAlertsBook: book]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
insert: insert atGallery: galleryID
	"Find the gallery and insert the picture afterwords"
	| oldText searchID marker searchText |
	oldText _ self text.
	searchID _ 0.
	marker _ 1.
	self isAForm
		ifTrue: [
			1 to: oldText size do: [:i |
				searchText _ oldText at: (i asString) ifAbsent: [''].
				[marker = 0] whileFalse: [
					marker _ searchText findString: '<?gallery' startingAt: marker.
					(marker = 0) ifFalse: [
						marker _ searchText findString: '?>' startingAt: marker].
					(marker = 0) ifFalse: [
						searchID _ searchID + 1.
						(searchID = galleryID) ifTrue: [
							"insert here"
							oldText at: (i asString) put: (String streamContents: [:stream |
								marker _ marker + 1.
								stream
									nextPutAll: (searchText copyFrom: 1 to: marker);
									nextPutAll: insert.
								(searchText size = marker) ifFalse: [stream
									nextPutAll: (searchText copyFrom: (marker + 1) to: (searchText size))]]).
							self text: oldText.
							^self]]]].
			oldText at: '1' put: ((oldText at: '1' ifAbsent: ['']), insert).
			self text: oldText]
		ifFalse: [
			[marker = 0] whileFalse: [
				marker _ oldText findString: '<?gallery' startingAt: marker.
				(marker = 0) ifFalse: [
					marker _ oldText findString: '?>' startingAt: marker].
				(marker = 0) ifFalse: [
					searchID _ searchID + 1.
					(searchID = galleryID) ifTrue: [
						"insert here"
						self text: (String streamContents: [:stream |
							marker _ marker + 1.
							stream
								nextPutAll: (oldText copyFrom: 1 to: marker);
								nextPutAll: insert.
							(oldText size = marker) ifFalse: [stream
								nextPutAll: (oldText copyFrom: (marker + 1) to: (oldText size))]]).
						^self]]].
			self text: (text, insert)]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
parent
	^self modulesAt: 'parent' ifAbsent: [nil]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
parentACChangedBook: book
	self inheritsAccessControl ifTrue: [
		self accessControl: self parent accessControl.
		"update children pages"
		(book childrenOf: self) do: [:page |
			page parentACChangedBook: book]]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
parentForRequest: request
	| parent |
	(parent _ self parent) ifNil: [^nil].
	^((parent accessLevelForRequest: request) > 1)
		ifTrue: [parent]
		ifFalse: [parent parentForRequest: request]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
parents
	| parent |
	^(parent _ self parent)
		ifNil: [OrderedCollection with: self]
		ifNotNil: [parent parents
			add: self;
			yourself]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
sendAniAlerts: request response: response shelf: shelf book: book
	| alertSender alertText alertServer alertReceivers aniSecurity myId |
	(alertReceivers _ self modulesAt: 'alerts') isEmpty ifTrue: [^self].
	request security ifNotNil: [
		"Filter out the person making the update"
		myId _ request security id.
		alertReceivers _ alertReceivers select: [:i | i ~= myId]].
	alertSender _ self settingsAt: 'alertSender' ifAbsent: [book settingsAt: 'alertSender' ifAbsent: [^self]].
	alertServer _ self settingsAt: 'alertServer' ifAbsent: [book settingsAt: 'alertServer' ifAbsent: [^self]].
	alertText _ TextFormatter crlfToCr: (book formatPageTemplate: 'alert' request: request response: response shelf: shelf page: self).
	aniSecurity _ shelf modulesAt: 'users'.
	alertReceivers _ alertReceivers collect: [:i | aniSecurity userAtId: i].
	"Make sure receivers want to be e-mailed"
	alertReceivers _ alertReceivers select: [:i | i settingsAt: 'sendAlerts' ifAbsent: [true]].
	alertReceivers _ alertReceivers collect: [:i | i address].
	[SMTPClient deliverMailFrom: alertSender to: alertReceivers text: alertText usingServer: alertServer] ifError: [:a :b | "No error for bad e-mail addresses"]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
setAccessControl: request response: response shelf: shelf book: book
	| allLevel usersLevel acGroups level |
	"set the access control based on a request"
	((self hasParent) and: [request fieldsAsBooleanKey: 'inheritAC'])
		ifTrue: ["remove access control and replace with parents"
			self settingsRemove: 'acAll'.
			self settingsRemove: 'acUsers'.
			self settingsRemove: 'acGroups'.
			self accessControl: (self parent accessControl)]
		ifFalse: ["update settings and module"
			allLevel _ request fieldsKey: 'acAll' ifAbsent: ['2: view'].
			allLevel _ AniAccess levelForDescription: allLevel.
			self settingsAt: 'acAll' put: allLevel.
			usersLevel _ request fieldsKey: 'acUsers' ifAbsent: ['2: view'].
			usersLevel _ AniAccess levelForDescription: usersLevel.
			(usersLevel <= allLevel) ifTrue: [usersLevel _ 0].
			self settingsAt: 'acUsers' put: usersLevel.
			acGroups _ String streamContents: [:stream |
				book groups do: [:group |
					level _ request fieldsKey: ('ac', group showId) ifAbsent: ['0: none'].
					level _ AniAccess levelForDescription: level.
					(level <= (group beSignedIn ifTrue: [usersLevel] ifFalse: [allLevel]))
						ifTrue: [level _ 0].
					(level > 0) ifTrue: [stream
						nextPutAll: group showId;
						nextPutAll: '->';
						nextPutAll: level asString;
						nextPutAll: ' ']]].
			self settingsAt: 'acGroups' put: acGroups.
			self accessControl: (AniAccess newFromPage: self)].
	"update children pages"
	(book childrenOf: self) do: [:page |
		page parentACChangedBook: book]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
setAlerts: request response: response shelf: shelf book: book
	"add or remove a user for alerts"
	| curInherits inherits curAlerts alerts newSetting idAndAlert |
	self hasParent
		ifTrue: [
			curInherits _ self alertsInheritsForUser: request security.
			inherits _ request fieldsAsBooleanKey: 'inheritAlert'.
			curInherits ifTrue: [inherits ifTrue: [^self]].
			curAlerts _ self alertsIncludesUser: request security.
			alerts _ request fieldsAsBooleanKey: 'alert'.
			((curInherits = inherits) and: [curAlerts = alerts]) ifTrue: [^self].
			newSetting _ Dictionary new.
			((self settingsAt: 'alerts' ifAbsent: ['']) findTokens: ' 	') do: [:token |
				idAndAlert _ token findTokens: '->'.
				newSetting
					at: ((idAndAlert at: 1) asNumber)
					put: ((idAndAlert at: 1) = 'true')].
			inherits
				ifTrue: [newSetting removeKey: request security id]
				ifFalse: [newSetting at: (request security id) put: alerts]]
		ifFalse: [
			curAlerts _ self alertsIncludesUser: request security.
			alerts _ request fieldsAsBooleanKey: 'alert'.
			curAlerts = alerts ifTrue: [^self].
			newSetting _ Dictionary new.
			((self settingsAt: 'alerts' ifAbsent: ['']) findTokens: ' 	') do: [:token |
				idAndAlert _ token findTokens: '->'.
				newSetting
					at: ((idAndAlert at: 1) asNumber)
					put: ((idAndAlert at: 1) = 'true')].
			alerts
				ifTrue: [newSetting at: (request security id) put: true]
				ifFalse: [newSetting removeKey: (request security id)]].

	"Set the alerts"
	newSetting _ String streamContents: [:stream |
		newSetting keysAndValuesDo: [:userId :alert | stream
			nextPutAll: userId asString;
			nextPut: $-;
			nextPutAll: alert asString;
			nextPut: $ ]].
	self settingsAt: 'alerts' put: newSetting.
	self initializeAlertsBook: book! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
setParent: request response: response shelf: shelf book: book
	"On error, do nothing"
	| parentPage |
	parentPage _ request fieldsAsNumberKey: 'parent'.
	(parentPage = 0)
		ifTrue: [self newParent: nil]
		ifFalse: [
			parentPage _ book pages at: parentPage ifAbsent: [
				"Do Nothing in Case of Error" ^self].
			self newParent: parentPage]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
showImage: request response: response shelf: shelf book: book
	"compensate for the limits of the *++* format
		REQUIRED
		src = the name of the image
		OPTIONAL
		width = the maximum width of the inlined image
		height = the maximum height of the inlined image
		align = the alignment
		alt = the ALT tag
		page = the page where the image is found
		linkToPage = link to a page
		space = space around it
		border = border size"
	| options src image thumb imgPage uploads pageUploads width height versions linkToPage size link alt title space border |
	options _ request settingsAt: 'options'.

	"Get src field and page field"
	(src _ options at: 'src' ifAbsent: [nil]) ifNil: [
		^'<b>IMAGE function must have a <em>src</em> field.</b>'].
	imgPage _ (imgPage _ options at: 'page' ifAbsent: [nil])
		ifNil: [self]
		ifNotNil: [imgPage isAllDigits
			ifTrue: [book pages at: (imgPage asInteger)
				ifAbsent: [^'<b>IMAGE function''s <em>page</em> field must be a valid page number.</b>']]
			ifFalse: [^'<b>IMAGE function''s <em>page</em> field must be an integer.</b>']].

	"Find the image"
	uploads _ book modulesAt: 'uploads'.
	versions _ nil.
	((imgPage accessLevelForRequest: request) > 0) ifTrue: [
		"Try to find the image in the page directory"
		pageUploads _ uploads directoryNamed: imgPage id asString.
		versions _ pageUploads fileRefsCacheAt: src ifAbsent: [nil]].
	versions
		ifNil: ["Try to find the image in the book directory"
			versions _ uploads fileRefsCacheAt: src ifAbsent: [
				^'<b>IMAGE function cannot find the upload.</b>']]
		ifNotNil: [uploads _ pageUploads].
	"Check to make sure it is an image"
	(image _ versions last) isAnImage ifFalse: [
		^'<b>IMAGE function <em>src</em> must be an image (GIF, JPEG, PNG).</b>'].

	"establish the width and height"
	(width _ options at: 'width' ifAbsent: [nil]) ifNotNil: [
		width isAllDigits
			ifTrue: [width _ width asInteger]
			ifFalse: [^'<b>IMAGE function''s <em>width</em> field must be an integer.</b>']].
	(height _ options at: 'height' ifAbsent: [nil]) ifNotNil: [
		height isAllDigits
			ifTrue: [height _ height asInteger]
			ifFalse: [^'<b>IMAGE function''s <em>height</em> field must be an integer.</b>']].

	"establish linkToPage"
	(linkToPage _ options at: 'linktopage' ifAbsent: [nil]) ifNotNil: [linkToPage isAllDigits
		ifTrue: [
			linkToPage _ book pages at: (linkToPage asInteger) ifAbsent: [
				^'<b>IMAGE function''s <em>page</em> field must be a valid page number.</b>'].
			"Make sure it is accessible"
			((linkToPage accessLevelForRequest: request) > 1) ifFalse: [
					linkToPage _ nil]]
		ifFalse: [^'<b>IMAGE function''s <em>linkToPage</em> field must be an integer.</b>']].

	"establish space"
	(options includesKey: 'space')
		ifTrue: [space _ options at: 'space'.
			space isAllDigits
				ifTrue: [space _ space asInteger]
				ifFalse: [^'<b>IMAGE function''s <em>space</em> field must be an integer.</b>']]
		ifFalse: [space _ 0].

	"establish border"
	(options includesKey: 'border')
		ifTrue: [border _ options at: 'border'.
			border isAllDigits
				ifTrue: [border _ border asInteger]
				ifFalse: [^'<b>IMAGE function''s <em>border</em> field must be an integer.</b>']]
		ifFalse: [border _ 0].

	"Check to see whether a thumbnail is needed."
	size _ image thumbnailSizeWidth: width height: height.
	(image size = size)
		ifTrue: ["No need for a thumbnail"
			thumb _ nil]
		ifFalse: ["Try for a thumbnail"
			thumb _ uploads thumbnailOf: versions size: size.
			thumb ifNil: [thumb _ image]].

	"Establish link, alt, and title"
	linkToPage
		ifNil: [thumb
			ifNil: [
				link _ nil.
				(alt _ options at: 'alt' ifAbsent: [nil])
					ifNil: ["No alternate"
						alt _ versions strictXmlName.
						title _ String streamContents: [:stream | stream
							nextPutAll: versions strictXmlName;
							nextPutAll: ': uploaded ';
							nextPutAll: (image modificationDateString);
							nextPutAll: ' at ';
							nextPutAll: (image modificationTimeString)]]
					ifNotNil: [title _ alt]]
			ifNotNil: [
				link _ String streamContents: [:stream | stream
					nextPutAll: (book settingsAt: 'uploadServerPath');
					nextPutAll: uploads httpPath;
					nextPutAll: image httpName].
				(alt _ options at: 'alt' ifAbsent: [nil])
					ifNil: ["No alternate"
						alt _ versions strictXmlName.
						title _ String streamContents: [:stream | stream
							nextPutAll: 'Click to enlarge: ';
							nextPutAll: alt;
							nextPutAll: ' (';
							nextPutAll: image width asString;
							nextPut: $x;
							nextPutAll: image height asString;
							nextPut: $)]]
					ifNotNil: [title _ alt]]]
		ifNotNil: [
			link _ request referenceShelf: shelf book: book page: linkToPage.
			title _ options at: 'alt' ifAbsent: [String streamContents: [:stream | stream
				nextPutAll: linkToPage showStrictName;
				nextPutAll: ': last edited ';
				nextPutAll: (book formatPageAction: 'timePast' request: request response: response shelf: shelf page: linkToPage);
				nextPutAll: ' ago by ';
				nextPutAll: (book formatPageAction: 'user-plaintext' request: request response: response shelf: shelf page: linkToPage)]].
			alt _ options at: 'alt' ifAbsent: [linkToPage showStrictName]].

	"Reference the file"
	^String streamContents: [:stream |
		link ifNotNil: [stream
			nextPutAll: '<a class="internal" href="';
			nextPutAll: link;
			nextPutAll: '">'].
		stream
			nextPutAll: '<img src="';
			nextPutAll: (book settingsAt: 'uploadServerPath');
			nextPutAll: uploads httpPath;
			nextPutAll: (thumb
				ifNil: [image httpName]
				ifNotNil: [thumb httpName]);
			nextPutAll: '" width=';
			nextPutAll: size x asString;
			nextPutAll: ' height=';
			nextPutAll: size y asString;
			nextPutAll: ' border=';
			nextPutAll: border asString.
		(options includesKey: 'space') ifTrue: [stream
			nextPutAll: ' vspace=';
			nextPutAll: space asString;
			nextPutAll: ' hspace=';
			nextPutAll: space asString].
		(options includesKey: 'align') ifTrue: [stream
			nextPutAll: ' align=';
			nextPutAll: (options at: 'align')].
		stream
			nextPutAll: ' title="';
			nextPutAll: title;
			nextPutAll: '" alt="';
			nextPutAll: alt;
			nextPutAll: '">'.
		link ifNotNil: [stream
			nextPutAll: '</a>']]! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
unaccessableToAll
	^self accessControl unaccessableToAll! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
uneditableToAll
	^self accessControl uneditableToAll! !

!NuSwikiPage methodsFor: 'utility AniAniWeb'!
unuploadableToAll
	^self accessControl unuploadableToAll! !


!SwikiBook methodsFor: 'accessing'!
bookActions
	^bookActions! !

!SwikiBook methodsFor: 'accessing'!
bookAddresses
	^bookAddresses! !

!SwikiBook methodsFor: 'accessing'!
bookTemplates
	^bookTemplates! !

!SwikiBook methodsFor: 'accessing'!
nameToPage
	^nameToPage! !

!SwikiBook methodsFor: 'accessing'!
pageActions
	^pageActions! !

!SwikiBook methodsFor: 'accessing'!
pageAddresses
	^pageAddresses! !

!SwikiBook methodsFor: 'accessing'!
pageTemplates
	^pageTemplates! !

!SwikiBook methodsFor: 'accessing'!
pages
	^pages! !

!SwikiBook methodsFor: 'accessing'!
pages: anObject
	pages _ anObject! !

!SwikiBook methodsFor: 'accessing'!
privAddresses
	^privAddresses! !

!SwikiBook methodsFor: 'accessing'!
setup
	^setup! !

!SwikiBook methodsFor: 'accessing'!
setup: dict
	setup _ dict! !

!SwikiBook methodsFor: 'modules'!
modules
	^modules copy! !

!SwikiBook methodsFor: 'modules'!
rawModules
	^modules! !

!SwikiBook methodsFor: 'modules'!
rawModules: dict
	modules _ dict! !

!SwikiBook methodsFor: 'modules'!
rawModulesIncludes: key
	^modules includesKey: key! !

!SwikiBook methodsFor: 'modules'!
rawModulesRemove: key
	^modules removeKey: key ifAbsent: []! !

!SwikiBook methodsFor: 'testing'!
hasBookAction: actionName
	^bookActions includesKey: actionName! !

!SwikiBook methodsFor: 'testing'!
hasBookAddress: addressName
	^bookAddresses includesKey: addressName! !

!SwikiBook methodsFor: 'testing'!
hasBookTemplate: templateName
	^bookTemplates includesKey: templateName! !

!SwikiBook methodsFor: 'testing'!
hasPageAction: actionName
	^pageActions includesKey: actionName! !

!SwikiBook methodsFor: 'testing'!
hasPageAddress: addressName
	^pageAddresses includesKey: addressName! !

!SwikiBook methodsFor: 'testing'!
hasPageId: anInteger
	(anInteger < 1) ifTrue: [^false].
	^anInteger <= pages size! !

!SwikiBook methodsFor: 'testing'!
hasPageNamed: aString
	^nameToPage includesKey: aString! !

!SwikiBook methodsFor: 'testing'!
hasPageTemplate: templateName
	^pageTemplates includesKey: templateName! !

!SwikiBook methodsFor: 'testing'!
hasPrivAddress: addressName
	^privAddresses includesKey: addressName! !

!SwikiBook methodsFor: 'inheritance'!
addChild: aBook
	children ifNil: [children _ OrderedCollection new].
	children add: aBook! !

!SwikiBook methodsFor: 'inheritance'!
allChildren
	| return |
	return _ OrderedCollection new.
	self hasChildren ifFalse: [^return].
	children do: [:child |
		return add: child.
		return addAll: child allChildren].
	^return! !

!SwikiBook methodsFor: 'inheritance'!
children
	^children! !

!SwikiBook methodsFor: 'inheritance'!
hasChildren
	^(children = nil) not! !

!SwikiBook methodsFor: 'inheritance'!
hasParent
	^false! !

!SwikiBook methodsFor: 'inheritance'!
hasSuper: aBook
	^false! !

!SwikiBook methodsFor: 'inheritance'!
loadSelfAndChildrenFrom: shelf
	self loadFrom: shelf.
	children ifNotNil: [children do: [:child | child loadSelfAndChildrenFrom: shelf]]! !

!SwikiBook methodsFor: 'inheritance'!
removeChild: aBook
	children remove: aBook ifAbsent: [].
	(children size = 0) ifTrue: [children _ nil].! !

!SwikiBook methodsFor: 'utility'!
addNewPage
	| test page |
	test _ pages at: 1.
	page _ test class new.
	page
		id: (pages size + 1);
		versionId: 0;
		storage: test storage.
	pages add: page.
	^page! !

!SwikiBook methodsFor: 'utility'!
collDatePagesBlogPrefix: prefix postfix: postfix
	"Return a sorted collection of Dates and Pages that are blog pages and match the prefix and postfix."
	| select return cutName date |
	select _ self pages.
	(prefix = '') ifFalse: [select _ select select: [:page | page name beginsWith: prefix]].
	(postfix = '') ifFalse: [select _ select select: [:page | page name endsWith: postfix]].
	return _ SortedCollection sortBlock: [:a :b | (a at: 1) > (b at: 1)].
	select do: [:page |
		cutName _ page name.
		((prefix ~= '') or: [postfix ~= '']) ifTrue: [
			cutName _ cutName copyFrom: (prefix size + 1) to: (cutName size - (postfix size))].
		cutName _ ReadStream on: cutName.
		[date _ Date readFrom: cutName] ifError: [:a :b | date _ nil].
		date ifNotNil: [return add: (Array with: date with: page)]].
	^return! !

!SwikiBook methodsFor: 'utility'!
pageAlmostNamed: addr ifThere: thereBlock ifNot: notBlock
	| dividers tokens isValid |

	dividers _ OrderedCollection new.
	dividers add: 1.
	(addr size > 1) ifTrue: [
		2 to: (addr size) do: [:i | (addr at: i) isUppercase ifTrue: [dividers add: i]]].
	tokens _ OrderedCollection new.
	(dividers size > 1) ifTrue: [
		1 to: (dividers size - 1) do: [:i | tokens add: (addr copyFrom: (dividers at: i) to: ((dividers at: i + 1) - 1)) asLowercase]].
	tokens add: (addr copyFrom: (dividers at: dividers size) to: addr size) asLowercase.
	pages do: [:page | isValid _ true.
		tokens do: [:token | (((page name asLowercase) findString: token) = 0) ifTrue: [isValid _ false]].
		isValid ifTrue: [^thereBlock value: page]].
	^notBlock value
! !

!SwikiBook methodsFor: 'utility'!
pageNamed: aString
	^nameToPage at: aString ifAbsent: [nil]! !

!SwikiBook methodsFor: 'utility'!
publicPageAlmostNamed: addr ifThere: thereBlock ifNot: notBlock
	| dividers tokens isValid |

	dividers _ OrderedCollection new.
	dividers add: 1.
	(addr size > 1) ifTrue: [
		2 to: (addr size) do: [:i | (addr at: i) isUppercase ifTrue: [dividers add: i]]].
	tokens _ OrderedCollection new.
	(dividers size > 1) ifTrue: [
		1 to: (dividers size - 1) do: [:i | tokens add: (addr copyFrom: (dividers at: i) to: ((dividers at: i + 1) - 1)) asLowercase]].
	tokens add: (addr copyFrom: (dividers at: dividers size) to: addr size) asLowercase.
	self pages do: [:page | isValid _ true.
		tokens do: [:token | (((page name asLowercase) findString: token) = 0) ifTrue: [isValid _ false]].
		isValid ifTrue: [(self aniAllowViewPage: page) ifTrue: [
			^thereBlock value: page]]].
	^notBlock value
! !

!SwikiBook methodsFor: 'utility'!
recentchanges: beforeBlock during: duringBlock after: afterBlock
	| return sortedPages page date |

	sortedPages _ pages asSortedCollection: [:x :y | (x date = y date) ifTrue: [x time > y time] ifFalse: [x date > y date]].
	page _ sortedPages at: 1.
	date _ page date.
	"First page"
	return _ WriteStream on: String new.
	return nextPutAll: (beforeBlock value: page).
	return nextPutAll: (duringBlock value: page).
	"Other pages"
	(sortedPages size = 1) ifFalse: [
		2 to: (sortedPages size) do: [:i | page _ sortedPages at: i.
			(page date = date) ifFalse: ["New Date"
				date _ page date.
				return nextPutAll: (afterBlock value).
				return nextPutAll: (beforeBlock value: page)].
			return nextPutAll: (duringBlock value: page)]].
	return nextPutAll: (afterBlock value).
	^return contents

! !

!SwikiBook methodsFor: 'utility'!
references: page before: beforeBlock during: duringBlock after: afterBlock ifAbsent: absentBlock
	| results return |

	results _ OrderedCollection new.
	pages do: [:element | ((element settingsAt: 'referenceCache' ifAbsent: [OrderedCollection new]) includes: page id) ifTrue: [results add: element]].
	(results includes: (pages at: 1)) ifTrue: [results remove: (pages at: 1)].
	(results size > 0) ifTrue: [
		return _ beforeBlock value: results.
		results do: [:element | return _ return, (duringBlock value: element)].
		^return, (afterBlock value: results)].
	^absentBlock value! !

!SwikiBook methodsFor: 'utility'!
renamePage: aSwikiPage to: aString
	nameToPage removeKey: aSwikiPage name ifAbsent: [].
	nameToPage at: aString put: aSwikiPage.
	aSwikiPage name: aString! !

!SwikiBook methodsFor: 'utility'!
searchFor: text caseSensitive: caseSensitive and: performAnd matchBlock: matchBlock
	| tokens results isMatch remaining pos1 |

	results _ OrderedCollection new.
	"Smart tokenize text with quotes"
	tokens _ OrderedCollection new.
	remaining _ text.
	[(remaining size > 0) and: [(pos1 _ remaining findString: '"' startingAt: 1) > 0]]
		whileTrue: [(pos1 = 1)
			ifTrue: [(remaining size > 1)
				ifTrue: [remaining _ remaining copyFrom: 2 to: remaining size.
					(pos1 _ remaining findString: '"' startingAt: 1) = 0
						ifTrue: [tokens add: remaining.
							remaining _ '']
						ifFalse: [pos1 = 1 ifFalse: [tokens add: (remaining copyFrom: 1 to: (pos1 - 1))].
							(pos1 = remaining size)
								ifTrue: [remaining _ '']
								ifFalse: [remaining _ remaining copyFrom: (pos1 + 1) to: remaining size]]]
				ifFalse: [remaining _ '']]
			ifFalse: [tokens addAll: ((remaining copyFrom: 1 to: (pos1 - 1)) findTokens: ' ').
				remaining _ remaining copyFrom: pos1 to: remaining size]].
	tokens addAll: (remaining findTokens: ' ').
	"Return Results"
	results _ OrderedCollection new.
	(tokens size = 0) ifFalse: [
		performAnd
			ifTrue: [pages do: [:page | "Test Pages in an AND search manner"
				isMatch _ true.
				tokens do: [:token |
					((page textContains: token caseSensitive: caseSensitive) or:
						[page name includesSubstring: token caseSensitive: caseSensitive])
							ifFalse: [isMatch _ false]].
				isMatch ifTrue: [matchBlock value: page]]]
			ifFalse: [pages do: [:page | "Test Pages in an OR search manner"
				isMatch _ false.
				tokens do: [:token |
					((page textContains: token caseSensitive: caseSensitive) or:
						[page name includesSubstring: token caseSensitive: caseSensitive])
							ifTrue: [isMatch _ true]].
				isMatch ifTrue: [matchBlock value: page]]]].
	^results! !

!SwikiBook methodsFor: 'utility'!
showName
	^(TextFormatter encodeToXmlCrlf: name)! !

!SwikiBook methodsFor: 'utility'!
showStrictName
	^(TextFormatter encodeToStrictXmlCrlf: name)! !

!SwikiBook methodsFor: 'initialization'!
initialize
	super initialize.
	nameToPage _ Dictionary new.
	pageAddresses _ Dictionary new.
	bookAddresses _ Dictionary new.
	privAddresses _ Dictionary new.
	pageTemplates _ Dictionary new.
	bookTemplates _ Dictionary new.
	pageActions _ Dictionary new.
	bookActions _ Dictionary new! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
aniAllowEditPage: aSwikiPage
	^aSwikiPage settingsAt: 'allowEdit' ifAbsent: [
		self aniAllowEditPage: (self pages at:
			(aSwikiPage settingsAt: 'parent' ifAbsent: [^true]))]! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
aniAllowViewPage: aSwikiPage
	^aSwikiPage settingsAt: 'allowView' ifAbsent: [
		self aniAllowViewPage: (self pages at:
			(aSwikiPage settingsAt: 'parent' ifAbsent: [^true]))]! !

!SwikiBook methodsFor: 'utility AniAniWeb' stamp: 'xw 5/11/2022 21:09'!
aniChangeParent: aSwikiPage to: newParentId
	"On error, do nothing"
	| parent |
	"If it is the same, do nothing"
	((aSwikiPage settingsAt: 'parent' ifAbsent: [0]) = newParentId) ifTrue: [^self].
	"If it is 0, remove the parent"
	(newParentId = 0) ifTrue: [
		aSwikiPage settingsRemove: 'parent'.
		^self].
	"If the newParentId does not exist, give up"
	parent _ self pages at: newParentId ifAbsent: [^self].
	"Check to make sure that there is no circular parentage"
	((self aniInheritanceForPage: parent) includes: aSwikiPage) ifFalse: [
		aSwikiPage settingsAt: 'parent' put: newParentId.
		aSwikiPage parent: parent.
		"update access control"
		aSwikiPage inheritsAccessControl ifFalse: [
			aSwikiPage accessControl: parent accessControl]]! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
aniInheritanceForPage: aSwikiPage
	| return currentPage |
	return _ OrderedCollection new.
	currentPage _ aSwikiPage.
	[currentPage notNil] whileTrue: [
		return add: currentPage.
		currentPage _ self aniParentPage: currentPage].
	^return! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
aniParentPage: aSwikiPage
	^self pages at: (aSwikiPage settingsAt: 'parent' ifAbsent: [^nil])! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
aniSiteMapCollDepth: depth public: isPublic
	| select selectTop parentId flatten |

	"Build a hierarchy"
	select _ self pages collect: [:page | Array
		with: page
		with: (SortedCollection sortBlock: [:a :b | ((a at: 1) name) < ((b at: 1) name)])].
	selectTop _ SortedCollection sortBlock: [:a :b | ((a at: 1) name) < ((b at: 1) name)].
	select do: [:arr | (parentId _ (arr at: 1) settingsAt: 'parent' ifAbsent: [nil])
		ifNil: [selectTop add: arr]
		ifNotNil: [((select at: parentId) at: 2) add: arr]].
	"Flatten hierarchy"
	flatten _ OrderedCollection new.
	self aniSiteMapFlatten: selectTop onTo: flatten depth: depth.
	"Remove not allowed"
	isPublic ifTrue: [
		flatten _ flatten select: [:arr | self aniAllowViewPage: (arr at: 1)]].
	"Reverse the depth and have the lowest value be 0"
	flatten do: [:arr | arr at: 2 put: (depth - (arr at: 2))].
	^flatten! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
aniSiteMapFlatten: aCollection onTo: return depth: depth
	aCollection do: [:arr |
		return add: (Array with: (arr at: 1) with: depth).
		(depth > 1) ifTrue: [
			self aniSiteMapFlatten: (arr at: 2) onTo: return depth: (depth - 1)]]! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
childrenOf: parent
	^self pages select: [:page | page parent = parent]! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
groups
	^(self modulesAt: 'groups') groups! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
inheritsAccessControl
	"TODO"
	^true! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
pageAlmostNamed: addr forRequest: request ifThere: thereBlock ifNot: notBlock
	| dividers tokens isValid |

	"establish the tokens we are looking for"
	dividers _ OrderedCollection new.
	dividers add: 1.
	(addr size > 1) ifTrue: [
		2 to: (addr size) do: [:i | (addr at: i) isUppercase ifTrue: [dividers add: i]]].
	tokens _ OrderedCollection new.
	(dividers size > 1) ifTrue: [
		1 to: (dividers size - 1) do: [:i | tokens add: (addr copyFrom: (dividers at: i) to: ((dividers at: i + 1) - 1)) asLowercase]].
	tokens add: (addr copyFrom: (dividers at: dividers size) to: addr size) asLowercase.

	"find a page whose name matches the tokens"
	(request viewablePagesInBook: self) do: [:page | isValid _ true.
		tokens do: [:token | (((page name asLowercase) findString: token) = 0) ifTrue: [isValid _ false]].
		isValid ifTrue: [(self aniAllowViewPage: page) ifTrue: [
			^thereBlock value: page]]].
	^notBlock value
! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
searchFor: text forRequest: request caseSensitive: caseSensitive performAnd: performAnd matchBlock: matchBlock
	| tokens results isMatch remaining pos1 pagesToSearch |

	results _ OrderedCollection new.
	pagesToSearch _ request linkablePagesInBook: self.
	"Smart tokenize text with quotes"
	tokens _ OrderedCollection new.
	remaining _ text.
	[(remaining size > 0) and: [(pos1 _ remaining findString: '"' startingAt: 1) > 0]]
		whileTrue: [(pos1 = 1)
			ifTrue: [(remaining size > 1)
				ifTrue: [remaining _ remaining copyFrom: 2 to: remaining size.
					(pos1 _ remaining findString: '"' startingAt: 1) = 0
						ifTrue: [tokens add: remaining.
							remaining _ '']
						ifFalse: [pos1 = 1 ifFalse: [tokens add: (remaining copyFrom: 1 to: (pos1 - 1))].
							(pos1 = remaining size)
								ifTrue: [remaining _ '']
								ifFalse: [remaining _ remaining copyFrom: (pos1 + 1) to: remaining size]]]
				ifFalse: [remaining _ '']]
			ifFalse: [tokens addAll: ((remaining copyFrom: 1 to: (pos1 - 1)) findTokens: ' ').
				remaining _ remaining copyFrom: pos1 to: remaining size]].
	tokens addAll: (remaining findTokens: ' ').
	"Return Results"
	results _ OrderedCollection new.
	(tokens size = 0) ifFalse: [
		performAnd
			ifTrue: [pagesToSearch do: [:page | "Test Pages in an AND search manner"
				isMatch _ true.
				tokens do: [:token |
					((page textContains: token caseSensitive: caseSensitive) or:
						[page name includesSubstring: token caseSensitive: caseSensitive])
							ifFalse: [isMatch _ false]].
				isMatch ifTrue: [matchBlock value: page]]]
			ifFalse: [pagesToSearch do: [:page | "Test Pages in an OR search manner"
				isMatch _ false.
				tokens do: [:token |
					((page textContains: token caseSensitive: caseSensitive) or:
						[page name includesSubstring: token caseSensitive: caseSensitive])
							ifTrue: [isMatch _ true]].
				isMatch ifTrue: [matchBlock value: page]]]].
	^results! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
siteMapCollectionRequest: request depth: depth
	"Return a collection of page and depth"
	| pageToParent stop topPages return |
	pageToParent _ Dictionary new.
	(request linkablePagesInBook: self) do: [:page |
		pageToParent at: page put: page parent].
	"Remove unlinkable parents"
	stop _ false.
	[stop] whileFalse: [
		stop _ true.
		pageToParent keysAndValuesDo: [:page :parent |
			(parent isNil or: [pageToParent includesKey: parent]) ifFalse: [
				stop _ false.
				pageToParent at: page put: parent parent]]].
	"Get the top level pages (those without a parent)"
	topPages _ SortedCollection sortBlock: [:a :b | a name asLowercase < b name asLowercase].
	pageToParent keysAndValuesDo: [:page :parent |
		parent ifNil: [topPages add: page]].
	"Put them on the collection"
	return _ OrderedCollection new.
	topPages do: [:page |
		self siteMapFlatten: page inSpace: pageToParent depth: depth onTo: return].
	return _ return collect: [:arr | Array
		with: (arr at: 1)
		with: (depth - (arr at: 2))].
	^return ! !

!SwikiBook methodsFor: 'utility AniAniWeb'!
siteMapFlatten: page inSpace: pageToParent depth: depth onTo: coll
	| childrenPages |
	coll add: (Array with: page with: depth).
	"If depth=1, then don't do the children pages"
	(depth = 1) ifFalse: [
		childrenPages _ SortedCollection sortBlock: [:a :b | a name asLowercase < b name asLowercase].
		pageToParent keysAndValuesDo: [:child :parent |
			(parent = page) ifTrue: [childrenPages add: child]].
		childrenPages do: [:child |
			self siteMapFlatten: child inSpace: pageToParent depth: (depth-1) onTo: coll]].! !

!SwikiBook methodsFor: 'storage'!
loadFrom: shelf
	self loadStorageFrom: shelf.
	storage loadBook: self.
	self loadPages! !

!SwikiBook methodsFor: 'storage'!
loadPages
	| kind |
	kind _ setup at: 'pageStorage' ifAbsent: [XmlSwikiStorage].
	pages _ (storage dir directoryExists: 'pages')
		ifTrue: [(kind fromDir: (storage dir directoryNamed: 'pages')) loadPages]
		ifFalse: [OrderedCollection new].
	"Initialize nameToPage"
	pages do: [:page | nameToPage at: (page name) put: page].! !

!SwikiBook methodsFor: 'storage'!
loadStorageFrom: shelf
	| kind |
	kind _ setup at: 'bookStorage' ifAbsent: [XmlSwikiStorage].
	storage _  kind fromDir: (shelf storage dir directoryNamed: name)! !

!SwikiBook methodsFor: 'storage'!
writeSettings
	storage writeSettingsForBook: self! !

!SwikiBook methodsFor: 'settings'!
rawSettings
	^settings! !

!SwikiBook methodsFor: 'settings'!
rawSettings: dict
	settings _ dict! !

!SwikiBook methodsFor: 'settings'!
rawSettingsIncludes: key
	^settings includesKey: key! !

!SwikiBook methodsFor: 'settings'!
rawSettingsRemove: key
	^settings removeKey: key ifAbsent: []! !

!SwikiBook methodsFor: 'settings'!
settings
	^settings copy! !

!SwikiBook methodsFor: 'private'!
bookActionNamed: actionName
	^bookActions at: actionName ifAbsent: [nil]! !

!SwikiBook methodsFor: 'private'!
bookAddressNamed: addressName
	^bookAddresses at: addressName ifAbsent: [nil]! !

!SwikiBook methodsFor: 'private'!
bookTemplateNamed: templateName
	^bookTemplates at: templateName ifAbsent: [self error: ('book template ', templateName, ' does not exist')]! !

!SwikiBook methodsFor: 'private'!
formatBookAction: actionName with: args
	| action |
	^(action _ self bookActionNamed: actionName)
		ifNil: ['<?', actionName, '?>']
		ifNotNil: [action copy fixTemps valueWithArguments: args]! !

!SwikiBook methodsFor: 'private'!
formatPageAction: actionName with: args
	"Format book action if no page action is found"
	| action |
	^(action _ self pageActionNamed: actionName)
		ifNil: [self formatBookAction: actionName with: (args copyFrom: 1 to: 4)]
		ifNotNil: [action copy fixTemps valueWithArguments: args]! !

!SwikiBook methodsFor: 'private'!
pageActionNamed: actionName
	^pageActions at: actionName ifAbsent: [nil]! !

!SwikiBook methodsFor: 'private'!
pageAddressNamed: addressName
	^pageAddresses at: addressName ifAbsent: [nil]! !

!SwikiBook methodsFor: 'private'!
pageTemplateNamed: templateName
	^pageTemplates at: templateName ifAbsent: [self error: ('page template ', templateName, ' does not exist')]! !

!SwikiBook methodsFor: 'private'!
privAddressNamed: addressName
	^privAddresses at: addressName ifAbsent: [nil]! !

!SwikiBook methodsFor: 'processing'!
formatBookAction: actionName request: request response: response shelf: shelf
	^self formatBookAction: actionName with: (Array with: request with: response with: shelf with: self)! !

!SwikiBook methodsFor: 'processing'!
formatBookAddress: addressName request: request response: response shelf: shelf
	| address |
	(address _ self bookAddressNamed: addressName) ifNil: [
		address _ self bookAddressNamed: 'default'].
	^address copy fixTemps value: request value: response value: shelf value: self! !

!SwikiBook methodsFor: 'processing'!
formatBookTemplate: templateName request: request response: response shelf: shelf
	^(BookTemplateFormatter swikiFormatter) format: (self bookTemplateNamed: templateName) request: request response: response shelf: shelf book: self! !

!SwikiBook methodsFor: 'processing'!
formatPageAction: actionName request: request response: response shelf: shelf page: page
	^self formatPageAction: actionName with: (Array with: request with: response with: shelf with: self with: page)! !

!SwikiBook methodsFor: 'processing'!
formatPageAddress: addressName request: request response: response shelf: shelf page: page
	| address |
	(address _ self pageAddressNamed: addressName) ifNil: [
		address _ self pageAddressNamed: 'default'].
	^address copy fixTemps valueWithArguments: (Array with: request with: response with: shelf with: self with: page)! !

!SwikiBook methodsFor: 'processing'!
formatPageTemplate: templateName request: request response: response shelf: shelf page: page
	^(BookTemplateFormatter swikiFormatter) format: (self pageTemplateNamed: templateName) request: request response: response shelf: shelf book: self page: page! !

!SwikiBook methodsFor: 'processing'!
formatPrivAddress: addressName request: request response: response shelf: shelf
	| address |
	(address _ self privAddressNamed: addressName) ifNil: [^nil].
	^address copy fixTemps value: request value: response value: shelf value: self! !

!SwikiBook methodsFor: 'processing'!
process: request response: response shelf: shelf
	"Process the swiki request to return the stream of the text."
	| filter page |
	"Filter Before Processing"
	(filter _ self formatPrivAddress: 'filter' request: request response: response shelf: shelf)
		ifNotNil: ["Return filter after logging"
			response at: 'content' put: filter.
			^self formatPrivAddress: 'log' request: request response: response shelf: shelf].
	"Process Normal Book or Page Request"
	pages ifNotNil: [request page ifNotNil: [
		page _ pages at: (request page) ifAbsent: [nil]]].
	response at: 'content' put: (page
		ifNil: [self formatBookAddress: (request address) request: request response: response shelf: shelf]
		ifNotNil: [self formatPageAddress: (request address) request: request response: response shelf: shelf page: page]).
	"Log After Processing"
	self formatPrivAddress: 'log' request: request response: response shelf: shelf! !


!SwikiShelf methodsFor: 'accessing'!
bookActions
	^bookActions! !

!SwikiShelf methodsFor: 'accessing'!
bookTemplates
	^bookTemplates! !

!SwikiShelf methodsFor: 'accessing'!
books
	^nameToBook values! !

!SwikiShelf methodsFor: 'accessing'!
privAddresses
	^privAddresses! !

!SwikiShelf methodsFor: 'accessing'!
shelfActions
	^shelfActions! !

!SwikiShelf methodsFor: 'accessing'!
shelfAddresses
	^shelfAddresses! !

!SwikiShelf methodsFor: 'accessing'!
shelfTemplates
	^shelfTemplates! !

!SwikiShelf methodsFor: 'storage'!
load
	storage loadShelf: self.
	nameToBook _ Dictionary new.
	storage setupBooks do: [:book |
		nameToBook at: (book name asLowercase) put: book].
	self loadInheritance.
	self loadBooks.
	self loadModules! !

!SwikiShelf methodsFor: 'storage'!
loadBooks
	nameToBook valuesDo: [:book | (book hasParent) ifFalse: [book loadSelfAndChildrenFrom: self]]! !

!SwikiShelf methodsFor: 'storage'!
loadInheritance
	| parent |
	nameToBook valuesDo: [:book | (book hasParent) ifTrue: [
		parent _ self bookNamed: (book setup at: 'parent').
		parent ifNil: [self error: ('parent book (', (book setup at: 'parent'), ') does not exits')].
		(parent setup at: 'inheritable' ifAbsent: [true])
			ifTrue: [parent addChild: book.
				book parent: parent]
			ifFalse: [self error: ('parent book (', (parent name), ') is not inheritable')]]]! !

!SwikiShelf methodsFor: 'storage'!
loadModules
	self formatPrivAddress: 'initialize' request: nil response: nil.
	nameToBook valuesDo: [:book |
		book formatPrivAddress: 'initialize' request: nil response: nil shelf: self]
! !

!SwikiShelf methodsFor: 'storage'!
reload
	"Stop First"
	self formatPrivAddress: 'stop' request: nil response: nil.
	"Reinitialize ATA"
	self initialize.
	storage loadShelf: self.
	"Reinitailize Modules"
	self loadModules! !

!SwikiShelf methodsFor: 'storage'!
writeSettings
	storage writeSettingsForShelf: self! !

!SwikiShelf methodsFor: 'storage'!
writeSetupForBook: book
	storage writeSetupForBook: book! !

!SwikiShelf methodsFor: 'testing'!
hasAni
	^nameToBook includesKey: 'ani'! !

!SwikiShelf methodsFor: 'testing'!
hasPrivAddress: addressName
	^privAddresses includesKey: addressName! !

!SwikiShelf methodsFor: 'utility'!
addBook: aSwikiBook
	nameToBook at: (aSwikiBook name asLowercase) put: aSwikiBook! !

!SwikiShelf methodsFor: 'utility'!
addNewBookNamed: aString
	| book |
	storage dir createDirectory: aString.
	book _ SwikiBook new.
	book name: aString.
	nameToBook at: (aString asLowercase) put: book.
	^book! !

!SwikiShelf methodsFor: 'utility'!
bookNamed: aString
	aString ifNil: [^nil].
	^nameToBook at: (aString asLowercase) ifAbsent: [nil]! !

!SwikiShelf methodsFor: 'utility'!
rollBackUsers: badUsers
	| badUserSet lastGoodVersion |
	badUserSet _ badUsers findTokens: String cr.
	badUserSet _ badUserSet asSet.
	self books do: [:book |
		book pages ifNotNil: [book pages do: [:page | (badUserSet includes: page user) ifTrue: [
			"Revert pages that came from badUser"
			lastGoodVersion _ page lastVersionsNotUsers: badUserSet.
			lastGoodVersion ifNotNil: [page
				forbidWriting;
				revertTo: lastGoodVersion book: book;
				write;
				permitWriting]]]]]! !

!SwikiShelf methodsFor: 'processing'!
formatBookAction: actionName request: request response: response book: book
	^self formatBookAction: actionName with: (Array with: request with: response with: self with: book)! !

!SwikiShelf methodsFor: 'processing'!
formatBookAction: actionName with: args
	^(bookActions at: actionName ifAbsent: [^self formatShelfAction: actionName with: (args copyFrom: 1 to: 3)]) copy fixTemps valueWithArguments: args! !

!SwikiShelf methodsFor: 'processing'!
formatBookTemplate: templateName request: request response: response book: book
	^(ShelfTemplateFormatter swikiFormatter) format: (bookTemplates at: templateName) request: request response: response shelf: self book: book! !

!SwikiShelf methodsFor: 'processing'!
formatPrivAddress: addressName request: request response: response
	^(privAddresses at: addressName ifAbsent: [^nil]) copy fixTemps value: request value: response value: self! !

!SwikiShelf methodsFor: 'processing'!
formatShelfAction: actionName request: request response: response
	^self formatShelfAction: actionName with: (Array with: request with: response with: self)! !

!SwikiShelf methodsFor: 'processing'!
formatShelfAction: actionName with: args
	^(shelfActions at: actionName ifAbsent: [^'<?', actionName, '?>']) copy fixTemps valueWithArguments: args! !

!SwikiShelf methodsFor: 'processing'!
formatShelfAddress: addressName request: request response: response
	^(shelfAddresses at: addressName ifAbsent: [^nil]) copy fixTemps value: request value: response value: self! !

!SwikiShelf methodsFor: 'processing'!
formatShelfTemplate: templateName request: request response: response
	^(ShelfTemplateFormatter swikiFormatter) format: (shelfTemplates at: templateName) request: request response: response shelf: self! !

!SwikiShelf methodsFor: 'processing'!
process: request response: response
	| book filter |
	"Filter Before Processing"
	filter _ self formatPrivAddress: 'filter' request: request response: response.
	filter
		ifNil: [(book _ self bookNamed: request book)
			ifNil: [response at: 'content' put: ((shelfAddresses at: (request book) ifAbsent: [shelfAddresses at: 'default']) copy fixTemps value: request value: response value: self)]
			ifNotNil: [(book setup at: 'accessible' ifAbsent: [true])
				ifTrue: [book process: request response: response shelf: self]
				ifFalse: [response at: 'content' put: (self formatShelfAddress: 'default' request: request response: response)]]]
		ifNotNil: [response at: 'content' put: filter].
	"Log After Processing"
	self formatPrivAddress: 'log' request: request response: response
! !

!SwikiShelf methodsFor: 'processing'!
stopProcessing
	"Stop Books"
	nameToBook valuesDo: [:book | book formatPrivAddress: 'stop' request: nil response: nil shelf: self].
	"Stop Self"
	self formatPrivAddress: 'stop' request: nil response: nil! !

!SwikiShelf methodsFor: 'initialization'!
initialize
	super initialize.
	privAddresses _ Dictionary new.
	shelfAddresses _ Dictionary new.
	bookTemplates _ Dictionary new.
	shelfTemplates _ Dictionary new.
	bookActions _ Dictionary new.
	shelfActions _ Dictionary new! !


!SwikiStructure class methodsFor: 'instance creation'!
new
	^super new
		initialize;
		yourself! !


!NuSwikiPage class methodsFor: 'instance creation'!
new
	| instance |
	instance _ super new.
	instance initialize.
	^instance! !

!NuSwikiPage class methodsFor: 'utility'!
hasAProtocol: text 
	(text includes: $:) ifFalse: [^ false].
	^ #('http' 'https' 'ftp' 'gopher' 'mailto' 'mailto' 'news' 'telnet' 'rlogin' 'tn3270' 'wais' 'file' ) includes: (text copyUpTo: $:) asLowercase! !

!NuSwikiPage class methodsFor: 'utility'!
isFormText: aText
	^(aText isKindOf: Dictionary)! !

!NuSwikiPage class methodsFor: 'utility'!
isTextAnEmailAddress: text
	(text includes: $@) ifFalse: [^false].
	(text includes: Character space) ifTrue: [^false].
	((text copyAfterLast: $@) includes: $.) ifFalse: [^false].
	^true
! !

!NuSwikiPage class methodsFor: 'utility'!
printDate: aDate
	^(aDate dayOfMonth asString), ' ', (aDate monthName), ' ', (aDate year asString)! !

!NuSwikiPage class methodsFor: 'utility'!
printTime: aTime
	^String streamContents: [:stream |
		aTime print24: false showSeconds: false on: stream]! !

!NuSwikiPage class methodsFor: 'utility'!
safePageNameFor: aString
	"Strip unwanted characters and whitespace"
	^aString withBlanksTrimmed select: [:char | ('<@*>' includes: char) not]! !

!NuSwikiPage class methodsFor: 'utility'!
urlForProtocolText: text 
	"URLs such as http:myfile.txt should be myfile.txt &
	URLs sucha s http:/myfile.txt should be /myfile.txt"
	| lowerText |
	lowerText _ text asLowercase.
	(lowerText beginsWith: 'http:') ifFalse: [^text].
	^(lowerText beginsWith: 'http://')
		ifTrue: [text]
		ifFalse: [text copyAfter: $:]! !

!NuSwikiPage class methodsFor: 'initialize-release'!
initialize
	BadCharTable _ String newFrom: ((0 to: 255) collect: [:i | i asCharacter]).
	BadCharTable at: 1 put: Character cr.! !


!SwikiSubBook methodsFor: 'modules'!
modules
	^(parent modules) addAll: modules! !

!SwikiSubBook methodsFor: 'modules'!
modulesAt: key
	^modules at: key ifAbsent: [parent modulesAt: key]! !

!SwikiSubBook methodsFor: 'modules'!
modulesAt: key ifAbsent: block
	^modules at: key ifAbsent: [parent modulesAt: key ifAbsent: block]! !

!SwikiSubBook methodsFor: 'modules'!
modulesIncludes: key
	^(modules includesKey: key)
		ifTrue: [true]
		ifFalse: [parent modulesIncludes: key]! !

!SwikiSubBook methodsFor: 'modules'!
modulesRemove: key
	modules removeKey: key ifAbsent: [^self error: 'Parent modules must be removed from parent']! !

!SwikiSubBook methodsFor: 'inheritance'!
hasParent
	^true! !

!SwikiSubBook methodsFor: 'inheritance'!
hasSuper: aBook
	^(parent = aBook)
		ifTrue: [true]
		ifFalse: [parent hasSuper: aBook]! !

!SwikiSubBook methodsFor: 'inheritance'!
parent
	^parent! !

!SwikiSubBook methodsFor: 'inheritance'!
parent: aBook
	parent _ aBook! !

!SwikiSubBook methodsFor: 'private'!
bookActionNamed: actionName
	^bookActions at: actionName ifAbsent: [parent bookActionNamed: actionName]! !

!SwikiSubBook methodsFor: 'private'!
bookAddressNamed: addressName
	^bookAddresses at: addressName ifAbsent: [parent bookAddressNamed: addressName]! !

!SwikiSubBook methodsFor: 'private'!
bookTemplateNamed: templateName
	^bookTemplates at: templateName ifAbsent: [parent bookTemplateNamed: templateName]! !

!SwikiSubBook methodsFor: 'private'!
pageActionNamed: actionName
	^pageActions at: actionName ifAbsent: [parent pageActionNamed: actionName]! !

!SwikiSubBook methodsFor: 'private'!
pageAddressNamed: addressName
	^pageAddresses at: addressName ifAbsent: [parent pageAddressNamed: addressName]! !

!SwikiSubBook methodsFor: 'private'!
pageTemplateNamed: templateName
	^pageTemplates at: templateName ifAbsent: [parent pageTemplateNamed: templateName]! !

!SwikiSubBook methodsFor: 'private'!
privAddressNamed: addressName
	^privAddresses at: addressName ifAbsent: [parent privAddressNamed: addressName]! !

!SwikiSubBook methodsFor: 'testing'!
hasBookAction: actionName
	^(bookActions includesKey: actionName)
		ifTrue: [true]
		ifFalse: [parent hasBookAction: actionName]! !

!SwikiSubBook methodsFor: 'testing'!
hasBookAddress: addressName
	^(bookAddresses includesKey: addressName)
		ifTrue: [true]
		ifFalse: [parent hasBookAddress: addressName]! !

!SwikiSubBook methodsFor: 'testing'!
hasBookTemplate: templateName
	^(bookTemplates includesKey: templateName)
		ifTrue: [true]
		ifFalse: [parent hasBookTemplate: templateName]! !

!SwikiSubBook methodsFor: 'testing'!
hasPageAction: actionName
	^(pageActions includesKey: actionName)
		ifTrue: [true]
		ifFalse: [parent hasPageAction: actionName]! !

!SwikiSubBook methodsFor: 'testing'!
hasPageAddress: addressName
	^(pageAddresses includesKey: addressName)
		ifTrue: [true]
		ifFalse: [parent hasPageAddress: addressName]! !

!SwikiSubBook methodsFor: 'testing'!
hasPageTemplate: templateName
	^(pageTemplates includesKey: templateName)
		ifTrue: [true]
		ifFalse: [parent hasPageTemplate: templateName]! !

!SwikiSubBook methodsFor: 'testing'!
hasPrivAddress: addressName
	^(privAddresses includesKey: addressName)
		ifTrue: [true]
		ifFalse: [parent hasPrivAddress: addressName]! !

!SwikiSubBook methodsFor: 'settings'!
settings
	^(parent settings) addAll: settings! !

!SwikiSubBook methodsFor: 'settings'!
settingsAt: key
	^settings at: key ifAbsent: [parent settingsAt: key]! !

!SwikiSubBook methodsFor: 'settings'!
settingsAt: key ifAbsent: block
	^settings at: key ifAbsent: [parent settingsAt: key ifAbsent: block]! !

!SwikiSubBook methodsFor: 'settings'!
settingsIncludes: key
	^(settings includesKey: key)
		ifTrue: [true]
		ifFalse: [parent settingsIncludes: key]! !

!SwikiSubBook methodsFor: 'settings'!
settingsRemove: key
	settings removeKey: key ifAbsent: [self error: 'Parent settings must be removed from parent']! !

!SwikiSubBook methodsFor: 'storage'!
loadPages
	| kind |
	kind _ setup at: 'pageStorage' ifAbsent: [XmlSwikiStorage].
	(storage dir directoryExists: 'pages')
		ifTrue: [
			pages _ (kind fromDir: (storage dir directoryNamed: 'pages')) loadPages.
			pages do: [:page | nameToPage at: (page name) put: page]]
		ifFalse: [
			pages _ parent pages.
			nameToPage _ parent nameToPage].! !


!SwikiSubDirectory methodsFor: 'accessing'!
containingDirectory
	^containingDirectory! !

!SwikiSubDirectory methodsFor: 'accessing'!
containingDirectory: aSwikiDirectory
	containingDirectory _ aSwikiDirectory! !

!SwikiSubDirectory methodsFor: 'accessing'!
httpPath
	^(containingDirectory httpPath), (self localHttpPath)! !

!SwikiSubDirectory methodsFor: 'accessing'!
localHttpPath
	^self httpName, '/'! !

!SwikiSubDirectory methodsFor: 'testing'!
isASubDirectory
	^true! !

!SwikiSubDirectory methodsFor: 'initialization'!
initializeDirectories
	super initializeDirectories.
	"dirServeCache"
	containingDirectory addToDirServeCache: self at: self localHttpPath! !

!SwikiSubDirectory methodsFor: 'cacheing'!
addToDirServeCache: aSubSwikiDir at: key
	super addToDirServeCache: aSubSwikiDir at: key.
	"Recurse Upward in Hierarchy"
	containingDirectory addToDirServeCache: aSubSwikiDir at: (self localHttpPath, key)! !


!SwikiSubDirectory class methodsFor: 'instance creation' stamp: 'xw 5/11/2022 22:12'!
fromDirectoryEntry: entry onDir: dir containingDirectory: aSwikiDirectory
	| instance |
	instance := self fromDirectoryEntry: entry.
	instance dir: dir.
	instance containingDirectory: aSwikiDirectory.
	instance initialize.
	^instance! !


!SwikiSurveyEntry methodsFor: 'storage'!
asXml
	| document votes survey entry |
	survey _ XMLElement named: 'survey' attributes: (Dictionary new).
	survey attributeAt: #name put: self name.
	from ifNotNil: [survey attributeAt: #from put: from asString].
	to ifNotNil: [survey attributeAt: #to put: to asString].
	votes _ XMLElement named: 'votes' attributes: (Dictionary new).
	keyToVotes keysAndValuesDo: [:key :value |
		entry _ XMLElement named: 'vote' attributes: (Dictionary new).
		entry attributeAt: 'name' put: key.
		entry contents add: (XMLStringNode string: value asString).
		votes addElement: entry].
	survey addElement: votes.
	document _ XMLDocument new.
	document version: '1.0'.
	document addElement: survey.
	^document! !

!SwikiSurveyEntry methodsFor: 'storage'!
save
	| text fileName |
	"Save as XML"
	text _ String streamContents: [:stream | self asXml printXMLOn: (XMLWriter on: stream)].
	"Save text onto file"
	fileName _ id asString, '.xml'.
	module forbidWriting.
	(module dir fileExists: fileName) ifTrue: [
		module dir deleteFileNamed: fileName].
	(module dir fileNamed: fileName)
		nextPutAll: text;
		close.
	module permitWriting! !

!SwikiSurveyEntry methodsFor: 'accessing'!
averageString
	| sum votes totalVotes |
	sum _ 0.
	totalVotes _ 0.
	self range do: [:key |
		votes _ keyToVotes at: key asString ifAbsent: [0].
		sum _ sum + (votes * key).
		totalVotes _ totalVotes + votes].
	^(totalVotes = 0)
		ifTrue: ['n/a']
		ifFalse: [((sum * 10 / totalVotes) rounded / 10.0) asString]! !

!SwikiSurveyEntry methodsFor: 'accessing'!
id: aNumber
	id _ aNumber! !

!SwikiSurveyEntry methodsFor: 'accessing'!
maxVotes
	^keyToVotes values max! !

!SwikiSurveyEntry methodsFor: 'accessing'!
module: aSwikiSurveyModule
	module _ aSwikiSurveyModule! !

!SwikiSurveyEntry methodsFor: 'accessing'!
name
	^name! !

!SwikiSurveyEntry methodsFor: 'accessing'!
range
	^(from > to)
		ifTrue: [from to: to by: -1]
		ifFalse: [from to: to]! !

!SwikiSurveyEntry methodsFor: 'accessing'!
rangeStrings
	^self range collect: [:i | i asString]! !

!SwikiSurveyEntry methodsFor: 'accessing'!
results
	^self hasRange
		ifTrue: [self resultsWithRange]
		ifFalse: [self resultsWithoutRange]! !

!SwikiSurveyEntry methodsFor: 'accessing'!
resultsWithRange
	| return keys sort |
	return _ OrderedCollection new.
	keys _ keyToVotes keys.
	self rangeStrings do: [:key |
		return add: (Array with: key with: (keyToVotes at: key ifAbsent: [0])).
		keys remove: key ifAbsent: []].
	keys isEmpty ifFalse: [
		sort _ SortedCollection sortBlock: [:a :b |
			(a at: 2) > (b at: 2)].
		keys do: [:key | sort add: (Array with: key with: (keyToVotes at: key))].
		return addAll: sort].
	^return asArray! !

!SwikiSurveyEntry methodsFor: 'accessing'!
resultsWithoutRange
	| return |
	return _ SortedCollection sortBlock: [:a :b |
		(a at: 2) > (b at: 2)].
	keyToVotes keysAndValuesDo: [:key :vote |
		return add: (Array with: key with: vote)].
	^return asArray! !

!SwikiSurveyEntry methodsFor: 'accessing'!
sumVotes
	^keyToVotes values sum! !

!SwikiSurveyEntry methodsFor: 'testing'!
hasRange
	^from notNil! !

!SwikiSurveyEntry methodsFor: 'initializing'!
initializeFromName: aString
	"Initialize Survey entry from a name"
	name _ aString.
	from _ nil.
	to _ nil.
	keyToVotes _ Dictionary new! !

!SwikiSurveyEntry methodsFor: 'initializing'!
initializeFromXml: xml
	| document |
	"Initialize Survey entry from XML"
	document _ xml elements at: 1.
	name _ document attributeAt: 'name'.
	(from _ document attributeAt: 'from' ifAbsent: [nil]) ifNotNil: [
		from _ from asNumber].
	(to _ document attributeAt: 'to' ifAbsent: [nil]) ifNotNil: [
		to _ to asNumber].
	keyToVotes _ Dictionary new.
	(document elements at: 1) elementsDo: [:entryXml | keyToVotes at: (entryXml attributeAt: 'name') put: ((entryXml contents at: 1) string asNumber)]! !

!SwikiSurveyEntry methodsFor: 'processing'!
assureFrom: newFrom to: newTo
	((newFrom = from) and: [newTo = to]) ifTrue: [^self].
	from _ newFrom.
	to _ newTo.
	self save! !

!SwikiSurveyEntry methodsFor: 'processing'!
assureKey: key
	(keyToVotes includesKey: key) ifFalse: [
		keyToVotes at: key put: 0.
		self save]! !

!SwikiSurveyEntry methodsFor: 'processing'!
voteKey: key
	(keyToVotes includesKey: key)
		ifTrue: [
			keyToVotes at: key put: ((keyToVotes at: key) + 1)]
		ifFalse: [
			keyToVotes at: key put: 1].
	self save! !


!SwikiSurveyEntry class methodsFor: 'instance creation'!
newFromName: aString
	^(self new)
		initializeFromName: aString;
		yourself! !

!SwikiSurveyEntry class methodsFor: 'instance creation'!
newFromXml: xml
	^self new
		initializeFromXml: xml;
		yourself! !


!SwikiSurveyModule methodsFor: 'storage'!
forbidWriting
	sema wait! !

!SwikiSurveyModule methodsFor: 'storage'!
permitWriting
	sema signal! !

!SwikiSurveyModule methodsFor: 'accessing'!
dir
	^dir! !

!SwikiSurveyModule methodsFor: 'accessing'!
dir: aFileDirectory
	dir _ aFileDirectory! !

!SwikiSurveyModule methodsFor: 'accessing'!
survey: surveyName
	^nameToSurvey at: surveyName asLowercase! !

!SwikiSurveyModule methodsFor: 'accessing'!
survey: surveyName ifAbsent: aBlock
	^nameToSurvey at: surveyName asLowercase ifAbsent: aBlock! !

!SwikiSurveyModule methodsFor: 'initializing'!
initialize
	| fileNames fileName id entry |
	sema _ Semaphore forMutualExclusion.
	nameToSurvey _ Dictionary new.
	fileNames _ dir fileNames.
	id _ 1.
	[fileNames includes: (fileName _ id asString, '.xml')] whileTrue: [
		entry _ SwikiSurveyEntry newFromXml: (XMLDOMParser parseDocumentFrom: (dir fileNamed: fileName)).
		entry id: id.
		entry module: self.
		nameToSurvey at: entry name put: entry.
		id _ id + 1]! !

!SwikiSurveyModule methodsFor: 'processing'!
addNewSurveyNamed: newName
	| id newSurvey |
	id _ nameToSurvey size + 1.
	newSurvey _ SwikiSurveyEntry newFromName: newName.
	newSurvey id: id.
	newSurvey module: self.
	nameToSurvey at: newSurvey name put: newSurvey.
	^newSurvey! !

!SwikiSurveyModule methodsFor: 'processing'!
assureSurvey: surveyName from: from to: to
	| lookup |
	lookup _ surveyName asLowercase.
	(nameToSurvey at: lookup ifAbsent: [self addNewSurveyNamed: lookup])
		assureFrom: from to: to! !

!SwikiSurveyModule methodsFor: 'processing'!
assureSurvey: surveyName key: key
	| lookup |
	lookup _ surveyName asLowercase.
	(nameToSurvey at: lookup ifAbsent: [self addNewSurveyNamed: lookup])
		assureKey: key! !

!SwikiSurveyModule methodsFor: 'processing'!
voteSurvey: surveyName key: key
	| lookup |
	lookup _ surveyName asLowercase.
	(nameToSurvey at: lookup ifAbsent: [self addNewSurveyNamed: lookup])
		voteKey: key! !


!SwikiSurveyModule class methodsFor: 'instance creation'!
onDir: aFileDirectory
	^(self basicNew)
		dir: aFileDirectory;
		initialize;
		yourself! !


!SwikiUser methodsFor: 'accessing'!
id
	^id! !

!SwikiUser methodsFor: 'accessing'!
idAsString
	^id asString! !

!SwikiUser methodsFor: 'accessing'!
internalId
	^self id! !

!SwikiUser methodsFor: 'accessing'!
name
	^name! !

!SwikiUser methodsFor: 'accessing'!
name: aString
	(aString = '') ifTrue: [^nil].
	(aString = name) ifTrue: [^self].
	(module hasUserNamed: aString) ifTrue: [^nil].
	module nameToUser
		removeKey: name;
		at: aString put: self.
	name _ aString! !

!SwikiUser methodsFor: 'settings'!
address
	^self settingsAt: 'address'! !

!SwikiUser methodsFor: 'settings'!
address: address
	"E-mail Address"
	self settingsAt: 'address' put: address! !

!SwikiUser methodsFor: 'settings'!
home
	^self homeIfAbsent: [nil]! !

!SwikiUser methodsFor: 'settings'!
home: aSwikiBook
	self settingsAt: (aSwikiBook name, '-home') put: true.
	"If user doesn't alread have a home, make it theirs"
	(self settingsIncludes: 'home') ifFalse: [
		self settingsAt: 'home' put: (aSwikiBook name)]! !

!SwikiUser methodsFor: 'settings'!
homeIfAbsent: aBlock
	^self settingsAt: 'home' ifAbsent: aBlock! !

!SwikiUser methodsFor: 'settings'!
isOwnerOfBook: book put: value
	| check |
	check _ book name, '-home'.
	(self settingsAt: check ifAbsent: [false])
		ifTrue: [value ifFalse: [self
			settingsRemove: check;
			save]]
		ifFalse: [value ifTrue: [self
			settingsAt: check put: true;
			save]]! !

!SwikiUser methodsFor: 'settings'!
password
	^self settingsAt: 'password'! !

!SwikiUser methodsFor: 'settings'!
password: password
	self settingsAt: 'password' put: password! !

!SwikiUser methodsFor: 'settings'!
settings
	^settings! !

!SwikiUser methodsFor: 'settings'!
settingsAt: key
	^settings at: key! !

!SwikiUser methodsFor: 'settings'!
settingsAt: key ifAbsent: block
	^settings at: key ifAbsent: block! !

!SwikiUser methodsFor: 'settings'!
settingsAt: key put: value
	settings at: key put: value! !

!SwikiUser methodsFor: 'settings'!
settingsIncludes: key
	^settings includesKey: key! !

!SwikiUser methodsFor: 'settings'!
settingsRemove: key
	^settings removeKey: key ifAbsent: []! !

!SwikiUser methodsFor: 'testing'!
hasConsented
	^self settingsAt: 'hasConsented' ifAbsent: [false]! !

!SwikiUser methodsFor: 'testing'!
isOwnerOfBook: aSwikiBook
	^self settingsAt: (aSwikiBook name, '-home') ifAbsent: [false]! !

!SwikiUser methodsFor: 'storage'!
asXml
	| document user entry settingsXml typeAndValue |
	user _ XMLElement named: 'user' attributes: (Dictionary new).
	user attributeAt: #name put: self name.
	settingsXml _ XMLElement named: 'settings' attributes: (Dictionary new).
	settings keysAndValuesDo: [:key :value |
		entry _ XMLElement named: 's' attributes: (Dictionary new).
		entry attributeAt: 'name' put: key.
		typeAndValue _ XmlSwikiStorage typeAndStringFromObject: value.
		entry attributeAt: 'type' put: (typeAndValue at: 1).
		entry contents add: (XMLStringNode string: (typeAndValue at: 2)).
		settingsXml addElement: entry].
	user addElement: settingsXml.
	document _ XMLDocument new.
	document version: '1.0'.
	document addElement: user.
	^document! !

!SwikiUser methodsFor: 'storage'!
save
	| text fileName |
	"Save as XML"
	text _ String streamContents: [:stream | self asXml printXMLOn: (XMLWriter on: stream)].
	"Save text onto file"
	fileName _ id asString, '.xml'.
	module forbidWriting.
	(module dir fileExists: fileName) ifTrue: [
		module dir deleteFileNamed: fileName].
	(module dir fileNamed: fileName)
		nextPutAll: text;
		close.
	module permitWriting! !

!SwikiUser methodsFor: 'initialization'!
id: anInteger
	id _ anInteger! !

!SwikiUser methodsFor: 'initialization'!
initializeFromName: aString
	name _ aString.
	settings _ Dictionary new! !

!SwikiUser methodsFor: 'initialization'!
initializeFromXml: xml
	| document key value |
	"Initialize user from XML"
	document _ xml elements at: 1.
	name _ document attributeAt: 'name'.
	settings _ Dictionary new.
	(document elements at: 1) elementsDo: [:settingXml |
		key _ settingXml attributeAt: 'name'.
		value _ settingXml contents.
		value _ value isEmpty ifTrue: [''] ifFalse: [(value at: 1) string].
		value _ XmlSwikiStorage objectFromType: (settingXml attributeAt: 'type') value: value.
		settings at: key put: value]! !

!SwikiUser methodsFor: 'initialization'!
module: aSwikiUsersModule
	module _ aSwikiUsersModule! !

!SwikiUser methodsFor: 'utility'!
survey: surveyName data: aDict
	"Save initial survey as XML"
	| fileName |
	fileName _ (id asString, '-', surveyName, '.xml')! !


!SwikiUser class methodsFor: 'instance creation'!
newFromName: aString
	^self new
		initializeFromName: aString;
		yourself! !

!SwikiUser class methodsFor: 'instance creation'!
newFromXml: xml
	^self new
		initializeFromXml: xml;
		yourself! !


!SwikiUsersModule methodsFor: 'accessing'!
dir
	^dir! !

!SwikiUsersModule methodsFor: 'accessing'!
nameToUser
	^nameToUser! !

!SwikiUsersModule methodsFor: 'accessing'!
userAtId: id
	^idToUser at: id! !

!SwikiUsersModule methodsFor: 'accessing'!
userAtId: id ifAbsent: aBlock
	^idToUser at: id ifAbsent: aBlock! !

!SwikiUsersModule methodsFor: 'accessing'!
userAtName: name
	^nameToUser at: name! !

!SwikiUsersModule methodsFor: 'accessing'!
userAtName: name ifAbsent: absentBlock
	^nameToUser at: name ifAbsent: absentBlock! !

!SwikiUsersModule methodsFor: 'accessing'!
users
	^nameToUser values! !

!SwikiUsersModule methodsFor: 'storage'!
forbidWriting
	sema wait! !

!SwikiUsersModule methodsFor: 'storage'!
permitWriting
	sema signal! !

!SwikiUsersModule methodsFor: 'testing'!
hasUserNamed: aString
	^nameToUser includesKey: aString! !

!SwikiUsersModule methodsFor: 'initialization'!
dir: aFileDirectory
	dir _ aFileDirectory! !

!SwikiUsersModule methodsFor: 'initialization'!
importUser: user
	"Check if the user already exists"
	| oldUser |
	(self hasUserNamed: user name)
		ifTrue: ["The user already exist; add new privileges"
			oldUser _ nameToUser at: user name.
			user settings keysAndValuesDo: [:key :setting |
				(key = 'password') ifFalse: [
					oldUser settingsAt: key put: setting]].
			oldUser save.
			^oldUser]
		ifFalse: ["Add user as is"
			user id: self nextUserId.
			user module: self.
			idToUser at: (user id) put: user.
			nameToUser at: (user name) put: user.
			user save.
			^user]! !

!SwikiUsersModule methodsFor: 'initialization'!
initialize
	| id entry |
	sema _ Semaphore forMutualExclusion.
	nameToUser _ Dictionary new.
	idToUser _ Dictionary new.
	dir fileNames do: [:fileName | (fileName endsWith: '.xml') ifTrue: [
		id _ fileName copyUpTo: $..
		id isAllDigits ifTrue: [
			id _ id asNumber.
			entry _ SwikiUser newFromXml: (XMLDOMParser parseDocumentFrom: (dir fileNamed: fileName)).
			entry id: id.
			entry module: self.
			idToUser at: id put: entry.
			nameToUser at: entry name put: entry]]].! !

!SwikiUsersModule methodsFor: 'initialization'!
nextUserId
	| i |
	i _ 1.
	[idToUser includesKey: i] whileTrue: [i _ i + 1].
	^i! !

!SwikiUsersModule methodsFor: 'processing'!
addNewUserNamed: aName
	^self addNewUserNamed: aName id: self nextUserId! !

!SwikiUsersModule methodsFor: 'processing'!
addNewUserNamed: username id: id
	| user |
	user _ SwikiUser newFromName: username.
	user id: id.
	user module: self.
	idToUser at: id put: user.
	nameToUser at: username put: user.
	^user! !

!SwikiUsersModule methodsFor: 'processing'!
processRequest: aSwikiRequest
	| username user |
	(username _ aSwikiRequest getUsername) ifNil: [^self].
	user _ nameToUser at: username ifAbsent: [^self].
	(aSwikiRequest isUsername: username password: user password) ifTrue: [
		aSwikiRequest security: user]! !

!SwikiUsersModule methodsFor: 'processing'!
signInRequest: aSwikiRequest
	| user password username |
	username _ aSwikiRequest fieldsKey: 'user' ifAbsent: [^self].
	password _ aSwikiRequest fieldsKey: 'password' ifAbsent: [^self].
	user _ nameToUser at: username ifAbsent: [^self].
	(user password = password) ifFalse: [^self].
	aSwikiRequest security: user.
	aSwikiRequest setUsername: username password: password! !

!SwikiUsersModule methodsFor: 'processing'!
updateOwners: request response: response shelf: shelf book: book
	| members |
	members _ request fieldsKey: 'members' ifAbsent: [''].
	members _ members findTokens: (' ,	', String crlf).
	members _ members collect: [:i | i asLowercase].
	members _ members asSet.
	"Always include current user as owner"
	members add: (request security address asLowercase).
	self users do: [:user | user
		isOwnerOfBook: book
		put: (members includes: (user address asLowercase))]! !

!SwikiUsersModule methodsFor: 'utility'!
ownersOfBook: book
	^self users select: [:user | user isOwnerOfBook: book]! !

!SwikiUsersModule methodsFor: 'utility'!
usersWithAddress: aString
	^idToUser values select: [:i | i address = aString]! !


!SwikiUsersModule class methodsFor: 'instance creation'!
onDir: aFileDirectory
	^self basicNew
		dir: aFileDirectory;
		initialize;
		yourself! !


!TextFormatter methodsFor: 'initializing'!
initialize
	match _ CharacterSet new.
	formattingArray _ Array new: 255.! !

!TextFormatter methodsFor: 'accessing'!
addAction: block from: beginning to: end
	"When the Action is performed, the text is scanned for things that start with beginning
	and stop with end. Whatever is between these two is then put into the block and what
	gets returned is fed to the formatted document."
	"The format for an Action is a 3 element array of (beginning end block)."
	| starts formatter |

	starts _ beginning at: 1.
	match add: starts.
	formatter _ Array new: 3.
	beginning size = 1
		ifTrue: [formatter at: 1 put: '']
		ifFalse: [formatter at: 1 put: (beginning copyFrom: 2 to: beginning size)].
	formatter at: 2 put: end.
	formatter at: 3 put: block.
	self addFormatter: formatter at: (starts asInteger).! !

!TextFormatter methodsFor: 'accessing'!
addMappingFrom: original to: replacement
	"A Mapping is when the text is scanned and all instances of original are mapped to
	their replacements."
	"The format for a Mapping is an 3 element array of (original nil replacement)."
	| starts formatter |

	starts _ original at: 1.
	match add: starts.
	formatter _ Array new: 3.
	original size = 1
		ifTrue: [formatter at: 1 put: '']
		ifFalse: [formatter at: 1 put: (original copyFrom: 2 to: original size)].
	formatter at: 3 put: replacement.
	self addFormatter: formatter at: (starts asInteger).! !

!TextFormatter methodsFor: 'accessing'!
remove: key
	"Removes a formatter (action, mapping) from the TextFormatter."
	"It remove it if it matches the orginal for a mapping or the beginning for an action."
	| starts formatters ends |

	starts _ key at: 1. "First character in the key."
	formatters _ formattingArray at: (starts asInteger).
	formatters ifNil: ["There is no matching formatter, so stop" ^nil]
		ifNotNil: [((key size) = 1) ifTrue: [ends _ ''] ifFalse: [ends _ key copyFrom: 2 to: (key size)].
			formatters do: [:element | ((element at: 1) = ends) ifTrue: [formatters remove: element]].
			((formatters size) = 0) ifTrue: [
				formattingArray at: (starts asInteger) put: nil. "Removes formatter"
				match remove: starts. "Removes from match"
			]
		].
	^nil! !

!TextFormatter methodsFor: 'private'!
action: action value: value text: text
	^(action copy fixTemps) value: text! !

!TextFormatter methodsFor: 'private'!
addFormatter: formatter at: position
	"Adds a formatter to the position in the formattingArray."
	| formatters |

	formatters _ formattingArray at: position.
	formatters isNil
		ifTrue: [formatters _ SortedCollection new sortBlock: [:x :y | (x at: 1) size >= (y at: 1) size].
			formattingArray at: position put: formatters].
	formatters add: formatter.
! !

!TextFormatter methodsFor: 'private'!
format: text actionValue: value onTo: stream
	"Apply all the formatting on text and put it onto stream."
	| pos i maxSize formatters index formatter |

	"i is the position of a match"
	pos _ 1. "Position in text, marking the seperation of processed and yet to be processed"
	[(i _ text indexOfAnyOf: match startingAt: pos) > 0]
		whileTrue: [stream nextPutAll: (text copyFrom: pos to: i-1). "No formatting in this space"
			maxSize _ text size - i.
			formatters _ formattingArray at: (text at: i) asInteger.
			index _ 1.
			[formatters size >= index] "Index of Formatters"
				whileTrue: [ "see if formatters match"
					formatter _ formatters at: index.
					"Check that size of formatter is allowed."
					(maxSize >= (formatter at: 1) size) ifTrue: [
						"Check if the formatter matches"
						((text copyFrom: (i + 1) to: (i + (formatter at: 1) size)) = (formatter at: 1))
							ifTrue: [ index _ formatters size + 1. "Match => exit loop"
								"Set i to beyond beginning marker"
								pos _ i + 1 + (formatter at: 1) size.
								(formatter at: 2)
									ifNil: [ "Mapping"
											stream nextPutAll: (formatter at: 3)
										]
									ifNotNil: [ "Action"
											"This does not allow nesting, but that's probably good."
											i _ text findString: (formatter at: 2) startingAt: pos.
											"Check for no closing"
											i > 0 ifTrue: [stream nextPutAll: (self action: (formatter at: 3) value: value text: (text copyFrom: pos to: i-1)).
													pos _ i + (formatter at: 2) size
												]
										]
								]
						].
					index _ index + 1.
				].
				"Check for no formatter matched"
				((formatters size) = (index - 1)) ifTrue: [stream nextPut: (text at: i). pos _ i + 1]
		].
		"Add last section if there is one."
		(pos <= text size) ifTrue: [stream nextPutAll: (text copyFrom: pos to: (text size))].
	 ^stream! !

!TextFormatter methodsFor: 'processing'!
format: text
	"Apply all the formatting to the text and return it as a stream"
	| return |

	"Create a new stream to write it on."
	return _ WriteStream on: (String new: text size).
	self format: text onTo: return.
	^return contents
! !

!TextFormatter methodsFor: 'processing'!
format: text onTo: stream
	^self format: text actionValue: nil onTo: stream! !


!BookTemplateFormatter methodsFor: 'private'!
action: action value: value text: text
	"Overwrites parent class to add swiki action"
	^(value size = 5)
		ifTrue: ["Page Request"
			(value at: 4) formatPageAction: text with: value]
		ifFalse: ["Book Request"
			(value at: 4) formatBookAction: text with: value]! !

!BookTemplateFormatter methodsFor: 'processing'!
format: template request: request response: response shelf: shelf book: book
	"Formatting used for a book request"
	| value stream |

	stream _ WriteStream on: (String new: template size).
	value _ Array with: request with: response with: shelf with: book.
	self format: template actionValue: value onTo: stream.
	^stream contents! !

!BookTemplateFormatter methodsFor: 'processing'!
format: template request: request response: response shelf: shelf book: book page: page
	"Formatting used for a page request"
	| value stream |

	stream _ WriteStream on: (String new: template size).
	value _ Array with: request with: response with: shelf with: book with: page.
	self format: template actionValue: value onTo: stream.
	^stream contents! !


!PageFormatter methodsFor: 'accessing'!
storeID
	^storeID! !

!PageFormatter methodsFor: 'accessing'!
storeID: id
	storeID _ id! !

!PageFormatter methodsFor: 'private'!
action: action value: value text: text
	value at: 1 put: text.
	^action copy fixTemps valueWithArguments: value! !

!PageFormatter methodsFor: 'private'!
storeString
	"Overwrite of Object method to save space for storing"
	(storeID) ifNotNil: ["Check to make sure this storeID is valid"
		(self class respondsTo: storeID)
			ifTrue: [^'(', self class asString, ' ', storeID asString, ')']].
	^super storeString! !

!PageFormatter methodsFor: 'utility'!
changeLinks: text request: request response: response shelf: shelf book: book page: page
	"edit formatter"
	| alias remaining pageEntry |

	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: [alias _ (remaining copyUpTo: $>), '>'.
			((alias size) = (remaining size))
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: (alias size + 1) to: (remaining size)]]
		ifFalse: [alias _ ''].
	"e-mail address"
	(NuSwikiPage isTextAnEmailAddress: remaining)
		ifTrue: [^'*', (TextFormatter encodeToXmlCrlf: (alias, remaining)), '*'].
	"http address"
	(NuSwikiPage hasAProtocol: remaining)
		ifTrue: [^'*', (TextFormatter encodeToXmlCrlf: (alias, remaining)), '*'].
	"Get pageEntry"
	(remaining includes: $@)
		ifTrue: [pageEntry _ remaining copyUpTo: $@.
			remaining _ remaining copyFrom: (pageEntry size + 1) to: (remaining size)]
		ifFalse: [pageEntry _ remaining.
			remaining _ ''].
	"Transform digit to title"
	((pageEntry isAllDigits) and: [pageEntry ~= ''])
		ifTrue: [(book pages size) >= (pageEntry asNumber)
			ifTrue: [^'*', (TextFormatter encodeToXmlCrlf: (alias, (book pages at: pageEntry asNumber) name, remaining)), '*']].
	^'*', (TextFormatter encodeToXmlCrlf: (alias, pageEntry, remaining)), '*'! !

!PageFormatter methodsFor: 'utility'!
internalLinks: text request: request response: response shelf: shelf book: book page: page
	"show formatter"
	| alias remaining pageEntry location lPage url |

	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: [alias _ (remaining copyUpTo: $>).
			((alias size + 1) = (remaining size))
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: (alias size + 2) to: (remaining size)].
			alias _ PageFormatter toSafeAlias: alias]
		ifFalse: [alias _ ''].
	"URL address"
	(NuSwikiPage hasAProtocol: remaining)
		ifTrue: [url _ NuSwikiPage urlForProtocolText: remaining.
			(self class isAnImage: remaining)
				ifTrue: [(alias = '')
					ifTrue: [^'<img alt="External Image" src="', url, '">']
					ifFalse: [^'<img alt="', alias, '" src="', url, '">']]
				ifFalse: [(alias = '')
					ifTrue: [^'<a class="external" href="', url, '">', remaining, '</a>']
					ifFalse: [^'<a class="external" href="', url, '">', alias, '</a>']]].
	"e-mail address"
	(NuSwikiPage isTextAnEmailAddress: remaining)
		ifTrue: [(alias = '')
			ifTrue: [^'<a class="external" href="mailto:', remaining, '">', remaining, '</a>']
			ifFalse: [^'<a class="external" href="mailto:', remaining, '">', alias, '</a>']].
	"Get pageEntry and location"
	(remaining includes: $@)
		ifTrue: [pageEntry _ remaining copyUpTo: $@.
			((pageEntry size + 1) = (remaining size))
				ifTrue: [location _ '']
				ifFalse: [location _ remaining copyFrom: (pageEntry size + 2) to: (remaining size)]]
		ifFalse: [pageEntry _ remaining.
			location _ ''].
	"No page entry"
	(pageEntry = '') ifTrue: [(location = '')
		ifTrue: [^'Error: this should not happen']
		ifFalse: [(alias = '')
			ifTrue: [^'<a class="internal" href="#', (PageFormatter toSafeLocation: location), '">', (PageFormatter toSafeAlias: location), '</a>']
			ifFalse: [^'<a class="internal" href="#', (PageFormatter toSafeLocation: location), '">', alias, '</a>']]].
	"Page Link"
	(alias = '')
		ifTrue: [request settingsRemove: 'alias']
		ifFalse: [request settingsAt: 'alias' put: alias].
	(location = '')
		ifTrue: [request settingsRemove: 'location']
		ifFalse: [request settingsAt: 'location' put: location].
	(pageEntry isAllDigits)
		ifTrue: [(book pages size) >= (pageEntry asNumber)
			ifTrue: [lPage _ book pages at: pageEntry asNumber]
			ifFalse: [^'Error: this should not happen']]
		ifFalse: [(book hasPageNamed: pageEntry)
			ifTrue: [lPage _ book pageNamed: pageEntry]
			ifFalse: ["New Page: uses newlink.page template"
				request settingsAt: 'pageEntry' put: pageEntry.
				^book formatPageTemplate: 'newLink' request: request response: response shelf: shelf page: page]].
	"Existing Page: uses link.page template"
	^book formatPageTemplate: 'link' request: request response: response shelf: shelf page: lPage.! !

!PageFormatter methodsFor: 'utility'!
plugin: text request: request response: response shelf: shelf book: book page: page
	| function options graph value to from |
	function _ LineFormatter parseFunctionAndOptionsFromText: text.
	options _ function at: 2.
	function _ function at: 1.
	function caseOf: {
		['vote']->[(graph _ options at: 'graph' ifAbsent: [nil]) ifNotNil: [
			(value _ options at: 'value' ifAbsent: [nil])
				ifNil: [
					to _ LineFormatter numberOrNilFromString: (options at: 'to' ifAbsent: [nil]).
					from _ LineFormatter numberOrNilFromString: (options at: 'from' ifAbsent: [nil]).
					(to notNil and: [from notNil]) ifTrue: [
						(book modulesAt: 'surveys') assureSurvey: graph from: from to: to]]
				ifNotNil: [(book modulesAt: 'surveys') assureSurvey: graph key: value]]]}
		otherwise: ["Do nothing"].
	^'<?', (TextFormatter crlfToCr: text), '?>'! !

!PageFormatter methodsFor: 'utility'!
renderInternalLinks: text request: request response: response shelf: shelf book: book page: page
	"render formatter"
	| alias remaining pageEntry rawLocation location lPage url |

	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: [alias _ (remaining copyUpTo: $>).
			((alias size + 1) = (remaining size))
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: (alias size + 2) to: (remaining size)].
			alias _ PageFormatter toSafeAlias: alias]
		ifFalse: [alias _ ''].
	"e-mail address"
	(NuSwikiPage isTextAnEmailAddress: remaining)
		ifTrue: [(alias = '')
			ifTrue: [^'<a href="mailto:', remaining, '">', remaining, '</a>']
			ifFalse: [^'<a href="mailto:', remaining, '">', alias, '</a>']].
	"URL address"
	(NuSwikiPage hasAProtocol: remaining)
		ifTrue: [url _ NuSwikiPage urlForProtocolText: remaining.
			(self class isAnImage: remaining)
				ifTrue: [(alias = '')
					ifTrue: [^'<img alt="External Image" src="', url, '">']
					ifFalse: [^'<img alt="', alias, '" src="', url, '">']]
				ifFalse: [(alias = '')
					ifTrue: [^'<a href="', url, '">', remaining, '</a>']
					ifFalse: [^'<a href="', url, '">', alias, '</a>']]].
	"Get pageEntry and location"
	(remaining includes: $@)
		ifTrue: [pageEntry _ remaining copyUpTo: $@.
			((pageEntry size + 1) = (remaining size))
				ifTrue: [location _ '']
				ifFalse: [location _ remaining copyFrom: (pageEntry size + 2) to: (remaining size)]]
		ifFalse: [pageEntry _ remaining.
			location _ ''].
	(location = '') ifFalse: [rawLocation _ (PageFormatter toSafeAlias: location).
		location _ '#', (PageFormatter toSafeLocation: location)].
	"No page entry"
	(pageEntry = '') ifTrue: [(location = '')
		ifTrue: [^'Error: this should not happen']
		ifFalse: [(alias = '')
			ifTrue: [^'<a href="', location, '">', rawLocation, '</a>']
			ifFalse: [^'<a href="', location, '">', alias, '</a>']]].
	"Existing page"
	(pageEntry isAllDigits)
		ifTrue: [
			lPage _ book pages at: (pageEntry asNumber) ifAbsent: [^'Error: this should not happen'].
			(alias = '')
				ifTrue: [(location = '')
					ifTrue: [^'<a href="', pageEntry, '.html">', lPage showName, '</a>']
					ifFalse: [^'<a href="', pageEntry, '.html', location, '">', (lPage showName), ' (', rawLocation, '(</a>']]
				ifFalse: [^'<a href="', pageEntry, '.html', location, '">', alias, '</a>']].
	"Page named this"
	(book hasPageNamed: pageEntry)
		ifTrue: [lPage _ book pageNamed: pageEntry.
			(alias = '')
				ifTrue: [(location = '')
					ifTrue: [^'<a href="', (lPage id asString), '.html">', (lPage showNameRequest: request book: book), '</a>']
					ifFalse: [^'<a href="', (lPage id asString), '.html', location, '">', (lPage showNameRequest: request book: book), ' (', rawLocation, ')</a>']]
				ifFalse: [^'<a href="', (lPage id asString), '.html', location, '">', alias, '</a>']].
	"New page (kind of stupid to render a link that isn't existing)"
	^'*', (TextFormatter encodeToXmlCrlf: text), '*'! !

!PageFormatter methodsFor: 'utility'!
renderUploadLinks: text request: request response: response shelf: shelf book: book page: page
	"render formatter"
	| alias remaining uploads pageUploads upload |

	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: [alias _ (remaining copyUpTo: $>).
			((alias size + 1) = (remaining size))
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: (alias size + 2) to: (remaining size)].
			alias _ PageFormatter toSafeAlias: alias]
		ifFalse: [alias _ ''].
	"use page upload server if possible"
	uploads _ book modulesAt: 'uploads'.
	(pageUploads _ uploads directoryNamed: (page id asString) ifAbsent: [nil])
		ifNil: [upload _ uploads fileRefsCacheAt: remaining ifAbsent: [nil]]
		ifNotNil: [(upload _ pageUploads fileRefsCacheAt: remaining ifAbsent: [nil])
			ifNil: [upload _ uploads fileRefsCacheAt: remaining ifAbsent: [nil]]
			ifNotNil: [uploads _ pageUploads]].
	upload
		ifNil: [^'Missing File (', (TextFormatter encodeToXmlCrlf: remaining), ')'].
	^upload last isAnImage
		ifTrue: ['<img src="uploads/', uploads httpPath, upload last httpName, '" width=', upload last width asString, ' height=', upload last height asString, ' alt="', ((alias = '') ifTrue: ['Uploaded Image: ', upload strictXmlName] ifFalse: [TextFormatter encodeToStrictXmlCrlf: alias]), '">']
		ifFalse: ['<a href="uploads/', uploads httpPath, upload last httpName, '">', ((alias = '') ifTrue: [upload xmlName] ifFalse: [TextFormatter encodeToStrictXmlCrlf: alias]), '</a>']! !

!PageFormatter methodsFor: 'utility'!
reverseLinks: text request: request response: response shelf: shelf book: book page: page
	"save formatter"
	| alias remaining pageEntry refId |

	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: [alias _ (remaining copyUpTo: $>), '>'.
			((alias size) = (remaining size))
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: (alias size + 1) to: (remaining size)]]
		ifFalse: [alias _ ''].
	"e-mail address"
	(NuSwikiPage isTextAnEmailAddress: remaining)
		ifTrue: [^'*', text, '*'].
	"URL address"
	(NuSwikiPage hasAProtocol: remaining)
		ifTrue: [^'*', text, '*'].
	"Get pageEntry"
	(remaining includes: $@)
		ifTrue: [pageEntry _ remaining copyUpTo: $@.
			remaining _ remaining copyFrom: (pageEntry size + 1) to: (remaining size)]
		ifFalse: [pageEntry _ remaining.
			remaining _ ''].
	"Make sure page entry is legitimate"
	pageEntry _ NuSwikiPage safePageNameFor: pageEntry.
	"No page entry"
	(pageEntry = '')
		ifTrue: [^'*', alias, remaining, '*'].
	"Check for digit"
	(pageEntry isAllDigits) ifTrue: [
		refId _ pageEntry asNumber.
		(book pages size >= refId) ifTrue: [(page settings at: 'referenceCache' ifAbsentPut: [OrderedCollection new]) addIfNotPresent: refId].
		^'*', alias, pageEntry, remaining, '*'].
	"Transform title to digit"
	(book hasPageNamed: pageEntry) ifTrue: [
		refId _ (book pageNamed: pageEntry) id.
		(page settings at: 'referenceCache' ifAbsentPut: [OrderedCollection new]) 
			addIfNotPresent: refId.
		^'*', alias, (refId asString), remaining, '*'].
	"Not an identified page"
	^'*', alias, pageEntry, remaining, '*'! !

!PageFormatter methodsFor: 'utility'!
updateLinks: text request: request response: response shelf: shelf book: book page: page
	"update formatter"
	| alias remaining pageEntry refId |
	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: 
			[alias _ (remaining copyUpTo: $>)
						, '>'.
			alias size = remaining size
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: alias size + 1 to: remaining size]]
		ifFalse: [alias _ ''].
	"e-mail address"
	(NuSwikiPage isTextAnEmailAddress: remaining)
		ifTrue: [^ '*' , text , '*'].
	"URL address"
	(NuSwikiPage hasAProtocol: remaining)
		ifTrue: [^ '*' , text , '*'].
	"Get pageEntry"
	(remaining includes: $@)
		ifTrue: 
			[pageEntry _ remaining copyUpTo: $@.
			remaining _ remaining copyFrom: pageEntry size + 1 to: remaining size]
		ifFalse: 
			[pageEntry _ remaining.
			remaining _ ''].
	"Digit already"
	pageEntry isAllDigits ifTrue: [^ '*' , text , '*'].
	"Transform title to digit"
	(book hasPageNamed: pageEntry)
		ifTrue: 
			[refId _ (book pageNamed: pageEntry) id.
			(page settings at: 'referenceCache' ifAbsentPut: [OrderedCollection new])
				addIfNotPresent: refId.
			^ '*' , alias , refId asString , remaining , '*'].
	"Not an identified page"
	^ '*' , text , '*'! !

!PageFormatter methodsFor: 'utility'!
uploadLinks: text request: request response: response shelf: shelf book: book page: page
	"show formatter"
	| alias remaining |

	remaining _ text copy.
	"alias"
	(remaining includes: $>)
		ifTrue: [alias _ (remaining copyUpTo: $>).
			((alias size + 1) = (remaining size))
				ifTrue: [remaining _ '']
				ifFalse: [remaining _ remaining copyFrom: (alias size + 2) to: (remaining size)].
			alias _ PageFormatter toSafeAlias: alias]
		ifFalse: [alias _ ''].
	"Use upload.page action"
	(alias = '')
		ifTrue: [request settingsRemove: 'alias']
		ifFalse: [request settingsAt: 'alias' put: alias].
	request settingsAt: 'file' put: remaining.
	^book formatPageAction: 'upload' request: request response: response shelf: shelf page: page! !

!PageFormatter methodsFor: 'functionality'!
addChangeLinks
	self addAction: [:text :request :response :shelf :book :page | self changeLinks: text request: request response: response shelf: shelf book: book page: page] from: '*' to: '*'! !

!PageFormatter methodsFor: 'functionality'!
addCrToCrlf
	self
		addMappingFrom: String cr to: String crlf;
		addMappingFrom: String crlf to: String crlf;
		addMappingFrom: (Character lf asString) to: String crlf! !

!PageFormatter methodsFor: 'functionality'!
addCrlfToCr
	self
		addMappingFrom: String crlf to: String cr;
		addMappingFrom: (Character lf asString) to: String cr! !

!PageFormatter methodsFor: 'functionality'!
addEditCode
	self addAction: [:text :request :response :shelf :book :page | '&lt;code&gt;', (TextFormatter encodeToXmlCrlf: text), '&lt;/code&gt;'] from: '<code>' to: '</code>'.
	self addAction: [:text :request :response :shelf :book :page | '&lt;CODE&gt;', (TextFormatter encodeToXmlCrlf: text), '&lt;/CODE&gt;'] from: '<CODE>' to: '</CODE>'! !

!PageFormatter methodsFor: 'functionality'!
addEditHtml
	self addAction: [:text :request :response :shelf :book :page | '&lt;html&gt;', (TextFormatter encodeToXmlCrlf: text), '&lt;/html&gt;'] from: '<html>' to: '</html>'.
	self addAction: [:text :request :response :shelf :book :page | '&lt;HTML&gt;', (TextFormatter encodeToXmlCrlf: text), '&lt;/HTML&gt;'] from: '<HTML>' to: '</HTML>'! !

!PageFormatter methodsFor: 'functionality'!
addEditPlugin
	self addAction: [:text :request :response :shelf :book :page | '&lt;?', (TextFormatter encodeToXmlCrlf: text), '?&gt;'] from: '<?' to: '?>'! !

!PageFormatter methodsFor: 'functionality'!
addEditSpecialCharacters
	self addMappingFrom: '&amp;' to: '&amp;amp;'.
	self addMappingFrom: '&lt;' to: '&amp;lt;'.
	self addMappingFrom: '&gt;' to: '&amp;gt;'.
	self addMappingFrom: '&*' to: '&amp;star;'.
	self addMappingFrom: '&' to: '&amp;'.
	self addMappingFrom: '"' to: '&quot;'.
	self addMappingFrom: '<' to: '&lt;'.
	self addMappingFrom: '>' to: '&gt;'! !

!PageFormatter methodsFor: 'functionality'!
addInternalLinks
	self addAction: [:text :request :response :shelf :book :page | self internalLinks: text request: request response: response shelf: shelf book: book page: page] from: '*' to: '*'.
	self addMappingFrom: '&*' to: '*'! !

!PageFormatter methodsFor: 'functionality'!
addRSS
	self addAction: [:text :request :response :shelf :book :page | ' href="', ((NuSwikiPage hasAProtocol: text) ifTrue: [''] ifFalse: [book settingsAt: 'urlPrefix' ifAbsent: ['']]), text, '"'] from: ' href="' to: '"'.
	self addAction: [:text :request :response :shelf :book :page | ' src="', ((NuSwikiPage hasAProtocol: text) ifTrue: [''] ifFalse: [book settingsAt: 'urlPrefix' ifAbsent: ['']]), text, '"'] from: ' src="' to: '"'.
	self addAction: [:text :request :response :shelf :book :page | ''] from: ' class="' to: '"'.
! !

!PageFormatter methodsFor: 'functionality'!
addRenderInternalLinks
	self addAction: [:text :request :response :shelf :book :page | self renderInternalLinks: text request: request response: response shelf: shelf book: book page: page] from: '*' to: '*'.
	self addMappingFrom: '&*' to: '*'! !

!PageFormatter methodsFor: 'functionality'!
addRenderUploadLinks
	self addAction: [:text :request :response :shelf :book :page | self renderUploadLinks: text request: request response: response shelf: shelf book: book page: page] from: '*+' to: '+*'! !

!PageFormatter methodsFor: 'functionality'!
addReverseLinks
	self addAction: [:text :request :response :shelf :book :page | self reverseLinks: text request: request response: response shelf: shelf book: book page: page] from: '*' to: '*'.
	self addAction: [:text :request :response :shelf :book :page | '*+', text, '+*'] from: '*+' to: '+*'.
	self addMappingFrom: '&*' to: '&*'! !

!PageFormatter methodsFor: 'functionality'!
addSaveCode
	self addAction: [:text :request :response :shelf :book :page | '<code>', (TextFormatter crlfToCr: text), '</code>']from: '<code>' to: '</code>'.
	self addAction: [:text :request :response :shelf :book :page | '<CODE>', (TextFormatter crlfToCr: text), '</CODE>']from: '<CODE>' to: '</CODE>'! !

!PageFormatter methodsFor: 'functionality'!
addSaveHtml
	self addAction: [:text :request :response :shelf :book :page | '<html>', (TextFormatter crlfToCr: text), '</html>'] from: '<html>' to: '</html>'.
	self addAction: [:text :request :response :shelf :book :page | '<HTML>', (TextFormatter crlfToCr: text), '</HTML>'] from: '<HTML>' to: '</HTML>'! !

!PageFormatter methodsFor: 'functionality'!
addSavePlugin
	self addAction: [:text :request :response :shelf :book :page | self plugin: text request: request response: response shelf: shelf book: book page: page] from: '<?' to: '?>'.! !

!PageFormatter methodsFor: 'functionality'!
addSaveSpecialCharacters
	self addMappingFrom: '&&' to: '&amp;'.
	self addMappingFrom: '&<' to: '&lt;'.
	self addMappingFrom: '&>' to: '&gt;'! !

!PageFormatter methodsFor: 'functionality'!
addShowSpecialCharacters
	self
		addMappingFrom: '&amp;' to: '&amp;';
		addMappingFrom: '&star;' to: '*';
		addMappingFrom: '&at;' to: '@';
		addMappingFrom: '--' to: '&#8211;';
		addMappingFrom: '---' to: '&#8212;'! !

!PageFormatter methodsFor: 'functionality'!
addTagIntegrity
	self addAction: [:text :request :response :shelf :book :page | '<', text, '>' ] from: '<' to: '>'
! !

!PageFormatter methodsFor: 'functionality'!
addUpdateCode
	self addAction: [:text :request :response :shelf :book :page | '<code>', text, '</code>'] from: '<code>' to: '</code>'.
	self addAction: [:text :request :response :shelf :book :page | '<CODE>', text, '</CODE>'] from: '<CODE>' to: '</CODE>'! !

!PageFormatter methodsFor: 'functionality'!
addUpdateHtml
	self addAction: [:text :request :response :shelf :book :page | '<html>', text, '</html>'] from: '<html>' to: '</html>'.
	self addAction: [:text :request :response :shelf :book :page | '<HTML>', text, '</HTML>'] from: '<HTML>' to: '</HTML>'! !

!PageFormatter methodsFor: 'functionality'!
addUpdateLinks
	self addAction: [:text :request :response :shelf :book :page | self updateLinks: text request: request response: response shelf: shelf book: book page: page] from: '*' to: '*'.
	self addAction: [:text :request :response :shelf :book :page | '*+', text, '+*'] from: '*+' to: '+*'.
	self addMappingFrom: '&*' to: '&*'.
! !

!PageFormatter methodsFor: 'functionality'!
addUploadLinks
	self addAction: [:text :request :response :shelf :book :page | self uploadLinks: text request: request response: response shelf: shelf book: book page: page] from: '*+' to: '+*'! !

!PageFormatter methodsFor: 'processing'!
format: text request: request response: response shelf: shelf book: book page: page
	|value stream|

	stream _ WriteStream on: (String new: text size).
	value _ Array with: nil with: request with: response with: shelf with: book with: page.
	self format: text actionValue: value onTo: stream.
	^stream contents! !


!ShelfTemplateFormatter methodsFor: 'private'!
action: action value: value text: text
	"Overwrites parent class to add swiki action"
	^(value size = 4)
		ifTrue: ["Page Request"
			(value at: 3) formatBookAction: text with: value]
		ifFalse: ["Book Request"
			(value at: 3) formatShelfAction: text with: value]! !

!ShelfTemplateFormatter methodsFor: 'processing'!
format: template request: request response: response shelf: shelf
	"Formatting used for a shelf request"
	| value stream |

	stream _ WriteStream on: (String new: template size).
	value _ Array with: request with: response with: shelf.
	self format: template actionValue: value onTo: stream.
	^stream contents! !

!ShelfTemplateFormatter methodsFor: 'processing'!
format: template request: request response: response shelf: shelf book: book
	"Formatting used for a book request"
	| value stream |

	stream _ WriteStream on: (String new: template size).
	value _ Array with: request with: response with: shelf with: book.
	self format: template actionValue: value onTo: stream.
	^stream contents! !


!TextFormatter class methodsFor: 'initialize-release'!
initialize
	"Carriage Return Conversions"
	CrToCrlf _ self new
		addMappingFrom: String cr to: String crlf;
		addMappingFrom: String crlf to: String crlf;
		addMappingFrom: (Character lf asString) to: String crlf;
		yourself.
	CrlfToCr _ self new
		addMappingFrom: String crlf to: String cr;
		addMappingFrom: (Character lf asString) to: String cr;
		yourself.
	"Xml Conversions"
	EncodeToStrictXmlCr _ self new
		addMappingFrom: '<' to: '&lt;';
		addMappingFrom: '>' to: '&gt;';
		addMappingFrom: '&' to: '&amp;';
		addMappingFrom: '"' to: '&quot;';
		addMappingFrom: String crlf to: String cr;
		addMappingFrom: (Character lf asString) to: String cr;
		yourself.
	EncodeToStrictXmlCrlf _ self new
		addMappingFrom: '<' to: '&lt;';
		addMappingFrom: '>' to: '&gt;';
		addMappingFrom: '&' to: '&amp;';
		addMappingFrom: '"' to: '&quot;';
		addMappingFrom: String cr to: String crlf;
		addMappingFrom: String crlf to: String crlf;
		addMappingFrom: (Character lf asString) to: String crlf;
		yourself.
	EncodeToXmlCr _ self new
		addMappingFrom: '<' to: '&lt;';
		addMappingFrom: '>' to: '&gt;';
		addMappingFrom: '&' to: '&amp;';
		addMappingFrom: String crlf to: String cr;
		addMappingFrom: (Character lf asString) to: String cr;
		yourself.
	EncodeToXmlCrlf _ self new
		addMappingFrom: '<' to: '&lt;';
		addMappingFrom: '>' to: '&gt;';
		addMappingFrom: '&' to: '&amp;';
		addMappingFrom: String cr to: String crlf;
		addMappingFrom: String crlf to: String crlf;
		addMappingFrom: (Character lf asString) to: String crlf;
		yourself.
	DecodeFromXmlCr _ self new
		addMappingFrom: '&lt;' to: '<';
		addMappingFrom: '&gt;' to: '>';
		addMappingFrom: '&amp;' to: '&';
		addMappingFrom: '&quot;' to: '"';
		addMappingFrom: String crlf to: String cr;
		addMappingFrom: (Character lf asString) to: String cr;
		yourself.
	DecodeFromXmlCrlf _ self new
		addMappingFrom: '&lt;' to: '<';
		addMappingFrom: '&gt;' to: '>';
		addMappingFrom: '&amp;' to: '&';
		addMappingFrom: '&quot;' to: '"';
		addMappingFrom: String cr to: String crlf;
		addMappingFrom: String crlf to: String crlf;
		addMappingFrom: (Character lf asString) to: String crlf;
		yourself.! !

!TextFormatter class methodsFor: 'formatting'!
crToCrlf: aCrDelimitedString
	^CrToCrlf format: aCrDelimitedString! !

!TextFormatter class methodsFor: 'formatting'!
crlfToCr: aCrlfDelimitedString
	^CrlfToCr format: aCrlfDelimitedString! !

!TextFormatter class methodsFor: 'formatting'!
decodeFromXmlCr
	^DecodeFromXmlCr! !

!TextFormatter class methodsFor: 'formatting'!
decodeFromXmlCr: xml
	^DecodeFromXmlCr format: xml! !

!TextFormatter class methodsFor: 'formatting'!
decodeFromXmlCrlf
	^DecodeFromXmlCrlf! !

!TextFormatter class methodsFor: 'formatting'!
decodeFromXmlCrlf: xml
	^DecodeFromXmlCrlf format: xml! !

!TextFormatter class methodsFor: 'formatting'!
encodeToStrictXmlCr
	^EncodeToStrictXmlCr! !

!TextFormatter class methodsFor: 'formatting'!
encodeToStrictXmlCr: aString
	^EncodeToStrictXmlCr format: aString! !

!TextFormatter class methodsFor: 'formatting'!
encodeToStrictXmlCrlf
	^EncodeToStrictXmlCrlf! !

!TextFormatter class methodsFor: 'formatting'!
encodeToStrictXmlCrlf: aString
	^EncodeToStrictXmlCrlf format: aString! !

!TextFormatter class methodsFor: 'formatting'!
encodeToXmlCr
	^EncodeToXmlCr! !

!TextFormatter class methodsFor: 'formatting'!
encodeToXmlCr: aString
	^EncodeToXmlCr format: aString! !

!TextFormatter class methodsFor: 'formatting'!
encodeToXmlCrlf
	^EncodeToXmlCrlf! !

!TextFormatter class methodsFor: 'formatting'!
encodeToXmlCrlf: aString
	^EncodeToXmlCrlf format: aString! !

!TextFormatter class methodsFor: 'instance creation'!
new
	^super new initialize! !


!BookTemplateFormatter class methodsFor: 'accessing'!
swikiFormatter
	^SwikiFormatter! !

!BookTemplateFormatter class methodsFor: 'initialize-release'!
initialize
	SwikiFormatter _ self new.
	SwikiFormatter
		initialize;
		addAction: #swikiAction from: '<?' to: '?>'! !


!PageFormatter class methodsFor: 'initialize-release'!
initialize
	ToSafeAlias _ TextFormatter new.
	ToSafeAlias initialize;
		addMappingFrom: '>' to: '';
		addMappingFrom: '<' to: '';
		addMappingFrom: '@' to: '';
		addMappingFrom: '&star;' to: '*';
		addMappingFrom: '&at;' to: '@';
		addMappingFrom: '&lt;' to: '&lt;';
		addMappingFrom: '&gt;' to: '&gt;';
		addMappingFrom: '&amp;' to: '&amp;';
		addMappingFrom: '&' to: '&amp;'.
	ToStrictSafeAlias _ TextFormatter new.
	ToStrictSafeAlias initialize;
		addMappingFrom: '>' to: '';
		addMappingFrom: '<' to: '';
		addMappingFrom: '@' to: '';
		addMappingFrom: '&star;' to: '*';
		addMappingFrom: '&at;' to: '@';
		addMappingFrom: '&lt;' to: '&lt;';
		addMappingFrom: '&gt;' to: '&gt;';
		addMappingFrom: '&amp;' to: '&amp;';
		addMappingFrom: '&' to: '&amp;';
		addMappingFrom: '"' to: '&quot;'.
	ToSafeLocation _ TextFormatter new.
	ToSafeLocation initialize;
		addMappingFrom: '>' to: '&gt;';
		addMappingFrom: '<' to: '&lt;';
		addMappingFrom: '"' to: '&quot;';
		addMappingFrom: '&' to: '&amp;';
		addMappingFrom: '#' to: ''.! !

!PageFormatter class methodsFor: 'formatting'!
toSafeAlias
	^ToSafeAlias! !

!PageFormatter class methodsFor: 'formatting'!
toSafeAlias: aString
	^ToSafeAlias format: aString! !

!PageFormatter class methodsFor: 'formatting'!
toSafeLocation
	^ToSafeLocation! !

!PageFormatter class methodsFor: 'formatting'!
toSafeLocation: aString
	^ToSafeLocation format: aString! !

!PageFormatter class methodsFor: 'formatting'!
toStrictSafeAlias
	^ToStrictSafeAlias! !

!PageFormatter class methodsFor: 'formatting'!
toStrictSafeAlias: aString
	^ToStrictSafeAlias format: aString! !

!PageFormatter class methodsFor: 'utility'!
copyTreeFromDir: fromDir toDir: toDir
	| fromFile toFile |
	fromDir directoryNames do: [:dName |
		(toDir directoryExists: dName) ifFalse: [toDir createDirectory: dName].
		self copyTreeFromDir: (fromDir directoryNamed: dName) toDir: (toDir directoryNamed: dName)].
	fromDir fileNames do: [:fName |
		(toDir fileExists: fName) ifTrue: [toDir deleteFileNamed: fName].
		fromFile _ fromDir readOnlyFileNamed: fName.
		toFile _ toDir newFileNamed: fName.
		toDir copyFile: fromFile toFile: toFile.
		fromFile close.
		toFile close]! !

!PageFormatter class methodsFor: 'utility'!
deleteTreeForDir: dir
	dir directoryNames do: [:dName |
		self deleteTreeForDir: (dir directoryNamed: dName).
		dir deleteDirectory: dName].
	dir fileNames do: [:fName |
		dir deleteFileNamed: fName]! !

!PageFormatter class methodsFor: 'utility'!
isAnImage: aFileName
	^#('gif' 'jpeg' 'jpg' 'png') includes: ((aFileName copyAfterLast: $.) asLowercase)! !

!PageFormatter class methodsFor: 'instance creation'!
editFormatter
	| return |
	return _ self new.
	return initialize;
		addCrToCrlf;
		addEditHtml;
		addEditCode;
		addEditPlugin;
		addChangeLinks;
		addEditSpecialCharacters;
		storeID: #editFormatter.
	^return! !

!PageFormatter class methodsFor: 'instance creation'!
rssFormatter
	| return |
	return _ self new.
	return
		initialize;
		addRSS;
		storeID: #rssFormatter.
	^return! !

!PageFormatter class methodsFor: 'instance creation'!
saveFormatter
	| return |
	return _ self new.
	return
		initialize;
		addCrlfToCr;
		addReverseLinks;
		addSaveHtml;
		addSaveCode;
		addSavePlugin;
		addSaveSpecialCharacters;
		storeID: #saveFormatter.
	^return! !

!PageFormatter class methodsFor: 'instance creation'!
updateFormatter
	| return |
	return _ self new.
	return initialize;
		addUpdateLinks;
		addUpdateHtml;
		addUpdateCode;
		storeID: #updateFormatter.
	^return! !


!ShelfTemplateFormatter class methodsFor: 'accessing'!
swikiFormatter
	^SwikiFormatter! !

!ShelfTemplateFormatter class methodsFor: 'initialize-release'!
initialize
	SwikiFormatter _ self new.
	SwikiFormatter
		initialize;
		addAction: #swikiAction from: '<?' to: '?>'! !


!XmlSwikiStorage methodsFor: 'pages' stamp: 'xw 5/15/2022 16:58'!
backupPage: aPage
	"Back-up a .xml page to put it's contents into a .old page."
	| oldPath oldStream file pos |

	"Get the path for the .old file."
	oldPath _ (aPage id asString), '.old'.
	"Get the .old stream to write on"
	(dir fileExists: oldPath)
		ifTrue: [oldStream := SwikiFileStream oldFileNamed: oldPath inDirectory: dir.
				oldStream setToEnd]
		ifFalse: [oldStream := SwikiFileStream newFileNamed: oldPath inDirectory: dir].
	file := (SwikiFileStream readOnlyFileNamed: (aPage id asString, '.xml') inDirectory: dir) contentsOfEntireFile.
	pos _ file findString: '<page>' startingAt: 1.
	"Add current page."
	oldStream nextPutAll: (file copyFrom: pos to: file size).
	oldStream nextPutAll: String cr.
	oldStream close! !

!XmlSwikiStorage methodsFor: 'pages'!
isAComplexPage: aPage
	| text |
	text _ aPage rawText.
	(text isKindOf: String) ifTrue: [^false].
	(text isKindOf: Array) ifTrue: [^false].
	^true
! !

!XmlSwikiStorage methodsFor: 'pages' stamp: 'xw 5/15/2022 16:43'!
loadPage: aPage
	| xml pos0 |
	(aPage versionId = 0)
		ifTrue: ["Load a current page from .xml file"
			xml := (SwikiFileStream readOnlyFileNamed: ((aPage id asString), '.xml') inDirectory: dir) contentsOfEntireFile.
			self loadPage: aPage from: xml startingAt: 1]
		ifFalse: ["Load an old page from .old file"
			xml := SwikiFileStream readOnlyFileNamed: ((aPage id asString), '.old') inDirectory: dir.
			"Get the correct version"
			pos0 _ 0.
			1 to: (aPage versionId) do: [:i |
				pos0 _ xml findString: '<page>' startingAt: (pos0 + 1).
				(pos0 = 0) ifTrue: ["There's an error"
					xml close.
					^nil]].
			self loadPage: aPage from: xml startingAt: pos0.
			xml close]! !

!XmlSwikiStorage methodsFor: 'pages'!
loadPage: aPage from: xml startingAt: pos0
	| pos1 pos2 date |

	"Version"
	pos1 _ xml findString: '<version date="' startingAt: pos0.
	pos2 _ xml findString: '" time="' startingAt: pos1.
	date _ (xml copyFrom: (pos1 + 15) to: (pos2 - 1)) findTokens: './'.
	aPage date: (Date newDay: (date at: 1) asNumber month: (date at: 2) asNumber year: (date at: 3) asNumber).
	pos1 _ xml findString: '" user="' startingAt: pos2.
	aPage time: (Time readFrom: (ReadStream on: (xml copyFrom: (pos2 + 8) to: (pos1 - 1)))).
	pos2 _ xml findString: '" />' startingAt: pos1.
	aPage user: (xml copyFrom: (pos1 + 8) to: (pos2 - 1)).
	"Settings"
	pos1 _ xml findString: '<settings>' startingAt: pos2.
	pos2 _ xml findString: '</settings>' startingAt: pos1.
	aPage settings: (self class settingsDictFrom: (xml copyFrom: (pos1) to: (pos2 + 10))).
	"Name"
	pos1 _ xml findString: '<name>' startingAt: pos2.
	pos2 _ xml findString: '</name>' startingAt: pos1.
	aPage name: (TextFormatter decodeFromXmlCr: (xml copyFrom: (pos1 + 6) to: (pos2 - 1))).
	"Text"
	pos1 _ xml findString: '<text>' startingAt: pos2.
	pos2 _ xml findString: '</text>' startingAt: pos1.
	aPage text: (self class textFrom: xml start: (pos1 + 6) end: (pos2 - 1))! !

!XmlSwikiStorage methodsFor: 'pages'!
loadPages
	"Automatically fix .tmp files"
	| maxPage temp pages page files |
	pages _ OrderedCollection new.
	files _ dir fileNames.
	"Establish the maximum page number"
	maxPage _ 1.
	files do: [:fileName |
		temp _ fileName copyUpTo: $..
		temp isAllDigits ifTrue: [
			maxPage _ maxPage max: temp asNumber]].
	"Load the files"
	1 to: maxPage do: [:id |
		(files includes: (id asString, '.xml'))
			ifTrue: ["load page from .xml file"
				page _ NuSwikiPage new id: id; versionId: 0; storage: self.
				self loadPage: page.
				pages add: page]
			ifFalse: [ComSwikiLauncher autoCorrectMissingPages
				ifTrue: ["Try to load page from .old file."
					page _ NuSwikiPage new id: id; versionId: 0; storage: self.
					(files includes: (id asString, '.old'))
						ifTrue: [page _ (self loadVersionsFrom: page) last.
							page text: page text.
							page versionId: 0.
							page storage: self.
							self writePage: page]
						ifFalse: [
							page name: 'Missing Page'.
							page date: Date today.
							page time: Time now.
							page user: ''.
							page text: ''.
							self writePage: page].
					pages add: page]
				ifFalse: ["Give an error."
					self error: ((dir fullPathFor: (id asString, '.xml')), ' is missing')]]].
	^pages! !

!XmlSwikiStorage methodsFor: 'pages' stamp: 'xw 5/15/2022 16:54'!
loadVersionsFrom: aPage
	| versions xml pos0 version vid |
	versions _ OrderedCollection new.
	(dir fileExists: (aPage id asString, '.old'))
		ifTrue: [xml := SwikiFileStream readOnlyFileNamed: (aPage id asString, '.old') inDirectory: dir.
			vid _ 1.
			pos0 _ 0.
			[0 = (pos0 _ xml findString: '<page>' startingAt: (pos0 + 1))] whileFalse: [
				version _ aPage class new id: (aPage id); versionId: vid; storage: self.
				self loadPage: version from: xml startingAt: pos0.
				versions add: version.
				vid _ vid + 1].
			xml close].
	^versions! !

!XmlSwikiStorage methodsFor: 'pages'!
multipleTextFrom: aPage
	| file return |
	file _ dir readOnlyFileNamed: (self pathFrom: aPage).
	return _ Dictionary new.
	aPage rawText keysAndValuesDo: [:key :value |
		(value isKindOf: Array)
			ifTrue: [file position: ((value at: 1) - 1).
				return at: key put: (TextFormatter decodeFromXmlCr: (file next: (1 + (value at: 2) - (value at: 1))))]
			ifFalse: [return at: key put: value]].
	file close.
	^return
! !

!XmlSwikiStorage methodsFor: 'pages'!
pathFrom: aPage
	^(aPage versionId = 0)
		ifTrue: [(aPage id asString), '.xml']
		ifFalse: [(aPage id asString), '.old']
! !

!XmlSwikiStorage methodsFor: 'pages'!
simpleTextFrom: aPage
	| file return |
	file _ dir readOnlyFileNamed: (self pathFrom: aPage).
	file position: ((aPage rawText at: 1) - 1).
	return _ TextFormatter decodeFromXmlCr: (file next: (1 + (aPage rawText at: 2) - (aPage rawText at: 1))).
	file close.
	^return
! !

!XmlSwikiStorage methodsFor: 'pages'!
textFrom: aPage
	| text |
	text _ aPage rawText.
	(text isKindOf: Array) ifTrue: [^self simpleTextFrom: aPage].
	(text isKindOf: Dictionary) ifTrue: [^self multipleTextFrom: aPage].
	^''
! !

!XmlSwikiStorage methodsFor: 'pages'!
textKey: key from: aPage
	| text arr return file |
	text _ aPage rawText.
	arr _ text at: key ifAbsent: [^''].
	file _ dir readOnlyFileNamed: (self pathFrom: aPage).
	file position: ((arr at: 1) - 1).
	return _ TextFormatter decodeFromXmlCr: (file next: (1 + (arr at: 2) - (arr at: 1))).
	file close.
	^return! !

!XmlSwikiStorage methodsFor: 'pages' stamp: 'xw 5/15/2022 16:59'!
wipePage: aPage
	"Move contents of .old to .del."
	| oldPath delPath delStream |

	oldPath _ (aPage id asString), '.old'.
	delPath _ (aPage id asString), '.del'.
	(dir fileExists: oldPath) ifFalse: [^self].
	delStream _ (dir fileExists: delPath)
		ifTrue: [(SwikiFileStream fileNamed: delPath inDirectory: dir)
			setToEnd;
			yourself]
		ifFalse: [SwikiFileStream newFileNamed: delPath inDirectory: dir].
	delStream
		nextPutAll: (SwikiFileStream readOnlyFileNamed: oldPath inDirectory: dir) contentsOfEntireFile;
		close.
	dir deleteFileNamed: oldPath! !

!XmlSwikiStorage methodsFor: 'pages' stamp: 'xw 5/15/2022 16:50'!
writePage: aPage
	| file text normalPath |
	
	[text _ String streamContents: [:stream |
		stream
			nextPutAll: '<?xml version="1.0"?>'; cr;
			nextPutAll: '<page>'; cr;
			"Version"
			nextPutAll: '<version date="';
			nextPutAll: aPage date dayOfMonth asString;
			nextPut: $/;
			nextPutAll: aPage date monthIndex asString;
			nextPut: $/;
			nextPutAll: aPage date year asString;
			nextPutAll: '" time="'.
		aPage time printOn: stream.
		stream
			nextPutAll: '" user="';
			nextPutAll: aPage user;
			nextPutAll: '" />'; cr;
			"settings"
			nextPutAll: '<settings>'; cr;
			nextPutAll: (self class settingsStringFrom: aPage settings);
			nextPutAll: '</settings>'; cr;
			"Name"
			nextPutAll: '<name>'.
		TextFormatter encodeToXmlCr format: aPage name onTo: stream.
		stream
			nextPutAll: '</name>'; cr;
			"Text"
			nextPutAll: '<text>'.
		self addTextFrom: aPage to: stream.
		stream
			nextPutAll: '</text>'; cr;
			nextPutAll: '</page>']] ifError: [:a :b | ^self "Do nothing"].
	["Delete Old Version"
	normalPath _ self pathFrom: aPage.
	dir deleteFileNamed: normalPath.
	file := SwikiFileStream newFileNamed: normalPath inDirectory: dir.
	file nextPutAll: text; close] ifError: ["Try to correct it"
		(dir fileExists: normalPath) ifFalse: [
			"Retry with garbage collect"
			Smalltalk garbageCollect.
			file := SwikiFileStream newFileNamed: normalPath inDirectory: dir.
			file nextPutAll: text; close.]]! !

!XmlSwikiStorage methodsFor: 'pages'!
writeVersions: versionColl
	| file text path |

	"Check to make sure it isn't empty"
	versionColl isEmpty ifTrue: [^self].
	[text _ String streamContents: [:stream | versionColl do: [:version |
		stream
			nextPutAll: '<page>'; cr;
			"Version"
			nextPutAll: '<version date="';
			nextPutAll: version date dayOfMonth asString;
			nextPut: $/;
			nextPutAll: version date monthIndex asString;
			nextPut: $/;
			nextPutAll: version date year asString;
			nextPutAll: '" time="'.
		version time printOn: stream.
		stream
			nextPutAll: '" user="';
			nextPutAll: version user;
			nextPutAll: '" />'; cr;
			"settings"
			nextPutAll: '<settings>'; cr;
			nextPutAll: (self class settingsStringFrom: version settings);
			nextPutAll: '</settings>'; cr;
			"Name"
			nextPutAll: '<name>'.
		TextFormatter encodeToXmlCr format: version name onTo: stream.
		stream
			nextPutAll: '</name>'; cr;
			"Text"
			nextPutAll: '<text>'.
		self addTextFrom: version to: stream.
		stream
			nextPutAll: '</text>'; cr;
			nextPutAll: '</page>'; cr]]] ifError: [:a :b | ^self "Do nothing"].
	path _ (versionColl last id asString), '.old'.
	[dir deleteFileNamed: path.
	file _ dir newFileNamed: path.
	file nextPutAll: text; close] ifError: ["Try to correct it"
		(dir fileExists: path) ifFalse: [
			"Retry with garbage collect"
			Smalltalk garbageCollect.
			file _ dir newFileNamed: path.
			file nextPutAll: text; close.]]! !

!XmlSwikiStorage methodsFor: 'private'!
addTextFrom: aPage to: file
	| saveText new arr sum |
	saveText _ aPage text.
	(saveText isKindOf: Dictionary)
		ifTrue: [new _ Dictionary new.
			file nextPutAll: String cr.
			sum _ 0.
			saveText keysAndValuesDo: [:key :value |
				sum _ sum + value size.
				arr _ Array new: 2.
				file nextPutAll: '<t name="'.
				TextFormatter encodeToStrictXmlCr format: key onTo: file.
				file nextPutAll: '">'.
				arr at: 1 put: (1 + file position).
				TextFormatter encodeToXmlCr format: value onTo: file.
				arr at: 2 put: (file position).
				new at: key put: arr.
				file nextPutAll: '</t>', String cr].
			(TextCacheLimit > sum) ifFalse: [
				aPage text: new]]
		ifFalse: [new _ Array new: 2.
			new at: 1 put: (1 + file position).
			TextFormatter encodeToXmlCr format: saveText onTo: file.
			new at: 2 put: file position.
			(TextCacheLimit > saveText size) ifFalse: [
				aPage text: new]]! !

!XmlSwikiStorage methodsFor: 'private'!
getMetaCollForDir: aDir
	| tokens return id type name category pos1 pos2 |
	return _ OrderedCollection new.
	(aDir fileExists: 'meta.xml') ifFalse: [^return].
	tokens _ (aDir readOnlyFileNamed: 'meta.xml') contentsOfEntireFile findTokens: String crlf.
	tokens do: [:token | (token beginsWith: '<file') ifTrue: [
		pos1 _ token findString: 'id="'.
		pos2 _ token findString: '"' startingAt: (pos1 + 4).
		id _ token copyFrom: (pos1+4) to: (pos2 - 1).
		pos1 _ token findString: 'type="'.
		pos2 _ token findString: '"' startingAt: (pos1 + 6).
		type _ token copyFrom: (pos1+6) to: (pos2 - 1).
		pos1 _ token findString: 'name="'.
		pos2 _ token findString: '"' startingAt: (pos1 + 6).
		name _ token copyFrom: (pos1+6) to: (pos2 - 1).
		category _ ((pos1 _ token findString: 'category="') = 0)
			ifTrue: [nil]
			ifFalse: [pos2 _ token findString: '"' startingAt: (pos1 + 10).
				token copyFrom: (pos1 + 10) to: (pos2 - 1)].
		return add: (Array with: id with: type with: name with: category)]].
	^return! !

!XmlSwikiStorage methodsFor: 'private'!
putMetaColl: coll forDir: aDir
	| file |
	(aDir fileExists: 'meta.xml') ifTrue: [aDir deleteFileNamed: 'meta.xml'].
	file _ aDir newFileNamed: 'meta.xml'.
	file
		nextPutAll: '<?xml version="1.0"?>';
		nextPut: Character cr;
		nextPutAll: '<meta>';
		nextPut: Character cr.
	coll do: [:arr |
		file
			nextPutAll: '<file id="';
			nextPutAll: (arr at: 1);
			nextPutAll: '" type="';
			nextPutAll: (arr at: 2);
			nextPutAll: '" name="';
			nextPutAll: (arr at: 3).
		(arr at: 4) ifNotNil: [file
			nextPutAll: '" category="';
			nextPutAll: (arr at: 4)].
		file
			nextPutAll: '" />';
			nextPut: Character cr].
	file
		nextPutAll: '</meta>';
		close
! !

!XmlSwikiStorage methodsFor: 'shelf'!
loadSettingsForShelf: shelf
	| ddir raw pos1 pos2 |
	ddir _ dir directoryNamed: 'default'.
	shelf settings: ((ddir fileExists: 'settings.xml')
		ifTrue: [raw _ (ddir readOnlyFileNamed: 'settings.xml') contentsOfEntireFile.
			pos1 _ raw findString: '<settings>' startingAt: 1.
			pos2 _ raw findString: '</settings>' startingAt: pos1.
			self class settingsDictFrom: (raw copyFrom: pos1 to: pos2 + 10)]
		ifFalse: [Dictionary new])! !

!XmlSwikiStorage methodsFor: 'shelf'!
setupBooks
	| books book bdir raw pos1 pos2 setup |
	books _ OrderedCollection new.
	dir directoryNames do: [:dname | (dname = 'default') ifFalse: [
		bdir _ dir directoryNamed: dname.
		(bdir fileExists: 'setup.xml') ifTrue: [
			raw _ (bdir readOnlyFileNamed: 'setup.xml') contentsOfEntireFile.
			pos1 _ raw findString: '<setup>' startingAt: 1.
			pos2 _ raw findString: '</setup>' startingAt: pos1.
			setup _ XmlSwikiStorage settingsDictFrom: (raw copyFrom: pos1 to: pos2 + 7).
			book _ (setup includesKey: 'parent')
				ifTrue: [SwikiSubBook new]
				ifFalse: [SwikiBook new].
			book
				name: dname;
				setup: setup.
			books add: book]]].
	^books! !

!XmlSwikiStorage methodsFor: 'shelf'!
writeSettingsForShelf: shelf
	| ddir file |
	"Delete Old Settings"
	(ddir _ dir directoryNamed: 'default') deleteFileNamed: 'settings.xml'.
	"Add New Settings"
	file _ ddir newFileNamed: 'settings.xml'.
	file nextPutAll: '<?xml version="1.0"?>', String cr.
	file nextPutAll: '<settings>', String cr.
	file nextPutAll: (self class settingsStringFrom: shelf settings).
	file nextPutAll: '</settings>'.
	file close.! !

!XmlSwikiStorage methodsFor: 'shelf'!
writeSetupForBook: book
	| bdir file |
	bdir _ dir directoryNamed: book name.
	"Delete Old Setup"
	bdir deleteFileNamed: 'setup.xml'.
	"Add New Setup"
	file _ bdir newFileNamed: 'setup.xml'.
	file nextPutAll: '<?xml version="1.0"?>', String cr.
	file nextPutAll: '<setup>', String cr.
	file nextPutAll: (self class settingsStringFrom: book setup).
	file nextPutAll: '</setup>'.
	file close.! !

!XmlSwikiStorage methodsFor: 'book (load)'!
loadSettingsForBook: book
	| raw pos1 pos2 |
	book rawSettings: ((dir fileExists: 'settings.xml')
		ifTrue: [raw _ (dir readOnlyFileNamed: 'settings.xml') contentsOfEntireFile.
			pos1 _ raw findString: '<settings>' startingAt: 1.
			pos2 _ raw findString: '</settings>' startingAt: pos1.
			XmlSwikiStorage settingsDictFrom: (raw copyFrom: pos1 to: pos2 + 10)]
		ifFalse: [Dictionary new])! !

!XmlSwikiStorage methodsFor: 'book (load)'!
writeSettingsForBook: book
	| file |
	"Delete Old Settings"
	dir deleteFileNamed: 'settings.xml'.
	"Add New Settings"
	file _ dir newFileNamed: 'settings.xml'.
	file nextPutAll: '<?xml version="1.0"?>', String cr.
	file nextPutAll: '<settings>', String cr.
	file nextPutAll: (self class settingsStringFrom: book rawSettings).
	file nextPutAll: '</settings>'.
	file close.! !


!XmlSwikiStorage class methodsFor: 'initialize-release'!
initialize
	TextCacheLimit _ 1000.
	"Dictionaries"
	TypesDict _ Dictionary new.
	TypesDict
		at: String put: #textSettingNamed:value:;
		at: Number put: #numberSettingNamed:value:;
		at: Boolean put: #booleanSettingNamed:value:;
		at: OrderedCollection put: #collSettingNamed:value:.
	AssocDict _ Dictionary new.
	AssocDict
		at: 'text' put: #textSettingFrom:;
		at: 'number' put: #numberSettingFrom:;
		at: 'boolean' put: #booleanSettingFrom:;
		at: 'coll' put: #collSettingFrom:;
		at: 'code' put: #codeSettingFrom:.! !

!XmlSwikiStorage class methodsFor: 'testing class hierarchy'!
handlesBookStorage
	^true! !

!XmlSwikiStorage class methodsFor: 'testing class hierarchy'!
handlesPageStorage
	^true! !

!XmlSwikiStorage class methodsFor: 'conversion'!
booleanSettingFrom: xml
	^xml = 'true'
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
booleanSettingNamed: aString value: value
	^'<s name="', (TextFormatter encodeToStrictXmlCr: aString), '" type="boolean">', (value ifTrue: ['true'] ifFalse: ['false']), '</s>'! !

!XmlSwikiStorage class methodsFor: 'conversion'!
codeSettingFrom: xml
	^Compiler evaluate: (TextFormatter decodeFromXmlCr: xml)
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
codeSettingNamed: aString value: value
	^'<s name="', (TextFormatter encodeToStrictXmlCr: aString), '" type="code">', (TextFormatter encodeToXmlCr: (self storeStringFor: value)), '</s>'! !

!XmlSwikiStorage class methodsFor: 'conversion'!
collSettingFrom: xml
	| return |
	return _ OrderedCollection new.
	(xml findTokens: ' ') do: [:element | return add: element asNumber].
	^return
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
collSettingNamed: aString value: value
	| return |
	return _ '<s name="', (TextFormatter encodeToStrictXmlCr: aString), '" type="coll">'.
	value do: [:element | return _ return, (element asString), ' '].
	^(return copyFrom: 1 to: (return size - 1)), '</s>'! !

!XmlSwikiStorage class methodsFor: 'conversion'!
numberSettingFrom: xml
	^xml asNumber
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
numberSettingNamed: aString value: value
	^'<s name="', (TextFormatter encodeToStrictXmlCr: aString), '" type="number">', (value asString), '</s>'! !

!XmlSwikiStorage class methodsFor: 'conversion'!
performerFor: value
	TypesDict keysAndValuesDo: [:class :selector |
		(value isKindOf: class) ifTrue: [^selector]].
	^#codeSettingNamed:value:! !

!XmlSwikiStorage class methodsFor: 'conversion'!
settingAssocFromXml: xml
	| pos1 pos2 pos3 key type value |
	pos1 _ xml findString: 'name="' startingAt: 1.
	pos2 _ xml findString: '"' startingAt: (pos1 + 6).
	key _ TextFormatter decodeFromXmlCr: (xml copyFrom: (pos1 + 6) to: (pos2 - 1)).
	pos3 _ xml findString: '>' startingAt: pos2.
	pos1 _ xml findString: 'type="' startingAt: 1.
	((pos1 < pos3) and: [pos1 > 0])
		ifTrue: [pos2 _ xml findString: '"' startingAt: (pos1 + 6).
			type _ xml copyFrom: (pos1 + 6) to: (pos2 - 1)]
		ifFalse: [type _ 'code'].
	pos1 _ xml findString: '</s>' startingAt: pos3.
	value _ xml copyFrom: (pos3 + 1) to: (pos1 - 1).
	value _ self perform: (AssocDict at: type) with: value.
	^Association key: key value: value
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
settingStringNamed: aString value: value
	^self perform: (self performerFor: value) with: aString with: value! !

!XmlSwikiStorage class methodsFor: 'conversion'!
settingsDictFrom: xml
	| pos1 pos2 dict |

	dict _ Dictionary new.
	pos1 _ 1.
	[0 = (pos1 _ xml findString: '<s ' startingAt: pos1)] whileFalse: [
		pos2 _ xml findString: '</s>' startingAt: pos1.
		dict add: (self settingAssocFromXml: (xml copyFrom: pos1 to: (pos2 + 3))).
		pos1 _ pos1 + 1].
	^dict
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
settingsStringFrom: dict
	"Converts a dictionary to a xml string."
	| xml |

	xml _ ''.
	dict keysAndValuesDo: [:key :value | xml _ xml, (self settingStringNamed: key value: value), String cr].
	^xml! !

!XmlSwikiStorage class methodsFor: 'conversion'!
storeStringFor: object
	| return |

	(object isKindOf: OrderedCollection) ifTrue: [
		((object at: 1 ifAbsent: ['do not do']) isKindOf: Integer)
			ifTrue: [return _ '#('.
				object do: [:element | return _ return, (element storeString), ' '].
				^return, ') asOrderedCollection']].
	^object storeString! !

!XmlSwikiStorage class methodsFor: 'conversion'!
textDictionaryFrom: xml start: start end: end
	| dict pos1 pos2 key sum |

	dict _ Dictionary new.
	pos2 _ start - 1.
	sum _ 0.
	[pos1 _ xml findString: '<t name="' startingAt: pos2. (pos1 = 0) or: [pos1 > end]] whileFalse: ["Keep adding elements"
		pos2 _ xml findString: '">' startingAt: pos1.
		key _ TextFormatter decodeFromXmlCr: (xml copyFrom: (pos1 + 9) to: (pos2 - 1)).
		pos1 _ xml findString: '</t>' startingAt: pos2.
		dict at: key put: (Array with: (pos2 + 2) with: (pos1 - 1)).
		"Determine if it should be cached or not"
		sum _ sum + pos1 - pos2 - 3.
		pos2 _ pos1 + 2].
	(TextCacheLimit > sum) ifFalse: [dict keysAndValuesDo: [:i :arr |
		dict at: i put: (TextFormatter decodeFromXmlCr: (xml copyFrom: (arr at: 1) to: (arr at: 2)))]].
	^dict
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
textFrom: xml start: start end: end
	| test |

	(start < end) ifTrue: [test _ xml findString: '<' startingAt: start.
		(test < end) ifTrue: [^self textDictionaryFrom: xml start: start end: end]].
	^(TextCacheLimit > (end - start))
		ifTrue: [TextFormatter decodeFromXmlCr: (xml copyFrom: start to: end)]
		ifFalse: [Array with: start with: end]! !

!XmlSwikiStorage class methodsFor: 'conversion'!
textSettingFrom: xml
	^TextFormatter decodeFromXmlCr: xml
! !

!XmlSwikiStorage class methodsFor: 'conversion'!
textSettingNamed: aString value: value
	^'<s name="', (TextFormatter encodeToStrictXmlCr: aString), '" type="text">', (TextFormatter encodeToXmlCr: value), '</s>'! !

!XmlSwikiStorage class methodsFor: 'utility'!
objectFromType: type value: value
	^type caseOf: {
		['text']->[value].
		['boolean']->[value = 'true'].
		['number']->[value asNumber].
		['code']->[Compiler evaluate: value]}
		otherwise: [self error: 'This is not a valid type.']! !

!XmlSwikiStorage class methodsFor: 'utility'!
typeAndStringFromObject: anObject
	^anObject class caseOf: {
		[String]->[Array with: 'text' with: anObject].
		[True]->[Array with: 'boolean' with: 'true'].
		[False]->[Array with: 'boolean' with: 'false']}
		otherwise: [(anObject isKindOf: Number)
			ifTrue: [Array with: 'number' with: anObject asString]
			ifFalse: [Array with: 'code' with: (self storeStringFor: anObject)]]! !

!XmlSwikiStorage class methodsFor: 'instance creation'!
loadPagesFromDir: dir
	^(self fromDir: dir) loadPages
! !

ComSwikiLauncher initialize!
LineFormatter initialize!
SwikiFile initialize!
SwikiImage initialize!
NuSwikiPage initialize!
TextFormatter initialize!
BookTemplateFormatter initialize!
PageFormatter initialize!
ShelfTemplateFormatter initialize!
XmlSwikiStorage initialize!
