using Godot;

public partial class DamageNumber : Label
{
    private Vector2 _velocity;
    private float _lifetime = 1.2f;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        _velocity = new Vector2(
           (float)GD.RandRange(-45, 45), // leve flutuação lateral
           -80
        );

        Color c = Modulate;
        c.A = 1f;
        Modulate = c;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        Position += _velocity * (float)delta;

        Color c = Modulate;
        c.A -= (float)(delta / _lifetime);
        Modulate = c;
        _lifetime -= (float)delta;

        if (_lifetime <= 0)
        {
            QueueFree();
        }
    }

    public void Setup(float value, bool is_crit = false)
    {
        Text = value.ToString();

        if (is_crit)
        {
            AddThemeColorOverride("font_color", Colors.Red);
            _velocity = new Vector2(
                  (float)GD.RandRange(-45, 45), // leve flutuação lateral
                  -80
               );
            Scale = new Vector2(1.4f, 1.4f);
        }
    }
}
