using Godot;

public partial class DamageRuntime : RefCounted
{
    public Node Source;
    public Node Target;
    public Vector2 Direction;

    public float BaseAmount;
    public float FinalAmount;
    public bool IsCritical;
    public int KnockbackForce;
    public int PullForce;

    public DamageRuntime(float amount, Node source = null, Node target = null)
    {
        BaseAmount = amount;
        FinalAmount = amount;
        Source = source;
        Target = target;
    }
}
