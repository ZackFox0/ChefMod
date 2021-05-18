using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using System;

namespace ChefMod
{
  public static class TynUtils
  {
    public static Chef Tyn(this Player player) => player.GetModPlayer<Chef>();
    public static ChefGlobalNPC Tyn(this NPC npc) => npc.GetGlobalNPC<ChefGlobalNPC>();
    public static ChefGlobalItem Tyn(this Item item) => item.GetGlobalItem<ChefGlobalItem>();
    public static ChefGlobalProj Tyn(this Projectile proj) => proj.GetGlobalProjectile<ChefGlobalProj>();

    public static float InRadians(this float degrees) => MathHelper.ToRadians(degrees);
    public static float InDegrees(this float radians) => MathHelper.ToDegrees(radians);
    public static int InTicks(this int seconds) => seconds * 60;
    public static int InTicks(this float seconds) => (int)Math.Round(seconds * 60);

    public static Vector2 RandomPointInHitbox(this Rectangle hitbox)
    {
      Vector2 v = new Vector2();
      int semiAxisX = Main.rand.Next(hitbox.Left, hitbox.Right),
          semiAxisY = Main.rand.Next(hitbox.Top, hitbox.Bottom);
      v.X = semiAxisX;
      v.Y = semiAxisY;
      return v;
    }
    public static bool PercentChance(this int chance) => Main.rand.Next(100) <= chance;
    public static bool PercentChance(this float chance) => Main.rand.NextFloat(100f) <= chance;
    public static Vector2 RotateTo(this Vector2 v, float rotation)
    {
      float oldVRotation = v.ToRotation();
      return v.RotatedBy(rotation - oldVRotation);
    }
    public static bool IsInRadius(this Entity target, Vector2 center, float radius) => Vector2.Distance(center, target.position) <= radius;
    public static int GrabProjCount(int type) {
      int count = 0;
      foreach (Projectile proj in Main.projectile)
      {
        if (proj.type == type)
          count++;
      }
      return count;
    }
    public static void Talk(string message)
    {
      if (Main.netMode != NetmodeID.Server)
      {
        string text = Language.GetTextValue(message);
        Main.NewText(text, 241, 127, 82);
      }
      else
      {
        NetworkText text = NetworkText.FromKey(message);
        NetMessage.BroadcastChatMessage(text, new Color(241, 127, 82));
      }
    }
  }
}