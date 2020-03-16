using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AdisonOfferwall.Api;

namespace AdisonOfferwall.iOS
{
#if UNITY_IOS
	public class OfferwallClient
	{
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
		private static extern void __setConfig(IntPtr config);

		[DllImport("__Internal")]
		private static extern void __setColorScheme(IntPtr colorScheme);

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

		public static void setServer(Api.Environment env)
		{
			if (env == Api.Environment.Development)
			{
				__setServer(0);
			}
			else if (env == Api.Environment.Staging)
			{
				__setServer(1);
			}
			else if (env == Api.Environment.Production)
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
			if (gender == Gender.Unknown)
			{
				__setGender(0);
			}
			else if (gender == Gender.Male)
			{
				__setGender(1);
			}
			else if (gender == Gender.Female)
			{
				__setGender(2);
			}
		}

		public static void setConfig(OfferwallConfig config)
        {
            __setConfig(config.nativeObject);
        }

		public static void setColorScheme(AdisonOfwColorScheme colorScheme)
		{
			__setColorScheme(colorScheme.nativeObject);
		}

		public static void showOfferwall()
		{
			__showOfferwall();
		}

		public static string getSdkVersion()
		{

			return "unknown";
		}

	}
#endif
}