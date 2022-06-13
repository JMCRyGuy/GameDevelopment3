using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int fowardMoveSpeed;
    public float forward;
    public int distance = 0;
    public bool crashed = false;
    public TextMeshProUGUI scoreText;

    public GameObject gameOverPanel;
    public TextMeshProUGUI distanceText;
    public TextMeshProUGUI highScoreText;

    public AudioSource music;
    public Image darknessPannel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FowardMovement();
    }
    void FowardMovement()
    {
        if (!crashed)
        {
            forward = fowardMoveSpeed * Time.deltaTime;
            transform.position += new Vector3(forward, 0f, 0f);
            distance = ((int)transform.position.x);
            scoreText.text = distance.ToString();

            music.pitch = (10000f - distance) / 10000f;
            print((10000f - distance) / 10000f);
            darknessPannel.color = new Color(0,0,0,(distance / 1000000f)*256);
            


        }


        

    }
    
    public void Crash()
    {
        gameOverPanel.SetActive(true);
        crashed = true;
        if (distance > SaveManager.instance.highScore)
        {
            SaveManager.instance.highScore = distance;
            SaveManager.instance.Save();
        }
        distanceText.text = "Distance: " + distance.ToString();
        highScoreText.text = "High Score: " + SaveManager.instance.highScore.ToString();

    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void QuitGame()
    {
        Application.Quit();

    }

}
