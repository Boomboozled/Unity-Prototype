# Unity-Prototype

## About my experience with Unity
I spent around 3 months learning Unity and familiarizing myself with the engine. After thinking more towards my future, I switched to Unreal Engine and have since then stopped working in Unity. This is because the games industry largely uses C++, and generally requires C++ game projects to be showcased when applying.

I decided to put what I studied from YouTube and tutorials into some practice by making a project in about 4 days that prototyped some game mechanics using PRIMITIVE objects to represent things.


## About the project itself

The project is a prototype, I wouldn't call it a "game". There isn't a main menu, nor win/lose condition, save states, etc. Other Unity projects I made in my learning do implement these things, but this is focused solely on mechanics.

## Player

The player can hold the "RMB" which then enables turning for the player. This was done only for purposes of working in the editor.

The player can hurl three projectiles at enemies by pressing "LMB", each projectile will home towards the enemy closest to them. Enemies who are hit with the projectile will bounce up off the ground for some visual feedback. - Unless they die instantly from losing all their health

The player can pickup a green powerup which will cause them to get bigger and allow them to  "eat" enemies after it has been activated.



## Enemies

There are four types of enemies with different health, fire rates, speeds, fields of vision, and appearances that will randomly spawn, with the number increasing after each wave.
The enemies move without NavMeshes. They are able to detect the player using the Dot Product. in the scene I included a "vision visualization cone" to see the field of vision of any enemy selected by the user in the editor. Also there is an option on each selected enemy to toggle "Show Player Tracking" which draws a line from the player to the enemy.

![image](https://user-images.githubusercontent.com/103400445/198081116-7cb93945-bcd5-4ee3-bc57-cb76e1d552fe.png)

Enemies will run away if you get too close, chase if you're too far, and are able to be outranged and stop fighting if you walk out of their detection radius.


## Fun Facts

- I took an introductory Linear Algebra course and used this project to do a presentation of how  the Linear Algebra discussed in class can directly apply to game development by talking about Vector Addition, Vector Subtraction, Dot Product, Distance, and more.

- The homing projectiles were inspired somewhat by the Tanks from Left4Dead, and the Rock Sling in Elden Ring
