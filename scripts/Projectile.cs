using Godot;
using System;
using static Godot.TextServer;

public partial class Projectile : Area2D
{
    private Vector2 _direction = Vector2.Right;
    private Node _source;
    private float _lifeTimer = 5;
    private float _speed = 400;
    private float damage = 10;

    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;        
    }

    public void SetDirection(Vector2 dir)
    {
        _direction = dir.Normalized();
    }

    public override void _PhysicsProcess(double delta)
    {
        Position += Transform.X * _speed * (float)delta;

        _lifeTimer -= (float)delta;
        if (_lifeTimer <= 0)
            QueueFree();
    }

    private void OnBodyEntered(Node body)
    {
        GD.Print($"tomou {damage} de dano");
        QueueFree();
    }

}
