using Godot;
using System;

[GlobalClass]
public partial class PlayerInAirState : State
{
    [Signal]
    public delegate void PlayerNotInAirEventHandler();
    [Export]
    player Player;

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

    public override void _PhysicsProcess(double delta) {
        Player.AnimatedSprite.Play("jump");

        Vector2 direction = Input.GetVector("left", "right", "up", "down");
        Vector2 velocity = Player.Velocity;

        if (Input.IsActionJustPressed("right") || Input.IsActionJustPressed("left"))
        {
            velocity.X = direction.X * Player.Speed * 0.5f;
            Player.Velocity = velocity;
        }

        if (direction.X > 0) {
            Player.AnimatedSprite.FlipH = false;
        }
        else if (direction.X < 0) {
            Player.AnimatedSprite.FlipH = true;
        }
        
        if (Player.IsOnFloor()) {
            Player.AnimatedSprite.Play("idle");
            EmitSignal(SignalName.PlayerNotInAir);
        }

        Player.MoveAndSlide();
    }
}
