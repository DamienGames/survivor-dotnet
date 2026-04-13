using Godot;

public partial class ProjectileSpawner : Node
{
    [Export] public Node2D Owner;

    public void Execute(WeaponConfig weapon)
    {
        if (weapon.ProjectileScene == null)
            return;

        switch (weapon.Shape)
        {
            case WeaponConfig.AttackShape.Line:
                Spawn(Vector2.Right, weapon);
                break;

            case WeaponConfig.AttackShape.Cone:
                SpawnCone(weapon, 5, 15f);
                break;

            case WeaponConfig.AttackShape.AroundPlayer:
                SpawnCircle(weapon, 8);
                break;
        }
    }

    private void Spawn(Vector2 dir, WeaponConfig weapon)
    {
        var instance = weapon.ProjectileScene.Instantiate<Node2D>();
        instance.GlobalPosition = Owner.GlobalPosition;

        if (instance is ProjectileComponent projectile)
        {
            projectile.SetDirection(dir);
        }

        Owner.GetTree().CurrentScene.AddChild(instance);
    }

    private void SpawnCone(WeaponConfig weapon, int count, float spread)
    {
        float half = spread / 2f;

        for (int i = 0; i < count; i++)
        {
            float t = count == 1 ? 0.5f : (float)i / (count - 1);
            float angle = Mathf.Lerp(-half, half, t);

            var dir = Vector2.Right.Rotated(Mathf.DegToRad(angle));
            Spawn(dir, weapon);
        }
    }

    private void SpawnCircle(WeaponConfig weapon, int count)
    {
        for (int i = 0; i < count; i++)
        {
            float angle = (Mathf.Tau / count) * i;
            var dir = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

            Spawn(dir, weapon);
        }
    }
}