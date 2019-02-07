using DnnSummit.Models;
using System;
using Xamarin.Forms;

namespace DnnSummit.Selectors
{
    public class QuestionDataTemplateSelector : DataTemplateSelector
    {
        public DataTemplate SingleLineTemplate { get; set; }
        public DataTemplate MultiLineTemplate { get; set; }
        public DataTemplate Scale1To5Template { get; set; }
        public DataTemplate BooleanTemplate { get; set; }
        public DataTemplate CustomOptionsTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            var question = (SurveyQuestion)item;
            if (question != null)
            {
                switch (question.Type)
                {
                    case Question.SingleLine:
                        return SingleLineTemplate;
                    case Question.MultiLine:
                        return MultiLineTemplate;
                    case Question.Scale1To5:
                        return Scale1To5Template;
                    case Question.Boolean:
                        return BooleanTemplate;
                    case Question.CustomOptions:
                        return CustomOptionsTemplate;
                }
            }

            throw new NotSupportedException("Unable to find the correct template");
        }
    }
}
