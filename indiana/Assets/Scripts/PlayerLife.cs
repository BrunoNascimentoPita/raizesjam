using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    // Vida do player
    public int vidaMaxPlayer;
    public int vidaAtualPlayer;

    public bool invulneravel = false;

    // colisão e sprite depois do dano

    public SpriteRenderer sprite;

    // barras de vida coração
    public GameObject coração1;
    public GameObject coração2;
    public GameObject coração3;
    public GameObject coração4;
    public GameObject coração5;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        vidaAtualPlayer = vidaMaxPlayer;

        coração1.SetActive(true);
        coração2.SetActive(true);
        coração3.SetActive(true);
        coração4.SetActive(true);
        coração5.SetActive(true);
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

        ChecarBarrasDeVida(); 
    }

    public void MachucarPlayer(int DanoParaReceber)
    {
        
        if(invulneravel == false)
        {
            vidaAtualPlayer -= DanoParaReceber;

            if(vidaAtualPlayer <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }

            ChecarBarrasDeVida();
        
        
            StartCoroutine("ReativarVulnerabilidade");
        }
        
    }

    IEnumerator ReativarVulnerabilidade()
    {
        invulneravel = true;
        for(int i = 0; i < 5; i++)
        {
            sprite.enabled = false;
            yield return new WaitForSeconds(0.1f);
            sprite.enabled = true;
            yield return new WaitForSeconds(0.1f);
        }
        
        yield return new WaitForSeconds(0.5f);
        invulneravel = false;
    }

    void ChecarBarrasDeVida()
    {
        if(vidaAtualPlayer >= 5)
        {
            coração1.SetActive(true);
            coração2.SetActive(true);
            coração3.SetActive(true);
            coração4.SetActive(true);
            coração5.SetActive(true);
        }
        else if(vidaAtualPlayer == 4)
        {
            coração1.SetActive(true);
            coração2.SetActive(true);
            coração3.SetActive(true);
            coração4.SetActive(true);
            coração5.SetActive(false);
        }
        else if(vidaAtualPlayer == 3)
        {
            coração1.SetActive(true);
            coração2.SetActive(true);
            coração3.SetActive(true);
            coração4.SetActive(false);
            coração5.SetActive(false);
        }
        else if(vidaAtualPlayer == 2)
        {
            coração1.SetActive(true);
            coração2.SetActive(true);
            coração3.SetActive(false);
            coração4.SetActive(false);
            coração5.SetActive(false);
        }
        else if(vidaAtualPlayer == 1)
        {
            coração1.SetActive(true);
            coração2.SetActive(false);
            coração3.SetActive(false);
            coração4.SetActive(false);
            coração5.SetActive(false);
        }
        else
        {
            coração1.SetActive(false);
            coração2.SetActive(false);
            coração3.SetActive(false);
            coração4.SetActive(false);
            coração5.SetActive(false);
        }
    }
}
