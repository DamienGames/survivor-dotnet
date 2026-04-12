using Godot;

[GlobalClass]
public partial class WeaponConfig : Resource
{
    [Export] public int Damage = 10;
    [Export] public float Cooldown = 1f;
    [Export] public PackedScene ProjectileScene;
}