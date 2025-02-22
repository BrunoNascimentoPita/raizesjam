using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    // Vida do player
    public int vidaMaxPlayer;
    public int vidaAtualPlayer;

    // colisão e sprite depois do dano
    public BoxCollider2D boxCol2D;
    public SpriteRenderer sprite;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtualPlayer = vidaMaxPlayer;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GanharVida(int vidaParaReceber)
    {
        Debug.Log("Ganhar vida foi chamado");
        
        if(vidaAtualPlayer + vidaParaReceber > vidaMaxPlayer)
        {
            vidaAtualPlayer = vidaMaxPlayer;
        }
        else
        {
            vidaAtualPlayer += vidaParaReceber;
        }   
    }

    public void MachucarPlayer(int DanoParaReceber)
    {
        vidaAtualPlayer -= DanoParaReceber;
        if(vidaAtualPlayer <= 0)
        {
            //GameManager.instance.GameOver();
        }
        
        boxCol2D.enabled = false;
        StartCoroutine("ReativarBoxCollider2D");
    }

    IEnumerator ReativarBoxCollider2D()
    {
        for(int i = 0; i < 5; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(0.5f);
        boxCol2D.enabled = true;
    }
}
