using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Animation Reset_Menu_Animation;
    // Start is called before the first frame update
    public static short number_level=1;
    [SerializeField] private GameObject Main_Menu;
    [SerializeField] private GameObject Quit_Menu;
    private Animation Exit_Menu;
    private Animation General_Menu;
    public Transform End_Point, Player_Now;
    public Slider Procent_Moved;
    private AudioSource Music_Button;
    public AudioClip Button_Clip;

    private float Change_RGBA;
    private Text Text_Level;
    

	private void Update()
	{
         
       
    }
	private void Start()
    {
        Procent_Moved = GameObject.FindWithTag("Slider_Procent")?.GetComponent<Slider>();
        Music_Button = GameObject.FindWithTag("GameController").GetComponent<AudioSource>();

       
        Change_RGBA = 1;


    }
 
    // Update is called once per frame
    void OnTriggerEnter(Collider colider)
    {
        if (colider.tag == "Player")
        {
            
            number_level += 1;
            PlayerPrefs.SetInt("Level_number", number_level);

            SceneManager.LoadScene("Scene" + PlayerPrefs.GetInt("Level_number"));
       
            PlayerPrefs.Save();

            Change_Rgba(1);

        }



    }


    public  async void Change_Rgba(int speed)
    {
        AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync($"Scene{PlayerPrefs.GetInt("Level_number")}");

        while (loadSceneAsync.progress < 1f)
        {
            await Task.Yield();

        }
        Text_Level = GameObject.Find("Text_Level").GetComponent<Text>();

        while (Change_RGBA > 0)
        {
            Change_RGBA = ((Text_Level.color.a - 0.3f * Time.deltaTime));

            Text_Level.color = new Color(1, 1, 1, Change_RGBA);

            Text_Level.text = "Level " + number_level;

            await Task.Delay(speed);
          
        }
       

    }
    /// <summary>
    /// Запускается при нажатии на Play
    /// </summary>
    public void Continue()
    {

        Music_Button.clip = Button_Clip;
        Music_Button.Play();

        if (PlayerPrefs.GetInt("Level_number") == 0)
        {
            PlayerPrefs.SetInt("Level_number", 1);
        }


        Change_Rgba(1);


    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Scene" + 0);
        Time.timeScale = 1;

    }

    public void QuitMenu()
    {

        General_Menu = Main_Menu.GetComponent<Animation>();

        

        Exit_Menu = Quit_Menu.GetComponent<Animation>();

        Exit_Menu.PlayQueued("Exit_Menu");

        General_Menu.PlayQueued("Main_Menu");









    }
    public void Yes()
    {
       
        Application.Quit();
        
         
       
    }
  

    public void No()
    {
        Exit_Menu.PlayQueued("Exit_Menu_2");

        General_Menu.PlayQueued("Main_Menu_2");



    }
    private void FixedUpdate()
    {
        if (SceneManager.GetSceneAt(0).name != "Scene0")
        Slider(End_Point,Player_Now);

     
    }

    public void Slider(Transform End_Point, Transform Player_Now)
    {
         
            End_Point = this.End_Point;
            Player_Now = this.Player_Now;
            float procent = Player_Now.transform.position.z / End_Point.transform.position.z;
            Procent_Moved.value = procent;

        

    }
}
