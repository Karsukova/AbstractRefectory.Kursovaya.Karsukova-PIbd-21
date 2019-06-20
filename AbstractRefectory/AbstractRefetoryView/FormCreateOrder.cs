using AbstractRefectoryServiceDAL.BindingModel;
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
    public partial class FormCreateOrder : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IAdminService serviceC;
        private readonly IOrderListService serviceP;
        private readonly IMainService serviceM;
        public FormCreateOrder(IAdminService serviceC, IOrderListService serviceP,
       IMainService serviceM)
        {
            InitializeComponent();
            this.serviceC = serviceC;
            this.serviceP = serviceP;
            this.serviceM = serviceM;
        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            try
            {
                List<AdminViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxCustomer.DisplayMember = "AdminFIO";
                    comboBoxCustomer.ValueMember = "Id";
                    comboBoxCustomer.DataSource = listC;
                    comboBoxCustomer.SelectedItem = null;

                }
                List<OrderListViewModel> listP = serviceP.GetList();
                if (listP != null)
                {
                    comboBoxOrderList.DisplayMember = "OrderListName";
                    comboBoxOrderList.ValueMember = "Id";
                    comboBoxOrderList.DataSource = listP;
                    comboBoxOrderList.SelectedItem = null;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        
        private void buttonSave_Click(object sender, EventArgs e)
        {
            
            if (comboBoxCustomer.SelectedValue == null)
            {
                MessageBox.Show("Выберите клиента", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxOrderList.SelectedValue == null)
            {
                MessageBox.Show("Выберите изделие", "Ошибка", MessageBoxButtons.OK,

               MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.CreateOrder(new OrderBindingModel
                {
                    AdminId = Convert.ToInt32(comboBoxCustomer.SelectedValue),
                    OrderListId = Convert.ToInt32(comboBoxOrderList.SelectedValue),
                    Sum = serviceP.GetElement(Convert.ToInt32(comboBoxOrderList.SelectedValue)).Sum
                });
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

        private void comboBoxOrderList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxCustomer.SelectedValue != null)
            {
                CalcSum();
            }
        }
        private void CalcSum()
        {
            textBoxSum.Text = serviceP.GetElement(Convert.ToInt32(comboBoxOrderList.SelectedValue)).Sum.ToString();
        }
    }
}