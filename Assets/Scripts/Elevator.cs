using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    // Start is called before the first frame update
    //range btwe elevator
    public Transform Pos1;
    public Transform Pos2;

    public Transform startPos; 
    public float elevatorMoveSpeed; 

    Vector3 nextPos;
    private void Start()
    {
        nextPos = Pos1.position; 
    }
    private void Update()
    {
        if(transform.position == Pos1.position  )
        {
            nextPos = Pos2.position; 
        }
        if( transform.position == Pos2.position )
        {
            nextPos = Pos1.position; 
        }

        transform.position = Vector3.MoveTowards(transform.position, nextPos, elevatorMoveSpeed * Time.deltaTime); 
    }
}
