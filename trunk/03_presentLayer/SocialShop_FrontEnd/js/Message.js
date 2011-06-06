/*
    Định nghĩa các thông báo trong hệ thống
*/
MESSAGE = new function () {
    // Các thông báo dùng chung
    this.noUserBuying = "Chưa có ai mua sản phẩm này!";
    this.userBuying = "Những người cùng mua sản phẩm này";
    this.existCart = "Sản phẩm đã có trong giỏ hàng";
    this.addCarted = "Đã thêm vào giỏ hàng";
    this.existFavorite = "Sản phẩm đã có trong danh sách yêu thích của bạn";
    this.likeProduct = "Đã thích sản phẩm";
    this.notLogin = "Bạn chưa đăng nhập!";
    this.notLoginComment = "Bạn cần đăng nhập để viết bình luận";
    this.notShopOwner = "Bạn không phải là chủ shop này!";
    this.shopOwner = "Bạn là chủ shop này!";
    this.title = "Thông báo";
    this.loadingText = "Đang xử lý...";
    this.error = "Có lỗi xảy ra!";
    this.lock = "Khóa";
    this.unlock = "Kích hoạt";
    this.existProduct = "Còn hàng";
    this.noexistProduct = 'Hết hàng';
    this.hasVAT = 'Có VAT';
    this.nohasVAT = 'Không VAT';
    this.hot = 'Hot';
    this.nohot = 'Không Hot';
    this.datetimenull = "Bạn chưa nhập ngày tháng";
    this.all = 'Tất cả';
    this.updateSuccess = 'Cập nhật dữ liệu thành công!';
    this.addSuccess = 'Thêm mới thành công!';
    this.deleteSuccess = 'Đã xóa!'
    this.errorFormatDate = "Ngày tháng phải có định dạng kiểu dd/MM/yyyy";
    this.errorNumber = "Dữ liệu nhập vào không đúng định dạng số!";
    this.timeEmpty = 'Thời gian không được rỗng!';
    this.errorCheck = 'Bạn phải chọn ít nhất một mục!';
    this.erroDateTime = 'Thời gian kết thúc phải lớn hơn thời gian bắt đầu';
    this.errorDateCompare = 'Thời gian kết thúc phải lớn hơn thời gian bắt đầu';
    this.errorStringSearch = 'Từ khóa tìm kiếm không được rỗng'
    this.selectCategory = '[Chọn chuyên mục]';
    this.selectProvince = 'Chọn Tỉnh';
    this.selectDistrict = 'Chọn Huyện';
    this.selectVillage = 'Chọn Xã';
    this.confirmDelete = 'Bạn có chắc chắn xóa không?';
    this.addNew = 'Thêm mới';
    this.update = 'Cập nhật thông tin';
    this.errorEmail = 'Địa chỉ Email không chính xác!';
    this.existEmail = 'Địa chỉ Email này đã tồn tại!';
    this.QAdataNull = "Không có câu hỏi nào!";
    this.errorDeleteTheme = "Theme đang được dùng hoặc Theme không thuộc Shop, bạn không thể xóa!";
    this.addThemeShopSuccess = "Mua Theme thành công!";
    this.status_chuakiemduyet = "Chưa kiểm duyệt";
    this.status_active = "Hiển thị";
    this.status_lock = "Khóa";
    // Các thông báo dùng trong file PMShop.js
    this.PMShop = new function () {
        this.subjectEmpty = "Tiêu đề không được rỗng!";
        this.bodyEmpty = "Nội dung không được rỗng!";
        this.subjectMaxLength = "Tiêu đề vượt quá 100 ký tự!";
        this.bodyMaxLength = "Nội dung vượt quá 1000 ký tự!";
        this.sendSuccess = 'Gửi tin nhắn thành công';
    }

    // Các thông báo dùng trong file ShopLogo.js
    this.userControl_ucShopLogo = new function () {
        this.penddingCertificate = "Shop chờ chứng thực";
        this.certificate = "Shop này đã được chứng thực!";
        this.requestCertificated = "Shop này đã được yêu cầu chứng thực!";
        this.fanShop = "Bạn đã là thành viên FanShop";
        this.requestCertificate = 'Yêu cầu chứng thực';
    }

    // Các thông báo dùng trong file CreateShop.js
    this.popup_CreateShopPopup = new function () {
        this.title = 'Tạo cửa hàng';
        this.createShop = "Tạo Shop";
        this.next = "Tiếp tục";
        this.back = "Quay lại";
        this.close = "Đóng";
        this.createShopSuccess = "Chúc mừng bạn đã tạo Shop thành công!";
        this.checkShopName_ok = "Bạn có thể dùng tên Shop này!";
        this.checkShopName_not_ok = "Tên Shop đã tồn tại!";
        this.province_not_select = "Bạn chưa chọn tỉnh!";
        this.checkMail_not_ok = "Địa chỉ mail đã được dùng!";
        this.emailShopError = "Địa chỉ email không đúng!";
        this.nameShopError = "Tên Shop chứa các kí tự không hợp lệ!";
        this.nameShopLengthError = "Tên Shop phải dài hơn 2 kí tự";
        this.nameShopEmptyError = "Tên Shop không được rỗng!";
        this.checkUser_not_ok = "Bạn đã là chủ của một Shop trên SS!\n Một tài khoản chỉ được phép tạo một Shop";
        this.checkInfo_not_ok = "Cần nhập đầy đủ các thông tin bắt buộc!";
        this.policy_not_accept = "Bạn cần đồng ý với các điều khoản của SS để được tạo Shop!";
    }

    this.payment = new function () {
        this.notEnoughtGo = 'Số Go trong tài khoản của bạn không đủ để thực hiện dịch vụ này';
        this.paymentError = 'Thanh toán thất bại';
        this.paymentNotExistAccount = 'Không tồn tại tài khoản thanh toán';
        this.paymentNotExistService = 'Không tồn tại dịch vụ';
        this.paymentErrorTime = 'Các giao dịch cách nhau 30s';
    }

    // Các thông báo dùng trong file handlersUploadLogo.js
    this.UploadLogo = new function () {
        this.notExts = "File upload không thuộc định dạng file nhạc cho phép. Bạn vui lòng chọn file khác";
        this.notPlayer = "Bạn cần Flash Player để sử dụng chức năng upload";
        this.loadFailed = "Đã xảy ra lỗi trong quá trình tải trang, mời bạn thử lại";
        this.sizeLimit = "Kích thước file quá lớn. Bạn vui lòng chọn file có kích thước dưới 2MB";
        this.queueError = "Lỗi xảy ra trong quá trình upload. Xin bạn vui lòng upload lại";
        this.uploadLimitExceeded = "Lỗi: UPLOAD_LIMIT_EXCEEDED";
        this.httpError = "Lỗi: HTTP_ERROR";
        this.missingUploadUrl = "Lỗi: MISSING_UPLOAD_URL";
        this.ioError = "Lỗi: IO_ERROR";
        this.securityError = "Lỗi: SECURITY_ERROR";
        this.uploadFailed = "Lỗi: UPLOAD_FAILED";
        this.error = "Lỗi: ";
    }

    //Các thông báo dùng trong file ListProduct.js
    this.ListProduct = new function () {
        this.addFavoriteSuccess = "Bạn đã thích sản phẩm này!";
        this.addFavoriteExist = "Sản phẩm này đã nằm trong danh sách sản phẩm yêu thích của bạn!";
        this.addCartSuccess = "Đã thêm vào giỏ hàng!";
        this.addCartExist = "Sản phẩm này đã nằm trong giỏ hàng của bạn!";
    }

    // Các thông báo dùng trong file ProductDetail.js
    this.ProductDetail = new function () {
        this.noNumber = "Số lượng không phải là số!";
        this.shopNotContract = 'Sản phẩm thuộc Shop chưa ký hợp đồng, bạn không thể thêm vào giỏ hàng';
    }

    this.Cart = new function () {
        this.confirmDelete = "Bạn có chắc chắn xóa sản phẩm này ra khỏi giỏ hàng ko?";
        this.noExistProduct = "Sản phẩm này không có trong giỏ hàng của bạn!";
        this.noSelectProvince = 'Bạn chưa chọn tỉnh';
        this.noSelectDistrict = 'Bạn chưa chọn huyện';
        this.noSelectVillage = 'Bạn chưa chọn xã';
        this.ReceiveNameEmpty = 'Tên người nhận không được rỗng';
        this.ReceiveMobileEmpty = 'Số điện thoại người nhận không được rỗng';
        this.ReceiveCardNoEmpty = 'Số CMTND người nhận không được rỗng';
        this.ReceiveAddressEmpty = 'Địa chỉ người nhận không được rỗng';
        this.noSelectTerm = 'Bạn chưa đồng ý điều khoản mua hàng';
        this.noSelectShippingMethod = 'Bạn chưa chọn phương thức vận chuyển';
        this.orderSuccess = 'Thanh toán thành công';
        this.noProduct = 'Không có mặt hàng nào trong giỏ';
        this.noExistVillage = 'Không tồn tại villageLocation';
        this.shippingMethodError = 'Lỗi xâu ShippingMethod';
        this.noExistShippingMethod = 'Không tồn tại phương thức vận chuyển';
        this.noEnoughtGo = 'Không đủ tiền thanh toán';
        this.noExistUser = 'Không tồn tại tài khoản này';
        this.noExistService = 'Không tồn tại mã dịch vụ';
        this.orderError = 'Lỗi order hàng';
        this.confirmOrder = 'Bạn có chắc chắn mua những mặt hàng này không?';
        this.quantityError = 'Số lượng sản phẩm phải lớn hơn 0';
    }

    // Các thông báo trong thư mục js/pages
    this.pages = new function () {
        // Các thông báo trong thư mực js/pages/shop
        this.Shop = new function () {
            // Các thông báo trong file Category.js
            this.Category = new function () {
                this.confirmDelete = "Bạn có chắc chắn xóa chuyên mục này không?";
                this.category = "Chuyên mục";
                this.existProduct = "Đã tồn tại sản phẩm, bạn chỉ có thể khóa chuyên mục này!";
                this.add = "Thêm";
                this.del = "Xóa";
                this.existCategory = "Chuyên mục này đã tồn tại";
            };

            this.Promotion = new function () {
                this.confirmDelete = "Bạn có chắc chắn xóa chương trình khuyến mãi này không?";
                this.promotionCodeEmpty = "Mã chương trình khuyến mãi không được trống!";
                this.promotionMaxLength = "Mã chương trình khuyến mãi không vượt quá 20 ký tự!";
                this.promotionPercentEmpty = "Phần trăm khuyến mãi không được trống!";
                this.promotionPercentNotReal = "Phần trăm khuyến mãi không phải là số thực lớn hơn hoặc bằng 0 và bé hơn hoặc bằng 100!";
                this.startDateEmpty = "Thời gian bắt đầu khuyến mãi không được trống!";
                this.endDateEmpty = "Thời gian kết thúc khuyến mãi không được trống!";

                this.errorDateCompare = "Thời gian kết thúc khuyến mãi phải lớn hơn thời gian băt đầu khuyến mãi"
                this.titleEmpty = 'Tiêu đề khuyến mãi không được trống!';
                this.titleMaxLength = 'Tiêu đề chương trình khuyến mãi không vượt quá 100 ký tự!';
                this.contentEmpty = 'Nội dung khuyến mãi không được trống!';
                this.existPromotionCode = 'Mã chương trình khuyến mãi đã tồn tại!';

                this.noProduct = 'Không có sản phẩm nào thuộc chương trình khuyến mãi này';

            };
            this.Product = new function () {
                this.noImage = 'Không có ảnh nào thuộc sản phẩm này';
                this.noSelectCategory = 'Bạn chưa chọn chuyên mục';
                this.productCodeEmpty = 'Mã sản phẩm không được rỗng';
                this.productCodeMaxLength = 'Mã sản phẩm không được lớn hơn 20 ký tự';
                this.productCodeExist = 'Mã sản phẩm đã tồn tại';
                this.productNameEmpty = 'Tên sản phẩm không được rỗng';
                this.productNameMaxLength = 'Tên sản phẩm không được lớn hơn 100 ký tự';
                this.weightEmpty = 'Khối lượng sản phẩm không được rỗng';
                this.weightNotReal = 'Khối lượng sản phẩm phải là số thực';
                this.amountEmpty = 'Số lượng sản phẩm không được rỗng';
                this.amountNotInteger = 'Số lượng sản phẩm phải là số nguyên lớn hơn 0';
                this.priceEmpty = 'Giá sản phẩm không được rỗng';
                this.priceNotInteger = 'Giá sản phẩm phải là số nguyên lớn hơn 0';
                this.descriptionEmpty = 'Mô tả sản phẩm không được rỗng';
                this.imageEmpty = 'Bạn chưa chọn ảnh cho sản phẩm';
                this.promotionCodeNotExist = 'Mã CTKM không tồn tại';
                this.notEnoughtGo = 'Số Go trong tài khoản của bạn không đủ để thực hiện dịch vụ này';
                this.insertError = 'Thêm mới sản phẩm thất bại';
                this.updateError = 'Cập nhật sản phẩm thất bại';
                this.upNewError = 'Đưa sản phẩm lên vị trí sản phẩm mới nhất thất bại';
                this.upHotError = 'Đưa sản phẩm lên vị trí sản phẩm hot nhất thất bại';
                this.imageMaxLength = 'Mỗi sản phẩm chỉ có tối đa 5 ảnh, bạn phải xóa ảnh cũ đi trước khi thêm ảnh mới vào';
                this.noExistImage = 'Không tồn tại ảnh';
                this.confirmDeleteProduct = 'Bạn có chắc chắn muốn xóa sản phẩm này không?';
                this.confirmUploadSuccess = 'Upload ảnh thành công, bạn có muốn upload ảnh khác không?';
                this.imageNameEmpty = 'Tên ảnh không được rỗng';
                this.existBuyingGroup = 'Sản phẩm đang có người tham gia mua hàng theo nhóm';
                this.upNewSuccess = 'Đưa sản phẩm lên vị trí sản phẩm mới nhất thành công';
                this.upHotSuccess = 'Đưa sản phẩm lên vị trí sản phẩm hot nhất thành công';
            };
            this.ImageCollection = new function () {
                this.confirmDelete = 'Bạn có chắc chắn xóa ảnh này không?';
                this.existProduct = 'Đang có sản phẩm sử dụng ảnh';
                this.noExistImage = 'Không tồn tại ảnh này';
            };

            this.ShopFan = new function () {
                this.errorCheckShopFan = 'Phải chọn ít nhất một mục!';
            };

            this.ShopInfoEdit = new function () {
                this.ShopValidateError = "Chưa nhập đủ thông tin";
                this.ShopUpdateUnSuccess = "Dữ liệu không đúng!";
                this.ShopUpdateSuccess = "Cập nhật dữ liệu thành công";
                this.ShopUpdateError = "Cập nhật thất bại, hãy cập nhật lại!";
                this.RequestCertificate = "Yêu cầu chứng thực";
                this.CancelCertificate = "Hủy yêu cầu chứng thực";
                this.CancelCertificateMsg = "Shop chưa được yêu cầu chứng thực";
                this.ShopLogoNotCertificate = "Yêu cầu chứng thực";
                this.ShopLogoPeddingCertificate = "Shop chờ chứng thực";

            };

            this.Message = new function () {
                this.recipientsEmpty = 'Người nhận không được rỗng';
                this.subjectEmpty = 'Tiêu đề không được rỗng';
                this.subjectMaxLength = 'Tiêu đề không được vượt quá 100 ký tự';
                this.bodyEmpty = 'Nội dung không được rỗng';
                this.bodyMaxLength = 'Nội dung không được vượt quá 1000 ký tự';
                this.sendSuccess = 'Gửi tin nhắn thành công';
                this.confirmDelete = 'Bạn có chắc chắn xóa tin nhắn này không';
                this.paygateSend = "Người gửi";
                this.paygateReceive = "Người nhận";
            };

            this.FanShop = new function () {
                this.confirmDeleteShopFan = 'Bạn có chắc chắn loại thành viên này ra khỏi danh sách Fan không?';
                this.confirmRejectFan = 'Bạn có chắc chắn từ chối thành viên này gia nhập FanShop không?';
            };

        };

        // Các thông báo trong thư mục js/pages/user
        this.user = new function () {
            this.productFavo = new function () {
                this.errorCheckProduct = "Bạn phải chọn ít nhất một sản phẩm!";
                this.infoRemoveProductFavo = "Bỏ chọn sản phẩm yêu thích thành công";
            };
        };
    };

    //Các thông báo BuyingGroup

    this.buyingGroup = new function () {
        this.noNumber = "Số lượng không phải là số nguyên lớn hơn 0!";
        this.insertPricePointSuccess = "Thêm điểm giá thành công!";
        this.deletePricePoint = "Xóa điểm giá thành công!";
        this.notIsInterger = "Dữ liệu nhập không đúng định dạng số!";
        this.priceIsnotInteger = "Giá sản phẩm phải là số nguyên lớn hơn 0!";
        this.peopleIsNotInteger = "Số sản phẩm phải là số nguyên lớn hơn 0!";
        this.ProductCodeIsEmpty = "Bạn chưa chọn sản phẩm!";
        this.confirmDeletePricePoint = "Bạn chắc chắn xóa điểm giá này!";
        this.notAddPricePoint = "Bạn chưa nhập điểm giá nào!";
        this.addBuyingGroupSuccess = "Thêm nhóm mua hàng thành công!";
        this.hasUserJoin = "Đang có người tham gia nhóm mua hàng này!";
        this.deleteBuyingGroupSuccess = "Xóa nhóm mua hàng thành công!";
        this.removeBuyingGroupSuccess = "Rời bỏ nhóm mua hàng thành công!";
        this.confirmDeleteBuyingGroup = "Bạn chắc chắn xóa nhóm mua hàng này!";
        this.updateBuyingGroupSucess = "Cập nhật dữ liệu thành công!";
        this.confirmLeaveBuyingGroup = "Bạn chắc chắn rời bỏ nhóm mua hàng này";
        this.policy_not_accept = "Bạn chưa đồng ý với điều khoản mua hàng theo nhóm!";
        this.isEmpty = "Bạn chưa nhập số sản phẩm!";
        this.isNotNumber = "Số sản phẩm phải là số!";
        this.isNotNumberProduct = "Số sản phẩm phải lớn hơn 0!";
        this.notEnoughGO = "Số tiền trong tài khoản không đủ để thanh toán!";
        this.errorPayment = "Lỗi khi thanh toán tham gia mua hàng theo nhóm!";
        this.successPayment_1 = "Bạn đã sử dụng <b>";
        this.successPayment_2 = " GO</b> vào dịch vụ của VTC Social Shopping. Mã giao dịch của bạn là <b>";
        this.isJoinBuyingGroup = "Bạn đã tham gia mua hàng theo nhóm mặt hàng này rồi!";
        this.isBigNumber = "Số lượng sản phẩm tham gia<br>vượt quá số lượng tối đa cho phép!";
        this.limitPricePoint = "Bạn chỉ được thêm tối đa 5 điểm giá!";
        this.minPricePoint = "Nhóm mua hàng phải có ít nhất 2 điểm giá!";
        this.existProductBuyingGroup = "Sản phẩm đang tồn tại mua hàng theo nhóm!";
        this.notProductByShop = "Sản phẩm này không thuộc Shop!";
        this.errorPricePoint = "Số sản phẩm và mức giá phải là số nguyên lớn hơn 0!";
        this.errorPoint = "Điểm giá không được rỗng!";
        this.confirmPayment = "Bạn có chắc chắn tham gia mua hàng theo nhóm không?";
        this.errorPeople = "Số người bắt đầu phải là 1!";
        this.errorAddPeople = "Bạn đã thêm số sản phẩm này rồi!";
        this.errorAddPrice = "Bạn đã thêm mức giá này rồi!";
        this.errorComparePeople = "Số sản phẩm phải lớn hơn số sản phẩm trước đó!";
        this.errorComparePrice = "Mức giá tiếp theo phải nhỏ hơn mức giá trước đó!";
        this.existPricePoint = "Đã tồn tại điểm giá này rồi!";
        this.notExistUserBuyingGroup = "Hiện chưa có sản phẩm tham gia";
        this.endPriceBuyingGroup = "Nhóm mua hàng đã đạt mức giá cuối cùng";
        this.notExistProductCode = "Mã sản phẩm không tồn tại";
        this.textBuyingGroupNotStart = "Chưa diễn ra";
        this.textBuyingGroupIsRun = "Đang diễn ra";
        this.textBuyingGroupEnd = "Đã kết thúc";
        this.textCurrentProduct = "Hiện có";
        this.textPrice = "Mức giá";
        this.textProduct = "Sản phẩm";
        this.textPeople = "Số sản phẩm";
        this.textDelete = "Xóa";
        this.textVND = "VNĐ";
        this.emptyDescription = "Mô tả nhóm mua hàng không được rỗng!";
        this.notMoney = "Tiền đặt cọc phải là số nguyên lớn hơn 0!";
        this.emptyMoney = "Tiền đặt cọc không được rỗng!";
        this.notSuccessful = "Thêm nhóm mua hàng không thành công, kiểm tra lại thông tin trước khi cập nhật!";
        this.updateStatusSuccess = "Cập nhật trạng thái vận chuyển thành công!";
        this.updateStatusError = "Cập nhật trạng thái vận chuyển không thành công!";
        this.buyingGroupEnd = "Đã kết thúc";
        this.bigProductNumber = "Số lượng sản phẩm không vượt được quá 10000 !";
        this.bigPrice = "Số tiền không được vượt quá 1.000.000.000 VNĐ !";
        this.errorDeletePricepoint = "Bạn không thể xóa điểm giá này, bắt đầu phải là 1";
        this.priceFrom = "Mức giá này phải thuộc khoảng&nbsp;";
        this.priceTo = "&nbsp;và&nbsp;";
        this.errorLimitProduct = "Bạn chưa chọn giới hạn số lượng sản phẩm!";
        this.onlyNumber = "Chỉ nhập số !";
        this.errorNumber = "Dữ liệu nhập phải là số nguyên lớn hơn 0 !";
        this.errorMaxProduct = "Số sản phẩm tối đa phải lớn hơn hoặc bằng&nbsp;"
        this.PriceFomular = "Phí đặt cọc tính theo công thức là&nbsp;";
        this.LimitAddPricepoint = "Bạn phải thêm ít nhất 2 điểm giá !";
        this.existJoinBuyingGroup = "Bạn đã tham gia nhóm mua hàng này, bạn có muốn thực hiện giao dịch khác !";
        this.notSuccessfulUpdate = "Cập nhật dữ liệu không thành công, kiểm tra lại thông tin trước khi cập nhật!";
        this.transactionSuccess = "Bạn đã tham gia mua hàng theo nhóm thành công!";
        this.transactionError = "Bạn đã tham gia mua hàng theo nhóm không thành công!";
        this.transactionPSuccess = "Bạn đã thanh toán mua hàng theo nhóm thành công!";
        this.transactionPError = "Bạn đã thanh toán mua hàng theo nhóm không thành công!";
        this.notMoneyCreateBuyingGroup = "Bạn không đủ tiền để tạo nhóm mua hàng !";
        this.endBuyingGroup = "Nhóm mua hàng đã kết thúc !";
        this.currentPrice = "Mức giá hiện tại";
        this.notGiftOwner = "Bạn không thể tự tặng quà cho mình !";
        this.notExistUserInSystem = "Người nhận quà không tồn tại trong hệ thống !";
        this.notEmptyReceiver = "Tên người nhận không được rỗng !";
    }

    this.buyingGroupPayment = new function () {
        this.PaymentError = 'Lỗi thanh toán mua hàng theo nhóm!';
        this.confirmPayment = 'Bạn có chắc chắn thanh toán mặt hàng này không?';
    };
    // Các thông báo trong các trang popup
    this.popup = new function () {
        // Các thông báo trong file SearchProduct.js    
        this.searchProduct = new function () {
            this.stt = 'STT';
            this.productCode = 'Mã sản phẩm';
            this.productName = 'Tên sản phẩm';
            this.price = 'Giá sản phẩm';
            this.weight = 'Khối lượng';
            this.del = 'Xóa';
        };
        this.bookPosition = new function () {
            this.selectPosition = 'Bạn chưa chọn vị trí';
            this.errorFromDate = 'Thời gian bắt đầu phải lớn hơn thời gian hiện tại';
            this.bookPositionSuccess = 'Đặt chỗ cho sản phẩm thành công';
            this.productBooked = 'Sản phẩm đã đặt chỗ trong khoảng thời gian này';
            this.positionBooked = 'Chỗ này đã có sản phẩm khác đặt';
            this.bookPositionError = 'Lỗi đặt chỗ';
        };
    }

    //Các thông báo trang Feedbackh
    this.feedback = new function () {
        this.confirmDelete = 'Bạn chắc chắn xóa phản hồi này!';
        this.contentFeedbackEmpty = 'Nội dung bình luận không được rỗng!';
        this.addCommentSucess = 'Thêm bình luận thành công!';
        this.overloadComment = 'Nội dung bình luận không được quá 200 ký tự';
        this.warningFeedbackSuccess = 'Bạn đã báo xấu nội dung này';
        this.notFeedback = "Không có bình luận nào cho sản phẩm này!";
    };
    //Các thông báo trang UserInfo
    this.userInfo = new function () {
        this.nameIsEmpty = 'Họ tên không được rỗng';
        this.birthDayIsEmpty = 'Ngày sinh không được rỗng';
        this.mobileIsEmpty = 'Số điện thoại không được rỗng';
        this.addressIsEmpty = 'Địa chỉ không được rỗng';
        this.emailIsEmpty = 'Địa chỉ Email không được rỗng';
        this.cardNoIsEmpty = 'Số chứng minh thư không được rỗng';
        this.errorCardNo = 'Số CMND không nhập đúng định dạng số';
        this.noIsMobile = 'Số điện thoại nhập không đúng định dạng số';
        this.ErrorbirthDay = 'Ngày tháng không đúng định dạng dd/MM/YYYY';
        this.errorEmail = 'Địa chỉ Email không đúng định dạng';
    };

    //Các thông báo dùng trong trang pages/shop/goPayment.js
    this.goPayment = new function () {
        this.errorEmpty = "Bạn chưa nhập số đồng tiền GO cần nạp";
        this.errorNumber = "Đồng tiền GO cần nạp phải là số";
        this.veryBigNumber = "Số tiền GO nạp không được quá 1.000.000";
        this.errorTransaction = "Giao dịch thất bại";
        this.success = "Thanh toán thành công";
        this.notEnoughVcoin = "Số dư hiện tại của bạn hiện không đủ để thực hiện thanh toán";
        this.transactionEnded = "Giao dịch này đã kết thúc xử lý, quý khách không thể kích hoạt lại";
        this.transactionCancel = "Quý khách đã hủy giao dịch, quý khách có thể tiếp tục mua hàng";
        this.transactionNotRegular = "Giao dịch không hợp lệ";
        this.transactionError = "Có lỗi xảy ra trong quá trình giao dịch";
    }

    this.userControl = new function () {
        this.AdvancedSearch = new function () {
            this.nationwide = 'Toàn quốc';
            this.priceFail = 'Nhập sai khoảng giá';
        };
    };

    this.location = new function () {
        this.locationAdd = "Thêm mới địa điêm shop thành công!";
        this.locationUpdate = "Cập nhật địa điểm shop thành công!";
        this.locationAddError = "Thêm mới địa điểm shop không thành công!";
        this.locationUpdateError = "Cập nhật địa điểm shop không thành công!";
        this.locationBuyingGroupAddError = "Thêm mới địa điểm BuyingGroup không thành công!";
        this.locationBuyingGroupUpdateError = "Cập nhật địa điểm BuyingGroup không thành công!";
    };
}