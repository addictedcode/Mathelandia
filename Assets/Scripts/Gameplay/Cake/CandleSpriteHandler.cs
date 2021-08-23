using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CandleSpriteHandler : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer[] candleSprites;
    private int digits;

    public void updateCandleSprites(List<Sprite> newCandleSprites)
    {
        for(int i = 0; i < newCandleSprites.Count; i++)
        {
            candleSprites[i].sprite = newCandleSprites[i];
        }
        digits = newCandleSprites.Count;
        toggleSprites(true);
    }
    public void toggleSprites(bool toggle)
    {
        for (int i = 0; i < digits; i++)
        {
            candleSprites[i].gameObject.SetActive(toggle);
        }
        for (int i = digits; i < 4; i++)
        {
            candleSprites[i].gameObject.SetActive(false);
        }
    }

}
