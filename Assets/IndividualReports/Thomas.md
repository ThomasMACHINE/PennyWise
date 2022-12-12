|Description | weight |
|----|----|
|Gameplay video  | 20 | 
|Code video | 10 | 
|Good Code  | 25 |
|Bad Code| 10 |
|Development process | 15 | 
|Reflection |  20 | 

# Reflection on Group Process
My role in this project was the role of the rabbit. The rabbits role is to be the facilitator for the team, through resourcefulnes, willingness to help and communicating across the team. I participated in the last iteration of this module, and I know how hard it could be starting up in Unity. This time I had some previous experience through other projects.

I used this knowledge to quickly create prototypes of how to solve different things. At the beginning of the development process where most are beginners, simple tasks like making the character move back and forwards can be quite tedious. Using OBS to record myself working, I would regularly post updates to the team with for example: Dragon movement, evolving, picking up coins and spitting them out. I would post these clips on Streamable and then link it in our Personal Group Discord. In total I made 33 or more clips. In the clips I would show for example the inspector, how I attach the scripts and fill out the variables for the given script. The goal I had in mind while doing this was to make it easier for the group membes to pass the initial Unity hurdle.

While I am not sure how much impact this had by itself, it was still working well as I would be available to answer any questions if there were any. What I realised along the way was that this was an excellent tool for motivating the group, and I think that the group encouraging each other and developing steadily from day 1 was a large factor to our success. 

Another way I tried to facilitate was by setting a fundament for some of the components our game would need. PlayerController, PlayerStatController and Dragon script are examples of this. PlayerController would be responsible for processing input and signal to PlayerStatController. PlayerStatController would process the signals and make changes based on these, like making the Dragon move, evolve or glide. The Dragon script would be used to create instantiations of Dragons (As this game would have multiple PlayableCharacters), setting speed, jumppower, booleans on each different model.

After setting a decently sized core of functionalities, and a precedent for how these 3 scripts operate together. I started working on other scripts and the group would continue to build on this Player Package. I then realized that it might have been a little bit confusing, as I would see Input handling at the PlayerStatController instead of the PlayerController, PlayerStatController suddenly declaring enums for DragonSize which should be in the class where the Dragon is defined.

It was an interesting lesson on how your own code and design is not inherently obvious to your other teammates, in the end it went fine as the group worked well together, and would squash bugs quickly when found. But I have also reflected on what I could have done to make it more obvious, and I think the name: PlayerStatController does not even make sense, does Stat mean State? What is the relation between a PlayerController and a PlayerStatController? I think changing their names to something like: **PlayerInputReader, PlayerStateController** could have made it more apparent, but this is better left for the code discussion.

One thing I regret not bringing up was using a shared document for codestyling, especially for C#, microsoft provides excellent advice for having consistent looking code.

## Learning
Going into this subject my goal was to improve at getting hands-on with the code, improving my capability of sitting down and cracking down on a problem/ticket/issue. I had a tendency to avoid some issues, pondering and writing down how I would like to solve them on paper. While I would still do this for more complex problems, I wanted to condition myself to sit down with the IDE and try out different variations rather than procrastinating until I am confident in my choice. I feel like I did quite well in this aspect, as I had many sessions where I went in deep focus and got some good work done. The "package" for NPC's was the result of one of these sessions. It's quite nice seeing what can be achieved, and especially with game programming there is a lot of space to nudge in some quality pieces of code in so many areas.

I also got to try out different things, with the NPC's I attempted to program by interface, PlayerController, PlayerStatController and Dragon tries to follow MVC where dragons would be the Models, PlayerController is the View that takes in player input and PlayerStatController is the business logic for the Player Package. There are of course some oddities as PlayerController would not be doing any output, but regardless I think designing it around MVC was cool. One regret in my code is not making some of the classes Singletons, there are some classes like PlayerController and PlayerStatController which really behaves as one and would greatly improve the code if they for example had an public static instance variable. That could have saved a lot of effort assigning them in the inspector on Unity.

