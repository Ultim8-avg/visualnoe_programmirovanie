using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using ReactiveUI;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_9.Models
{
    public class ReviewerFiles : ReactiveObject
    {
        ObservableCollection<ReviewerFiles>? files;     
        public bool is_directory;                       

        public ReviewerFiles(string path)
        {
            files = null;
            this.Path = path;
            var file = new FileInfo(path);
            is_directory = file.Attributes.HasFlag(FileAttributes.Directory);

            if (file.Name.Length == 0)
            {
                TitlePath = path;
            }
            else
            {
                TitlePath = file.Name;
            }
        }

        public ObservableCollection<ReviewerFiles>? Files
        {
            get
            {
                if (files == null && is_directory)      
                {
                    files = new ObservableCollection<ReviewerFiles>(); 

                    string[] current_path;

                    try
                    {
                        current_path = Directory.GetDirectories(Path);  

                        foreach (string file in current_path)           
                        {
                            files.Add(new ReviewerFiles(file));        
                        }
                    }
                    catch (UnauthorizedAccessException) { }

                    try
                    {
                        current_path = Directory.GetFiles(Path);        
                        foreach (string file in current_path)
                        {
                            FileInfo file_info = new FileInfo(file);
                            string extension = file_info.Extension; 

                            if (extension == ".png" || extension == ".jpg" || extension == ".jpeg")  
                            {
                                files.Add(new ReviewerFiles(file));     
                            }
                        }
                    }
                    catch (UnauthorizedAccessException) { }
                }

                return files;
            }
        }

        public string TitlePath
        {
            set;

            get;
        }

        public string Path
        {
            private set;

            get;
        }
    }
}
