using System.Collections.Generic;
using System.Linq;
using AceLand.Library.Attribute;
using UnityEngine;

namespace AceLand.Mono
{
    public class SingletonBuilder : MonoBehaviour
    {
        [Header("Setting")]
        [SerializeField] private SingletonBuilderProfile profile;
        private readonly List<string> _existingSingletons = new();

        [Header("Scene")]
        [SerializeField] private bool onSceneExitActions;
        [ConditionalShow("onSceneExitActions")]
        [SerializeField] private bool killSingletonsOnSceneExit;
        
        private void Awake()
        {
            HandleExistingSingletons();
            BuildNewSingletons();
            Finalization();
        }

        private void OnDestroy()
        {
            if (onSceneExitActions && killSingletonsOnSceneExit)
            {
                RemoveSingletonsInProfile();
            }
        }

        private void RemoveSingletonsInProfile()
        {
            foreach (var singleton in profile.Singletons)
            {
                var go = GameObject.Find(singleton.gameObject.name);
                if (go == null) continue;
                
                Destroy(go);
                Debug.Log($"{name} is destroyed");
            }
        }

        private void HandleExistingSingletons()
        {
            _existingSingletons.Clear();

            foreach (var singleton in FindObjectsByType(typeof(Singleton), FindObjectsSortMode.None).Cast<Singleton>())
                _existingSingletons.Add(singleton.gameObject.name);
        }

        private void BuildNewSingletons()
        {
            foreach (var singleton in profile.Singletons)
            {
                if (singleton == null)
                {
                    Debug.LogWarning($"Null Singleton is found in list");
                    continue;
                }
                if (_existingSingletons.Contains(singleton.gameObject.name))
                {
                    singleton.SceneInit();
                    Debug.Log($"{singleton.gameObject.name} is existed and initialized.");
                    continue;
                }

                var singletonObj = Instantiate(singleton.gameObject, Vector3.zero, Quaternion.identity, null);
                var objectName = singleton.gameObject.name;
                singletonObj.name = objectName;
                singletonObj.GetComponent<Singleton>().SceneInit();
                _existingSingletons.Add(objectName);
                Debug.Log($"{singletonObj.name} is instantiated and initialized.");
            }
        }

        private void Finalization()
        {
            Debug.Log("All Singletons is Loaded.");
        }
    }
}
