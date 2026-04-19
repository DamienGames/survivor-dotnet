using Godot;

public partial class Main : Node2D
{
    [Export]
    public EnemySpawner spawner;

	private Label _labelFPS;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        _labelFPS = GetNode<Label>("CanvasLayer/FPS");
        spawner = GetNode<EnemySpawner>("EnemySpawner");
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
         spawner.SpawnEnemies(1);
        _labelFPS.Text = Engine.GetFramesPerSecond().ToString();
    }
}
