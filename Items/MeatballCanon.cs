using Terraria.ID;
using Terraria.ModLoader;
using Terraria;
using Microsoft.Xna.Framework;
using Terraria.Audio;
using SpaghettiMod.DamageClasses;

namespace SpaghettiMod.Items
{

    public class MeatballCanon : ModItem 
    {
        public override void SetDefaults()
        {
            Item.width = 62; // Hitbox width of the item.
            Item.height = 32; // Hitbox height of the item.
            Item.scale = 1.1f;
            Item.rare = ItemRarityID.Blue; // The color that the item's name will be in-game.

            // Use Properties
            Item.useTime = 30; // The item's use time in ticks (60 ticks == 1 second.)
            Item.useAnimation = 30; // The length of the item's use animation in ticks (60 ticks == 1 second.)
            Item.useStyle = ItemUseStyleID.Shoot; // How you use the item (swinging, holding out, etc.)
            Item.autoReuse = true; // Whether or not you can hold click to automatically use it again.
            Item.UseSound = SoundID.Item11; // The sound that this item plays when used.

            // Weapon Properties
            Item.DamageType = ModContent.GetInstance<SpaghettiDamageClass>(); // Sets the damage type to ranged.
            Item.damage = 35; // Sets the item's damage. Note that projectiles shot by this weapon will use its and the used ammunition's damage added together.
            Item.knockBack = 5f; // Sets the item's knockback. Note that projectiles shot by this weapon will use its and the used ammunition's knockback added together.
            Item.noMelee = true; // So the item's animation doesn't do damage.

            // Gun Properties
            Item.shoot = ProjectileID.PurificationPowder; // For some reason, all the guns in the vanilla source have this.
            Item.shootSpeed = 4f; // The speed of the projectile (measured in pixels per frame.)

            // FIX ME: ADD THIS TO AMMO ID CLASS REFERENCE
            Item.useAmmo = ModContent.ItemType<Meatball>(); // The "ammo Id" of the ammo item that this weapon uses. Ammo IDs are magic numbers that usually correspond to the item id of one item that most commonly represent the a
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            recipe.AddIngredient(ItemID.DirtBlock, 3);
            recipe.AddTile(TileID.WorkBenches);
            recipe.Register();
        }

        // 
        public override Vector2? HoldoutOffset()
        {
            return new Vector2(0.5f, -2.5f);
        }

    }

}

