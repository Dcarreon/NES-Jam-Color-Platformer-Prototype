using Godot;
using System;

[GlobalClass]
public partial class PlayerMoveState : State
{
    [Signal]
    public delegate void PlayerStoppedMovementEventHandler();

    [Export]
    player Player;
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    bool StateEnabled = false;

    public override void _Ready()
    {
    }

    public override void EnterState() {
        StateEnabled = true;
    }

    public override void ExitState()
    {
        StateEnabled = false;
        //EmitSignal(SignalName.PlayerStoppedMovement);
    }

    public override void _PhysicsProcess(double delta)
	{
        if (StateEnabled) {
            Vector2 velocity = Player.Velocity;

            // Add the gravity.
            if (!Player.IsOnFloor())
                velocity.Y += gravity * (float)delta;

            // Handle Jump.
            if (Input.IsActionJustPressed("ui_accept") && Player.IsOnFloor())
                velocity.Y = JumpVelocity;

            // Get the input direction and handle the movement/deceleration.
            // As good practice, you should replace UI actions with custom gameplay actions.
            Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
            if (direction != Vector2.Zero)
            {
                velocity.X = direction.X * Speed;
            }
            else
            {
                velocity.X = Mathf.MoveToward(Player.Velocity.X, 0, Speed);
            }

            Player.Velocity = velocity;
            Player.MoveAndSlide();
        }
	}
}
