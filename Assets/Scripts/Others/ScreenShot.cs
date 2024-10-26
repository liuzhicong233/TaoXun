using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShot : MonoBehaviour
{
    string path = @"D:\游戏项目\陶寻\截图/Screenshot.png";


    private void ScreenShot_Full()
    {
        ScreenCapture.CaptureScreenshot(path, 0);
    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.I)){
            ScreenShot_Full();
        }
    }

}
