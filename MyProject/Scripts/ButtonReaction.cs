using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ButtonReaction : MonoBehaviour
{
 

    private AudioSource Phone_Music;
    public AudioClip Phone_Clip;
    public AudioClip Button_Clip;
    public Sprite Music_On;
    public Sprite Music_Off;
    [SerializeField] private Sprite PauseSpr, NoPauseSpr;
    Image Music_Component_Image,PauseImage;
    private Bird bird;
    private static Slider Music_Value_Slider;
    static float Music_Value =0.5f;

    static bool Cond_Music=true;
 
    private void Start()
    {
        Music_Value_Slider = GameObject.Find("SF Slider")?.GetComponent<Slider>();

      

        if(Cond_Music==true)
        {
            PlayerPrefs.SetString("ConditionMusic", "On");
            
            Cond_Music = false;
        
        }
        Music();


    }
    


    // Start is called before the first frame update
    void Awake()
    {
        Music_Component_Image = GameObject.Find("ButtonMusic")?.GetComponent<Image>();

        PauseImage = GameObject.Find("Pause")?.GetComponent<Image>();

        Phone_Music = GameObject.Find("Phone_Music_Controller")?.GetComponent<AudioSource>();

        bird = GameObject.Find("Bird").GetComponent<Bird>();

      
        

    }

   

    private void FixedUpdate()
    {
        if(Music_Value_Slider!=null)
        Music_Value_Slider.value = Music_Value;
    }
    public void Music()
    {



        Phone_Music.volume = Music_Value;

        if (Music_Component_Image  != null)//если есть кнопка звука - тогда меняется звук
        {
            if (PlayerPrefs.GetString("ConditionMusic").Equals("On"))
            {


                Music_Component_Image.sprite = Music_On;



                Phone_Music.clip = Phone_Clip;
                Phone_Music.loop = true;
                Phone_Music.Play();
                PlayerPrefs.SetString("ConditionMusic", "Off");



            }


            else if (PlayerPrefs.GetString("ConditionMusic").Equals("Off"))
            {

                Music_Component_Image.sprite = Music_Off;

                Phone_Music.Stop();
                PlayerPrefs.SetString("ConditionMusic", "On");


            }
        }

       

    }
    int i = 1;
    public void Pause()
    {
        if (bird.hill > 0)
        {
            switch (i)
            {

                case 1:

                    i = 0;
                    Time.timeScale = 0;
                    PauseImage.sprite = PauseSpr;
                     
                    Phone_Music.PlayOneShot(Button_Clip);

                    break;
                case 0:

                    i = 1;
                    Time.timeScale = 1;
                    PauseImage.sprite = NoPauseSpr;
                    Phone_Music.PlayOneShot(Button_Clip);
                    break;

            }
        }



    }

    public void Go_To_Menu(AudioClip ButtonClip)
    {
        Phone_Music.PlayOneShot(ButtonClip);

        SceneManager.LoadScene("Scene" + 0);
       

    }

    public void ReloadLastLevel(AudioClip ButtonClip)
    {
        Phone_Music.PlayOneShot(ButtonClip);
        SceneManager.LoadScene("Scene6");

    }
    public   void Slider_Music_Value()
    {


        Music_Value = Music_Value_Slider.value;
		Phone_Music.volume = Music_Value;





    }
    // Update is called once per frame

}
