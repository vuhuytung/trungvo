using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataContext;
namespace DAL
{
    class DBSlideShow
    {
        public DataContext.SlideShowDataContext CreateInstance()
        {
            return new SlideShowDataContext(VTCO.Config.Global.Settings.ConnectionString);
        }
    }
}
