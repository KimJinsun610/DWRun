using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class retry_btn : MonoBehaviour
{
    public AudioClip[] sound;
    public void retry()
    {
        Debug.Log("retry");
        soundmanager.instance.PlaySE("btn");
        SceneManager.LoadScene("START");
    }

   
}
