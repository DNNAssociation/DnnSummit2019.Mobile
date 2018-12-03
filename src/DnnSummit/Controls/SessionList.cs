
using DnnSummit.Models;
using System;
using System.Collections;
using Xamarin.Forms;

namespace DnnSummit.Controls
{
    public class SessionList : ContentView
	{
        public StackLayout StackLayout;
		public SessionList ()
		{
            StackLayout = new StackLayout
            {
                Spacing = 0,
                BackgroundColor = Color.FromHex("#727126"),
                Margin = new Thickness(-20, 0)
            };

            Content = StackLayout;
		}

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(SessionList),
            null,
            propertyChanged: OnItemsSourceProperty);

        private static void OnItemsSourceProperty(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SessionList)bindable;
            if (context != null)
            {
                context.ItemsSource = (IEnumerable)newValue;
                context.StackLayout.Children.Clear();

                foreach (var item in context.ItemsSource)
                {
                    var session = (Session)item;
                    if (session != null)
                    {
                        context.StackLayout.Children.Add(new Label
                        {
                            Text = session.Title,
                            FontSize = 18,
                            FontAttributes = FontAttributes.Bold,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Color.White,
                            Margin = new Thickness(0, 15)
                        });
                    }
                }
            }
        }
    }
}