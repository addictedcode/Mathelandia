using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpriteHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer[] candleSprites;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCandleSprites(List<Sprite> newCandleSprites)
    {
        for(int i = 0; i < newCandleSprites.Count; i++)
        {
            candleSprites[i].sprite = newCandleSprites[i];
        }
    }
    public void toggleSprites(bool toggle)
    {
        for (int i = 0; i < candleSprites.Length; i++)
        {
            candleSprites[i].gameObject.SetActive(toggle);
        }
    }

}
