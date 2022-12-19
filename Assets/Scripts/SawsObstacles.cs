using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawsObstacles : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] float moveSpeed; 
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0f, 0f, moveSpeed * Time.deltaTime);  
    }
}
