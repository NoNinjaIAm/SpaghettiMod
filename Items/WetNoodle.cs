using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpaghettiMod.Items
{
    internal class WetNoodle : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.width = 16;
            Item.height = 15;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.consumable = true;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.EatFood; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = false; // Whether or not you can hold click to automatically use it again.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.healLife = 5; // Heal when eat
        }
    }
}