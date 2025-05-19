using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterAudio : MonoBehaviour
{
    // Fonte de �udio que ser� tocada no in�cio (defina no Inspector)
    public AudioSource audioSource;

    // Objeto de UI (canvas) que ser� ativado ap�s o �udio
    public GameObject canvasObject;

    void Start()
    {
        // Se ambas as refer�ncias est�o definidas, inicia a coroutine
        if (audioSource != null && canvasObject != null)
        {
            StartCoroutine(PlayAudioThenShowCanvas());
        }
    }

    private void Update()
    {
        // Verifica se a tecla H foi pressionada para carregar a cena "loading2"
        loading2();
    }

    // Coroutine que toca o �udio e, ao terminar, exibe o canvas
    System.Collections.IEnumerator PlayAudioThenShowCanvas()
    {
        audioSource.Play();

        // Espera o tempo de dura��o do �udio
        yield return new WaitForSeconds(audioSource.clip.length);

        // Ativa o canvas ap�s o fim do �udio
        canvasObject.SetActive(true);
    }

    // Carrega a cena "loading2" ao pressionar H
    void loading2()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            SceneManager.LoadScene("loading2");
        }
    }
}



