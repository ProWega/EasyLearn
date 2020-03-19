using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;


public class poshol : MonoBehaviour

{

    private Vector3 mOffset;
    private float mZCoord;
    private bool canDrag;
    private bool userRule = false;
    [SerializeField] private VideoPlayer video;
    void OnMouseDown()

    {
        userRule = true;
        mZCoord = Camera.main.WorldToScreenPoint(
        gameObject.transform.position).z;

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }

    private void OnMouseUp()
    {
        video.time = (transform.localPosition.x + 0.5f) * video.length;
        userRule = false;
    }

    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;

        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {
        if (canDrag)
        {
            if (transform.localPosition.x <= 0.5 && transform.localPosition.x >= -0.5)
                transform.position = GetMouseAsWorldPoint() + mOffset;
            
        }
        else if (transform.localPosition.x >= 0.5)
        {
            canDrag = false;
            transform.localPosition = new Vector3(0.49f, 0, -0.08f);
            canDrag = true;
        }
        else
        {
            canDrag = false;
            transform.localPosition = new Vector3(-0.49f, 0, -0.08f);
            canDrag = true;
        }

    }
    void Update()
    {
        if (!userRule)
        {
            transform.localPosition = new Vector3((float)(video.time / video.length) - 0.5f, 0, -0.08f);
        }
        if (transform.localPosition.x < 0.5 && transform.localPosition.x > -0.5)
        {
            canDrag = true;
            gameObject.transform.localPosition = (new Vector3(gameObject.transform.localPosition.x, 0, -0.08f));
            Debug.Log(transform.localPosition.x);
        }
        else
        {
            canDrag = false;
            if (transform.localPosition.x > 0.5)
            {
                transform.localPosition = new Vector3(0.49f, 0, -0.08f);
                canDrag = true;
            }
            else
            {
                transform.localPosition = new Vector3(-0.49f, 0, -0.08f);
                canDrag = true;
            }           
        }
    }
}
