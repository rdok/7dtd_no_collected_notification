using HarmonyLib;

namespace NoCollectedNotification.Harmony
{
    [HarmonyPatch(typeof(XUiC_CollectedItemList), nameof(XUiC_CollectedItemList.AddItemStack))]
    public static class Patch
    {
        private static readonly ILogger Logger = new Logger();

        public static bool Prefix(ItemStack _is, bool _bAddOnlyIfNotExisting = false)
        {
            if (_is?.itemValue?.ItemClass?.Name == null) return false;

            Logger.Info($"Disabling notification for {_is.itemValue.ItemClass.Name}");

            return false;
        }
    }
}