using Godot;
using System;

public class Enemybody : KinematicBody2D
{
    int health = 5;

    public override void _Ready()
    {
        // Called every time the node is added to the scene.
        // Initialization here
        
    }

    public override void _Process(float delta)
    {
        var sprite = GetNode<Sprite>("Enemysprite");
       if(health <= 0)
       {
           sprite.Visible = false;
       } 
    }
}
