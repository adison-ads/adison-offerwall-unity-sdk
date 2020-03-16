using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdisonOfwColorScheme
{
#if UNITY_ANDROID
    public AndroidJavaObject javaObject;

    public AdisonOfwColorScheme()
    {
        //javaObject = new AndroidJavaObject("co.adison.offerwall.AdisonOfwColorScheme");
    }

    public string primaryColor;
    public string primaryColorVariant;
    public string onPrimaryColor;
    
#elif UNITY_IOS
    [DllImport("__Internal")]
    private static extern IntPtr __createAdisonOfwColorScheme();

    [DllImport("__Internal")]
    private static extern void __setPrimaryColor(IntPtr colorScheme, string hexString);

    [DllImport("__Internal")]
    private static extern void __setPrimaryColorVariant(IntPtr colorScheme, string hexString);

    [DllImport("__Internal")]
    private static extern void __setOnPrimaryColor(IntPtr colorScheme, string hexString);

    public IntPtr nativeObject;

    public AdisonOfwColorScheme()
    {
        nativeObject = __createAdisonOfwColorScheme();
    }

    public string primaryColor
    {
        set
        {
            __setPrimaryColor(nativeObject, value);

        }
    }

    public string primaryColorVariant
    {
        set
        {
            __setPrimaryColorVariant(nativeObject, value);

        }
    }

    public string onPrimaryColor
    {
        set
        {
            __setOnPrimaryColor(nativeObject, value);

        }
    }

#endif
}
