using Godot;
using System;

public partial class Dice : Node2D {
    private AnimatedSprite2D animation;

    [Signal]
    public delegate void DiceDropedEventHandler(int n);

    public override void _Ready() {
        var vp = GetViewportRect();
        var vwidth = vp.Size.X;
        var vheight = vp.Size.Y;
        
        GlobalPosition = new Vector2((vwidth / 2 + 800), (vheight / 2) + 420);

        animation = GetNode<AnimatedSprite2D>("Animation");
        animation.AnimationFinished +=  this.Drop;
    }

    public override void _UnhandledInput(InputEvent @event) {
        if ((@event is InputEventMouseButton eventClick && eventClick.Pressed)
            || (@event is InputEventScreenTouch eventTouch && eventTouch.Pressed)) {
            GD.Print(@event);
            Animate();
        }
    }

    public void Animate() {
        animation.Frame = 0;
        animation.Play();
    }

    public void Drop() {
        var n = GD.RandRange(1, 2);
        animation.Frame = n-1; 

        GD.Print(n);

        EmitSignal(SignalName.DiceDroped, n);
    }
}
