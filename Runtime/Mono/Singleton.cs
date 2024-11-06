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
        private static T _instance;

        protected virtual void Awake()
        {
            if (_instance != null)
            {
                Destroy(gameObject);
                return;
            }

            _instance = GetComponent<T>();
            transform.parent = null;
            DontDestroyOnLoad(this);
        }
    }
}