The most impactful lecture for me might have been the ethics one. There are many games that conditions the player into spending time, and/or money unwillingly. An recent example of this came from Jagex - Runescape. They released some limited edition servers where all players starts from the beginning. While the idea was percieved as fun and exciting, Jagex added a bunch of limited edition items that would be given to the player on the main game if they were to achieve it. For reference, some items could take up to 200 hours to collect individually. With this, players were induced with a fear of missing out as they would never have another oppurtunity at claiming these items. However, since many players did not have the time to invest all those hours, it would further incentivize the players to spend their real money to boost themselves towards these goals.

The way this impacted my product was that my perspective changed from making a challenging product, I was more focused on creating an experience. Before I could have wanted to implement a nearly impossible game with purchaseable skips, but having the player face the same wall soon after again. 

## Working in a group

I had quite a good time in the group. It was a group of 4 motivated, likeable, and keen people. Our discussions where productive, issues were resolved quickly, someone was always quick to take on new problems and we were understanding of eachothers situation as we had 4 different schedules. 

Our group had a great mix of skills. When producing a game you need a multitude of skills to produce high quality work in all the different areas like 2D and 3D design, sound design, player design, maths for things like camera movement. I would have an awful time using Blender, or trying to produce any 2D graphics. This was covered by a group member, and I think we did great work at distributing work so that each team member could use their strengths. I also think our great communications gave great learning oppurtunities for each group member as everyone was happy to walk eachother through their work.

I think the work went great, Ideally I would have liked to do some more polishing to our development process. It would have been cool to formulate tickets as stories and work with Story Driven Development. Requirements on tickets would also have been an improvement as that would force the group to align on the criterias the work should meet. No problems occured when it came to this as most tickets were resolved well and with high quality. Regardless, it is about working in a way and following procedures which minimizes the risk of errors, so I still think it could have benificial.

# Good Code
To start of, I like simple solutions, in the GamePauseMenu we wanted to make instructions for the player, my idea for this was that instead of making plenty of Panels with many UI elements, we can instead make the images on Paint for each instruction page and navigate through them like the picture app on your phone. The UI simply has 1 arrow on each side, the script holds a list of images.

<img width="559" alt="image" src="https://user-images.githubusercontent.com/53544690/206933297-a91984f1-7633-4516-b624-21f846516093.png">

And the thought process is simple, the User can either get the picture before (left) or the next (right) through the pictures, by clicking the arrow keys in the UI. 

<img width="676" alt="image" src="https://user-images.githubusercontent.com/53544690/206933436-be1c3eca-15a4-4b0a-a1ac-0c6fd78ac350.png">

