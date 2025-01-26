using UnityEngine;

namespace AceLand.Library.Mono
{
    public abstract class Singleton : MonoBehaviour
    {
        public virtual void SceneInit()
        {
            // noop
        }
    }
    
    public abstract class Singleton<T> : Singleton
        where T : Singleton<T>
    {
        public static T Instance { get; private set; }

        protected virtual void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = GetComponent<T>();
            transform.parent = null;
            DontDestroyOnLoad(this);
        }
    }
}
