using Godot;
using System;

public partial class Playground : Node2D {
    private Dice dice;
    private Player player;
    private Board board;

    override public void _Ready() {
        dice = GetNode<Dice>("Dice");
        player = GetNode<Player>("Player");
        board = GetNode<Board>("Board");

        dice.Connect(Dice.SignalName.DiceDroped, new Callable(this, MethodName.OnDiceDropedEvent));
    }

    public void OnDiceDropedEvent(int n) {
        player.Go(board.Points[player.Cell + (n-1)].point, n);

        // проверяем есть ли точка интереса в этом месте
    }
}
