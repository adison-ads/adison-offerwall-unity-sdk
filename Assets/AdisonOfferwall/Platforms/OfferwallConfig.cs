using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OfferwallConfig
{
#if UNITY_ANDROID
    public AndroidJavaObject javaObject;

    public OfferwallConfig()
    {
        javaObject = new AndroidJavaObject("co.adison.offerwall.AdisonConfig");
    }

    public string offerwallListTitle
    {
        set
        {
            javaObject.Set("offerwallListTitle", value);

        }
    }

    public bool prepareViewHidden
    {
        set
        {
            javaObject.Set("prepareViewHidden", value);

        }
    }
#elif UNITY_IOS
    [DllImport("__Internal")]
    private static extern IntPtr __createOfferwallConfig();

    [DllImport("__Internal")]
    private static extern void __setOfferwallListTitle(IntPtr config, string title);

    [DllImport("__Internal")]
    private static extern void __isPrepareViewHidden(IntPtr config, bool hidden);

    public IntPtr nativeObject;

    public OfferwallConfig()
    {
        nativeObject = __createOfferwallConfig();
    }

    public string offerwallListTitle
    {
        set
        {
            __setOfferwallListTitle(nativeObject, value);

        }
    }

    public bool prepareViewHidden
    {
        set
        {
            __isPrepareViewHidden(nativeObject, value);

        }
    }

#endif
}
