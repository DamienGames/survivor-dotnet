using Godot;

public partial class StatsContext : RefCounted
{
    public float Damage;
    public float AttackSpeed;
    public float CritChance;

    public void CopyFrom(StatsConfig config)
    {
        Damage = config.Damage;
        AttackSpeed = config.AttackSpeed;
        CritChance = config.CritChance;
    }
}