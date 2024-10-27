using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanCredit : MonoBehaviour
{
   void Update()
   {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
        if (transform.position.y >= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        }
   }
}
