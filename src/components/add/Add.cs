using Godot;
using System;

public partial class Add : Button {

    [Signal]
    public delegate void AppendEventHandler();

    override public void _Ready() {
        Pressed += OnPressed;
    }

    private void OnPressed() {
        GD.Print("on pressed");

        EmitSignal(SignalName.Append);
    }
}
