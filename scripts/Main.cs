using Godot;

public partial class Main : Node2D
{
    [Export]
    public EnemySpawner spawner;

	private Label _labelFPS;

	public override void _Ready()
	{
    }

    public override void _Process(double delta)
    {
    }
}
