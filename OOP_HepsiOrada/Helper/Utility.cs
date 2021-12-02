using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OOP_HepsiOrada.Helper
{
    public class Utility
    {
        private readonly static string appName = "Toplama Sihirbazı";
        public static void ShowErrorMessage(string mesaj)
        {
            MessageBox.Show(mesaj, appName, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        public static void ShowSuccessMessage (string mesaj)
        {
            MessageBox.Show(mesaj, appName, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        public static DialogResult ShowDialogResultInformationMessage(string mesaj)
        {
            DialogResult result=MessageBox.Show(mesaj, appName, MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            return result;
        }
    }
}
