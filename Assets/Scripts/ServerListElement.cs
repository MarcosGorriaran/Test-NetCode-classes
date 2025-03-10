using System.Net;
using TMPro;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class ServerListElement : FormHandler
{
    DiscoveryResponseData _responsetData;
    IPAddress _hostIpAddress;
    [SerializeField]
    TMP_Text _hostServerNameText;
    [SerializeField]
    TMP_Text _hostIPAddressText;
    [SerializeField]
    Button _connectButton;

    public override void ChangeData()
    {
        _hostServerNameText.text = _responsetData.ServerName;
        _hostIPAddressText.text = _hostIpAddress.ToString();
    }
    public void ChangeData(IPAddress hostIP,DiscoveryResponseData broadcastData)
    {
        _hostIpAddress = hostIP;
        _responsetData = broadcastData;
        ChangeData();
    }

    public override void DoAction()
    {
        if(NetworkManager.Singleton == null)
        {
            Debug.LogError("The form can't perform the action if there is no network manager");
            return;
        }
    }
}
