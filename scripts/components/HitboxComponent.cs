using Godot;

public partial class HitboxComponent : Area2D
{
    #region Signals

    [Signal] public delegate void HitDetectedEventHandler(Node2D other);
    #endregion

    #region Exports

    [Export] private float damage = 10;
    [Export] private int pull_force = 10;
    [Export] private int knockback_force = 10;
    #endregion

    #region Properties

    public float Damage => damage;
    public int Knockback => knockback_force;
    #endregion

    #region Métodos

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body is HurtboxComponent hurtbox)        
            EmitSignal(nameof(HitDetectedEventHandler), hurtbox);        
    }
    #endregion
}