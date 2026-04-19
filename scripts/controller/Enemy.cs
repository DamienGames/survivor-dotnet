using Godot;

public partial class Enemy : StaticBody2D
{
    [Signal] public delegate void HurtEventHandler(Node2D other);

    public const float Speed = 200.0f;
    public const float JumpVelocity = -400.0f;
    public bool Active = false;
    public Area2D _hurtBox;

    public override void _Ready()
    {
        _hurtBox = GetNode<Area2D>("Hurtbox");
        _hurtBox.AreaEntered += OnAreaEntered;
    }

    public override void _PhysicsProcess(double delta)
    {
        if (Active)
        {
            var player = GetTree().Root.GetNodeOrNull<Player>("../Player");
            if (player is not null)
            {
                var distance = GlobalPosition.DistanceTo(player.GlobalPosition);
                if (distance >= 200f)
                {
                    Vector2 dir =
                        (player.GlobalPosition - GlobalPosition)
                        .Normalized();

                    GlobalPosition +=
                        dir *
                        Speed *
                        (float)delta;
                }
            }         
        }
    }

    public void Spawn(Vector2 vector2)
    {
        Visible = true;
        ProcessMode = ProcessModeEnum.Always;
        GlobalPosition = vector2;
        Active = true;
    }

    public void OnAreaEntered(Area2D area)
    {
        Enemy enemy = GetParent<Enemy>();
    }
}
