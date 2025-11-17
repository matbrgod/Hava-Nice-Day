using UnityEngine;
using System.Collections;

public class TriggerRatao : MonoBehaviour
{
    public GameObject vidaDoBoss;
    public GameObject animacao;
    
    public GameObject SpawnerRatinhos;

    private void OnTriggerStay2D(Collider2D objectThatStayed)
    {
        
        if (objectThatStayed.CompareTag("Player"))
        {
            StartCoroutine(Animacao());
        }
    }

    private IEnumerator Animacao()
    {
        yield return new WaitForSeconds(4f);
        if (animacao != null && !animacao.activeSelf)
        {
            animacao.SetActive(true);
            //StartCoroutine(ActivateTriggerWithDelay());
        }
        if (SpawnerRatinhos != null)
            SpawnerRatinhos.SetActive(true);
        yield return new WaitForSeconds(1f);
        if (vidaDoBoss != null)
        {
            vidaDoBoss.SetActive(true);
        }
        yield return new WaitForSeconds(1f);
        Object.Destroy(this.gameObject);
    }

    
}
