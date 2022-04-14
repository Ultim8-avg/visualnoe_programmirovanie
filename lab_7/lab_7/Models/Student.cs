using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Avalonia.Media;
using ReactiveUI;

namespace lab_7.Models
{
    public class Student : ReactiveObject
    {
        string name;                
        ISolidColorBrush color;     
        string average_mark;        

        public Student()
        {
            name = "";

            Marks = new List<Mark> {
                new Mark("СГМА"), 
                new Mark("Сети ЭВМ"),
                new Mark("ЭЭС"),
                new Mark("Архитектура ЭВМ")
            };

            for (int i = 0; i < Marks.Count; ++i)
            {
                Marks[i].Changed.Subscribe((x) => calculate());
            }

            calculate();
        }

        public Student(string nam) : this()
        {
            name = nam;
        }

        public string Name
        {
            set => name = value;

            get => name;
        }

        public List<Mark> Marks
        {
            set;

            get;
        }

        public string AverageMark
        {
            set => this.RaiseAndSetIfChanged(ref average_mark, value);

            get => average_mark;
        }

        public ISolidColorBrush Color
        {
            set => this.RaiseAndSetIfChanged(ref color, value);

            get => color;
        }

        void calculate()
        {
            double result = 0;
            
            try
            {
                foreach (var mark in Marks)
                {
                    result += int.Parse(mark.Value);
                }
            }
            catch (FormatException e)
            {
                AverageMark = "#ERROR";
                Color = Brushes.White;
                return;
            }

            result /= Marks.Count;  

            if (result < 1)                        
            {
                Color = Brushes.Red;
            }
            else if (result >= 1 && result < 1.5)   
            {
                Color = Brushes.Yellow;
            }
            else                                    
            {
                Color = Brushes.Green;
            }

            AverageMark = result.ToString();
        }

        public bool IsChecked
        {
            set;

            get;
        }
    }
}
