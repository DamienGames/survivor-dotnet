using Godot;

public partial class WeaponComponent : Node
{
	#region Signals

	[Signal] public delegate void HasShootEventHandler(Node2D other);
	#endregion

	#region Exports

	[Export] public WeaponConfig config;
	[Export] public ProjectileConfig ProjectileConfig;
	#endregion

	#region Properties

	private float _timer;
	#endregion

	#region Métodos
	public override void _Process(double delta)
	{
		_timer -= (float)delta;

		if (_timer <= 0)
		{
			Shoot();
			_timer = config.Cooldown;
		}
	}

	private void Shoot()
	{
		var instance = config.ProjectileScene.Instantiate<Node2D>();

		GetTree().CurrentScene.AddChild(instance);
		instance.GlobalPosition = GetParent<Node2D>().GlobalPosition;

		if (instance is ProjectileComponent projectile)
			projectile.Init(ProjectileConfig, instance);
	}
	#endregion
}
