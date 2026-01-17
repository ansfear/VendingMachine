namespace VendingMachine
{
    partial class StaffPanelForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblCash = new Label();
            lblElectronic = new Label();
            btnWithdrawCash = new Button();
            btnWithdrawElectronic = new Button();
            SuspendLayout();
            // 
            // lblCash
            // 
            lblCash.AutoSize = true;
            lblCash.Location = new Point(134, 58);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(33, 15);
            lblCash.TabIndex = 0;
            lblCash.Text = "Cash";
            // 
            // lblElectronic
            // 
            lblElectronic.AutoSize = true;
            lblElectronic.Location = new Point(134, 99);
            lblElectronic.Name = "lblElectronic";
            lblElectronic.Size = new Size(32, 15);
            lblElectronic.TabIndex = 1;
            lblElectronic.Text = "Elect";
            // 
            // btnWithdrawCash
            // 
            btnWithdrawCash.Location = new Point(296, 50);
            btnWithdrawCash.Name = "btnWithdrawCash";
            btnWithdrawCash.Size = new Size(75, 23);
            btnWithdrawCash.TabIndex = 2;
            btnWithdrawCash.Text = "Забрать";
            btnWithdrawCash.UseVisualStyleBackColor = true;
            btnWithdrawCash.Click += btnWithdrawCash_Click;
            // 
            // btnWithdrawElectronic
            // 
            btnWithdrawElectronic.Location = new Point(296, 91);
            btnWithdrawElectronic.Name = "btnWithdrawElectronic";
            btnWithdrawElectronic.Size = new Size(75, 23);
            btnWithdrawElectronic.TabIndex = 3;
            btnWithdrawElectronic.Text = "Забрать";
            btnWithdrawElectronic.UseVisualStyleBackColor = true;
            btnWithdrawElectronic.Click += btnWithdrawElectronic_Click;
            // 
            // StaffPanelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 239);
            Controls.Add(btnWithdrawElectronic);
            Controls.Add(btnWithdrawCash);
            Controls.Add(lblElectronic);
            Controls.Add(lblCash);
            Name = "StaffPanelForm";
            Text = "StaffPanelForm";
            Load += StaffPanelForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCash;
        private Label lblElectronic;
        private Button btnWithdrawCash;
        private Button btnWithdrawElectronic;
    }
}