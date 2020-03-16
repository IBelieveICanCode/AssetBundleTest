using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadAssetBundles : MonoBehaviour
{
    AssetBundle myLoadedAssetBundle;

    public GameObject cube;
    public string path;
    public string assetName;
    void Start()
    {
        //LoadAssetBundle(path);
        InstantiateObject(assetName);
    }

    private void LoadAssetBundle(string bundleUrl)
    {
        myLoadedAssetBundle = AssetBundle.LoadFromFile(bundleUrl);
        Debug.Log(myLoadedAssetBundle == null ? "Failed to Load" : "Asset Loaded");
    }

    void InstantiateObject(string assetName)
    {
        //var prefab = myLoadedAssetBundle.LoadAsset(assetName);
        Instantiate(cube, Vector3.zero, Quaternion.identity);
    }
}
