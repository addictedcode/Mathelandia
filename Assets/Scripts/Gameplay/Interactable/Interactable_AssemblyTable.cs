using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable_AssemblyTable : MonoBehaviour
{
    // Start is called before the first frame update
    public List<GameObject> cakeBases;
    public List<int> cakeInts;
    public List<GameObject> frostings;
    public List<SpriteRenderer> cakeSprites;
    public List<SpriteRenderer> frostingSprites;
    public int FinalAnswer = 0;
    public bool isCakeComplete = false;

    private void Start()
    {
        foreach(SpriteRenderer sprite in cakeSprites)
        {
            sprite.color = new Color(0, 0, 0, 0);
        }
        foreach (SpriteRenderer sprite in frostingSprites)
        {
            sprite.color = new Color(0, 0, 0, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().isInsideInteractField = true;
            other.gameObject.GetComponent<playerController>().isAssemblyTable = true;
            other.gameObject.GetComponent<playerController>().assemblyTable = this;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            other.gameObject.GetComponent<playerController>().isInsideInteractField = false;
            other.gameObject.GetComponent<playerController>().isAssemblyTable = false;
            other.gameObject.GetComponent<playerController>().assemblyTable = null;
        }
    }

    public void UpdateStack(GameObject newStackItem)
    {
        if (frostings.Count < 1 || cakeBases.Count < 2)
        {
            if (newStackItem.tag == "Frosting")
            {
                frostings.Add(newStackItem);
                if (newStackItem.GetComponent<HeldObject>().isPositiveFrosting)
                {
                    frostingSprites[frostings.Count - 1].color = new Color(1f, 153f / 255f, 153f / 255f, 1f);
                }
                else
                {
                    frostingSprites[frostings.Count - 1].color = new Color(153f / 255f, 153f / 255f, 1f, 1f);
                }
            }
            else if (newStackItem.tag == "CakeBase")
            {
                cakeInts.Add(newStackItem.GetComponent<Cake>().number);
                cakeBases.Add(newStackItem);
                
                cakeSprites[cakeBases.Count - 1].color = new Color(135f / 255f, 72f / 255f, 72f / 255f, 1f);
            }
        }
        UpdateFinalAnswer();
    }

    public void UpdateFinalAnswer()
    {
        if (frostings.Count == 1 && cakeBases.Count == 2)
        {
            isCakeComplete = true;
            FinalAnswer = cakeInts[0];
            for (int i = 1; i < cakeBases.Count; i++)
            {
                for (int j = 0; j < frostings.Count; j++)
                {
                    if (frostings[j].GetComponent<HeldObject>().isPositiveFrosting)
                    {
                        FinalAnswer += cakeInts[i];
                    }
                    else
                    {
                        FinalAnswer -= cakeInts[i];
                    }
                }
            }
            Debug.Log(FinalAnswer);
        }
    }

    public int TakeCake()
    {
        if (isCakeComplete)
        {
            cakeBases.Clear();
            frostings.Clear();
            foreach (SpriteRenderer sprite in cakeSprites)
            {
                sprite.color = new Color(0, 0, 0, 0);
            }
            foreach (SpriteRenderer sprite in frostingSprites)
            {
                sprite.color = new Color(0, 0, 0, 0);
            }
            isCakeComplete = false;
            cakeInts.Clear();
            return FinalAnswer;
        }
        return 0;

    }


}
