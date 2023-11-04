using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Photon.Pun;

public class MenuManager : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_Text logText;
    [SerializeField] TMP_InputField inputField;

    public override void OnConnectedToMaster()
    {
        Log("Connected to the server");
    }

    void Log(string message)
    {
        logText.text += "\n";
        logText.text += message;
    }

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(null, new Photon.Realtime.RoomOptions { MaxPlayers = 15 });
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRandomRoom();
    }

    void Start()
    {
        //присваиваем игроку них с рандомным числом
        PhotonNetwork.NickName = "Player" + Random.Range(1, 9999);
        //Отображаем ник игрока в поле Log
        Log("Player Name: " + PhotonNetwork.NickName);
        //Настройки игры
        PhotonNetwork.AutomaticallySyncScene = true; //Автопереключение сцены
        PhotonNetwork.GameVersion = "1"; //Версия игры
        PhotonNetwork.ConnectUsingSettings(); //Подключается к серверу Photon
    }

    public override void OnJoinedRoom()
    {
        Log("Joined the lobby");
        PhotonNetwork.LoadLevel("Lobby");
    }

    public void ChangeName()
    {
        //Считываем то, что написал игрок в поле InputField
        PhotonNetwork.NickName = inputField.text;
        //Выводим в поле игрока его новый никнейм
        Log("New Player name: " + PhotonNetwork.NickName);
    }

    void Update()
    {
        
    }
}
