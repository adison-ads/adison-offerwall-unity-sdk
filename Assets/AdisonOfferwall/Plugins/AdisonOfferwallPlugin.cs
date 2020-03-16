using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AdisonOfferwall.Api;

namespace AdisonOfferwallPlugin
{
	public class Adison
	{
		const string pluginName = "co.adison.offerwall.Adison";

#if UNITY_IOS
		[DllImport("__Internal")]
		private static extern void __initialize(string appKey);

		[DllImport("__Internal")]
		private static extern void __setDebugEnabled(bool enable);

		[DllImport("__Internal")]
		private static extern void __setUid(string uid);

		[DllImport("__Internal")]
		private static extern void __setIsTester(bool enable);

        [DllImport("__Internal")]
        private static extern void __setServer(int env);

        [DllImport("__Internal")]
		private static extern void __setBirthYear(int birthYear);

        [DllImport("__Internal")]
        private static extern void __setGender(int gender);

        [DllImport("__Internal")]
		private static extern void __showOfferwall();


		public static void initialize(string appKey)
		{
			__initialize(appKey);
		}

		public static void setDebugEnabled(bool enable)
		{
			__setDebugEnabled(enable);
		}

		public static void setUid(string uid)
		{
			__setUid(uid);
		}

		public static void setIsTester(bool enable)
		{
			__setIsTester(enable);
		}

		public static void setServer(Environment env)
		{
            if (env == Environment.Development)
            {
                __setServer(0);
            }
            else if (env == Environment.Staging)
            {
                __setServer(1);
            }
            else if (env == Environment.Production)
            {
                __setServer(2);
            }
        }

		public static void setBirthYear(int birthYear)
		{
			__setBirthYear(birthYear);
		}

		public static void setGender(Gender gender)
		{
            if (gender == Gender.UNKNOWN)
            {
                __setGender(0);
            }
            else if (gender == Gender.MALE)
            {
                __setGender(1);
            }
            else if (gender == Gender.FEMALE)
            {
                __setGender(2);
            }
        }

		public static void showOfferwall()
		{
			__showOfferwall();
		}

		public static string getSdkVersion()
		{

			return "unknown";
		}



#elif UNITY_ANDROID
		static AndroidJavaClass _pluginClass;
		static AndroidJavaObject _pluginInstance;

		public static AndroidJavaClass PluginClass
		{
			get
			{
				if (_pluginClass == null)
				{
					_pluginClass = new AndroidJavaClass(pluginName);
				}
				return _pluginClass;
			}
		}

		public static AndroidJavaObject PluginInstance
		{
			get
			{
				if (_pluginInstance == null)
				{
					_pluginInstance = PluginClass.GetStatic<AndroidJavaObject>("INSTANCE");
				}
				return _pluginInstance;
			}
		}

		public static AndroidJavaObject getContext()
		{
			AndroidJavaClass playerClass = new AndroidJavaClass("com.unity3d.player.UnityPlayer");
			return playerClass.GetStatic<AndroidJavaObject>("currentActivity");
		}

		public static void initialize(string appKey)
		{
			PluginClass.CallStatic("initialize", new object[2] { getContext(), appKey });
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

        public static void setServer(Environment environment)
        {
			AndroidJavaClass enumClass = new AndroidJavaClass("co.adison.offerwall.Server");
			if (environment == Environment.Development)
			{
				PluginClass.CallStatic("setServer", new object[1] { enumClass.GetStatic<AndroidJavaObject>("Development") });
			}
			else if (environment == Environment.Staging)
			{
				PluginClass.CallStatic("setServer", new object[1] { enumClass.GetStatic<AndroidJavaObject>("Staging") });
			}
			else if (environment == Environment.Production)
			{
				PluginClass.CallStatic("setServer", new object[1] { enumClass.GetStatic<AndroidJavaObject>("Production") });
			}
		}

        public static void setBirthYear(int birthYear)
        {
			//AndroidJavaObject integer = null;
			//if (self.HasValue)
			//{
			//	using (var integerClass = new AndroidJavaClass("java.lang.Integer"))
			//	{
			//		integer = integerClass.CallStatic<AndroidJavaObject>("valueOf", self);
			//	}
				PluginClass.CallStatic("setBirthYear", birthYear);
        }

        public static void setGender(Gender gender)
        {
			AndroidJavaClass enumClass = new AndroidJavaClass("co.adison.offerwall.Gender");
			if (gender == Gender.UNKNOWN)
			{
				PluginClass.CallStatic("setGender", new object[1] { enumClass.GetStatic<AndroidJavaObject>("UNKNOWN") });
			}
			else if (gender == Gender.MALE)
			{
				PluginClass.CallStatic("setGender", new object[1] { enumClass.GetStatic<AndroidJavaObject>("MALE") });
			}
			else if (gender == Gender.FEMALE)
			{
				PluginClass.CallStatic("setGender", new object[1] { enumClass.GetStatic<AndroidJavaObject>("FEMALE") });
			}
		}

        public static void showOfferwall()
		{
			PluginClass.CallStatic("showOfferwall");
		}

		public static string getSdkVersion()
		{
			if (Application.platform == RuntimePlatform.Android)
			{
				return PluginInstance.Call<string>("getSdkVersion");
			}
			return "unknown";
		}
       

#endif
	}


	public enum Environment
	{
		Development, Staging, Production
	}

	public enum Gender
	{
		UNKNOWN, MALE, FEMALE
	}
}