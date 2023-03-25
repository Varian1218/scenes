using System.Collections.Generic;

namespace Scenes
{
    public interface ISceneLoader
    {
        IEnumerator<T> LoadSceneAsync<T>(string sceneName) where T : class;
    }
}