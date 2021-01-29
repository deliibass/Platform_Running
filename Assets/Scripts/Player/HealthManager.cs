using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    public int maxHealth;
    public int currentHeatlh;

    public PlayerController thePlayer;

    public float invincibilityLength;
    private float invincibilityCounter;

    public Renderer playerRenderer;
    private float flashCounter;
    public float flashLength = 0.1f;

    private bool isRespawning;
    private Vector3 respawnPoint;
    public float respawnLength;

    void Start()
    {
        currentHeatlh = maxHealth;
        //thePlayer = FindObjectOfType<PlayerController>();
        respawnPoint = thePlayer.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(invincibilityCounter > 0)
        {
            invincibilityCounter -= Time.deltaTime;
            flashCounter -= Time.deltaTime;
            if(flashCounter <= 0)
            {
                playerRenderer.enabled = !playerRenderer.enabled;
                flashCounter = flashLength;
            }

            if(invincibilityCounter <= 0)
            {
                playerRenderer.enabled = true;
            }
        }
    }

    public void HurtPlayer(int damage, Vector3 direction)
    {
            if (invincibilityCounter <= 0)
            {
                currentHeatlh -= damage;

                if (currentHeatlh <= 0)
                {
                    Respawn();
                }
                else
                {
                    thePlayer.Knockback(direction);

                    invincibilityCounter = invincibilityLength;

                    playerRenderer.enabled = false;

                    flashCounter = flashLength;
                }
            }

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
        thePlayer.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnLength);
        isRespawning = false;

        thePlayer.gameObject.SetActive(true);
        thePlayer.transform.position = respawnPoint;
        currentHeatlh = maxHealth;


        invincibilityCounter = invincibilityLength;

        playerRenderer.enabled = false;

        flashCounter = flashLength;
    }

    public void HealPlayer(int healAmount)
    {
        currentHeatlh += healAmount;
        if(currentHeatlh > maxHealth)
        {
            currentHeatlh = maxHealth;
        }
    }
}
