using DnnSummit.Models;
using Prism.Commands;
using System;
using System.Collections;
using System.Windows.Input;
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

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        public static readonly BindableProperty CommandProperty = BindableProperty.Create(
            nameof(Command),
            typeof(ICommand),
            typeof(SessionList),
            null,
            propertyChanged: OnCommandPropertyChanged);

        private static void OnCommandPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SessionList)bindable;
            if (context != null)
            {
                context.Command = (ICommand)newValue;
                if (context.ItemsSource != null)
                {
                    OnItemsSourceProperty(bindable, null, context.ItemsSource);
                }
            }
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
                        var label = new Label
                        {
                            Text = session.Title,
                            FontSize = 18,
                            FontAttributes = FontAttributes.Bold,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Color.White,
                            Margin = new Thickness(0, 15)
                        };

                        label.GestureRecognizers.Add(new TapGestureRecognizer
                        {
                            Command = context.Command,
                            CommandParameter = session
                        });

                        context.StackLayout.Children.Add(label);
                    }
                }
            }
        }
    }
}