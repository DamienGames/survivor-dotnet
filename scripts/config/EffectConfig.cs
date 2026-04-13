using Godot;

public abstract partial class Effect : Resource
{
    #region Exports

    [Export] protected float duration = 2f;
    #endregion

    #region Métodos
    public abstract void Apply(Node target);
    #endregion
}