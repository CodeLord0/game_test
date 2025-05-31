using Godot;
using System;

public class Coin : Area2D
{
    // Declare member variables here. Examples:
    // private int a = 2;
    // private string b = "text";

    // Called when the node enters the scene tree for the first time.
    
    public override void _Ready()
    {
        //this.Connect("pickup", this, nameof(OnPlayerPickup));

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(float delta)
    {


    }

    void pickup()
        {
            QueueFree();
        }   
}
