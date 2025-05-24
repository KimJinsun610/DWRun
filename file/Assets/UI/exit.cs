using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class exit : MonoBehaviour
{ public void exit_btn()
    {
        Debug.Log("exit");
        soundmanager.instance.PlaySE("btn");
        Application.Quit();
    }
    
}
