using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class ChangeSkin : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] GameObject[] body;
    [SerializeField] GameObject[] head;
    [SerializeField] bool isMale;
    void Start()
    {
        Replace(isMale);
    }

    void Update()
    {
      if (photonView.IsMine)
        {
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                isMale = !isMale;
                Replace(isMale);
            }
        }  
    }

    public void Replace(bool value)
    {
        body[0].SetActive(value);      
        head[0].SetActive(value); 
        body[1].SetActive(!value); 
        head[1].SetActive(!value); 
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            //Отправляем другим игрокам значение переменной isMale, если она поменялась
            stream.SendNext(isMale);
        }
        else
        { 
            //Получаем данные от других игроков и записываем их в переменную isMale
            isMale = (bool)stream.ReceiveNext();
            //Вызываем метод Replace с новым значением isMale
            Replace(isMale);
        }
    }
}
