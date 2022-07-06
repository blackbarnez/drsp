using UnityEngine;
public class ShotScript : MonoBehaviour
{
 
    public int damage = 1;
    public bool isEnemyShot = false;
    public int scoreCount;
    GameObject player;
    PlayerScript playerScript;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerScript>();
    }
    void Start()
    {
        // Ограниченное время жизни, чтобы избежать утечек
        Destroy(gameObject, 20); // 20 секунд
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!isEnemyShot && collision.gameObject.CompareTag("Enemy")&& collision.gameObject.transform.position.x<27)
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            playerScript.AddScore(1);
            Debug.Log(scoreCount);
        }
        if (isEnemyShot && collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<HealthScript>().Damage(1);
            Destroy(gameObject);
        }
    }
    
}
