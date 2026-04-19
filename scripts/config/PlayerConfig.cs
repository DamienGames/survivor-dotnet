using Godot;

public partial class PlayerConfig : Resource
{
    #region Exports

    [ExportGroup("Base")]
    [Export] public string Id;
    [Export] public string DisplayName = "Player";


    [ExportGroup("Behavior")]
    [Export] float MaxHealth;
    [Export] float Damage;
    [Export] float MovingSpeed;
    [Export] float CriticalChange;
    [Export] float CriticalMultiplier;
    [Export] float Evasion;
    [Export] int Level;

    [Export] EnemyType Type;
    [Export] EnemyHostility Hostility;

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public PackedScene EnemyScene;
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
