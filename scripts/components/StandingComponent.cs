using Godot;
using System;

public partial class StandingComponent : Node
{
    #region Signal

    [Signal]
    public delegate void StandingChangedEventHandler(int type, int _totalPoints);

    [Signal]
    public delegate void StandingResetEventHandler();
    #endregion

    #region Exports

    [Export] public StandingConfig Config;
    #endregion

    #region Properties

    private int _corporationPoints = 0;
    private int _humanPoints = 0;
    private int _robotPoints = 0;
    private int _totalPoints = 0;
    #endregion

    #region Métodos

    /// <summary>
    /// Inclui +1 ponto ao faction type definido.
    /// </summary>
    /// <param name="amount"></param>
    /// <param name="factionType"></param>
    public void Add(int amount, StandingConfig.FactionType factionType)
    {

        if (_totalPoints >= Config.MaxPoints)
            return;

        if (GetPoints(factionType) >= Config.MaxFactionPoints)
            return;

        switch (factionType)
        {
            case StandingConfig.FactionType.Corporation:
                _corporationPoints++;
                break;

            case StandingConfig.FactionType.Human:
                _humanPoints++;
                break;

            case StandingConfig.FactionType.Robot:
                _robotPoints++;
                break;
        }

        _totalPoints++;
        EmitSignal(SignalName.StandingChanged, (int)factionType, _totalPoints);
    }

    /// <summary>
    /// Remove -1 ponto ao faction type definido.
    /// </summary>
    /// <param name="factionType"></param>
    public void Remove(StandingConfig.FactionType factionType)
    {
        if (GetPoints(factionType) <= 0)
            return;

        switch (factionType)
        {
            case StandingConfig.FactionType.Corporation:
                _corporationPoints--;
                break;

            case StandingConfig.FactionType.Human:
                _humanPoints--;
                break;

            case StandingConfig.FactionType.Robot:
                _robotPoints--;
                break;
        }

        _totalPoints--;
        EmitSignal(SignalName.StandingChanged, -1, (int)factionType, _totalPoints);
    }

    /// <summary>
    /// Reset de todos os pontos para 0
    /// </summary>
    public void Reset()
    {
        _corporationPoints = 0;
        _humanPoints = 0;
        _robotPoints = 0;
        _totalPoints = 0;
        EmitSignal(SignalName.StandingReset);
    }

    /// <summary>
    /// Retorna a pontuação atual do faction type definido
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    private int GetPoints(StandingConfig.FactionType type)
    {
        return type switch
        {
            StandingConfig.FactionType.Corporation => _corporationPoints,
            StandingConfig.FactionType.Human => _humanPoints,
            StandingConfig.FactionType.Robot => _robotPoints,
            _ => 0
        };
    }
    #endregion
}
