using Godot;
using Godot.Collections;

[GlobalClass]
public partial class WeaponConfig : Resource
{
	#region Exports

	[ExportGroup("Base")]
	[Export] public string Id;
	[Export] public string DisplayName;

	[ExportGroup("Combat")]
	[Export] public float Damage = 10;
	[Export] public float Cooldown = 1f;
	[Export] public float Range = 100f;
	[Export] public float CriticalMultiplier = 1f;
	[Export] public int KnockbackForce = 0;
	[Export] public int Pullforce = 0;

	[ExportGroup("Behavior")]
	[Export] public WeaponType Type;
	[Export] public AttackPattern Pattern;
	[Export] public AttackShape Shape;

	[ExportGroup("Visual")]
	[Export] public Texture2D DisplayIcon;
	[Export] public PackedScene ProjectileScene;

	[ExportGroup("Effects")]
	[Export] public Array<EffectConfig> Effects;
	#endregion

	#region Enums

	public enum WeaponType
	{
		None,
		Ranged,
		Melee,
		Summon,
		Area
	}
	public enum AttackPattern
	{
		Hit,            // linha (melee)
		Arc,            // arco (melee)
		Projectile,     // tiro linha
		Beam,           // laser linha
		Orbit,          // girando ao redor
		Boomerang,      // vai e volta
		Rain,           // chuva
		Zone,           // área fixa
		Pulse,          // explosão
		Chain,          // salto      
		Bounce,         // ricochete      
		Aura,           // ao redor      
		Trap,           // fixa 
		Dash,           // em movimento 
		Repeat,          // repetição
		Binary          // alternado
	}
	public enum AttackShape
	{
		Line,
		Cone,
		Circle,
		Area,
		AroundPlayer
	}
	#endregion
}
