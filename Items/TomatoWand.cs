using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace SpaghettiMod.Items
{
	public class TomatoWand : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.SpaghettiMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 45;
			Item.DamageType = DamageClass.Melee;
			Item.width = 30;
			Item.height = 30;
			Item.useTime = 35;
			Item.useAnimation = 35;
			Item.useStyle = 1;
			Item.knockBack = 6;
			Item.value = 10000;
			Item.rare = 3;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;
        }

		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}
	}
}