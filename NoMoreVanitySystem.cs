using System.Reflection;
using MonoMod.Cil;
using MonoMod.RuntimeDetour.HookGen;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace tmlvanitiesbegone;

public class NoMoreVanitySystem : ModSystem
{
    internal delegate bool orig_TryGettingPatreonOrDevArmor(IEntitySource source, Player player);
    internal delegate bool hook_TryGettingPatreonOrDevArmor(orig_TryGettingPatreonOrDevArmor orig, IEntitySource source, Player player);
    
    internal static event hook_TryGettingPatreonOrDevArmor TryGettingPatreonOrDevArmor {
        add
        {
            HookEndpointManager.Add<hook_TryGettingPatreonOrDevArmor>(MethodBase.GetMethodFromHandle(typeof(Main).Assembly.GetType("Terraria.ModLoader.Default.ModLoaderMod").GetMethod("TryGettingPatreonOrDevArmor", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle), value);
        }
        remove
        {
            HookEndpointManager.Remove<hook_TryGettingPatreonOrDevArmor>(MethodBase.GetMethodFromHandle(typeof(Main).Assembly.GetType("Terraria.ModLoader.Default.ModLoaderMod").GetMethod("TryGettingPatreonOrDevArmor", BindingFlags.NonPublic | BindingFlags.Static).MethodHandle), value);
        }
    }

    public override void Load()
    {
        TryGettingPatreonOrDevArmor += (orig, source, player) =>
        {
            return false;
        };
    }
}