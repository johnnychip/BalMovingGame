using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProceduralGenerator : MonoBehaviour {

    #region Properties

    [SerializeField]
    private Transform spawnPoint;

    //Hidden
    private readonly int numberOfPaths = 3;
    private Dictionary<Vector2, int> pathDick = new Dictionary<Vector2, int>();
    
    //Cached Components
    private Transform target;
    private Transform lastTarget;
    private IEnumerator recordPath;

    #endregion

    #region Unity Functions

    private void Start()
    {
        Setup();

        UIManager.Instance.onPlay += ExecuteGeneration;
    }

    #endregion

    #region Class Functions

    private void Setup()
    {
        //Dictionary setup
        int index = 1;

        for (int i = 1; i <= numberOfPaths; i++)
        {
            for (int j = 1; j <= numberOfPaths; j++)
            {
                pathDick.Add(new Vector2(i, j), index);
                index++;
            }
        }

        //For loop explanation:

        /*
        pathDic.Add(new Vector2(1, 1), 1);
        pathDic.Add(new Vector2(1, 2), 2);
        pathDic.Add(new Vector2(1, 3), 3);
        pathDic.Add(new Vector2(2, 1), 4);
        pathDic.Add(new Vector2(2, 2), 5);
        pathDic.Add(new Vector2(2, 3), 6);
        pathDic.Add(new Vector2(3, 1), 7);
        pathDic.Add(new Vector2(3, 2), 8);
        pathDic.Add(new Vector2(3, 3), 9);
        */

        //Path setup
        GameObject path = PoolManager.Instance.GetObject(Vector3.zero, 5);

        lastTarget = path.transform;
    }

    private void ExecuteGeneration()
    {
        lastTarget.GetComponent<Rigidbody2D>().velocity = Vector2.up * GameManager.Instance.velocity;

        ExecuteRecordPath();
    }

    private void ExecuteRecordPath()
    {
        //Set new path
        Transform newPath = GetNewPath();

        //Corutine logic
        if (recordPath != null)
            StopCoroutine(recordPath);

        recordPath = RecordPath(newPath);

        StartCoroutine(recordPath);
    }

    private Transform GetNewPath()
    {
        string[] lastPathCoordinates = lastTarget.name.Split('-');

        int lastPos = Int32.Parse(lastPathCoordinates[1]);

        int poolIndex = pathDick[new Vector2(
            lastPos,
            UnityEngine.Random.Range(1, numberOfPaths + 1))];

        return PoolManager.Instance.GetObject(spawnPoint.position, poolIndex).transform;
    }

    #endregion

    #region Coroutines

    private IEnumerator RecordPath(Transform target)
    {
        this.target = target;

        this.target.GetComponent<Rigidbody2D>().velocity = Vector2.up * GameManager.Instance.velocity;

        while (this.target.position.y > 0)
        {
            yield return null;
        }

        //Last target pool release
        string[] lastPathCoordinates = lastTarget.name.Split('-');

        int xComponent = Int32.Parse(lastPathCoordinates[0]);
        int yComponent = Int32.Parse(lastPathCoordinates[1]);

        Vector2 lastPos = new Vector2(xComponent, yComponent);

        int poolIndex = pathDick[lastPos];

        PoolManager.Instance.ReleaseObject(lastTarget.gameObject, poolIndex);

        //Set new last target
        lastTarget = this.target;
    }

    #endregion
}
