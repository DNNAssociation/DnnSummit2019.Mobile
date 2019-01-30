using DnnSummit.Models;
using ImageCircle.Forms.Plugin.Abstractions;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DnnSummit.Controls
{
    public class HeadshotListControl : ContentView
    {
        public StackLayout Control { get; private set; }
        public HeadshotListControl()
        {
            Control = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false),
                WidthRequest = 100
            };

            Content = Control;
        }

        public IEnumerable Speakers
        {
            get { return (IEnumerable)GetValue(SpeakersProperty); }
            set { SetValue(SpeakersProperty, value); }
        }

        public static readonly BindableProperty SpeakersProperty = BindableProperty.Create(
            nameof(Speakers),
            typeof(IEnumerable),
            typeof(HeadshotListControl),
            null,
            propertyChanged: OnSpeakersPropertyChanged);

        private static void OnSpeakersPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (HeadshotListControl)bindable;
            if (context != null)
            {
                context.Control.Children.Clear();
                var items = (IEnumerable<Speaker>)newValue;
                if (items == null) return;

                if (items.Count() == 1)
                {
                    context.AddSpeaker(items.FirstOrDefault(), 70);
                }
                else
                {
                    var speakers = items.ToArray();
                    int itemsPerRow = 2;
                    StackLayout container = new StackLayout
                    {
                        Orientation = StackOrientation.Vertical,
                        VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                        HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true)
                    };
                    StackLayout row = new StackLayout();

                    for (int index = 0; index < speakers.Length; index++)
                    {
                        if (index % itemsPerRow == 0)
                        {
                            row = new StackLayout
                            {
                                Orientation = StackOrientation.Horizontal
                            };
                            container.Children.Add(row);

                        }

                        var circleImage = new CircleImage
                        {
                            Source = speakers[index].Headshot,
                            BorderColor = (Color)App.Current.Resources["AvatarBorder"],
                            BorderThickness = 1,
                            Aspect = Aspect.AspectFill,
                            WidthRequest = 45,
                            HeightRequest = 45,
                            VerticalOptions = new LayoutOptions(LayoutAlignment.Start, true),
                            HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false)
                        };

                        row.Children.Add(circleImage);
                    }

                    context.Control.Children.Add(container);
                }
            }
        }

        public void AddSpeakerNoTitle(Speaker speaker, int size)
        {
            var circleImage = new CircleImage
            {
                Source = speaker.Headshot,
                BorderColor = (Color)App.Current.Resources["AvatarBorder"],
                BorderThickness = 1,
                Aspect = Aspect.AspectFill,
                WidthRequest = size,
                HeightRequest = size,
                VerticalOptions = new LayoutOptions(LayoutAlignment.Start, true),
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false)
            };

            Control.Children.Add(circleImage);
        }

        public void AddSpeaker(Speaker speaker, int size)
        {
            var circleImage = new CircleImage
            {
                Source = speaker.Headshot,
                BorderColor = (Color)App.Current.Resources["AvatarBorder"],
                BorderThickness = 2,
                Aspect = Aspect.AspectFill,
                WidthRequest = size,
                HeightRequest = size,
                VerticalOptions = new LayoutOptions(LayoutAlignment.Start, true),
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false)
            };

            var label = new Label
            {
                Text = speaker.Name,
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                VerticalOptions = new LayoutOptions(LayoutAlignment.Center, true),
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };

            Control.Children.Add(circleImage);
            Control.Children.Add(label);
        }
    }
}
