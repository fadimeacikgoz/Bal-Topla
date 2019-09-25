using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvyScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float speed;
    public GameObject lvy;
    public bool lvy_statu = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate((speed * Time.deltaTime) * -1, 0, 0);
        if (lvy_statu)
        {
            //Instantiate(tree, new Vector2((float)10.58, -3.27f), Quaternion.identity);
            // tree_statu = false;
            Invoke("dublacate_lvy", 0); //sadece bir sefer çalıştırmak istediğimiz metdolarda kullanılır (invoke)
            lvy_statu = false;

        }
    }
    private void dublacate_lvy()
    {
        Instantiate(lvy, new Vector3((float)1.15,3.58f,  -1), Quaternion.identity);
        Invoke("hide_fnc", 2);

    }

    private void hide_fnc()
    {
        //lvy.SetActive(false);//nesneyi sahneden  kaldır
        Destroy(lvy, 0);//0 sn ortadan kaldırır
    }

}
