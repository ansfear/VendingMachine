namespace VendingMachine
{
    partial class CashPaymentForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CashPaymentForm));
            lblAmount = new Label();
            btn10 = new Button();
            btn50 = new Button();
            btn100 = new Button();
            btn500 = new Button();
            btnConfirm = new Button();
            btnRefund = new Button();
            SuspendLayout();
            // 
            // lblAmount
            // 
            lblAmount.AutoSize = true;
            lblAmount.Location = new Point(128, 36);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(91, 15);
            lblAmount.TabIndex = 0;
            lblAmount.Text = "Внесено: 0 руб.";
            // 
            // btn10
            // 
            btn10.Location = new Point(20, 68);
            btn10.Name = "btn10";
            btn10.Size = new Size(70, 33);
            btn10.TabIndex = 1;
            btn10.Text = "10 ₽";
            btn10.UseVisualStyleBackColor = true;
            btn10.Click += btn10_Click;
            // 
            // btn50
            // 
            btn50.Location = new Point(112, 68);
            btn50.Name = "btn50";
            btn50.Size = new Size(70, 33);
            btn50.TabIndex = 2;
            btn50.Text = "50 ₽";
            btn50.UseVisualStyleBackColor = true;
            btn50.Click += btn50_Click;
            // 
            // btn100
            // 
            btn100.Location = new Point(210, 68);
            btn100.Name = "btn100";
            btn100.Size = new Size(70, 33);
            btn100.TabIndex = 3;
            btn100.Text = "100 ₽";
            btn100.UseVisualStyleBackColor = true;
            btn100.Click += btn100_Click;
            // 
            // btn500
            // 
            btn500.Location = new Point(310, 68);
            btn500.Name = "btn500";
            btn500.Size = new Size(70, 33);
            btn500.TabIndex = 4;
            btn500.Text = "500 ₽";
            btn500.UseVisualStyleBackColor = true;
            btn500.Click += btn500_Click;
            // 
            // btnConfirm
            // 
            btnConfirm.Location = new Point(107, 124);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(75, 49);
            btnConfirm.TabIndex = 5;
            btnConfirm.Text = "Выдать товар";
            btnConfirm.UseVisualStyleBackColor = true;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // btnRefund
            // 
            btnRefund.Location = new Point(210, 124);
            btnRefund.Name = "btnRefund";
            btnRefund.Size = new Size(75, 49);
            btnRefund.TabIndex = 6;
            btnRefund.Text = "Вернуть деньги";
            btnRefund.UseVisualStyleBackColor = true;
            btnRefund.Click += btnRefund_Click;
            // 
            // CashPaymentForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(403, 184);
            Controls.Add(btnRefund);
            Controls.Add(btnConfirm);
            Controls.Add(btn500);
            Controls.Add(btn100);
            Controls.Add(btn50);
            Controls.Add(btn10);
            Controls.Add(lblAmount);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "CashPaymentForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Внесение наличных";
            Load += CashPaymentForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblAmount;
        private Button btn10;
        private Button btn50;
        private Button btn100;
        private Button btn500;
        private Button btnConfirm;
        private Button btnRefund;
    }
}