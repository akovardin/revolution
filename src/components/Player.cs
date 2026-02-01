using Godot;
using System;
using System.Reflection.Metadata;

public partial class Player : CharacterBody2D {
    private Vector2 target; 
    private Timer timer;

    public override void _Ready() {
        timer = new Timer();
        AddChild(timer);
        timer.WaitTime = 3;
        timer.Timeout += this.Go;
        timer.Start();

        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;
        
        GlobalPosition = new Vector2((vwidth / 2 - 950), vheight / 2 + 460);

        // subscribe to dice channel
        // enable move
    }

    public override void _PhysicsProcess(double delta) {
        // https://stackoverflow.com/questions/77142736/how-to-move-and-slide-to-a-target-location-and-stop
        var direction = GlobalTransform.Origin.DirectionTo(target);
        var distance = GlobalTransform.Origin.DistanceTo(target);

        var speed = (distance / delta) * 0.05;
        Velocity = direction * (float) speed;

        MoveAndSlide();

        // нужно проверять закончился ли шаг
    }

    public void Go() {
        // Velocity = Vector2.Right * 100;

        // var direction = GlobalTransform.Origin.DirectionTo(target);
        // var distance = GlobalTransform.Origin.DistanceTo(target);
        // var speed = (distance / delta);
        // Velocity = direction * max_speed;

        target = new Vector2(1000, 1000);
    }
}
