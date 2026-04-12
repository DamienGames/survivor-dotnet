using Godot;

public partial class StatsComponent : Node
{
    [Export] private int baseDamage = 10;
    [Export] private int defense = 2;
    [Export] private float moveSpeed = 100f;

    public int Damage => baseDamage;
    public int Defense => defense;
    public float MoveSpeed => moveSpeed;
}