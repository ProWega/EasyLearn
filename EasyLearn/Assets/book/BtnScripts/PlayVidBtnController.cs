using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(BoxCollider))]
public class PlayVidBtnController : MonoBehaviour
{
    private VideoPlayer video;
    public static bool isMustPlaying = true;
    public Sprite play;
    public Sprite playPressed;
    public Sprite pause;
    public Sprite pausePressed;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    private void Awake()
    {
        #region Все ли элементы UI указаны?
        if (play == null)
        {
            Debug.LogError("Play кнопка AR видео не назначена");
        }
        if (pause == null)
        {
            Debug.LogError("Pause кнопка AR видео не назначена");
        }
        #endregion
    }
    void Start()
    {
        video = GetComponentInParent<VideoPlayer>();
        GetComponent<SpriteRenderer>().sprite = pause;
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = transform.parent.GetComponentInParent<MeshRenderer>().enabled;
        gameObject.GetComponent<BoxCollider>().enabled = transform.parent.GetComponentInParent<MeshRenderer>().enabled;
    }
    private void OnMouseUpAsButton()
    {
        if (video.isPlaying)
        {
            rend.sprite = play;
            video.Pause();
            isMustPlaying = false;
        }
        else
        {
            rend.sprite = pause;
            cantTouch();
            video.Play();
            isMustPlaying = true;
        }
    }

    IEnumerator cantTouch()
    {
        TouchVideoController.canTouch = false;
        yield return new WaitForSeconds(2);
        TouchVideoController.canTouch = true;
    }
    private void OnMouseDown()
    {
        if (!video.isPlaying)
            rend.sprite = playPressed;
        else
            rend.sprite = pausePressed;
    }
    private void OnMouseUp()
    {
        if (!video.isPlaying)
            rend.sprite = play;
        else
            rend.sprite = pause;
    }
}
