using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int fruitCount = 0;
    [SerializeField] private Text fruitCountText;
    [SerializeField] private AudioSource CollectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruit"))
        {
            CollectSound.Play();
            Destroy(collision.gameObject);
            fruitCount++;
            fruitCountText.text = "Fruit Count: " + fruitCount;
        }
    }
}
