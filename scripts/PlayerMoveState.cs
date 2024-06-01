using Godot;
using System;

[GlobalClass]
public partial class PlayerMoveState : State
{
    [Signal]
    public delegate void PlayerStoppedMovementEventHandler();

    [Export]
    player Player;
	public float JumpVelocity = -400.0f;

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
        if (Input.IsActionJustPressed("a_key") && Player.IsOnFloor())
            velocity.Y = JumpVelocity;

        // Get the input direction and handle the movement/deceleration.
        // As good practice, you should replace UI actions with custom gameplay actions.
        Vector2 direction = Input.GetVector("left", "right", "up", "down", 1.0f);
        if (direction.X != 0)
        {
            velocity.X = direction.X * Player.Speed;
        }
        else
        {
            velocity.X = Mathf.MoveToward(Player.Velocity.X, 0, Player.Speed);
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
