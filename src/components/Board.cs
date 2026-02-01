using Godot;
using System;

public partial class Board : Sprite2D {
    public override void _Ready() {
        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;
        
        GlobalPosition = new Vector2((vwidth / 2 - 150), vheight / 2);
    }
}
