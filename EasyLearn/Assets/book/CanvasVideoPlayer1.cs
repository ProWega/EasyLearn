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
    // Start is called before the first frame update
    void Start()
    {
        video = GetComponent<VideoPlayer>();
        image = GetComponent<RawImage>();

        StartVideo();
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    void StartVideo()
    {
        StartCoroutine(PlayVideo());
    }
    IEnumerator PlayVideo()
    {
        video.Prepare();
        WaitForSeconds waitForSeconds = new WaitForSeconds(1);
        while (!video.isPrepared)
        {
            yield return waitForSeconds;
            break;
        }
        image.texture = video.texture;
        video.Play();
    }
}
