using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdisonOfferwall.Common
{
    public class AdisonColorScheme
    {
#if UNITY_ANDROID
        public AndroidJavaObject javaObject;

        public AdisonColorScheme()
        {
            //javaObject = new AndroidJavaObject("co.adison.offerwall.AdisonColorScheme");
        }

        public string PrimaryColor;
        public string PrimaryColorVariant;
        public string OnPrimaryColor;

#elif UNITY_IOS
        [DllImport("__Internal")]
        private static extern IntPtr __createAdisonColorScheme();

        [DllImport("__Internal")]
        private static extern void __setPrimaryColor(IntPtr colorScheme, string hexString);

        [DllImport("__Internal")]
        private static extern void __setPrimaryColorVariant(IntPtr colorScheme, string hexString);

        [DllImport("__Internal")]
        private static extern void __setOnPrimaryColor(IntPtr colorScheme, string hexString);

        public IntPtr nativeObject;

        public AdisonColorScheme()
        {
            nativeObject = __createAdisonColorScheme();
        }

        public string PrimaryColor
        {
            set
            {
                __setPrimaryColor(nativeObject, value);

            }
        }

        public string PrimaryColorVariant
        {
            set
            {
                __setPrimaryColorVariant(nativeObject, value);

            }
        }

        public string OnPrimaryColor
        {
            set
            {
                __setOnPrimaryColor(nativeObject, value);

            }
        }
#endif
    }
}