using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float speed = 10;

    public int currentWayPointIndex = 0;

    private Transform target;


    void Start()
    {

        target = WayPoints.points[0];
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 dir = target.position - transform.position;


        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);

        if(Vector3.Distance(target.position, transform.position) <= 0.4f)
        {
            GetNextWaypoint();
        }


    }

    void GetNextWaypoint()
    {

        if (currentWayPointIndex >= WayPoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        currentWayPointIndex++;
        target = WayPoints.points[currentWayPointIndex];

    }




}
