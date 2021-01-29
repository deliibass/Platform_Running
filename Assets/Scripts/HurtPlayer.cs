using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    public int damageToGive = 1;
    public AudioClip crash;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(crash, transform.position);
            Vector3 hitDirection = other.transform.position - transform.position;
            hitDirection = hitDirection.normalized;

            FindObjectOfType<HealthManager>().HurtPlayer(damageToGive, hitDirection);
        }

        if(other.gameObject.tag == "Opponent")
        {
            FindObjectOfType<OpponentHealthManager>().HurtOpponent();
        }

    }
}
