using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlatformSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[]  PlatformPacksLow;
    [SerializeField] private GameObject[] PlatformPacksMedium;
    [SerializeField] private GameObject[] PlatformPacksHard;
    [SerializeField] private GameObject[] PlatformPacks;
    private float timerToGeneratePlatforms = 4;
    [SerializeField] private Player PlayerScript;
    [SerializeField] private Transform FirstPlatformSpawnPosition;
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Complexity"))
        {
            PlayerPrefs.SetInt("Complexity", 1);
        }
        switch (PlayerPrefs.GetInt("Complexity"))
        {
            case 1:
                PlatformPacks = PlatformPacksLow;
                break;
            case 2:
                PlatformPacks = PlatformPacksMedium;
                break;
            case 3:
                PlatformPacks = PlatformPacksHard;
                break;
        }
        Instantiate(PlatformPacks[0]).transform.position = FirstPlatformSpawnPosition.position;
    }
    public void Complexity(int complexity )
    {
        PlayerPrefs.SetInt("Complexity", complexity);
        SceneManager.LoadScene(0);
    }
    private void FixedUpdate()
    {
        if (PlayerScript.Speed > 0)
        {
            if (timerToGeneratePlatforms < 3)
            {
                timerToGeneratePlatforms = timerToGeneratePlatforms + PlayerScript.Speed / 7.9f * Time.deltaTime;
            }
            else
            {
                Instantiate(PlatformPacks[Random.Range(0, PlatformPacks.Length)]).transform.position = transform.position;
                timerToGeneratePlatforms = 0;
            }
        }
    }
}
