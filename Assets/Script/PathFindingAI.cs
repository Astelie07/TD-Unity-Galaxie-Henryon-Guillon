using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;

public class PathFindingAI : MonoBehaviour
{
    [SerializeField] private Transform _currentDestination = null;
    private NavMeshAgent _navMeshAgent = null;

    public List<Transform> _targetList = new List<Transform>();

    private int _targetIndex = 0;

    private bool _endTarget = false;

    public bool _isRandomTarget;
    private bool _followPlayer = false;
    private Transform _playerPos;


    void Start()
    {
        _navMeshAgent = this.GetComponent<NavMeshAgent>();

        foreach (GameObject _target in GameObject.FindGameObjectsWithTag("Target"))
        {
            _targetList.Add(_target.GetComponent<Transform>());
        }
        _targetList.Reverse();

        SetDestination();
    }

    void Update()
    {
        if(_followPlayer == true)
        {
            _navMeshAgent.destination = _playerPos.position;
        }
        else
        {
            if (_endTarget == false)
            {
                _navMeshAgent.destination = _currentDestination.position;

                if (Vector3.Distance(transform.position, _currentDestination.position) <= 1f)
                {
                    Debug.Log("destination atteinte");
                    SetDestination();
                }
            }
            else
            {
                _navMeshAgent.isStopped = true;
            }
        }
    }

    void SetDestination()
    {
        if (_targetIndex >= _targetList.Count)
        {
            _endTarget = true;
        } else
        {
            if(_isRandomTarget == false)
            {
                //cas ordonné
                _currentDestination = _targetList[_targetIndex];
                _currentDestination.position = _currentDestination.position;
                _targetIndex = _targetIndex + 1;
            }
            else
            {
                //cas aléatoire
                int index = Random.Range(0, _targetList.Count);
                _currentDestination = _targetList[index];
                _targetList[index] = _targetList[_targetList.Count - 1];
                _targetList.RemoveAt(_targetList.Count - 1);
                _currentDestination.position = _currentDestination.position;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("player grou");
            _playerPos = other.transform;

            if(_followPlayer == false)
            {
                this.gameObject.GetComponent<AudioSource>().Play();
            }
            _followPlayer = true;
        }
    }
}
