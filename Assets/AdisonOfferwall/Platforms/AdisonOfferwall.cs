using System;
using UnityEngine;

using AdisonOfferwall;
using AdisonOfferwall.Api;
using AdisonOfferwall.Common;

namespace AdisonOfferwall
{
#if UNITY_ANDROID
	public class Adison : Android.AdisonOfferwallPlugin
#elif UNITY_IOS
	public class Adison : iOS.AdisonOfferwallPlugin
#endif
	{
	}
}
