using UnityEngine;
using UnityEngine.UI;
using StarterAssets;

public class PlayerStats : MonoBehaviour
{
    // Barras de energia do jogador, energia da base e taxa habitável
    public Slider energia, energyBase, taxaHabitavel;

    // Referência ao controlador de personagem
    public ThirdPersonController character;

    // Lista de todos os painéis solares na cena
    public GameObject[] paineisSolares;

    // Tela de morte
    public GameObject morte;

    // Se o jogador está na área de carregamento
    bool carregamento = false;

    void Start()
    {
        energia.value = 500f;           // Energia inicial do jogador
        taxaHabitavel.value = 0f;       // Taxa habitável começa em 0
    }

    void Update()
    {
        taxaEnergy();                   // Controla drenagem e recarga da energia do jogador
        taxaEnergyBase();              // Atualiza a energia da base com base nos painéis
        dead();                        // Verifica se jogador deve morrer
    }

    // Atualiza a energia da base
    void taxaEnergyBase()
    {
        if (TodosPaineisAtivos())      // Se todos painéis estão ligados
        {
            energyBase.value = energyBase.maxValue; // Energia da base no máximo
        }
        else
        {
            energyBase.value -= Time.deltaTime; // Diminui energia com o tempo
        }
    }

    // Atualiza energia do jogador
    void taxaEnergy()
    {
        if (carregamento)
        {
            energia.value += Time.deltaTime * 5f; // Recarga rápida ao carregar
        }

        // Se o jogador está se movendo ou correndo
        if (Input.GetAxis("Horizontal") != 0 && Input.GetKey(KeyCode.LeftShift) || Input.GetAxis("Vertical") != 0)
        {
            energia.value -= Time.deltaTime * 2f; // Gasta mais energia ao correr
        }
        else
        {
            energia.value -= Time.deltaTime; // Gasto normal
        }
    }

    // Checa se todos painéis estão ativos
    bool TodosPaineisAtivos()
    {
        foreach (GameObject painel in paineisSolares)
        {
            if (!painel.activeSelf) // Se qualquer painel estiver desligado
                return false;
        }
        return true;
    }

    // Quando entra na zona de carregamento
    private void OnTriggerEnter(Collider loading)
    {
        if (loading.CompareTag("carregamento"))
        {
            carregamento = true;
        }
    }

    // Quando sai da zona de carregamento
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("carregamento"))
        {
            carregamento = false;
        }
    }

    // Verifica se jogador ou base morreu
    void dead()
    {
        if (energia.value <= 0f || energyBase.value <= 0)
        {
            morte.SetActive(true); // Ativa tela de morte
        }
    }
}



