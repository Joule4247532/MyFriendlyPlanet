using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //References
    public GameObject Player;
    public GameObject Planet;
    public GameObject Asteroid;
    public GameObject gameOverUI;
    public Text timeScore;


    //Variables
    private float time;
    public float spawnRate;
    private float cooldown;
    public bool objDestroid;
    public bool gameOver;


    //Init
    private void Start()
    {
        objDestroid = false;
    }


    //Runtime
    private void Update()
    {
        time = Time.timeSinceLevelLoad;
        cooldown = cooldown - Time.deltaTime;

        Spawner();
        CheckObj();
        CheckPlanet();
        GameOver();
        UpdateUI();
        
    }

    private void UpdateUI()
    {
        if (gameOver)
        {
            FindObjectOfType<Camera>().gameObject.GetComponent<FollowPlayer>().enabled = false;
            gameOverUI.gameObject.SetActive(true);
            timeScore.gameObject.SetActive(false);
        }

        timeScore.text = "Time Alive : " + time.ToString("0");
    }

    private void GameOver()
    {
        if (gameOver)
        {

        }
    }

    private void CheckObj()
    {
        if (objDestroid)
        {
            objDestroid = false;
            SpawnAsteroid();
        }
    }

    private void Spawner()
    {
        if (!gameOver)
        {
            if (time % spawnRate < 0.1f && cooldown <= 0f)
            {
                SpawnAsteroid();

                cooldown = 0.2f;
            }
        }
    }

    private void SpawnAsteroid()
    {

        Instantiate(Asteroid, FindPos(), new Quaternion());
    }

    private Vector3 FindPos()
    {
        float rdVal = Random.value - 0.5f;
        float spawnX = Random.Range(35f,45f) * (rdVal/Mathf.Abs(rdVal)) + Player.transform.position.x;
        rdVal = Random.value - 0.5f;
        float spawnY = Random.Range(55f, 65f) * (rdVal / Mathf.Abs(rdVal)) + Player.transform.position.y;
        return new Vector3(spawnX,spawnY, 0);
    }

    public void LoadLevel(bool loadMenu)
    {
        Debug.Log("Load");
        if (loadMenu)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }

    void CheckPlanet()
    {
        if (!gameOver)
        {
            if ((Player.transform.position - Planet.transform.position).magnitude > 200f)
            {
                gameOver = true;
                Destroy(Planet);
            }
        }
    }
}
