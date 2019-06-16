namespace AbstractRefetoryView
{
    partial class FormFridgesLoad
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.SaveToExcel = new System.Windows.Forms.Button();
            this.Холодильник = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Продукт = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Количество = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.AliceBlue;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Холодильник,
            this.Продукт,
            this.Количество});
            this.dataGridView.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridView.Location = new System.Drawing.Point(12, 61);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(647, 518);
            this.dataGridView.TabIndex = 0;
            // 
            // SaveToExcel
            // 
            this.SaveToExcel.Location = new System.Drawing.Point(12, 12);
            this.SaveToExcel.Name = "SaveToExcel";
            this.SaveToExcel.Size = new System.Drawing.Size(305, 34);
            this.SaveToExcel.TabIndex = 1;
            this.SaveToExcel.Text = "Сохранить в Excel";
            this.SaveToExcel.UseVisualStyleBackColor = true;
            this.SaveToExcel.Click += new System.EventHandler(this.buttonSaveToExcel_Click);
            // 
            // Холодильник
            // 
            this.Холодильник.HeaderText = "Склад";
            this.Холодильник.Name = "Холодильник";
            this.Холодильник.Width = 200;
            // 
            // Продукт
            // 
            this.Продукт.HeaderText = "Материал";
            this.Продукт.Name = "Продукт";
            this.Продукт.Width = 200;
            // 
            // Количество
            // 
            this.Количество.HeaderText = "Количество";
            this.Количество.Name = "Количество";
            this.Количество.Width = 200;
            // 
            // FormFridgesLoad
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 600);
            this.Controls.Add(this.SaveToExcel);
            this.Controls.Add(this.dataGridView);
            this.Name = "FormFridgesLoad";
            this.Text = "Загрузка холодильников";
            this.Load += new System.EventHandler(this.FormStoragesLoad_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button SaveToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn Холодильник;
        private System.Windows.Forms.DataGridViewTextBoxColumn Продукт;
        private System.Windows.Forms.DataGridViewTextBoxColumn Количество;
    }
}