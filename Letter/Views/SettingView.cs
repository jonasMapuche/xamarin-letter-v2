using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Letter.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Letter.Views
{
    public class SettingView
    {
        public SettingView(Context context)
        {
            SettingViewModel settingViewModel = new SettingViewModel();

            TextView text_abou = (TextView)((Activity)context).FindViewById(Resource.Id.tex_viw_about);
            text_abou.Text = settingViewModel.getAbout();
        }
    }
}