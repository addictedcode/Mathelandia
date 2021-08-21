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

    #endregion

    #region Fields

    //Controls -=============================
    private Vector2 _movement;
    private float x;
    private float y;
    private float interact;
    //Controls -=============================

    //INTERACTING ===========================
    public bool isTrashCan;
    public bool isCustomer;
    public Customer customerRef;
    

    public bool isInsideInteractField = false;
    public InteractableBehavior interactable = null;
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
                    animator.SetBool("isHolding", false);
                }
                else if (isCustomer)
                {
                    Cake cake = heldItem.GetComponent<Cake>();
                    if (customerRef.finishOrder(cake.getNumber()))
                    {
                        UpdateHeldItem(null, null, new Color(0, 0, 0, 0));
                        animator.SetBool("isHolding", false);
                    }
                }
            }
            
            if (heldItemSprite.sprite == null) // IF THERE ARE NO HELD ITEMS and player is about to pick up a new item
            {
                if(interactable != null)
                {
                    UpdateHeldItem(interactable.pickUpItem,
                                    interactable.pickUpItem.GetComponentInChildren<SpriteRenderer>().sprite,
                                    interactable.pickUpItem.GetComponentInChildren<SpriteRenderer>().color);
                    animator.SetBool("isHolding", true);
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
