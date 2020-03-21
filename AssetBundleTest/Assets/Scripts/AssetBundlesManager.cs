using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class AssetBundlesManager : MonoBehaviour
{
    AssetBundle myLoadedAssetBundle;
    public string path;

    public void LoadAssetBundle(string assetBundle)
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile(Application.persistentDataPath + "/" + assetBundle);
        Debug.Log(myLoadedAssetBundle == null ? "Failed to Load" : "Asset Loaded");
    }

    public GeometryObjectModel FindMyAssetFromBundle(GeometryObjectData objectData)
    {
        var assets = myLoadedAssetBundle.LoadAllAssets();
        foreach (GameObject asset in assets)
        {
            for (int index = 0; index < objectData.ClicksData.Count; index++)
            {
                if (asset.name == objectData.ClicksData[index].ObjectType)
                {
                    GeometryObjectModel myObject = asset.GetComponent<GeometryObjectModel>();
                    myObject.ClickData = objectData.ClicksData[index];
                    return myObject;
                };
            }
        }
        myLoadedAssetBundle.Unload(true);
        return null;
    }

}
