using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.EventSystems;

public class SliderController : MonoBehaviour
{
    [SerializeField]
    private GameObject video;
    [SerializeField] private VideoPlayer canvasVideoPlayer;
    [SerializeField] private CanvasVideoPlayer1 canvasVideoPlayerObject;
    VideoPlayer videoPlayer;
    Slider slider;
    private bool onDown = false;
    private void Awake()
    {
        if (video == null)
            Debug.LogError("В Slider не указано видео!");
        if (canvasVideoPlayer == null)
            Debug.LogError("В Slider не указано canvasVideoPlayer!");
        if (canvasVideoPlayerObject == null)
            Debug.LogError("В Slider не указано canvasVideoPlayerObject!");
        videoPlayer = video.GetComponent<VideoPlayer>();
        slider = GetComponent<Slider>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("ITS WORK!!!");
    }
    // Start is called before the first frame update
    public void changeTime()
    {

        if (videoPlayer.canSetTime && Input.touchCount > 0)
            videoPlayer.time = slider.value * videoPlayer.length;
        
    }
    private void Update()
    {

        if (videoPlayer.isPlaying && Input.touchCount == 0)
        {
            slider.value = (float)videoPlayer.time / (float)videoPlayer.length;
        }
        else if (canvasVideoPlayer.isPlaying && Input.touchCount == 0)
        {
            slider.value = (float)canvasVideoPlayer.time / (float)canvasVideoPlayer.length;
        }
        
    }
    
    private void OnMouseDown()
    {
        onDown = true;
        Debug.Log("OnDrag");
    }
    private void OnMouseDrag()
    {
        changeTime();
    }
    private void OnMouseUp()
    {
        onDown = false;
    }

    
}
