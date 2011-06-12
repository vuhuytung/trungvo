<%@ Application Language="C#" %>
<script RunAt="server">

    void Application_Start(object sender, EventArgs e)
    {
        // Code that runs on application startup

    }

    void Application_End(object sender, EventArgs e)
    {
        //  Code that runs on application shutdown

    }

    void Application_Error(object sender, EventArgs e)
    {
        // Code that runs when an unhandled error occurs

    }

    void Session_Start(object sender, EventArgs e)
    {
        // Code that runs when a new session is started

    }

    void Session_End(object sender, EventArgs e)
    {
        // Code that runs when a session ends. 
        // Note: The Session_End event is raised only when the sessionstate mode
        // is set to InProc in the Web.config file. If session mode is set to StateServer 
        // or SQLServer, the event is not raised.

    }

    void Application_BeginRequest(object sender, EventArgs e)
    {
        /* Fix for the Flash Player Cookie bug in Non-IE browsers.
         * Since Flash Player always sends the IE cookies even in FireFox
         * we have to bypass the cookies by sending the values as part of the POST or GET
         * and overwrite the cookies with the passed in values.
         * 
         * The theory is that at this point (BeginRequest) the cookies have not been read by
         * the Session and Authentication logic and if we update the cookies here we'll get our
         * Session and Authentication restored correctly
         */
        //string[] arrSessionCookie = {
        //                                VTCO.Config.Constants.COOKIE_LOGIN_TYPE,
        //                                VTCO.Config.Constants.COOKIE_USER_ID,
        //                                VTCO.Config.Constants.COOKIE_PAYGATE_ID,
        //                                VTCO.Config.Constants.COOKIE_PAYGATE_NAME,
        //                                VTCO.Config.Constants.COOKIE_PUBLIC_NAME,
        //                                VTCO.Config.Constants.COOKIE_SHOP_ID,
        //                                VTCO.Config.Constants.COOKIE_SHOP_NAME
        //                            };


        //try
        //{
        //    string session_param_name = "ASPSESSID";
        //    string strTemp = HttpContext.Current.Request.Form[session_param_name] ?? HttpContext.Current.Request.QueryString[session_param_name];
        //    if (strTemp != null)
        //    {
        //        string[] arr = VTCO.Utils.UserUtils.GetDeCodeCookieData(strTemp);
        //        for (int i = 0; i < arrSessionCookie.Length; i++)
        //        {
        //            string session_cookie_name = arrSessionCookie[i];
        //            UpdateCookie(session_cookie_name, arr[i]);
        //        }
        //    }
        //}
        //catch (Exception)
        //{
        //    Response.StatusCode = 500;
        //    Response.Write("Error Initializing Session");
        //}

    }
    void UpdateCookie(string cookie_name, string cookie_value)
    {
        //HttpCookie cookie = HttpContext.Current.Request.Cookies.Get(cookie_name);
        //if (cookie == null)
        //{
        //    cookie = new HttpCookie(cookie_name);
        //    cookie.HttpOnly = true;
        //    HttpContext.Current.Request.Cookies.Add(cookie);
        //}
        //cookie.Value = cookie_value;
        //cookie.HttpOnly = true;
        //HttpContext.Current.Request.Cookies.Set(cookie);
    }
</script>
