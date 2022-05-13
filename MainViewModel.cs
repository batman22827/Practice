using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice
{
    public class MainViewModel
    {
        public ObservableCollection<ImageViewModel> Images { get; set; } = new ObservableCollection<ImageViewModel>();

        public MainViewModel()
        {
            var dir = Directory.GetFiles("Images", "*.png");
            foreach (var file in dir)
            {
                var fileInfo = new FileInfo(file);
                Images.Add(new ImageViewModel(fileInfo.Name, fileInfo.FullName));
            }
        }
    }
}
