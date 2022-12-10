# Penny for your wish

This is a game where you play as a dragon who is on a mission to kidnap the princess.

Our gamedesign document: https://github.com/ThomasMACHINE/PennyWise/wiki/Game-Design
Our Original gamedesign document: https://github.com/ThomasMACHINE/PennyWise/wiki/Original-Game-Design-and-Ideas
Our 2D assets: https://github.com/ThomasMACHINE/PennyWise/wiki/2D-Assets

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
 - Music was created for the game by extern: Birger Wessel Audio (Link to their youtube channel: https://www.youtube.com/channel/UCgvNONj7uLkhVaEoIFIzDRQ) 
 
 ## Videos
 - Trailer
 - Full Gameplay 
 - A video showing off the code that is tightinly integrated with the game engine that is difficult to see from the text of the programming.
 
 ## Individual reports:
 
 - Susanne (ADD LINK TO OWN SELFREFLECTION)
 - Thomas (ADD LINK TO OWN SELFREFLECTION)
 - Fredrik (ADD LINK TO OWN SELFREFLECTION)
 - Ole  (ADD LINK TO OWN SELFREFLECTION)

### Work Distribution Matrix

ADD YOURS INN

All
Most
Half
Some
Touched

| | Susanne | Thomas | Fredrik | Ole | 
|----|----|----|----|----|
| Player |Touched|||| 
| NPCs |Touched||||  
| Movement of Player |Some|||| 
| Objects like Crate(removed) and Bush |Half|||| 
| Coins|Touched|||| 
| Interactables like doors/pressure plates ||||| 
| Designs/Modeling/Animating |Most|||| 
| UI |Some|||| 
| Maps |Half|||| 
| Audio |Half|||| 
 
 ## Group discussion on the development process

#### Strenghts and weaknesses of Unity (NEED MORE?)
For our project we decided to use Unity. The decision was made relatively early on, already within the first meeting the group had. Most of the group was impartial to the choice, however some had previous experience with Unity and suggested using that engine, since it was well suited for the kind of game we were planning to make. The game is a 3d Puzzle/plattformer game. We did not consider using godot as its better suited for 2d games. 

Unity also allowed for easier scripting. Since Unity uses C# insead of Unreals C++, C# handles all the memory related functionaleties and the game is able to run for days without any problems or glitches. 

After working a little in Unity we learned how easy and convenient it was to create new scenes, and use the prefabs we had created of objects to simply drag and drop into the scene. We had made a prefab of the player for instance, and with this method it was simple to add it to a new scene without doing any work over and over again. Admittedly we had some problems in the begining because not everyone was using the same version of Unity, but once that was resolved we had no further issues. 



#### Process and Communication systems during development
We used the team roles established from the teacher, where each member selfassignes an animal. Susanne was the bear, Thomas was the Rabbit, Fredrik the Wolf and Ole was the Cat. Most of the team fit snuggly into these roles, we were not a large enough team to encompass all the roles, and as such we were missing the owl and the puippy, the owl which makes sure progress is made was added to the role of the bear and puppy was easily accepted by everyone as all the group members were able to push forward with entusiasm.

The following image is a screenshot of the video explaining the roles. The video can be found here: https://www.youtube.com/watch?v=WB6w7ovocpk
![image](https://user-images.githubusercontent.com/60709685/205981735-df13084e-7ef3-42c5-a3ca-b221da84d80a.png)

In regards to communication, not all students are in Gjøvik and as such, everything happened online via Discord. We used the channel provided to us from the game programming server, as well as creating our own server for more indept descussions. 

Our structure of work and progress was quite similar to the agile development method: Scrum. We agreed to a meeting once per week. This meeting happened after the lecture/lab on fridays and lasted untill some members had work to attend or the tasks had been completed. Each meeting consisted of every member of the group going over additions to the code for functionality, that way everyone was updated on the game functionality, and after that, we reviewed the backlog and added more tasks to do untill the next friday. Ocationally we would spend this meeting working together on a harder issue, or discuss particular game design ideas. The tasks divided and completed were organized as issues in the git, more on this bellow. 

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
