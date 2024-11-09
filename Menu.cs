using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public Button startButton;
    public InputField nameInput;
    public GameObject menuObject;
    public GameObject inputNameObject;
    public GameObject chooseClassObject;
    [SerializeField] InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        if(menuObject != null && inputNameObject != null && chooseClassObject != null)
        {
            inputNameObject.SetActive(false);
            menuObject.SetActive(true);
            chooseClassObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inputNameObject != null)
        {
            if(inputNameObject.activeSelf)
            {
                if(Input.GetKeyDown(KeyCode.Return))
                {
                    ValidateInput();
                }
            }
        }
    }

    public void startGame(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    public void exitGame()
    {
        Application.Quit();
    }

    public void restartLevel()
    {
        SceneManager.LoadScene(PlayerPrefs.GetString("LastLevel"));
    }

    public void backToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void goToInputName()
    {
        inputNameObject.SetActive(true);
        menuObject.SetActive(false);
        chooseClassObject.SetActive(false);
    }

    public void goToChooseClass()
    {
        inputNameObject.SetActive(false);
        menuObject.SetActive(false);
        chooseClassObject.SetActive(true);
    }

    public void ValidateInput()
    {
        string inputName = inputField.text;
        PlayerPrefs.SetString("myName", inputName);

        if(inputName != "")
        {
            goToChooseClass();
        }
    }
}
