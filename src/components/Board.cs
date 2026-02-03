using Godot;
using System;

public class Point {
    public Vector2 point;
    public int Chips;

    public Point(Vector2 point) {
        this.point = point;
    }
}

public partial class Board : Sprite2D {
    public Point[] Points = new Point[85];
    private Dice dice;
    private Player player;

    public override void _Ready() {
        dice = GetNode<Dice>("../Dice");
        player = GetNode<Player>("../Player");


        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;



        Points[0] = new Point(new Vector2((vwidth / 2 - 950) + 135, vheight / 2 + 460));
        Points[1] = new Point(new Vector2((vwidth / 2 - 950) + 270, vheight / 2 + 460));
        Points[2] = new Point(new Vector2((vwidth / 2 - 950) + 405, vheight / 2 + 460));
        Points[3] = new Point(new Vector2((vwidth / 2 - 950) + 540, vheight / 2 + 460));
        Points[4] = new Point(new Vector2((vwidth / 2 - 950) + 675, vheight / 2 + 460));
        Points[5] = new Point(new Vector2((vwidth / 2 - 950) + 810, vheight / 2 + 460));
        
        
        GlobalPosition = new Vector2((vwidth / 2 - 150), vheight / 2);
    }
}
