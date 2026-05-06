using Godot;

using static StatsComponent;
public abstract partial class EffectRuntime : RefCounted
{
    protected Node _target;
    protected StatsComponent _stats;

    protected float _duration;
    protected float _timer;

    public void Init(Node target, float duration)
    {
        _target = target;
        _duration = duration;
        _timer = duration;
        _stats = target.GetNodeOrNull<StatsComponent>("StatsComponent");
        OnStart();
    }

    public void Update(double delta)
    {
        _timer -= (float)delta;

        OnUpdate(delta);

        if (_timer <= 0)
            OnEnd();
    }
    protected virtual void OnUpdate(double delta)
    {
    }

    protected virtual void OnStart()
    {
        _stats.AddModifier(this, StatType.Damage, 10);
    }

    protected virtual void OnEnd()
    {
        _stats.RemoveBySource(this);
    }
}