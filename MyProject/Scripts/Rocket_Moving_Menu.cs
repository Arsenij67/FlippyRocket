using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket_Moving_Menu : MonoBehaviour
{
  
   private  Vector3 StartPosition;
   [SerializeField] private float Ampl, Friq;
    [SerializeField] private ParticleSystem Fire_Down;

    private Animation Rot_Rocket;
    void Start()

    {  StartPosition = transform.position;

        Rot_Rocket = gameObject.GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.touchCount > 0)
        {

            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)
            {
                Rot_Rocket.Play();
                Fire_Down.Play();

            }
        }


        transform.position = StartPosition + new Vector3(0, Ampl * Mathf.Sin(Friq * Time.time), 0);
    }
}
