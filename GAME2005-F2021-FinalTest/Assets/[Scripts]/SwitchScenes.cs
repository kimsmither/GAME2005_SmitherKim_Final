using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SwitchScenes : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Intro") != 0)
        {
            SceneManager.LoadScene("Main");
        }

        if (Input.GetAxisRaw("Main") != 0)
        {
            SceneManager.LoadScene("Intro");
        }
    }
}
