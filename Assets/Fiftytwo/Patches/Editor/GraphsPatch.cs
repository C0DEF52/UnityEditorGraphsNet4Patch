#if !( NET_2_0 || NET_STANDARD_2_0 || NET_2_0_SUBSET )

using System.ComponentModel;
using System.Reflection;
using UnityEditor.Graphs;
using Harmony;

namespace Fiftytwo
{
    [HarmonyPatch( typeof( Property ) )]
    [HarmonyPatch( "ConvertFromSingleValue" )]
    public class GraphsPatch
    {
        private static readonly MethodInfo GetConverter;

        static GraphsPatch ()
        {
            GetConverter = typeof( Property ).GetMethod( "GetConverter",
                BindingFlags.NonPublic | BindingFlags.Static );
        }

        private static bool Prefix ( ref string __result, Property __instance, object o )
        {
            var converter = ( TypeConverter )GetConverter.Invoke( null, new object[] { __instance.type } );
            __result = converter.ConvertToString( o );
            return false;
        }
    }
}

#endif
