using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class treeScript : MonoBehaviour
{
    public GameObject tree;
    // Start is called before the first frame update
    public float speed;
    public bool tree_statu = false;
   
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed * Time.deltaTime)*-1, 0, 0);

        ////objeden yeni bir tane üretiliyor 
        //float rnd = Random.Range(0,2);
        //tree.transform.localPosition = new Vector2((float)10.58, -3.27f);
        ////transform.position = transform.position + new Vector3((float)10.58, -3.27f);
        //tree.SetActive(true);//Yeni pozisyondaki üyesi sahnede gösterdi;

        if (tree_statu)
        {
            
            Invoke("dublacate_tree", 0); //sadece bir sefer çalıştırmak istediğimiz metdolarda kullanılır (invoke)
            tree_statu = false;
              
        }
        
      
    }
    private void dublacate_tree()
    {
        Instantiate(tree, new Vector3((float)10.58, -3.27f,-1), Quaternion.identity);
        Invoke("hide_fnc", 2);
        
    }

     private void hide_fnc()
    {
        // tree.SetActive(false);//nesneyi sahneden  kaldır
        Destroy(tree, 0);
    }

   
}

