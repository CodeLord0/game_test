using Godot;
using System;


public class Main : Node
{

    [Export]
    PackedScene Coin;
    
    [Export]
    int Playtime;
    Vector2 screensize;
    int Time_left;
    bool Playing = false;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GD.Randomize();
        
        GetNode<Area2D>("Player").Hide();
        
        

    }

    //  // Called every frame. 'delta' is the elapsed time since the previous frame.
    //  public override void _Process(float delta)
    //  {
    //      
    //  }
}
