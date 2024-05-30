using Godot;
using System;

[GlobalClass]
public partial class State : Node
{
	[Signal]
	public delegate void FinishedStateEventHandler();

	public virtual void EnterState(){}
	
	public virtual void ExitState(){}
}
