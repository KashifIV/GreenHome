using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading; 
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace GreenHomeProject
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Questions : ContentPage
    {
        private List<QStructure> Qs = new List<QStructure>();
        private int counter = 0;
        Label questionTitle;
        StackLayout GlobalLayout; 
        public Questions()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeQuestions();
            GlobalLayout = new StackLayout { Padding = new Thickness(5, 10), VerticalOptions = LayoutOptions.Center };
            this.Content = GlobalLayout;          
            questionTitle = new Label { Text = Qs[counter].question, TextColor = Color.White, FontSize = 20, HorizontalOptions = LayoutOptions.Center};
            GlobalLayout.Children.Add(questionTitle);
            DetermineAndCreateScreen(Qs[counter]); 
        }
        private void InitializeQuestions()
        {
            // Take from database in Final 
            Qs.Add(new QStructure("What kind of light bulb do you use?", new List<string> {"Incandescent", "Halogen", "Fluorescent", "Compact Fluorescent (CFL)", "Light Emitting Diode (LED)" }));
            Qs.Add(new QStructure("How many light bulbs are in your home?", new List<string> { "0-3", "4-7", "8-12", "13-18", "19-23", "24+" })); 
            Qs.Add(new QStructure("How many times a week do you use the Washing Machine?", "Is it High Efficiency?", new List<int> {1, 2, 3, 4, 5, 6, 7 }));
            Qs.Add(new QStructure("How many times a week do you use the Dish Washer?", new List<int> {1, 2, 3, 4, 5, 6, 7}));
            Qs.Add(new QStructure("What kind of Car do you drive?", new List<string> {"Sedan", "Convertable", "Coupe", "Minivan", "Van", "Pickup Truck", "Crossover" }));
        }
        private void FadeScreenOut(StackLayout layout)
        {
            for (int i = 0; i < layout.Children.Count; i++)
            {
                layout.Children[i].FadeTo(0, 1000);
            }
            //Thread.Sleep(1000);
            for (int i = layout.Children.Count - 1; i > 0; i--)
            {
                layout.Children.RemoveAt(i);
            }
        }
        private void DetermineAndCreateScreen(QStructure val)
        {
            if (val.subQuestion == null)
            {
                CreateScreen(val.question, val.options); 
            }
            else
            {
                CreateScreen(val.question, val.options, val.subQuestion); 
            }
        }
        private void CreateScreen(string question, List<string> options)
        {
           // FadeScreenOut(layout);
            questionTitle.Text = question;
            var select = new Picker {Title = "...", HorizontalOptions = LayoutOptions.Center, TextColor = Color.Black, BackgroundColor = Color.White};
            //select.ItemsSource = options;
            //select.Opacity = 0;
            select.ItemsSource = options; 
            GlobalLayout.Children.Add(select);
            //select.FadeTo(100, 1000);
            //questionTitle.FadeTo(100, 1000);
        }
        private void CreateScreen(string question, List<string> options, string q2)
        {
            //FadeScreenOut(layout);
            questionTitle.Text = question;
            var select = new Picker { HorizontalOptions = LayoutOptions.Center, TextColor = Color.White, BackgroundColor = Color.White };
            //select.ItemsSource = options;
            //select.Opacity = 0;
            var subQ = new Label { VerticalOptions = LayoutOptions.Center, HorizontalTextAlignment = TextAlignment.End, Text = q2, TextColor = Color.White};
            var check = new Switch { VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.End };

            GlobalLayout.Children.Add(select);
            GlobalLayout.Children.Add(subQ);
            GlobalLayout.Children.Add(check);
            select.FadeTo(100, 1000);
            subQ.FadeTo(100, 1000);
            check.FadeTo(100, 1000);
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            counter++;
            DetermineAndCreateScreen(Qs[counter]); 
        }
    }
    public struct QStructure
    {
        public string question, subQuestion;
        public bool multiple;
        public List<string> options;
        public QStructure(string q, List<string> o)
        {
            multiple = false;
            question = q;
            subQuestion = null;
            options = o;
        }
        public QStructure(string q, List<int> o)
        {
            multiple = false;
            question = q;
            subQuestion = null;
            options = new List<string>(); 
            for (int i = 0; i< o.Count; i++)
            {
                options.Add(o.ToString()); 
            }
        }
        public QStructure(string q1, string q2, List<string> o) 
        {
            multiple = true;
            question = q1;
            subQuestion = q2;
            options = o; 
        }
        public QStructure(string q1, string q2, List<int> o)
        {
            multiple = true;
            question = q1;
            subQuestion = q2;
            options = new List<string>();
            for (int i = 0; i < o.Count; i++)
            {
                options.Add(o.ToString());
            }
        }
    }
}