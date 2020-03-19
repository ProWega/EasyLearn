using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(BoxCollider))]
public class ResetBtnController : MonoBehaviour
{
    private VideoPlayer video;

    // Если родитель рендерится, то переменная TRUE
    public static bool canRendering = false;

    public static bool isPresssed; // Нажата ли кнопка

    // Start is called before the first frame update
    void Start()
    {
        video = GetComponentInParent<VideoPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        canRendering = transform.parent.GetComponentInParent<MeshRenderer>().enabled;
        gameObject.GetComponent<BoxCollider>().enabled = canRendering;
    }
    private void OnMouseUpAsButton()
    {
        if (video.canSetTime)
            video.time = 0f;
    }
    private void OnMouseDown()
    {
        isPresssed = true;
    }
    private void OnMouseUp()
    {
        isPresssed = false;
    }

}
