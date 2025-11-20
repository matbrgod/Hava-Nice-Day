using UnityEngine;

public class triggerAttack : MonoBehaviour
{
     public Player player;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.canAttack = true;
           
        }
    }
}
