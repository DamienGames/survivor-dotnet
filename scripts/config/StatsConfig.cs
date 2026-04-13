using Godot;

[GlobalClass]
public partial class StatsConfig : Resource
{
    [Export] public float Damage = 10f;
    [Export] public float Defense = 1f;
    [Export] public float Speed = 1f;
    [Export] public float AttackSpeed = 1f;
    [Export] public float CritChance = 0.1f;
}