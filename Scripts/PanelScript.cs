using JetBrains.Annotations;
using NUnit.Framework;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PanelScript : MonoBehaviour
{

    [SerializeField] GameObject AsteroidText;
    [SerializeField] GameObject PlayScreenCover;
    [SerializeField] GameObject PlayerSpaceShip;
    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;
    [SerializeField] GameObject ControlsText;
    [SerializeField] GameObject ScoresText;
    [SerializeField] GameObject LivesText;
    [SerializeField] GameObject YouHaveDiedText;
    [SerializeField] GameManagerScript gameManagerScript;

    List<GameObject> gameObjectsToSetActiveForPlayButton = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactiveForPlayButton = new List<GameObject>();

    List<GameObject> gameObjectsToSetActiveForControlsButton = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactiveForControlsButton = new List<GameObject>();

    List<GameObject> gameObjectsToSetActiveForControlsExitButton = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactiveForControlsExitButton = new List<GameObject>();

    List<GameObject> gameObjectsToSetActiveForRestartButton = new List<GameObject>();
    List<GameObject> gameObjectsToSetInactiveForRestartButton = new List<GameObject>();

    List<GameObject> gameObjectsToSetInactiveForQuitButton = new List<GameObject>();

    void Start()
    {

        gameObjectsToSetActiveForPlayButton.Add(PlayerSpaceShip);
        gameObjectsToSetActiveForPlayButton.Add(ScoresText);
        gameObjectsToSetActiveForPlayButton.Add(LivesText);

        gameObjectsToSetInactiveForPlayButton.Add(AsteroidText);
        gameObjectsToSetInactiveForPlayButton.Add(PlayScreenCover);
        gameObjectsToSetInactiveForPlayButton.Add(gameObject);

        //------------------------------------------------------

        gameObjectsToSetActiveForControlsButton.Add(ControlsText);
        gameObjectsToSetActiveForControlsButton.Add(Button3);

        gameObjectsToSetInactiveForControlsButton.Add(AsteroidText);
        gameObjectsToSetInactiveForControlsButton.Add(Button1);
        gameObjectsToSetInactiveForControlsButton.Add(Button2);


        //------------------------------------------------------

        gameObjectsToSetActiveForControlsExitButton.Add(AsteroidText);
        gameObjectsToSetActiveForControlsExitButton.Add(Button1);
        gameObjectsToSetActiveForControlsExitButton.Add(Button2);

        gameObjectsToSetInactiveForControlsExitButton.Add(ControlsText);
        gameObjectsToSetInactiveForControlsExitButton.Add(Button3);

        //------------------------------------------------------

        gameObjectsToSetActiveForRestartButton.Add(PlayerSpaceShip);
        gameObjectsToSetActiveForRestartButton.Add(ScoresText);
        gameObjectsToSetActiveForRestartButton.Add(LivesText);

        gameObjectsToSetInactiveForRestartButton.Add(YouHaveDiedText);
        gameObjectsToSetInactiveForRestartButton.Add(gameObject);
        gameObjectsToSetInactiveForRestartButton.Add(PlayScreenCover);

        //------------------------------------------------------

        gameObjectsToSetInactiveForQuitButton.Add(YouHaveDiedText);
        gameObjectsToSetInactiveForQuitButton.Add(gameObject);

    }

    void Update()
    {
        
    }

    public void OnButtonClick(int buttonValue)
    {

        if (buttonValue == 1)
        {

            gameManagerScript.playButtonHasBeenPressed = true;

            foreach (GameObject obj in gameObjectsToSetActiveForPlayButton)
            {

                obj.SetActive(true);

            }

            foreach (GameObject obj in gameObjectsToSetInactiveForPlayButton)
            {

                obj.SetActive(false);

            }
        }
        else if (buttonValue == 2)
        {

            foreach (GameObject obj in gameObjectsToSetActiveForControlsButton)
            {

                obj.SetActive(true);

            }

            foreach (GameObject obj in gameObjectsToSetInactiveForControlsButton)
            {

                obj.SetActive(false);

            }
        }
        else if (buttonValue == 3)
        {

            foreach (GameObject obj in gameObjectsToSetActiveForControlsExitButton)
            {

                obj.SetActive(true);

            }

            foreach (GameObject obj in gameObjectsToSetInactiveForControlsExitButton)
            {

                obj.SetActive(false);

            }
        }
        else if (buttonValue == 4)
        {

            foreach (GameObject obj in gameObjectsToSetActiveForRestartButton)
            {

                obj.SetActive(true);

            }

            foreach (GameObject obj in gameObjectsToSetInactiveForRestartButton)
            {

                obj.SetActive(false);

            }
        }
        else if (buttonValue == 5)
        {

            foreach (GameObject obj in gameObjectsToSetInactiveForQuitButton)
            {

                obj.SetActive(false);

            }

            foreach (GameObject obj in gameManagerScript.Asteroids)
            {

                obj.SetActive(false);

            }
        }
    }
}
