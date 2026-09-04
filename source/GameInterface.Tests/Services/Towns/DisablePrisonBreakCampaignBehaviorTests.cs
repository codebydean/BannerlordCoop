using Common;
using GameInterface.Services.Towns.Patches.Disabled;
using Xunit;

namespace GameInterface.Tests.Services.Towns;

/// <summary>
/// Prison break events must be registered on clients so the "Start Jailbreak"
/// menu option is available, while remaining disabled on the server.
/// </summary>
public class DisablePrisonBreakCampaignBehaviorTests
{
    [Theory]
    [InlineData(false, true)]
    [InlineData(true, false)]
    public void RegisterEventsPrefix_AllowsOnlyClientRegistration(bool isServer, bool expected)
    {
        bool previousIsServer = ModInformation.IsServer;

        try
        {
            ModInformation.IsServer = isServer;

            Assert.Equal(expected, DisablePrisonBreakCampaignBehavior.Prefix());
        }
        finally
        {
            ModInformation.IsServer = previousIsServer;
        }
    }
}