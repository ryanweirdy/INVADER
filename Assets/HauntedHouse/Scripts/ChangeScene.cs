using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChangeScene : MonoBehaviour
{
    [SerializeField]
    public float delayBeforeLoading;
    [SerializeField]
    private string sceneToLoad;
    private float elapsedTime;
    public bool delay;

    // Start is called before the first frame update
    void Start()
    {

    }
/*
    private void Update()
    {
        if (delay == true)
        {
            elapsedTime += Time.deltaTime;
            if (elapsedTime > delayBeforeLoading)
            {
                SceneChange(sceneToLoad);
            }
        }
    }
    */
    public void SceneChange(string scene)
    {
        SceneManager.LoadScene(scene);
    }

}
// JUST A TEST!!!