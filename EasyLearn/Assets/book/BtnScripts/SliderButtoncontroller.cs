using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SliderButtoncontroller : MonoBehaviour
{

    public static bool canRendering = false;
    public BoxCollider cubeCollider;
    public MeshRenderer cubeRend;
    public static bool isPresssed; // Нажата ли кнопка

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(transform.GetChild(0).transform.name);
    }

    // Update is called once per frame
    void Update()
    {
        canRendering = transform.parent.transform.parent.GetComponentInParent<MeshRenderer>().enabled;

        Debug.Log(canRendering);

        cubeCollider.enabled = canRendering;
        cubeRend.enabled = canRendering;
        GetComponent<BoxCollider>().enabled = canRendering;
        GetComponent<MeshRenderer>().enabled = canRendering;
        
    }
}
