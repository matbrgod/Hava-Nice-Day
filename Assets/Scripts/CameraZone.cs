using System.Collections;
using UnityEngine;

public class CameraZone : MonoBehaviour
{
    [Tooltip("CameraFollow instance (optional). If null the script will find one in the scene.")]
    public CameraFollow cameraFollow;
    [Tooltip("Transform the camera should move to while player is inside the zone.")]
    public Transform cameraPoint;
    public float panMoveSpeed = 5f;
    public float holdSeconds = 3f;

    private bool triggered = false;
    public float delay;
    public GameObject hudArma;
    public GameObject hudVida;
    public GameObject quest0;
    public GameObject quest01;
    public Enemy enemy;
    public BossPatrol bossPatrol;
    public Animator animator;
    public BossIgreja bossIgreja; // Na BossIgreja a batalha começa no fim da cutscene
    [SerializeField] private bool pararMusica = false;
    [SerializeField] private bool Destroir = false;

    //luzes
    public GameObject luzes;
    public GameObject luzCamera;

    private void Start()
    {
        if (cameraFollow == null)
            cameraFollow = FindObjectOfType<CameraFollow>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (triggered) return;
        if (!other.CompareTag("Player")) return;
        if (cameraFollow == null || cameraPoint == null) return;
        hudArma.SetActive(false);
        hudVida.SetActive(false);
        quest0.SetActive(false);
        if (pararMusica)
            MusicManager.Instance.PlayMusic("Parar");
        if (luzes != null)
            luzes.SetActive(true);
        if (luzCamera != null)
            luzCamera.SetActive(true);
        if (enemy != null)
            enemy.enemyAnimator.SetBool("IsEating", true);
        var player = FindObjectOfType<Player>();
        if (player != null) player.canAttack = false;
        FindObjectOfType<Player>().moveSpeed = 0f;

        triggered = true;
        cameraFollow.LockCameraAt(cameraPoint.position, cameraPoint.rotation, panMoveSpeed, holdSeconds);
        StartCoroutine (ResetTriggerAfterDelay(delay));
    }


    
    private IEnumerator ResetTriggerAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        hudArma.SetActive(true);
        hudVida.SetActive(true);
        if (quest01 != null)
            quest01.SetActive(true);
        if (enemy != null)
            enemy.enemyAnimator.SetBool("IsEating", false);
        if (luzCamera != null)
            luzCamera.SetActive(false);
        var player = FindObjectOfType<Player>();
        if (player != null) player.canAttack = true;
        FindObjectOfType<Player>().moveSpeed = 5f;
        if(bossIgreja != null) bossIgreja.HoraDoDuelo();
        if (bossPatrol != null) bossPatrol.enabled = true;
        if (animator != null) animator.enabled = true;
        if (Destroir) Destroy(gameObject);
    }
}