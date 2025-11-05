using UnityEngine;
using UnityEngine.AI;

public class PathFindingAI : MonoBehaviour
{
    [SerializeField] private Transform _destination = null;
    private NavMeshAgent _navMeshAgent = null;
    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        _navMeshAgent.destination = _destination.position;
    }
}
