
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {
    public GameObject enemy;
    public GameObject enemy2;
    public GameObject planet;
    public GameObject player;
    public float interval = 2;
    public float startDelay = 4;
    public float planetInterval = 2;
    public float planetStartDelay = 4;
    public GameObject endGameScreen;


    // Use this for initialization
    void Start () {
        InvokeRepeating("SpwnEnemys", startDelay, interval);
        InvokeRepeating("SpwnEnemys2", startDelay*3, interval*3);
        InvokeRepeating("SpwnPlanets", planetStartDelay, planetInterval);
     
       
        
    }
	
	// Update is called once per frame
	void Update () {

        if (player.GetComponent<PlayerScript>().gameOver)
        {
            GameOver();
        }

    }


    public void GameOver()
    {
        endGameScreen.SetActive(true);
    }
    public  void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void SpwnEnemys()
    {

        Instantiate(enemy, new Vector3(transform.position.x, Random.Range(-7,7),transform.position.z), enemy.transform.rotation);
    }

    void SpwnEnemys2()
    {

        Instantiate(enemy2, new Vector3(transform.position.x, Random.Range(-7, 7), enemy2.transform.position.z), enemy.transform.rotation);
    }

    void SpwnPlanets()
    {
        
        Instantiate(planet, new Vector3(transform.position.x, Random.Range(-7, 7), planet.transform.position.z), planet.transform.rotation);
    }
}
