using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;

namespace lab_7.Models
{
    public class Mark : ReactiveObject
    {
        ISolidColorBrush color;     
        string mark;                

        public Mark(string name_subject)
        {
            Value = "0";
            Name_subject = name_subject;
        }

        public ISolidColorBrush Color
        {
            set => this.RaiseAndSetIfChanged(ref color, value);

            get => color;
        }

        public string Name_subject
        {
            set;

            get;
        }

        public string Value
        {
            get => mark;

            set
            {
                try
                {
                    int value_mark = int.Parse(value);      

                    if (value_mark < 0 || value_mark > 2)   
                    {
                        value = "#ERROR";
                        Color = Brushes.White;
                    }
                    else                                   
                    {
                        if (value_mark == 0)               
                        {
                            Color = Brushes.Red;
                        }
                        else if (value_mark == 1)           
                        {
                            Color = Brushes.Yellow;
                        }
                        else                                
                        {
                            Color = Brushes.Green;
                        }
                    }
                }
                catch (FormatException e)
                {
                    value = "#ERROR";
                }

                this.RaiseAndSetIfChanged(ref mark, value);
            }
        }
    }
}
