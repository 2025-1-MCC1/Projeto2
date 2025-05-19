using UnityEngine;
using UnityEngine.SceneManagement;

public class StarterAudio : MonoBehaviour
{
    // Fonte de áudio que será tocada no início (defina no Inspector)
    public AudioSource audioSource;

    // Objeto de UI (canvas) que será ativado após o áudio
    public GameObject canvasObject;

    void Start()
    {
        // Se ambas as referências estão definidas, inicia a coroutine
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

    // Coroutine que toca o áudio e, ao terminar, exibe o canvas
    System.Collections.IEnumerator PlayAudioThenShowCanvas()
    {
        audioSource.Play();

        // Espera o tempo de duração do áudio
        yield return new WaitForSeconds(audioSource.clip.length);

        // Ativa o canvas após o fim do áudio
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



