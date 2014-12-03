namespace Lab04
{
    partial class ApplicationForm
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
            this.textBoxKsi1 = new System.Windows.Forms.TextBox();
            this.textBoxKsi2 = new System.Windows.Forms.TextBox();
            this.labelKsi1 = new System.Windows.Forms.Label();
            this.labelKsi2 = new System.Windows.Forms.Label();
            this.textBoxMessage = new System.Windows.Forms.TextBox();
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonSend = new System.Windows.Forms.Button();
            this.buttonVerify = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.RichTextBox();
            this.textBox4 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // textBoxKsi1
            // 
            this.textBoxKsi1.Location = new System.Drawing.Point(12, 31);
            this.textBoxKsi1.Name = "textBoxKsi1";
            this.textBoxKsi1.Size = new System.Drawing.Size(100, 20);
            this.textBoxKsi1.TabIndex = 0;
            // 
            // textBoxKsi2
            // 
            this.textBoxKsi2.Location = new System.Drawing.Point(136, 31);
            this.textBoxKsi2.Name = "textBoxKsi2";
            this.textBoxKsi2.Size = new System.Drawing.Size(100, 20);
            this.textBoxKsi2.TabIndex = 1;
            // 
            // labelKsi1
            // 
            this.labelKsi1.AutoSize = true;
            this.labelKsi1.Location = new System.Drawing.Point(13, 12);
            this.labelKsi1.Name = "labelKsi1";
            this.labelKsi1.Size = new System.Drawing.Size(35, 13);
            this.labelKsi1.TabIndex = 3;
            this.labelKsi1.Text = "Кси 1";
            // 
            // labelKsi2
            // 
            this.labelKsi2.AutoSize = true;
            this.labelKsi2.Location = new System.Drawing.Point(136, 12);
            this.labelKsi2.Name = "labelKsi2";
            this.labelKsi2.Size = new System.Drawing.Size(35, 13);
            this.labelKsi2.TabIndex = 4;
            this.labelKsi2.Text = "Кси 2";
            // 
            // textBoxMessage
            // 
            this.textBoxMessage.Location = new System.Drawing.Point(260, 31);
            this.textBoxMessage.Name = "textBoxMessage";
            this.textBoxMessage.Size = new System.Drawing.Size(338, 20);
            this.textBoxMessage.TabIndex = 5;
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(260, 11);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(65, 13);
            this.labelMessage.TabIndex = 6;
            this.labelMessage.Text = "Сообщение";
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(504, 127);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(94, 42);
            this.buttonSend.TabIndex = 7;
            this.buttonSend.Text = "Отправить";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.ButtonSendClick);
            // 
            // buttonVerify
            // 
            this.buttonVerify.Location = new System.Drawing.Point(504, 272);
            this.buttonVerify.Name = "buttonVerify";
            this.buttonVerify.Size = new System.Drawing.Size(94, 42);
            this.buttonVerify.TabIndex = 8;
            this.buttonVerify.Text = "Проверить";
            this.buttonVerify.UseVisualStyleBackColor = true;
            this.buttonVerify.Click += new System.EventHandler(this.ButtonVerifyClick);
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox3.Location = new System.Drawing.Point(12, 58);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(486, 182);
            this.textBox3.TabIndex = 9;
            // 
            // textBox4
            // 
            this.textBox4.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox4.Location = new System.Drawing.Point(12, 246);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(486, 117);
            this.textBox4.TabIndex = 10;
            // 
            // ApplicationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(610, 375);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.buttonVerify);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.textBoxMessage);
            this.Controls.Add(this.labelKsi2);
            this.Controls.Add(this.labelKsi1);
            this.Controls.Add(this.textBoxKsi2);
            this.Controls.Add(this.textBoxKsi1);
            this.Name = "ApplicationForm";
            this.Text = "Лабораторная работа 4. Криптографическая подпись Фиат-Шамира";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxKsi1;
        private System.Windows.Forms.TextBox textBoxKsi2;
        private System.Windows.Forms.Label labelKsi1;
        private System.Windows.Forms.Label labelKsi2;
        private System.Windows.Forms.TextBox textBoxMessage;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Button buttonVerify;
        private System.Windows.Forms.RichTextBox textBox3;
        private System.Windows.Forms.RichTextBox textBox4;
    }
}

