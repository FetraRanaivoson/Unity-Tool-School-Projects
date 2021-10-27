using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MenuCreator
{
    [MenuItem("Setting/Player")]
    public static void MenuSettingPlayer()
    {
        Debug.Log("Player menu clicked");
    }
    
    [MenuItem("Setting/Sound/Start")]
    public static void MenuSettingSoundStart()
    {
        Debug.Log("Sound started");
    }
    
    [MenuItem("Setting/Sound/Stop")]
    public static void MenuSettingSoundStop()
    {
        Debug.Log("Sound stopped");
    }
}
