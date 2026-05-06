using Godot;

[GlobalClass]
public partial class PlayerConfig : Resource
{
    #region Exports

    [ExportGroup("Base")]
    [Export] public string Id;
    [Export] public string DisplayName = "Player";


    [ExportGroup("Behavior")]
    [Export] public float MaxHealth;
    [Export] public float MovingSpeed;
    [Export] public float JumpForce;
    [Export] public float Evasion;
    [Export] public int Level;

    [Export] public EnemyType Type;
    [Export] public EnemyHostility Hostility;

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public PackedScene PlayerScene;
    [Export] public PackedScene StartingWeapon;
    #endregion

    #region Enums
    public enum EnemyType
    {
        Melee,
        Ranged,
        Magic
    }

    public enum EnemyHostility
    {
        Agressive,
        Neutral,
        Passive
    }
    #endregion
}
