using Godot;
using System;

[GlobalClass]
public partial class PlayerWheelInputState : State
{
    [Export]
    player Player;

    public override void _Ready()
    {
        SetPhysicsProcess(false);
        SetProcess(false);
    }

    public override void EnterState() 
    {
        SetPhysicsProcess(true);
        SetProcess(true);
    }

    public override void ExitState() 
    {
        SetPhysicsProcess(false);
        SetProcess(false);
    }

    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(double delta) {
        Vector2 velocity = Player.Velocity;
        Vector2 direction = Input.GetVector("left", "right", "up", "down");
        if (direction.X == 0 && Player.IsOnFloor()) {
            Player.AnimatedSprite.Play("idle");
            velocity.X = Mathf.MoveToward(Player.Velocity.X, 0, Player.Speed);
        }
        Player.Velocity = velocity;
        Player.MoveAndSlide();
    }
}
