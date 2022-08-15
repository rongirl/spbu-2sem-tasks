using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceOfEnemies : MonoBehaviour
{
    public int probability = 0;
    public bool isEndOfGame = false;
    public GameObject enemyCatOne;
    public GameObject enemyCatTwo;
    public GameObject enemyDog;
    public AudioSource audioSource;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            int randomNumber = Random.Range(1, 100);
            if (randomNumber <= probability)
            {   
                audioSource.Play(); 
                enemyCatOne.SetActive(true);
                enemyCatTwo.SetActive(true);
                enemyDog.SetActive(true);
                isEndOfGame = true;
            }
            
        }
    }
}