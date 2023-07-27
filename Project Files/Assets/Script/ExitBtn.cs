using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitBtn : MonoBehaviour
{
    public void Exit()
    {
        Debug.Log("Exit Game");
        Application.Quit();
    }
}
