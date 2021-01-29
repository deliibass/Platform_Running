using UnityEngine;
using UnityEngine.AI;

public class OpponentsController : MonoBehaviour
{
    public Camera cam;
    public NavMeshAgent agent;
    public OpponentsMove character;
    public Transform destinationPoint;
    Vector3 dest;

    void Start()
    {
        agent.updateRotation = false;
        dest = new Vector3(destinationPoint.transform.position.x, destinationPoint.transform.position.y, destinationPoint.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (agent.transform.position != destinationPoint.transform.position)
        {
            agent.Move(transform.forward * 5 * Time.deltaTime);
        }

        if (agent.remainingDistance > agent.stoppingDistance)
        {
            character.Move(agent.desiredVelocity, false, false);
        }
        else
        {
            character.Move(Vector3.zero, false, false);
        }
    }
}
