using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class ExitButtonController : MonoBehaviour
{
    public GameObject playBtn;
    public GameObject vrBtn;
    public GameObject arBtn;
    // Start is called before the first frame update
    private void Awake()
    {
        #region Все ли элементы UI указаны?
        if (playBtn == null)
        {
            Debug.LogError("Не указана кнопка выхода");
        }
        if (vrBtn == null)
        {
            Debug.LogError("Не указана кнопка VR режима");
        }
        if (arBtn == null)
        {
            Debug.LogError("Не указана кнопка AR режима");
        }
        if (playBtn == arBtn || playBtn == vrBtn || vrBtn == arBtn)
        {
            Debug.LogError("Какая то из кнопок не указана. Вы указали одинаковые в разные переменные");
        }
        #endregion
    }
    private void OnMouseUpAsButton()
    {
        ImageTracking_Video.VideoPlayerBookAgent.SetVideoIsPlaying();
        TurnOffExitBtn();
        MainBookController.mainMenu = true;
        MainBookController.Video = false;
        Debug.Log("Выход из режима видео");
    }

    // Выключние кнопки выхода и включение кнопки входа
    public void TurnOffExitBtn()
    {
        playBtn.GetComponent<SpriteRenderer>().enabled = true;
        playBtn.GetComponent<BoxCollider>().enabled = true;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;

        vrBtn.GetComponent<SpriteRenderer>().enabled = true;
        vrBtn.GetComponent<BoxCollider>().enabled = true;
        arBtn.GetComponent<SpriteRenderer>().enabled = true;
        arBtn.GetComponent<BoxCollider>().enabled = true;
    }
}
