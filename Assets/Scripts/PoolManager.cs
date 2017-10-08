using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    #region Properties

    [SerializeField]
    private int poolSize;
    [SerializeField]
    private GameObject[] pathPrefabs = new GameObject[9];

    //Hidden
    [HideInInspector]
    public List<GameObject>[] paths = new List<GameObject>[9];

    //Cached components
    private new Transform transform;

    //Singleton!
    public static PoolManager Instance
    {
        get; private set;
    }

    #endregion

    #region Unity functions

    private void Awake()
    {
        if (Instance != null)
            DestroyImmediate(gameObject);
        else
            Instance = this;

        SetupPool();
    }

    #endregion

    #region Pool functions

    private void SetupPool()
    {
        transform = GetComponent<Transform>();

        //Path lists setup
        for (int i = 0; i < paths.Length; i++)
            paths[i] = new List<GameObject>();

        //Path pool setup
        for (int i = 0; i < paths.Length; i++)
        {
            for (int j = 0; j < poolSize; j++)
                AddObject(pathPrefabs[i], i);
        }
    }

    public GameObject GetObject(Vector3 position, int pathIndex)
    {
        if (paths[pathIndex].Count == 0)
            AddObject(pathPrefabs[pathIndex], pathIndex);

        return ObtainObject(position, pathIndex);
    }

    public void ReleaseObject(GameObject @object, int pathIndex)
    {
        List<GameObject> pathList = paths[pathIndex];

        @object.transform.parent = transform;
        @object.transform.position = Vector3.zero;
        @object.SetActive(false);
        pathList.Add(@object);
    }

    private void AddObject(GameObject pathPrefab, int pathIndex)
    {
        GameObject instance = Instantiate(pathPrefabs[pathIndex], Vector3.zero, Quaternion.identity, transform);

        instance.SetActive(false);
        paths[pathIndex].Add(instance);
    }

    private GameObject ObtainObject(Vector3 position, int pathIndex)
    {
        List<GameObject> pathList = paths[pathIndex];

        GameObject @object = pathList[pathList.Count - 1];

        pathList.RemoveAt(pathList.Count - 1);
        @object.transform.parent = null;
        @object.SetActive(true);
        @object.transform.position = position;

        return @object;
    }

    #endregion

    #region Coroutines

    private IEnumerator Instantiate(GameObject gameObject)
    {
        yield return Object.Instantiate(gameObject);
    }

    #endregion
}
