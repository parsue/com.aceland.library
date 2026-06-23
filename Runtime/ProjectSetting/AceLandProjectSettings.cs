using System;
using System.IO;
using AceLand.Library.Attribute;
using AceLand.ProjectSetting;
using UnityEngine;

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
        [SerializeField] private bool separateEditorAndBuild = true;
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

#if UNITY_EDITOR
        
        public void OnValidate()
        {
            UpdateSystemRoot();
        }
        
#endif

        internal void SetSystemRoot()
        {
            UpdateSystemRoot();
        }

        private void UpdateSystemRoot()
        {
            while (customerSystemFolder.EndsWith('\\') || customerSystemFolder.EndsWith('/'))
                customerSystemFolder = customerSystemFolder[..^1];
            while (customerTempFolder.EndsWith('\\') || customerTempFolder.EndsWith('/'))
                customerTempFolder = customerTempFolder[..^1];
            
            var sRoot = GetPath(systemRoot);
            var tRoot = GetPath(tempRoot);

#if UNITY_EDITOR
            systemRootPath = (systemRoot is SystemRoot.PersistentData, separateEditorAndBuild) switch
            {
                (true, false) => tRoot,
                (true, true) => Path.Combine(tRoot, "Editor"),
                (false, false) =>
                    Path.Combine(sRoot, Application.companyName, Application.productName),
                (false, true) => 
                    Path.Combine(sRoot, Application.companyName, Application.productName, "Editor"),
            };
            
            tempRootPath = (systemRoot is SystemRoot.PersistentData, separateEditorAndBuild) switch
            {
                (true, false) => Path.Combine(tRoot, "temp"),
                (true, true) => Path.Combine(tRoot, "Editor", "temp"),
                (false, false) =>
                    Path.Combine(tRoot, Application.companyName, Application.productName, "temp"),
                (false, true) => 
                    Path.Combine(sRoot, Application.companyName, Application.productName, "Editor", "temp"),
            };
#else
            systemRootPath = (systemRoot is SystemRoot.PersistentData) switch
            {
                true => tRoot,
                false => Path.Combine(sRoot, Application.companyName, Application.productName),
            };
            
            tempRootPath = (systemRoot is SystemRoot.PersistentData) switch
            {
                true => Path.Combine(tRoot, "temp"),
                false => Path.Combine(tRoot, Application.companyName, Application.productName, "temp"),
            };
#endif
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