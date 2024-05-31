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
        
        if (Player.IsOnFloor()) {
            Player.AnimatedSprite.Play("idle");
            EmitSignal(SignalName.PlayerNotInAir);
        }

        Player.MoveAndSlide();
    }
}
