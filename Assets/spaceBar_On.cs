using UnityEngine;

public class spaceBar_On : MonoBehaviour
{
    public GameObject spaceBar;

    private void OnTriggerEnter2D(Collider2D triggerCollider)
    {
        if (triggerCollider.gameObject.CompareTag("Player"))
        {
            if(spaceBar != null) 
                spaceBar.SetActive(true);

            Object.Destroy(this.gameObject);
        }
    }
}
