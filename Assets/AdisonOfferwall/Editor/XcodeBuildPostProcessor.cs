using UnityEngine;
using UnityEditor;
using UnityEditor.Callbacks;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using System.IO;
using System.Diagnostics;
using UnityEditor.iOS.Xcode;

public static class XcodeBuildPostProcessor
{
	private static string _postBuildDirectoryKey { get { return "XcodePostBuildPath-" + PlayerSettings.productName; } }
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
		if (buildTarget != BuildTarget.iOS) return;

        // PBXProject 초기화
        var projectPath = Path.Combine(pathToBuiltProject, "Unity-iPhone.xcodeproj/project.pbxproj");
		PBXProject pbxProject = new PBXProject();
		pbxProject.ReadFromFile(projectPath);
#if UNITY_2019_3_OR_NEWER
        string target = pbxProject.GetUnityMainTargetGuid();
#else
		string target = pbxProject.TargetGuidByName(PBXProject.GetUnityTargetName());
#endif

		// 빌드 설정 추가
		pbxProject.SetBuildProperty(target, "ALWAYS_EMBED_SWIFT_STANDARD_LIBRARIES", "YES");

		// 수정된 설정 반영
		pbxProject.WriteToFile(projectPath);
	}
}
