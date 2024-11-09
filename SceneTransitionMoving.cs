using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionMoving : MonoBehaviour
{
    public string sceneToMoveName;
    
    public void moveScene()
    {
        SceneManager.LoadScene(sceneToMoveName);
    }
}
