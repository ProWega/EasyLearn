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
    public Sprite pause;
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
        gameObject.GetComponent<SpriteRenderer>().enabled = GetComponentInParent<MeshRenderer>().enabled;
        gameObject.GetComponent<BoxCollider>().enabled = GetComponentInParent<MeshRenderer>().enabled;
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
            video.Play();
            isMustPlaying = true;
        }
    }
}
