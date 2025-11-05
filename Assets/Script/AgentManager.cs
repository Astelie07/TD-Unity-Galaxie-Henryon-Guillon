using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;


public class AgentManager : MonoBehaviour
{
    [SerializeField] private GameObject _agent;
    [SerializeField] private int _numberOfAgents = 1;

    public List<GameObject> _agentsList = new List<GameObject>();


    public float _agentsSpeed = 1f;

    [SerializeField] private bool _isRandomTarget;

    void Start()
    {
        if(_agent != null)
        {
            AgentsSpawn();
        }
    }

    void Update()
    {
        
    }

    public void OnValidate()
    {
        ChangeAgentsValues();
    }

    void ChangeAgentsValues()
    {
        Debug.Log("changeSpeed");
        foreach (GameObject i in _agentsList)
        {
            i.GetComponent<NavMeshAgent>().speed = _agentsSpeed;
            Debug.Log(i.name + "is changing speed");
            Debug.Log(i.GetComponent<NavMeshAgent>().speed);
        }
    }

    void AgentsSpawn()
    {
        for (int i = 0; i < _numberOfAgents; i++)
        {
            Instantiate(_agent, new Vector3(0, 0, 0), Quaternion.identity);
            _agent.GetComponent<NavMeshAgent>().speed = _agentsSpeed;
            _agent.GetComponent<PathFindingAI>()._isRandomTarget = _isRandomTarget;
            _agentsList.Add(_agent);
        }
    }
}
