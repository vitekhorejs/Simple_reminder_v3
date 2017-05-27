using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Simple_reminder.UWP;
using Xamarin.Forms;
using System.IO;

[assembly: Dependency(typeof(FileHelper))]
namespace Simple_reminder.UWP
{
    public class FileHelper : IFileHelper
    {
        public string GetLocalFilePath(string filename)
        {
            return Path.Combine(ApplicationData.Current.LocalFolder.Path, filename);
        }
    }
}
