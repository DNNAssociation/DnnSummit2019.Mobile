using DnnSummit.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace DnnSummit.Controls
{
    public class SponsorControl : ContentView
    {
        public StackLayout Control { get; set; }
        public SponsorControl()
        {
            Control = new StackLayout
            {
                Spacing = 0,
                Margin = 0
            };
            Content = Control;
        }

        public StackLayout CreateRow(Sponsor[] sponsors, bool isLastRow = false)
        {
            var row = new StackLayout
            {
                Orientation = StackOrientation.Horizontal,
                HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true),
                Spacing = 20,
                Margin = new Thickness(10, 0, 10, 0),
                HeightRequest = 200,
            };

            foreach (var item in sponsors)
            {
                var image = new Image
                {
                    Source = item.ImageLink,
                    Aspect = Aspect.AspectFit,
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Fill, true),
                    Margin = 0,
                    //HeightRequest = RowHeight
                };

                if (isLastRow)
                {
                    //var first = (StackLayout)Control.Children.First();
                    image.WidthRequest = 100; // todo - get width of each image from the first row
                    HorizontalOptions = new LayoutOptions(LayoutAlignment.Center, false);
                }

                row.Children.Add(image);
            }

            return row;
        }

        public double RowHeight
        {
            get { return (double)GetValue(RowHeightProperty); }
            set { SetValue(RowHeightProperty, value); }
        }

        public static readonly BindableProperty RowHeightProperty = BindableProperty.Create(
            nameof(RowHeight),
            typeof(double),
            typeof(SponsorControl),
            (double)100);



        public int SponsorsPerRow
        {
            get { return (int)GetValue(SponsorsPerRowProperty); }
            set { SetValue(SponsorsPerRowProperty, value); }
        }

        public static readonly BindableProperty SponsorsPerRowProperty = BindableProperty.Create(
            nameof(SponsorsPerRow),
            typeof(int),
            typeof(SponsorControl),
            2);

        public IEnumerable ItemsSource
        {
            get { return (IEnumerable)GetValue(ItemsSourceProperty); }
            set { SetValue(ItemsSourceProperty, value); }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(
            nameof(ItemsSource),
            typeof(IEnumerable),
            typeof(SponsorControl),
            null,
            propertyChanged: OnItemsSourcePropertyChanged);

        private static void OnItemsSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var context = (SponsorControl)bindable;
            if (context != null)
            {
                context.Control.Children.Clear();

                var data = (IEnumerable<Sponsor>)newValue;                
                if (data != null)
                {
                    var current = new List<Sponsor>();
                    var sponsors = data.ToArray();

                    for (int index = 0; index < sponsors.Length; index++)
                    {
                        current.Add(sponsors[index]);

                        if ((index > 0 && index % (context.SponsorsPerRow - 1) == 0) || index == sponsors.Length - 1)
                        {
                            bool isLast = false;
                            if (index == sponsors.Length - 1 && context.Control.Children.Count() > 1)
                            {
                                isLast = true;
                            }

                            var row = context.CreateRow(current.ToArray(), isLast);
                            current.Clear();

                            context.Control.Children.Add(row);
                        }
                    }
                }
            }
        }
    }
}
