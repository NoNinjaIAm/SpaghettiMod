using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using SpaghettiMod.DamageClasses;
using Microsoft.Xna.Framework;
using Terraria.DataStructures;
using SpaghettiMod.Projectiles;

namespace SpaghettiMod.Items
{
	public class WetNoodleSword : ModItem
	{
        // The Display Name and Tooltip of this item can be edited in the Localization/en-US_Mods.SpaghettiMod.hjson file.

		public override void SetDefaults()
		{
			Item.damage = 1;
			Item.DamageType = ModContent.GetInstance<SpaghettiDamageClass>();
			Item.width = 32;
			Item.height = 32;
			Item.useTime = 20;
			Item.useAnimation = 20;
			Item.useStyle = ItemUseStyleID.Swing;
			Item.knockBack = 0;
			Item.value = 1;
			Item.rare = ItemRarityID.White;
			Item.UseSound = SoundID.Item1; //FIX ME: SLAP SOUND
			Item.autoReuse = true;
        }

        // FIX ME: CHANGE RECIPE
		public override void AddRecipes()
		{
			Recipe recipe = CreateRecipe();
			recipe.AddIngredient(ItemID.DirtBlock, 3);
			recipe.AddTile(TileID.WorkBenches);
			recipe.Register();
		}

        public override void UseAnimation(Player player)
        {
            base.UseAnimation(player);
			int i = 0;

			if(player.whoAmI == Main.myPlayer)
			{
			for(i=0; i < 10; i++)
				{
					Vector2 velocityOffset = new Vector2(Main.rand.Next(0, 21) * player.direction, Main.rand.Next(-20, 5)), newVector = Vector2.Add(velocityOffset, player.velocity);

					Dust.NewDust(player.position, player.width, player.height, DustID.Water, newVector.X, newVector.Y, 150, Color.SkyBlue, 1.5f);
				}
			}
			
        }


    }
}