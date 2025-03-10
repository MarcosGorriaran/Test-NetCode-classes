using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UIElements;

public class ServerFinderList : FormHandler
{
    List<ServerListElement> _discoveredServers = new List<ServerListElement>();
    List<ServerListElement> _pool = new List<ServerListElement>();
    ExampleNetworkDiscovery _networkDiscovery;
    [SerializeField]
    ServerListElement _listElementPrefab;
    [SerializeField]
    Transform _scrollViewContentObject;

    private void Awake()
    {
        _networkDiscovery = GetComponent<ExampleNetworkDiscovery>();
        _networkDiscovery.OnServerFound.AddListener(OnServerFound);
    }
    void OnServerFound(IPEndPoint sender, DiscoveryResponseData response)
    {
        AddSectionToList(sender.Address, response);
    }
    ServerListElement AddSectionToList(IPAddress hostAddress, DiscoveryResponseData data)
    {
        IEnumerable<ServerListElement> availableObjects = _pool.Where(obj=> obj.gameObject.activeSelf);
        ServerListElement newListElement;
        if (availableObjects.Count() > 0)
        {
            newListElement = availableObjects.First();
            newListElement.gameObject.SetActive(true);
        }
        else
        {
            newListElement = Instantiate(_listElementPrefab,_scrollViewContentObject);
            newListElement.transform.localScale = _listElementPrefab.transform.localScale;
            _pool.Add(newListElement);
        }
        _discoveredServers.Add(newListElement);
        newListElement.ChangeData(hostAddress, data);
        return newListElement;
        
    }
    public override void ChangeData()
    {
        EmptyList();
    }
    void EmptyList()
    {
        foreach (ServerListElement element in _discoveredServers)
        {
            element.gameObject.SetActive(false);
        }
        _discoveredServers.Clear();
    }
    public override void DoAction()
    {
        throw new System.NotImplementedException();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
