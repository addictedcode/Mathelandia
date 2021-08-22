using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    #region Inspector

    [Header("Movement")]
    [SerializeField]
    private float speed = 500f;

    [Header("Relations")]
    [SerializeField]
    private Animator animator = null;

    [SerializeField]
    private SpriteRenderer spriteRenderer = null;

    [SerializeField]
    private Rigidbody2D rb = null;

    [SerializeField]
    private GameObject heldItem;

    [SerializeField]
    private SpriteRenderer heldItemSprite = null;

    [SerializeField]
    private NumberCandles numberCandleSpawner;
    #endregion

    #region Fields

    //Controls -=============================
    private Vector2 _movement;
    private float x;
    private float y;
    private float interact;
    //Controls -=============================

    //INTERACTING ===========================
    public bool isTrashCan = false;
    public bool isAssemblyTable = false;
    public bool isInsideInteractField = false;
    public InteractableBehavior interactable = null;
    public Interactable_AssemblyTable assemblyTable = null;
    //INTERACTING ===========================

    #endregion

    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        heldItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        getInput();
    }

    private void FixedUpdate()
    {
        move();
    }

    private void getInput()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");
        interact = Input.GetAxis("Interact");

        if (x != 0 || y != 0)
        {
            animator.SetFloat("speed", 1);
            if (x > 0)
            {
                spriteRenderer.flipX = false;
                heldItemSprite.transform.localPosition = new Vector3(.5f,
                                                                   heldItemSprite.transform.localPosition.y,
                                                                   heldItemSprite.transform.localPosition.z);
            }

            else if (x < 0)
            {
                spriteRenderer.flipX = true;
                heldItemSprite.transform.localPosition = new Vector3(-.5f,
                                                                   heldItemSprite.transform.localPosition.y,
                                                                   heldItemSprite.transform.localPosition.z);
            }
        }
        else if (x == 0 && y == 0)
        {
            animator.SetFloat("speed", 0);
        }


        if (interact != 0)
        {
            Interact();
        }
    }
    private void move()
    {
        Vector2 move;

        move = (rb.transform.right * x + rb.transform.up * y) * speed * Time.fixedDeltaTime;

        rb.velocity = (new Vector2(move.x, move.y));
    }

    private void Interact()
    {
        if (isInsideInteractField)
        {
            if (heldItem != null)
            {
                if (isTrashCan)
                {
                    UpdateHeldItem(null, null, new Color(0, 0, 0, 0));
                    GetComponentInChildren<CandleSpriteHandler>().toggleSprites(false);
                    animator.SetBool("isHolding", false);
                }
                if (isAssemblyTable)
                {
                    if (!assemblyTable.isCakeComplete)
                    {
                        if (heldItem.tag == "Frosting" && assemblyTable.frostings.Count < 1)
                        {
                            assemblyTable.UpdateStack(heldItem);

                            UpdateHeldItem(null, null, new Color(0, 0, 0, 0));
                            GetComponentInChildren<CandleSpriteHandler>().toggleSprites(false);
                            animator.SetBool("isHolding", false);
                        }
                        else if (heldItem.tag == "CakeBase" && assemblyTable.cakeBases.Count < 2)
                        {
                            assemblyTable.UpdateStack(heldItem);

                            UpdateHeldItem(null, null, new Color(0, 0, 0, 0));
                            GetComponentInChildren<CandleSpriteHandler>().toggleSprites(false);
                            animator.SetBool("isHolding", false);
                        }
                    }
                    
                }

            }
            else if (heldItemSprite.sprite == null) // IF THERE ARE NO HELD ITEMS and player is about to pick up a new item
            {
                if(interactable != null)
                {
                    GetComponentInChildren<CandleSpriteHandler>().toggleSprites(false);
                    UpdateHeldItem(interactable.pickUpItem,
                                    interactable.pickUpItem.GetComponentInChildren<SpriteRenderer>().sprite,
                                    interactable.pickUpItem.GetComponentInChildren<SpriteRenderer>().color);
                    animator.SetBool("isHolding", true);
                    if(interactable.gameObject.tag == "CakeBase")
                    {
                        GetComponentInChildren<CandleSpriteHandler>().toggleSprites(true);
                        GetComponentInChildren<CandleSpriteHandler>().updateCandleSprites(
                                    numberCandleSpawner.generateCandleSprites(
                                           interactable.pickUpItem.GetComponent<HeldObject>().cakeInteger));
                        Destroy(interactable.gameObject);
                    }
                }
                if (isAssemblyTable)
                {
                    assemblyTable.TakeCake();
                }
            }
        }
    }
    
    private void UpdateHeldItem(GameObject newHeldItem, Sprite newSprite, Color newColor)
    {
        heldItem = newHeldItem;
        heldItemSprite.sprite = newSprite;
        heldItemSprite.color = newColor;
    }
}
