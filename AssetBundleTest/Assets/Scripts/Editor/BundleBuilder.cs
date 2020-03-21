using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/BuildAssets")]
    static void BuildAllAssets()
    {
        BuildPipeline.BuildAssetBundles(Application.persistentDataPath, 
            BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}
