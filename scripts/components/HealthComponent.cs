using System.Reflection.Emit;
using Godot;

public partial class HealthComponent : Node
{
    #region Signals
    [Signal] public delegate void DiedEventHandler();
    [Signal] public delegate void HealthChangedEventHandler(float currentHealth);
    [Signal] public delegate void FullHealEventHandler(float currentHealth);
    #endregion

    #region Exports
    [Export] private int maxHealth = 100;

    #endregion

    #region Properties
    private float _currentHealth;
    private bool _dead;
    private StatsComponent _stats;
    public bool Dead => _dead;
    #endregion

    #region Métodos

    public override void _Ready()
    {
        _currentHealth = maxHealth;
        _stats = GetParent().GetNode<StatsComponent>("StatsComponent");
    }

    public void TakeDamage(float rawDamage)
    {
        if (_currentHealth <= 0)
            return;

        float defense = _stats?.Defense ?? 0;
        float finalDamage = Mathf.Max(rawDamage - defense, 1);

        _currentHealth -= finalDamage;
        EmitSignal(SignalName.HealthChanged, _currentHealth);

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
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
        EmitSignal(SignalName.FullHeal, _currentHealth);
    }
    #endregion






}