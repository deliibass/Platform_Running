using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalObstacleManager : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speed = 3;
    //adjust this to change how high it goes
    [SerializeField]
    float width = 6f;

    Vector3 pos;

    int chooseDirection;

    private void Start()
    {
        chooseDirection = Random.Range(1, 3);
        pos = transform.position;
    }
    void FixedUpdate()
    { 
        transform.Rotate(0,20,0);

        if(chooseDirection == 1)
        {
            chooseDirection = 1;
        }
        else if(chooseDirection == 2)
        {
            chooseDirection = -1;
        }

        //calculate what the new X position will be
        float newX = Mathf.Sin(Time.time * speed) * width + pos.x;
        //set the object's X to the new calculated X
        transform.position = new Vector3(newX * chooseDirection, transform.position.y, transform.position.z);

    }
}
