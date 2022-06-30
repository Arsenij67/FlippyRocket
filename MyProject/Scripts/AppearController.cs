using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class AppearController : MonoBehaviour
{

    float second = 0;

    public void Start()
    {
       
    }

    public Vector3 IterationVector3;
    public float TimeSpawn;
    public float Destination_Spawn;
    public float MaxDistance, MinDistance;

    public GameObject[] block = new GameObject[3];


    private Cleaner clean;


    void Awake()
    {


        StartCoroutine(CreateBlock());
        


}
    int i=0;

    [HideInInspector]
    public Vector3 buff = Vector3.zero;

    public IEnumerator CreateBlock()
    {

        while (true)
        {
            int RandValue = Random.Range(0, 3);

            clean = block[RandValue].GetComponent<Cleaner>();

            GameObject AllBlock = block[RandValue];



            buff = new Vector3(57f, transform.position.y, transform.position.z + Random.Range(4, 8));



            IterationVector3 = new Vector3(0, Random.Range(0, 3),0)+ buff;



        GameObject OneBlockUp =   Instantiate(AllBlock, IterationVector3, Quaternion.identity);

          

            OneBlockUp.transform.tag = "Column";


           IterationVector3 = IterationVector3 - new Vector3(0, Random.Range(MinDistance,MaxDistance), 0);

      
            

            GameObject OneBlockDown =   Instantiate( AllBlock , IterationVector3, Quaternion.identity);

            OneBlockDown.transform.tag = "Column";



            clean.TimeDestory = 15+i++;
            


          yield return new WaitForSeconds(Destination_Spawn);
           
            if (second >= TimeSpawn)
            {
                StopAllCoroutines();
              
            }
        }
    }



   

     

    void FixedUpdate()
    {
        
        second += 0.02f;

       
        
    }
}
