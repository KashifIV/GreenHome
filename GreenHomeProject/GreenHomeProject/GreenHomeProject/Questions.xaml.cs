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
	public partial class Questions : ContentPage
	{
        private List<string> Qs = new List<string>();
        private int counter = 0;
       
		public Questions ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeQuestions();
            StackLayout layout = new StackLayout { Padding = new Thickness(5, 10) };
            this.Content = layout;
            Label label = new Label { Text = Qs[counter], TextColor = Color.White, FontSize = 20 };
            InitializeScreen(layout, label);
            layout.Children.Add(label);
        }
        private void InitializeQuestions()
        {
            // Take from database in Final 
            Qs.Add("What kind of light bulb do you use?");
            Qs.Add("How many light bulbs are in your home?");
            Qs.Add("How many times a week do you use the Washing Machine?");
            Qs.Add("Is it High Efficiency?");
            Qs.Add("How many times a week do you use the Dish Washer?");
            Qs.Add("What kind of Car do you drive?");
        }
        private void InitializeScreen(Layout layout, Label label)
        {          
            label.VerticalOptions = LayoutOptions.Center;
            label.HorizontalOptions = LayoutOptions.Center;     
        }
        private void CreateInput(StackLayout layout)
        {
            if (counter == 0)
            {
              
                Picker bulbOptions = new Picker { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
    
                var options = new List<string>();
                options.Add("Incandescent");
                options.Add("Compat Fluorecent Lamp (CFL)");
                options.Add("Light Emitting Diode's (LED)");
                options.Add("Halogen Light Bublb");
                bulbOptions.ItemsSource = options;
                layout.Children.Add(bulbOptions); 
            }
        }
        private bool CheckInput()
        {
            return true; 
            if (counter == 0)
            {

            }
        }
        private void NextButton(object sender, EventArgs e)
        {
            if (CheckInput())
            {

            }
        }
    }
}