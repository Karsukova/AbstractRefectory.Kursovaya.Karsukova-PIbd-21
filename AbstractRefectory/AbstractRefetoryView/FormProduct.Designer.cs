namespace AbstractRefetoryView
{
    partial class FormProduct
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
            this.textBoxMaterial = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.textBoxPrice = new System.Windows.Forms.TextBox();
            this.Стоимость = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxDateFreshment = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxMaterial
            // 
            this.textBoxMaterial.Location = new System.Drawing.Point(193, 9);
            this.textBoxMaterial.Multiline = true;
            this.textBoxMaterial.Name = "textBoxMaterial";
            this.textBoxMaterial.Size = new System.Drawing.Size(381, 33);
            this.textBoxMaterial.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Наименование:";
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(255, 173);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(146, 39);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(433, 173);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(141, 39);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // textBoxPrice
            // 
            this.textBoxPrice.Location = new System.Drawing.Point(193, 59);
            this.textBoxPrice.Name = "textBoxPrice";
            this.textBoxPrice.Size = new System.Drawing.Size(381, 26);
            this.textBoxPrice.TabIndex = 4;
            // 
            // Стоимость
            // 
            this.Стоимость.AutoSize = true;
            this.Стоимость.Location = new System.Drawing.Point(30, 62);
            this.Стоимость.Name = "Стоимость";
            this.Стоимость.Size = new System.Drawing.Size(97, 20);
            this.Стоимость.TabIndex = 5;
            this.Стоимость.Text = "Стоимость:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 109);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(125, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Срок годности:";
            // 
            // textBoxDateFreshment
            // 
            this.textBoxDateFreshment.Location = new System.Drawing.Point(193, 109);
            this.textBoxDateFreshment.Name = "textBoxDateFreshment";
            this.textBoxDateFreshment.Size = new System.Drawing.Size(381, 26);
            this.textBoxDateFreshment.TabIndex = 7;
            // 
            // FormProduct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 237);
            this.Controls.Add(this.textBoxDateFreshment);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Стоимость);
            this.Controls.Add(this.textBoxPrice);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxMaterial);
            this.Name = "FormProduct";
            this.Text = "Добавить продукт";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxMaterial;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxPrice;
        private System.Windows.Forms.Label Стоимость;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxDateFreshment;
    }
}