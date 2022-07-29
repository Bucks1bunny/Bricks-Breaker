using System;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    public event Action<int> Scored = delegate { };

    public HashSet<Brick> bricks
    {
        get;
        private set;
    } = new HashSet<Brick>();

    private void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            var brick = transform.GetChild(i).GetComponent<Brick>();
            bricks.Add(brick);
            brick.BrickDestroyed += OnBrickDestroy;
        }
    }

    private void OnBrickDestroy(Brick brick)
    {
        bricks.Remove(brick);
        Scored(brick.data.score);
    }
}
