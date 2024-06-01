using Godot;
using System;

public partial class GameManager : Node2D
{
	player Player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player = GetNode<player>("Player");
		Player.WheelInputState.PlayerWheelUp += () => GD.Print("Player pressing up");
		Player.WheelInputState.PlayerWheelDown += () => GD.Print("Player pressing down");
		Player.WheelInputState.PlayerWheelLeft += () => GD.Print("Player pressing left");
		Player.WheelInputState.PlayerWheelRight += () => GD.Print("Player pressing right");
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
