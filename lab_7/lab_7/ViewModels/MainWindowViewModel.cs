using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using lab_7.Models;
using System.Text;
using ReactiveUI;
using System.IO;
using Avalonia.Controls;

namespace lab_7.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        ObservableCollection<Student> items;   

        public MainWindowViewModel()
        {
            items = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> Items
        {
            get => items;
            set => this.RaiseAndSetIfChanged(ref items, value);
        }

        public void add_student()
        {
            Items.Add(new Student("‘»Œ"));
        }

        public void delete_student()
        {
            ObservableCollection<Student> newItems = new();

            foreach (var student in items)
            {
                if (!student.IsChecked)
                {
                    newItems.Add(student);
                }
            }

            Items = newItems;
        }

        public void save_file(string path)
        {
            using (StreamWriter sw = File.CreateText(path))
            {
                foreach (var student in Items)
                {
                    sw.Write($"\"{student.Name}\" ");
                    foreach (var mark in student.Marks)
                    {
                        sw.Write($"{mark.Value} ");
                    }
                    sw.Write('\n');
                }
            }
        }

        public void load_file(string path)
        {
            if (File.Exists(path))
            {
                Items.Clear();
                
                using (StreamReader sr = File.OpenText(path))
                {
                    var str = "";
                    while ((str = sr.ReadLine()) != null)
                    {
                        var index = str.IndexOf('"', 1);

                        var name = str.Substring(1, index - 1);

                        var grades = str.Substring(index + 2).Split(' ');

                        var student = new Student(name);

                        for (int i = 0; i < 4; ++i)
                        {
                            student.Marks[i].Value = grades[i];
                        }
                            
                        Items.Add(student);
                    }
                }
            }
        }
    }
}
