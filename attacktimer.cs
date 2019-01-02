using Godot;
using System;

public class attacktimer : Timer
{
    private void _on_Timer_timeout()
    {
        var sprite = GetNode<Sprite>("Playersprite");
        sprite.Visible = !sprite.Visible;
    }
}
