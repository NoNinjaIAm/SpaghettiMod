using Terraria.ID;
using Terraria.ModLoader;
using SpaghettiMod.Items;
using System.Linq;
using Terraria.GameContent.ItemDropRules;
using Terraria;

namespace ExampleMod.Common.GlobalNPCs
{
    // This file shows numerous examples of what you can do with the extensive NPC Loot lootable system.
    // You can find more info on the wiki: https://github.com/tModLoader/tModLoader/wiki/Basic-NPC-Drops-and-Loot-1.4
    // Despite this file being GlobalNPC, everything here can be used with a ModNPC as well! See examples of this in the Content/NPCs folder.
    public class NpcDrop : GlobalNPC
    {
        // ModifyNPCLoot uses a unique system called the ItemDropDatabase, which has many different rules for many different drop use cases.
        // Here we go through all of them, and how they can be used.
        // There are tons of other examples in vanilla! In a decompiled vanilla build, GameContent/ItemDropRules/ItemDropDatabase adds item drops to every single vanilla NPC, which can be a good resource.

        public override void ModifyNPCLoot(NPC npc, NPCLoot npcLoot)
        {
            // Blue Slime Drops Meatballs
            if (npc.type == NPCID.BlueSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Meatball>(), 1));
            }

            // Red Slime Drops Tomatos
            // Doesn't work lolol (red slimes in terrraia are also called blue slimes??)
            if (npc.type == NPCID.RedSlime)
            {
                npcLoot.Add(ItemDropRule.Common(ModContent.ItemType<Tomato>(), 1));
            }
        }
    }
}
