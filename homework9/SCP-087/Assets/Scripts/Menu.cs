using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    private bool isPlay = true;
    private bool isRetry = true;
    public GameObject menu;
    public GameObject floorCount;
    public GameObject endOfGame;
    public InputField textProbability;
    public PlaceOfEnemies place;
    public Vector3 startPosition;
    public Quaternion startRotation;
    public GameObject player;
    public GameObject mainCamera;
    public AudioSource audioMain;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
        audioMain.Play();
    }

    void Update()
    {
        MenuActivate();
    }

    public void MenuActivate()
    {
        if (isPlay || isRetry)
        {
            player.transform.position = startPosition;
            player.transform.rotation = startRotation;
            mainCamera.transform.rotation = startRotation;
            menu.SetActive(true);
            floorCount.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0f;
            place.enemyCatOne.SetActive(false);
            place.enemyCatTwo.SetActive(false);
            place.enemyDog.SetActive(false);
            
        }
        else if (place.isEndOfGame)
        {
            floorCount.SetActive(false);
            endOfGame.SetActive(true);
            textProbability.text = "";
            Cursor.lockState = CursorLockMode.None;
            player.GetComponent<PlayerController>().speed = 0f;
            audioMain.Stop();
        }
        else
        {   
            floorCount.SetActive(true);    
            menu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<PlayerController>().speed = 10f;
            Time.timeScale = 1f;
        }
    } 

    public void Play()
    {
        if (int.TryParse(textProbability.text, out place.probability) && 0 <= place.probability && place.probability <= 100)
        {
            isPlay = false;
            isRetry = false;
        }
    }

    public void Retry()
    {
        place.audioSource.Stop();
        audioMain.Play();
        endOfGame.SetActive(false);
        place.isEndOfGame = false;
        isRetry = true;
    }

    public void Exit()
    {
        Application.Quit();
    }
}