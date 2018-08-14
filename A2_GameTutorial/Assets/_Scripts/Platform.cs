using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {



    // Setting the player to be parented to the moving platform
    void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.tag == "Player")
            collider.transform.SetParent(transform, true);
        Debug.Log(" player on is the platform ");
    }

    void OnCollisionExit2D(Collision2D collider)
    {
        // making the player unparented from the platform
        collider.transform.SetParent(transform.parent, true);
        Debug.Log(" player is off the platform ");
    }
}
