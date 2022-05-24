using System;
using System.Collections.Generic;
using System.Text;
using lab_9.Models;
using System.Collections.ObjectModel;
using Avalonia.Media.Imaging;
using ReactiveUI;
using System.IO;

namespace lab_9.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        Bitmap? image;                                     
        bool is_move_enable;                                
        ObservableCollection<ReviewerFiles> items;          
        int move_index;                                     
        List<string> image_move_list;                      
        string current_path;                               
        ReviewerFiles selected_item;                      


        public MainWindowViewModel()
        {
            Image = null;
            MoveEnable = false;
            items = new ObservableCollection<ReviewerFiles>();

            foreach (DriveInfo drive in DriveInfo.GetDrives())
            {
                items.Add(new ReviewerFiles(drive.Name));
            }

            this.WhenAnyValue((x) => x.SelectedItem).Subscribe((x) => load_image());
        }

        public Bitmap? Image
        {
            set => this.RaiseAndSetIfChanged(ref image, value);

            get => image;
        }

        public bool MoveEnable
        {
            set => this.RaiseAndSetIfChanged(ref is_move_enable, value);

            get => is_move_enable;
        }

        public ObservableCollection<ReviewerFiles> Items
        {
            set => this.RaiseAndSetIfChanged(ref items, value);

            get => items;
        }

        public string CurrentPath
        {
            set => this.RaiseAndSetIfChanged(ref current_path, value);

            get => current_path;
        }

        public ReviewerFiles SelectedItem
        {
            set => this.RaiseAndSetIfChanged(ref selected_item, value);

            get => selected_item;
        }

        void load_image()
        {
            if (selected_item != null && !selected_item.is_directory)
            {
                Image = new Bitmap(selected_item.Path);
                CurrentPath = selected_item.Path;
                image_move_list = new List<string>();

                int index = 0;

                foreach (string file in Directory.GetFiles(Directory.GetParent(selected_item.Path).FullName))
                {
                    string ext = Path.GetExtension(file);
                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg")
                    {
                        if (file == selected_item.Path)
                        {
                            move_index = index;
                        }

                        image_move_list.Add(file);

                        index++;
                    }

                }
                if (image_move_list.Count > 1)
                {
                    MoveEnable = true;
                }
            }

            else
            {
                Image = null;
                MoveEnable = false;
            }
        }

        void move_image(int direction)
        {
            int nIndex = move_index + direction;

            if (nIndex < 0)
            {
                nIndex = image_move_list.Count - 1;
            }

            if (nIndex >= image_move_list.Count)
            {
                nIndex = 0;
            }

            move_index = nIndex;
            CurrentPath = image_move_list[move_index];

            Image = new Bitmap(image_move_list[move_index]);
        }
    }
}
