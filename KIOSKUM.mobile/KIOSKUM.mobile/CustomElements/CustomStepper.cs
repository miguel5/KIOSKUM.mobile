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
        Entry Entry;
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
            //Spacing = 1;

            PlusBtn = new Button { Text = "+", WidthRequest = 30, HeightRequest = 30, FontAttributes = FontAttributes.Bold, FontSize = 15,
                VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };
            MinusBtn = new Button { Text = "-", WidthRequest = 30, HeightRequest = 30, FontAttributes = FontAttributes.Bold, FontSize = 15,
                VerticalOptions = LayoutOptions.Center, HorizontalOptions = LayoutOptions.Center };

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

            Orientation = StackOrientation.Horizontal;
            PlusBtn.Clicked += PlusBtn_Clicked;
            MinusBtn.Clicked += MinusBtn_Clicked;
            Entry = new Entry
            {
                PlaceholderColor = Color.Gray,
                Keyboard = Keyboard.Numeric,
                WidthRequest = 40,
                BackgroundColor = Color.FromHex("#3FFF")
            };
            Entry.SetBinding(Entry.TextProperty, new Binding(nameof(Text), BindingMode.TwoWay, source: this));
            Entry.TextChanged += Entry_TextChanged;

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

            StackLayout stack = new StackLayout
            {
                //Spacing = 1,
                HeightRequest = 60,
                Children =
                {
                    PlusBtn,
                    MinusBtn
                }
            };
            //Children.Add(MinusBtn);
            Children.Add(Label);
            Children.Add(stack);
            //Children.Add(PlusBtn);
            
        }

        private void Entry_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(e.NewTextValue))
                this.Text = int.Parse(e.NewTextValue);
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
