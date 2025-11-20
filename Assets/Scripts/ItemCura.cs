using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class ItemCura : MonoBehaviour
{
    [Tooltip("Quantidade de vida que este item restaura")]
    public int healAmount = 25;

    [Tooltip("Prefab de efeito visual opcional ao coletar")]
    public GameObject pickupEffect;

    [Tooltip("Som opcional ao coletar")]
    public AudioClip pickupSound;

    void Start()
    {
   
        var col = GetComponent<Collider2D>();
        if (col != null)
            col.isTrigger = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (!other.CompareTag("Player"))
            return;

        if (Player.instance == null)
            return;

        
        int current = Player.instance.healthPlayer;
        int max = Player.instance.maxHealthPlayer;
        int newHealth = Mathf.Min(current + healAmount, max);

        
        if (newHealth == current)
            return;

        Player.instance.healthPlayer = newHealth;

        if (Player.instance.healthText != null)
            Player.instance.healthText.text = "" + Player.instance.healthPlayer;

        
        if (pickupEffect != null)
            Instantiate(pickupEffect, transform.position, Quaternion.identity);

        
        if (pickupSound != null)
            AudioSource.PlayClipAtPoint(pickupSound, Camera.main != null ? Camera.main.transform.position : transform.position);

        Destroy(gameObject);
    }
}
