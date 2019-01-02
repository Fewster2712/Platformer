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
    const int rangex = 45;
    const int rangey = 15;
    bool onFloor = false;
    Vector2 velocity;
    bool attackcooldown = false;
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
        if(Input.IsKeyPressed((int) KeyList.F) && attackcooldown == false)
        {
            var enemy= GetParent().GetParent().GetNode<Node2D>("Enemy").GetNode<KinematicBody2D>("Enemybody");
            var dist = this.GetGlobalPosition().DistanceTo(enemy.GetGlobalPosition());
            var dir = GetNode<AnimatedSprite>("Playersprite").FlipH;  
            if(enemy.GlobalPosition.x - this.GlobalPosition.x <= rangex && enemy.GlobalPosition.y - this.GlobalPosition.y <= rangey)
            {
                if(dir == false && enemy.GlobalPosition.x > this.GlobalPosition.x)
                {
                    enemy.GetNode<Sprite>("Enemysprite").Visible = !enemy.GetNode<Sprite>("Enemysprite").Visible;
                }
                else if (dir == true && enemy.GlobalPosition.x < this.GlobalPosition.x)
                {
                    enemy.GetNode<Sprite>("Enemysprite").Visible = !enemy.GetNode<Sprite>("Enemysprite").Visible;
                }
            }
            //attackcooldown = true;
        }
        
        
    }

}
