using System;
using System.Runtime.InteropServices;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AdisonOfferwall.Api;
using AdisonOfferwall.Common;
using AOT;

namespace AdisonOfferwall.iOS
{
#if UNITY_IOS
	public class AdisonOfferwallPlugin
	{
		[DllImport("__Internal")]
		private static extern void __initialize(string appKey);

		[DllImport("__Internal")]
		private static extern void __setDebugEnabled(bool enable);

		[DllImport("__Internal")]
		private static extern void __setUid(string uid);

		[DllImport("__Internal")]
		private static extern string __getUid();

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

		[DllImport("__Internal")]
		private static extern void __setLifeCycleCallbacks(
                OfferwallOpenCallback offerwallOpenCallback,
			    OfferwallClosedCallback offerwallClosedCallback
			);

		public static OnLifeCycleListener LifeCycleListener;


		public static void Initialize(string appKey)
		{
			__initialize(appKey);

			LifeCycleListener = new OnLifeCycleListener();
			__setLifeCycleCallbacks(OfferwallOpen, OfferwallClosed);
		}

		public static void SetDebugEnabled(bool enable)
		{
			__setDebugEnabled(enable);
		}

		public static void SetUid(string uid)
		{
			__setUid(uid);
		}

		public static string GetUid()
		{
			return __getUid();
		}

		public static void SetIsTester(bool enable)
		{
			__setIsTester(enable);
		}

		public static void SetEnvironment(Api.Environment env)
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

		public static void SetBirthYear(int birthYear)
		{
			__setBirthYear(birthYear);
		}

		public static void SetGender(Gender gender)
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

		public static void SetConfig(AdisonConfig config)
        {
            __setConfig(config.nativeObject);
        }

		public static void SetColorScheme(AdisonColorScheme colorScheme)
		{
			__setColorScheme(colorScheme.nativeObject);
		}

		public static void ShowOfferwall()
		{
			__showOfferwall();
		}

		public static string GetSdkVersion()
		{

			return "unknown";
		}

		delegate void OfferwallOpenCallback();
		[MonoPInvokeCallback(typeof(OfferwallOpenCallback))]
		private static void OfferwallOpen()
		{
            LifeCycleListener.offerwallOpen();
        }

		delegate void OfferwallClosedCallback();
        [MonoPInvokeCallback(typeof(OfferwallClosedCallback))]
		private static void OfferwallClosed()
		{
            LifeCycleListener.offerwallClosed();
        }

		public class OnLifeCycleListener
		{
            public event EventHandler<EventArgs> OnOfferwallOpen;
            public event EventHandler<EventArgs> OnOfferwallClosed;

			public void offerwallOpen()
            {
				OnOfferwallOpen?.Invoke(this, EventArgs.Empty);
            }

			public void offerwallClosed()
            {
				OnOfferwallClosed?.Invoke(this, EventArgs.Empty);
            }
        }

	}
#endif
}