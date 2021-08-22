using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private int order;
    public CustomerSpawner spawner;

    private bool leavingShop = false;
    private float moveSpeed = 5.0f;
    private Vector3 destination;
    private Vector3 startPosition;
    private float lerpDelta = 0.0f;
    public Animator animator;

    private bool hasNewDestination = false;

    public void setOrder(int num)
    {
        order = num;
        //Debug.Log(num);
    }

    public int getOrder()
    {
        return order;
    }

    public bool finishOrder(int cakeNum)
    {
        if (cakeNum == order)
        {
            spawner.clearCustomer(this);
            leavingShop = true;
            setDestination(gameObject.transform.position + new Vector3(-10, 0, 0));
            return true;
        }
        else
            return false;
    }

    private void Update()
    {
        if (hasNewDestination)
        {
            float distance = (destination - startPosition).magnitude;
            lerpDelta += Time.deltaTime * moveSpeed / distance;
            Mathf.Clamp(lerpDelta, 0, 1.0f);

            gameObject.transform.position = Vector3.Lerp(startPosition, destination, lerpDelta);

            animator.SetFloat("speed", 1);

            if (lerpDelta >= 1.0f)
            {
                animator.SetFloat("speed", 0);
                if (leavingShop)
                    Destroy(gameObject);
                else
                    hasNewDestination = false;
            }
        }
    }

    public void setDestination(Vector3 dest)
    {
        destination = dest;
        hasNewDestination = true;
        startPosition = gameObject.transform.position;
        lerpDelta = 0.0f;
    }
}
