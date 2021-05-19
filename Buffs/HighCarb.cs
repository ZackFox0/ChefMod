using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using static ChefMod.ChefUtils;

namespace ChefMod.FoodBuffs
{
  public class HighCarb : ModBuff
  {
    public override void SetDefaults()
    {
      DisplayName.SetDefault("High-Carb");
      Description.SetDefault("Increased energy potential, increasing movement speed 10% and health regen +2");
    }

    public override void Update(Player player, ref int buffIndex)
    {
      player.moveSpeed *= 1.1f;
      player.Chef().highCarb = true;
    }
  }
}