using Godot;

public partial class ProjectileComponent: Area2D
{
    private int _damage;
    private Vector2 _direction = Vector2.Right;
    private float _speed = 300f;

    public void SetDamage(int damage)
    {
        _damage = damage;
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += _direction * _speed * (float)delta;
    }

    public int GetDamage() => _damage;
}