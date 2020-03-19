using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderViewController : MonoBehaviour
{
    [SerializeField] GameObject video; 
    [SerializeField] GameObject slider;
    [SerializeField] CanvasController canvasController;
    MeshRenderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = video.GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canvasController.isCanvas)
        {
            if (rend.enabled && !slider.activeSelf)
                slider.SetActive(true);
            else if (!rend.enabled && slider.activeSelf)
                slider.SetActive(false);
        }
        else
        {
            slider.SetActive(true);
        }
    }
}
