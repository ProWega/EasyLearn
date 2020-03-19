using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(BoxCollider))]
public class FullscreenButtonController : MonoBehaviour
{

    [SerializeField]
    CanvasController canvasController;
    public static bool canRendering = false;
    public static bool isPresssed = false;
    [SerializeField]
    VideoPlayer video;
    // Start is called before the first frame update
    private void Awake()
    {

        if (video == null)
        {
            Debug.LogError("Не добавлен video");
        }
    }

    // Update is called once per frame
    void Update()
    {
        canRendering = transform.parent.GetComponentInParent<MeshRenderer>().enabled;
        gameObject.GetComponent<BoxCollider>().enabled = canRendering;
    }
    private void OnMouseDown()
    {
        isPresssed = true;
    }
    private void OnMouseUp()
    {
        isPresssed = false;
    }
    private void OnMouseUpAsButton()
    {
        
        canvasController.StartCanvas(video.url, video.time);
    }
}
