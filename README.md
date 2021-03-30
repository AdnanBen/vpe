# Deployment Manual

**Unity: Building**
1. Open using Unity 2019.4.17f1 or later 2019 version
2. File > Build Settings > Build

**Web app deployment**

(The main web app is currently deployed to https://vpe-video-chat.herokuapp.com/, the peerjs server is at https://vpe-peerjs-server.herokuapp.com/)

**If you would like to use your own web app and peerjs server:**

1\. Set "host" of the myPeer object in public/script.js to a live PeerJS server. Remove the "host" attribute to use the default server provided by PeerJS. (PeerJS deployment information can be found at https://github.com/peers/peerjs-server)  
2\. Run "npm install" in the presenters-videos folder to install dependencies.   
3a\. Run "npm start" to run the node app locally  
3b\. Alternatively, deploy the node app following the deployment guide of your hosting provider

**Setting URL to self hosted web app:**
1. Run the built application once and close
2. Navigate to install folder, Config/config.json file and replace URL

## User Manual

Run VPE.exe executable to start the program

**Configuring a new scene**
1. Select “New Scene” in the main menu
2. Select a venue by clicking on it in the scrollable box
3. Press next arrow in bottom of screen to proceed with loading, otherwise back arrow to return to main menu
4. Select desired scene components by pressing on tick boxes. For desktop capture, click the dropdown box to select a desktop
5. Press next arrow to begin presentation mode

**Movement and camera controls**
- W A S D keys control movement, Left Shift and Left Control control directly vertical movement.
- Arrows keys are used to change the camera angle and rotation.
- Holding space temporarily increases sensitivity/speed of the controls
- You can save camera position and angle+rotation by holding any number on your keyboard, 0 to 9, for two seconds. To restore that save, simply press that key again

The help menu shows movement and rotation controls, sensitivity adjustment, and saving + loading camera angles. It can be accessed at any time during present mode via the dropdown menu

**Using the dropdown menu**

To access the dropdown menu, press the gear icon in the top right of the screen. Press again if you need to close it.

Dropdown menu allows you to access the following functions:
- Open scene configuration menu
- Open help menu
- Open web app for multi-presenter functionality
- Load a saved scene
- Save the current scene configuration and defined camera angles
- Exit to main menu

**Saving and Loading**

Save and Load is available from the dropdown menu. You can also press “Load Saved Scene” in the main menu.
The following data is saved:
- Which scene components are enabled
- Saved camera angles

Saves files are stored in C:\Users\%USERNAME%\AppData\LocalLow\ucl\VPE\Saves


## OBS and web app for multiple presenters

0\. (Prerequisite) Launch VPE, configure scene, move camera into desired position.

**1. Web App instructions:**

a) Open the web app from the dropdown menu button, a new room will be automatically created. Ensure you have given the website permission to access your camera.
b) If you do not have a green screen, select the correct webcam and enable the “Remove Background” option.
c) Click “Join Call”
d) Send URL to co-presenters, they must do steps b and c.

2\. Create a new OBS scene in the bottom left panel by pressing “+” and select it
Add a new source, of type “Game Capture”, Set Mode to “Capture specific window” and Window to “[VPE.exe]”

Manipulating sources:
To adjust size: Ensure the correct source is selected, then in the preview window: drag the red squares on edges of selected source.
To reposition: Click and hold source in the preview, move to desired position.
To crop: hold “Alt” key and drag squares like with size adjustment.

Applying chroma key:
Press “Filters”, add an Effect Filter of type “Chroma Key”

**4\. To add yourself as a presenter, if you are using a greenscreen:** Add a new source, of type “Video Capture Device”. Manipulate as needed and add chroma key effect.  
**5\. To add co-presenters and/or self if using background removal:** Add a new source, type “Window”, for Window select your browser window with the web app. Duplicate the source for each presenter, manipulate the source to crop onto the needed grid section of each presenter. Add chroma key effect.

If you have multiple saved camera angles in VPE, you can duplicate your OBS scene and reposition presenters as needed. You can set a hotkey to switch OBS scenes, for examples to the same keys as the saved camera angle, or to something more convenient like number pad keys. To do this: File > Settings > Hotkeys, scroll down to the target scene and set the “Switch to Scene Hotkey”.
