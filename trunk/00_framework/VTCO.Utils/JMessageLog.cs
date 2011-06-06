using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VTCO.Utils
{    
    /// <summary>
    /// Summary description for JMessageLog
    /// </summary>
        public class JMessageLog
        {
            public string Header { get; set; }

            public string Description { get; set; }

            public string Footer { get; set; }

            public string AccountNameSource { get; set; }

            public string AccountNameDest { get; set; }

            public string UrlDetail { get; set; }

            public string Thumbnail { get; set; }
        }
        public enum PrivacyType
        {
            All = 1,
            FriendOfFriend = 3,
            Friend = 5,
            OnlyMe = 7
        }    
}
