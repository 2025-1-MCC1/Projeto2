using UnityEngine;

public class silicioOre : MonoBehaviour
{
    // Quantidade de silício que será adicionada ao inventário ao minerar
    public int amountToGive = 12;

    // Indica se o jogador está próximo do minério
    private bool playerNearby = false;

    void Update()
    {
        // Verifica se o jogador está perto e clicou com o botão esquerdo do mouse
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            // Procura o HotbarManager na cena
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se o HotbarManager existe e se o jogador está com a picareta selecionada
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                // Adiciona silício ao inventário
                hotbar.AddSilicio(amountToGive);

                // Destroi o objeto do minério após a coleta
                Destroy(gameObject);
            }
            else
            {
                // Mensagem de aviso se a picareta não estiver selecionada
                Debug.Log("Você precisa estar com a picareta selecionada!");
            }
        }
    }

    // Detecta quando o jogador entra na área de coleta do minério (collider com isTrigger)
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Detecta quando o jogador sai da área de coleta do minério
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}

