using Godot;

public partial class HitboxComponent : Area2D
{
    [Export] private int damage = 10;

    public int Damage => damage;
}