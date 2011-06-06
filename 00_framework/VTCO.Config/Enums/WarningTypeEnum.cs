//
// Author: trung.pham
// Creare Date: 2010-06-30
// Description: Enum trong warning
//

namespace VTCO.Config.Enums
{
    /// <summary>
    /// Loại đối tượng trong phần cảnh báo
    /// </summary>
    public enum WarningTypeEnum : int
    {
        QuestionQA = 1,      // Câu hỏi hỏi đáp
        CommentQA = 2,       // Comment hỏi đáp
        CommentProduct = 3,  // Comment sản phẩm
        BadShop = 4,         // Báo shop xấu
        BadProductShow = 5,  // Show hàng xấu
        BadWantAds = 6,      // Rao vặt xấu
        CommentBuyingGroup = 7 // Comment Buying Group
    }
}
