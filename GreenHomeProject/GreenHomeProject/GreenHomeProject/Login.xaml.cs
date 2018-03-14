using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHomeProject
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Login : ContentPage
	{
        public Login()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }

        private void Entry_Focused(object sender, FocusEventArgs e)
        {
            if (e.IsFocused)
                user.Text = "";
            if (!e.IsFocused && user.Text == "")
            {
                user.Text = "Username";
            }

        }

        private void Entry_Focused_1(object sender, FocusEventArgs e)
        {

            pass.IsPassword = true;
            if (e.IsFocused)
                pass.Text = "";
            else if (!e.IsFocused && pass.Text == "")
                user.Text = "Password";
            else if (!e.IsFocused && Authenticate())
            {
                Navigation.PopAsync();
            }

        }
        private bool Authenticate()
        {
            return true;
        }

        private void user_Unfocused(object sender, FocusEventArgs e)
        {

        }
    }
}
