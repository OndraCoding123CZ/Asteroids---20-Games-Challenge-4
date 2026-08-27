using System.Collections;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{

    GameManagerScript gameManagerScript;

    void Start()
    {

        gameManagerScript = FindAnyObjectByType<GameManagerScript>();

    }

    void Update()
    {
        
        StartCoroutine(MoveBullet());

    }

    IEnumerator MoveBullet()
    {

        float bulletStartSpeed = 5f;

        transform.Translate(Vector2.up * bulletStartSpeed * Time.deltaTime);

        yield return new WaitForSeconds(3f);

        Destroy(gameObject);

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("AsteroidCollider"))
        {
            
            gameManagerScript.playerScore += 100;
            gameManagerScript.UpdateScoreAndLives();
            gameManagerScript.destroyedAsteroids++;

            gameManagerScript.asteroidPosition = collision.gameObject.transform.position;
            gameManagerScript.SplitAsteroidInto2PiecesOnceHit();

            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);

        }
        else if (collision.gameObject.CompareTag("SmallAsteroidCollider"))
        {

            gameManagerScript.playerScore += 100;
            gameManagerScript.UpdateScoreAndLives();
            gameManagerScript.destroyedAsteroids++;

            Destroy(collision.gameObject.transform.parent.gameObject);
            Destroy(gameObject);

        }
    }
}
