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
        board = GetNode<Board>("Board");

        list = GetNode<List>("List");
        add = GetNode<Add>("Add");

        dice.Connect(Dice.SignalName.DiceDroped, new Callable(this, MethodName.OnDiceDropedEvent));
        add.Connect(Add.SignalName.Append, new Callable(this, MethodName.OnAddPlayerEvent));
    }

    public void OnDiceDropedEvent(int n) {
        // player.Go(board.Points[player.Cell + (n-1)].point, n);
        GD.Print(currentPlayer);
        GD.Print(players[currentPlayer].cell + (n-1));

        players[currentPlayer].Go(board.Points[players[currentPlayer].cell + (n-1)].point, n);
        currentPlayer++; // этот счетчик должен ходить по кругу
        if (currentPlayer >= players.Count) {
            currentPlayer = 0;
        }
    }

    public void OnAddPlayerEvent() {
        GD.Print("AddPlayerEvent");

        // playerList.Add(player); // добавляем пользователя в список
        // спавним нового игрока рядом с доской

        // выбор цвета по порядку
        var color = "red";

        var playerScene = GD.Load<PackedScene>("res://src/components/player/player.tscn");
        var player = (Player)playerScene.Instantiate();
        player.color = color;

        // добавляем рядом с доской
        AddChild(player);

        // добавляем игрока в массив чтоб чтоб игрок ходил
        players.Add(player);

        var itemScene = GD.Load<PackedScene>("res://src/components/list/item/item.tscn");
        var item = (Item)itemScene.Instantiate();
        item.name = "Player123"; // имя генерируем случайно
        item.color = color;

        list.AddChild(item);
    }
}
