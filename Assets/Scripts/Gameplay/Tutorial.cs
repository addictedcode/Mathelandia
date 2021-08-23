using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial : MonoBehaviour
{
    public string pickupCakeString = "Press Space in front of cakes to pick them up!";
    public Sprite pickUpCakes;
    public string placeCakeString = "Press Space in front of this table to place the cake!";
    public Sprite placeCakes;

    public string pickupFrostingString = "Press Space in front of this table to pickup frosting!";
    public Sprite pickupFrosting;
    public string placeFrostingString = "Placing frosting on this table will control the operation!";
    public Sprite placeFrosting;

    public string stackCakesString = "A combination of cakes and frosting placed on this table will give you an integer cake!";
    public Sprite stackCakes;
    public string submitCakesString = "Serve the customer with an identical integer cake!";
    public Sprite submitCakes;

    public string garbageCakesString = "If you messed up, don't worry! You can throw away failed cakes in the trash can by pressing space there.";
    public Sprite garbageCakes;

    public string timerString = "Serve as much customers as possible within the time limit!";
    public Sprite timer;
    public string pointsString = "More customers served, more points achieved!";
    public Sprite points;

    public Sprite end;


    public GameObject popUp;
    public Text popUpText;
    public Image popUpImage;
    public float timeElapsed;
    private int currentTutorial;
    private string[] tutorialKeys =
    {
        "pickUpCakes",
        "placeCakes",
        "pickUpFrosting",
        "placeFrosting",
        "stackCakes",
        "submitCakes",
        "garbageCakes",
        "timer",
        "points",
    };
    public bool endtut = false;

    // Start is called before the first frame update
    void Start()
    {
        popUp.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timeElapsed += Time.deltaTime;
        if(timeElapsed > 5.0f)
        {
            if(currentTutorial < 9)
            {
                popUpTime(tutorialKeys[currentTutorial]);
                currentTutorial++;
                timeElapsed = 0;
            }
            else
            {
                popUpText.text = "Well done for finishing the tutorial! Press OK to return to the main menu";
                popUpImage.sprite = null;
            }
        }
    }

    public void popUpTime(string tutorial)
    {
        popUp.SetActive(true);
        Time.timeScale = 0;
        switch (tutorial)
        {
            case "pickUpCakes":
                popUpText.text = pickupCakeString;
                popUpImage.sprite = pickUpCakes;
                break;
            case "placeCakes":
                popUpText.text = placeCakeString;
                popUpImage.sprite = placeCakes;
                break;
            case "pickUpFrosting":
                popUpText.text = pickupFrostingString;
                popUpImage.sprite = pickupFrosting;
                break;
            case "placeFrosting":
                popUpText.text = placeFrostingString;
                popUpImage.sprite = placeFrosting;
                break;
            case "stackCakes":
                popUpText.text = stackCakesString;
                popUpImage.sprite = stackCakes;
                break;
            case "submitCakes":
                popUpText.text = submitCakesString;
                popUpImage.sprite = submitCakes;
                break;
            case "garbageCakes":
                popUpText.text = garbageCakesString;
                popUpImage.sprite = garbageCakes;
                break;
            case "timer":
                popUpText.text = timerString;
                popUpImage.sprite = timer;
                break;
            case "points":
                popUpText.text = pointsString;
                popUpImage.sprite = points;
                break;
        }
    }
    public void closePopUp()
    {
        if (!endtut)
        {
            popUp.SetActive(false);
            Debug.Log("Close!");
            Time.timeScale = 1;
        }
        else
        {
            // Switch back to main menu
        }
        
    }
}
