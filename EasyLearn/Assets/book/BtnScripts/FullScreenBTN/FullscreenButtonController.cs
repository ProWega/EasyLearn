using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(BoxCollider))]
public class FullscreenButtonController : MonoBehaviour
{
    public static bool canRendering = false;
    public static bool isPresssed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        canRendering = GetComponentInParent<MeshRenderer>().enabled;
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
        
    }
}
