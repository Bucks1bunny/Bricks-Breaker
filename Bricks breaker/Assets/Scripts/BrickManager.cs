using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public event Action<int> Scored = delegate { };
    public event Action<bool> AllBricksDestoyed = delegate { };

    [SerializeField]
    private GameObject[] bricks;
    [SerializeField]
    private Transform[] positions;

    private Dictionary<Transform, Brick> bricksPosition = new Dictionary<Transform, Brick>();

    private void Awake()
    {
        foreach (var position in positions)
        {
            var brick = bricks[UnityEngine.Random.Range(0, bricks.Length)].GetComponent<Brick>();
            brick.BrickDestroyed += OnBrickDestroy;
            Instantiate(brick, position.position, Quaternion.identity);
            bricksPosition.Add(position, brick);
        }
    }

    private void OnBrickDestroy(Brick brick)
    {
        foreach (var tempBrick in bricksPosition)
        {
            if (tempBrick.Value != brick)
            {
                continue;
            }
            bricksPosition.Remove(tempBrick.Key);
        }
        Scored(brick.Data.score);
        if (bricksPosition.Count == 0)
        {
            AllBricksDestoyed(true);
        }
    }

}
