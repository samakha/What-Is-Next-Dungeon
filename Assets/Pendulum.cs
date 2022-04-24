using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulum : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] float moveSpeed; 
    [SerializeField] float leftAngle; 
    [SerializeField] float rightAngle;

    bool movingClockWise; 
    void Start()
    {

        rb = GetComponent<Rigidbody2D>(); 
    }

    // Update is called once per frame
    void Update()
    {
        rb.angularVelocity = moveSpeed;
        MoveObject(); 
    }
    void ChangeMoveDirection( )
    {
        if( transform.rotation.z > rightAngle)
        {
            movingClockWise = false; 
        }
        if( transform.rotation.z < leftAngle )
        {
            movingClockWise = true; 
        }
    }
    private void MoveObject( )
    {
        ChangeMoveDirection(); 
        if( movingClockWise)
        {
            rb.angularVelocity = moveSpeed; 
        }
        if( !movingClockWise)
        {
            rb.angularVelocity = -moveSpeed; 
        }
    }
}
