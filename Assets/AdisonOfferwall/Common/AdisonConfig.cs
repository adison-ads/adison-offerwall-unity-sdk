using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AdisonOfferwall.Common
{
    public class AdisonConfig
    {
#if UNITY_ANDROID
        public AndroidJavaObject javaObject;

        public AdisonConfig()
        {
            javaObject = new AndroidJavaObject("co.adison.offerwall.AdisonConfig");
        }

        public string OfferwallListTitle
        {
            set
            {
                javaObject.Set("offerwallListTitle", value);

            }
        }

        public bool PrepareViewHidden
        {
            set
            {
                javaObject.Set("prepareViewHidden", value);

            }
        }
#elif UNITY_IOS
        [DllImport("__Internal")]
        private static extern IntPtr __createAdisonConfig();

        [DllImport("__Internal")]
        private static extern void __setOfferwallListTitle(IntPtr config, string title);

        [DllImport("__Internal")]
        private static extern void __isPrepareViewHidden(IntPtr config, bool hidden);

        public IntPtr nativeObject;

        public AdisonConfig()
        {
            nativeObject = __createAdisonConfig();
        }

        public string OfferwallListTitle
        {
            set
            {
                __setOfferwallListTitle(nativeObject, value);

            }
        }

        public bool PrepareViewHidden
        {
            set
            {
                __isPrepareViewHidden(nativeObject, value);

            }
        }
#endif
    }
}