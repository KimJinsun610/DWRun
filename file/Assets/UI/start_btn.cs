using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class start_btn : MonoBehaviour
{
    public void start_()
    {
        Debug.Log("start");
        soundmanager.instance.PlaySE("btn");
        SceneManager.LoadScene("PLAYING");
    }

}