All in all I feel like I have sprinkled a lot of nice simple solutions into the codebase like this, another example is the PlayerNotifier: [MessagePlayerScreen.cs](https://github.com/ThomasMACHINE/PennyWise/blob/417b681ceb9afd65fb808348e542fe3d49099f3b/Assets/Scripts/UI/PlayerNotification/MessagePlayerScreen.cs) The functional use of this script would be to create any other random script that contacted this script, sending along a message to be displayed to the user. Beyond setting up the UI for the text fields and icons, the script is simple and does what it needs to do. Messages are queued unless they can be shown instantly, and when removed the next message in the queue will be shown. If there are none, it will then deactivate itself, awaiting a new message.

**PlayerController, PlayerStatController, Dragon**
The end result of this was very pleasing! This code now follows the vision of PlayerController checking for Input, PlayerStatController doing the processing and controlling Dragon and other things like UI and Score. And Dragon allowing the designer to customize dragons that can be controlled by the PlayerStatController.

**Good Code - Framework**

I was quite happy with my NPC "framework", this was not used heavily in the game, only being utilised for the GoldGolem.

The useage for this framework would be to seamlessly add in new Characters to the game, and skipping most of the boilerplate code. There are 2 main scripts, Character and AggressiveCharacter.

Character implements the interface IWalkingCharacter, which ensures that the Character class and its inheritors has a definition for DoMove()

<img width="558" alt="image" src="https://user-images.githubusercontent.com/53544690/206931567-b0f48a81-69a9-40fb-87b7-408d4f94e1f6.png">

The Character implements this interface, with a working base function that can be used by inheritors.

<img width="722" alt="image" src="https://user-images.githubusercontent.com/53544690/206931602-4bf202ec-416a-40b3-9c10-90e1e3785cda.png">

The result of this is that we can now make a new Character - ScaryBalloon, inherit from Character, and we now have skipped some of the boilerplate definitions of variables, and the movement function.

This is also extended to AggressiveCharacters, which inherit from Character.

<img width="580" alt="image" src="https://user-images.githubusercontent.com/53544690/206931791-2d04a326-9ef8-4df2-af6b-5272c5fe377f.png">

To see what the Aggressive Character class looks like, we can look at the Interface it implements.

<img width="635" alt="image" src="https://user-images.githubusercontent.com/53544690/206931894-55ccc320-fbac-4387-8846-3566b22aebf4.png">

Interestingly, the **CheckPlayerCaught** and **OnPlayerCaught** is abstract in both the interface and the class. This somewhat goes against the idea of re-usability, however I wanted to ensure that each different kind of NPC would implement something new and unique when interacting with the player.

This shows the whole of the script, granting some free movement methods and search AI.

<img width="1122" alt="image" src="https://user-images.githubusercontent.com/53544690/206932202-b2c8688d-7202-40f0-bee2-a652bdb8295a.png">

[GoldGolem](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/Scripts/Character/NPC/GoldGolem.cs) shows how this can be implemented, having its own custom animations and behaviour for catching the player.

In addition to this, there are some components like [CharacterGPS](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/Scripts/Character/NPC/CharacterGPS.cs).
This is used in Character, and is an example of programming using composition. This is something I think is nice for larger systems, as it makes more sense to split up the solution into more cohesive units. In this example, when the GoldGolem is moving, it does not need to do any calculations to find its next position, this is all processed by the GPS and returned to the GoldGolem who mindlessly walks there.

Another effect was that these Characters no longer ran on their own update cycle, but instead could be controlled by another script like [NPCHiveMind](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/Scripts/Character/NPC/NpcHiveMind.cs) which would find any characters in the scene and allow customization of how often they search/move at one location. 

# Bad Code

To start off, there were some problems in the codebase with inconsistent spacing and redundant comments, examples of this can be seen in the resolution to this ticket: https://github.com/ThomasMACHINE/PennyWise/commit/54781caf5f715e2a090941693fcc1d0f31c11bde

Ideally we would have conformed to a code style document, that could have decreased the occurences of this.

In a previous iteration we had an issue with the Dragon Roar, when the Dragon roars, a seperate coroutine is ran which will reset the Guard states to not scared. The issue was that this coroutine could be spammed by the user spamming roar, leading to unpredictable outcomes as new coroutines are ran at the same time. The solution was easy, both in a game balancing sense and prevention. We resolved this by adding a cooldown so that the Roar could not be used too often. [Commit that fixed this issue](https://github.com/ThomasMACHINE/PennyWise/commit/06ef1332888f5b23dc758d1f1cbb69e5b110b95e)

A really cool feature of c# is property wrapping, in Java the standard procedure is to generate Setters and Getters and set ur fields as private (or LomBok lol). In c# we can define the different access levels for reading and writing to the variables. You would not sabotage your code on purpose, which is why putting ur fields as public is not necessarily the end of the world. The problems arise later on, when someone that doesn't understand the code or even yourself after having forgotten what it does, start working on it again.

<img width="449" alt="image" src="https://user-images.githubusercontent.com/53544690/207029471-5d5d0f7c-ad1b-483e-9187-218c9b1ee5a5.png">

PlayerStatController is the script that tells all other scripts which Dragon is active, normally it will only change this itself. But now that is publically available, and there is no restriction on setting the variable, one could set a new Dragon by mistake and the other scripts that checks this variable would cascade down to all other scripts reading the Active Dragon.

Another way I would have liked to solve some of the variables changing is using a subscription model. Currently most scripts are actively reading the current dragon from PlayerStatController ensure that they are using the correct one, if the other scripts could trust PlayerStatController to notify them when it changes, the other scripts could run on a read once, store value basis.

