using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HalfDonut : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speed = 3, distance;
    //adjust this to change how high it goes
    [SerializeField]
    float width = 0.12f;
    Vector3 pos;
    public GameObject movingStick;
    void Update()
    {
        //calculate what the new X position will be
        float newX = Mathf.Sin(Time.time * speed) * width;
        //set the object's X to the new calculated X
        movingStick.transform.position = new Vector3(newX + distance, transform.position.y, transform.position.z);
    }
}
