using UnityEngine;

public class interactionRobot : MonoBehaviour
{
    public GameObject menuCanvas;      // Menu que aparece ao apertar "E"
    public GameObject messageCanvas;   // Mensagem do tipo "Aperte E para interagir"

    private bool interaction = false;  // Se o jogador está na área de interação

    void Update()
    {
        // Se o jogador está perto e apertou "E"
        if (interaction && Input.GetKeyDown(KeyCode.E))
        {
            menuCanvas.SetActive(true);              // Mostra o menu principal
            Time.timeScale = 0f;                     // Pausa o jogo
            Cursor.visible = true;                   // Mostra o cursor
            Cursor.lockState = CursorLockMode.None;  // Libera o cursor
        }
    }

    // Quando o jogador entra na área do robô
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction = true;
            messageCanvas.SetActive(true); // Mostra a mensagem "Aperte E"
        }
    }

    // Quando o jogador sai da área
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            interaction = false;
            messageCanvas.SetActive(false); // Esconde a mensagem
        }
    }
}


