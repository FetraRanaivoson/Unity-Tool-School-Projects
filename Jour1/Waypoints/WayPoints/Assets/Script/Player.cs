using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameObject player;
    private List<GameObject> wayPoints;
    private int nextPoint = 0;
    public int speed { get; set; } = 2;
    

    void Start()
    {
        wayPoints = GetComponent<MovementControllerS>().wayPoints;
    }
    

    void Update()
    {
        if (wayPoints != null && wayPoints.Count > 0)
        {
            Vector3 direction = wayPoints[nextPoint].transform.position - player.transform.position;
            player.transform.rotation = Quaternion.Slerp(player.transform.rotation, Quaternion.LookRotation(direction),
                5f);
        
            if (direction.sqrMagnitude > .1f)
                player.transform.Translate(0, 0, speed * Time.deltaTime);
            else
                nextPoint++;
        
            if (nextPoint == wayPoints.Count)
                nextPoint = 0;
        }
    }
    
}
