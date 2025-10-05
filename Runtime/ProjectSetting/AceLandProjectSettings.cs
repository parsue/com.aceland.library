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
        [SerializeField] private SystemRoot systemRoot = SystemRoot.PersistentData;
        [ConditionalShow("systemRoot", SystemRoot.Custom)]
        [SerializeField] private string customerSystemFolder = "c:";
        [SerializeField] private SystemRoot tempRoot = SystemRoot.PersistentData;
        [ConditionalShow("tempRoot", SystemRoot.Custom)]
        [SerializeField] private string customerTempFolder = "c:";
        
        [SerializeField, ReadOnlyField] private string systemRootPath;
        [SerializeField, ReadOnlyField] private string tempRootPath;
        
        public string SystemRootPath => systemRootPath;
        public string TempRootPath => tempRootPath;

        public void OnValidate()
        {
            while (customerSystemFolder.EndsWith('\\') || customerSystemFolder.EndsWith('/'))
                customerSystemFolder = customerSystemFolder[..^1];
            while (customerTempFolder.EndsWith('\\') || customerTempFolder.EndsWith('/'))
                customerTempFolder = customerTempFolder[..^1];
            
            var sRoot = GetPath(systemRoot);
            var tRoot = GetPath(tempRoot);

            systemRootPath = systemRoot is SystemRoot.PersistentData
                ? tRoot
                : Path.Combine(sRoot, Application.companyName, Application.productName);
            tempRootPath = tempRoot is SystemRoot.PersistentData
                ? Path.Combine(tRoot, "temp")
                : Path.Combine(tRoot, Application.companyName, Application.productName, "temp");
        }

        private string GetPath(SystemRoot root)
        {
            var path = root switch
            {
                SystemRoot.PersistentData => Application.persistentDataPath,
                SystemRoot.LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                SystemRoot.RoamingAppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                SystemRoot.Custom => customerSystemFolder + "\\",
                _ => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            };
            return path.Replace('/', '\\');
        }
    }
}