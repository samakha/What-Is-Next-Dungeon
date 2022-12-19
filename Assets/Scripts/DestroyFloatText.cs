using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyFloatText : MonoBehaviour
{
    [SerializeField] float timeToDestroy;

    private void Update()
    {
        Destroy(gameObject, timeToDestroy); 
    }
}
