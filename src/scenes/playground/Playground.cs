using Godot;
using System;
using System.Linq;
using Godot.Collections;

public partial class Playground : Node2D {
    private Dice dice;
    private Board board;
    private Dialog dialog;
    private List list;
    private Add add;
    private Array<Player> players = new Array<Player>();
    private int currentPlayer = 0;

    private Array<String> names = ["Артем", "Николай", "Светлана", "Екатерина"];
    private Array<String> colors = ["red", "green", "blue", "orange"];

    private Random random = new Random();

    override public void _Ready() {
        dice = GetNode<Dice>("Dice");
        board = GetNode<Board>("Board");
        dialog = GetNode<Dialog>("Dialog");

        list = GetNode<List>("List");
        add = GetNode<Add>("Add");

        dice.Connect(Dice.SignalName.DiceDroped, new Callable(this, MethodName.OnDiceDropedEvent));
        add.Connect(Add.SignalName.Append, new Callable(this, MethodName.OnAddPlayerEvent));
    }

    public void OnDiceDropedEvent(int n) {
        // на какую клетку нужно подвинуть игрока
        var point = players[currentPlayer].cell + (n-1);

        // перемещаем игрока на нужную точку
        players[currentPlayer].Go(board.Points[point].point, n);

        // тут обрабатываем точку интереса
        var interest = board.Interests[point]; 
        if (interest != null) {
            GD.Print("Interest: " + interest.description);
            // показать нужно с задержкой
            dialog.Show();
        }

        // проверяем заверщение игры


        // если игра не закончилась, то передаем ход другому игроку
        currentPlayer++; // этот счетчик должен ходить по кругу
        if (currentPlayer >= players.Count) {
            currentPlayer = 0;
        }
    }

    public void OnAddPlayerEvent() {
        GD.Print("AddPlayerEvent");

        // максимальное кол-во игроков
        if (players.Count >= 4) {
            return;
        }

        // выбор цвета по порядку
        var color = colors[players.Count];
        var name = names[players.Count];

        var playerScene = GD.Load<PackedScene>("res://src/components/player/player.tscn");
        var player = (Player)playerScene.Instantiate();
        player.color = color;

        // добавляем рядом с доской
        AddChild(player);

        // добавляем игрока в массив чтоб чтоб игрок ходил
        players.Add(player);

        var itemScene = GD.Load<PackedScene>("res://src/components/list/item/item.tscn");
        var item = (Item)itemScene.Instantiate();
        item.name = name; // имя генерируем случайно
        item.color = color;

        list.AddChild(item);
    }
}
