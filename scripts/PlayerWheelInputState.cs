using Godot;
using System;

[GlobalClass]
public partial class PlayerWheelInputState : State
{
    [Signal]
    public delegate void PlayerWheelInputEnteredEventHandler();
    [Signal]
    public delegate void PlayerWheelInputExitedEventHandler();
    [Export]
    player Player;
    Vector2 direction = Input.GetVector("left", "right", "up", "down");

    public override void _Ready()
    {
        SetPhysicsProcess(false);
        SetProcess(false);
    }

    public override void EnterState() 
    {
        EmitSignal(SignalName.PlayerWheelInputEntered);
        SetPhysicsProcess(true);
        SetProcess(true);
    }

    public override void ExitState() 
    {
        EmitSignal(SignalName.PlayerWheelInputExited);
        SetPhysicsProcess(false);
        SetProcess(false);
    }

    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(double delta) {
        Vector2 velocity = Player.Velocity;
        if (direction.X == 0 && Player.IsOnFloor()) {
            Player.AnimatedSprite.Play("idle");
            velocity.X = Mathf.MoveToward(Player.Velocity.X, 0, Player.Speed);
        }
        Player.Velocity = velocity;
        Player.MoveAndSlide();
    }
}
