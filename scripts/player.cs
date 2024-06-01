using Godot;
using System;

public partial class player : CharacterBody2D
{
	[Export]
	ColorOptions ColorWheel;
	public AnimatedSprite2D AnimatedSprite;
	public StateMachine PlayerStateMachine;
	public PlayerMoveState MoveState;
	public PlayerInAirState InAirState;
	public PlayerWheelInputState WheelInputState;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public float Speed = 150.0f;
	bool ColorWheelInactive = true; // Hard coded solution honestly

    public override void _Ready()
    {
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		PlayerStateMachine = GetNode<StateMachine>("StateMachine");
		MoveState = GetNode<PlayerMoveState>("StateMachine/PlayerMoveState");
		InAirState = GetNode<PlayerInAirState>("StateMachine/PlayerInAirState");
		WheelInputState = GetNode<PlayerWheelInputState>("StateMachine/PlayerWheelInputState");

		if (ColorWheelInactive) InAirState.PlayerNotInAir += () => PlayerStateMachine.ChangeState(MoveState);
		WheelInputState.PlayerWheelInputEntered += () => ColorWheel.Activated();
		WheelInputState.PlayerWheelInputExited += () => ColorWheel.Deactivated();
    }

    public override void _Process(double delta)
    {
		if (Input.IsActionJustPressed("b_key")) {
			ColorWheelInactive = false;
			PlayerStateMachine.ChangeState(WheelInputState);
		}
		else if (Input.IsActionJustReleased("b_key")) {
			ColorWheelInactive = true;
			PlayerStateMachine.ChangeState(InAirState);
		}
    }

    public override void _PhysicsProcess(double delta)
	{
        Vector2 direction = Input.GetVector("left", "right", "up", "down");

		Vector2 velocity = Velocity;

		if (!IsOnFloor()) {
			if (ColorWheelInactive) PlayerStateMachine.ChangeState(InAirState);
			velocity.Y += gravity * (float)delta;
		}
		Velocity = velocity;
	}
}
