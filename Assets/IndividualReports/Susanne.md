# Good Code

Most of the code I wrote built on something someone else had already made the base of, for instance the player, or a NPC. And as such I have had a hand in almost everything. One of the things I implemented is a counter for the popups. Once a popup is displaying, you had to manually click it away. To solve this I had to use a coroutine which could run on its own. I made new variables to keep track of what I needed: 

![image](https://user-images.githubusercontent.com/60709685/206909048-83c60a52-a2e2-469b-974e-2ada61fa29c6.png)

The bool is updated to false once the timer is done.

![image](https://user-images.githubusercontent.com/60709685/206909083-8bb14f70-c44c-47e2-a843-17c7480c93a8.png)

What was interesting about this challenge was that couldn't find a way to stop the coroutine early, if say the user clicked the popup away manually. I had to do some research before learning to set the corutine and give it a name as a variable. This is showcased in the first picture, and then when I want to start the timer, I call it like this: 

![image](https://user-images.githubusercontent.com/60709685/206909167-a83eb874-de6b-49cc-8bbc-771a6bb9ed43.png)

And when I want to stop it, I call it like this:

![image](https://user-images.githubusercontent.com/60709685/206909188-12c858d7-f999-41c9-8502-9a719b6eafd0.png)

Examples fetched from: [Here](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/Scripts/UI/PlayerNotification/MessagePlayerScreen.cs)

# Bad Code
As this was my first try with Unity, I am confident there are some non-optimized solutions. The one I am showcasing here is how the sound is played when the dragon is walking. We got eight different foot soundsteps from our sound developer, Birger. I have been the one to implement most of the audio, including SFX. The steps were difficult because I wanted to do as I had done for the rest of the SFX, and that being, calling it when the function for what was performed. Like jumping, or roaring. But walking was different. When I researched how to do it online, all I got was either a loop of a single audio playing whenever the player was walking, or connectiong the sounds to the animation of the 3D model. I tried both, but was not happy with the first solution, and was not able to get the second one to work, and as such, I implemented a bad solution that sounds the best. 

What I did was set a new variable in the dragon called stepID.
![image](https://user-images.githubusercontent.com/60709685/206909507-70774a0d-a567-4afe-b990-89f7a52b68fe.png)


This variable would keep track of which step (out of the 8 possible sounds) was currently playing. Then I made a switch with all the possible numbers StepID could be, and set the music to play. 

![image](https://user-images.githubusercontent.com/60709685/206909588-6065f645-0651-4c59-9a6a-84916a22cca6.png)

Well, it worked, but note that on line 174 there is a a pretty long if check. Because originally without this, witout checking if the sound was done playing, you would be blasted with a cacaphony of noise upon trying to walk in game. So to stop this I had to make an aditional function to only allow the next sound of the next step to be played once the previous one was done playing. And the only way I could fix this was to constantly check in an update loop:

![image](https://user-images.githubusercontent.com/60709685/206909817-89663f29-1fd1-40f4-b194-bc58417a24d1.png)

So it works, but the implementation is bad. To fix this, I would have simply gone back to the 3D animation of the model and added the sounds there. 

All but the last image is fetched from: [Here](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/Scripts/Character/Player/Dragon.cs)
The last image is fetched from: [Here](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/checkEndofSound.cs)


# Reflection on things learned and keyconsepts
As I was the bear of the group, I was in charge of scheduling and setting tasks to be completed. I was the one to pitch this game to the rest of the group at the start and I am increadibly lucky to have been working with these people to deliver such a good product (in my opinion) that matched my original idea so well. That being said, I feel like I have learned a lot about the gamedesign aspect of the course. I made and designed the abilities, the interactables and most of the levels. (4/6) I contacted resources outside of NTNU, and was able to get a composer for the game, and I made all the 2D art that was used in the game, as well as the central 3D models, like dragon and NPCs. It was exiting to try and tell a story through the medium of  game, as well as making interesting designs and levels that would feel good to play. I also learned Blender for this course to make the 3D Models. As well as using Clip Studio Paint to make the 2D animated sections. 

I got to try Unity for the first time and had a grand time learning to use the already made objects like crates or capsules and playing around with the physics. When we got to work on the code I was able to pick up C# relatively quick. The coding aspect was fun, albeit challenging. I will honestly say that while I had a hand in almost everything that was developed, that was because the other group members would build the basis for it, and I would then later on come in and add more functionality, or change the implementation. That doesnt mean I didnt create anything from scratch, I simply wish I had more of an oppertunity to do so during this course. However, I am going to remedy that in the future as I am not done with Game programming in my life!

# Rubric and final reflection
I feel like I have put a lot of work into this project. I have coded a lot, albeit perhaps not as much as some other members of the group, but I had so many hats in this project that undertaking anymore would have made me topple. I loved working with the team and making a game like this. I was playtesting it with my friends both online as well as physical where I was able to get lots of good fedback on how to design the game around the player. I am very happy with the result, and I hope I get to work with more games in the future!

|Description | weight |
|----|----|
|Gameplay video  | 20 | 
|Code video | 10 | 
|Good Code  | 10 |
|Bad Code| 20 |
|Development process | 10 | 
|Reflection |  30 | 
