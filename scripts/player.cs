using Godot;
using System;

public partial class player : CharacterBody2D
{
	public AnimatedSprite2D AnimatedSprite;
	StateMachine PlayerStateMachine;
	PlayerMoveState MoveState;
	PlayerInAirState InAirState;
	//public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		PlayerStateMachine = GetNode<StateMachine>("StateMachine");
		MoveState = GetNode<PlayerMoveState>("StateMachine/PlayerMoveState");
		InAirState = GetNode<PlayerInAirState>("StateMachine/PlayerInAirState");

		InAirState.PlayerNotInAir += () => PlayerStateMachine.ChangeState(MoveState);
    }

    public override void _PhysicsProcess(double delta)
	{
		if (!IsOnFloor()) {
			PlayerStateMachine.ChangeState(InAirState);
		}
	}
}
