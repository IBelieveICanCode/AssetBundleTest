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

    #if UNITY_EDITOR
    private void Awake()
    {
        //Only after loading a new bundles
        DataManager.SaveAssetBundles();
    }
    #endif  

    public void InitFigure()
    {
        try
        {
            DataManager.Load();
            List<string> _assetNames = DataManager.PlayerData.AssetNames;
            int random = Random.Range(0, _assetNames.Count);
            assetBundleManager.LoadAssetBundle(_assetNames[random].ToLower());

            GeometryObjectData geometryData = Resources.Load<GeometryObjectData>("Installers/GeometryObjectData");
            GeometryObjectModel asset = assetBundleManager.FindMyAssetFromBundle(geometryData);
            if (asset != null)
            {
                Instantiate(asset);
                GameData gameData = Resources.Load<GameData>("Installers/GameData");
                timer = new Timer(gameData.ObservableTime, asset.ChangeColor);
                print("Time to change color: " + gameData.ObservableTime);
                print("Min click count:" + asset.ClickData.MinClicksCount);
                print("Max click count:" + asset.ClickData.MaxClicksCount);
                timer.Restart();
            }
            else
                print("Asset doesn't exist in loaded bundle");
        }

        catch (System.NullReferenceException e)
        {
            print ("First Save some bundles through Assets/BuildAssets");
        }
    }
}
