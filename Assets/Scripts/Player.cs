using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [HideInInspector] public float Speed => _speed;
    [SerializeField] private float _speed;
    private float defaultSpeed;
    [SerializeField] private Text CrystalCount;
    [SerializeField] private GameObject GameOverTouchPanel;

    private void Start()
    {
        if (!PlayerPrefs.HasKey("CrystalCount"))
        {
            PlayerPrefs.SetInt("CrystalCount", 0);
        }
        CrystalCount.text = PlayerPrefs.GetInt("CrystalCount").ToString();
        defaultSpeed = _speed;
        _speed = 0;
    }
    void FixedUpdate()
    {
        transform.Translate(Vector3.forward * _speed * Time.deltaTime);
    }

    public void Play()
    {
        _speed = defaultSpeed;
    }

    public void Turn()
    {
        if (transform.rotation == Quaternion.Euler(0, 0, 0))
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
            return;
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }
    public void GameOver()
    {
        SceneManager.LoadScene(0);
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.CompareTag("DeadTrigger"))
        {
            GameOverTouchPanel.SetActive(true);
            _speed = 0;
        }
        if (col.CompareTag("Crystal"))
        {
            PlayerPrefs.SetInt("CrystalCount",PlayerPrefs.GetInt("CrystalCount") + 1);
            CrystalCount.text = PlayerPrefs.GetInt("CrystalCount").ToString();
            Destroy(col.gameObject);
        }
    }
}
