using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;

public class MainScript : MonoBehaviour
{
    //public Player player;
    
    private int nbPlayers = 20;
    private GameObject _playerResource;
    public List<Player> players;

    
    private Vector2 offset;

    private void Awake()
    {
        //player = GetComponent<Player>();
        _playerResource = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player.prefab");
        players = new List<Player>();
        offset = new Vector2(20,20);
        for (int i = 0; i < nbPlayers; i++)
        {
            GameObject playerObjectInstance = GameObject.Instantiate(_playerResource);
            Player playerScript = playerObjectInstance.GetComponent<Player>();
            players.Add(playerScript);
            players[i].Init(offset);
        }
        
    }

    void Start()
    {
    }
    
    void Update()
    {
        for (int i = 0; i < players.Count; i++)
        {
            players[i].Move(offset, Time.deltaTime);
        }
    }
}
