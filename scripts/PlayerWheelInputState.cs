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
    bool Emit = true;

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
        Vector2 direction = Input.GetVector("left", "right", "up", "down");
        if (direction.Y < 0 && direction.X == 0) {
            if (Emit) EmitSignal(SignalName.PlayerWheelUp);
            Emit = false;
        }
        else if (direction.Y > 0 && direction.X == 0) {
            if (Emit) EmitSignal(SignalName.PlayerWheelDown);
            Emit = false;
        }
        else if (direction.X < 0 && direction.Y == 0) {
            if (Emit) EmitSignal(SignalName.PlayerWheelLeft);
            Emit = false;
        }
        else if (direction.X > 0 && direction.Y == 0) {
            if (Emit) EmitSignal(SignalName.PlayerWheelRight);
            Emit = false;
        }

        if (direction == Vector2.Zero) {
            Emit = true;
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
