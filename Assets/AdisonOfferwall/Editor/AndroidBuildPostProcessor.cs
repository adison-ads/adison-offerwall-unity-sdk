#if UNITY_ANDROID
using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;

using UnityEditor.Build;
using System.IO;

//using AdisonOfferwall.Editor;

public static class AndroidBuildPostProcessor
{
    private static string _postBuildDirectoryKey { get { return "AdisonOfferwallPostBuildPath-" + PlayerSettings.productName; } }
    private static string postBuildDirectory
    {
        get
        {
            return EditorPrefs.GetString(_postBuildDirectoryKey);
        }
        set
        {
            EditorPrefs.SetString(_postBuildDirectoryKey, value);
        }
    }

    [PostProcessBuild(800)]
    public static void OnPostProcessBuild(BuildTarget buildTarget, string pathToBuiltProject)
    {
        postBuildDirectory = pathToBuiltProject;
        var scriptPath = Path.Combine(Application.dataPath, "Plugins/Android/res/values/colors.xml");


        Directory.CreateDirectory(postBuildDirectory + "/launcher/src/main/res/values");
        var filepath = Path.Combine(postBuildDirectory, "launcher/src/main/res/values/colors.xml");

        File.Copy(scriptPath, filepath, true);
    }
}

#endif
