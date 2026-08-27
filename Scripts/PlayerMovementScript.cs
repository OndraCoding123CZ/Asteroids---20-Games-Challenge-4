using System.Collections;
using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{

    [SerializeField] GameManagerScript gameManagerScript;

    float startingMoveSpeed = 3f;

    void Start()
    {
        
    }

    void Update()
    {

        RestrictPlayerFromMovingTooFar();

        Quaternion currentRotation = transform.rotation;

        if (Input.GetKey(KeyCode.W))
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, 0);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 4f * Time.deltaTime);

            transform.Translate(Vector2.up * startingMoveSpeed * Time.deltaTime);
            Physics2D.SyncTransforms();

        }

        if (Input.GetKey(KeyCode.A))
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, 90);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 4f * Time.deltaTime);

            transform.Translate(Vector2.up * startingMoveSpeed * Time.deltaTime);
            Physics2D.SyncTransforms();

        }

        if (Input.GetKey(KeyCode.S))
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, -180);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 4f * Time.deltaTime);

            transform.Translate(Vector2.up * startingMoveSpeed * Time.deltaTime);
            Physics2D.SyncTransforms();

        }

        if (Input.GetKey(KeyCode.D))
        {

            Quaternion targetRotation = Quaternion.Euler(0, 0, -90);

            transform.rotation = Quaternion.Slerp(currentRotation, targetRotation, 4f * Time.deltaTime);

            transform.Translate(Vector2.up * startingMoveSpeed * Time.deltaTime);
            Physics2D.SyncTransforms();

        }
    }

    void RestrictPlayerFromMovingTooFar()
    {

        Vector2 playerPosition = transform.position;

        if (transform.position.x >= 12)
        {

            playerPosition.x = -11;

        }
        else if (transform.position.x <= -12)
        {

            playerPosition.x = 11;

        }

        if (transform.position.y >= 5)
        {

            playerPosition.y = -4;

        }
        else if (transform.position.y <= -5)
        {

            playerPosition.x = 4;

        }

        transform.position = playerPosition;

    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Name: " + collision.gameObject.name + "Tag: " + collision.gameObject.tag);

        if (collision.gameObject.CompareTag("AsteroidCollider"))
        {

            gameManagerScript.playerLives--;
            gameManagerScript.UpdateScoreAndLives();

        }
        else if (collision.gameObject.CompareTag("SmallAsteroidCollider"))
        {

            gameManagerScript.playerLives--;
            gameManagerScript.UpdateScoreAndLives();

        }
    }
}
