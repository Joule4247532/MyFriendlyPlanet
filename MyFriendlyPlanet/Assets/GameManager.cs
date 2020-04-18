using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //References
    public GameObject Player;
    public GameObject Planet;
    public GameObject Asteroid;
    public Canvas UI;


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
        GameOver();
        
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
        if (time % spawnRate < 0.1f && cooldown <= 0f)
        {
            SpawnAsteroid();

            cooldown = 0.2f;
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
        if (loadMenu)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
