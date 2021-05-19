using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static Terraria.ModLoader.ModContent;
using static ChefMod.ChefUtils;
using ChefMod.FoodBuffs;

namespace ChefMod.Food
{
  public class Baguette : ModItem
  {
    public override void SetStaticDefaults()
    {
      DisplayName.SetDefault("Baguette");
      Tooltip.SetDefault("\"The French used these as a substitute for swords when they had a\nsteel shortage, shortly after the storming of the Bastille. They were hard enough to act as clubs.\"\n\"Hon hon hon, oui oui baguette!\"");
    }
    public override void SetDefaults()
    {
      item.CloneDefaults(ItemID.Mushroom);
      item.width = 52;
      item.height = 50;
      item.healLife = 30;
      item.potion = false;
    }
    public override bool UseItem(Player player)
    {
      player.AddBuff(BuffType<HighCarb>(), 180.InTicks());
      player.AddBuff(BuffID.PotionSickness, 30.InTicks());
      return true;
    }
  }
}