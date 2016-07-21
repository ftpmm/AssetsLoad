using UnityEngine;
using System.Collections;
using UnityEditor;

public class Builder : ScriptableObject {

    [MenuItem("Build/BuildAssets")]
    public static void BuilderAssets()
    {
        BuildPipeline.BuildAssetBundles("Assets/AssetBundles", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.StandaloneWindows64);
    }
}
