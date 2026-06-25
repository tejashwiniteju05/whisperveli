using UnityEngine;
using UnityEngine.AI;

public class enemy : MonoBehaviour
{
    public Transform player;

    public float chaseDistance = 5f;
    public float roamDistance = 10f;

    public static bool safeZone = false;

    NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        Roam();
    }

    void Update()
    {
        // Player in safe zone -> roam
        if (safeZone)
        {
            if (agent.remainingDistance < 1f)
            {
                Roam();
            }
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance < chaseDistance)
        {
            agent.SetDestination(player.position);
        }
        else
        {
            if (agent.remainingDistance < 1f)
            {
                Roam();
            }
        }
    }

    public void Roam()
    {
        float x = Random.Range(-roamDistance, roamDistance);
        float z = Random.Range(-roamDistance, roamDistance);

        Vector3 pos = new Vector3(
            transform.position.x + x,
            transform.position.y,
            transform.position.z + z
        );

        agent.SetDestination(pos);
    }
}
