using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupItem : MonoBehaviour
{
    public int value;
    public GameObject pickupEffect;

    public AudioClip impact;


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(impact, transform.position);

            FindObjectOfType<GameManager>().AddItem(value);

            Instantiate(pickupEffect, transform.position, transform.rotation);

            Destroy(gameObject);
        }
    }
}
