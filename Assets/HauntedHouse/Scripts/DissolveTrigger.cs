using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    public SkinnedMeshRenderer mr;

    // Update is called once per frame
    void Update()
    {
       if(Input.GetKeyDown(KeyCode.D))
        {
            mr.material.SetFloat("Vector1_ed669a49e002446bb5f03ba3216c5d08", Time.time);
        }
    }
}
