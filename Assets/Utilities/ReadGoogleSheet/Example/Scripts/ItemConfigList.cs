using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ItemConfigList", menuName = "Config/ItemConfigList")]
public class ItemConfigList : ScriptableObject
{
    public string sheetId;
    public string gridId;
    
    public List<ItemConfig> items;

    [ContextMenu("Sync")]
    private void Sync()
    {
        ReadGoogleSheets.FillData<ItemConfig>(sheetId, gridId, list =>
        {
            items = list;
            ReadGoogleSheets.SetDirty(this);
        });   
    }

    [ContextMenu("OpenSheet")]
    private void Open()
    {
        ReadGoogleSheets.OpenUrl(sheetId, gridId);
    }
}

[Serializable]
public class ItemConfig
{
    public string name;
    public Sprite avatar;
    public int damage;
    public int price;
    public UnlockType costType;
}