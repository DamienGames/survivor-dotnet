using Godot;
using System;
using System.Reflection.Emit;
using static System.Net.Mime.MediaTypeNames;

public partial class HealthComponent : Node
{
    #region Signals

    [Signal] 
    public delegate void HealthChangedEventHandler(float currentHealth, bool isFull = false);

    [Signal]
    public delegate void DiedEventHandler();
    #endregion

    #region Exports
    [Export] 
    private int maxHealth = 100;

    #endregion

    #region Properties
    public float CurrentHealth { get; private set; }
    public bool IsDead { get; private set; }

    private float _currentHealth;
    private bool _isDead;
    private StatsComponent _stats;
    #endregion

    #region Métodos

    public override void _Ready()
    {
        _currentHealth = maxHealth;
        _stats = GetParent().GetNode<StatsComponent>("StatsComponent");
    }

    public void TakeDamage(DamageRuntime damage)
    {
        if (_currentHealth <= 0 || _isDead)
            return;

        float defense = _stats?.GetStat(StatsComponent.StatType.Defense) ?? 0;
        float finalDamage = Mathf.Max(damage.FinalAmount - defense, 1);

        _currentHealth -= finalDamage;
        EmitSignal(SignalName.HealthChanged, _currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            _isDead = true;
            EmitSignal(SignalName.Died);
        }
    }

    public void Heal(float amount)
    {
        _currentHealth += amount;
        if (_currentHealth > maxHealth)
            _currentHealth = maxHealth;
        EmitSignal(SignalName.HealthChanged, _currentHealth);
    }

    public void FullHeal()
    {
        if (_currentHealth != maxHealth)
            _currentHealth = maxHealth;
        EmitSignal(SignalName.HealthChanged, _currentHealth, true);
    }
    #endregion
}