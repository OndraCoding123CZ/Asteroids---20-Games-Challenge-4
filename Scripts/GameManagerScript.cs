using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class GameManagerScript : MonoBehaviour
{

    [SerializeField] GameObject Bullet;
    [SerializeField] GameObject PlayerSpaceShip;
    [SerializeField] GameObject PlayerSpaceShipNose;
    [SerializeField] GameObject Asteroid;
    [SerializeField] GameObject SmallAsteroid;
    [SerializeField] GameObject YouHaveDiedText;
    [SerializeField] GameObject RestartButton;
    [SerializeField] GameObject QuitButton;
    [SerializeField] GameObject PlayScreenCover;
    [SerializeField] GameObject LivesTextGO;
    [SerializeField] GameObject ScoreTextGO;
    [SerializeField] GameObject Panel;
    [SerializeField] GameObject PlayButton;
    [SerializeField] GameObject ControlsButton;
    [SerializeField] GameObject ExitControlsButton;

    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] TextMeshProUGUI LivesText;

    List<GameObject> gameObjectsToSetActiveForRestartButton = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactiveForRestartButton = new List<GameObject>();

    public List<GameObject> Asteroids = new List<GameObject>();

    float instantiatedAsteroids = 0f;
    public float playerScore = 0f;
    public float playerLives = 3f;
    public bool playButtonHasBeenPressed = false;
    public float splitAsteroids = 2f;
    public bool bulletIsCollidingWithAsteroid = false;
    public float destroyedAsteroids = 0f;

    public Quaternion playerRotation;
    public Vector2 playerPosition;
    public Vector2 asteroidPosition;

    void Start()
    {

        gameObjectsToSetActiveForRestartButton.Add(YouHaveDiedText);
        gameObjectsToSetActiveForRestartButton.Add(RestartButton);
        gameObjectsToSetActiveForRestartButton.Add(QuitButton);
        gameObjectsToSetActiveForRestartButton.Add(PlayScreenCover);
        gameObjectsToSetActiveForRestartButton.Add(Panel);

        gameObjectsToSetInactiveForRestartButton.Add(PlayerSpaceShip);
        gameObjectsToSetInactiveForRestartButton.Add(LivesTextGO);
        gameObjectsToSetInactiveForRestartButton.Add(ScoreTextGO);
        gameObjectsToSetInactiveForRestartButton.Add(PlayButton);
        gameObjectsToSetInactiveForRestartButton.Add(ControlsButton);
        gameObjectsToSetInactiveForRestartButton.Add(ExitControlsButton);

        StartCoroutine(SetInstantiateAsteroidActive());
        StartCoroutine(ShowRestartScreen());
      
    }

    void Update()
    {

        playerRotation = PlayerSpaceShip.transform.rotation;

        FireBullet();

    }

    public void SplitAsteroidInto2PiecesOnceHit()
    {

        GameObject asteroid1 = Instantiate(SmallAsteroid, asteroidPosition, Quaternion.identity);
        GameObject asteroid2 = Instantiate(SmallAsteroid, asteroidPosition, Quaternion.identity);

        asteroid1.transform.rotation = Quaternion.Euler(0f, 0f, 45f);
        asteroid1.transform.Find("SmallAsteroidCollider").rotation = Quaternion.Euler(0, 0, 0);
        asteroid2.transform.rotation = Quaternion.Euler(0f, 0f, -45f);
        asteroid2.transform.Find("SmallAsteroidCollider").rotation = Quaternion.Euler(0, 0, 0);

        asteroid1.transform.Find("SmallAsteroidCollider").position = asteroid1.transform.position;
        asteroid2.transform.Find("SmallAsteroidCollider").position = asteroid2.transform.position;

        asteroid1.transform.Find("pngtree-asteroid-stone-big-png-image_12814136_0").localScale = new Vector3(0.5f, 0.5f, 0.5f);
        asteroid1.transform.Find("SmallAsteroidCollider").localScale = new Vector3(0.5f, 0.5f, 0.5f);

        asteroid2.transform.Find("pngtree-asteroid-stone-big-png-image_12814136_0").localScale = new Vector3(0.5f, 0.5f, 0.5f);
        asteroid2.transform.Find("SmallAsteroidCollider").localScale = new Vector3(0.5f, 0.5f, 0.5f);

    }

    IEnumerator SetInstantiateAsteroidActive()
    {

        while (true)
        {

            if (playButtonHasBeenPressed)
            {

                StartCoroutine(InstantiateAsteroid());

                break;

            }

            yield return new WaitForSeconds(0.1f);

        }
    }

    void FireBullet()
    {

        if (Input.GetKeyDown(KeyCode.Space) && PlayerSpaceShip != null)
        {

            Vector2 bulletSpawnPosition = PlayerSpaceShipNose.transform.position;

            GameObject bullet = Instantiate(Bullet, bulletSpawnPosition, Quaternion.identity);
            playerPosition = PlayerSpaceShip.transform.position;
            bullet.transform.rotation = playerRotation;

        }
    }

    public IEnumerator ShowRestartScreen()
    {

        while (true)
        {

            if (playerLives <= 0)
            {

                foreach (GameObject obj in gameObjectsToSetActiveForRestartButton)
                {

                    obj.SetActive(true);

                }

                foreach (GameObject obj in gameObjectsToSetInactiveForRestartButton)
                {

                    obj.SetActive(false);

                }

                foreach (GameObject obj in Asteroids)
                {

                    if (obj != null)
                    {

                        obj.SetActive(false);

                    }
                }

                yield return new WaitForSeconds(0.1f);

                playerLives = 3f;
                playerScore = 0f;
                instantiatedAsteroids = 0f;
                UpdateScoreAndLives();

            }

            yield return new WaitForSeconds(0.1f);

        }
    }

    IEnumerator InstantiateAsteroid()
    {

        while (true)
        {

            if (PlayerSpaceShip != null)
            {

                Vector2 asteroidSpawnPosition = new Vector2(Random.Range(-10, 10), Random.Range(-3, 3));

                GameObject asteroid = Instantiate(Asteroid, asteroidSpawnPosition, Quaternion.identity);
                Asteroids.Add(asteroid);
                asteroid.transform.rotation = playerRotation;
                instantiatedAsteroids++;

                playerPosition = PlayerSpaceShip.transform.position;

            }

            if (playerLives <= 0)
            {

                StopCoroutine(InstantiateAsteroid());

            }

            yield return new WaitForSeconds(8f);

        }
    }

    public void UpdateScoreAndLives()
    {

        ScoreText.text = "SCORE:" + playerScore;
        LivesText.text = "LIVES:" + playerLives;

    }
}
