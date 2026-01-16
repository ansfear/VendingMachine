namespace VendingMachine
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnSlot1 = new Button();
            btnSlot2 = new Button();
            btnSlot3 = new Button();
            btnSlot4 = new Button();
            btnSlot5 = new Button();
            lblInserted = new Label();
            btnPayCash = new Button();
            btnPayCard = new Button();
            btnRefund = new Button();
            SuspendLayout();
            // 
            // btnSlot1
            // 
            btnSlot1.Location = new Point(45, 54);
            btnSlot1.Name = "btnSlot1";
            btnSlot1.Size = new Size(175, 23);
            btnSlot1.TabIndex = 0;
            btnSlot1.Text = "btnSlot1";
            btnSlot1.UseVisualStyleBackColor = true;
            // 
            // btnSlot2
            // 
            btnSlot2.Location = new Point(251, 54);
            btnSlot2.Name = "btnSlot2";
            btnSlot2.Size = new Size(181, 23);
            btnSlot2.TabIndex = 1;
            btnSlot2.Text = "btnSlot2";
            btnSlot2.UseVisualStyleBackColor = true;
            // 
            // btnSlot3
            // 
            btnSlot3.Location = new Point(450, 54);
            btnSlot3.Name = "btnSlot3";
            btnSlot3.Size = new Size(149, 23);
            btnSlot3.TabIndex = 2;
            btnSlot3.Text = "btnSlot3";
            btnSlot3.UseVisualStyleBackColor = true;
            // 
            // btnSlot4
            // 
            btnSlot4.Location = new Point(633, 54);
            btnSlot4.Name = "btnSlot4";
            btnSlot4.Size = new Size(145, 23);
            btnSlot4.TabIndex = 3;
            btnSlot4.Text = "btnSlot4";
            btnSlot4.UseVisualStyleBackColor = true;
            // 
            // btnSlot5
            // 
            btnSlot5.Location = new Point(808, 54);
            btnSlot5.Name = "btnSlot5";
            btnSlot5.Size = new Size(142, 23);
            btnSlot5.TabIndex = 4;
            btnSlot5.Text = "btnSlot5";
            btnSlot5.UseVisualStyleBackColor = true;
            // 
            // lblInserted
            // 
            lblInserted.AutoSize = true;
            lblInserted.Location = new Point(407, 138);
            lblInserted.Name = "lblInserted";
            lblInserted.Size = new Size(91, 15);
            lblInserted.TabIndex = 5;
            lblInserted.Text = "Внесено: 0 руб.";
            // 
            // btnPayCash
            // 
            btnPayCash.Location = new Point(137, 220);
            btnPayCash.Name = "btnPayCash";
            btnPayCash.Size = new Size(141, 23);
            btnPayCash.TabIndex = 6;
            btnPayCash.Text = "Оплатить наличными";
            btnPayCash.UseVisualStyleBackColor = true;
            // 
            // btnPayCard
            // 
            btnPayCard.Location = new Point(407, 220);
            btnPayCard.Name = "btnPayCard";
            btnPayCard.Size = new Size(114, 23);
            btnPayCard.TabIndex = 7;
            btnPayCard.Text = "Оплатить картой";
            btnPayCard.UseVisualStyleBackColor = true;
            // 
            // btnRefund
            // 
            btnRefund.Location = new Point(633, 220);
            btnRefund.Name = "btnRefund";
            btnRefund.Size = new Size(111, 23);
            btnRefund.TabIndex = 8;
            btnRefund.Text = "Вернуть деньги";
            btnRefund.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1083, 450);
            Controls.Add(btnRefund);
            Controls.Add(btnPayCard);
            Controls.Add(btnPayCash);
            Controls.Add(lblInserted);
            Controls.Add(btnSlot5);
            Controls.Add(btnSlot4);
            Controls.Add(btnSlot3);
            Controls.Add(btnSlot2);
            Controls.Add(btnSlot1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnSlot1;
        private Button btnSlot2;
        private Button btnSlot3;
        private Button btnSlot4;
        private Button btnSlot5;
        private Label lblInserted;
        private Button btnPayCash;
        private Button btnPayCard;
        private Button btnRefund;
    }
}
