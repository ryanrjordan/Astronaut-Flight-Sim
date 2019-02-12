Instructions on setting up the Unity project:
1. Install the newest version of Unity from https://unity3d.com/get-unity/download
	(You don't need really any of the optional downloads, if you use the installer)
2. Pull the project from the git repo: https://git.ece.iastate.edu/409-group/409-prototype.git
	You shouldn't need to authenticate at all. I'm not worried about security, but I can add it if you want.
3. Launch Unity and open the project titled "Unity_Prototype".
4. I recommend downloading Visual Studio Code(ide) for free, if you need a C# editor.

Just a few extra tips.
1. To run the project, click the play button in the middle of the top of the screen. 
	The current keyboard controls should be displayed on the screen when running.
2. The lefthand list of things like astronaut, sphere1-3, and canvas lists all of the assets in the "scene".
	When you click on an asset in can be modified on the right.
3. I would recommend not messing with the camerafollow script, because it was a god damn nightmare to 
	get to where it is now and I'm scared to modify further it myself. I think it's good enough.
4. The big colored cube that spawns directedly infront of the player is the "space station" where ideally
	we could have collision detection to detect if the user makes it to the station. 
5. Mainly the project needs collision detection and the "debris/meteor event" where	random objects 
	move towards the player to be added. I think just setting stuff around the station and having
	those set objects be forced towards the player when they hit a button should suffice.
6. We also need to add controller support, but that should be simple.
7. I would highly recommend watching some YouTube videos(checkout the channel Brackeys) and 
	messing around with your own project before working on the prototype, unless you have a hang of things.
	

I didn't proofread any of that, so let me (Ryan) know if something doesn't make sense.