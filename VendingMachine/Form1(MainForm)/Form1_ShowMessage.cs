using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1
    {
        private void ShowMessage(string message, bool autoReset = false)
        {
            lblDisplay.Text = message;

            if (autoReset)
            {
                var timer = new System.Windows.Forms.Timer();
                timer.Interval = 2000;
                timer.Tick += (s, e) =>
                {
                    lblDisplay.Text = "Выберите товар (1–5)";
                    ((System.Windows.Forms.Timer)s).Stop();
                };
                timer.Start();
            }
        }
    }
}