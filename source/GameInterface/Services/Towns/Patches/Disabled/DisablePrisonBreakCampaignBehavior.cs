using Common;
using HarmonyLib;
using SandBox.CampaignBehaviors;

namespace GameInterface.Services.Towns.Patches.Disabled;

[HarmonyPatch(typeof(PrisonBreakCampaignBehavior))]
internal class DisablePrisonBreakCampaignBehavior
{
    [HarmonyPatch(nameof(PrisonBreakCampaignBehavior.RegisterEvents))]
    internal static bool Prefix() => ModInformation.IsClient;
}
