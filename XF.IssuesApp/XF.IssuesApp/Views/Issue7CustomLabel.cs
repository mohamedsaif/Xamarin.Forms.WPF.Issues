using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF.IssuesApp.Views
{
    public class Issue7CustomLabel : Label
    {
        public static readonly BindableProperty DeferredTextProperty = BindableProperty.Create("DeferredText", typeof(string), typeof(Issue7CustomLabel), null, BindingMode.TwoWay, propertyChanged: OnDeferredTextChanged);

        private string _deferredText;

        public string DeferredText
        {
            get
            {
                return this._deferredText;
            }

            set
            {
                this._deferredText = value;
                this.OnPropertyChanged("DeferredText");
                this.Text = _deferredText;
                this.OnPropertyChanged("Text");
            }
        }

        private static void OnDeferredTextChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = bindable as Issue7CustomLabel;
            if (control == null)
            {
                return;
            }

            control.DeferredText = (string)newValue;
        }
    }
}
