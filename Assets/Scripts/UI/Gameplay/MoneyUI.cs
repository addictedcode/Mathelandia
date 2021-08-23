using System;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        EventManager<PointsEventArgs>.Add("points", OnPointEvent);
    }

    void OnPointEvent(object sender, PointsEventArgs e)
    {
        TMP_Text text = gameObject.GetComponentInChildren<TMP_Text>();
        text.text = e.points.ToString();
    }

}
