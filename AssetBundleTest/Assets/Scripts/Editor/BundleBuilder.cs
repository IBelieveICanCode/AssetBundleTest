using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BundleBuilder : Editor
{
    [MenuItem("Assets/BuildAssets")]
    static void BuildAllAssets()
    {
        BuildPipeline.BuildAssetBundles(@"C:\Users\Sergey\RepositoryForMyGames\AssetBundleTest\AssetBundleTest\Assets\Resources", 
            BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}
