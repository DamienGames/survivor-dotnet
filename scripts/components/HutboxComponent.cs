using Godot;

public partial class HurtboxComponent : Area2D
{
    private HealthComponent _health;

    public override void _Ready()
    {
        _health = GetParent().GetNode<HealthComponent>("HealthComponent");
        AreaEntered += OnAreaEntered;
    }

    private void OnAreaEntered(Area2D area)
    {
        if (area is HitboxComponent hitbox)
        {
            _health.TakeDamage(hitbox.Damage);
        }
    }
}