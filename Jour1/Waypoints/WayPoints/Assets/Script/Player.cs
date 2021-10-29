using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    public GameObject player;
    private NavMeshAgent _playerAgent;
    private Animator _playerAnim;
    private List<GameObject> _wayPoints;
    private int _nextPoint = 0;
    public int Speed { get; set; } = 2;
    

    void Start()
    {
        _playerAgent = player.GetComponent<NavMeshAgent>();
        _playerAnim = player.GetComponent<Animator>();
        _wayPoints = GetComponent<MovementControllerS>().wayPoints;
    }
    

    void Update()
    {
        if (_wayPoints != null && _wayPoints.Count > 0)
        {
            Vector3 direction = _wayPoints[_nextPoint].transform.position - player.transform.position;
            _playerAnim.SetFloat("Speed", Mathf.Lerp(0,1,_playerAgent.velocity.magnitude/_playerAgent.speed));
            //_playerAnim.SetFloat("Speed", Mathf.Clamp(_playerAgent.velocity.magnitude/_playerAgent.speed,0,1));

            if (Vector3.Distance(_wayPoints[_nextPoint].transform.position, player.transform.position) > 1f)
                _playerAgent.SetDestination(_wayPoints[_nextPoint].transform.position);
            else
                _nextPoint++;
        
            if (_nextPoint == _wayPoints.Count)
                _nextPoint = 0;
        }
    }
    
}
