using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    public string cenaParaCarregar;       // Nome da cena que será carregada (ex: "Gameplay")
    public Slider barraDeProgresso;       // Referência opcional para a barra de progresso na UI

    void Start()
    {
        StartCoroutine(CarregarCenaAsync()); // Inicia o carregamento assíncrono
    }

    IEnumerator CarregarCenaAsync()
    {
        // Começa a carregar a cena em segundo plano
        AsyncOperation operacao = SceneManager.LoadSceneAsync(cenaParaCarregar);
        operacao.allowSceneActivation = false; // Evita que a cena ative automaticamente ao chegar em 90%

        while (!operacao.isDone)
        {
            // Calcula o progresso (normalizado entre 0 e 1)
            float progresso = Mathf.Clamp01(operacao.progress / 0.9f);

            // Atualiza a barra se ela existir
            if (barraDeProgresso != null)
                barraDeProgresso.value = progresso;

            // Quando a cena estiver praticamente pronta
            if (operacao.progress >= 0.9f)
            {
                yield return new WaitForSeconds(1f); // Dá um tempo antes de trocar (ex: animação)
                operacao.allowSceneActivation = true; // Ativa a cena
            }

            yield return null; // Espera um frame
        }
    }
}


