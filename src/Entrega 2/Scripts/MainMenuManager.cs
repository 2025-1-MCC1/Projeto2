using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public string nomeCenaJogo = "Gameplay"; // Nome da cena principal

    // Começa um novo jogo
    public void NovoJogo()
    {
        PlayerPrefs.DeleteAll(); // Limpa dados antigos
        SceneManager.LoadScene(nomeCenaJogo); // Carrega a cena do jogo
    }

    // Carrega jogo salvo (se houver dados)
    public void CarregarJogo()
    {
        if (PlayerPrefs.HasKey("PlayerX"))
        {
            SceneManager.LoadScene(nomeCenaJogo);
        }
        else
        {
            Debug.Log("Nenhum jogo salvo encontrado!");
            // Aqui poderia exibir aviso visual
        }
    }

    // Fecha o jogo
    public void Sair()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}


