using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameController : Singleton<GameController>
{
    Timer timer;
    ClickColorData clickData;
    [SerializeField]
    private AssetBundlesManager assetBundleManager;
    [SerializeField]
    private DataManager DataManager;

    private void Awake()
    {
        //InitFigure();
    }
    public void InitFigure()
    {
        DataManager.Load();
        List<string> _assetNames = DataManager.PlayerData.AssetNames;
        int random = Random.Range(0, _assetNames.Count);
        assetBundleManager.LoadAssetBundle(_assetNames[random].ToLower());

        GeometryObjectData geometryData = Resources.Load<GeometryObjectData>("Installers/GeometryObjectData");
        GeometryObjectModel asset = assetBundleManager.FindMyAssetFromBundle(geometryData);
        if (asset != null)
            Instantiate(asset);

        GameData gameData = Resources.Load<GameData>("Installers/GameData");
        timer = new Timer(gameData.ObservableTime, asset.ChangeColor);
        print("Time to change color: " + gameData.ObservableTime);
        print("Min click count:" + asset.ClickData.MinClicksCount);
        print("Max click count:" + asset.ClickData.MaxClicksCount);
        timer.Restart();
    }

    public void SaveInfoAboutAssetBundles()
    {
        DataManager.SaveAssetBundles();
    }
}
