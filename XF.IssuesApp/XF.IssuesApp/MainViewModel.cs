using FontAwesome.Constants;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace XF.IssuesApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        /// <summary>
        /// Occurs when [property changed].
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        public string Issue1Field
        {
            get
            {
                return null;
            }
        }

        public string Issue2Field
        {
            get
            {
                return "String that is NOT centering vertically even though I am telling it to through the VerticalTextAlignment property!";
            }
        }

        public string Issue3Field1
        {
            get
            {
                return FA.BARS;
            }
        }

        public string Issue3Field2
        {
            get
            {
                return "Something written in Pick Ax Font";
            }
        }

        private string _issue5Field = "Failed!";
        public string Issue5Field
        {
            get
            {
                return _issue5Field;
            }
            set
            {
                _issue5Field = value;
                RaisePropertyChanged("Issue5Field");
            }
        }
        
        public Command Issue5FieldCommand
        {
            get
            {
                return new Command(() =>
                {
                    this.Issue5Field = "Success!";
                });
            }
        }

        public string Issue6Field
        {
            get
            {
                return "Username";
            }
        }

        private string _issue7Field;
        public string Issue7Field
        {
            get
            {
                return _issue7Field;
            }
            set
            {
                _issue7Field = value;
                RaisePropertyChanged("Issue7Field");
            }
        }

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="propertyName">Name of the property.</param>
        private void RaisePropertyChanged(string propertyName)
        {
            if (this.PropertyChanged == null)
            {
                return;
            }

            this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
