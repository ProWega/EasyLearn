using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(VideoPlayer))]
public class TouchVideoController : MonoBehaviour
{
    float touchDuration;
    Touch touch;
    float screenWidth;
    private bool checking = false;
    [SerializeField]
    private float changeTime;
    [SerializeField]
    private GameObject videoVrCanvas;
    VideoPlayer video;
    // Start is called before the first frame update
    void Start()
    {
        screenWidth = Screen.currentResolution.width;
        video = GetComponent<VideoPlayer>();
        if (!video.isPrepared)
        {
            video.Prepare();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        { //if there is any touch
            
            touchDuration += Time.deltaTime;
            touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f) //making sure it only check the touch once && it was a short touch/tap and not a dragging.
                StartCoroutine("singleOrDouble");
        }
        else
            touchDuration = 0.0f;
    }

    IEnumerator singleOrDouble()
    {
        yield return new WaitForSeconds(0.2f);
        if (touch.tapCount == 1)
        {
            Debug.Log("Single");
        }

        else if (touch.tapCount == 2)
        {
            //this coroutine has been called twice. We should stop the next one here otherwise we get two double tap
            StopCoroutine("singleOrDouble");
            if (touch.position.x > (screenWidth / 2))
            {
                //Debug.Log("DoubleRight");
                plusSomeSeconds();
            }
            else
            {
                //Debug.Log("DoubleLeft");
                minusSomeSeconds();
            }
        }
    }

    void plusSomeSeconds()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled)
        {
            if (video.canSetTime)
                video.time += changeTime;
            else
                Debug.LogError("Не может установить время");
        }
    }
    void minusSomeSeconds()
    {
        if (gameObject.GetComponent<MeshRenderer>().enabled)
        {
            if (video.canSetTime)
                video.time -= changeTime;
            else
                Debug.LogError("Не может установить время");
        }
    }
}
