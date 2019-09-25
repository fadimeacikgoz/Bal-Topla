using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerScript : MonoBehaviour
{
    public GameObject flower;
    public float speed;
     
    public bool flower_statu = false;
    public bool flower_gost_statu = false;
    
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        transform.Translate((speed * Time.deltaTime) * -1, 0, 0);
        if (flower_statu && flower_gost_statu== false)
        {
            Invoke("fnc_settings", 0);
            
           
            flower_statu = false;
        }
        else
        {
            Invoke("fnc_settings", 10);
            flower_gost_statu = false;
        }
    }
    private  void fnc_settings()
    {
       
        //new flower create
        float rn1 = Random.Range(3.5f, -3.5f);
        Instantiate(flower, new Vector3((float)10.0f, rn1, -1), Quaternion.identity);
        Destroy(flower, 0);
    }
}
