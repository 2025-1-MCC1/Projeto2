// Simula o ciclo de dia e noite com base na rotação do Sol

using UnityEngine;

public class DiaENoite : MonoBehaviour
{
    [SerializeField] private Transform luzDirecional; // Sol
    [SerializeField][Tooltip("Duração do dia em segundos")] private int duracaoDoDia;

    private float segundos;
    private float multiplicador;

    void Start()
    {
        multiplicador = 86400f / duracaoDoDia; // 86400s = 24h
    }

    void Update()
    {
        segundos += Time.deltaTime * multiplicador;

        if (segundos >= 86400f)
            segundos = 0;

        processarCeu();
    }

    void processarCeu()
    {
        // Gira o Sol de -90 a 270 graus ao longo do "dia"
        float rotacaoX = Mathf.Lerp(-90, 270, segundos / 86400f);
        luzDirecional.rotation = Quaternion.Euler(rotacaoX, 0, 0);
    }
}

