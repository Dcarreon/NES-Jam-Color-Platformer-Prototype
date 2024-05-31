using Godot;
using System;

public partial class player : CharacterBody2D
{
	public AnimatedSprite2D AnimatedSprite;
	StateMachine PlayerStateMachine;
	PlayerMoveState MoveState;
	PlayerInAirState InAirState;
	PlayerWheelInputState WheelInputState;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();
	public float Speed = 150.0f;
	bool EnableStateChange = true;

    public override void _Ready()
    {
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		PlayerStateMachine = GetNode<StateMachine>("StateMachine");
		MoveState = GetNode<PlayerMoveState>("StateMachine/PlayerMoveState");
		InAirState = GetNode<PlayerInAirState>("StateMachine/PlayerInAirState");
		WheelInputState = GetNode<PlayerWheelInputState>("StateMachine/PlayerWheelInputState");

		if (EnableStateChange) InAirState.PlayerNotInAir += () => PlayerStateMachine.ChangeState(MoveState);
    }

    public override void _Process(double delta)
    {
		if (Input.IsActionJustPressed("b_key")) {
			EnableStateChange = false;
			PlayerStateMachine.ChangeState(WheelInputState);
		}
		else if (Input.IsActionJustReleased("b_key")) {
			EnableStateChange = true;
			PlayerStateMachine.ChangeState(InAirState);
		}
    }

    public override void _PhysicsProcess(double delta)
	{
        Vector2 direction = Input.GetVector("left", "right", "up", "down");

		Vector2 velocity = Velocity;

		if (!IsOnFloor()) {
			if (EnableStateChange) PlayerStateMachine.ChangeState(InAirState);
			velocity.Y += gravity * (float)delta;
		}
		Velocity = velocity;
	}
}
