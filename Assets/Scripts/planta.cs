using UnityEngine;
using System.Collections;

public class planta : MonoBehaviour
{
    public float healthEnemy;
    public float maxHealthEnemy = 3f;
    public float distanciaParaAtacar = 5f;
    public float tempoEntreTiros = 2f;
    public GameObject projetilPrefab;
    public Transform pontoDeDisparo;

    private Transform jogador;
    private float tempoUltimoTiro;
    private Estado estadoAtual = Estado.Idle;
    private Renderer rend;
    private Color corOriginal;


    private enum Estado
    {
        Idle,
        Atacando
    }

    void Start()
    {
        healthEnemy = maxHealthEnemy;
        GameObject objJogador = GameObject.FindGameObjectWithTag("Player");
        if (objJogador != null)
            jogador = objJogador.transform;
        rend = GetComponent<Renderer>();
        if (rend != null)
            corOriginal = rend.material.color;
    }

    void Update()
    {
        if (jogador == null)
            return;

        float distancia = Vector2.Distance(transform.position, jogador.position);

        switch (estadoAtual)
        {
            case Estado.Idle:
                if (distancia <= distanciaParaAtacar)
                    estadoAtual = Estado.Atacando;
                break;

            case Estado.Atacando:
                if (distancia > distanciaParaAtacar)
                {
                    estadoAtual = Estado.Idle;
                }
                else
                {
                    Atacar();
                }
                break;
        }
    }

    void Atacar()
    {
        if (Time.time - tempoUltimoTiro >= tempoEntreTiros)
        {
            Instantiate(projetilPrefab, pontoDeDisparo.position, Quaternion.identity);
            tempoUltimoTiro = Time.time;
        }
    }
    public void TakeDamage(float damage)
    {
        healthEnemy -= damage;
        StartCoroutine(Piscar());
        if (healthEnemy <= 0)
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator Piscar()
    {
        rend.material.color = Color.red;
        yield return new WaitForSeconds(0.3f);
        rend.material.color = corOriginal;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bullet"))
        {
           healthEnemy -= 1;// Assuming each bullet reduces health by 1
           if (healthEnemy <= 0)
            {
                Destroy(gameObject);
            }


        }
    }
}