using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
[RequireComponent(typeof(VideoPlayer))]
[RequireComponent(typeof(RawImage))]

public class CanvasVideoPlayer1 : MonoBehaviour
{
    
    

    private VideoPlayer video;
    private RawImage image;
    private void Awake()
    {
        video = GetComponent<VideoPlayer>();
        image = GetComponent<RawImage>();
    }
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        image = GetComponent<RawImage>();

       
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }
    private void OnEnable()
    {
        StartVideo(CanvasController.url, CanvasController.time);
    }

    public void StartVideo(string url, double time)
    {
        StartCoroutine(PlayVideo(url, time));
    }
    IEnumerator PlayVideo(string url, double time)
    {
        if (video == null)
            Debug.Log("Video = null");
        video.url = url;
        video.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!video.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        image.texture = video.texture;
        video.Play();
        if (video.canSetTime)
        {
            video.time = time;
            Debug.Log("Time seted");
        }
    }
}
