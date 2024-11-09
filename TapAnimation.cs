using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapAnimation : MonoBehaviour
{
    public Animator myAnim;
    private bool pressed;
    public GameObject PopSFX;
    private Gameplay myGameManager;
    public GameObject greenComment;
    public GameObject yellowComment;
    public GameObject redComment;
    public bool isRunning;
    private bool currentlyRunning;
    private float runningTime;
    private float runningStopTime = 1f;
    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameObject.Find("GameManager").GetComponent<Gameplay>();
        runningTime = runningStopTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(!myGameManager.winTheGame && !myGameManager.loseTheGame)
        {
            if(myAnim != null)
            {
                myAnim.SetBool("pressed", pressed);
                if(isRunning)
                {
                    myAnim.SetBool("running", currentlyRunning);
                }
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    if(isRunning)
                    {
                        currentlyRunning = true;
                    }
                    pressed = true;
                    giveComment();
                    Instantiate(PopSFX);
                }
                else
                {
                    if(!isRunning)
                    {
                        pressed = false;
                    }
                    else
                    {
                        if(currentlyRunning == true)
                        {
                            runningTime -= Time.deltaTime;
                            if(runningTime <= 0)
                            {
                                runningTime = runningStopTime;
                                currentlyRunning = false;
                                pressed = false;
                            }
                        }
                    }
                }
            }
            else
            {
                if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
                {
                    Instantiate(PopSFX);
                    giveComment();
                }
            }
        }
    }

    public void giveComment()
    {
        if(myGameManager.energyPoints >= (0.78 * myGameManager.energyMaxPoints)) //>78%
        {
           int probabilityAppear = Random.Range(0, 10);
           if(probabilityAppear > 7)
           {
                Instantiate(redComment, transform.position, Quaternion.identity);
           }
        }
        else if(myGameManager.energyPoints >= (0.60 * myGameManager.energyMaxPoints)) //>60%
        {
           int probabilityAppear = Random.Range(0, 10);
           if(probabilityAppear > 7)
           {
                Instantiate(yellowComment, transform.position, Quaternion.identity);
           }
        }
        else if(myGameManager.energyPoints >= (0.40 * myGameManager.energyMaxPoints)) //>40%
        {
           int probabilityAppear = Random.Range(0, 10);
           if(probabilityAppear > 6)
           {
                Instantiate(greenComment, transform.position, Quaternion.identity);
           }
        }
    }
}
