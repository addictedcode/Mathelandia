using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
            if (m_time >= m_sprites.Length) m_time = 0;
        }
    }
}
