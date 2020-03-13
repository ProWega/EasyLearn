using System.Collections;

using System.Collections.Generic;

using UnityEngine;



public class DragObject : MonoBehaviour

{

    private Vector3 mOffset;



    private float mZCoord;
    private float mYCoord;


    private void Update()
    {
        //Debug.Log(Input.mousePosition.x);
        //Debug.Log(GetComponentInParent<Transform>().rotation.z);
        Debug.Log(GetComponentInParent<Transform>().rotation.z);
    }
    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).z;
        mYCoord = Camera.main.WorldToScreenPoint(gameObject.transform.position).y;
        

        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

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

        Vector3 position = GetMouseAsWorldPoint() + mOffset;
        transform.position = new Vector3(position.x, position.y, position.z);
    }

}