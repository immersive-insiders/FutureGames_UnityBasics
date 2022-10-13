using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 1;
    [SerializeField] private float rotationSpeed = 20;

    private GameObject target;
    private float distanceToTarget;


    

    private void Update()
    {
        if (target == null)
            target = GameObject.FindGameObjectWithTag("Player");


        distanceToTarget = Vector3.Distance(transform.position, target.transform.position);

        if(distanceToTarget< 0.5)
        {
            transform.RotateAround(target.transform.position, Vector3.up, rotationSpeed * Time.deltaTime);
        }
        else
        {
            transform.position += (target.transform.position - transform.position) * speed * Time.deltaTime;
        }
    }
}
