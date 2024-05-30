using Godot;
using System;

public partial class player : CharacterBody2D
{
	StateMachine PlayerStateMachine;
	PlayerMoveState MoveState;

    public override void _Ready()
    {
		PlayerStateMachine = GetNode<StateMachine>("StateMachine");
		MoveState = GetNode<PlayerMoveState>("StateMachine/PlayerMoveState");
    }

    public override void _PhysicsProcess(double delta)
	{
	}
}
