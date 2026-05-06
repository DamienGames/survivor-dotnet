using System;
using Godot;

public partial class HurtboxComponent : Area2D
{
    #region Signals

    [Signal]
    public delegate void HurtEventHandler(Node area);

    [Signal]
    public delegate void BlockedEventHandler(Node area);

    [Signal]
    public delegate void InvincibleStartedEventHandler(float duration);

    [Signal]
    public delegate void InvincibleEndedEventHandler();

    #endregion

    #region Exports

    [Export] public PackedScene DamageNumberScene;
    #endregion

    #region Properties

    private bool _is_invincible;
    private HealthComponent _health;
    private HitboxComponent _hitbox;
    #endregion

    #region Métodos

    public override void _Ready()
    {
        _health = GetParent().GetNode<HealthComponent>("HealthComponent");
        AreaEntered += OnAreaEntered;
    }

    public void TakeDamage(DamageRuntime damageContext)
    {
        _health.TakeDamage(damageContext);
        ShowDamageNumber(damageContext.FinalAmount);
        EmitSignal(SignalName.Hurt, damageContext.Source);
    }

    public async void SetInvincible(bool active, float duration = 0)
    {
        _is_invincible = active;

        if (active)
            EmitSignal(SignalName.InvincibleStarted, duration);

        if (duration > 0)
        {
            await ToSignal(GetTree().CreateTimer(0.5f), SceneTreeTimer.SignalName.Timeout);
            SetInvincible(false);
        }
        else
        {
            EmitSignal(SignalName.InvincibleEnded);
        }
    }

    public bool CanBeHit()
    {
        return !_is_invincible && _health != null && !_health.IsDead;
    }

    public void ShowDamageNumber(float damage)
    {
        var numberScene = DamageNumberScene.Instantiate<DamageNumber>();
        GetParent().AddChild(numberScene);
        numberScene.GlobalPosition = GlobalPosition;
        numberScene.Setup(damage, GD.Randf() > 0.5f);
    }
    #endregion

    #region Events

    private void OnAreaEntered(Area2D area)
    {
        if (area is not HitboxComponent hitbox)
            return;

        if (_is_invincible)
        {
            EmitSignal(SignalName.Blocked, hitbox);
            return;
        }
        EmitSignal(SignalName.Hurt, hitbox);
    }

    private void OnHitDetected(DamageRuntime damageContext)
    {
        if (!CanBeHit())
            return;

        TakeDamage(damageContext);
    }
    #endregion
}