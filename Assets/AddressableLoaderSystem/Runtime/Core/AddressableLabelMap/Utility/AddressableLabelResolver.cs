using System;
using System.Collections.Generic;

namespace AddressableLoaderSystem.Runtime.AddressableLabelMap
{
    public static class AddressableLabelResolver
    {
        public static string GetLabel(string address)
        {
            return AddressableLabelMapAsset.Instance.TryGetLabel(address, out var label) ? label : null;
        }

        public static Dictionary<string, string> GetLabelsByType(Type type)
        {
            return AddressableLabelMapAsset.Instance.GetLabelsByType(type);
        }
    }
}