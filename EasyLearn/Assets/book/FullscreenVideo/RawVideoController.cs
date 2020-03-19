using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
[RequireComponent(typeof(VideoPlayer))]
public class RawVideoController : MonoBehaviour
{
    VideoPlayer video;
    RawImage image;
    [SerializeField]
    easyar.VideoCameraDevice camDevice;
    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<RawImage>();
        video = GetComponent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartFullScreen(string url, double time)
    {
        Debug.Log("StartFullScreen");
        camDevice.Close();
        StartCoroutine(PlayVideo(url, time));

    }
    IEnumerator PlayVideo(string url, double time)
    {
        video.Prepare();
        video.url = url;
        Debug.Log(time);
        while (!video.isPrepared)
        {
            Debug.Log("Preparing");
            yield return new WaitForSeconds(0.5f);
            break;
        }
        video.Play();
        Debug.Log(video.texture);
        while (!GetComponent<VideoPlayer>().canSetTime)
        {
            Debug.Log("Cant set time");
            yield return new WaitForSeconds(2f);
           
        }
        Debug.Log(time);
        GetComponent<VideoPlayer>().time = time;
        GetComponent<VideoPlayer>().Play();
        GetComponent<RawImage>().texture = video.texture;
        Debug.Log(GetComponent<VideoPlayer>().texture);
        Debug.Log(GetComponent<VideoPlayer>().time);
    }
}
