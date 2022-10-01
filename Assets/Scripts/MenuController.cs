using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{

    [SerializeField] private string VersionName = "0.1";
    [SerializeField] private GameObject UserNameMenu;
    [SerializeField] private GameObject ConnectPanel;

    [SerializeField] private InputField UsernameInput;
    [SerializeField] private InputField CreateGameInput;
    [SerializeField] private InputField JoinGameInput;

    [SerializeField] private GameObject StartButton;

    private void Awake() {

        PhotonNetwork.ConnectUsingSettings(VersionName);

    }

    private void Start() {
        
        UserNameMenu.SetActive(true);
        
    }

    private void OnConnectedToMaster() {

        PhotonNetwork.JoinLobby(TypedLobby.Default);
        Debug.Log("Connected");
    }

    public void ChangeUserNameInput() {
        bool status = UsernameInput.text.Length >= 3 ? true : false;

        StartButton.SetActive(status);
    }

    public void SetUserName() {
        UserNameMenu.SetActive(false);
        PhotonNetwork.playerName = UsernameInput.text;
    }

}
