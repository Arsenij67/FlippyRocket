using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangeButton : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    Bird bird;

    
    public AudioClip ClipRePush;
    private AudioSource ButtonSource;
    [SerializeField] Sprite Retry1;
    [SerializeField] Sprite Retry2;
    ButtonReaction Phone_Clip;

    public Animation Reset_Menu_Animation;
    public Animation Main_Window;
  
 

  
    void Start()
    { 
        bird = GameObject.Find("Bird").GetComponent<Bird>();
        ButtonSource = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();
        Phone_Clip = gameObject.GetComponent<ButtonReaction>();

        


    }

 
     

    public void OnPointerEnter(PointerEventData eventData)
    {
      
        gameObject.GetComponent<Image>().sprite = Retry2;
        ButtonSource.clip = ClipRePush;
        ButtonSource.PlayOneShot(ClipRePush);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
      
        GetComponent<Image>().sprite = Retry1;
      

    }
     
    public void Mail()
    {
        Application.OpenURL("https://vk.com/id446930815");

    }
    public void Return()
    {
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);



    }
	public void Raset()
	{
        Reset_Menu_Animation.PlayQueued("Exit_Menu");
        Main_Window.PlayQueued("Main_Menu");

       
      

    }

    public void YesReset()
    {
        PlayerPrefs.DeleteKey("Level_number");

        Reset_Menu_Animation.PlayQueued("Exit_Menu_2");
        Main_Window.PlayQueued("Main_Menu_2");
    }

    public void NoReset()
    {
        Reset_Menu_Animation.PlayQueued("Exit_Menu_2");
        Main_Window.PlayQueued("Main_Menu_2");
    }











}
