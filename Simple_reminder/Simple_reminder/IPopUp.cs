using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simple_reminder
{
    public interface IPopUp
    {
        void ShowToast(string message);
        //void ShowSnackbar(string message);
    }
}
