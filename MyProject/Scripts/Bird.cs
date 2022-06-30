using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class Bird : MonoBehaviour
{
    public Text Hills;
    public Rigidbody rb;
    public int speed;
    public float SpeedPhone = 3;
    [SerializeField]
    private float ClampDown;
    [SerializeField]
    private float ClampUp;

    public AudioClip Clash_Clip;




    public AudioClip Clip_Lose;
    private AudioSource Source_Lose;


    public float hill = 10;

   
    [SerializeField]
    private Sprite Retry1;
    [SerializeField]
    private Sprite Retry2;
    public Image hillImage;
    [SerializeField]
    private ParticleSystem smoke;
    private Touch touch;
    [SerializeField]
    private Animation anim;

    public Animation Window_Lose;
    
    private int TimeScore;

    [SerializeField]
    private Text ScoreText;

    private static int Record;
    [SerializeField]
    private Text RecordText;

    private AudioSource Clash_Source;
    private void Awake()
	{
        Source_Lose = GameObject.Find("Phone_Music_Controller").GetComponent<AudioSource>();
    }
 

    void Start()
    {
       
        Time.timeScale = 1;
        rb.useGravity = true;
        Clash_Source = GameObject.Find("Phone_Music_Controller")?.GetComponent<AudioSource>();



        hillImage = GameObject.Find("ImageHealth").GetComponent<Image>();
        anim = gameObject.GetComponent<Animation>();
        TimeScore = 0;

        if (ScoreText != null || RecordText != null)
        {
            ScoreText.text = TimeScore.ToString();
            RecordText.text = "Record: " + Record.ToString();
        }



    }
    private void OnTriggerEnter(Collider collision)
    {

        try
        {



            hill--;

            Hills.text = hill.ToString();
            if (collision.transform.tag == "Column")
            {
                Transform ast1 = collision.transform?.GetChild(0);

                Transform ast2 = collision.transform?.GetChild(1);

                Transform ast3 = collision.transform?.GetChild(2);

                ast1.parent = null;
                ast2.parent = null;
                ast3.parent = null;


                Destroy(ast1.gameObject, 6f);
                Destroy(ast2.gameObject, 6f);
                Destroy(ast3.gameObject, 6f);



                Rigidbody rb1 = ast1.gameObject.AddComponent<Rigidbody>();

                Rigidbody rb2 = ast2.gameObject.AddComponent<Rigidbody>();

                Rigidbody rb3 = ast3.gameObject.AddComponent<Rigidbody>();

                rb1.useGravity = false;
                rb2.useGravity = false;
                rb3.useGravity = false;


                Destroy(collision.gameObject, 4f);

            }


        }
        catch (Exception)
        {
            print("Ну ошибка чувак...");
        }
        if (collision.name != "Level_Up" && collision.tag != "Patron" && collision.tag != "Health")
        {



            for (int i = 0; i < 7; i++) gameObject.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.color = Color.red;

            Clash_Source.PlayOneShot(Clash_Clip);
        }
        
        
       

       
        if (hill < 1)
        {

            SpeedPhone = -4;
            speed = 0;
            Destroy(GetComponent<BoxCollider>());


            Window_Lose.Play();
          
            Source_Lose.PlayOneShot(Clip_Lose);








        }

 
        float HillInProcent = (hill / 10) * 100;

        if (HillInProcent <= 70f && HillInProcent > 20f) hillImage.color = Color.yellow;


        if (HillInProcent <= 20f) hillImage.color = Color.red;






    }



    private void OnTriggerExit(Collider collision)
    {
        if (collision.name != "Level_Up" && collision.tag != "Patron" && collision.tag != "Health")
        {



            for (int i = 0; i < 7; i++)  gameObject.transform.GetChild(0).GetChild(i).GetComponent<MeshRenderer>().material.color = Color.white;

             

        }



    }


    float buff;
    void FixedUpdate()
    {

        buff += 0.05f;

        if (buff > 1 && ScoreText != null&& hill>0)
        {
            TimeScore = (int)buff;
            ScoreText.text = "Score: " + TimeScore.ToString();
        }

        if (TimeScore > Record && RecordText != null)
        {
            Record = TimeScore;
            RecordText.text = "Record: " + Record.ToString();
        }


        if (Input.GetKey(KeyCode.Space) )  // for PK
        {
            rb.AddForce(0, 5 * speed *Time.fixedDeltaTime, 0);
           
            smoke.Play();
            anim.Play();
         
        }

        if (transform.position.y > ClampUp)
        {
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.zero);
            transform.position = new Vector3(transform.position.x,ClampUp,transform.position.z);
        }

        

            
      if (transform.position.y < ClampDown)
        {
            //rb.useGravity = false;
            rb.velocity = Vector3.zero;
            rb.AddForce(Vector3.zero);
            transform.position = new Vector3(transform.position.x, ClampDown, transform.position.z);

        }




        if (Input.touchCount > 0)
        {

            touch = Input.GetTouch(0);
        }

        if (touch.phase == TouchPhase.Stationary && Input.touchCount > 0) //For Phone
        {


            smoke.Play();
            anim.Play();
            rb.AddForce(0, 5 * speed*Time.fixedDeltaTime, 0);
        }


        transform.Translate(0, 0, SpeedPhone * Time.fixedDeltaTime);


    }
}
