using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bushScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject tree_small;
    public bool tree_small_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed * Time.deltaTime) * -1, 0, 0);
        if (tree_small_statu)
        {
            //Instantiate(tree, new Vector2((float)10.58, -3.27f), Quaternion.identity);
            // tree_statu = false;
            Invoke("dublacate_tree_small", 0); //sadece bir sefer çalıştırmak istediğimiz metdolarda kullanılır (invoke)
            tree_small_statu = false;

        }
    }
    private void dublacate_tree_small()
    {
        Instantiate(tree_small, new Vector3((float)12.58, -4.27f, -1), Quaternion.identity);
        Invoke("hide_fnc", 2);
    }
    private void hide_fnc()
    {
        //lvy.SetActive(false);//nesneyi sahneden  kaldır
        Destroy(tree_small, 0);//0 sn ortadan kaldırır
    }

}
