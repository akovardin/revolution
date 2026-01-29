using Godot;
using System;

public partial class Playground : Node2D {
    private Sprite2D board;
    private Sprite2D title;
    private Node2D dice;
    private VBoxContainer players;
    private Sprite2D player;

    override public void _Ready() {
        board = GetNode<Sprite2D>("Board");
        title = GetNode<Sprite2D>("Title");
        dice = GetNode<Node2D>("Dice");
        players = GetNode<VBoxContainer>("Players");
        player = GetNode<Sprite2D>("Player");

        var vp = GetViewport();
        var vwidth = vp.GetVisibleRect().Size.X;
        var vheight = vp.GetVisibleRect().Size.Y;


        board.GlobalPosition = new Vector2((vwidth / 2 - 150), vheight / 2);
        title.GlobalPosition = new Vector2((vwidth / 2 + 750), (vheight / 2) - 420);
        dice.GlobalPosition = new Vector2((vwidth / 2 + 750), (vheight / 2) + 420);
        players.GlobalPosition = new Vector2((vwidth / 2 + 600), (vheight / 2 - 200));
        player.GlobalPosition = new Vector2((vwidth / 2 - 850), vheight / 2 + 420);

        GD.Print("hello");
    }
}
