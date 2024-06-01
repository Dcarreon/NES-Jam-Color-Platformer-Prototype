using Godot;
using System;

public partial class ColorPlatform : AnimatableBody2D
{
	public CollisionShape2D CollisionShape;
	Sprite2D Green;
	Sprite2D Blue;
	Sprite2D Yellow;
	Sprite2D Beige;

	[Export]
	public string Color;

	public override void _Ready()
	{
		CollisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		Green  = GetNode<Sprite2D>("Green");	
		Blue   = GetNode<Sprite2D>("Blue");
		Yellow = GetNode<Sprite2D>("Yellow");
		Beige  = GetNode<Sprite2D>("Beige"); 

		CollisionShape.Disabled = true;
		CollisionShape.OneWayCollision = true;

		Green.Visible = false;
		Blue.Visible = false;
		Yellow.Visible = false;
		Beige.Visible = false;

		switch (Color) {
			case "Green":
				Green.Visible = true;
				break;

			case "Blue":
				Blue.Visible = true;
				break;

			case "Yellow":
				Yellow.Visible = true;
				break;

			case "Beige":
				Beige.Visible = true;
				break;
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
