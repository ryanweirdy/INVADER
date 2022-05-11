using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capture : MonoBehaviour

{
    public bool TakingScreenshot = false;
    public GameObject TXT_ScreenShot;
 public void TakePhoto()
    {
        StartCoroutine(TakeScreenShotandSave());
    }
    private IEnumerator TakeScreenShotandSave()
    {
        TakingScreenshot = true;
        TXT_ScreenShot.SetActive(true);
        yield return new WaitForEndOfFrame();

        Texture2D screenShot = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        screenShot.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        screenShot.Apply();

        string screenShotName = "space_invaders_" + System.DateTime.Now.ToString("f");

        NativeGallery.SaveImageToGallery(screenShot, "spaceInvaders", screenShotName);

        TakingScreenshot = false;
        TXT_ScreenShot.SetActive(false);


    }
}
