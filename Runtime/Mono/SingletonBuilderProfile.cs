using System.Collections.Generic;
using UnityEngine;

namespace AceLand.Mono
{
    [CreateAssetMenu(fileName = "Singleton Profile", menuName = "Profiles/Singleton Profile", order = 1)]
    public sealed class SingletonBuilderProfile : ScriptableObject
    {
        [SerializeReference] private List<Singleton> singletons;

        public IEnumerable<Singleton> Singletons => singletons;
        public int Count => singletons.Count;
    }
}
