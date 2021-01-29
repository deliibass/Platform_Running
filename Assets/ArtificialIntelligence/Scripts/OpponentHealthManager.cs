using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpponentHealthManager : MonoBehaviour
{
    public OpponentsMove theOpponent;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    void Start()
    {
        respawnPoint = theOpponent.transform.position;
    }


    public void HurtOpponent()
    {
            Respawn();
    }

    public void Respawn()
    {

        if (!isRespawning)
        {
            StartCoroutine("RespawnCo");
        }

    }

    public IEnumerator RespawnCo()
    {
        isRespawning = true;
        theOpponent.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        theOpponent.gameObject.SetActive(true);
        theOpponent.transform.position = respawnPoint;

    }
}
