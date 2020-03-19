using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(BoxCollider))]
public class PlayButtonController : MonoBehaviour
{
    public GameObject exitBtn;
    public GameObject vrBtn;
    public GameObject arBtn;
    public VideoPlayer video;
    [HideInInspector]
    public bool status;
    // Start is called before the first frame update
    private void Awake()
    {
        #region Все ли элементы UI указаны?
        if (exitBtn == null)
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
        if (exitBtn == arBtn || exitBtn == vrBtn || vrBtn == arBtn)
        {
            Debug.LogError("Какая то из кнопок не указана. Вы указали одинаковые в разные переменные");
        }
        #endregion
        
    }
    // Update is called once per frame
    void Update()
    {
        status = gameObject.GetComponent<SpriteRenderer>().enabled;
        // Обработка ошибки
        if (!MainBookController.mainMenu && gameObject.GetComponent<SpriteRenderer>().enabled == true)
        {
            TurnOffPlayBtn();
        }
        
    }
    private void OnMouseUpAsButton()
    {

        ImageTracking_Video.VideoPlayerBookAgent.SetVideoIsPlaying();
        MainBookController.mainMenu = false;
        MainBookController.Video = true;
        Debug.Log("Отдана команда на запуск видео");
        TurnOffPlayBtn();
    }

    // Выключение кнопки входа и включение лишних кнопок
    public void TurnOffPlayBtn()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        gameObject.GetComponent<BoxCollider>().enabled = false;
        vrBtn.GetComponent<SpriteRenderer>().enabled = false;
        vrBtn.GetComponent<BoxCollider>().enabled = false;
        arBtn.GetComponent<SpriteRenderer>().enabled = false;
        arBtn.GetComponent<BoxCollider>().enabled = false;
        exitBtn.GetComponent<SpriteRenderer>().enabled = true;
        exitBtn.GetComponent<BoxCollider>().enabled = true;
        
    }
}
