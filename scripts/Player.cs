using Godot;
using static System.Net.Mime.MediaTypeNames;

public partial class Player : CharacterBody2D
{
	[Export] PackedScene _projectileScene;
	public const float SPEED = 300.0f;
    public  const float DELAY = 1f;
    public  float CurrentDelay = 0;

    public Vector2 direction = Vector2.Zero;


    public override void _PhysicsProcess(double delta)
	{
		Vector2 velocity = Velocity;
        if (CurrentDelay > 0)
        {
            CurrentDelay -= Mathf.Clamp(CurrentDelay, 0, (float)delta);
            GD.Print($"delay {CurrentDelay}");
        }
      

        if (Input.IsActionJustPressed("PlayerShoot") && CurrentDelay <= 0)
		{
			Shoot();
		}

		// Get the input direction and handle the movement/deceleration.
		// As good practice, you should replace UI actions with custom gameplay actions.
		direction = Input.GetVector("MoveLeft", "MoveRight", "MoveUp", "MoveDown");
        if (Mathf.Abs(direction.X) > Mathf.Abs(direction.Y))
        {
            direction.Y = 0;
        }
        else
        {
            direction.X = 0;
        }


        Velocity = direction * SPEED;
        MoveAndSlide();
	}

	private async void Shoot()
	{
        CurrentDelay = DELAY;
        for (int i = 0; i < 3; i++)
        {
            var projectile = _projectileScene.Instantiate<Projectile>();

            GetTree().CurrentScene.AddChild(projectile);

            projectile.GlobalPosition = GlobalPosition;

            // espera 0.15 segundos entre tiros
            await ToSignal(
                GetTree().CreateTimer(0.15f),
                SceneTreeTimer.SignalName.Timeout
            );
        }
    }
}
