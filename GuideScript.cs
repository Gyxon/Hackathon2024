using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideScript : MonoBehaviour
{
    public GameObject objectGuide;
    private bool disappear;
    private float countdown = 2f;
    // Update is called once per frame
    void Update()
    {
        if(!disappear)
        {
            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                disappear = true;
                objectGuide.SetActive(false);
            }
        }
        else
        {
            if(!Input.GetKey(KeyCode.Space) || !Input.GetMouseButton(0))
            {
                countdown -= Time.deltaTime;
            }
            else
            {
                countdown = 2f;
            }
            if(countdown <= 0)
            {
                countdown = 2f;
                disappear = false;
                objectGuide.SetActive(true);
            }
        }
    }
}
