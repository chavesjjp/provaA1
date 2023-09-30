using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Services.Analytics.Internal;
using UnityEngine;
using UnityEngine.AI;

public class EnemyHandler : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] destinos;
    int numeroDestino;
    Vector3 target;
    bool isHumanoid;
    public Transform player;
    private void Start()
    {
        isHumanoid = false;
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }
    void Update()
    {
        if (agent.agentTypeID == 0)
            isHumanoid = true;
        switch (isHumanoid)
        {
            case true:
                agent.SetDestination(player.position);
                break;
            case false:
                if (Vector3.Distance(transform.position, target) < 1)
                {
                    UpdateNumeroDestino();
                    UpdateDestination();
                }
                break;
        }

    }
    void UpdateDestination()
    {
        target = destinos[numeroDestino].position;
        agent.SetDestination(target);
    }
    void UpdateNumeroDestino()
    {
        numeroDestino++;
        if (numeroDestino == destinos.Length)
        {
            numeroDestino = 0;
        }
    }
    public void AgentType()
    {
        agent.agentTypeID = 0;
    }

}
