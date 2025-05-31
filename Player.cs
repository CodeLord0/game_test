using Godot;
using System;
using System.Drawing.Text;
using System.Linq.Expressions;

public class Player : Area2D
{	
	// variables are declared at this section
	[Export] // makes speed visible in the editor
	int Speed; //declares speed for the player

	[Signal]
	
	public delegate void hurt();

	[Signal]
	public delegate void pickup();
	
	Vector2 Velocity; // declares the 
	//Vector2 ScreenSize; // variable containing the width of the game window
	Vector2 pos; // position of the player
	
	AnimatedSprite anim; // holds the current animation of the player
	Vector2 ScreenSize ;
	
		// runs once at the start of the game
	public override void _Ready()
	{
		ScreenSize.x = 480;
		ScreenSize.y = 720;
		pos = Position; // assigns the Position of th
		 // holds the width and height of the screen
		anim = GetNode<AnimatedSprite>("AnimatedSprite"); // gets the AnimatedSprite node
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(float delta)
	{
	
		
		Get_input(); // calls the Getinput() method

		// keeps the player in the window
		pos.x = Mathf.Clamp(pos.x, 0, ScreenSize.x); // keeps the player from being less than the left side of the game window and the right side of the game window
		pos.y = Mathf.Clamp(pos.y, 0, ScreenSize.y); // keeps the player from going beyond the top side of the game window and the right of the game window


		pos.x += Velocity.x * delta; // sets the x component of the player to the positional reference of the plaeyr
		pos.y += Velocity.y * delta; // sets the y component of the player to the position refernce of the player

		Position = pos; // sets the real position of the player to positional reference of the player
		
		
		// checks if the player has moved
		if (Velocity.Length() > 0)
		{

			anim.Animation = "run"; // sets the animation of the player to the running animation
			anim.FlipH = Velocity.x < 0; //if the x component of the player 

		}
		else
		{
			anim.Animation = "idle"; // play the idle animation
		}

		Velocity = new Vector2(); // reset velocity to 0
	}

	// get the player input
	void Get_input()
	{

		if (Input.IsActionPressed("ui_left"))
		{
			Velocity.x -= 1;

		}
		if (Input.IsActionPressed("ui_right"))
		{
			Velocity.x += 1;

		}
		if (Input.IsActionPressed("ui_up"))
		{
			Velocity.y -= 1;

		}
		if (Input.IsActionPressed("ui_down"))
		{
			Velocity.y += 1;

		}
		if (Velocity.Length() > 0) { // if the player is moving
			Velocity = Velocity.Normalized() * Speed; // normalize the vector
		}
	 }

	void Start(Vector2 pos)
	{
		SetProcess(true);
		Position = pos;
		anim.Animation = "run";
	}

	void Die()
	{
		anim.Animation = "hurt";
		SetProcess(false);
	}

	void _on_Player_area_entered(Area2D area)
	{
		GD.Print("colission");
		if (area.IsInGroup("coins"))
		{

			EmitSignal(nameof(pickup));
		}

		if (area.IsInGroup("obstacles"))
		{
			EmitSignal(nameof(hurt));
			Die();

	 	}
			

				
	 }
	
		

} 

