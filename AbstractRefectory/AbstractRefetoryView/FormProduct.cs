﻿using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Unity;

namespace AbstractRefetoryView
{
    public partial class FormProduct : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IProductService service;
        private int? id;
        public FormProduct(IProductService service)
        {
            InitializeComponent();
            this.service = service;
        }


        private void FormMaterial_Load(object sender, EventArgs e)
        {

            if (id.HasValue)
            {
                try
                {
                    ProductViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxMaterial.Text = view.ProductName;
                        textBoxPrice.Text = view.Price.ToString();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }

        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxMaterial.Text))
            {
                MessageBox.Show("Заполните ФИО", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (id.HasValue)
                {
                    service.UpdElement(new ProductBindingModel
                    {
                        Id = id.Value,
                        ProductName = textBoxMaterial.Text,
                        Price = Convert.ToDecimal(textBoxPrice.Text)
                    });
                }
                else
                {
                    service.AddElement(new ProductBindingModel
                    {
                        ProductName = textBoxMaterial.Text,
                         Price = Convert.ToDecimal(textBoxPrice.Text)
                    });
                }
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}