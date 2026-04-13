# ⚡ Cyber Survivors (nome provisório)

Um jogo estilo *survivor-like* inspirado em Vampire Survivors, ambientado em um mundo **cyberpunk**, desenvolvido com **Godot 4 + C# (.NET)**.

---

## 🎮 Sobre o projeto

Cyber Survivors é um jogo onde o jogador enfrenta hordas de inimigos enquanto evolui suas armas automaticamente, combinando efeitos como:

- 🔥 Burn (queima)
- ☠ Poison (dano ao longo do tempo)
- ⚡ Shock (chain damage)
- 🧲 Knockback
- 🧠 Hacks digitais

O foco é criar um sistema **modular, escalável e orientado a dados**.

---

## 🚀 Principais features

- ✅ Sistema de armas baseado em **Resource**
- ✅ Combinação automática de armas (evolução)
- ✅ Sistema de **Effects plugável**
- ✅ Arquitetura baseada em **componentes**
- ✅ Suporte a múltiplos padrões de ataque:
  - Projectile
  - Beam
  - Orbit
  - Boomerang
  - Zone
  - Chain
- ✅ Sistema de **i-frame com feedback visual**
- 🔄 (WIP) Sistema de XP
- 🔄 (WIP) UI de upgrades

---

## 🧱 Arquitetura

O projeto segue um modelo **data-driven + component-based**.

### 🔹 WeaponConfig (Resource)

Define uma arma:
EnergyGlove,
Gun,
NeonBlade,
DroneSwarm,
EMPPulse,
RailgunShot,
OverheatCannon,
LaserGrid,
OrbitalSatellite,
Virus,
HologramDecoy,
SignalJammer,
AITurret = 12,
OverclockAura ,
Firewall,
LagField,
 
