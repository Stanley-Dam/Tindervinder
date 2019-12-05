using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScreen : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        Scene currentscene = SceneManager.GetActiveScene();
        if (currentscene.buildIndex == 1) {
            this.GetComponent<SpriteRenderer>().color = Color.Lerp(Color.white, Color.black, Time.time);
            if (this.GetComponent<SpriteRenderer>().color == Color.black)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}
