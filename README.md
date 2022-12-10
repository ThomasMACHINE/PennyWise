# Penny for your wish

This is a game where you play as a dragon who is on a mission to kidnap the princess.

- Our gamedesign document: [Here](https://github.com/ThomasMACHINE/PennyWise/wiki/Game-Design)
- Our Original gamedesign document: [Here](https://github.com/ThomasMACHINE/PennyWise/wiki/Original-Game-Design-and-Ideas)
- Our 2D assets: [Here](https://github.com/ThomasMACHINE/PennyWise/wiki/2D-Assets)

Or you can go to the wiki and find these documents there.

## Members of the group:
 - Susanne Skjold Edvardsen
 - Thomas Vincent Lien
 - Fredrik Lønnemo
 - Ole Anders Hvalsmarken

## Resources:
 - Background materials such as mountains and trees were fetched from: unity asset store
 - 2D Animations were made by Susanne
 - 3D Models (Dragon and NPCs) were made by Susanne
 - 3D animations of models were made by Thomas
 - Music was created for the game by extern: Birger Wessel Audio. Link to their youtube channel: [Here](https://www.youtube.com/channel/UCgvNONj7uLkhVaEoIFIzDRQ) 
 
 ## Videos
 - Trailer
 - Full Gameplay 
 - A video showing off the code that is tightinly integrated with the game engine that is difficult to see from the text of the programming.
 
 ## Individual reports:
 
[Susanne](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/IndividualReports/Susanne.md)
[Thomas](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/IndividualReports/Thomas.md)
[Fredrik](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/IndividualReports/Fredrik.md)
[Ole](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/IndividualReports/Ole.md)

### Work Distribution Matrix
| | Susanne | Thomas | Fredrik | Ole | (EXTERN) Birger |
|----|----|----|----|----|----|
| Player |Some|Half|Some|Some|| 
| Movement of Player |Some|Some|Some|Some| |
| Camera ||Some||Most| |
| Guard NPC |Touched|||All||
| NPC Framework ||All||||
| Pathwalking |Touched|All||Touched||
| Objects like Crate(removed) and Bush |Half|Some|Touched|Some| |
| Coins|Touched|Some|Half|Half| |
| Interactables like doors/pressure plates |||Half|Half| |
| Designs & Modeling|Most||Touched|| |
| Animating | Half|Half||||
| UI |Half|Half|Some|Touched| |
| Levels |Half|Touched|Some|Half| |
| Audio Implementation |Most|Some||| |
| Designing Audio | ||||All|
 
## Group discussion on the development process

#### Strenghts and weaknesses of Unity
For our project we decided to use Unity. The decision was made relatively early on, already within the first meeting the group had. Most of the group was impartial to the choice, however some had previous experience with Unity and suggested using that engine, since it was well suited for the kind of game we were planning to make. The game is a 3d Puzzle/plattformer game. We did not consider using godot as its better suited for 2d games. 

A strength of the way GameObjects work in Unity is that it is easy to attach new scripts and configure them in the inspector.  Since Unity uses C# insead of Unreals C++, C# handles all the memory related functionaleties and the game is able to run for days without any problems or glitches. SerializedFields in the inspector makes it excellent to configure values as they can be changed while the game is running, making it a lot easier to try out new configurations quickly. Another strength is that once you have found your desired configurations, the GameObject can be saved as a prefab, allowing for quick re-use and implementation.

After working a little in Unity we learned how easy and convenient it was to create new scenes, and use the prefabs we had created of objects to simply drag and drop into the scene. We had made a prefab of the player for instance, and with this method it was simple to add it to a new scene without doing any work over and over again. Admittedly we had some problems in the begining because not everyone was using the same version of Unity, but once that was resolved we had no further issues. 

A weakness of the hierarchy is that it can be hard to organise larger scenes, as all GameObjects share the same icon. The main tools to organising the hierarchy is proper naming, good use of parenting and putting in empty game objects to add artificial space between objects in the hierarchy. Roblox Studio's hierarchy is an example of a nicer hierarchy, where different objects have different icons.

Another fault with Unity is the lack of multiplayer implementation, which would have been difficult to add to the implementation. Luckily for us we had no such ambitions to use multiplayer, and as such Unity was still the best suited engine to develop the game within.


#### Process and Communication systems during development
We used the team roles established from the teacher, where each member selfassignes an animal. Susanne was the Bear, Thomas was the Rabbit, Fredrik the Wolf and Ole was the Cat. Most of the team fit snuggly into these roles, we were not a large enough team to encompass all the roles, and as such we were missing the owl and the puppy, the owl which makes sure progress is made was added to the role of the bear and puppy was easily accepted by everyone as all the group members were able to push forward with entusiasm.

The following image is a screenshot of the video explaining the roles. The video can be found here: [Link](https://www.youtube.com/watch?v=WB6w7ovocpk)
![image](https://user-images.githubusercontent.com/60709685/205981735-df13084e-7ef3-42c5-a3ca-b221da84d80a.png)

In regards to communication, not all students are in Gjøvik and as such, everything happened online via Discord. We used the channel provided to us from the game programming server, as well as creating our own server for more indepth discussions. 

Our structure of work and progress was quite similar to the agile development method: Scrum. We agreed to a meeting once per week. This meeting happened after the lecture/lab on fridays and lasted untill some members had work to attend or the tasks had been completed. Most commonly the meetings lasted from 10.00 to 13.00. Each meeting consisted of every member of the group going over additions to the code for functionality, that way everyone was updated on the game functionality, and after that, we reviewed the backlog and added more tasks to do untill the next friday. Ocationally we would spend this meeting working together on a harder issue, or discuss particular game design ideas. The tasks divided and completed were organized as issues in the git, more on this bellow. 

#### Use of version control systems

As mentioned above, we each got assigned tasks to solve for each week. Some tasks were bigger and took more time, while some were shorter and quickly solved. When working each member would then refer to the assigned issue ID in their commit message, that way it was easy to track which merge had worked and updated each issue. Here is an example: https://github.com/ThomasMACHINE/PennyWise/issues/70  

Here is the issue, we can see the name is indicative of what is needed to do. On the right is a picture of the person who is assigned to this task.
![image](https://user-images.githubusercontent.com/60709685/205984404-e85add03-36cd-41b5-b0ad-484e2f7d060b.png)

Inside the issue it looks like this: 
![image](https://user-images.githubusercontent.com/60709685/205984621-3c71c75d-e85f-43f6-9ec5-d985c0eb8ebf.png)

Here we see a more indepth explanation for what is needed to complete the task. Underneath we see that the issue was worked on and mentioned in some commit messages, then applied some labels before being marked as complete. 

The labels we have for the project are as following: 
![image](https://user-images.githubusercontent.com/60709685/205984900-1f34e469-7378-4d27-a97e-d5aaaf562c5b.png)

Which are all easy to understand and add to issues as they are being worked on. 

In the development we made some use of branches in Git, ideally we would have more use of this feature. By protecting the master branch and only accept merge requests approved by other group members we could have had a more secure development process. This could have been a little tedious as some files like prefabs are very sensitive to merge conflicts, and if group members were not vary, this could lead to them often being behind on each others work. This could be troublesome as two members could have worked on a prefab for a week, then once finished and pushed, one group member will have to discard their configurations and do them all over again. Routines that would mitigate this are pulling often, resolving conflicts in your own branch as you go along and pushing changes quickly. However it is also not ideal to push half-completed issues, therefore it was considered troublesome to enforce strict rules to the main branch.

Throughout the process we made up for the security problems through rigorous QA-testing by every group member, separating work so that the members are rarely working on the same components and good communication on the occasions where this was inevitable.

#### QA - Testing
During the developement each functionality was tested by the team before being pushed by main. In addition to this we also had a team playtest the game whenever new functionality was added. In reality the game was playeted once every month. This made it so we always worked towards a game that would feel good to play. 

In addition to this testing, we also performed testing by and for the other groups in this subject. When we performed our tests we mostly got feedback that we were expecting, and some bug fixes.

Here is a list of notable changes that were made due to testing:
- Platform/elevator - Now moves the dragon smoothly instead of jaggedly
- Glide - Now automatically goes forward instead of needing to specify direction with WASD
- Crate - Removed from the game as most players forgot they could pick up objects
- Score - When playing as the largest dragon, we originally removed the ability to pick up coins, but testers wanted to be able to collect all the coins and as such we made it so that when you pick up coins as the biggest dragon, you instead increase a score.
- Easy - We noticed that whenever the player had acces to the bush as a medium dragon, they could simply pick it up and walk past all guards. So we implemented a movementcheck that checks if the player is moving while in the bush. This made the levels a little more difficult to complete.
