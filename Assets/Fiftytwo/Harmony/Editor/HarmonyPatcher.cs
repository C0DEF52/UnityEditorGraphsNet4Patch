using Harmony;
using UnityEditor;

namespace Fiftytwo
{
    [InitializeOnLoad]
    public static class HarmonyPatcher
    {
        public const string HarmonyID = "com.fiftytwo.unity-editor-patches";

        static HarmonyPatcher ()
        {
            Instance = HarmonyInstance.Create( HarmonyID );
            Instance.PatchAll( typeof( HarmonyPatcher ).Assembly );
        }

        public static HarmonyInstance Instance { get; private set; }
    }
}
