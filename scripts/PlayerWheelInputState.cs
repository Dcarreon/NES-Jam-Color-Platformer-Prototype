using Godot;
using System;

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
        Player.MoveAndSlide();
    }
}
