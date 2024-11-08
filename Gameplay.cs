using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Gameplay : MonoBehaviour
{
    public Slider EnergyBar;
    public int energyMaxPoints;
    public int energyPoints;
    private float timer;
    public float timerInput;
    public Slider ProgressBar;
    public int progressPoints;
    public int progressWinPoint;
    private bool winTheGame;
    public Camera myCam;
    public Animator anim;
    public int indicatorInt;
    private float pressTimer;
    private bool loseTheGame;
    public string LevelName;
    public string NextLevel;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.SetString("LastLevel", LevelName);
        //Energy Bar
        EnergyBar.minValue = 0;
        EnergyBar.maxValue = energyMaxPoints;
        energyPoints = energyMaxPoints/2;
        timer = timerInput;
        progressPoints = 0;
        ProgressBar.maxValue = progressWinPoint;
        ProgressBar.minValue = 0;
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetInteger("IndicatorInt", indicatorInt);
        if(!winTheGame && !loseTheGame)
        {
            //Energy Bar
            EnergyBar.value = energyPoints;
            ProgressBar.value = progressPoints;

            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(progressPoints < progressWinPoint)
                {
                    progressPoints++;
                }
                if(energyPoints < energyMaxPoints)
                {
                    energyPoints++;
                }
            }
            
            timer -= Time.deltaTime;

            if(timer <= 0)
            {
                energyPoints--;
                timer = timerInput;
            }
        }

        //Win the Game, move to other game
        if(progressPoints >= progressWinPoint)
        {
            winTheGame = true;
            if(NextLevel == "")
            {
                Debug.Log("You win the game");
            }
            else
            {
                SceneManager.LoadScene(NextLevel);
            }
        }

        //Lose Game
        if(energyPoints < 0)
        {
            loseTheGame = true;
        }
        else if(energyPoints >= energyMaxPoints)
        {
            loseTheGame = true;
        }

        //Indicator Transition
        if(energyPoints >= (0.78 * energyMaxPoints)) //>78%
        {
            myCam.backgroundColor = Color.red;
            if(Input.GetKey(KeyCode.Space))
            {
                indicatorInt = 2;
            }
            else if(pressTimer <= 0)
            {
                indicatorInt = 0;
            }
        }
        else if(energyPoints <= (0.25 * energyMaxPoints)) //<25%
        {
            myCam.backgroundColor = Color.red;
            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                indicatorInt = 2;
            }
            else if(pressTimer <= 0)
            {
                indicatorInt = 0;
            }
        }
        else if(energyPoints >= (0.25 * energyMaxPoints) && energyPoints <= (0.40 * energyMaxPoints)) //>25% && <40%
        {
            myCam.backgroundColor = Color.yellow;
            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                indicatorInt = 1;
            }
            else if(pressTimer <= 0)
            {
                indicatorInt = 0;
            }
        }
        else if(energyPoints <= (0.78 * energyMaxPoints) && energyPoints >= (0.60 * energyMaxPoints)) //<72% && >60%
        {
            myCam.backgroundColor = Color.yellow;
            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                indicatorInt = 1;
            }
            else if(pressTimer <= 0)
            {
                indicatorInt = 0;
            }
        }
        else
        {
            myCam.backgroundColor = Color.grey;
            indicatorInt = 0;
        }

        //Press Space Addition
        if(Input.GetKey(KeyCode.Space) && pressTimer <= 0f || Input.GetMouseButton(0) && pressTimer <= 0f)
        {
            pressTimer = 1.5f;
        }

        if(pressTimer >= 0)
        {
            pressTimer -= Time.deltaTime;
        }
    }
}
