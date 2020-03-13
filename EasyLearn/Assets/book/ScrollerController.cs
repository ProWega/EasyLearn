using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
[RequireComponent(typeof(BoxCollider))]
public class ScrollerController : MonoBehaviour
{
    private Vector3 mOffset;
    private float mZCoord;
    private float mYCoord;
    // Start is called before the first frame update
    private VideoPlayer video;
    private Vector3 start;
    private Vector3 end;
    // Start is called before the first frame update
    void Start()
    {  
        video = GetComponentInParent<VideoPlayer>();
        start = new Vector3(-(video.transform.lossyScale.x / 2), transform.position.y, transform.position.z);
        end = new Vector3((video.transform.lossyScale .x / 2), transform.position.y, transform.position.z);
        transform.position = start;

        mZCoord = transform.localPosition.z;
        mYCoord = transform.localPosition.y;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = GetComponentInParent<MeshRenderer>().enabled;
        gameObject.GetComponent<BoxCollider>().enabled = GetComponentInParent<MeshRenderer>().enabled;
        Debug.Log(GetMouseAsWorldPoint());
    }
    void OnMouseDown()

    {
        //mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        //mYCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.localPosition - GetMouseAsWorldPoint();
    }



    private Vector3 GetMouseAsWorldPoint()
    {
        // Pixel coordinates of mouse (x,y)
        Vector3 mousePoint = Input.mousePosition;

        // z coordinate of game object on screen

        mousePoint.z = mZCoord;
        mousePoint.y = mYCoord;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);
    }
    void OnMouseDrag()
    {
        transform.localPosition = GetMouseAsWorldPoint() + mOffset;
    }
}
