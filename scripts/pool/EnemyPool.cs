using Godot;
using Godot.Collections;

public partial class EnemyPool : Node
{
    [Export] PackedScene EnemyScene;
    [Export] int MaxPoolSize = 50;

    private Array<Enemy> _pool = new();

    public int SetPool(int PoolSize)
    {
        int ammount = 0;
        if (PoolSize + _pool.Count <= MaxPoolSize)
        {
            for (int i = 0; i < PoolSize; i++)
            {
                var enemy = EnemyScene.Instantiate<Enemy>();

                AddChild(enemy);
                enemy.Visible = false;
                enemy.ProcessMode = ProcessModeEnum.Disabled;
                _pool.Add(enemy);
                ammount++;
            }
        }
        return ammount;
    }

    public Enemy GetEnemy()
    {
        foreach (var enemy in _pool)
        {
            if (!enemy.Active)
            {
                return enemy;
            }
        }
        return null;
    }

    public Array<Enemy> GetEnemies(int ammount)
    {
        SetPool(ammount);

        Array<Enemy> enemies = new();
        foreach (var enemy in _pool)
        {
            if (!enemy.Active)
                enemies.Add(enemy);
        }
        return enemies;
    }

    public void RemoveEnemy(string name)
    {
        foreach (var enemy in _pool)
        {
            if (enemy.Name == name)
            {
                enemy.Active = false;
            }
        }
    }

    public void ResetPool()
    {
        _pool.Clear();
    }
}