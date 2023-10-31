using Terraria;
using Terraria.ModLoader;
using SpaghettiMod.GlobalNPCs;

namespace SpaghettiMod.Buffs
{
	public class MarinatedDebuff : ModBuff
	{

		public const int DamageMultiplier = 200;

		public override void Update(NPC npc, ref int buffIndex) {
			npc.GetGlobalNPC<DamageModificationGlobalNPC>().marinatedDebuff = true;
		}

	}
}