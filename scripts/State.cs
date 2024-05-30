using Godot;
using System;

[GlobalClass]
public partial class State : Node
{
	[Signal]
	public delegate void FinishedStateEventHandler();

	public void EnterState(){}
	
	public void ExitState(){}
}
