using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
    private GameObject arVideoCanvas;
    VideoPlayer video;
    public Camera camera;
    [SerializeField]
    private GameObject ImagePeremotkaLeft;
    [SerializeField]
    private GameObject ImagePeremotkaRight;
    public static bool canTouch = true;
    [SerializeField] CanvasController canvasController;
    public VideoPlayer videoCanvas;

    [SerializeField]
    private GameObject ImagePeremotkaLeftCanvas;
    [SerializeField]
    private GameObject ImagePeremotkaRightCanvas;

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
        //if (arCanvas)
        //{
        //    StopAllCoroutines();
        //    arCanvas = false;
        //    arVideoCanvas.SetActive(false);
        //}
        if (canTouch)
        {
            if (Input.touchCount > 0)
            { //if there is any touch
                RaycastHit hit;
                Ray ray = camera.ScreenPointToRay(Input.mousePosition);
                if (!Physics.Raycast(ray, out hit))
                {
                    Transform objectHit = hit.transform;
                    if (objectHit == null)
                    {
                        touchDuration += Time.deltaTime;
                        touch = Input.GetTouch(0);
                        if (touch.phase == TouchPhase.Ended && touchDuration < 0.2f) //making sure it only check the touch once && it was a short touch/tap and not a dragging.
                            StartCoroutine("singleOrDouble");
                    }
                    // Do something with the object that was hit by the raycast.
                }
            }
            else
                touchDuration = 0.0f;
        }
        else
        {
            arVideoCanvas.SetActive(false);
        }
        if (GetComponent<MeshRenderer>().enabled && !video.isPlaying)
        {
            arVideoCanvas.SetActive(true);
        }
    }

    IEnumerator singleOrDouble()
    {
        yield return new WaitForSeconds(0.2f);
        if (touch.tapCount == 1)
        {
            Debug.Log("Single");

            StopAllCoroutines();
            StartCoroutine(arCanvasCourutine());

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
        if (canvasController.isCanvas)
        {
            if (gameObject.GetComponent<MeshRenderer>().enabled)
            {
                if (video.canSetTime)
                {
                    StartCoroutine(RightPeremotka());
                    video.time += changeTime;
                }
                else
                    Debug.LogError("Не может установить время");
            }
        }
        else
        {
            if (videoCanvas.canSetTime)
            {
                StartCoroutine(RightPeremotka());
                videoCanvas.time -= changeTime;
            }
            else
                Debug.LogError("Не может установить время");
        }
        
    }
    void minusSomeSeconds()
    {
        if (!canvasController.isCanvas)
        {
            if (gameObject.GetComponent<MeshRenderer>().enabled)
            {
                if (video.canSetTime)
                {
                    StartCoroutine(LeftPeremotka());
                    video.time -= changeTime;
                }
                else
                    Debug.LogError("Не может установить время");
            }
        }
        else
        {
            if (videoCanvas.canSetTime)
            {
                StartCoroutine(LeftPeremotka());
                videoCanvas.time -= changeTime;
            }
            else
                Debug.LogError("Не может установить время");
        }
    }
    

    IEnumerator arCanvasCourutine()
    {
        if (video.isPlaying)
        {
            changeArCanvasStatus();
        }
        yield return new WaitForSeconds(2f);
        arVideoCanvas.SetActive(false);
    }
    private void changeArCanvasStatus()
    {
        if (arVideoCanvas.activeSelf)
        {
            arVideoCanvas.SetActive(false);
        }
        else
        {
            arVideoCanvas.SetActive(true);
        }
    }

    IEnumerator LeftPeremotka()
    {
        StopCoroutine(RightPeremotka());
        ImagePeremotkaRight.SetActive(false);
        ImagePeremotkaRightCanvas.SetActive(false);
        if (!canvasController.isCanvas)
        {
            ImagePeremotkaLeft.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            ImagePeremotkaLeft.SetActive(false);
        }
        else
        {
            ImagePeremotkaLeftCanvas.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            ImagePeremotkaLeftCanvas.SetActive(false);
        }
    }
    IEnumerator RightPeremotka()
    {
        StopCoroutine(LeftPeremotka());
        ImagePeremotkaLeft.SetActive(false);
        ImagePeremotkaLeftCanvas.SetActive(false);
        if (canvasController.isCanvas)
        {
            ImagePeremotkaRight.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            ImagePeremotkaRight.SetActive(false);
        }
        else
        {
            ImagePeremotkaRightCanvas.SetActive(true);
            yield return new WaitForSeconds(0.4f);
            ImagePeremotkaRightCanvas.SetActive(false);
        }
    }
}
