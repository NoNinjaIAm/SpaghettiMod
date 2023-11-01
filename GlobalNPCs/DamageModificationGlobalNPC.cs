using SpaghettiMod.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using SpaghettiMod.DamageClasses;

namespace SpaghettiMod.GlobalNPCs
{
	internal class DamageModificationGlobalNPC : GlobalNPC
	{
		public override bool InstancePerEntity => true;
		public bool marinatedDebuff;

		public override void ResetEffects(NPC npc) {
			marinatedDebuff = false;
		}

		public override void ModifyIncomingHit(NPC npc, ref NPC.HitModifiers modifiers) {
			if (marinatedDebuff && modifiers.DamageType == ModContent.GetInstance<SpaghettiDamageClass>()) {
				// The if statement checks if the debuff is on the enemy and if the incoming damage is meatball damage
				modifiers.SourceDamage *= MarinatedDebuff.DamageMultiplier;
				// The source damage is multiplied by the damage multiplier located in the marinated debuff
			}
		}

		public override void DrawEffects(NPC npc, ref Color drawColor) {
			// This simple color effect indicates that the buff is active
			if (marinatedDebuff) {
				drawColor.G = 0;
			}
		}
	}
}