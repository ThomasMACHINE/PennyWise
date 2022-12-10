#The Bad
One thing that became abundantly clear were the difference in coding style. Personally, I like to have long variable names that makes commenting redundant. Others however use the minimalistic approach like this (comment added later). Another thing was to use of hardcoded values, have tried to minimize it, but there are still some leftover.
https://github.com/ThomasMACHINE/PennyWise/blob/6984e3d4acc15c5eb750d753093ee285cb43b54f/Assets/Scripts/GameObjects/PlatformMovement.cs line 14.
 
Another bad thing is “legacy” code. By this I don’t mean code that are not in use anymore, but code that may be considered redundant due to changing the implementation of something.
Let’s take the code for updating the player model https://github.com/ThomasMACHINE/PennyWise/blob/6984e3d4acc15c5eb750d753093ee285cb43b54f/Assets/Scripts/Character/Player/PlayerStatController.cs line 39-69
 
This code checks the global coin score, and records it in a variable. Based on it and the global model, one can activate or deactivate certain models in the next scene. Two things to notice here is that the medium and large dragon being deactivated should not do anything since the are implemented as disabled. This has changed for being used (with similar lines in the first if-check), to not. I choose to keep it in, since it would mean that I could easier change the implementation if the group decided to change the implementation later. The else line is also “useless” since there should be no way to ever reach it. As a safety option, one could choose to exit the application instead of reloading the scene.

https://github.com/ThomasMACHINE/PennyWise/blob/6984e3d4acc15c5eb750d753093ee285cb43b54f/Assets/Scripts/Util/CameraController.cs Line 70-82.
Finally, the camera implementation. Originally, we only needed to have left-right movement with an option to zoom in and out. When we implemented moving platforms and elevation, this however changed. However, the implementation we had so far used was a camera following the player movement with a delay (longer when loading a scene in to get a pan effect). If we implemented the movement as we had done with right-left, it would mean that the player model would need to rotate. This would have the effect of causing the player to leave the ground due to physics. The solution was to move the target higher or lower based on user input, so that one can get the same effect. While it still works, I would rather has the camera as a separate independent movement. This would also make it easier to avoid the behaviour of the camera clipping into walls (and as such, makes them see-trough). One issue that I ran into with mouse is that there is no good way to tell how much value is added by moving the mouse down -> up in a given timeframe, since it depends on the speed of moving the mouse. This led to either the mouse getting locked out from the if-check or over scaling. By resetting the mouse value to a lower value, one can avoid both, but it’s inelegant (not to mention hardcoded, so could be issues if one has a different scaling/sensitivity on their mouse)
#The Good
With regards to good code, one could consider the solution to the bug in issue #82.
https://github.com/ThomasMACHINE/PennyWise/blob/6984e3d4acc15c5eb750d753093ee285cb43b54f/Assets/Scripts/Character/Player/Dragon.cs line 124-138, 439-455
The bug happened due to changing size (devolving being the only option here) would disable the script before it finished execution. One fix could have been changing all guards in a scene to be correct when devolving, but this would be bad practices if we implemented several similar mechanism interactions. 
As one can see, we use coroutines to enable the guards to have different times before returning to normal (possible when the cooldown of the roar is shorter than the guards time to return to normal).
Instead I added the option to reset all the guards in a scene (assuming there is at least one) when devolving. This has the added benefit of making more gameplay sense, since the medium dragon is not “as scary” as the large.
 

Another implementation of good practices is quite simple.
https://github.com/ThomasMACHINE/PennyWise/blob/6984e3d4acc15c5eb750d753093ee285cb43b54f/Assets/FallingRock.cs and https://github.com/ThomasMACHINE/PennyWise/blob/6984e3d4acc15c5eb750d753093ee285cb43b54f/Assets/FallingRockSpawner.cs

 
This is part of the falling rock system. The FallingRockSpawner.cs will spawn rocks upside down (so they are pointing downwards) where each rock will be a separate coroutine. The rocks themselves has a check its world position and will destroy the rock game object if it passes it. One could technically just spawn the rocks themselves, but this will lead to an issue if one does not finish the level, as more and more game objects would be spawned. Normally this would only manifest after a long time, but it’s still good practice.

#Key concepts
On the playtesting front, it became painfully obvious to make sure that everything was ready before the playtesting seeing as several groups had different issues with getting an executable. From the playtesting it was surprising how different people would play the game. Some were speed running through it, while others went slow. It was also enlightening to see how different skill levels affected the testing. From playtesting it also became clear why delivering a bug-free game can be hard, due to the fact the players will try almost anything, causing edge cases to be more apparent.
Another key concept used was more of an ideological discussion. When we implemented the “AI” in the game one key concept of AI is the “ability” to learn. A finite-state machine however CAN be seen as a glorified if-else statement, and as such, would not have an ability to “learn”. So the question would then be; “What constitutes learning in an AI”.
With regards to monetization there is a lot to be said. There is no one-size-fits-all with regards to it. However, there seems to be a correlation between the amount of money one can earn, and how aggressive one is with monetization. 
There are also the concepts mentioned earlier with regards to small teams working remotely. The first rule of small teams working remotely is to create rules around working. In our case, it would have been beneficial to have a standard for code writing to avoid previous mentioned challenges.

# Reflection
Developing and seeing the game come together was fun. It also made me look at more relevant things, like the series starting around the start of the semester by Masahiro Sakurai (creator of Kirby. Link: https://www.youtube.com/@sora_sakurai_en/videos). Another would be the limitations and advantages of the different engines (looking at the Unreal engine 5.1).
It also led to me looking at other games, and trying to figure out how different aspects were made and why they was made that way, like the interview with Glen Schofield (link: https://www.youtube.com/watch?v=TEXdJU9ZUX8). 


Rubric 
Description	min	def	max
Gameplay video	5	10	20
Code video	0	10	15
Good Code	10	20	30
Bad Code	10	20	30
Development process	10	20	30
Reflection	10	20	30

### Rubric 
|----|----|
| Description|  |
| Gameplay video|10|
| Code video|  10 |
| Good Code|   20 |
| Bad Code| 20|
| Development|20  |
| Reflection|20|

