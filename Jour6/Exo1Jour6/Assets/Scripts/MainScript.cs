using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    public int NbPlayers { get; private set; }
    private GameObject _playerResource;
    public List<Player> players;
    private Vector2 _offset;

    private void Awake()
    {
        _playerResource = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player.prefab");
        players = new List<Player>();
        _offset = new Vector2(20,20);
        NbPlayers = 20;
        for (int i = 0; i < NbPlayers; i++)
        {
            GameObject playerObjectInstance = GameObject.Instantiate(_playerResource);
            Player playerScript = playerObjectInstance.GetComponent<Player>();
            players.Add(playerScript);
            players[i].Init(_offset);
        }
    }

    void Start()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].ApplyForce();
        }
    }
    
    void Update()
    {
    }
}
