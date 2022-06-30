using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lut_Spawn : MonoBehaviour
{

    [SerializeField]
    private GameObject[] lut_spawn = new GameObject[2];
 public float Friqens_Spawn = 20;
    AppearController appear;
    void Start()
    {
        StartCoroutine("CreateLut");
        appear = GetComponent<AppearController>();
    }


    private IEnumerator CreateLut()
    {
        while (true)
        {
            Instantiate(lut_spawn[Random.Range(0, 2)], new Vector3(57f, transform.position.y, transform.position.z +3)- new Vector3(0,6,0), Quaternion.identity);
           

            yield return new WaitForSeconds(Friqens_Spawn);
        }


        
    }
    
}
