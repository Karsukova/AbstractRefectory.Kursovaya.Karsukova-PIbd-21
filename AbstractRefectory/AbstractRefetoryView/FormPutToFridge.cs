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
    public partial class FormPutToFridge : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        private readonly IFridgeService serviceS;
        private readonly IProductService serviceC;
        private readonly IMainService serviceM;
        public FormPutToFridge(IFridgeService serviceS, IProductService serviceC,
       IMainService serviceM)
        {
            InitializeComponent();
            this.serviceS = serviceS;
            this.serviceC = serviceC;
            this.serviceM = serviceM;
        }
        private void FormPutToFridge_Load(object sender, EventArgs e)
        {
            try
            {
                List<ProductViewModel> listC = serviceC.GetList();
                if (listC != null)
                {
                    comboBoxProduct.DisplayMember = "ProductName";
                    comboBoxProduct.ValueMember = "Id";
                    comboBoxProduct.DataSource = listC;
                    comboBoxProduct.SelectedItem = null;
                }
                List<FridgeViewModel> listS = serviceS.GetList();
                if (listS != null)
                {

                    comboBoxFridge.DisplayMember = "FridgeName";
                    comboBoxFridge.ValueMember = "Id";
                    comboBoxFridge.DataSource = listS;
                    comboBoxFridge.SelectedItem = null;
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
            if (string.IsNullOrEmpty(textBoxCount.Text))
            {
                MessageBox.Show("Заполните поле Количество", "Ошибка",
               MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (comboBoxProduct.SelectedValue == null)
            {
                MessageBox.Show("Выберите продукт", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (comboBoxFridge.SelectedValue == null)
            {
                MessageBox.Show("Выберите холодильник", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                serviceM.PutProductToFridge(new FridgeProductBindingModel
                {
                    ProductId = Convert.ToInt32(comboBoxProduct.SelectedValue),
                    FridgeId = Convert.ToInt32(comboBoxFridge.SelectedValue),
                    Count = Convert.ToInt32(textBoxCount.Text)

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

       

    }
}
