using Godot;
public partial class PlayerRuntime : Node
{
    public PlayerConfig Config;
    public string DisplayName;
    public float CurrentHealth;
    public float CurrentXp;

    public float SpeedModifier = 1f;
    public float EvasionModifier = 1f;

    public int Level;
    public Vector2 MoveDirection;

    //public WeaponRuntime CurrentWeapon;

    public float FinalSpeed()
    {
        return Config.MovingSpeed * SpeedModifier;
    }

    public void Initialize(PlayerConfig config)
    {
        Config = config;
        CurrentHealth = Config.MaxHealth;
    }

    public void AddSpeedModifier(float value)
    {
        SpeedModifier += value;
    }
   
    public void AddEvasionModifier(float amount)
    {
        EvasionModifier += amount;
    }

    public void ResetModifiers()
    {
        SpeedModifier = 1f;
        EvasionModifier = 1f;
    }
}
