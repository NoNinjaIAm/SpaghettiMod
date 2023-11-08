using SpaghettiMod.DamageClasses;
using SpaghettiMod.Projectiles;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Enums;

namespace SpaghettiMod.Items
{
	public class TomatoWand : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.SpaghettiMod.hjson file.

		public override void SetStaticDefaults() {
			Item.staff[Type] = true; // This makes the useStyle animate as a staff instead of as a gun.
		}

		public override void SetDefaults() {
			// DefaultToStaff handles setting various Item values that magic staff weapons use.
			// Hover over DefaultToStaff in Visual Studio to read the documentation!
			Item.DefaultToStaff(ModContent.ProjectileType<TomatoSauceProj>(), 16, 10, 5);

			// Customize the UseSound. DefaultToStaff sets UseSound to SoundID.Item43, but we want SoundID.Item20
			Item.UseSound = SoundID.Item20;

			// Set damage and knockBack
			Item.SetWeaponValues(1, 0);

			// Set rarity and value
			Item.SetShopValues(ItemRarityColor.Green2, 10000);

			Item.DamageType = ModContent.GetInstance<SpaghettiDamageClass>();
		}

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 3);
			recipe.AddIngredient(ModContent.GetInstance<Tomato>(), 1);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}