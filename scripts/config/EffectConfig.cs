using Godot;

[GlobalClass]
public abstract partial class EffectConfig : Resource
{
    [Export] public float Duration = 2f;
    [Export] public int Priority = 0;
    [Export] public float Chance = 1.0f;

    public abstract EffectInstance CreateInstance();
}