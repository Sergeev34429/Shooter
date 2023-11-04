using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class MiniMap : MonoBehaviourPunCallbacks
{
    //скорость прокрутки
    [SerializeField] private float scrollSpeed = 1f;
    //Минимальное приближение
    [SerializeField] private float minValue = 10f;
    //Максимальное приближение
    [SerializeField] private float maxValue = 60f;
    //Текущее приближение
    private float currentValue;
    void Start()
    {
        if (!photonView.IsMine)
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        // Получаем значение прокрутки колесика мыши
        float scrollDelta = Input.GetAxis("Mouse ScrollWheel");
        // Изменяем значение переменной текущего приближения в зависимости от направления прокрутки
        if (scrollDelta < 0)
        {
            currentValue += scrollSpeed;
        }
        else if (scrollDelta > 0)
        {
            currentValue -= scrollSpeed;
        }
        // Ограничиваем значение переменной между минимальным и максимальным значениями
        //То есть текущее значение будет ограничиваться данными,
        //которые мы задали и не будет уходить в бесконечность
        currentValue = Mathf.Clamp(currentValue, minValue, maxValue);
        gameObject.GetComponent<Camera>().orthographicSize = currentValue; 
    }
}
