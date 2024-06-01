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
	[Export]
	GameManager Game;
	Sprite2D SelectedSprite;

	public override void _Ready()
	{
		CollisionShape = GetNode<CollisionShape2D>("CollisionShape2D");
		Green  = GetNode<Sprite2D>("Green");	
		Blue   = GetNode<Sprite2D>("Blue");
		Yellow = GetNode<Sprite2D>("Yellow");
		Beige  = GetNode<Sprite2D>("Beige"); 

		CollisionShape.Disabled = true;
		CollisionShape.OneWayCollision = true;

		Game.PlatformChangeCollision += CollisionToggle;

		Green.Visible = false;
		Blue.Visible = false;
		Yellow.Visible = false;
		Beige.Visible = false;

		switch (Color) {
			case "Green":
				Green.Visible = true;
				SelectedSprite = Green;
				break;

			case "Blue":
				Blue.Visible = true;
				SelectedSprite = Blue;
				break;

			case "Yellow":
				Yellow.Visible = true;
				SelectedSprite = Yellow;
				break;

			case "Beige":
				Beige.Visible = true;
				SelectedSprite = Beige;
				break;
		}

		SelectedSprite.FlipV = true;
	}

	void CollisionToggle(string EmittedColor) {
		if (EmittedColor == Color) {
			CollisionShape.Disabled = false;
			if (SelectedSprite.FlipV) {
				SelectedSprite.FlipV = false;
			}
		}
		else {
			CollisionShape.Disabled = true;
			if (!SelectedSprite.FlipV) {
				SelectedSprite.FlipV = true;
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}
