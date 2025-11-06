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

    private GameObject _currentAgent;

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
            _currentAgent = Instantiate(_agent, new Vector3(0, 0, 0), Quaternion.identity);
            _currentAgent.GetComponent<NavMeshAgent>().speed = _agentsSpeed;
            _currentAgent.GetComponent<PathFindingAI>()._isRandomTarget = _isRandomTarget;
            _agentsList.Add(_currentAgent);
        }
    }
}
