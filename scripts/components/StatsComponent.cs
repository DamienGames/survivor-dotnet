using Godot;
using System.Collections.Generic;

public partial class StatsComponent : Node
{
    #region Signals

    [Signal] public delegate void StatsChangedEventHandler();
    #endregion

    #region Exports

    [Export] public StatsConfig Config;
    #endregion

    #region Properties

    private readonly List<StatModifier> _modifiers = new();
    #endregion

    #region Métodos

    public float GetStat(StatType type)
    {
        float baseValue = type switch
        {
            StatType.Damage => Config.Damage,
            StatType.Defense => Config.Defense,
            StatType.Speed => Config.Speed,
            StatType.AttackSpeed => Config.AttackSpeed,
            StatType.CritChance => Config.CritChance,
            _ => 0
        };

        float bonus = 0;

        foreach (var mod in _modifiers)
        {
            if (mod.Type == type)
                bonus += mod.Value;
        }

        return baseValue + bonus;
    }

    public void AddModifier(object source, StatType type, float value)
    {
        _modifiers.Add(new StatModifier
        {
            Source = source,
            Type = type,
            Value = value
        });

        EmitSignal(SignalName.StatsChanged);
    }

    public void RemoveBySource(object source)
    {
        _modifiers.RemoveAll(m => m.Source == source);
        EmitSignal(SignalName.StatsChanged);
    }

    public void Reset()
    {
        _modifiers.Clear();
        EmitSignal(SignalName.StatsChanged);
    }

    #endregion

public enum StatType
    {
        Damage,
        Defense,
        Speed,
        AttackSpeed,
        CritChance
    }

    public record StatModifier
    {
        public object Source;
        public StatType Type;
        public float Value;
    }
}