using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{

    public int vidaParaDar;
    public bool PWDeVida;

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
            if(PWDeVida == true)
            {
                other.gameObject.GetComponent<PlayerLife>().GanharVida(vidaParaDar);                
            }
            
            Destroy(this.gameObject);
        }
    }
}
