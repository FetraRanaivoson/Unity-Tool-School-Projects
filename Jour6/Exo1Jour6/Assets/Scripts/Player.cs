using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private int _nbPlayer = 20;
    private GameObject _playerResources;
    private List<GameObject> _players;
    private List<Vector3> _directions;
    private List<Rigidbody> _rigidbodies;
    private float _speed = 25;

    private int textureNbCol = 10;
    private int textureNbRow = 10;
    private int rangePositionStart = 15;
    private void Awake()
    {
        _playerResources = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player.prefab");
        _players = new List<GameObject>();
        InitPlayers();

        _directions = new List<Vector3>();
        for (int i = 0; i < _nbPlayer; i++)
        {
            _directions.Add(new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1)));
        }

        _rigidbodies = new List<Rigidbody>();
        for (int i = 0; i < _nbPlayer; i++)
        {
            _rigidbodies.Add(_players[i].GetComponent<Rigidbody>());
        }
    }

    private void InitPlayers()
    {
        for (int i = 0; i < _nbPlayer; i++)
        {
            _players.Add(GameObject.Instantiate(_playerResources));
            _players[i].transform.position = new Vector3(Random.Range(-rangePositionStart, rangePositionStart),
                _players[i].transform.position.y, Random.Range(-rangePositionStart, rangePositionStart));
            Texture2D t2d = new Texture2D(textureNbCol, textureNbRow);
            t2d.filterMode = FilterMode.Point;
            _players[i].GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
            _players[i].GetComponent<MeshRenderer>().sharedMaterial.mainTexture = t2d;

            Color randomColor = new Color(Random.value, Random.value, Random.value, 1);
            Color[,] playerColor = new Color[textureNbCol, textureNbRow];
            for (int r = 0; r < textureNbCol; r++)
            {
                for (int c = 0; c < textureNbRow; c++)
                {
                    playerColor[r, c] = randomColor;
                }
            }

            for (int row = 0; row < textureNbCol; row++)
            {
                for (int col = 0; col < textureNbRow; col++)
                {
                    t2d.SetPixel(row, col, playerColor[row, col]);
                }
            }

            t2d.Apply();
        }
    }

    void Start() 
    {
        
    }
    
    void FixedUpdate()
    {
        for (int i = 0; i < _nbPlayer; i++)
        {
            _rigidbodies[i].AddForce(_directions[i].normalized * _speed * Time.deltaTime, 
                ForceMode.Impulse);
        }
    }

    public void SerializePosition()
    {
        List<PlayerData> playerDatas = new List<PlayerData>();
        foreach (var player in _players)
        {
            playerDatas.Add(new PlayerData(player.transform.position));
        }
        //PlayerWrappper p = new PlayerWrappper();
        //p.players = playerDatas;
        JsonManager.WrapperList <PlayerData> datas = new JsonManager.WrapperList<PlayerData>(playerDatas);
        
        string json = JsonManager.ToJson<JsonManager.WrapperList <PlayerData>>(datas);
        Debug.Log(json);
        
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }
        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "myFile.json"), json);
        AssetDatabase.SaveAssets();

    }
    
    [Serializable]
    public class PlayerWrappper
    {
        public List<PlayerData> players;

    }
}