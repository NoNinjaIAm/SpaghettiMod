using Terraria;
using Terraria.ModLoader;

namespace SpaghettiMod.Buffs
{
	public class MarinatedDebuff : ModBuff
	{

		public override void Update(NPC npc, ref int buffIndex) {
			npc.lifeRegen -= 50;
		}

	}
}