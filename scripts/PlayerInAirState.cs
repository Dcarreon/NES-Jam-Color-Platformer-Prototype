using Godot;
using System;

[GlobalClass]
public partial class PlayerInAirState : State
{
    [Signal]
    public delegate void PlayerNotInAirEventHandler();
    [Export]
    player Player;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

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
        Vector2 velocity = Player.Velocity;
        velocity.Y += gravity * (float)delta;
        Player.Velocity = velocity;
        
        if (Player.IsOnFloor()) {
            EmitSignal(SignalName.PlayerNotInAir);
        }

        Player.MoveAndSlide();
    }
}
