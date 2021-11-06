using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.IO;
using Random = UnityEngine.Random;

public class Player : MonoBehaviour
{
    private float RbForce { get; set; }
    public Rigidbody Rb { get; set; }
    public Color Color { get; set; }

    private void Awake()
    {
        Rb = GetComponent<Rigidbody>();
    }

    void Start() 
    {
    }
    
    public void Init(Vector2 offset)
    {
        //Randomize position
        transform.position = new Vector3(Random.Range(-offset.x, offset.x), .7f,
            Random.Range(-offset.y, offset.y));
        //Randomize direction
        transform.rotation = Quaternion.Euler(new Vector3(transform.rotation.x, Random.Range(0,360), transform.rotation.z));
        //Randomize force to apply
        RbForce = Random.Range(500, 1000);
        //RbForce = 20;
        //Randomize color
        InitColor(new Color(Random.value, Random.value, Random.value, 1));
    }
    public void ApplyForce()
    {
        Rb.AddForce(transform.forward * RbForce, ForceMode.Force);
        //transform.Translate(0,0, RbForce * Time.deltaTime);
    }

    public void InitPlayer(PlayerData playerData)
    {
        transform.name = playerData.name;
        transform.position = playerData.position;
        Rb.velocity = playerData.velocity;
        InitColor(playerData.color);
    }
    public PlayerData GetData()
    {
        return new PlayerData(name, transform.position, Rb.velocity, Color);
    }

    private void InitColor(Color color)
    {
        int textureNbCol = 10;
        int textureNbRow = 10;
        int rangePositionStart = 15;
        Texture2D t2d = new Texture2D(textureNbCol, textureNbRow);
        t2d.filterMode = FilterMode.Point;
        GetComponent<MeshRenderer>().material = new Material(Shader.Find("Diffuse"));
        GetComponent<MeshRenderer>().sharedMaterial.mainTexture = t2d;
        Color randomColor = color;
        this.Color = randomColor;
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