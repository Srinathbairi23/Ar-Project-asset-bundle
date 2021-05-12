#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class CreateAssetBundle : Editor
{
    [MenuItem("Assets/Create Asset Bundles")]

    static void BuildAssetBundle()
    {
        BuildPipeline.BuildAssetBundles(@"C:\Users\IND33D\Desktop\AssetBundle", BuildAssetBundleOptions.ChunkBasedCompression, BuildTarget.Android);
    }
}

#endif