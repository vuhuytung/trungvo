//
// Author: trung.pham
// Creare Date: 2010-06-30
// Description: Các Enums trong Activity
//

namespace VTCO.Config.Enums
{
    /// <summary>
    /// Enum quy định ai được phép xem Activity
    /// </summary>
    public enum ActivityPrivacyTypeEnum : int
    {
        All = 1,
        FriendOfFriend = 3,
        Friend = 5,
        OnlyMe = 7,
        NotPublishOnWall = 0
    }
}
