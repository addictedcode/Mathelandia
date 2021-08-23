using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class StageSelect : MonoBehaviour
{
    [SerializeField] private GameObject prefab_button;
    [SerializeField] private Transform stageselect_panel;
    [Scene] [SerializeField] private string[] m_scene_stages;
    [Scene] [SerializeField] private string[] m_scenes_to_load;

    private void Awake()
    {
        foreach (string scene in m_scene_stages)
        {
            GameObject newButton = Instantiate(prefab_button, stageselect_panel);
            TMP_Text text = newButton.GetComponentInChildren<TMP_Text>();
            Button btn = newButton.GetComponent<Button>();
            btn.onClick.AddListener(() => { StartCoroutine(LoadScenes(scene)); });
            text.text = scene;
        }
    }

    IEnumerator LoadScenes(string stage)
    {
        Dictionary<string, AsyncOperation> async_ops = new Dictionary<string, AsyncOperation>(m_scenes_to_load.Length);
        async_ops[stage] = SceneManager.LoadSceneAsync(stage, LoadSceneMode.Additive);
        foreach (string scene in m_scenes_to_load)
            async_ops[scene] = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
        foreach (AsyncOperation ops in async_ops.Values)
        {
            yield return ops;
        }
        SceneManager.UnloadSceneAsync(gameObject.scene);
    }
}
