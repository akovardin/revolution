using Godot;
using System;

public partial class Item : MarginContainer {
    [Export]
    public String name;
    [Export]
    public String color;

    public override void _Ready() {
        GetNode<Label>("Container/Label").Text = name;
        GetNode<Sprite2D>("Container/Player").Modulate = new Color("#f14343");
    }
}
