using Godot;
using System;

[GlobalClass]
public partial class StateMachine : Node
{
	[Export]
	State State; // Also represents the intial state when the game starts

	public void ChangeState(State NewState) {
		State.ExitState();
		NewState.EnterState();
		State = NewState;
	}
}
