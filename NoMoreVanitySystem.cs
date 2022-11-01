using System;
using System.Reflection;
using MonoMod.RuntimeDetour.HookGen;
using Terraria;
using Terraria.DataStructures;
using Terraria.ModLoader;

namespace tmlvanitiesbegone;

public class NoMoreVanitySystem : ModSystem
{
    public override void Load() {
        Type modLoaderMod = typeof(Main).Assembly.GetType("Terraria.ModLoader.Default.ModLoaderMod");
        MethodInfo tryGetMethod = modLoaderMod?.GetMethod("TryGettingPatreonOrDevArmor", BindingFlags.NonPublic | BindingFlags.Static);
        HookEndpointManager.Add(tryGetMethod, (IEntitySource _, Player _) => false);
    }
}