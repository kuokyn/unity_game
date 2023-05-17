using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCollector : MonoBehaviour
{

    private int apples = 0;
    public TMP_Text applesCount;
    public AudioSource collectingSound;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            collectingSound.Play();
            Destroy(collision.gameObject);
			apples++;
			applesCount.text = "Apples: " + apples;
        }
    }
}
