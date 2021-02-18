using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public Snapshot snapL;
    public Snapshot snapR;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            snapL.takeSnapshot();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            snapR.takeSnapshot();
        }
    }
}
