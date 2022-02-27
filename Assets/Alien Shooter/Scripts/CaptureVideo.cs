using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureVideo : MonoBehaviour

{
    public bool TakingPhoto = false;
    public GameObject TXT_Photo;

    public bool TakingVideo = false;
    public GameObject TXT_Video;

    public void TakePhoto()
    {
        StartCoroutine(TakePhotoandSave());
    }
    private IEnumerator TakePhotoandSave()
    {
        TakingPhoto = true;
        TXT_Photo.SetActive(true);
        yield return new WaitForEndOfFrame();

        Texture2D photo = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        photo.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        photo.Apply();

        string photoName = "game_title_" + System.DateTime.Now.ToString("f");

        NativeGallery.SaveImageToGallery(photo, "gameTitle", photoName);

        TakingPhoto = false;
        TXT_Photo.SetActive(false);

    }

    /*
    public void TakeVideo()
    {
        StartCoroutine(TakeVideoandSave());
    }
    private IEnumerator TakeVideoandSave()
    {
        TakingVideo = true;
        TXT_Video.SetActive(true);
        yield return new WaitForEndOfFrame();

        Texture2D video = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);

        video.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);

        video.Apply();

        string videoName = "game_title_" + System.DateTime.Now.ToString("f");

        NativeGallery.SaveVideoToGallery(byte[] mediaBytes, string album, string filename, MediaSaveCallback callback = null);

        TakingVideo = false;
        TXT_Video.SetActive(false);


    }
    */
}
