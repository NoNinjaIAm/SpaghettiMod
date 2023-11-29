using SpaghettiMod.Buffs;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpaghettiMod.DamageClasses;
using System.Numerics;

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
				// Change color
				drawColor.R = 255;
				drawColor.G = 0;
				drawColor.B = 0;

				// Marinated dust
				int choice = Main.rand.Next(5);
           		if(choice == 0)
            	{
					Dust.NewDust(npc.position, npc.width, npc.height, DustID.BloodWater, 0.0f, -4.0f, 150, Color.Red, 1.7f);
				}
			}
		}
		
	}
}