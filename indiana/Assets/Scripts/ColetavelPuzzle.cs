using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColetavelPuzzle : MonoBehaviour
{
    public bool coletavel1;
    public bool coletavel2;
    public bool coletavel3;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {        
            Destroy(this.gameObject);
        }
    }
}
