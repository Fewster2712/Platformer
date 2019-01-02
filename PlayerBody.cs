using Godot;
using System;

public class PlayerBody : KinematicBody2D
{
    //Movement
    const int speed = 10;
    Vector2 floor = new Vector2(0,-1);
    const int gravity = 15;
    const int maxspeed = 140;
    const int minspeed = 10;
    const int jumppower = -350;
    const int deacl = 5;
    const int range = 25;
    bool onFloor = false;
    Vector2 velocity;
    //Movement ended
    

    public override void _PhysicsProcess(float delta)
    {
        //Movement
        var anim = (AnimatedSprite)GetNode("Playersprite");
        if (Input.IsKeyPressed((int) KeyList.A))
        {
          
          velocity.x -= speed;

            if (velocity.x < maxspeed*-1)
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
            if(velocity.x > 0)
            {
                velocity.x -= deacl;
            }
            else if(velocity.x < 0)
            {
                velocity.x += deacl;
            }
            anim.Play("idle");
        }
        
          if(Input.IsKeyPressed((int) KeyList.W))
        {
            if(onFloor == true)
            {
                anim.Play("jump");
            velocity.y = jumppower;
            }
        }
        else if(velocity.y > 0)
        {
            anim.Play("fall");
        }
        if(velocity.x > 0)
        {
            anim.Play("run");
            anim.FlipH = false;
        }
        else if(velocity.x < 0)
        {
            anim.Play("run");
            anim.FlipH = true;
        }
        velocity.y += gravity;
        velocity = MoveAndSlide(velocity, floor);
        if(this.IsOnFloor() == true)
        {
            onFloor = true;
        }
        else 
        {
        onFloor = false;
        }
        //Movement ended

        //Attack
        var root = GetTree().GetRoot();
        var enemy = (Node2D)root.GetNode("Enemy");
        enemy.
        
    }

//    public o)verride void _Process(float delta)
//    {
//        // Called every frame. Delta is time since last frame.
//            // Update game logic here.
//        
//    }
}
