using Godot;
using System;

public class PlayerBody : KinematicBody2D
{
    const int speed = 10;
    Vector2 floor = new Vector2(0,-1);
    const int gravity = 15;
    const int maxspeed = 60;
    const int minspeed = 10;
    const int jumppower = -250;
    bool on_ground = true;
    Vector2 velocity;
    
    

    public override void _PhysicsProcess(float delta)
    {
     
        if(Input.IsKeyPressed((int) KeyList.A))
        {
          
          velocity.x -= speed;
            if(velocity.x > maxspeed*-1)
            {
                velocity.x = maxspeed*-1;
            }
        }   
          if(Input.IsKeyPressed((int) KeyList.D))
        {
            velocity.x += speed;
            if (velocity.x > maxspeed)
            {
                velocity.x = maxspeed;
            }

        }
        if(!Input.IsKeyPressed((int) KeyList.D) && !Input.IsKeyPressed((int) KeyList.A))
        {
            velocity.x = 0;
        }
        
          if(Input.IsKeyPressed((int) KeyList.W))
        {
            if (on_ground = true)
            {
            velocity.y = jumppower;
            }
        }
        
        velocity.y += gravity;
        velocity = MoveAndSlide(velocity, floor);
        
    }

//    public override void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//        // Update game logic here.
//        
//    }
}
