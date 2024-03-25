using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyPlatform : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.gameObject.name == "Player") 
        {
            collision.gameObject.transform.SetParent(transform); // set the player as a child of the platform, player moves like platform
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
            collision.gameObject.transform.SetParent(null); // remove the player from the parent, player moves independently
        }
    }
}