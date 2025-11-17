using UnityEngine;
using UnityEngine.Rendering.Universal;
using System.Collections;


public class LuzPiscante : MonoBehaviour
{
    public Light2D luz;
    private bool aumentando = false;
    private bool aumentando2 = false;
    [SerializeField] private bool aumentar = true;
    [SerializeField] private bool diminuir = true;
    [SerializeField] private float esperarQuantoTempo;
    [SerializeField] private float minimo;
    [SerializeField] private float maximo;
    [SerializeField] private float velocidade;

    //luz muda de tamanho
    [SerializeField] private bool tamanhoMuda = false;
    [SerializeField] private float tamanhoMaximo;
    [SerializeField] private float tamanhoMinimo;
    [SerializeField] private float tamanhoVelocidade;

    //Luz curto circuito
    [SerializeField] private bool curtoCircuito = false;
    private bool desligada = false;


    void Start()
    {
        if (luz == null)
            luz = GetComponent<Light2D>();
    }

    void Update()
    {
        StartCoroutine(LuzPiscando());
        LanternaFalhando();
        falhaEletrica();
    }

    private IEnumerator LuzPiscando()
    {
        if (aumentando == false)
        {
            if(diminuir == true)
            {
                luz.intensity -= velocidade * Time.deltaTime;
                if (luz.intensity <= minimo)
                {
                    luz.intensity = minimo;
                    yield return new WaitForSeconds(esperarQuantoTempo);
                    aumentando = true;
                }
            }
            if(diminuir == false)
               aumentando = true;
        }
        else
        {

            if(aumentar == true)
            {
                aumentando = true;
                luz.intensity += velocidade * Time.deltaTime;
                if (luz.intensity >= maximo)
                {
                    luz.intensity = maximo;
                    yield return new WaitForSeconds(esperarQuantoTempo);
                    aumentando = false;
                }
            }
            //if (aumentar == true)
            //    aumentando = false;
        }
    }

    public void LanternaFalhando()
    {
        if (tamanhoMuda)
        {
            if (aumentando2 == true)
            {
                if (luz != null)
                {
                    luz.pointLightOuterRadius -= tamanhoVelocidade * Time.deltaTime;
                    if (luz.pointLightOuterRadius <= tamanhoMinimo)
                    {
                        aumentando2 = false;
                    }
                }
            }
            if (aumentando2 == false)
            {
                if(luz != null)
                {
                    luz.pointLightOuterRadius += tamanhoVelocidade * Time.deltaTime;
                    if (luz.pointLightOuterRadius >= tamanhoMaximo)
                    {
                        aumentando2 = true;
                    }
                
                }
            }
        }
    }

    private void falhaEletrica()
    {
        if(curtoCircuito == true)
        {
            if (desligada = true)
            {
                luz.enabled = true;
                desligada = false;
            }
            float chance = UnityEngine.Random.Range(0, 10); // Returns 0-9.
            if (chance <= 0)
            {
                luz.enabled = false;
                desligada = true;
            }
        }
    }
}
