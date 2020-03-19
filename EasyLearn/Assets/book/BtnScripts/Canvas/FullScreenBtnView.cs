using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FullScreenBtnView : MonoBehaviour
{
    [SerializeField] CanvasController canvasController;
    [SerializeField] GameObject FullScreenBtn;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        FullScreenBtn.SetActive(canvasController.isCanvas);
    }
}
