using UnityEngine;

public class veneno : MonoBehaviour
{
    public int dano = 1;
    public float tempoDeVida = 1f; // Tempo em segundos antes de desaparecer

    void Start()
    {
        Destroy(gameObject, tempoDeVida);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Supondo que o player tenha um m�todo chamado "LevarDano"
            other.SendMessage("LevarDano", dano, SendMessageOptions.DontRequireReceiver);
        }
    }
}   