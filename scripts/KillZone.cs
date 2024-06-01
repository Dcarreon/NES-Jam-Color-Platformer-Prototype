using Godot;
using System;

public partial class KillZone : Area2D
{
    Timer KillTimer;
    public override void _Ready()
    {
        KillTimer = GetNode<Timer>("Timer");

        BodyEntered += OnBodyEntered;
        KillTimer.Timeout += () => OnTimerTimeout();
    }

    void OnBodyEntered(Node2D Body) {
        KillTimer.Start();
    }

    void OnTimerTimeout() {
        GetTree().ReloadCurrentScene();
    }
}
