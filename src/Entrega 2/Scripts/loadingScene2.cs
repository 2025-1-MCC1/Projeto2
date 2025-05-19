using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class loadingScene2 : MonoBehaviour
{
    public string cenaParaCarregar;       // Nome da cena que ser� carregada
    public Slider barraDeProgresso;       // Refer�ncia opcional da barra de progresso

    void Start()
    {
        StartCoroutine(CarregarCenaAsync()); // Come�a a carregar ao iniciar a cena
    }

    IEnumerator CarregarCenaAsync()
    {
        AsyncOperation operacao = SceneManager.LoadSceneAsync(cenaParaCarregar);
        operacao.allowSceneActivation = false;

        while (!operacao.isDone)
        {
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);

            if (barraDeProgresso != null)
                barraDeProgresso.value = progresso;

            if (operacao.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f); // Espera 1 segundo
                operacao.allowSceneActivation = true;
            }

            yield return null;
        }
    }
}

