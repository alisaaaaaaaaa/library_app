
namespace library_app
{
    partial class DateAskform
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
            this.txtlab = new System.Windows.Forms.Label();
            this.datetb = new System.Windows.Forms.MaskedTextBox();
            this.okbutton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtlab
            // 
            this.txtlab.AutoSize = true;
            this.txtlab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.txtlab.Location = new System.Drawing.Point(33, 36);
            this.txtlab.Name = "txtlab";
            this.txtlab.Size = new System.Drawing.Size(259, 20);
            this.txtlab.TabIndex = 0;
            this.txtlab.Text = "Введите дату возвратата книги:";
            // 
            // datetb
            // 
            this.datetb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.datetb.Location = new System.Drawing.Point(113, 81);
            this.datetb.Mask = "00/00/0000";
            this.datetb.Name = "datetb";
            this.datetb.Size = new System.Drawing.Size(91, 26);
            this.datetb.TabIndex = 1;
            this.datetb.ValidatingType = typeof(System.DateTime);
            // 
            // okbutton
            // 
            this.okbutton.Location = new System.Drawing.Point(113, 131);
            this.okbutton.Name = "okbutton";
            this.okbutton.Size = new System.Drawing.Size(91, 27);
            this.okbutton.TabIndex = 2;
            this.okbutton.Text = "Ok";
            this.okbutton.UseVisualStyleBackColor = true;
            this.okbutton.Click += new System.EventHandler(this.okbutton_Click);
            // 
            // DateAskform
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 199);
            this.Controls.Add(this.okbutton);
            this.Controls.Add(this.datetb);
            this.Controls.Add(this.txtlab);
            this.MaximumSize = new System.Drawing.Size(338, 238);
            this.MinimumSize = new System.Drawing.Size(338, 238);
            this.Name = "DateAskform";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label txtlab;
        private System.Windows.Forms.MaskedTextBox datetb;
        private System.Windows.Forms.Button okbutton;
    }
}