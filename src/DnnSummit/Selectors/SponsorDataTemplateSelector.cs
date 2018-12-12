using DnnSummit.Models;
using System;
using Xamarin.Forms;

namespace DnnSummit.Selectors
{
    public class SponsorDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate TitleTemplate { get; set; }
        public DataTemplate PlatinumTemplate { get; set; }
        public DataTemplate GoldTemplate { get; set; }
        public DataTemplate SilverTemplate { get; set; }
        public DataTemplate BronzeTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var sponsor = (ISponsorGroup)item;
            if (sponsor != null)
            {
                switch (sponsor.Level)
                {
                    case SponsorType.Title:
                        return TitleTemplate;
                    case SponsorType.Platinum:
                        return PlatinumTemplate; 
                    case SponsorType.Gold:
                        return GoldTemplate;
                    case SponsorType.Silver:
                        return SilverTemplate;
                    case SponsorType.Bronze:
                        return BronzeTemplate;
                }
            }

            throw new NotSupportedException("Unable to find the correct template");
        }
    }
}
