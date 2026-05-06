using Godot;
using Godot.Collections;

[GlobalClass]
public partial class StandingConfig : Resource
{
    [Export] public int MaxPoints = 18;
    [Export] public int MaxFactionPoints = 10;

    public enum FactionType
    {
        Corporation,
        Human,
        Robot
    }
}