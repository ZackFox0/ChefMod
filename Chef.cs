using Terraria;
using Terraria.ModLoader;

namespace ChefMod
{
  public class Chef : ModPlayer
  {
    public bool highCarb;
    public override void ResetEffects()
    {
      highCarb = false;
    }
    public override void NaturalLifeRegen(ref float regen)
    {
      if (highCarb) regen += 2;
    }
  }
}