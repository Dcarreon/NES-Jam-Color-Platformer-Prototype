using Godot;
using System;

public partial class ColorOptions : Control
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Visible = false;
		SetProcess(false);
	}

	public void Activated() {
		Visible = true;
		SetProcess(true);
	}

	public void Deactivate() {
		Visible = false;
		SetProcess(false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
