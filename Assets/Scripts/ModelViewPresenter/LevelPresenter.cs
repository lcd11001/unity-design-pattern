using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class LevelPresenter : MonoBehaviour
{
    // Model
    [SerializeField] Level level;
    // View
    [SerializeField] TextMeshProUGUI levelText;
    [SerializeField] TextMeshProUGUI experienceText;
    [SerializeField] ParticleSystem levelParticle;
    [SerializeField] Button increaseXPButton;

    private void Start()
    {
        increaseXPButton.onClick.AddListener(GainExperience);
        level.onLevelUpAction += UpdateLevelUI;
        level.onExperienceUpAction += UpdateExperienceUI;
        UpdateUI();
    }

    private void OnDestroy()
    {
        increaseXPButton.onClick.RemoveListener(GainExperience);
        level.onLevelUpAction -= UpdateLevelUI;
        level.onExperienceUpAction -= UpdateExperienceUI;
    }

    private void UpdateExperienceUI(int newExperience)
    {
        experienceText.text = $"Experience: {newExperience}";
    }

    private void UpdateLevelUI(int newLevel)
    {
        levelText.text = $"Level: {newLevel}";
        levelParticle.Play();
    }

    private void GainExperience()
    {
        level.GainExperience(10);
    }

    private void UpdateUI()
    {
        levelText.text = $"Level: {level.GetLevel()}";
        experienceText.text = $"Experience: {level.GetExperience()}";
    }

}
