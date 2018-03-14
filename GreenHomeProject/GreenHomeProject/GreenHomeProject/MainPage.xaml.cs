using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace GreenHomeProject
{
	public partial class MainPage : ContentPage
	{

        public MainPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            if (CheckNewUser())
            {
                Navigation.PushAsync(new Questions());
            }
            if (CheckLogin())
            {
                Navigation.PushAsync(new Login());
            }
        }
        public bool CheckLogin()
        {
            if (true)
            {
                return true;
            }
            else
                return false;
        }
        private bool CheckNewUser()
        {
            if (true)
                return true;
            else
                return false;
        }
    }
}

