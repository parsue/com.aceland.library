using System;
using System.Diagnostics;
using System.IO;
using AceLand.Library.Attribute;
using UnityEngine;
using Debug = UnityEngine.Debug;
// ReSharper disable UnusedMember.Local

namespace AceLand.Library.ProjectSetting
{
    internal enum SystemRoot
    {
        PersistentData, LocalAppData, RoamingAppData, Custom,
    }
    
    public class AceLandProjectSettings : ProjectSettings<AceLandProjectSettings>
    {
        [Header("System Folders")]
        [SerializeField] private SystemRoot systemRoot = SystemRoot.LocalAppData;
        [ConditionalShow("systemRoot", SystemRoot.Custom)]
        [SerializeField] private string customerFolder = "c:";
        [SerializeField, ReadOnlyField] private string systemRootPath;
        [SerializeField, ReadOnlyField] private string tempRootPath;
        
        public string SystemRootPath => systemRootPath;
        public string TempRootPath => tempRootPath;

        public void OnValidate()
        {
            while (customerFolder.EndsWith('\\') || customerFolder.EndsWith('/'))
                customerFolder = customerFolder[..^1];
            
            var root = systemRoot switch
            {
                SystemRoot.PersistentData => Application.persistentDataPath,
                SystemRoot.LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                SystemRoot.RoamingAppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                SystemRoot.Custom => customerFolder + "\\",
                _ => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            };
            root = root.Replace('/', '\\');

            systemRootPath = Path.Combine(root, Application.companyName, Application.productName);
            tempRootPath = Path.Combine(systemRootPath, "temp");
        }
    }
}