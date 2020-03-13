using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transport : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Object;
    public Vector3 _targetPoint;
    GameObject gameObjects;
     // Указываешь нужные координаты
    float _speed; // указываем скорость

    //Создаем переменную для обозначения скорости движения
    

    void Start()
    {
        
        _speed = 0.1f;
    }

    void FixedUpdate()
    {

        MoveObj(); // Вызываем метод для движения, вызов происходит каждый фрейм или что то вроде того
    }

    void MoveObj()
    {
        Object.transform.position = Vector3.MoveTowards(Object.transform.position, _targetPoint, _speed);
        foreach (GameObject gameObjects in GameObject.FindGameObjectsWithTag("s1"))
        {
            gameObjects.GetComponent<Transport>().enabled = false;
        }
        //Двигаем объект с помощью метода MoveTowards, в скобках слева на право 1. Текущее положение, 2. Точка назначения, 3. скорость
    }
}

