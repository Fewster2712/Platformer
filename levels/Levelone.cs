using Godot;
using System;

public class Levelone : Node
{
   public override void _Process(float delta)
   {


   }

   public Vector2 Playerpo()
   {
     var player = (Node2D)GetNode("Player");
     var playerpos = player.Position;
     return playerpos;
   }
    public Vector2 Enemypo()
   {
     var enemy = (Node2D)GetNode("Enemy");
     var enemypos = enemy.Position;
     return enemypos;
   }
}
