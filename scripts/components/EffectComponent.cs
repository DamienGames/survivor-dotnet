using Godot;
using System;

public partial class EffectComponent : Node
{
    public abstract partial class Effect : Resource
    {
        [Export] public int Priority = 0;
        [Export] public float Chance = 1.0f;
        [Export] public float Duration = 1.0f;

        public abstract void Apply(Node target);
    }
}
