using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public event Action<int> Scored = delegate { };
    public event Action<bool> AllBricksDestoyed = delegate { };

    public HashSet<Brick> Bricks
    {
        get;
        private set;
    } = new HashSet<Brick>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var brick = transform.GetChild(i).GetComponent<Brick>();
            Bricks.Add(brick);
            brick.BrickDestroyed += OnBrickDestroy;
        }
    }

    private void OnBrickDestroy(Brick brick)
    {
        Bricks.Remove(brick);
        Scored(brick.Data.score);
        if (Bricks.Count == 0)
        {
            AllBricksDestoyed(true);
        }
    }

}
