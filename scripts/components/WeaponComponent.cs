using Godot;

public partial class WeaponComponent : Node
{
    [Export] private WeaponConfig config;

    private float _timer;

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
        var projectile = config.ProjectileScene.Instantiate<Node2D>();
        GetTree().CurrentScene.AddChild(projectile);

        projectile.GlobalPosition = GetParent<Node2D>().GlobalPosition;

        if (projectile is Projectile p)
            p.SetDamage(config.Damage);
    }
}