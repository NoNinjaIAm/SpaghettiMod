using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;
using SpaghettiMod.DamageClasses;
using SpaghettiMod.Buffs;

namespace SpaghettiMod.Projectiles
{

    public class MeatballProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
        }
        public override void SetDefaults()
        {
            Projectile.width = 12; // The width of projectile hitbox
            Projectile.height = 12; // The height of projectile hitbox
            Projectile.scale = 1.7f;
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<MeatballDamageClass>(); // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = true; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame

            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
        }

        public override void OnHitNPC(NPC target, NPC.HitInfo hit, int damage) {
			// These effects act on a hit happening, so they should go here.
			// Buffs added locally are automatically synced to the server and other players in multiplayer
			target.AddBuff(ModContent.BuffType<MarinatedDebuff>(), 600);
		}

        public override void OnKill(int timeLeft)
        {
            // Meatball Destory Dust
            base.OnKill(timeLeft);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SnowBlock, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, Color.Brown, 3f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SnowBlock, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.1f, 150, Color.Brown, 2f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SnowBlock, Projectile.velocity.X * 0.3f, Projectile.velocity.Y * 0.3f, 150, Color.Red, 2.3f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SnowBlock, Projectile.velocity.X * 0.4f, Projectile.velocity.Y * 0.1f, 150, Color.Brown, 2.6f);
            Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, DustID.SnowBlock, Projectile.velocity.X * 0.1f, Projectile.velocity.Y * 0.4f, 150, Color.Brown, 1.6f);


            // Sound Plays
            Terraria.Audio.SoundEngine.PlaySound(SoundID.Item167, Projectile.position);
        }

        public override void PostAI()
        {
            // Gravity
            base.PostAI();
            Projectile.velocity.Y = Projectile.velocity.Y + 0.1f; // 0.1f for arrow gravity, 0.4f for knife gravity
            if (Projectile.velocity.Y > 16f) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
            {
                Projectile.velocity.Y = 16f;
            }
        }

        public override void AI()
        {
            // This is here to make a trail as the meatball is fired.
            int choice = Main.rand.Next(5);

            if(choice == 0)
            {
                Dust.NewDust(Projectile.position, Projectile.width, Projectile.height, 125, Projectile.velocity.X * 0.25f, Projectile.velocity.Y * 0.25f, 150, Color.Red, 1.3f);
            }
        }

    }

    
}

