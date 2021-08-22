using System;
using UnityEngine;

public class MoneyUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventManager<EventArgs>.Add("points", OnPointEvent);
        EventManager<EventArgs>.Invoke(this, "points");
    }

    void OnPointEvent(object sender, EventArgs e)
    {
        Debug.Log("Points changed");
    }

}
