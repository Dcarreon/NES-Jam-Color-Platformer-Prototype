using Godot;
using System;

public partial class GameManager : Node2D
{
	[Signal]
	public delegate void PlatformChangeCollisionEventHandler(string Color);
	player Player;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Player = GetNode<player>("Player");
		Player.WheelInputState.PlayerWheelInputEntered += () => Engine.TimeScale = 0.25f;
		Player.WheelInputState.PlayerWheelInputExited += () => Engine.TimeScale = 1.0f;
		Player.WheelInputState.PlayerWheelUp += PlatformChangeCollisionEmitter;
		Player.WheelInputState.PlayerWheelDown += PlatformChangeCollisionEmitter;
		Player.WheelInputState.PlayerWheelLeft += PlatformChangeCollisionEmitter; 
		Player.WheelInputState.PlayerWheelRight += PlatformChangeCollisionEmitter;
	}

	void PlatformChangeCollisionEmitter (string Color) {
		EmitSignal(SignalName.PlatformChangeCollision, Color);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
