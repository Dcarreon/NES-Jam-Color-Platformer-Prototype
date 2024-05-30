using Godot;
using System;

[GlobalClass]
public partial class PlayerInAirState : State
{
    [Signal]
    public delegate void PlayerNotInAirEventHandler();
    [Export]
    player Player;
    bool StateEnabled = false;
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

    public override void EnterState()
    {
        StateEnabled = true;
    }

    public override void ExitState()
    {
        StateEnabled = false;
    }

    public override void _PhysicsProcess(double delta) {
        if (StateEnabled) {
            Player.AnimatedSprite.Play("jump");
            Vector2 velocity = Player.Velocity;
            velocity.Y += gravity * (float)delta;
            Player.Velocity = velocity;
            
            if (Player.IsOnFloor()) {
                Player.AnimatedSprite.Play("idle");
                EmitSignal(SignalName.PlayerNotInAir);
            }

            Player.MoveAndSlide();
        }
    }
}
