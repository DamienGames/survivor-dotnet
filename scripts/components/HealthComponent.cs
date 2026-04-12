using Godot;

public partial class HealthComponent : Node
{
    [Signal] public delegate void DiedEventHandler();

    [Export] private int maxHealth = 100;

    private int _currentHealth;
    private StatsComponent _stats;

    public override void _Ready()
    {
        _currentHealth = maxHealth;
        _stats = GetParent().GetNode<StatsComponent>("StatsComponent");
    }

    public void TakeDamage(int rawDamage)
    {
        if (_currentHealth <= 0)
            return;

        int defense = _stats?.Defense ?? 0;
        int finalDamage = Mathf.Max(rawDamage - defense, 1);

        _currentHealth -= finalDamage;

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            EmitSignal(SignalName.Died);
        }
    }
}