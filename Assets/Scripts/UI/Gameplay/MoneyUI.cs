using System;
using UnityEngine;
using TMPro;

public class MoneyUI : MonoBehaviour
{
    private uint totalPoints = 0;
    // Start is called before the first frame update
    void Awake()
    {
        EventManager<PointsEventArgs>.Add("points", OnPointEvent);
    }

    void OnPointEvent(object sender, PointsEventArgs e)
    {
        TMP_Text text = gameObject.GetComponentInChildren<TMP_Text>();
        totalPoints += e.points;
        text.text = totalPoints.ToString();
    }

}
