# Assignment_Girish
INTRODUCTION:


This is a 3D snake game built using unity and written in C#. The game starts with a start screen which displays the Title and new game button and the HighScore of the Game. The snake grows by a length of 1 every time it eats a food on the map. 1 food spawns on the map at the start of the game and every time the snake eats the food - a new food piece gets spawned somewhere else on the map. The game is over when the snake collides with the edge of the map or itself. You and you only may complete this specification in any way or solution you please.

DESIGN:

The game is designed in Unity. The GameObjects used are : 1. quad as the plane, 2. Sphere as the snake and food, 3. Cube as the border, 4. text for the text.

Total 4 scripts are used in the game in-order to navigate and play through the game.

gamecontroller.cs, mainmenu.cs, snake.cs, and gameover.cs

Functions used: 

1.  Movement() function for the movement of the snake using transform rotation. And incrementing the length of the snake using the sphere as llnked list.

2. ComChange() function for the changing the direction of the snake using the arrow keys.

3. foodfunction() to generate the food by 1 i.e., spawning the food if the snake collides with the food.


void Foodfunction()
	{
		int xPos = Random.Range(-xBound, xBound);
		int yPos = Random.Range(-yBound, yBound);
		int zPos = Random.Range(-zBound, zBound);
		
		currfood = (GameObject)Instantiate(foodPrefab, new Vector3(xPos, yPos, zPos),transform.rotation);
		StartCoroutine(CheckRender(currfood));
	}
	
4. hit() function to check if the snake is colliding with food or itself or the borders.

HOW TO PLAY THE GAME:

The game starts with the main menu screen, Click on New game. Now, Navigate the snake using the Arrow keys. Hit the food and then the snake increments by 1. As the game progresses the snake grows longer and try not hitting the borders and the snake itself. If you hit the borders and snake itself the game gets over.
