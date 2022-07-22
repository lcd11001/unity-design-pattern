using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{
    [Tooltip("This prefab will only be spawned once and persisted between scenes")]
    [SerializeField] GameObject persitentPrefab = null;

    // PRIVATE STATE
    static bool hasSpawned = false;

    private void Awake()
    {
        if (hasSpawned)
        {
            return;
        }

        SpawnPersistentObject();

        hasSpawned = true;
    }

    private void SpawnPersistentObject()
    {
        GameObject persistentObject = Instantiate(persitentPrefab);
        DontDestroyOnLoad(persistentObject);
    }
}
