using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Mirror;
using TMPro;

public class MyNetworkPlayer : NetworkBehaviour
{
    [SerializeField] private TMP_Text nameText = null;
    [SerializeField] private Renderer renderer = null;

    [SyncVar(hook=nameof(HandleNameUpdated))]
    [SerializeField]
    private string name = "None";

    [SyncVar(hook = nameof(HandleColorUpdated))]
    [SerializeField]
    private Color color = Color.white;

    #region Server

    [Server]
    public void SetName(string _name) {
        name = _name;
    }

    [Server]
    public void SetColor(Color _color) {
        color = _color;
    }

    [Command]
    public void CmdSetName(string _name) {
        string[] blackListed = new string[] { "Nigga" };
        bool contain = false;
        for (int i = 0; i < blackListed.Length; i++) {
            if (_name.Contains(blackListed[i])) {
                contain = true;
                break;
            }
        }
        
        if (string.IsNullOrWhiteSpace(_name) || _name.Length >= 10 || contain) {
            return;
        }

        RpcLogNewName(_name);
        SetName(_name);
    }

    #endregion

    #region Client

    private void HandleNameUpdated(string oldName, string newName) {
        nameText.text = newName;
    }

    private void HandleColorUpdated(Color oldColor, Color newColor) {
        renderer.material.color = newColor;
    }

    [ContextMenu("Set My Name")]
    private void SetMyName() {
        CmdSetName("Nigga");
    }

    [ClientRpc]
    private void RpcLogNewName(string _name) {
        Debug.Log(_name);
    }

    #endregion
}
