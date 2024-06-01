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
    public delegate void PlayerWheelUpEventHandler(string color);
    [Signal]
    public delegate void PlayerWheelDownEventHandler(string color);
    [Signal]
    public delegate void PlayerWheelLeftEventHandler(string color);
    [Signal]
    public delegate void PlayerWheelRightEventHandler(string color);
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
            if (Emit) {EmitSignal(SignalName.PlayerWheelUp, "Green");}
            Emit = false;
        }
        else if (direction.Y > 0 && direction.X == 0) {
            if (Emit) {EmitSignal(SignalName.PlayerWheelDown, "Yellow");}
            Emit = false;
        }
        else if (direction.X < 0 && direction.Y == 0) {
            if (Emit) {EmitSignal(SignalName.PlayerWheelLeft, "Beige");}
            Emit = false;
        }
        else if (direction.X > 0 && direction.Y == 0) {
            if (Emit) {EmitSignal(SignalName.PlayerWheelRight, "Blue");}
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
