using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Refer�ncia ao menu de pausa
    public GameObject pauseMenu;

    // Estado atual do jogo (pausado ou n�o)
    private bool isPaused = false;

    // Refer�ncia ao transform do jogador (usado para salvar posi��o)
    public Transform player;

    void Update()
    {
        // Alterna entre pausar e despausar quando o jogador pressiona Esc
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    // Pausa o jogo
    void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    // Retoma o jogo
    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    // Salva o jogo e fecha a aplica��o
    public void SaveAndQuit()
    {
        SaveGame();
        Application.Quit();
        // Para voltar ao menu, use: SceneManager.LoadScene("MainMenu");
    }

    // Salva a posi��o do jogador
    void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.position.z);
        PlayerPrefs.Save();

        Debug.Log("Jogo salvo!");
    }
}


