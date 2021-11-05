using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

[CustomEditor(typeof(MainScript))]
public class MainScriptEditor : Editor
{
    private MainScript _mainScript;
    private List<Player> _players;
    private string playerDataFilename = "myFile.json";
    private void OnEnable()
    {
        _mainScript = target as MainScript;
        _players = _mainScript.players;
    }

    public override void OnInspectorGUI()
    {
        Rect area = GUILayoutUtility.GetRect(EditorGUIUtility.currentViewWidth, 4 * EditorGUIUtility.singleLineHeight);

        GUI.Box(area, GUIContent.none);

        if (GUI.Button(
            new Rect(EditorGUIUtility.currentViewWidth / 2 - EditorGUIUtility.currentViewWidth / 4, 10,
                EditorGUIUtility.currentViewWidth / 2, 25), "Save"))
        {
            SerializePlayer();
        }

        if (GUI.Button(
            new Rect(EditorGUIUtility.currentViewWidth / 2 - EditorGUIUtility.currentViewWidth / 4, 40,
                EditorGUIUtility.currentViewWidth / 2, 25), "Load"))
        {
            DeserializePlayer();
        }

    }

    private void SerializePlayer()
    {
        List<PlayerData> playerData = new List<PlayerData>();
        for (int i = 0; i < _mainScript.NbPlayers; i++)
        {
            playerData.Add(new PlayerData(_players[i].name, _players[i].transform.position,
                _players[i].Rb.velocity, _players[i].Color));
        }

        JsonManager.WrapperList<PlayerData> data = new JsonManager.WrapperList<PlayerData>(playerData);
        string json = JsonManager.ToJson<JsonManager.WrapperList<PlayerData>>(data);
        Debug.Log(json);
        if (!Directory.Exists(Application.streamingAssetsPath))
        {
            Directory.CreateDirectory(Application.streamingAssetsPath);
        }

        File.WriteAllText(Path.Combine(Application.streamingAssetsPath, playerDataFilename), json);
        AssetDatabase.SaveAssets();
    }

    private void DeserializePlayer()
    {
        string json = File.ReadAllText(Path.Combine(Application.streamingAssetsPath, playerDataFilename));
        JsonManager.WrapperList<PlayerData> playersData =
            JsonManager.FromJson<JsonManager.WrapperList<PlayerData>>(json);

        for (int i = 0; i < playersData.datas.Count; i++)
        {
            _players[i].InitPlayer(playersData.datas[i]);
        }
    }
}
