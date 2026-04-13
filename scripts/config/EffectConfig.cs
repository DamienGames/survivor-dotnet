using Godot;
using static System.Net.Mime.MediaTypeNames;

public abstract partial class Effect : Resource
{
    #region Exports

    [Export] protected float duration = 2f;
    [Export] public int Priority = 0;
    [Export] public float Chance = 1.0f;
    #endregion

    #region Métodos

    public abstract void Apply(Node target);
    #endregion

    public enum EffectPhase
    {
        OnHit,
        Control,
        Movement,
        DamageOverTime
    }
}


//1.Base Damage
//2. Multipliers (buffs/debuffs ofensivos)
//3. Defesa/Redução
//4. Crit
//5. Modificadores finais
//6. On-Hit Effects (Effects)