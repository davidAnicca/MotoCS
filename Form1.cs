using System;
using System.IO;
using System.Windows.Forms;
using Motocliclisti.Entity;
using Motocliclisti.Repo;
using Motocliclisti.Srv;

namespace Motocliclisti
{
    public partial class Form1 : Form
    {
        private log4net.ILog _logger =
            log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private string _constring;

        private Service _service;

        public Form1()
        {
            InitializeComponent();
            Uri configUri =
                new Uri("C:\\Users\\meres\\Desktop\\Fac\\MPP\\L02-Home\\Motocliclisti\\Motocliclisti\\log4net.config");
            log4net.Config.XmlConfigurator.Configure(configUri);
            _logger.Debug("Test");


            StreamReader reader = new StreamReader("bd.config");
            _constring = reader.ReadLine();
            _service = new Service(_constring);
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string username = userNameText.Text;
            string passwd = passwordText.Text;

            if (_service.CheckUser(username, passwd))
            {
                Main mainForm = new Main(_service);
                this.Hide();
                mainForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Utilizator/Parolă incorectă");
                userNameText.Text = "";
                passwordText.Text = "";
                return;
            }
        }
    }
}