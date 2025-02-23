using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fillImage; // Arraste a imagem de transição aqui
    public float transitionSpeed = 10f; // Velocidade do efeito

    void Start()
    {
        fillImage.gameObject.SetActive(true); 
        StartCoroutine(FillOut()); // Faz o efeito de esvaziamento no início
    }

    public void ReloadScene()
    {
        StartCoroutine(FillInAndReload()); // Inicia a transição e recarrega a cena
    }

    IEnumerator FillOut()
    {
        float fill = 1f;
        while (fill > 0)
        {
            fill -= Time.deltaTime * transitionSpeed;
            fillImage.fillAmount = fill;
            yield return null;
        }
    }

    IEnumerator FillInAndReload()
    {
        float fill = 0f;
        while (fill < 1)
        {
            fill += Time.deltaTime * transitionSpeed;
            fillImage.fillAmount = fill;
            yield return null;
        }

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
