using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bottom : MonoBehaviour
{
    [SerializeField]
    private float speed= - 5;
    
    // Start is called before the first frame update
    void Start()
    {

    }
  
  

    // Update is called once per frame
    void FixedUpdate()
    {
     
        transform.Translate(0, 0, speed* Time.deltaTime,Space.World);
    }
}
