# Unity-Prototype

## About
I spent around 3 months learning Unity and familiarizing myself with the engine. After thinking more towards the future, I switched to Unreal Engine and have since then stopped working in Unity. This is because the games industry largely uses C++, and generally  requires C++ game projects to be showcased.'


This is a Unity Project I made that prototyped some game mechanics using PRIMITIVE objects to represent things:



## Enemies

There are four types of enemies with different health, fire rates, speeds, and appearances that will randomly spawn, with the number increasing after each wave.
The enemies move without NavMeshes. They are able to detect the player using the Dot Product, in the scene I included a "visualization cone" to see the vision cone of any enemy select in the editor. Also there is an option on each enemy to toggle an option to "Show Player Tracking" which draws a line from the player to the enemy.
![image](https://user-images.githubusercontent.com/103400445/198081116-7cb93945-bcd5-4ee3-bc57-cb76e1d552fe.png)

Enemies will run away if you get too close, chase if you're too far, and are able to be outranged and walk out of their detection radius.

## 

The player can hold the "RMB" which then enables turning for the player. This was done only for purposes of working in the editor.

The player can hurl three projectiles at enemies by pressing "LMB", each projectile will home towards the enemy closest to them. Enemies who are hit with the projectile will bounce up off the ground for some visual feedback.

The player can pickup a green powerup and "eat" enemies after it has been activated.


