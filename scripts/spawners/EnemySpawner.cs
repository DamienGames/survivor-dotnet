using System;
using System.Reflection.Metadata;
using Godot;
using Godot.Collections;

public partial class EnemySpawner : Node
{
    [Export] private Array<Marker2D> _listaMarkers;
    [Export] bool IsActive = false;

    private EnemyPool _enemyPool;

    public override void _Ready()
    {
        _enemyPool = GetParent().GetNode<EnemyPool>("EnemyPool");   
    }

    public void SpawnEnemies(int ammount)
    {
        var enemies = _enemyPool.GetEnemies(ammount);
        if (IsActive)
        {
            foreach (var enemy in enemies)
            {
                var spawn = _listaMarkers.PickRandom();
                Vector2 random = new Vector2(spawn.GlobalPosition.X + GD.RandRange(1, 400), spawn.GlobalPosition.Y + GD.RandRange(1, 400));
                if (!enemy.Active)
                    enemy.Spawn(GetPosition());
            }
        }
    }

    public Vector2 GetPosition()
    {
        var _player = GetParent().GetNodeOrNull<Player>("Player");
        Vector2 position = Vector2.Zero;

        if (_player is not null)
        {
            Vector2 screenSize = GetTree().Root.GetVisibleRect().Size;
            RandomNumberGenerator rng = new();

            float minRadius = screenSize.X + 500;
            float maxRadius = screenSize.X + 600;

            float angle = rng.RandfRange(0, Mathf.Tau);
            float radius = rng.RandfRange(minRadius, maxRadius);

            position =
                _player.GlobalPosition +
                Vector2.FromAngle(angle) * radius;

            return position;
        }
        return position;
    }


    public void Remove(Node2D Enemy)
    {
        _enemyPool.RemoveEnemy(Enemy.Name);
    }
}
