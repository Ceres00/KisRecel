using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class ZeminHareket : MonoBehaviour
{
    public Transform karakter;
    public float hareketHizi = 5f;

    void Update()
    {
        HareketEt();
    }

    void HareketEt()
    {
     
        Vector2 hareketYonu = karakter.position - transform.position;

      
        GetComponent<Rigidbody2D>().velocity = hareketYonu.normalized * hareketHizi;
    }
}

