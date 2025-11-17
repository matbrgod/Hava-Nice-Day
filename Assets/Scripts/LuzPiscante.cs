using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;


public class LuzPiscante : MonoBehaviour
{
    public Light2D luz;
    private bool aumentando = false;
    [SerializeField] private bool aumentar = true;
    [SerializeField] private bool diminuir = true;
    [SerializeField] private float esperarQuantoTempo;
    [SerializeField] private float minimo;
    [SerializeField] private float maximo;
    [SerializeField] private float velocidade;

    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light2D>();
        //velocidade = 4f;
    }

    void Update()
    {
        StartCoroutine(LuzPiscando());
    }

    private IEnumerator LuzPiscando()
    {
        if (!aumentando)
        {
            if(diminuir)
            {
                luz.intensity -= velocidade * Time.deltaTime;
                if (luz.intensity <= minimo)
                {
                    luz.intensity = minimo;
                    yield return new WaitForSeconds(esperarQuantoTempo);
                    aumentando = true;
                }
            }
            if(!diminuir)
                aumentando = true;
        }
        else
        {

            if(aumentar)
            {
                luz.intensity += velocidade * Time.deltaTime;
                if (luz.intensity >= maximo)
                {
                    luz.intensity = maximo;
                    yield return new WaitForSeconds(esperarQuantoTempo);
                    aumentando = false;
                }
            }
            if (aumentar)
                aumentando = false;
        }
    }
}
