using Godot;

public partial class AreaAttack : Node
{
    [Export] public Node2D Owner;

    public void Execute(WeaponConfig weapon)
    {
        GD.Print("Área executada");
    }
}