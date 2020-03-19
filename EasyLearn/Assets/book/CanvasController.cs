using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    [SerializeField]
    private GameObject rawImage;
    [SerializeField]
    easyar.VideoCameraDevice camDevice;

    public static string url;
    public static double time;
    private VideoPlayer videoArMode;

    [HideInInspector] public bool isCanvas = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartCanvas(string _url, double _time)
    {
        camDevice.Close();
        url = _url;
        time = _time;
        rawImage.SetActive(true);
        isCanvas = true;
        //rawImage.GetComponent<CanvasVideoPlayer1>().StartVideo(url, time);
    }
    public void StopCanvas(VideoPlayer videoAr)
    {
        videoArMode = videoAr;
        VideoPlayer videoCanvas = videoAr.GetComponent<TouchVideoController>().videoCanvas;
        time = videoCanvas.time;
        camDevice.Open();
        rawImage.SetActive(false);
        StartCoroutine(PlayArVideo());
        isCanvas = false;
    }
    IEnumerator PlayArVideo()
    {
        if (!videoArMode.isPrepared)
            videoArMode.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!videoArMode.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        //videoArMode.Play();
        if (videoArMode.canSetTime)
        {
            videoArMode.time = time;
        }
    }
}
