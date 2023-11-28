
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.GameContent.UI;
using Terraria.ID;
using Terraria.ModLoader;
using SpaghettiMod.DamageClasses;

namespace SpaghettiMod.Items
{
	public class BakedSpaghettiPickaxe : ModItem
	{
		public override void SetDefaults() {
			Item.damage = 15;
			Item.DamageType =  ModContent.GetInstance<SpaghettiDamageClass>();
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 5;
			Item.value = Item.buyPrice(gold: 20); // Buy this item for one gold - change gold to any coin and change the value to any number <= 100
			Item.rare = ItemRarityID.Green;
			Item.UseSound = SoundID.Item1;
			Item.autoReuse = true;

			Item.pick = 70; // How strong the pickaxe is, see https://terraria.wiki.gg/wiki/Pickaxe_power for a list of common values
			Item.attackSpeedOnlyAffectsWeaponAnimation = true; // Melee speed affects how fast the tool swings for damage purposes, but not how fast it can dig
		}
    
        public override void MeleeEffects(Player player, Rectangle hitbox) 
        {
			if (Main.rand.NextBool(10)) 
            {
				Dust.NewDust(new Vector2(hitbox.X, hitbox.Y), hitbox.Width, hitbox.Height, Dust.lavaBubbles);
			}
	    }

        public override void AddRecipes() {
			Recipe recipe = CreateRecipe();
				recipe.AddIngredient(ModContent.ItemType<WetNoodlePickaxe>(), 10);
				recipe.AddIngredient(ItemID.Wood, 10);
                recipe.AddTile(TileID.WorkBenches);
				recipe.Register();
		}
    }
}