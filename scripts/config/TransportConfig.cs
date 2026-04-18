using Godot;
using Godot.Collections;
using static WeaponConfig;

public partial class TransportConfig : Resource
{

    #region Exports
    [ExportGroup("Base")]
    [Export] public string Id;
    [Export] public string DisplayName;
    [Export] public string Description;

    [ExportGroup("Combat")]
    [Export] public float Health;
    [Export] public float Cooldown = 1f;

    [ExportGroup("Behavior")]
    [Export] public int MovinSpeed;
    [Export] public int Slots;
    [Export] public TransportType Type;
    [Export] public TransportBoost Boost;
    [Export] public TransportEvolve Evolve;

    [ExportGroup("Visual")]
    [Export] public Texture2D DisplayIcon;
    [Export] public PackedScene TransportScene;

    [ExportGroup("Effects")]
    [Export] public Array<EffectConfig> Effects;
    #endregion

    #region Enums
    public enum TransportType
    {
        Cart,
        Fly,
        Runner     
    }

    public enum TransportEvolve
    {
        Slots,
        Armor,
        Velocity,
        Boost
    }

    public enum TransportBoost
    {
        None,
        AttackSpeed,
        Energy,
        Magnet,
        Projectil,
    }
    #endregion

}
