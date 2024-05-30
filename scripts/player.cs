using Godot;
using System;

public partial class player : CharacterBody2D
{
	public AnimatedSprite2D AnimatedSprite;
	StateMachine PlayerStateMachine;
	PlayerMoveState MoveState;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void _Ready()
    {
		AnimatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite2D");
		PlayerStateMachine = GetNode<StateMachine>("StateMachine");
		MoveState = GetNode<PlayerMoveState>("StateMachine/PlayerMoveState");
    }

    public override void _PhysicsProcess(double delta)
	{
            if (!IsOnFloor()) {
				AnimatedSprite.Play("jump");
				Vector2 velocity = Velocity;
                velocity.Y += gravity * (float)delta;
				Velocity = velocity;
			}
	}
}
