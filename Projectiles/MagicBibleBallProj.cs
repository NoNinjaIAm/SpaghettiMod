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
using Microsoft.CodeAnalysis;

namespace SpaghettiMod.Projectiles
{

    public class MagicBibleBallProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            ProjectileID.Sets.TrailCacheLength[Projectile.type] = 5; // The length of old position to be recorded
            ProjectileID.Sets.TrailingMode[Projectile.type] = 0; // The recording mode
            Main.projFrames[Projectile.type] = 3; //3 animation frames
        }
        public override void SetDefaults()
        {
            Projectile.width = 29; // The width of projectile hitbox
            Projectile.height = 29; // The height of projectile hitbox
            Projectile.scale = 1.3f;
            Projectile.aiStyle = 1; // The ai style of the projectile, please reference the source code of Terraria
            Projectile.friendly = true; // Can the projectile deal damage to enemies?
            Projectile.hostile = false; // Can the projectile deal damage to the player?
            Projectile.DamageType = ModContent.GetInstance<SpaghettiDamageClass>(); // Is the projectile shoot by a ranged weapon?
            Projectile.penetrate = 1; // How many monsters the projectile can penetrate. (OnTileCollide below also decrements penetrate for bounces as well)
            Projectile.timeLeft = 600; // The live time for the projectile (60 = 1 second, so 600 is 10 seconds)
            Projectile.alpha = 255; // The transparency of the projectile, 255 for completely transparent. (aiStyle 1 quickly fades the projectile in) Make sure to delete this if you aren't using an aiStyle that fades in. You'll wonder why your projectile is invisible.
            Projectile.light = 0.5f; // How much light emit around the projectile
            Projectile.ignoreWater = true; // Does the projectile's speed be influenced by water?
            Projectile.tileCollide = false; // Can the projectile collide with tiles?
            Projectile.extraUpdates = 1; // Set to above 0 if you want the projectile to update multiple time in a frame
            AIType = ProjectileID.Bullet; // Act exactly like default Bullet
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

        bool goingUp = true; //Is the projectile going up? (If false then we are going down)
        bool firstIteration = true; // Are we in the first instance of PostAI running?
        float initialYVel; // Savining the velocity of the projectile the moment it is created
        public override void PostAI()
        {
            base.PostAI();
            Projectile.rotation = 0.0f; //Don't rotate sprite

            // Saving initial velocity. Using it so that when bubble travels it accounts for this and doesn't have static ups and downs.
            if(firstIteration)
            {
                initialYVel = Projectile.velocity.Y;
                firstIteration = false;
            }
            
            if(goingUp) // Going up logic
            {
                Projectile.velocity.Y = Projectile.velocity.Y - 0.01f;
                if (Projectile.velocity.Y < (-0.35f + initialYVel)) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
                {
                    Projectile.velocity.Y = -0.35f + initialYVel;
                    goingUp = false;
                }
            }
            else // Going down logic
            {
                Projectile.velocity.Y = Projectile.velocity.Y + 0.01f;
                if (Projectile.velocity.Y > (0.35f + initialYVel)) // This check implements "terminal velocity". We don't want the projectile to keep getting faster and faster. Past 16f this projectile will travel through blocks, so this check is useful.
                {
                    Projectile.velocity.Y = 0.35f + initialYVel;
                    goingUp = true;
                }
            }
            
        }

        public override void AI()
        {
            // This is here to make a trail as the meatball is fired.
            int choice = Main.rand.Next(10);

            if(choice == 0)
            {
                Dust.NewDust(Projectile.position + new Vector2(0, 20), Projectile.width, Projectile.height, DustID.CrimsonPlants, Projectile.velocity.X * 0.1f, 1, 150, Color.Red, 1.3f);
            }

            // Loop between frames every ___ ticks
            if (++Projectile.frameCounter >= 45)
            {
	            Projectile.frameCounter = 0;
	            Projectile.frame = ++Projectile.frame % Main.projFrames[Projectile.type];
            }

        }


    }

    
}
