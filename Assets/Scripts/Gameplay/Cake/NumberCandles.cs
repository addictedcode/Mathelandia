using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumberCandles : MonoBehaviour
{

    private GameObject cakeObject;
    [SerializeField]
    private Sprite[] numberCandleSprites = new Sprite[10];
    [SerializeField]
    private Sprite negativeCandleSprite;
    private int numberCandle;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public List<Sprite> generateCandleSprites(int number)
    {
        int digits = Mathf.Abs(number).ToString().Length;
        List<Sprite> candleList = new List<Sprite>();
        int[] numbers = new int[digits];

        if (number < 0)
        {
            candleList.Add(negativeCandleSprite);
        }
        int[] numbersBackwards = new int[digits];
        for (int i = 0; i < digits; i++)
        {
            
            numbersBackwards[i] = Mathf.Abs(number % 10);
            number /= 10;
        }
        for(int i = numbersBackwards.Length -1 ; i >= 0 ; i--)
        {
            candleList.Add(numberCandleSprites[numbersBackwards[i]]);
        }
        return candleList;
    }
}
