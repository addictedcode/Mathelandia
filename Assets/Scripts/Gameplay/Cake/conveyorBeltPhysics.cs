using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class conveyorBeltPhysics : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "CakeBase")
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000f, 0));
        }
    }
}
