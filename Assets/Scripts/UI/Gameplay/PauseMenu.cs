using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    private void OnEnable()
    {
        EventManager<EventArgs>.Invoke(this, "pause");
        Time.timeScale = 0;
    }

    private void OnDisable()
    {
        EventManager<EventArgs>.Invoke(this, "resume");
        Time.timeScale = 1;
    }

    public void OnQuitClick()
    {
        SceneManager.LoadScene(0);
    }
}
