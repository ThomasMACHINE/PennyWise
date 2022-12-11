|Description | weight |
|----|----|
|Gameplay video  | 20 | 
|Code video | 10 | 
|Good Code  | 30 |
|Bad Code| 10 |
|Development process | 15 | 
|Reflection |  20 | 

# Reflection on Group Process
My role in this project was the role of the rabbit. The rabbits role is to be the facilitator for the team, through resourcefulnes, willingness to help and communicating across the team. I participated in the last iteration of this module, and I know how hard it could be starting up in Unity. This time I had some previous experience through other projects.

I used this knowledge to quickly create prototypes of how to solve different things. At the beginning of the development process where most are beginners, simple tasks like making the character move back and forwards can be quite tedious. Using OBS to record myself working, I would regularly post updates to the team with for example: Dragon movement, evolving, picking up coins and spitting them out. I would post these clips on Streamable and then link it in our Personal Group Discord. In total I made 33 or more clips. In the clips I would show for example the inspector, how I attach the scripts and fill out the variables for the given script. The goal I had in mind while doing this was to make it easier for the group membes to pass the initial Unity hurdle.

While I am not sure how much impact this had by itself, it was still working well as I would be available to answer any questions if there were any. What I realised along the way was that this was an excellent tool for motivating the group, and I think that the group encouraging each other and developing steadily from day 1 was a large factor to our success. 

Another way I tried to facilitate was by setting a fundament for some of the components our game would need. PlayerController, PlayerStatController and Dragon script are examples of this. PlayerController would be responsible for processing input and signal to PlayerStatController. PlayerStatController would process the signals and make changes based on these, like making the Dragon move, evolve or glide. The Dragon script would be used to create instantiations of Dragons (As this game would have multiple PlayableCharacters), setting speed, jumppower, booleans on each different model.

After setting a decently sized core of functionalities, and a precedent for how these 3 scripts operate together. I started working on other scripts and the group would continue to build on this Player Package. I then realized that it might have been a little bit confusing, as I would see Input handling at the PlayerStatController instead of the PlayerController, PlayerStatController suddenly declaring enums for DragonSize which should be in the class where the Dragon is defined.

It was an interesting lesson on how your own code and design is not inherently obvious to your other teammates, in the end it went fine as the group worked well together, and would squash bugs quickly when found. But I have also reflected on what I could have done to make it more obvious, and I think the name: PlayerStatController does not even make sense, does Stat mean State? What is the relation between a PlayerController and a PlayerStatController? I think changing their names to something like: PlayerInputReader, PlayerStateController could have made it more apparent, but this is better left for the code discussion.

One thing I regret not bringing up was using a shared document for codestyling, especially for C#, microsoft provides excellent advice for having consistent looking code.

# Good Code
To start of with I like simple solutions, in the GamePauseMenu we wanted to make instructions for the player, my idea for this was that instead of making plenty of Panels with many UI element, we can instead make the images on Paint for each instruction page and rotate through them. The UI simply has arrows, the script holds a list of images.

<img width="559" alt="image" src="https://user-images.githubusercontent.com/53544690/206933297-a91984f1-7633-4516-b624-21f846516093.png">

And the thought process is simple, the User can either get the picture before (left) or the next (right) through the pictures, by clicking the arrow keys in the UI. 

<img width="676" alt="image" src="https://user-images.githubusercontent.com/53544690/206933436-be1c3eca-15a4-4b0a-a1ac-0c6fd78ac350.png">

All in all I feel like I have sprinkled a lot of nice simple solutions into the codebase like this, another example is the PlayerNotifier: [MessagePlayerScreen.cs](https://github.com/ThomasMACHINE/PennyWise/blob/417b681ceb9afd65fb808348e542fe3d49099f3b/Assets/Scripts/UI/PlayerNotification/MessagePlayerScreen.cs) The functional use of this script would be to create any other random script that contacted this script, sending along a message to be displayed to the user. Beyond setting up the UI for the text fields and icons, the script is simple and easy. Messages are queued unless they can be shown instantly, and when removed the next message in the queue will be shown. If there are none, it will then deactivate itself, awaiting a new message.

**PlayerController, PlayerStatController, Dragon**
The end result of this was very pleasing! This code now follows the vision of PlayerController checking for Input, PlayerStatController doing the processing and controlling Dragon and other things like UI and Score. And Dragon allowing the designer to customize dragons that can be controlled by the PlayerStatController.

**Good Code - Framework**

I was quite happy with my NPC "framework", this was not used heavily in the game, only being utilised for the GoldGolem. One of the problems I like to solve are: "We have to repeat so much code in order to make many different instances of very similar things."

The useage for this framework would be to seamlessly add in new Characters to the game, and skipping most of the boilerplate. There are 2 main scripts, Character and AggressiveCharacter.

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

GoldGolem shows how this can be implemented, having its own custom animations and behaviour for catching the player.

In addition to this, there are some components like [CharacterGPS](https://github.com/ThomasMACHINE/PennyWise/blob/master/Assets/Scripts/Character/NPC/CharacterGPS.cs).
This is used in Character, and is an example of programming using composition. This is something I think is nice for larger systems, as it makes more sense to split up the solution into more cohesive units. In this example, when the GoldGolem is moving, it does not need to do any calculations to find its next position, this is all processed by the GPS and returned to the GoldGolem who mindlessly walks there.


# Bad Code

To start off, there were some problems in the codebase with inconsistent spacing and redundant comments, examples of this can be seen in the resolution to this ticket: https://github.com/ThomasMACHINE/PennyWise/commit/54781caf5f715e2a090941693fcc1d0f31c11bde

Ideally we would have conformed to a code style document, that could have decreased the occurences of this.

In a previous iteration we had an issue with the Dragon Roar, when the Dragon roars, a seperate coroutine is ran which will reset the Guard states to not scared. The issue was that this coroutine could be spammed by the user spamming roar, leading to unpredictable outcomes as new coroutines are ran at the same time. The solution was easy, both in a game balancing sense and prevention. We resolved this by adding a cooldown so that the Roar could not be used too often. [Commit that fixed this issue](https://github.com/ThomasMACHINE/PennyWise/commit/06ef1332888f5b23dc758d1f1cbb69e5b110b95e)



