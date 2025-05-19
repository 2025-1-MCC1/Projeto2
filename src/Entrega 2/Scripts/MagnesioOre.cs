using UnityEngine;

public class MagnesioOre : MonoBehaviour
{
    public int amountToGive = 15; // Quantidade de magnésio a ser coletado

    private bool playerNearby = false; // Se o jogador está perto

    void Update()
    {
        if (playerNearby && Input.GetMouseButtonDown(0))
        {
            HotbarManager hotbar = FindObjectOfType<HotbarManager>();

            // Verifica se o jogador está com a picareta
            if (hotbar != null && hotbar.GetSelectedSlotIndex() == hotbar.pickaxeSlotIndex)
            {
                hotbar.AddMagnesio(amountToGive); // Adiciona magnésio à hotbar
                Destroy(gameObject); // Remove o minério da cena
            }
            else
            {
                Debug.Log("Você precisa estar com a picareta selecionada!");
            }
        }
    }

    // Quando o jogador entra na área do minério
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = true;
        }
    }

    // Quando o jogador sai da área do minério
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerNearby = false;
        }
    }
}
