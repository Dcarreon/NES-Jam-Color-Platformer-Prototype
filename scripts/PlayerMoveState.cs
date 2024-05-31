using Godot;
using System;

[GlobalClass]
public partial class PlayerMoveState : State
{
    [Signal]
    public delegate void PlayerStoppedMovementEventHandler();

    [Export]
    player Player;
	public const float Speed = 150.0f;
	public const float JumpVelocity = -400.0f;

    public override void _Ready()
    {
        SetPhysicsProcess(false);
    }

    public override void EnterState() 
    {
        SetPhysicsProcess(true);
    }

    public override void ExitState()
    {
        SetPhysicsProcess(false);
    }

    public override void _PhysicsProcess(double delta)
	{
        Vector2 velocity = Player.Velocity;

        // Handle Jump.
        if (Input.IsActionJustPressed("ui_accept") && Player.IsOnFloor())
            velocity.Y = JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("left", "right", "ui_up", "ui_down");
        if (direction != Vector2.Zero)
        {
            velocity.X = direction.X * Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Player.Velocity.X, 0, Speed);
        }

        if (direction.X > 0) {
            Player.AnimatedSprite.FlipH = false;
        }
        else if (direction.X < 0) {
            Player.AnimatedSprite.FlipH = true;
        }

        if (direction.X == 0) {
            Player.AnimatedSprite.Play("idle");
        }
        else {
            Player.AnimatedSprite.Play("run");
        }

        Player.Velocity = velocity;
        Player.MoveAndSlide();
	}
}
