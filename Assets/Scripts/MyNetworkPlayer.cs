using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string name = "None";

    [Server]
    public void SetName(string _name) {
        name = _name;
    }

    [SyncVar]
    [SerializeField]
    private Color color = Color.white;

    [Server]
    public void SetColor(Color _color) {
        color = _color;
        GetComponentInChildren<MeshRenderer>().material.color = color;
    }
}
