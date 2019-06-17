using AbstractRefectoryServiceDAL.BindingModel;
using AbstractRefectoryServiceDAL.ViewModel;
using AbstractRefectoryServiceDAL.Interfaces;
using AbstractRefectoryModel;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Unity;

namespace AbstractRefetoryView
{
    public partial class FormOrderListProductCount : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public OrderListProductViewModel Model
        {
            set { model = value; }
            get
            {
                return model;
            }
        }
        private readonly IProductService serviceP;

        private OrderListProductViewModel model;
        public FormOrderListProductCount(IProductService serviceP)
        {
            InitializeComponent();
            this.serviceP = serviceP;
        }
        private void FormOrderListProduct_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductViewModel> list = serviceP.GetList();
                if (list != null)
                {
                    comboBoxProduct.DisplayMember = "ProductName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = list;
                    comboBoxProduct.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
            if (model != null)
            {
                comboBoxProduct.Enabled = false;
                comboBoxProduct.SelectedValue = model.ProductId;
                textBoxCount.Text = model.Count.ToString();
            }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите материал", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                if (model == null)

                {

                    model = new OrderListProductViewModel
                    {
                        ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                        ProductName = comboBoxProduct.Text,
                        Count = Convert.ToInt32(textBoxCount.Text),
                        Price = Convert.ToDecimal(textBoxPrice.Text),
                        Sum = Convert.ToDecimal(textBoxSum.Text)

                    };
                }
                else
                {
                    model.Count = Convert.ToInt32(textBoxCount.Text);
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

        private void CalcSum()
        {
            if (comboBoxProduct.SelectedValue != null &&
           !string.IsNullOrEmpty(textBoxCount.Text))
            {
                try
                {
                    int id = Convert.ToInt32(comboBoxProduct.SelectedValue);
                    ProductViewModel product = serviceP.GetElement(id);
                    int count = Convert.ToInt32(textBoxCount.Text);
                    textBoxSum.Text = (count * product.Price).ToString();
                    textBoxPrice.Text = product.Price.ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
        }
        private void textBoxCount_TextChanged(object sender, EventArgs e)
        {
            CalcSum();
        }
        private void comboBoxProduct_SelectedIndexChanged(object sender, EventArgs e)
        {
            CalcSum();
        }

       
    }
}