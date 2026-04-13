using Godot;

public partial class StatsComponent : Node
{
    #region Signals
    [Signal] public delegate void StatsChangedEventHandler();
    #endregion

    #region Exports

    [Export] private float _baseDamage = 10;
    [Export] private float _baseDefense = 2;
    [Export] private float _baseSpeed = 100;
    #endregion

    #region Properties
    private float _bonusDamage;
    private float _bonusDefense;
    private float _bonusSpeed;

    public float Damage => _baseDamage + _bonusDamage;
    public float Defense => _baseDefense + _bonusDefense;
    public float Speed => _baseSpeed + _bonusSpeed;
    #endregion

    #region Métodos

    public void AddDefense(float amount)
    {
        _bonusDefense += amount;
        EmitSignal(SignalName.StatsChanged);
    }

    public void AddDamage(float amount)
    {
        _bonusDamage += amount;
        EmitSignal(SignalName.StatsChanged);
    }

    public void AddSpeed(float amount)
    {
        _bonusSpeed += amount;
        EmitSignal(SignalName.StatsChanged);
    }

    public void ResetBonuses()
    {
        _bonusDamage = 0;
        _bonusDefense = 0;
        _bonusSpeed = 0;

        EmitSignal(SignalName.StatsChanged);
    }
    #endregion
}


