using System;

namespace AdisonOfferwall.Api
{
    public class LoginRequestedEventArgs : EventArgs
    {
        public string Message { get; set; }
    }
}
