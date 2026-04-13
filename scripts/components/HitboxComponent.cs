using Godot;

public partial class HitboxComponent : Area2D
{
    #region Signals

    [Signal] public delegate void HitDetectedEventHandler(Node2D other);
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
        if (body is HurtboxComponent hurtbox && hurtbox.CanBeHit())
            EmitSignal(nameof(HitDetectedEventHandler), hurtbox);        
    }
    #endregion
}


//public void ApplyEffects(Node target, Array<Effect> effects)
//{
//    var sortedEffects = effects.OrderByDescending(e => e.Priority);

//    foreach (var effect in sortedEffects)
//    {
//        if (GD.Randf() <= effect.Chance)
//        {
//            effect.Apply(target);
//        }
//    }
//}


////float damage = baseDamage;

//// 1. Buffs
//damage *= attacker.DamageMultiplier;

//// 2. Defesa
//damage -= target.Defense;

//// 3. Crit
//if (IsCrit())
//    damage *= critMultiplier;

//// 4. Clamp
//damage = Mathf.Max(1, damage);