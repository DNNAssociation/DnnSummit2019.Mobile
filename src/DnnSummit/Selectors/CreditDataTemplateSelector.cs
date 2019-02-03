using DnnSummit.Models;
using System;
using Xamarin.Forms;

namespace DnnSummit.Selectors
{
    public class CreditDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate PlatformTemplate { get; set; }
        public DataTemplate CompanyTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var credit = (Credit)item;
            if (credit != null)
            {
                switch (credit.CreditType)
                {
                    case CreditType.Company:
                        return CompanyTemplate;
                    case CreditType.Platform:
                        return PlatformTemplate;
                }
            }

            throw new NotSupportedException("Unable to find the correct template");
        }
    }
}
