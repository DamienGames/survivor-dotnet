//using Godot;
//using System;
//using System.Collections.Generic;

//public partial class EnemyPool : Node
//{
//    [Export] public PackedScene EnemyScene;

//    private Queue<Enemy> _pool = new();

//    public Enemy Get()
//    {
//        if (_pool.Count > 0)
//        {
//            var e = _pool.Dequeue();
//            e.Visible = true;
//            return e;
//        }

//        var enemy = EnemyScene.Instantiate<Enemy>();
//        AddChild(enemy);
//        return enemy;
//    }

//    public void Return(Enemy enemy)
//    {
//        enemy.Visible = false;
//        _pool.Enqueue(enemy);
//    }
//}