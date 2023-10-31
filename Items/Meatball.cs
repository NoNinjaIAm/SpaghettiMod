using SpaghettiMod.Buffs;
using SpaghettiMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpaghettiMod.Items
{
    public class Meatball : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = ModContent.GetInstance<MeatballDamageClass>();
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 2f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<Projectiles.MeatballProj>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 6f; // The speed of the projectile.
            Item.ammo = Item.type; // FIX ME: ADD THIS TO AMMO ID CLASS REFERENCE

            // This code makes it shootable without a Meatball Canon
            Item.useStyle = ItemUseStyleID.Swing; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.noMelee = true; // So the item's animation doesn't do damage.
            Item.useTime = 40; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 40; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.scale = 0f; // Makes meatball item invisible when throwing


        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.RottenChunk, 2);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();

            Recipe recipe2 = CreateRecipe();
            recipe2.AddIngredient(ItemID.Vertebrae, 2);
            recipe2.AddTile(TileID.CookingPots);
            recipe2.Register();
        }


    }
}