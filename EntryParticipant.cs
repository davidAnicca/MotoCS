using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Motocliclisti.Entity;
using Motocliclisti.Srv;

namespace Motocliclisti
{
    public partial class EntryParticipant : Form
    {

        private Service _service;

        public EntryParticipant(Service service)
        {
            _service = service;
            InitializeComponent();

            List<Probe> probes = _service.getProbes();
            foreach (Probe probe in probes)
            {
                CapacityChoice.Items.Add(probe.Code);
            }

            List<Team> teams = _service.GetTeams();
            foreach (Team team in teams)
            {
                teamChoice.Items.Add(team.Name);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = nameText.Text;
            string team = teamChoice.Text;
            string capacity = CapacityChoice.Text;

            _service.AddParticipant(name, team, capacity);
            MessageBox.Show("Înscris cu succes!");
            this.Close();
        }
    }
}