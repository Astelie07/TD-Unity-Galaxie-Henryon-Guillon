using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;


public class AgentManager : MonoBehaviour
{
    [SerializeField] private GameObject _agent;
    [SerializeField] private int _numberOfAgents = 1;

    [SerializeField] private List<Transform> _spawnPoints = new List<Transform>();

    public List<GameObject> _agentsList = new List<GameObject>();


    public float _agentsSpeed = 1f;

    [SerializeField] private bool _isRandomTarget;

    private GameObject _currentAgent;

    void Start()
    {
        foreach (GameObject _spawn in GameObject.FindGameObjectsWithTag("SpawnPoint"))
        {
            _spawnPoints.Add(_spawn.GetComponent<Transform>());
        }

        if (_agent != null)
        {
            AgentsSpawn();
        }
    }

    void Update()
    {
        
    }

    //public void OnValidate()
    //{
    //    ChangeAgentsValues();
    //}

    public void ChangeAgentsValues(float _frostSpeed)
    {
        Debug.Log("changeSpeed");
        foreach (GameObject i in _agentsList)
        {
            i.GetComponent<NavMeshAgent>().speed = _frostSpeed;
            Debug.Log(i.name + "is changing speed");
            Debug.Log(i.GetComponent<NavMeshAgent>().speed);
        }
    }

    void AgentsSpawn()
    {
        for (int i = 0; i < _numberOfAgents; i++)
        {
            //random pos between multiple spawn points
            int index = Random.Range(0, _spawnPoints.Count);
            Transform _randomSpawnPos = _spawnPoints[index];


            _currentAgent = Instantiate(_agent, _randomSpawnPos.position, Quaternion.identity);
            _currentAgent.GetComponent<NavMeshAgent>().speed = _agentsSpeed;
            _currentAgent.GetComponent<PathFindingAI>()._isRandomTarget = _isRandomTarget;
            _agentsList.Add(_currentAgent);
        }
    }
}
