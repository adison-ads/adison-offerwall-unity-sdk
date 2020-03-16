using System;
using UnityEngine;

using AdisonOfferwall;
using AdisonOfferwall.Api;

namespace AdisonOfferwall
{
#if UNITY_IOS
	public class Adison
#elif UNITY_ANDROID
	public class Adison : AdisonOfferwall.Android.OfferwallClient
#endif
	{
	}
}
