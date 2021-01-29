using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallObstacle : MonoBehaviour
{
    //adjust this to change speed
    [SerializeField]
    float speed = 3, distance;
    //adjust this to change how high it goes
    [SerializeField]
    float width = 0.12f;
    Vector3 pos;
    private void Start()
    {
    }

    private void Update() 
    {
        //calculate what the new Y position will be
        float newY = Mathf.Sin(Time.time * speed) * width;
        //set the object's Y to the new calculated Y
        transform.position = new Vector3(transform.position.x , newY + distance, transform.position.z);
    }
}
