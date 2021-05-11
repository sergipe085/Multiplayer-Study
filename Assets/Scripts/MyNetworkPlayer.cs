using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SyncVar]
    [SerializeField]
    private string name = "None"
}
