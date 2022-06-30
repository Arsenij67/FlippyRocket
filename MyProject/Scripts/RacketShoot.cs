using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RacketShoot : MonoBehaviour
{
    public int AmmoQuantity = 10;
 
    public Text AmmoText;
    [SerializeField]
    private Image AmmoImage;

    public Rigidbody BulletRB;
    [SerializeField]
    private Transform Instantiate_Start_Position;
    
   
  
   Rigidbody BulletNew;
    // Update is called once per frame
public void ShootDown()
    {
        if (AmmoQuantity > 0)
        {
            AmmoQuantity -= 1;

            AmmoText.text = AmmoQuantity.ToString();

            AmmoImage.color = Color.red;
            AmmoText.color = Color.red;
            BulletNew = Instantiate(BulletRB, Instantiate_Start_Position.position+new Vector3(0,0,1), Quaternion.identity);

          

            BulletNew.velocity = new Vector3(0, 0, 20);
            BulletNew.GetComponent<ParticleSystem>().Play();
        }
        
    }
    public void ShootUp()
    {
        AmmoText.color = Color.white;
        AmmoImage.color = Color.white;


    }
    private void FixedUpdate()
    {
        if (Time.time % 5 == 0&&AmmoQuantity<10)
        {
            AmmoQuantity++;
            AmmoText.text = AmmoQuantity.ToString();
            AmmoText.color = Color.green;
            AmmoImage.color = Color.green;
        }
       
     


    }



}






