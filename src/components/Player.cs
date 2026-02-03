using Godot;
using System;
using System.Reflection.Metadata;

public partial class Player : CharacterBody2D {
    private Vector2 target; 
    private Timer timer;
    public int Cell;

    public override void _Ready() {
        // timer = new Timer();
        // AddChild(timer);
        // timer.WaitTime = 3;
        // timer.Timeout += this.Go;
        // timer.Start();

        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;

        // стартовая позиция
        GlobalPosition = new Vector2((vwidth / 2 - 950), vheight / 2 + 460);
    }

    public override void _PhysicsProcess(double delta) {
        // https://stackoverflow.com/questions/77142736/how-to-move-and-slide-to-a-target-location-and-stop
        // https://docs.godotengine.org/en/stable/tutorials/physics/using_character_body_2d.html
        var direction = GlobalTransform.Origin.DirectionTo(target);
        var distance = GlobalTransform.Origin.DistanceTo(target);

        var speed = (distance / delta) * 0.05;
        Velocity = direction * (float) speed;

        if (target != Vector2.Zero) {
            MoveAndSlide();
        }
    }

    public void Go(Vector2 point, int n) {
        target = point;
        Cell += n;
    }
}
