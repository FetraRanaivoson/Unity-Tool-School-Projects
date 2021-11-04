using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    public static int PlayerId;
    private Vector3 position;
    private float _velocity;

    public void Init(Vector2 offset)
    {
        transform.position = new Vector3(Random.Range(-offset.x, offset.x), transform.position.y,
            Random.Range(-offset.y, offset.y));
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, Random.Range(0,360), transform.rotation.z));
        _velocity = Random.Range(5, 10);
        
        int textureNbCol = 10;
        int textureNbRow = 10;
        int rangePositionStart = 15;
        Texture2D t2d = new Texture2D(textureNbCol, textureNbRow);
        t2d.filterMode = FilterMode.Point;
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        GetComponent<MeshRenderer>().sharedMaterial.mainTexture = t2d;
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
    public void Move(Vector2 offset, float deltaTime)
    {
        transform.Translate(Vector3.forward * deltaTime);
    }

    public void InitPlayer(PlayerData playerData)
    {
        transform.name = playerData.name;
        transform.position = playerData.position;
        _velocity = playerData.velocity;
    }
    public PlayerData GetData()
    {
        return new PlayerData(name, transform.position, _velocity);
    }

   
    
    // private int _nbPlayer = 20;
    // private GameObject _playerResources;
    // private List<GameObject> _players;
    // private List<Vector3> _directions;
    // private List<Rigidbody> _rigidbodies;
    // private float _speed = 25;
    //
    // private int textureNbCol = 10;
    // private int textureNbRow = 10;
    // private int rangePositionStart = 15;
    private void Awake()
    {
        PlayerId = 1;
        // _playerResources = AssetDatabase.LoadAssetAtPath<GameObject>("Assets/Prefabs/Player.prefab");
        // _players = new List<GameObject>();
        // InitPlayers();
        //
        // _directions = new List<Vector3>();
        // for (int i = 0; i < _nbPlayer; i++)
        // {
        //     _directions.Add(new Vector3(Random.Range(-1,1), 0, Random.Range(-1,1)));
        // }
        //
        // _rigidbodies = new List<Rigidbody>();
        // for (int i = 0; i < _nbPlayer; i++)
        // {
        //     _rigidbodies.Add(_players[i].GetComponent<Rigidbody>());
        // }
    }

    void Start() 
    {
    }
    
    void FixedUpdate()
    {
        // for (int i = 0; i < _nbPlayer; i++)
        // {
        //     _rigidbodies[i].AddForce(_directions[i].normalized * _speed * Time.deltaTime, 
        //         ForceMode.Impulse);
        // }
    }

    public void SerializePosition()
    {
        // List<PlayerData> playerDatas = new List<PlayerData>();
        // for (int i = 0; i< _nbPlayer; i++)
        // {
        //     playerDatas.Add(new PlayerData(_players[i].name + (i+1), _players[i].transform.position));
        // }
        // //PlayerWrappper p = new PlayerWrappper();
        // //p.players = playerDatas;
        // JsonManager.WrapperList <PlayerData> datas = new JsonManager.WrapperList<PlayerData>(playerDatas);
        //
        // string json = JsonManager.ToJson<JsonManager.WrapperList <PlayerData>>(datas);
        // Debug.Log(json);
        //
        // if (!Directory.Exists(Application.streamingAssetsPath))
        // {
        //     Directory.CreateDirectory(Application.streamingAssetsPath);
        // }
        // File.WriteAllText(Path.Combine(Application.streamingAssetsPath, "myFile.json"), json);
        // AssetDatabase.SaveAssets();
    }

    public void DeserializePosition()
    {
        // string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, "myFile.json"));
        //
        // JsonManager.WrapperList<PlayerData> playerDatas = JsonManager.FromJson<JsonManager.WrapperList<PlayerData>>(json);
        // Debug.Log(playerDatas.datas.Count);
    }
}