using Godot;
using System;

public partial class player : CharacterBody2D
{
	StateMachine PlayerStateMachine;
	PlayerMoveState MoveState;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
		PlayerStateMachine = GetNode<StateMachine>("StateMachine");
		MoveState = GetNode<PlayerMoveState>("StateMachine/PlayerMoveState");
    }

    public override void _PhysicsProcess(double delta)
	{
            if (!IsOnFloor()) {
				Vector2 velocity = Velocity;
                velocity.Y += gravity * (float)delta;
				Velocity = velocity;
			}
	}
}
