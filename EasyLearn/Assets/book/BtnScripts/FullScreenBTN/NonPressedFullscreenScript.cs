using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NonPressedFullscreenScript : MonoBehaviour
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
        if (FullscreenButtonController.canRendering)
        {
            rend.enabled = !FullscreenButtonController.isPresssed;
        }
        else
            rend.enabled = false;
    }
}
