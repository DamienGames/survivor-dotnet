using Godot;
using System;
using static System.Net.Mime.MediaTypeNames;

[GlobalClass]
public partial class Player : CharacterBody2D
{

	[Export] public  PlayerConfig _config;

    private PlayerRuntime _runtime;
    private PackedScene _damageNumberScene = GD.Load<PackedScene>("res://scenes/UI/damage_number.tscn");

    public override void _Ready()
    {
        _runtime = new PlayerRuntime();
        AddChild(_runtime);
        _runtime.Initialize(_config);
    }

    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;

		// Add the gravity.
		if (!IsOnFloor())
		{
			velocity += GetGravity() * (float)delta;
		}

		// Handle Jump.
		if (Input.IsActionJustPressed("ui_accept") && IsOnFloor())
		{
			velocity.Y = _config.JumpForce;
		}

		Vector2 direction = Input.GetVector("ui_left", "ui_right", "ui_up", "ui_down");
		if (direction != Vector2.Zero)
		{
			velocity.X = direction.X * _runtime.FinalSpeed();
		}
		else
		{
			velocity.X = Mathf.MoveToward(Velocity.X, 0, _runtime.FinalSpeed());
		}
        Velocity = velocity;
        MoveAndSlide();
    }

	public async void ShowDamage(float damage)
	{
		var damageNumber = _damageNumberScene.Instantiate<DamageNumber>();
		AddChild(damageNumber);
		damageNumber.GlobalPosition = GlobalPosition;
		damageNumber.Setup(damage, GD.RandRange(0, 1) > 0);
    }
}
