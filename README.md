**Edit a file, create a new file, and clone from Bitbucket in under 2 minutes**

When you're done, you can delete the content in this README and update the file with details for others getting started with your repository.

*We recommend that you open this README in another tab as you perform the tasks below. You can [watch our video](https://youtu.be/0ocf7u76WSo) for a full demo of all the steps in this tutorial. Open the video in a new tab to avoid leaving Bitbucket.*

---

## Exo 1
1. You can drag and drop game objects player onto the main movement controller to create a waypoint system
2. Any game objects you place on the player script will follow the system
3. The first waypoint you plug in is the first location the player will go through.
4. You can arrange the order of the waypoint system
5. You can delete a way point
6. The path is materialized by lines between each waypoint
7. The path is updated automatically as you arrange the order of the waypoint system
8. The player is a human character
9. The player follows the way point path just like a regular object
10. The player has animation: idle, walk, run
11. The player uses a navmesh system to move
12. Created a nice environment and add fog 



## Exo2
1. Can select 2 colors in a custom window name ColorToolWindow
2. First color is for painting and second color is for erasing
3. The display is a n * m grid of colors
4. Each row is represented by a box with a random color just like a pixel
5. When you customize the number of rows and columns, the grid will be updated
6. You can fill each boxes with the same color by the Fill All button. The paint color is the one that
will be used
7. You can drag and drop any game objects to the output renderer
8. When you click save to object, the texture represented by the colored grid will be applied to the object you
drag and drop in.

---

## Exo 3
1. Created a casse brique in the inspector
2. The number of bricks typed in the field is the number of bricks that will be displayed 
on the inspector
3. You use the slider Move to move the brick
4. The slider values are between 0 and 1 and are proportional to the inspector width

## Exo 3 FACULTATIF
1. Created a custom property drawer of a float named Explosion force
2. The initial force is represented by the y value of an AnimCurve.
3. The explosion will occur on the start.
4. A value of 0 will deactivate the explosion, the more the value the more force will be generated to push objects away from the centre of the explosion.
5. A negative value will pull objects toward the center like a magnet.


## Exo 4
1. Created an inspector that can spawn an enemy type based on the selection in a drop down list
2. When you click the button create, the selected enemy will be spawn on the scene
3. After spawning an enemy, the button create will change directly to Swap
4. The swap button will swap the last enemy you spawned by the current selected enemy type on the list.
5. When you click in the inspector but not the button, the swap button will change to create button so that
you can spawn a new type of enemy again
6. Created the exact same features but in an editor window: Enemy > Create enemy...

## Exo 5
1. You can create a magic card by right click > create > magic card > create
2. Created a magic card creator window
3. You can set up: card name, description, mana cost, card background, the image to display on the card
and the card type (the 5 elements)
4. Anything you typed in will be displayed on the card preview are
7. When you click on create new card, a new scriptable objects will be created based on the informations you
provided in and will be added to the right side
8. The right side displays all the existing scriptable objects you have. When you click on each of them, their informations will be automatically displayed on the left side

## Exo 6
1. Create a platform with many players (sphere game objects)
2. Their colors will be randomized on the start of the game
3. They will have random speed and random direction
4. Their rigid body will be applied a force
5. When you click save, all players data will be saved onto a json file
6. When you click load, all players data will be retrieved so the players
will be back to their original state at the time of saving
7. The data retrieved are their name, position, rigid body's velocity and colors

## Exo 7
1. DELEGATE: Create an object player and an object player follower. As you move the player, the follower is following you using a delegate event system
2. You can move / rotate the player using the arrow directions of the keyboard
3. STACK LIFO: The player have four free slots that can carry medicine object. When you go the medicine location, it will be placed on a free slot on your left.
When you press T, the last medicine you have grabbed is the first one to be thrown away from you (LIFO: Last In First Out)
4. You can't grab more than four medicines
5. Pickup and carry is using an observer design pattern: the player is aware of the existence of the medicine item (pickup), the medicine is aware of the player (throw)

## Exo 8
1. Added a method to calculate permutation

## Exo9 
1. Modeled a basic stylized car in blender
2. Simulated the front and rear lights
3. Added an hdr image to simulate reflections on the car paint

## Exo10 
1. Modeled a cube character in blender
2. Added multiple light sources to the scene
3. Added some foliages

## Exo11
1. Modeled a kitchen in blender
2. Added texture to the table, chairs, carrelage
3. Added multiple light sources
3. Added hdr image to simulate reflections 
 
## Exo12 
1. Modeled a robot character following blueprint
2. Skinned and rigged the character

## Exo13 
1. Created a run animation for the robot character following animation blueprint
2. Cycled the animation
3. Added multiple light sources
4. Exported the animation to unity

## Exo14 
1. Created a FPS game
2. The player will be inside an alley where there's some mysterious target
3. The player shoot bullets using the pool factory pattern
4. 5 bullets will be placed on the inactive list at the beginning of the game. When the player shots one, it will be placed on the active list.
6. Gun sound will be played on shot
5. After all bullets are active ie player used all his available bullets, the gun will turn red and empty gun sound will be played instead.
6. A bullet becomes active if it hits a target or the ground or is invisible from the camera
7. If the number of active bullet >= 1, the gun will turn to its normal color and the player can shoot again
8. The number of availaible bullets is displayed on the top left hand side of the screen. It used an observer listener pattern.



You’ll start by editing this README file to learn how to edit a file in Bitbucket.


Next, you’ll add a new file to this repository.

1. Click the **New file** button at the top of the **Source** page.
2. Give the file a filename of **contributors.txt**.
3. Enter your name in the empty file space.
4. Click **Commit** and then **Commit** again in the dialog.
5. Go back to the **Source** page.

Before you move on, go ahead and explore the repository. You've already seen the **Source** page, but check out the **Commits**, **Branches**, and **Settings** pages.

---

## Clone a repository

Use these steps to clone from SourceTree, our client for using the repository command-line free. Cloning allows you to work on your files locally. If you don't yet have SourceTree, [download and install first](https://www.sourcetreeapp.com/). If you prefer to clone from the command line, see [Clone a repository](https://confluence.atlassian.com/x/4whODQ).

1. You’ll see the clone button under the **Source** heading. Click that button.
2. Now click **Check out in SourceTree**. You may need to create a SourceTree account or log in.
3. When you see the **Clone New** dialog in SourceTree, update the destination path and name if you’d like to and then click **Clone**.
4. Open the directory you just created to see your repository’s files.

Now that you're more familiar with your Bitbucket repository, go ahead and add a new file locally. You can [push your change back to Bitbucket with SourceTree](https://confluence.atlassian.com/x/iqyBMg), or you can [add, commit,](https://confluence.atlassian.com/x/8QhODQ) and [push from the command line](https://confluence.atlassian.com/x/NQ0zDQ).
