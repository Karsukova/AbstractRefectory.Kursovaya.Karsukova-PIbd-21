﻿namespace AbstractRefetoryView
{
    partial class FormMain
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.администраторыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.продуктыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.СпискиПоставокToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.холодильникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пополнитьХолодильникToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.загруженностьХолодильниковToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.заказыКлиентовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.adminOrdersViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminOrdersViewModelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.справочникиToolStripMenuItem,
            this.пополнитьХолодильникToolStripMenuItem,
            this.отчётыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1155, 33);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.администраторыToolStripMenuItem,
            this.продуктыToolStripMenuItem,
            this.СпискиПоставокToolStripMenuItem,
            this.холодильникиToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(135, 29);
            this.справочникиToolStripMenuItem.Text = "Справочники";
            // 
            // администраторыToolStripMenuItem
            // 
            this.администраторыToolStripMenuItem.Name = "администраторыToolStripMenuItem";
            this.администраторыToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.администраторыToolStripMenuItem.Text = "Администраторы";
            this.администраторыToolStripMenuItem.Click += new System.EventHandler(this.клиентыToolStripMenuItem_Click);
            // 
            // продуктыToolStripMenuItem
            // 
            this.продуктыToolStripMenuItem.Name = "продуктыToolStripMenuItem";
            this.продуктыToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.продуктыToolStripMenuItem.Text = "Продукты";
            this.продуктыToolStripMenuItem.Click += new System.EventHandler(this.компонентыToolStripMenuItem_Click);
            // 
            // СпискиПоставокToolStripMenuItem
            // 
            this.СпискиПоставокToolStripMenuItem.Name = "СпискиПоставокToolStripMenuItem";
            this.СпискиПоставокToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.СпискиПоставокToolStripMenuItem.Text = "Списки поставок";
            this.СпискиПоставокToolStripMenuItem.Click += new System.EventHandler(this.изделияToolStripMenuItem_Click);
            // 
            // холодильникиToolStripMenuItem
            // 
            this.холодильникиToolStripMenuItem.Name = "холодильникиToolStripMenuItem";
            this.холодильникиToolStripMenuItem.Size = new System.Drawing.Size(238, 30);
            this.холодильникиToolStripMenuItem.Text = "Холодильники";
            this.холодильникиToolStripMenuItem.Click += new System.EventHandler(this.складыToolStripMenuItem_Click);
            // 
            // пополнитьХолодильникToolStripMenuItem
            // 
            this.пополнитьХолодильникToolStripMenuItem.Name = "пополнитьХолодильникToolStripMenuItem";
            this.пополнитьХолодильникToolStripMenuItem.Size = new System.Drawing.Size(225, 29);
            this.пополнитьХолодильникToolStripMenuItem.Text = "Пополнить холодильник";
            this.пополнитьХолодильникToolStripMenuItem.Click += new System.EventHandler(this.пополнитьСкладToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.загруженностьХолодильниковToolStripMenuItem,
            this.заказыКлиентовToolStripMenuItem,
            this.toolStripMenuItem2});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(84, 29);
            this.отчётыToolStripMenuItem.Text = "Отчёты";
            // 
            // загруженностьХолодильниковToolStripMenuItem
            // 
            this.загруженностьХолодильниковToolStripMenuItem.Name = "загруженностьХолодильниковToolStripMenuItem";
            this.загруженностьХолодильниковToolStripMenuItem.Size = new System.Drawing.Size(351, 30);
            this.загруженностьХолодильниковToolStripMenuItem.Text = "Загруженность холодильников";
            this.загруженностьХолодильниковToolStripMenuItem.Click += new System.EventHandler(this.загруженностьХолодильниковToolStripMenuItem_Click);
            // 
            // заказыКлиентовToolStripMenuItem
            // 
            this.заказыКлиентовToolStripMenuItem.Name = "заказыКлиентовToolStripMenuItem";
            this.заказыКлиентовToolStripMenuItem.Size = new System.Drawing.Size(351, 30);
            this.заказыКлиентовToolStripMenuItem.Text = "Заказы клиентов";
            this.заказыКлиентовToolStripMenuItem.Click += new System.EventHandler(this.заказыКлиентовToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(351, 30);
            this.toolStripMenuItem2.Text = "Прайс продуктов";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.прайсИзделийToolStripMenuItem_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.BackgroundColor = System.Drawing.Color.GhostWhite;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(14, 58);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowTemplate.Height = 28;
            this.dataGridView.Size = new System.Drawing.Size(827, 460);
            this.dataGridView.TabIndex = 1;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(883, 76);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(232, 44);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "Создать заказ";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(883, 149);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(232, 44);
            this.button1.TabIndex = 3;
            this.button1.Text = "Отдать на выполнение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonTakeOrderInWork_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(883, 223);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(232, 44);
            this.button2.TabIndex = 4;
            this.button2.Text = "Заказ готов";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonOrderReady_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(883, 306);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(232, 44);
            this.button3.TabIndex = 5;
            this.button3.Text = "Заказ оплачен";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonPayOrder_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(883, 375);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(232, 44);
            this.button4.TabIndex = 6;
            this.button4.Text = "Обновить список";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonRef_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(888, 436);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(227, 45);
            this.button5.TabIndex = 7;
            this.button5.Text = "Бэкап";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1155, 532);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonCreateOrder);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "Учёт продуктов столовой";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminOrdersViewModelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem администраторыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem продуктыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem СпискиПоставокToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;

        private System.Windows.Forms.ToolStripMenuItem холодильникиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пополнитьХолодильникToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem прайсИзделийToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem загруженностьХолодильниковToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem заказыКлиентовToolStripMenuItem;
        private System.Windows.Forms.BindingSource adminOrdersViewModelBindingSource;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
    }
}
