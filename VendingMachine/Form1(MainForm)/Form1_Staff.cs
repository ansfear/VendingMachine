using System.Windows.Forms;

namespace VendingMachine
{
    public partial class Form1
    {
        private void OpenStaffPanel()
        {
            var staffForm = new StaffPanelForm();
            staffForm.ShowDialog();
        }

        private void btnOpenStaff_Click(object sender, EventArgs e)
        {
            var pin = Microsoft.VisualBasic.Interaction.InputBox("Введите ПИН-код:", "Доступ персонала", "");
            if (pin == "12345")
            {
                OpenStaffPanel();
            }
            else
            {
                MessageBox.Show("Неверный ПИН!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}