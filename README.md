# HuntTheWumpus2d
HuntTheWumpus is a text based game. This is my 2D implementation of it.

Instructions
------
To play the game either click on HuntTheWumpus2d.exe or make a shortcut of it to wherever you would like, it needs to remain in the folder it is located in for asset paths.

Controls
-----
| Key                | Effect                                               |
|:------------------:|:----------------------------------------------------:|
|   Up Arrow or W    | Move Character Up                                    |
|   Left Arrow or A  | Move Character Left                                  | 
|   Down Arrow or S  | Move Character Down                                  |
|   Right Arrow or D | Move Character Right                                 |
|   Backspace        | Exit game from any screen                            |
|   T                | Enter Shooting Mode                                  |
|   C (Hold)         | Shows locations of all hazzards     (Cheat Mode)     |
|   Z                | Instantly kill character, showing wumpus kill screen |

Gameplay
-----
Gameplay is fairly simple. You have the ability to move around the screen. The outer walls of the map have collision detection as to stop movement outside the map. 
###Goal
- The goal of the game is to defeat the wumpus and escape with your life. To do this you must venture through the cave and avoid other hazzards, namely Superbats and Bottomless pits.
###Hazzards
- The game has 3 types of hazzards: Superbats, Bottomless Pits, and the Wumpus. 
  * When you enter a room with Superbats your are instantly teleported to a new random room that doesn't contain a hazzard.
  * When you enter a room with a Bottomless pit you are instantly killed and prompted to exit or start a new game.
  * When you enter a room with the Wumpus you wake him at first, then if you encounter him again you are killed.
  
###Shooting
- While not implemented, when you press T you enter shooting mode. This lets you first select the number of rooms and then the rooms you wish to shoot through attempting to kill the Wumpus. 

Not Implemented Yet | Future Plans
-----
- Currently shooting is not implemented, I could not figure out the best way of taking user input and ran out of time in the current timeframe.
 - Shooting framework is in the code, but it is not implemented.

