using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VrButtonController : MonoBehaviour
{
    [SerializeField] PlayButtonController PlayBtn;
    public static bool status;

    private BoxCollider collider;
    private SpriteRenderer rend;
    // Start is called before the first frame update
    private void Awake()
    {
        if (!PlayBtn)
            Debug.LogError("В кнопке VR не указана кнопка Play");
    }
    void Start()
    {
        collider = GetComponent<BoxCollider>();
        rend = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        status = PlayBtn.status;
        collider.enabled = status;
        rend.enabled = status;       
    }
}
