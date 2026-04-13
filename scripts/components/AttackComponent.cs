using Godot;

public partial class AttackComponent : Node
{
	[Export] public WeaponConfig Weapon;
	[Export] public Node2D Owner;

	[Export] public ProjectileSpawner ProjectileSpawner;
	[Export] public MeleeAttack Melee;
	[Export] public AreaAttack Area;

	private float _cooldown;

	public override void _Process(double delta)
	{
		if (_cooldown > 0)
			_cooldown -= (float)delta;
	}

	public void TryAttack()
	{
		if (_cooldown > 0 || Weapon == null)
			return;

		switch (Weapon.Pattern)
		{
			case WeaponConfig.AttackPattern.Hit:
			case WeaponConfig.AttackPattern.Arc:
				Melee.Execute(Weapon);
				break;

			case WeaponConfig.AttackPattern.Projectile:
			case WeaponConfig.AttackPattern.Boomerang:
			case WeaponConfig.AttackPattern.Bounce:
				ProjectileSpawner.Execute(Weapon);
				break;

			case WeaponConfig.AttackPattern.Pulse:
			case WeaponConfig.AttackPattern.Zone:
			case WeaponConfig.AttackPattern.Aura:
				Area.Execute(Weapon);
				break;

			//  ESPECIAIS (implementa depois)
			case WeaponConfig.AttackPattern.Beam:
			case WeaponConfig.AttackPattern.Orbit:
			case WeaponConfig.AttackPattern.Rain:
			case WeaponConfig.AttackPattern.Chain:
			case WeaponConfig.AttackPattern.Trap:
			case WeaponConfig.AttackPattern.Dash:
			case WeaponConfig.AttackPattern.Repeat:
			case WeaponConfig.AttackPattern.Binary:
				GD.Print($"Pattern ainda não implementado: {Weapon.Pattern}");
				break;
			default:
				GD.PrintErr($"Pattern desconhecido: {Weapon.Pattern}");
				break;
		}

		_cooldown = Weapon.Cooldown;
	}
}
