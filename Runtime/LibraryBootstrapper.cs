using System;
using AceLand.Library.Utils;
using UnityEngine;

namespace AceLand.Library
{
    internal static class LibraryBootstrapper
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initialization()
        {
            Helper.StartUpTime = DateTime.Now;
        }
    }
}