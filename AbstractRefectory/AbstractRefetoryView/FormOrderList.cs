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
    public partial class FormOrderList : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IOrderListService service;
        private int? id;
        private List<OrderListProductViewModel> orderlistProducts;
        public FormOrderList(IOrderListService service)
        {
            InitializeComponent();
            this.service = service;
        }

        private void LoadData()
        {
            try
            {
                if (orderlistProducts != null)
                {
                    dataGridView.DataSource = null;
                    dataGridView.DataSource = orderlistProducts;
                    dataGridView.Columns[0].Visible = false;
                    dataGridView.Columns[1].Visible = false;
                    dataGridView.Columns[2].Visible = false;
                    dataGridView.Columns[3].AutoSizeMode =
                    DataGridViewAutoSizeColumnMode.Fill;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }

        private void FormOrderList_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    OrderListViewModel view = service.GetElement(id.Value);
                    if (view != null)
                    {
                        textBoxName.Text = view.OrderListName;
                        textBoxPrice.Text = view.Sum.ToString();
                        orderlistProducts = view.OrderListProducts;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                orderlistProducts = new List<OrderListProductViewModel>();
            }
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormOrderListProductCount>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (form.Model != null)
                {
                    if (id.HasValue)
                    {
                        form.Model.OrderListId = id.Value;
                    }
                    orderlistProducts.Add(form.Model);
                }
                LoadData();
            }
        }
        private void buttonUpd_Click(object sender, EventArgs e)
        {
            CalcSum();
            if (dataGridView.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormOrderListProductCount>();
                form.Model =
               orderlistProducts[dataGridView.SelectedRows[0].Cells[0].RowIndex];
                if (form.ShowDialog() == DialogResult.OK)
                {
                    orderlistProducts[dataGridView.SelectedRows[0].Cells[0].RowIndex] =
                   form.Model;
                    LoadData();
                    CalcSum();
                }
            }
            
        }
        private void buttonDel_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        orderlistProducts.RemoveAt(dataGridView.SelectedRows[0].Cells[0].RowIndex);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void buttonRef_Click(object sender, EventArgs e)
        {
            LoadData();
            CalcSum();
        }
        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Не указана стоимость закупки", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (orderlistProducts == null || orderlistProducts.Count == 0)
            {
                MessageBox.Show("Заполните компоненты", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<OrderListProductBindingModel> orderlistProductBM = new
               List<OrderListProductBindingModel>();
                for (int i = 0; i < orderlistProducts.Count; ++i)
                {
                    orderlistProductBM.Add(new OrderListProductBindingModel
                    {
                        Id = orderlistProducts[i].Id,
                        OrderListId = orderlistProducts[i].OrderListId,
                        Price = orderlistProducts[i].Price,
                        ProductName = orderlistProducts[i].ProductName,
                        ProductId = orderlistProducts[i].ProductId,
                        Count = orderlistProducts[i].Count,
                        Sum = orderlistProducts[i].Sum
                    });
                }
                if (id.HasValue)
                {
                    service.UpdElement(new OrderListBindingModel
                    {
                        Id = id.Value,
                        OrderListName = textBoxName.Text,
                        Sum = Convert.ToDecimal(textBoxPrice.Text),
                        OrderListProducts = orderlistProductBM
                    });
                }
                else
                {

                    service.AddElement(new OrderListBindingModel
                    {
                        OrderListName = textBoxName.Text,
                        Sum = Convert.ToDecimal(textBoxPrice.Text),
                        OrderListProducts = orderlistProductBM
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

        private void CalcSum()
        {
            decimal? sum = 0;

            for (int i = 0; i < orderlistProducts.Count; ++i)
            {

                sum += orderlistProducts[i].Sum;
            }
            textBoxPrice.Text = sum.ToString();
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog
            {
                Filter = "xls|*.xls|xlsx|*.xlsx"
            };
            var filePath = string.Empty;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                filePath = ofd.FileName;
            }
            List<OrderListProductBindingModel> OLP = service.ReadExcel(filePath);
           for (int i = 0; i < OLP.Count; i++)
            {
                orderlistProducts.Add(new OrderListProductViewModel
                {
                    ProductId = OLP[i].ProductId,
                    ProductName = OLP[i].ProductName,
                    Price = OLP[i].Price,
                    Count = OLP[i].Count,
                    Sum = OLP[i].Sum
                });
            }
            LoadData();
            CalcSum();
           
        }
    }
}