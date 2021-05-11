using System.Collections;
using System.Collections.Generic;
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

    [Server]
    public void SetName(string _name) {
        name = _name;
    }

    private void HandleNameUpdated(string oldName, string newName) {
        nameText.text = newName;
    }

    [SyncVar(hook=nameof(HandleColorUpdated))]
    [SerializeField]
    private Color color = Color.white;

    [Server]
    public void SetColor(Color _color) {
        color = _color;
        GetComponentInChildren<MeshRenderer>().material.color = color;
    }

    private void HandleColorUpdated(Color oldColor, Color newColor) {
        renderer.material.color = newColor;
    }
}
