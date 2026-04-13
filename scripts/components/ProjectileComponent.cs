using System;
using Godot;

public partial class ProjectileComponent : Area2D
{
    #region Properties

    private float _damage;
    private Vector2 _direction = Vector2.Right;
    private float _speed = 300f;
    #endregion

    #region Métodos
 
    public override void _PhysicsProcess(double delta)
    {
        Position += _direction * _speed * (float)delta;
    }

    public void SetDamage(float damage)
    {
        _damage = damage;
    }

    public float GetDamage()
    {
        return _damage;
    }
    #endregion
}