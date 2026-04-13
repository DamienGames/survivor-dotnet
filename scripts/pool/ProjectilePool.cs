using Godot;
using System.Collections.Generic;

public partial class ProjectilePool : Node
{
    #region Exports

    [Export] public PackedScene ProjectileScene;
    [Export] public int InitialSize = 20;
    #endregion

    #region Properties

    private Queue<ProjectileComponent> _pool = new();
    #endregion

    #region Métodos

    public override void _Ready()
    {
        for (int i = 0; i < InitialSize; i++)
        {
            var projectile = Create();
            projectile.Visible = false;
            _pool.Enqueue(projectile);
        }
    }

    private ProjectileComponent Create()
    {
        var instance = ProjectileScene.Instantiate<ProjectileComponent>();
        AddChild(instance);
        instance.SetProcess(false);
        return instance;
    }

    public ProjectileComponent Get()
    {
        if (_pool.Count == 0)
            return Create();

        var projectile = _pool.Dequeue();
        projectile.Visible = true;
        projectile.SetProcess(true);

        return projectile;
    }

    public void Return(ProjectileComponent projectile)
    {
        projectile.Visible = false;
        projectile.SetProcess(false);
        _pool.Enqueue(projectile);
    }
    #endregion

}