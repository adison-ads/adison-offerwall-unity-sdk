using System;
using UnityEngine;

using AdisonOfferwall.Api;
using AdisonOfferwall.Common;

namespace AdisonOfferwall.Android
{
#if UNITY_ANDROID
    public class AdisonOfferwallPlugin
    {
        static AndroidJavaClass _pluginClass;

        public static AndroidJavaClass PluginClass
        {
            get
            {
                if (_pluginClass == null)
                {
                    _pluginClass = new AndroidJavaClass(Utils.OfferwallClassName);
                }
                return _pluginClass;
            }
        }

        public static event EventHandler<EventArgs> OnLoginRequested;

        public static AndroidJavaObject getContext()
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);            
            return playerClass.GetStatic<AndroidJavaObject>("currentActivity");
        }

        public static void Initialize(string appKey)
        {
            PluginClass.CallStatic("initialize", new object[2] { getContext(), appKey });
            //setOnLoginRequested(new OnLoginRequestedListener());         
        }

        public static void SetDebugEnabled(bool enable)
        {
            PluginClass.CallStatic("setDebugEnabled", enable);
        }

        public static void SetUid(string uid)
        {
            PluginClass.CallStatic("setUid", uid);
        }

        public static void SetIsTester(bool enable)
        {
            PluginClass.CallStatic("setIsTester", enable);
        }

        public static void SetEnvironment(Api.Environment environment)
        {
            AndroidJavaClass enumClass = new AndroidJavaClass("co.adison.offerwall.Server");
            if (environment == Api.Environment.Development)
            {
                PluginClass.CallStatic("setServer", new object[1] { enumClass.GetStatic<AndroidJavaObject>("Development") });
            }
            else if (environment == Api.Environment.Staging)
            {
                PluginClass.CallStatic("setServer", new object[1] { enumClass.GetStatic<AndroidJavaObject>("Staging") });
            }
            else if (environment == Api.Environment.Production)
            {
                PluginClass.CallStatic("setServer", new object[1] { enumClass.GetStatic<AndroidJavaObject>("Production") });
            }
        }

        public static void SetBirthYear(int birthYear)
        {
            PluginClass.CallStatic("setBirthYear", birthYear);
        }

        public static void SetGender(Gender gender)
        {
            AndroidJavaClass enumClass = new AndroidJavaClass("co.adison.offerwall.Gender");
            if (gender == Gender.Unknown)
            {
                PluginClass.CallStatic("setGender", new object[1] { enumClass.GetStatic<AndroidJavaObject>("UNKNOWN") });
            }
            else if (gender == Gender.Male)
            {
                PluginClass.CallStatic("setGender", new object[1] { enumClass.GetStatic<AndroidJavaObject>("MALE") });
            }
            else if (gender == Gender.Female)
            {
                PluginClass.CallStatic("setGender", new object[1] { enumClass.GetStatic<AndroidJavaObject>("FEMALE") });
            }
        }

        public static void ShowOfferwall()
        {
            PluginClass.CallStatic("showOfferwall");
        }

        public static void SetOnLoginRequested(OnLoginRequestedListener listener)
        {
            PluginClass.CallStatic("setOfferwallListener", listener);
        }

        public static void SetConfig(AdisonConfig config)
        {
            PluginClass.CallStatic("setConfig", config.javaObject);
        }

        public static void SetColorScheme(AdisonColorScheme colorScheme)
        {
            //PluginClass.CallStatic("setColorScheme", colorScheme.javaObject);
        }

        public class OnLoginRequestedListener : AndroidJavaProxy
        {
            public OnLoginRequestedListener() : base(Utils.RequestLoginListenerClassName) { }
            void requestLogin(AndroidJavaObject context)
            {
                Debug.Log("login request");
                onLoginRequested();
            }
        }

    #region Callbacks from RequestLoginListener.

        public static void onLoginRequested()
        {
            if (OnLoginRequested != null)
            {
                OnLoginRequested(PluginClass, EventArgs.Empty);
            }
        }

    #endregion
    }
#endif
}


