using Godot;
using System;

public partial class AddPlayer : Button {

    [Signal]
    public delegate void AddEventHandler();

    override public void _Ready() {
        Pressed += OnPressed;
    }

    private void OnPressed() {
        GD.Print("on pressed");

        EmitSignal(SignalName.Add);
    }
}
