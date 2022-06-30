using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lut : MonoBehaviour
{
    RacketShoot AddAmmo;
    Bird AddHill;
    [SerializeField]
    private AudioClip Sound_Catch;
    private AudioSource Music_Controller;
    [SerializeField]
    ParticleSystem Expload_Catch;
    // Start is called before the first frame update

    private void Awake()
    {
        Music_Controller = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Music_Controller.clip = Sound_Catch;
        Music_Controller.Play();

        AddHill = GameObject.Find("Bird").GetComponent<Bird>();
        AddAmmo = GameObject.Find("Bird").GetComponent<RacketShoot>();

        if (other.transform.tag == "Player"&& gameObject.transform.tag == "Health")
        {
            Expload_Catch.Play();
            AddHill.hill = AddHill.hill + 6;
            Destroy(gameObject, 0.3f);

        }
        if(other.transform.tag == "Player"&& gameObject.transform.tag == "Patron")
        {
            Expload_Catch.Play();
            AddHill.hill = AddHill.hill + 1;
            AddHill.Hills.text = AddHill.hill.ToString();

            AddAmmo.AmmoQuantity = AddAmmo.AmmoQuantity + 5;
            AddAmmo.AmmoText.text = AddAmmo.AmmoQuantity.ToString();
            Destroy(gameObject, 0.3f);

        }
        
    }
    void Update()
    {
        transform.RotateAround(transform.position,Vector3.down,2f);
        
    }
}
