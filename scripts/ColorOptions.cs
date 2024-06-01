using Godot;
using System;

public partial class ColorOptions : Control
{
	public override void _Ready()
	{
		Visible = false;
		SetProcess(false);
	}

	public void Activated() {
		Visible = true;
		SetProcess(true);
	}

	public void Deactivated() {
		Visible = false;
		SetProcess(false);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
