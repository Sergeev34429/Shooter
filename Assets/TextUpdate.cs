using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
public class TextUpdate : MonoBehaviourPunCallbacks, IPunObservable
{
    [SerializeField] TMP_Text playerNickName;
    int health = 100;
    void Start()
    {
        if (photonView.IsMine)
        {
            playerNickName.text = photonView.Controller.NickName + "\n" + "Health: " + health.ToString();
            photonView.RPC("RotateName", RpcTarget.Others);
        }
    }

    void Update()
    {
        
    }

    //принимаем данные
    public void SetHealth(int newHealth)
    {
        //обновляем переменную health
        health = newHealth;
        //обновляем текст на нашем UI
        //получаем никнейм от фотона + переходим на следующую строку и выводим здоровье
        playerNickName.text = photonView.Controller.NickName + "\n" + "Health: " + health.ToString();
    }

    [PunRPC]
    public void RotateName()
    {
        playerNickName.GetComponent<RectTransform>().localScale = new Vector3(-1, 1, 1);
    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        if (stream.IsWriting)
        {
            stream.SendNext(health);
        }
        else
        {
            health = (int)stream.ReceiveNext();
            playerNickName.text = photonView.Controller.NickName + "\n" + "Health: " + health.ToString();
        }
    }
}
