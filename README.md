# Contribution
For the game project, ANGRi, available with this link. https://play.google.com/store/apps/details?id=com.DumbDumberDumbestCuteAndCuter.ANGRi&hl=en_US&gl=US 

For this project, I provided main coding support with the majority of the coding backend handled by me. 
In this project, I made use of two Unity asset packs and built off of them.

Uni Bullet Hell: https://assetstore.unity.com/packages/tools/integration/uni-bullet-hell-19088#description

Simple Mobile Joystick: https://github.com/ashwaniarya/Unity3D-Simple-Mobile-Joystick

While these two did much work for the project, they required heavy modification for usage in the final product. To start, I will go into each and how I modified them

![](https://github.com/CalebStudent/Caleb-McCartney-ANGRi-Work/blob/main/exOfJoy.PNG)

While they joysticks were designed for the twinstick gameplay we had in mind, to work with our character, the controls had to be rewritten entirely.


![](https://github.com/CalebStudent/Caleb-McCartney-ANGRi-Work/blob/main/2022-05-09%2021-48-50.gif)

The joystick't values were repurposed to simply move and rotate a character with the addition of rotating the character making them shoot bullets, the method of attack in the game. Similarly, Uni Bullet Hell is used so that the boss can attack the player. The bullet patterns are highly customizable and allow for nearly infinite patterns. This is where the the base is built.

![](https://github.com/CalebStudent/Caleb-McCartney-ANGRi-Work/blob/main/block.PNG)

the bullets are coded entirely by me. The player's bullet is programmed to be created and directed by the player. The player script sets their bullet's speed, direction, and damgage. This damage is dealt to the enemy if it connects and destroys enemy bullets should it touch one. This mechanic was based of the player's projectiles in the game FURi, an inspiration for ANGRi. This was to give the player a method of being agressive with their defense, even being able to land hits if they're agressive and accurate enough.

Beyond this, I created all three boss fights seen in-game alongside the timer that records the player's best time.

![](https://github.com/CalebStudent/Caleb-McCartney-ANGRi-Work/blob/main/time.PNG) 

The times are recorded individually for each boss and are displayed on the main menu beneath their respective level, tempting players to go back in and to set a new best time. Alongside this is a progression blocker. The player starts with the first level and must beat it to unlock the second level and beat the second to unlock the third.

Looking back at the project, I wish I could've toyed with more unusual mechanics on all fronts. Make the player move in a special way for a level, use different layouts like restricting the player to the bottom of the screen, make the boss move and shoot alongside other attacks that involved them physically. However, development time and feasibility of implementing prevented these areas from being explored fully.
