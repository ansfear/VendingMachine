using System.Drawing;
using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1
    {
        private void UpdateUI()
        {
            for (int slot = 1; slot <= 5; slot++)
            {
                var product = _products.Find(p => p.Slot == slot);
                if (product == null) continue;

                var button = GetButtonBySlot(slot);
                if (button == null) continue;

                button.Text = $"{slot}. {product.Name} \n {product.Price} руб.";

                if (product.IsAvailable)
                {
                    button.Enabled = true;
                    button.BackColor = Color.White;
                    button.ForeColor = Color.Black;
                }
                else
                {
                    button.Enabled = false;
                    button.BackColor = Color.FromArgb(255, 210, 210);
                    button.ForeColor = Color.Gray;
                }
            }
        }

        private Button GetButtonBySlot(int slot)
        {
            return slot switch
            {
                1 => btnSlot1,
                2 => btnSlot2,
                3 => btnSlot3,
                4 => btnSlot4,
                5 => btnSlot5,
                _ => null
            };
        }
    }
}