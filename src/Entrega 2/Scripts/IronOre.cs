using UnityEngine;

public class IronOre : MonoBehaviour
{
    public int amountToGive = 20;  // Quantidade de ferro que esse minério fornece

    private bool playerNearby = false; // Detecta se o jogador está perto

    void Update()
    {
        // Se o jogador está perto e clicou com o botão esquerdo
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se a picareta está selecionada
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                hotbar.AddIron(amountToGive); // Adiciona ferro ao inventário
                Destroy(gameObject);         // Destroi o minério
            }
            else
            {
                Debug.Log("Você precisa estar com a picareta selecionada!");
            }
        }
    }

    // Ativa detecção quando o jogador entra no trigger
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Desativa detecção ao sair do trigger
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}


