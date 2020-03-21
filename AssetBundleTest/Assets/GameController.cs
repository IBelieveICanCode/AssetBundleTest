using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : Singleton<GameController>
{
    ClickColorData clickData;
    [SerializeField]
    private AssetBundlesManager assetBundleManager;
    [SerializeField]
    private DataManager DataManager;

    private void Awake()
    {
        InitFigure();
    }
    public void InitFigure()
    {
        //DataManager.SaveAssetBundles();
        DataManager.Load();
        List<string> _assetNames = DataManager.PlayerData.AssetNames;
        int random = Random.Range(0, _assetNames.Count);
        assetBundleManager.LoadAssetBundle(_assetNames[random].ToLower());

        GeometryObjectData geometryData = Resources.Load<GeometryObjectData>("Installers/GeometryObjectData");
        GeometryObjectModel asset = assetBundleManager.FindMyAssetFromBundle(geometryData);
        if (asset != null)
            Instantiate(asset);

        GameData gameData = Resources.Load<GameData>("Installers/GameData");
        asset.GameData = gameData;
        asset.Init();
    }
}
