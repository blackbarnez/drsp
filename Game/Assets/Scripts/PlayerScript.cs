using TMPro;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerScript : MonoBehaviour
{
    bool damagePlayer = false;
    public bool gameOver = false;
    bool shoot;
    public int scoreCount;

    public Vector2 speed = new Vector2(15, 15);
    

    private Vector2 movement;

    public TextMeshProUGUI score;
    public TextMeshProUGUI endScoreText;

    private void Start()
    {
        scoreCount = 0;
        score.SetText("Score: " + scoreCount);
    }
    void Update()
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }


        float inputX = Input.GetAxis("Horizontal");
        float inputY = Input.GetAxis("Vertical");
        if (!gameOver)
        {
         movement = new Vector2(
         speed.x * inputX,
         speed.y * inputY);

            shoot = Input.GetButtonDown("Fire1");
            shoot |= Input.GetButtonDown("Fire2");
        }
       

        if (shoot)
        {
            WeaponScript weapon = GetComponent<WeaponScript>();
            if (weapon != null)
            {
                weapon.Attack(false);
            }
        }
    }


    public void AddScore(int plus)
    {
        scoreCount += plus;
        score.SetText("Score: " + scoreCount);
        endScoreText.SetText("Your score: " + scoreCount);
    }


    void FixedUpdate()
    {

        GetComponent<Rigidbody2D>().velocity = movement;
        if ((transform.position.y > 10) || (transform.position.y < -10) ||
            (transform.position.x < -16) || (transform.position.x > 26))
        {

            gameOver = true;

        }

    }
}
