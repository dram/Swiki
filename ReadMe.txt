Comanche Swiki---------------------------------------------------------version:		ComSwiki 1.5, "One Of These Days"			Comanche 7.0.2squeak:		3.7date:		2 December 2005by:			Je77 (Jochen.Rick@cc.gatech.edu)---------------------------------------------------------To Set Up Your System:1. Put the 'swiki' folder in the folder where the image file is2. Start Squeak3. Install Comanche through SqueakMap	a. In the world menu, click on 'open...'	b. Choose 'SqueakMap Package Loader'	c. Install 'Dynamic Bindings (1.2)'	d. Install 'Named Process (1.2)'	e. Install 'KomServices (1.1.1)'	f. Install 'KomHttpServer (7.0.2)'4. Install 'Swiki.cs5. Do: (ComSwikiLauncher openAsMorph)6. Set the port by pressing the port button on the ComSwiki Launcher	a. port 80 is the default web server port, though you may not have permission to use it		(on various *nix implementations, users are not allowed port access to low numbers)	b. port 8000, 8080 and 8888 are the other options7. Save changes	a. left button click on background to get World menu	b. click on 'save and quit'8. Start the server	a. press 'start server' button on ComSwiki Launcher (this may take some time)9. Use the AdminTool to set up the site	a. go to http://mysite:8080/admin/help#getStarted (substitute your port number for 8080)	b. the user:password pair is admin:password	c. follow the instructions there to get startedTo End Swiki on Comanche:1. Press 'stop server' button on ComSwiki LauncherTo Automatically Start Comanche/Swiki:1. Press 'save & exit' button on ComSwiki Launcher.	note: the next time that Squeak starts, ComSwiki starts automaticallyMiscellaneous Notes:1. When downloading and transferring Swikis, you should transfer in binary mode