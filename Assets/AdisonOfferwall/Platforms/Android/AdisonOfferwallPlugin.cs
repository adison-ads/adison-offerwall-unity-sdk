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

        public static OnLifeCycleListener LifeCycleListener;

        public static AndroidJavaObject getContext()
        {
            AndroidJavaClass playerClass = new AndroidJavaClass(Utils.UnityActivityClassName);            
            return playerClass.GetStatic<AndroidJavaObject>("currentActivity");
        }

        public static void Initialize(string appKey)
        {
            PluginClass.CallStatic("initialize", new object[2] { getContext(), appKey });
            
            LifeCycleListener = new OnLifeCycleListener();
            PluginClass.CallStatic("setLifeCycleListener", LifeCycleListener);
        }

        public static void SetDebugEnabled(bool enable)
        {
            PluginClass.CallStatic("setDebugEnabled", enable);
        }

        public static void SetUid(string uid)
        {
            PluginClass.CallStatic("setUid", uid);
        }

        public static string GetUid()
        {
            return PluginClass.CallStatic<string>("getUid");
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

        public static void SetConfig(AdisonConfig config)
        {
            PluginClass.CallStatic("setConfig", config.javaObject);
        }

        public static void SetColorScheme(AdisonColorScheme colorScheme)
        {
            //PluginClass.CallStatic("setColorScheme", colorScheme.javaObject);
        }

        #region Callbacks from OnLifeCycleListener.
        public class OnLifeCycleListener : AndroidJavaProxy
        {
            public event EventHandler<EventArgs> OnOfferwallOpen;
            public event EventHandler<EventArgs> OnOfferwallClosed;

            public OnLifeCycleListener() : base(Utils.LifeCycleListenerClassName) { }

            public void offerwallOpen()
            {
                OnOfferwallOpen?.Invoke(this, EventArgs.Empty);
            }

            public void offerwallClosed()
            {
                OnOfferwallClosed?.Invoke(this, EventArgs.Empty);
            }
        }
        #endregion
    }
#endif
}
