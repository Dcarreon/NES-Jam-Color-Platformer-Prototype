using Godot;
using System;

public partial class PlayerWheelInputState : State
{
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

    public override void _Process(double delta)
    {
    }

    public override void _PhysicsProcess(double delta) {
        Player.MoveAndSlide();
    }
}
