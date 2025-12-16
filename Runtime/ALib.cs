using System.Collections.Generic;
using System.IO;
using AceLand.Library.Json.Converters;
using AceLand.Library.ProjectSetting;
using Newtonsoft.Json;
using UnityEngine;

namespace AceLand.Library
{
    public static partial class ALib
    {
        internal static AceLandProjectSettings ProjectSettings
        {
            get
            {
                _projectSettings ??= Resources.Load<AceLandProjectSettings>(nameof(AceLandProjectSettings));
                return _projectSettings;
            }
        }
        private static AceLandProjectSettings _projectSettings;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterAssembliesLoaded)]
        private static void Initialize()
        {
            Directory.CreateDirectory(SystemRootPath);
            Directory.CreateDirectory(TempRootPath);
        }
        
        private static readonly List<JsonConverter> converters = new()
        {
            new ColorConverter(), new GradientConverter(), new AnimationCurveConverter(),
            new Vector2Converter(), new Vector3Converter(), new Vector4Converter(),
            new Vector2IntConverter(), new Vector3IntConverter(), new QuaternionConverter(),
            new BoundsConverter(), new BoundsIntConverter(), new Matrix4X4Converter(),
            new Hash128Converter(), new LayerMaskConverter(),
            new RectIntConverter(), new RectConverter(),
            new NativeFloat2Converter(), new NativeFloat3Converter(), new NativeFloat4Converter(),
            new NativeQuaternionConverter(),
            new NativeFloat2X2Converter(), new NativeFloat2X3Converter(), new NativeFloat2X4Converter(), 
            new NativeFloat3X2Converter(), new NativeFloat3X3Converter(), new NativeFloat3X4Converter(),
            new NativeFloat4X2Converter(), new NativeFloat4X3Converter(), new NativeFloat4X4Converter(),
        };
    }
}