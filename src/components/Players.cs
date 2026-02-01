using Godot;
using System;

public partial class Players : VBoxContainer {
    public override void _Ready() {
        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;
        
        GlobalPosition = new Vector2((vwidth / 2 + 650), (vheight / 2 - 200));
    }
}
