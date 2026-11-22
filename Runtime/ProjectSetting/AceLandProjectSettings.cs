using System;
using System.IO;
using AceLand.ProjectSetting;
using UnityEngine;

// ReSharper disable UnusedMember.Local

namespace AceLand.Library.ProjectSetting
{
    public enum SystemRoot
    {
        PersistentData, LocalAppData, RoamingAppData, Custom,
    }
    
    public class AceLandProjectSettings : ProjectSettings<AceLandProjectSettings>
    {
        // System root
        [SerializeField] private bool separateEditorAndBuild = true;
        [SerializeField] private SystemRoot systemRoot = SystemRoot.PersistentData;
        [SerializeField] private string customerSystemFolder = "c:";
        [SerializeField] private SystemRoot tempRoot = SystemRoot.PersistentData;
        [SerializeField] private string customerTempFolder = "c:";
        
        [SerializeField] private string systemRootPath;
        [SerializeField] private string tempRootPath;
        
        public string SystemRootPath => systemRootPath;
        public string TempRootPath => tempRootPath;
        
        private void OnEnable()
        {
#if UNITY_EDITOR
            EditorValidate();
#endif
        }
        
#if UNITY_EDITOR
        public void EditorValidate()
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
            
            var sRoot = GetPath(systemRoot, customerSystemFolder);
            var tRoot = GetPath(tempRoot, customerTempFolder);

#if UNITY_EDITOR
            systemRootPath = (systemRoot is SystemRoot.PersistentData, separateEditorAndBuild) switch
            {
                (true, false) => sRoot,
                (true, true) => Path.Combine(sRoot, "Editor"),
                (false, false) =>
                    Path.Combine(sRoot, Application.companyName, Application.productName),
                (false, true) => 
                    Path.Combine(sRoot, Application.companyName, Application.productName, "Editor"),
            };
            
            tempRootPath = (tempRoot is SystemRoot.PersistentData, separateEditorAndBuild) switch
            {
                (true, false) => Path.Combine(tRoot, "temp"),
                (true, true) => Path.Combine(tRoot, "Editor", "temp"),
                (false, false) =>
                    Path.Combine(tRoot, Application.companyName, Application.productName, "temp"),
                (false, true) => 
                    Path.Combine(tRoot, Application.companyName, Application.productName, "Editor", "temp"),
            };
            
            
#else
            systemRootPath = (systemRoot is SystemRoot.PersistentData) switch
            {
                true => sRoot,
                false => Path.Combine(sRoot, Application.companyName, Application.productName),
            };
            
            tempRootPath = (tempRoot is SystemRoot.PersistentData) switch
            {
                true => Path.Combine(tRoot, "temp"),
                false => Path.Combine(tRoot, Application.companyName, Application.productName, "temp"),
            };
#endif
        }

        private string GetPath(SystemRoot root, string cusFolder)
        {
            var path = root switch
            {
                SystemRoot.PersistentData => Application.persistentDataPath,
                SystemRoot.LocalAppData => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                SystemRoot.RoamingAppData => Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                SystemRoot.Custom => cusFolder + "\\",
                _ => Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)
            };
            return path.Replace('/', '\\');
        }
    }
}