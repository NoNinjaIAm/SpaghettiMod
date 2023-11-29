using SpaghettiMod.DamageClasses;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpaghettiMod.Items
{
    public class MegaMeatball : ModItem
    {
        public override void SetStaticDefaults()
        {
            Item.ResearchUnlockCount = 99;
        }

        public override void SetDefaults()
        {
            Item.damage = 12; // The damage for projectiles isn't actually 12, it actually is the damage combined with the projectile and the item together.
            Item.DamageType = ModContent.GetInstance<SpaghettiDamageClass>();
            Item.width = 16;
            Item.height = 16;
            Item.maxStack = Item.CommonMaxStack;
            Item.consumable = true; // This marks the item as consumable, making it automatically be consumed when it's used as ammunition, or something else, if possible.
            Item.knockBack = 2f;
            Item.value = 10;
            Item.rare = ItemRarityID.Green;
            Item.shoot = ModContent.ProjectileType<Projectiles.MegaMeatballProj>(); // The projectile that weapons fire when using this item as ammunition.
            Item.shootSpeed = 6f; // The speed of the projectile.
            Item.ammo = Item.type; // FIX ME: ADD THIS TO AMMO ID CLASS REFERENCE

        }

        // Please see Content/ExampleRecipes.cs for a detailed explanation of recipe creation.
        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ModContent.ItemType<Meatball>(), 10);
            recipe.AddTile(TileID.CookingPots);
            recipe.Register();

        }


    }
}