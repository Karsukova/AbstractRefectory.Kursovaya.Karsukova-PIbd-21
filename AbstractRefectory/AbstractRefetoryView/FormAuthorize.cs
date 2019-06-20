using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Unity;

namespace AbstractRefetoryView
{
    public partial class FormAuthorize : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }

        public FormAuthorize()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBoxPassword.Text == "1234")
                {
                    var form = Container.Resolve<FormMain>();
                    form.ShowDialog();

                }
                else
                {
                    throw new Exception("Неверный пароль"); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Неверный пароль", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
    }
}
