using DnnSummit.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;

namespace DnnSummit.Controls
{
    public class ScheduleItemControl : ContentView
    {
        public StackLayout Control { get; private set; }
        public ScheduleItemControl()
        {
            Control = new StackLayout();

            Content = Control;
        }

        public IEnumerable Messages
        {
            get { return (IEnumerable)GetValue(MessagesProperty); }
            set { SetValue(MessagesProperty, value); }
        }

        public static readonly BindableProperty MessagesProperty = BindableProperty.Create(
            nameof(Messages),
            typeof(IEnumerable),
            typeof(ScheduleItemControl),
            null,
            propertyChanged: OnMessagesPropertyChanged);

        private static void OnMessagesPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (ScheduleItemControl)bindable;
            if (context != null)
            {
                context.Control.Children.Clear();

                var items = (IEnumerable<DayMessage>)newValue;
                if (items == null) return;

                foreach (var item in items)
                {
                    var itemControl = new StackLayout();

                    if (!string.IsNullOrWhiteSpace(item.Heading))
                    {
                        var itemTitle = new Label
                        {
                            Text = item.Heading,
                            FontSize = 18,
                            TextColor = (Color)App.Current.Resources["Gray"]
                        };

                        itemControl.Children.Add(itemTitle);
                    }

                    if (!string.IsNullOrWhiteSpace(item.SubHeading))
                    {
                        var itemSubHeading = new Label
                        {
                            Text = item.SubHeading,
                            FontSize = 16,
                            TextColor = (Color)App.Current.Resources["DarkBlue"]

                        };

                        itemControl.Children.Add(itemSubHeading);
                    }

                    if (item.Events != null && item.Events.Any())
                    {
                        foreach (var entry in item.Events)
                        {
                            var entryStackLayout = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal,
                                Margin = new Thickness(5,0,0,0)
                            };

                            var box = new BoxView
                            {
                                HeightRequest = 5,
                                WidthRequest = 5,
                                BackgroundColor = (Color)App.Current.Resources["DarkBlue"],
                                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false),
                                VerticalOptions = new LayoutOptions(LayoutAlignment.Center, false)
                            };

                            var entryText = new StringBuilder();
                            entryText.Append(entry.TimeSlot);
                            entryText.Append(" | ");
                            entryText.Append(entry.Description);

                            if (!string.IsNullOrWhiteSpace(entry.Room))
                            {
                                entryText.Append(" - ");
                                entryText.Append(entry.Room);
                            }

                            var label = new Label
                            {
                                Text = entryText.ToString(),
                                FontSize = 14
                            };

                            entryStackLayout.Children.Add(box);
                            entryStackLayout.Children.Add(label);

                            itemControl.Children.Add(entryStackLayout);
                        }
                    }

                    context.Control.Children.Add(itemControl);
                }
            }
        }
    }
}
