using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace Scenes
{
    public class SceneLoader : ISceneLoader
    {
        private readonly Dictionary<string, Type> _types = new();

        public void Add<TInterface, TClass>() where TClass : MonoBehaviour, TInterface
        {
            _types.Add(GetHash<TInterface>(), typeof(TClass));
        }

        private static string GetHash<T>()
        {
            return typeof(T).Name;
        }

        public IEnumerator<T> LoadSceneAsync<T>(string sceneName) where T : class
        {
            var asyncOperation = SceneManager.LoadSceneAsync(sceneName);
            while (!asyncOperation.isDone)
            {
                yield return null;
            }

            yield return Object.FindObjectOfType(_types[GetHash<T>()]) as T;
        }
    }
}