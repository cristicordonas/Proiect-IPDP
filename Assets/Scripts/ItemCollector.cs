using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    private int melonCount = 0;
    [SerializeField] private Text melonCountText;
    [SerializeField] private AudioSource collectSound;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Melon"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            melonCount++;
            melonCountText.text = "Melon Count: " + melonCount;
        }
    }
}