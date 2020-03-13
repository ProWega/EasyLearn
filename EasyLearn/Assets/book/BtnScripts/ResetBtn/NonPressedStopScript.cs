// Для спрайта не нажатой кнопки

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPressedStopScript : MonoBehaviour
{
    private SpriteRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ResetBtnController.canRendering)
        {
            rend.enabled = !ResetBtnController.isPresssed;
        }
        else
            rend.enabled = false;
    }
}
