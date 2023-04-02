using System.Collections.Generic;
using UnityEngine;

namespace Scenes
{
    public class ScriptableObjectSceneLoader : ScriptableObject, ISceneLoader
    {
        private ISceneLoader _impl;

        public ISceneLoader Impl
        {
            set => _impl = value;
        }

        public IEnumerator<T> LoadSceneAsync<T>(string sceneName) where T : class
        {
            return _impl.LoadSceneAsync<T>(sceneName);
        }
    }
}