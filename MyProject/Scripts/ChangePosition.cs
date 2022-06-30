using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePosition : MonoBehaviour
{
    // Start is called before the first frame update
   
   [SerializeField] float Friq = 2, Ampl = 1;
    Vector3 StartPosition;

    Transform[] Asteroids = new Transform[3];
    // Update is called once per frame
    private void Start()
    {
        StartPosition = transform.position;

       

            Asteroids[0] = gameObject?.transform.GetChild(0);

            Asteroids[1] = gameObject?.transform.GetChild(1);

            Asteroids[2] = gameObject?.transform.GetChild(2);
        



    }
    void FixedUpdate()
    {
        

            if (Asteroids[0] != null) Asteroids[0].Rotate(0, Random.Range(2, 6) / 4, 0);
            if (Asteroids[1] != null) Asteroids[1].Rotate(0, 0, Random.Range(-6, -2) / 4);
            if (Asteroids[2] != null) Asteroids[2].Rotate(Random.Range(3, 6) / 4, 0, 0);
        
   
        transform.position = StartPosition + new Vector3(0,Ampl*Mathf.Sin(Friq*Time.time),0);
  





    }



}
