using Godot;

public partial class MeleeAttack : Node
{
    [Export] public Node2D Owner;

    public void Execute(WeaponConfig weapon)
    {
        var space = Owner.GetWorld2D().DirectSpaceState;

        var shape = new CircleShape2D
        {
            Radius = weapon.Range
        };

        var query = new PhysicsShapeQueryParameters2D
        {
            Shape = shape,
            Transform = new Transform2D(0, Owner.GlobalPosition),
            CollideWithBodies = true
        };

        var results = space.IntersectShape(query);

        foreach (var hit in results)
        {
            var collider = hit["collider"].AsGodotObject();

            if (collider is not HurtboxComponent hurtbox || !hurtbox.CanBeHit())
                continue;

            var damageContext = new DamageContext(weapon.Damage)
            {
                Source = Owner,
                Target = hurtbox,
                Direction = GetDirectionTo(hurtbox),
                KnockbackForce = weapon.KnockbackForce,
                PullForce = 0
            };

            hurtbox.TakeDamage(damageContext);
        }
    }

    private Vector2 GetDirectionTo(HurtboxComponent hurtbox)
    {
        return (hurtbox.GlobalPosition - Owner.GlobalPosition).Normalized();
    }
}