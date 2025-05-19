using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class LoadingScreenManager : MonoBehaviour
{
    public string cenaParaCarregar;       // Nome da cena que ser� carregada (ex: "Gameplay")
    public Slider barraDeProgresso;       // Refer�ncia opcional para a barra de progresso na UI

    void Start()
    {
        StartCoroutine(CarregarCenaAsync()); // Inicia o carregamento ass�ncrono
    }

    IEnumerator CarregarCenaAsync()
    {
        // Come�a a carregar a cena em segundo plano
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
                yield return new WaitForSeconds(1f); // D� um tempo antes de trocar (ex: anima��o)
                operacao.allowSceneActivation = true; // Ativa a cena
            }

            yield return null; // Espera um frame
        }
    }
}


