using TMPro;
using Unity.Netcode;
using UnityEngine;

public class HostServerFormHandler : FormHandler
{
    [SerializeField]
    TMP_InputField serverName;
    public override void ChangeData()
    {
        if(NetworkManager.Singleton != null && NetworkManager.Singleton.TryGetComponent(out ExampleNetworkDiscovery discovery))
        {
            discovery.ServerName = serverName.text;
        }
        
    }

    public override void DoAction()
    {
        if(NetworkManager.Singleton != null)
        {
            NetworkManager.Singleton.StartHost();
        }
    }
}
