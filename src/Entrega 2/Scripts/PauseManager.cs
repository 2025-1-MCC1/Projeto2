using UnityEngine;

public class PauseManager : MonoBehaviour
{
    // Referência ao menu de pausa
    public GameObject pauseMenu;

    // Estado atual do jogo (pausado ou não)
    private bool isPaused = false;

    // Referência ao transform do jogador (usado para salvar posição)
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

    // Salva o jogo e fecha a aplicação
    public void SaveAndQuit()
    {
        SaveGame();
        Application.Quit();
        // Para voltar ao menu, use: SceneManager.LoadScene("MainMenu");
    }

    // Salva a posição do jogador
    void SaveGame()
    {
        PlayerPrefs.SetFloat("PlayerX", player.position.x);
        PlayerPrefs.SetFloat("PlayerY", player.position.y);
        PlayerPrefs.SetFloat("PlayerZ", player.position.z);
        PlayerPrefs.Save();

        Debug.Log("Jogo salvo!");
    }
}


