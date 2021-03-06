using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Clock : MonoBehaviour
{
    [SerializeField] private SpriteRenderer m_renderer;
    [SerializeField] private Sprite[] m_sprites;
    [SerializeField] private float m_seconds;

    private WaitForSeconds m_interval;
    private int m_time = 0;

    private void Awake()
    {
        m_interval = new WaitForSeconds(m_seconds);
    }

    private void Start()
    {
        StartCoroutine(TimeTick());
    }

    IEnumerator TimeTick()
    {
        while (true) {
            m_renderer.sprite = m_sprites[m_time];
            yield return m_interval;
            ++m_time;
            //Timer ends
            if (m_time >= m_sprites.Length)
            {
                EventManager<EventArgs>.Invoke(this, "endtime");
                SceneManager.LoadScene(0);
                break;
            }
        }
    }
}
