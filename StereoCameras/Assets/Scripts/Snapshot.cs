using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class Snapshot : MonoBehaviour
{
    Camera snapCam;
    public int resolutionWidth = 500;
    public int resolutionHeight = 500;


    void Awake()
    {
        snapCam = GetComponent<Camera>();
        snapCam.targetTexture = new RenderTexture(resolutionWidth, resolutionHeight, 24);
        snapCam.gameObject.SetActive(false);
        Debug.Log(snapCam.gameObject.name);
    }


    public void takeSnapshot()
    {
        snapCam.gameObject.SetActive(true);
    }

    void LateUpdate()
    {
        if (snapCam.gameObject.activeSelf)
        {
            Texture2D snapshot = new Texture2D(resolutionWidth, resolutionHeight, TextureFormat.RGB24, false);
            snapCam.Render();
            RenderTexture.active = snapCam.targetTexture;
            snapshot.ReadPixels(new Rect(0, 0, resolutionWidth, resolutionHeight), 0, 0);
            byte[] bytes = snapshot.EncodeToPNG();
            string fileName = getFileName();
            System.IO.File.WriteAllBytes(fileName, bytes);
            Debug.Log(snapCam.gameObject.name + " Snapshot token");
            snapCam.gameObject.SetActive(false);
        }
    }

    private string getFileName()
    {
        return string.Format("{0}/Snapshots/{1}_{2}x{3}_{4}.png", Application.dataPath, snapCam.gameObject.name, resolutionWidth, resolutionHeight, System.DateTime.Now.ToString("yyyy-mm-dd_hh-mm-ss"));
    }
}
