using UnityEngine;
using TMPro;

/// Handle hitpoints and damages
public class HealthScript : MonoBehaviour
{
    public int hp = 1;

    public Sprite[] sprites;
    SpriteRenderer playerSp;


    private void Start()
    {
        playerSp = gameObject.GetComponent<SpriteRenderer>();
    }

    public void Damage(int damageCount)
    {
        hp -= damageCount;

        if (hp >= 11) { playerSp.sprite = sprites[0]; }
        if (hp >= 7 && hp < 11) { playerSp.sprite = sprites[1]; }
        if (hp >= 3 && hp < 7) { playerSp.sprite = sprites[2]; }
        if (hp < 3) { playerSp.sprite = sprites[3]; }


        if (hp <= 1)
        {
            gameObject.GetComponent<Rigidbody2D>().gravityScale = 100;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Damage(1);
        }
    }

}
