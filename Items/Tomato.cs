using SpaghettiMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpaghettiMod.Items
{
    internal class Tomato : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 3; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = ModContent.GetInstance<SpaghettiDamageClass>();
            Item.knockBack = 0.5f;
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.consumable = true;
            Item.useAnimation = 12;
            Item.useStyle = ItemUseStyleID.Swing; // How you use the item (swinging, holding out, etc.)
            Item.useTime = 30; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 30; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.scale = 0f; // Makes meatball item invisible when throwing
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.shootSpeed = 8f; // The speed of the projectile.
            Item.shoot = ModContent.ProjectileType<Projectiles.TomatoProj>();
        }
    }
}
