using UnityEngine;

public class titanioOre : MonoBehaviour
{
    // Quantidade de titânio que será adicionada ao inventário ao minerar
    public int amountToGive = 9;

    // Indica se o jogador está próximo do minério
    private bool playerNearby = false;

    void Update()
    {
        // Verifica se o jogador está perto e clicou com o botão esquerdo do mouse
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            // Procura o HotbarManager na cena
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se a picareta está selecionada
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                // Adiciona titânio ao inventário e destrói o minério da cena
                hotbar.AddTitanio(amountToGive);
                Destroy(gameObject);
            }
            else
            {
                Debug.Log("Você precisa estar com a picareta selecionada!");
            }
        }
    }

    // Detecta quando o jogador entra na área do minério
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Detecta quando o jogador sai da área do minério
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}

