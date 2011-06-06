/*
    Định nghĩa các hằng số trong hệ thống
*/
CONSTANT = new function () {
    this.TAG_IMAGE_LOADING = '<img alt="Loading..." src="/images/loading_bar.gif" />';
    this.PAGE_SIZE_NEW_PRODUCT = 10;
    this.PAGE_SIZE_LIST_PRODUCT = 24;
    this.PAGE_DISPLAY = 7;
    this.PAGE_DISPLAY_FEEDBACK_SHOP = 5;
    this.PAGE_SIZE_FAVORITE_PRODUCT = 6;
    this.PAGE_SIZE_FEEDBACK = 6;
    this.PAGE_SIZE_FEEDBACK_SHOP = 10;
    this.PAGE_SIZE_USER_SHOP_FAN_CLUB = 12;
    this.PAGE_SIZE_SHOP_FAN_LIST = 12;
    this.PAGE_SIZE_FAN_SHOP_LIST = 12;
    this.PAGE_SIZE_SHOP_FAN_CLUB = 18;
    this.PAGE_SIZE_SHOP_LIST = 10;
    this.PAGE_SIZE_ADVANCED_SEARCH_SHOP = 10;
    this.PAGE_SIZE_ADVANCED_SEARCH = 10;
    this.PAGE_SIZE_MY_PRODUCT = 12;
    this.PAGE_SIZE_MESSAGE_INBOX = 18;
    this.PAGE_SIZE_MESSAGE_SEND = 18;
    this.PAGE_SIZE_SHOW_PRODUCT = 5;
    this.PAGE_SIZE_ORTHER_PRODUCT = 4;
    this.PAGE_SIZE_SAME_PRODUCT = 6;
    this.PAGE_SIZE_CERTIFICATE_SHOP = 10;
    this.PAGE_SIZE_SHOP_FAN_SHOP_DIRECT = 7;
    this.PAGE_SIZE_SHOP_WANT_ADS = 5; //Tin rao vặt
    this.PAGE_SIZE_PRODUCT_NEW_BUYING = 5;
    this.PAGE_SIZE_USER_BUYINGGROUP = 8;
    this.PAGE_SIZE_USER_SHOP_BUYINGGROUP = 6;
    this.PAGE_SIZE_LIST_BUYINGGROUP = 12;
    this.PAGE_SIZE_LIST_BUYINGGROUP_SHOP = 10;
    this.PAGE_DISPLAY_BUYINGGROUP = 10;
    this.PAGE_DISPLAY_REPORT_SHOPADMIN = 14;
    this.PAGE_SITE_QA_LIST = 8; //QA:Mua gi? ở đâu/ giá bao nhiêu?
    this.PAGE_SIZE_LIST_PRODUCT_BY_SHOP = 24;
    //Type cho trang danh sách sản phẩm
    this.LIST_PRODUCT_NEW = 1; //Sản phẩm mới nhất
    this.LIST_PRODUCT_FAVO = 2; //Sản phẩm được yêu thích nhất
    this.LIST_PRODUCT_VIEWCOUNT = 3; //Sản phẩm xem nhiều nhất
    this.LIST_PRODUCT_BESTSELL = 4; //Sản phẩm bán chạy nhất


    //Hằng số cho GoPayment
    this.PAY_COST = 5; //Phí thanh toán
    this.GO_TO_VND = 100; //Tỉ lệ quy đổi giữa đồng GO và VNĐ

    this.TOOLTIP_STYLE_INPUT = {
        trigger: ['focus', 'blur'],
        positions: ['right'],
        fill: '#F7F7F7',
        strokeStyle: '#B7B7B7',
        spikeLength: 10,
        spikeGirth: 10,
        padding: 8,
        cornerRadius: 0,
        cssStyles: {
            fontFamily: '"lucida grande",tahoma,verdana,arial,sans-serif',
            fontSize: '11px',
            textAlign: 'justify'
        }
    };
}