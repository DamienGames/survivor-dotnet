using Godot;
using Godot.Collections;

[GlobalClass]
public partial class StandingConfig : Resource
{
    [Export] public int CorporationPonints = 0;
    [Export] public int UndergroundPoints = 0;
    [Export] public int RobotPoints = 0;

    public Dictionary<FactionType, FactionType> Rival = new ()
    {
        {   FactionType.Corporation, FactionType.Robot  },
        {   FactionType.Underground, FactionType.Corporation  },
        {   FactionType.Robot, FactionType.Underground  }
    };

    public enum FactionType
    {
        Corporation,
        Underground,
        Robot
    }
}