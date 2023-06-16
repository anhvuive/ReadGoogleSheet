using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfigList", menuName = "Config/CharacterConfigList")]
public class CharacterConfigList : ScriptableObject
{
    public string sheetId;
    public string gridId;
    public List<CharacterConfig> characters;

    [ContextMenu("Sync")]
    private void Sync()
    {
        ReadGoogleSheets.FillData<CharacterConfig>(sheetId, gridId, list =>
        {
            characters = list;
            ReadGoogleSheets.SetDirty(this);
        });
    }

    [ContextMenu("OpenSheet")]
    private void OpenSheet()
    {
        ReadGoogleSheets.OpenUrl(sheetId, gridId);
    }
}

[Serializable]
public class CharacterConfig
{
    public string characterName;
    public Sprite characterAvatar;
    public string hp;
    public string damage;
    public string unlockLevel;
    public UnlockType unlockType;
    public string unlockCost;
    public List<int> upgradeCost;
}

public enum UnlockType
{
    Free,
    Coin,
    Ads,
    Gem,
}