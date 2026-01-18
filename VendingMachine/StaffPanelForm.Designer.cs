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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StaffPanelForm));
            lblCash = new Label();
            lblElectronic = new Label();
            btnWithdrawCash = new Button();
            btnWithdrawElectronic = new Button();
            btnRestock1 = new Button();
            btnRestock2 = new Button();
            btnRestock3 = new Button();
            btnRestock4 = new Button();
            btnRestock5 = new Button();
            lblStock1 = new Label();
            lblStock2 = new Label();
            lblStock3 = new Label();
            lblStock4 = new Label();
            lblStock5 = new Label();
            SuspendLayout();
            // 
            // lblCash
            // 
            lblCash.AutoSize = true;
            lblCash.Location = new Point(37, 20);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(33, 15);
            lblCash.TabIndex = 0;
            lblCash.Text = "Cash";
            // 
            // lblElectronic
            // 
            lblElectronic.AutoSize = true;
            lblElectronic.Location = new Point(37, 61);
            lblElectronic.Name = "lblElectronic";
            lblElectronic.Size = new Size(32, 15);
            lblElectronic.TabIndex = 1;
            lblElectronic.Text = "Elect";
            // 
            // btnWithdrawCash
            // 
            btnWithdrawCash.Location = new Point(176, 12);
            btnWithdrawCash.Name = "btnWithdrawCash";
            btnWithdrawCash.Size = new Size(75, 31);
            btnWithdrawCash.TabIndex = 2;
            btnWithdrawCash.Text = "Забрать";
            btnWithdrawCash.UseVisualStyleBackColor = true;
            btnWithdrawCash.Click += btnWithdrawCash_Click;
            // 
            // btnWithdrawElectronic
            // 
            btnWithdrawElectronic.Location = new Point(176, 53);
            btnWithdrawElectronic.Name = "btnWithdrawElectronic";
            btnWithdrawElectronic.Size = new Size(75, 31);
            btnWithdrawElectronic.TabIndex = 3;
            btnWithdrawElectronic.Text = "Забрать";
            btnWithdrawElectronic.UseVisualStyleBackColor = true;
            btnWithdrawElectronic.Click += btnWithdrawElectronic_Click;
            // 
            // btnRestock1
            // 
            btnRestock1.Location = new Point(176, 100);
            btnRestock1.Name = "btnRestock1";
            btnRestock1.Size = new Size(123, 31);
            btnRestock1.TabIndex = 4;
            btnRestock1.Text = "Пополнить лоток 1";
            btnRestock1.UseVisualStyleBackColor = true;
            // 
            // btnRestock2
            // 
            btnRestock2.Location = new Point(176, 149);
            btnRestock2.Name = "btnRestock2";
            btnRestock2.Size = new Size(124, 31);
            btnRestock2.TabIndex = 5;
            btnRestock2.Text = "Пополнить лоток 2";
            btnRestock2.UseVisualStyleBackColor = true;
            // 
            // btnRestock3
            // 
            btnRestock3.Location = new Point(176, 197);
            btnRestock3.Name = "btnRestock3";
            btnRestock3.Size = new Size(123, 31);
            btnRestock3.TabIndex = 6;
            btnRestock3.Text = "Пополнить лоток 3";
            btnRestock3.UseVisualStyleBackColor = true;
            // 
            // btnRestock4
            // 
            btnRestock4.Location = new Point(176, 245);
            btnRestock4.Name = "btnRestock4";
            btnRestock4.Size = new Size(123, 31);
            btnRestock4.TabIndex = 7;
            btnRestock4.Text = "Пополнить лоток 4";
            btnRestock4.UseVisualStyleBackColor = true;
            // 
            // btnRestock5
            // 
            btnRestock5.Location = new Point(176, 295);
            btnRestock5.Name = "btnRestock5";
            btnRestock5.Size = new Size(123, 31);
            btnRestock5.TabIndex = 8;
            btnRestock5.Text = "Пополнить лоток 5";
            btnRestock5.UseVisualStyleBackColor = true;
            // 
            // lblStock1
            // 
            lblStock1.AutoSize = true;
            lblStock1.Location = new Point(37, 108);
            lblStock1.Name = "lblStock1";
            lblStock1.Size = new Size(38, 15);
            lblStock1.TabIndex = 9;
            lblStock1.Text = "label1";
            // 
            // lblStock2
            // 
            lblStock2.AutoSize = true;
            lblStock2.Location = new Point(37, 157);
            lblStock2.Name = "lblStock2";
            lblStock2.Size = new Size(38, 15);
            lblStock2.TabIndex = 10;
            lblStock2.Text = "label2";
            // 
            // lblStock3
            // 
            lblStock3.AutoSize = true;
            lblStock3.Location = new Point(37, 205);
            lblStock3.Name = "lblStock3";
            lblStock3.Size = new Size(38, 15);
            lblStock3.TabIndex = 11;
            lblStock3.Text = "label3";
            // 
            // lblStock4
            // 
            lblStock4.AutoSize = true;
            lblStock4.Location = new Point(37, 253);
            lblStock4.Name = "lblStock4";
            lblStock4.Size = new Size(38, 15);
            lblStock4.TabIndex = 12;
            lblStock4.Text = "label4";
            // 
            // lblStock5
            // 
            lblStock5.AutoSize = true;
            lblStock5.Location = new Point(37, 303);
            lblStock5.Name = "lblStock5";
            lblStock5.Size = new Size(38, 15);
            lblStock5.TabIndex = 13;
            lblStock5.Text = "label5";
            // 
            // StaffPanelForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(576, 359);
            Controls.Add(lblStock5);
            Controls.Add(lblStock4);
            Controls.Add(lblStock3);
            Controls.Add(lblStock2);
            Controls.Add(lblStock1);
            Controls.Add(btnRestock5);
            Controls.Add(btnRestock4);
            Controls.Add(btnRestock3);
            Controls.Add(btnRestock2);
            Controls.Add(btnRestock1);
            Controls.Add(btnWithdrawElectronic);
            Controls.Add(btnWithdrawCash);
            Controls.Add(lblElectronic);
            Controls.Add(lblCash);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "StaffPanelForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Панель управления";
            Load += StaffPanelForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCash;
        private Label lblElectronic;
        private Button btnWithdrawCash;
        private Button btnWithdrawElectronic;
        private Button btnRestock1;
        private Button btnRestock2;
        private Button btnRestock3;
        private Button btnRestock4;
        private Button btnRestock5;
        private Label lblStock1;
        private Label lblStock2;
        private Label lblStock3;
        private Label lblStock4;
        private Label lblStock5;
    }
}