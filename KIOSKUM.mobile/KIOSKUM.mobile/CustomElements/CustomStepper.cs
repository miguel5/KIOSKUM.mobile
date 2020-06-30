using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Xml.Schema;
using Xamarin.Forms;

namespace KIOSKUM.mobile.CustomElements
{
    public class CustomStepper : StackLayout
    {
        Button PlusBtn;
        Button MinusBtn;
        Label Label;

        public static readonly BindableProperty TextProperty =
          BindableProperty.Create(
             propertyName: "Text",
              returnType: typeof(int),
              declaringType: typeof(CustomStepper),
              defaultValue: 1,
              defaultBindingMode: BindingMode.TwoWay);

        public int Text
        {
            get { return (int)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public CustomStepper()
        {
            Spacing = 1;
            Margin = 1;
            Orientation = StackOrientation.Horizontal;

            PlusBtn = new Button { Text = "+", WidthRequest = 40, HeightRequest = 20, FontAttributes = FontAttributes.Bold, FontSize = 15,
                VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.Black, Padding = 0 };
            MinusBtn = new Button { Text = "-", WidthRequest = 40, HeightRequest = 20, FontAttributes = FontAttributes.Bold, FontSize = 15,
                VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center, BorderColor = Color.Black, Padding = 0 };

            switch (Device.RuntimePlatform)
            {

                case Device.UWP:
                case Device.Android:
                    {
                        PlusBtn.BackgroundColor = Color.Transparent;
                        MinusBtn.BackgroundColor = Color.Transparent;
                        break;
                    }
                case Device.iOS:
                    {
                        PlusBtn.BackgroundColor = Color.DarkGray;
                        MinusBtn.BackgroundColor = Color.DarkGray;
                        break;
                    }
            }

            PlusBtn.Clicked += PlusBtn_Clicked;
            MinusBtn.Clicked += MinusBtn_Clicked;

            Label = new Label
            {
                WidthRequest = 20,
                HeightRequest = 20,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                BackgroundColor = Color.FromHex("#3FFF"),
                TextColor = Color.Black
            };
            Label.SetBinding(Label.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));

            StackLayout buttons_stack = new StackLayout
            {
                Spacing = 1,
                Margin = 1,
                //HeightRequest = 60,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Center,
                Children =
                {
                    PlusBtn,
                    MinusBtn
                }
            };


            Children.Add(Label);
            Children.Add(buttons_stack);          
        }

        private void MinusBtn_Clicked(object sender, EventArgs e)
        {
            if (Text > 1)
                Text--;
        }

        private void PlusBtn_Clicked(object sender, EventArgs e)
        {
            Text++;
        }

    }
}
