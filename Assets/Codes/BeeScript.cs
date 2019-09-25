using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeeScript : MonoBehaviour
{   //açılışta gelen panle kontrolu 
    public GameObject startPanel;
    //  sahnede bulunan text nesnesi üretiliyor
    public Text distanceText,flowerText,maxFlowerText,maxDistanceText;
    int flowercount;
    public float distance;
    public float speed, upSpeed;
    void Start()
    {
        Time.timeScale = 0;//Zaman aralığı zamanı durdur, 
        maxFlowerText.text = "" + PlayerPrefs.GetInt("flower_max", 0);
        maxDistanceText.text = "" + PlayerPrefs.GetInt("distance_max", 0);
    }
    

    // Update is called once per frame
    void Update()
    {
        distance += 1 * Time.deltaTime;
        distanceText.text = "" + (int)distance + "Mt";
      
        transform.Translate(speed * Time.deltaTime, 0, 0);
        //boşluk tusuna basıldıgında yapılacak işlemler 

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * upSpeed);//Zıplamasını saglıyor
        }

        //Sahnede herhangi bir yere tıklandıgında  saglıyor
        foreach (Touch touch in Input.touches)
        {
            if(touch.phase== TouchPhase.Began) //began tıklandıgında 
            {
                GetComponent<Rigidbody2D>().AddForce(Vector2.up * upSpeed);
            }
        }


    }
    //çarptiği nesnenin degerin game objesine atar
    private void OnTriggerEnter2D(Collider2D obj)
    {
        //gost tag
        if(obj.gameObject.tag == "tree_gost_tag")
        {
            Debug.Log("tree_gost_tag" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<treeScript>().tree_statu = true;
        }

        if (obj.gameObject.tag == "ıvy_gost_tag")
        {
            Debug.Log("ıvy_gost_tag");
            obj.gameObject.transform.root.gameObject.GetComponent<lvyScript>().lvy_statu = true;
        }

        if (obj.gameObject.tag == "tree_small_gost_tag")
        {
            Debug.Log("tree_small_gost_tag");
            obj.gameObject.transform.root.gameObject.GetComponent<bushScript>().tree_small_statu = true;
        }
        if (obj.gameObject.tag == "flower_tag")
        {
            Debug.Log("flower_tag" + obj.gameObject.name);
            obj.gameObject.transform.root.gameObject.GetComponent<flowerScript>().flower_statu = true;
            flowercount++;
            flowerText.text = "" + flowercount + " ";
        }
        if (obj.gameObject.tag == "flower_gost_tag")
        {
            Debug.Log("flower_gost_tag" + obj.gameObject.name);
        }
    }


    private void OnCollisionEnter2D(Collision2D obj)
    {
        if (obj.gameObject.tag == "tree_tag")
        {
          
            gameOver();
                
        }
        if (obj.gameObject.tag == "bush_tag")
        {
            gameOver();
        }
        if (obj.gameObject.tag == "ıvy_tag")
        {
            gameOver();

        }
       

    }
    public void gamestart()
    {
        Debug.Log("Start btn call");
        startPanel.SetActive(false);//paneli gizlee
        Time.timeScale = 1;//Zaman aralığı zamanı durdur,
    }

    private void gameOver(){
        int flower_max = PlayerPrefs.GetInt("flower_max", 0);
        int distance_max = PlayerPrefs.GetInt("distance_max", 0);
        if (flowercount> flower_max)
        {
            // daha önce puanı yok direkt yaz
            PlayerPrefs.SetInt("flower_max", flowercount);
      
        }

        if (distance > distance_max)
        {
            // daha önce puanı yok direkt yaz
          
            PlayerPrefs.SetInt("distance_max", (int)distance);
        }

        Time.timeScale = 0;//Zaman aralığı zamanı durdur,

    }
   
}
