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
    public GameObject Scroller;


    //Variables
    private float time;
    public float spawnRate;
    private float cooldown;
    public bool objDestroid;
    public bool gameOver;
    private bool updated = false;
    public string causeOfGG = "Null";
    public int levelLoad = -1;
    public bool debugMode = false;


    //Init
    private void Start()
    {
        objDestroid = false;
        levelLoad = -1;
    }


    //Runtime
    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            time = Time.timeSinceLevelLoad;
            cooldown = cooldown - Time.deltaTime;
            if (!debugMode)
            {
                GameOver();
                Spawner();
                CheckObj();
                CheckPlanet();
                
                UpdateUI();
            }
            else
            {
                CheckObj();
                Spawner();
                gameOver = false;
            }
        }
        else if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                FindObjectOfType<AudioManager>().Play("Click");
                SceneManager.LoadScene(1);
            }
        }
        
    }

    private void UpdateUI()
    {
        if (gameOver)
        {
            gameOverUI.gameObject.SetActive(true);
            Scroller.GetComponent<BGScroll>().enabled = false;
            timeScore.fontSize = 50;
            timeScore.fontStyle = FontStyle.Bold;
            timeScore.alignment = TextAnchor.UpperCenter;
            if (!updated)
                timeScore.text = timeScore.text + "\n \n \n \n \n \n \n" + causeOfGG;
                updated = true;

            if (Input.GetKey("r"))
            {
                FindObjectOfType<AudioManager>().Play("Click");
                SceneManager.LoadScene(1);
            }
            else if (Input.GetKey("e"))
            {
                FindObjectOfType<AudioManager>().Play("Click");
                SceneManager.LoadScene(0);
            }

        }
        else
        {
            timeScore.text = " Time Alive : " + time.ToString("0");
        }
    }

    private void GameOver()
    {
        if (gameOver)
        {
            FindObjectOfType<Camera>().gameObject.GetComponent<FollowPlayer>().enabled = false;
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

        Instantiate(Asteroid, FindPos() + Player.transform.position, new Quaternion());
    }

    private Vector3 FindPos()
    {
        float rdVal = Random.value - 0.5f;
        float spawnX = Random.Range(35f,45f) * (rdVal/Mathf.Abs(rdVal));
        rdVal = Random.value - 0.5f;
        float spawnY = Random.Range(55f, 65f) * (rdVal / Mathf.Abs(rdVal));
        //Debug.Log(new Vector3(spawnX, spawnY, 0) + Player.transform.position);
        return new Vector3(spawnX,spawnY, 0);
    }

    private void LoadLevel()
    {
        if (levelLoad == -1)
            return;
        FindObjectOfType<AudioManager>().Play("Click");
        Debug.Log("Load");
        SceneManager.LoadScene(levelLoad);
    }


    void CheckPlanet()
    {
        if (!gameOver)
        {
            if ((Player.transform.position - Planet.transform.position).magnitude > 200f)
            {
                FindObjectOfType<AudioManager>().Play("Away");
                gameOver = true;
                causeOfGG = "The planet\ndrifted away";
                Destroy(Planet);
            }
        }
    }
}
