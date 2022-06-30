using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class BulletFall : MonoBehaviour
{



    [SerializeField]
    private AudioClip Expload_Rocket_Clip;

    private AudioSource Expload_Rocket_Source;
    [SerializeField]
    private ParticleSystem Expload_Electric;
   
    private void Awake()
    {
        
        Expload_Rocket_Source = GameObject.Find("Controller").GetComponent<AudioSource>();
    }
    private void OnCollisionEnter(Collision collision)
    {


        if (collision.transform.name.Equals("Asteroid"))
        {
           


            collision.gameObject.AddComponent<Rigidbody>();

            Rigidbody RB = collision.gameObject?.GetComponent<Rigidbody>();

            RB.useGravity = false;


            RB.velocity = Vector3.forward * 1000 * Time.deltaTime;

            ParticleSystem Elect = Instantiate(Expload_Electric, collision.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
            Elect.Play();

           
           
            Destroy(Elect,2f);// удаляем эффект взрыва
            Destroy(collision.gameObject,2f); // удаляем метеорит через 2 секунды
            Destroy(gameObject, 5f);//  удаляем снаряд
            Expload_Rocket_Source.PlayOneShot(Expload_Rocket_Clip);  // включаем музыку столкновения
          

            Expload_Electric.Play(); // включаем столкновение эффект

        }
        

 

        


    }
    void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag.Equals("Column"))
        {
            try
            {

                Transform ast1 = collision.transform.GetChild(0);
                Transform ast2 = collision.transform.GetChild(1);
                Transform ast3 = collision.transform.GetChild(2);

                ast1.parent = null;
                ast2.parent = null;
                ast3.parent = null;

                Destroy(collision.gameObject);
            
                Destroy(ast1.gameObject,5f);
                Destroy(ast2.gameObject, 5f);
                Destroy(ast3.gameObject, 5f);
            }
            catch (Exception)
            {
                print("Ты гдето одновременно и выстрелил и прикоснулся к метеориту.Не страшно");

            }
        }

        
    }
}
