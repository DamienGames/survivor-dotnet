using Godot;
using System.Collections.Generic;

public partial class EffectComponent : Node
{
    private List<EffectInstance> _effects = new();

    public void ApplyEffect(EffectConfig config, Node target)
    {
        if (GD.Randf() > config.Chance)
            return;

        var instance = config.CreateInstance();
        instance.Init(target, config.Duration);

        _effects.Add(instance);
    }

    public override void _Process(double delta)
    {
        for (int i = _effects.Count - 1; i >= 0; i--)
        {
            var effect = _effects[i];
            effect.Update(delta);

            // simples: remove quando acabar
            // (você pode melhorar isso depois)
        }
    }
}