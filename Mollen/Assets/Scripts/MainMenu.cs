using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public int MaxSize = 5;
    public int maxSpeed = 5;
    public int maxHoles = 16;
    public int maxPause = 5;
    private int minNumber = 1;
    public int maxLevel = 4;



    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex -1);
    }

    public void updateClick()
    {
        int holes = PlayerPrefs.GetInt("holes");
        GameObject.Find("HoleNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (holes);

        int speed = PlayerPrefs.GetInt("speed");
        GameObject.Find("SpeedNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (speed);

        int pause = PlayerPrefs.GetInt("pauze");
        GameObject.Find("PauseNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (pause);

        int size = PlayerPrefs.GetInt("grootte");
        GameObject.Find("SizeNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (size);

        int level = PlayerPrefs.GetInt("level");
        GameObject.Find("LevelNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (size);
    }


    public void increaseSpeed()
    {
        int speed = PlayerPrefs.GetInt("speed");
        if(speed <= maxSpeed)
        {
            PlayerPrefs.SetInt("speed",speed+1);
            GameObject.Find("SpeedNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (speed + 1);
        }
    }

    public void decreaseSpeed()
    {
        int speed = PlayerPrefs.GetInt("speed");
        if(speed > minNumber)
        {
            PlayerPrefs.SetInt("speed",speed-1);
            GameObject.Find("SpeedNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (speed - 1);
        }
    }


    public void increasePauze()
    {
        int pauze = PlayerPrefs.GetInt("pauze");
        if (pauze <= maxPause)
        {
            PlayerPrefs.SetInt("pauze", pauze + 1);
            GameObject.Find("PauseNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (pauze + 1);
        }
    }

    public void decreasePauze()
    {
        int pauze = PlayerPrefs.GetInt("pauze");
        if(pauze > minNumber)
        {
            PlayerPrefs.SetInt("pauze", pauze - 1);
            GameObject.Find("PauseNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (pauze - 1);
        }

    }

    public void increasegrootte()
    {
        int grootte = PlayerPrefs.GetInt("grootte");
        if(grootte <= MaxSize){
            PlayerPrefs.SetInt("grootte", grootte + 1);
            GameObject.Find("SizeNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (grootte + 1);
        }
    }

    public void decreasegrootte()
    {
        int grootte = PlayerPrefs.GetInt("grootte");
        if(grootte > minNumber)
        {
            PlayerPrefs.SetInt("grootte", grootte - 1);
            GameObject.Find("SizeNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (grootte - 1);
        }
    }

    public void increaseHoles()
    {
        int holes = PlayerPrefs.GetInt("holes");
        if(holes <= maxHoles)
        {
            PlayerPrefs.SetInt("holes", holes + 1);
            GameObject.Find("HoleNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (holes + 1);
        }
    }

    public void decreaseHoles()
    {
        int holes = PlayerPrefs.GetInt("holes");
        if(holes > minNumber)
        {
            PlayerPrefs.SetInt("holes", holes - 1);
            GameObject.Find("HoleNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (holes - 1);
        }
    }

    public void increaseLevel()
    {
        int level = PlayerPrefs.GetInt("level");
        if(level <= maxLevel)
        {
            PlayerPrefs.SetInt("level", level + 1);
            GameObject.Find("LevelNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (level + 1);
        }
    }

    public void decreaseLevel()
    {
        int level = PlayerPrefs.GetInt("level");
        if(level > minNumber)
        {
            PlayerPrefs.SetInt("level", level - 1);
            GameObject.Find("LevelNumberIndicator").GetComponent<TMPro.TextMeshProUGUI>().text = "" + (level - 1);
        }
    }

}
