using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cleaner : MonoBehaviour
{
    public int TimeDestory;

    private void FixedUpdate()
    {
        Destroy(gameObject,TimeDestory);
    }

 


        
    
}
