﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace ZGAF_DELR_EXAMEN_2P.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();
            Xamarin.FormsMaps.Init("CVQNY2Q9KgtdHnWgmWi9~6Bj4sINLmjvOR_UBWvTeOA~Al1zBxognQL37BHZj9ErQj34cu8Hv2ekiPwyCaA1IyRAwdoYvv3HgCDOzoDGnkQA");
            LoadApplication(new ZGAF_DELR_EXAMEN_2P.App());
        }
    }
}
