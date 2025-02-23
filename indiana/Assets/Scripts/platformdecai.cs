using UnityEngine;

public class DesativarAtrasado : MonoBehaviour
{
    private float tempoParaDesativar = 0.7f; // Tempo antes de desativar
    private bool ativado = false; // Para evitar múltiplas ativações
public Animator platformAnim;
void Start(){

    platformAnim = GetComponent<Animator>();
    platformAnim.Play("madeiranormal");
}
      void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player")&& !ativado)
        {
           platformAnim.Play("madeiraquebrar");
            ativado = true;
            Invoke("DesativarObjeto", tempoParaDesativar); // Chama a função após 4 segundos
            Debug.Log("chamado");
        }
    }

    void DesativarObjeto()
    {
        
        gameObject.SetActive(false); // Desativa o objeto
    }
}
