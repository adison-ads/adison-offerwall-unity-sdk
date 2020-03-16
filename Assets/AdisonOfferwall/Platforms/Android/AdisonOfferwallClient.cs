using System;
using UnityEngine;

using AdisonOfferwall.Api;
//using AdisonOfferwall.Common;

namespace AdisonOfferwall.Android
{
    public class OfferwallClient : IOfferwallClient
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

        public static void initialize(string appKey)
        {
            PluginClass.CallStatic("initialize", new object[2] { getContext(), appKey });
            //setOnLoginRequested(new OnLoginRequestedListener());         
        }

        public static void setDebugEnabled(bool enable)
        {
            PluginClass.CallStatic("setDebugEnabled", enable);
        }

        public static void setUid(string uid)
        {
            PluginClass.CallStatic("setUid", uid);
        }

        public static void setIsTester(bool enable)
        {
            PluginClass.CallStatic("setIsTester", enable);
        }

        public static void setServer(Api.Environment environment)
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

        public static void setBirthYear(int birthYear)
        {
            PluginClass.CallStatic("setBirthYear", birthYear);
        }

        public static void setGender(Gender gender)
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

        public static void showOfferwall()
        {
            PluginClass.CallStatic("showOfferwall");
        }

        public static void setOnLoginRequested(OnLoginRequestedListener listener)
        {
            PluginClass.CallStatic("setOfferwallListener", listener);
        }

        public static void setConfig(OfferwallConfig config)
        {
            PluginClass.CallStatic("setConfig", config.javaObject);
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
}


