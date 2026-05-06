using Godot;

public partial class HitboxComponent : Area2D
{
    #region Signals

    [Signal] public delegate void HitDetectedEventHandler(DamageRuntime damageContext);
    #endregion

    #region Exports

    [Export] private float damage = 10;
    [Export] private int pull_force = 10;
    [Export] private int knockback_force = 10;
    #endregion

    #region Properties

    public float Damage => damage;
    public int Knockback => knockback_force;
    #endregion

    #region Métodos

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is not HurtboxComponent hurtbox || !hurtbox.CanBeHit())
            return;

        var damageRuntime = new DamageRuntime(damage)
        {
            Source = this,
            Target = hurtbox,
            KnockbackForce = knockback_force,
            PullForce = pull_force
        };

        EmitSignal(SignalName.HitDetected, damageRuntime);
    }
    #endregion
}
