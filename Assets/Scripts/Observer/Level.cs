using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class LevelUpEvent: UnityEvent<int> {}

public class Level : MonoBehaviour
{
    [SerializeField] int pointsPerLevel = 200;
    int experiencePoints = 0;

    // Observer
    [SerializeField] LevelUpEvent onLevelUp;

    private void Start()
    {
        StartCoroutine("SimulateGainExperience");
    }

    IEnumerator SimulateGainExperience()
    {
        while (true)
        {
            yield return new WaitForSeconds(.2f);

            GainExperience(10);
        }
    }

    public void GainExperience(int points)
    {
        // for ex: when level up, reset health
        int level = GetLevel();

        experiencePoints += points;

        int newLevel = GetLevel();
        if (newLevel > level)
        {
            // GetComponent<Health>().ResetHealth();
            Debug.Log("raise LEVEL UP event");
            onLevelUp?.Invoke(newLevel);
        }
    }

    public int GetExperience()
    {
        return experiencePoints;
    }

    public int GetLevel()
    {
        return experiencePoints / pointsPerLevel;
    }
}
