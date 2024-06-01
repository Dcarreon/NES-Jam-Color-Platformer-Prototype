using Godot;
using System;

[GlobalClass]
public partial class PlayerWheelInputState : State
{
    [Signal]
    public delegate void PlayerWheelInputEnteredEventHandler();
    [Signal]
    public delegate void PlayerWheelInputExitedEventHandler();
    [Signal]
    public delegate void PlayerWheelUpEventHandler();
    [Signal]
    public delegate void PlayerWheelDownEventHandler();
    [Signal]
    public delegate void PlayerWheelLeftEventHandler();
    [Signal]
    public delegate void PlayerWheelRightEventHandler();
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
        if (Input.IsActionJustPressed("up")) {
            EmitSignal(SignalName.PlayerWheelUp);
        }
        if (Input.IsActionJustPressed("down")) {
            EmitSignal(SignalName.PlayerWheelDown);
        }
        if (Input.IsActionJustPressed("left")) {
            EmitSignal(SignalName.PlayerWheelLeft);
        }
        if (Input.IsActionJustPressed("right")) {
            EmitSignal(SignalName.PlayerWheelRight);
        }
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
