using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour, IDataPersistence
{
    public event Action<int> Scored = delegate { };
    public event Action<bool> AllBricksDestoyed = delegate { };

    [SerializeField]
    private GameObject[] bricks;
    [SerializeField]
    private Transform[] positions;
    private Dictionary<Vector3, int> bricksDict = new Dictionary<Vector3, int>();
    private Dictionary<Vector3, GameObject> tempDict = new Dictionary<Vector3, GameObject>();

    public void LoadData(GameData data)
    {
        foreach (var pair in data.dict)
        {
            var brickGO = Instantiate(bricks[pair.Value], pair.Key, Quaternion.identity);
            bricksDict.Add(pair.Key, pair.Value);
            tempDict.Add(pair.Key, brickGO.gameObject);
        }
    }

    public void SaveData(GameData data)
    {
        data.dict.Clear();
        foreach (var pair in bricksDict)
        {
            data.dict.Add(pair.Key, pair.Value);
        }
    }

    private void Start()
    {
        if (bricksDict.Count == 0)
        {
            for (int i = 0; i < positions.Length; i++)
            {
                int randomBrick = UnityEngine.Random.Range(0, bricks.Length);
                var brick = bricks[randomBrick];
                var position = positions[i].position;
                var GO = Instantiate(brick, positions[i].position, Quaternion.identity);
                bricksDict.Add(position, randomBrick);
                tempDict.Add(position, GO);
            }
        }
        foreach (var brick in GameObject.FindGameObjectsWithTag("Brick"))
        {
            brick.GetComponent<Brick>().BrickDestroyed += OnBrickDestroy;
        }
    }

    private void OnBrickDestroy(Brick brick)
    {
        foreach (var pair in tempDict)
        {
            if (pair.Value != brick.gameObject)
            {
                continue;
            }
            bricksDict.Remove(pair.Key);
            tempDict.Remove(pair.Key);
            break;
        }
        Scored(brick.Data.score);
        if (tempDict.Count == 0)
        {
            AllBricksDestoyed(true);
        }
    }

}
