using Godot;
using System;
using System.Linq;
using Godot.Collections;

public partial class Playground : Node2D {
    private Dice dice;
    // private Player player;
    private Board board;
    private List list;
    private Add add;
    private Array<Player> players = new Array<Player>();
    private int currentPlayer = 0;

    override public void _Ready() {
        dice = GetNode<Dice>("Dice");
        // player = GetNode<Player>("Player");
        board = GetNode<Board>("Board");

        list = GetNode<List>("List");
        add = GetNode<Add>("Add");

        dice.Connect(Dice.SignalName.DiceDroped, new Callable(this, MethodName.OnDiceDropedEvent));
        add.Connect(Add.SignalName.Append, new Callable(this, MethodName.OnAddPlayerEvent));
    }

    public void OnDiceDropedEvent(int n) {
        // player.Go(board.Points[player.Cell + (n-1)].point, n);

        players[currentPlayer].Go(board.Points[players[currentPlayer].Cell + (n-1)].point, n);
        currentPlayer++; // этот счетчик должен ходить по кругу
        // проверяем есть ли точка интереса в этом месте
    }

    public void OnAddPlayerEvent() {
        // проверяем есть ли точка интереса в новом месте

        GD.Print("AddPlayerEvent");

        // playerList.Add(player); // добавляем пользователя в список
        // спавним нового игрока рядом с доской

        var scene = GD.Load<PackedScene>("res://src/components/player/player.tscn");
        var instance = scene.Instantiate();

        AddChild(instance);

        // добавляем игрока в массив чтоб чтоб игрок ходил
        players.Add((Player)instance);
    }
}
