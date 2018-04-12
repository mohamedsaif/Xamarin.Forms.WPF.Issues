using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XF.IssuesApp
{
    public class ShowIssuePage : ContentPage
    {
        #region Constructors

        public ShowIssuePage(object bindingContext, View view, Color? backgroundColor = null)
        {
            this.BindingContext = bindingContext;

            this.BackgroundColor = backgroundColor ?? Color.White;

            this.Content = view;
        }

        #endregion Constructors
    }
}