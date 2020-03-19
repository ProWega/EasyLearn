using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationValue : MonoBehaviour
{
    public GameObject sphere;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(System.Math.Cos(30));
        Debug.Log(30 * Mathf.PI / 180);
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(gameObject.transform.rotation.eulerAngles.z);
        Debug.Log(System.Math.Sin((30 * System.Math.PI)/ 180));
        Debug.Log(Mathf.Sin(gameObject.transform.rotation.eulerAngles.z * Mathf.PI / 180));

        sphere.transform.position = new Vector3(transform.position.x + 10, (transform.position.x + 10) * Mathf.Sin(gameObject.transform.rotation.eulerAngles.z * Mathf.PI / 180), transform.position.z);
    }
}
