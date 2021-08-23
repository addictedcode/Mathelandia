using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    [Scene] [SerializeField] private string[] m_scenes_to_load;

    public void OnPlayClick()
    {
        StartCoroutine(LoadScenes());
    }

    public void OnQuitClick()
    {
        Application.Quit();
    }

    IEnumerator LoadScenes()
    {
        Dictionary<string, AsyncOperation> async_ops = new Dictionary<string, AsyncOperation>(m_scenes_to_load.Length);
        foreach (string scene in m_scenes_to_load)
            async_ops[scene] = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        foreach (AsyncOperation ops in async_ops.Values)
        {
            yield return ops;
        }
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
