using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Motocliclisti.Entity;
using Motocliclisti.Repo;
using Motocliclisti.ServerC;
using Motocliclisti.Srv;

namespace Motocliclisti
{
    public partial class Main : Form
    {
        private Service _service;

        private ServerCom _serverCom;

        public Main(Service service)
        {
            _service = service;
            InitializeComponent();
            this.Load += new EventHandler(Main_Load);
            UpdateList();
        }

        private void UpdateList()
        {
            List<Probe> probesData = _service.getProbes();
            probes.Items.Clear();
            foreach (var probe in probesData)
            {
                probes.Items.Add(
                    probe.Code
                    + "->"
                    +
                    _service
                        .getParticipantsCount
                            (probe.Code)
                    + " participanți");
            }
        }

        private void Main_Load(object sender, EventArgs e)
        {
            try
            {
                _serverCom = new ServerCom(this);
            }
            catch (Exception ignored)
            {
                MessageBox.Show("Eroare la conectare server. Aplicația se va închide");
                Application.Exit();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String team = teamText.Text;
            List<Participant> participants = _service.GetParticipantsByTeam(team);

            if (participants == null)
            {
                MessageBox.Show("nu exista echipa asta");
                teamText.Text = "";
                return;
            }

            partic.Items.Clear();
            foreach (Participant participant in participants)
            {
                partic.Items.Add(participant.Name + "->" + participant.Capacity);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EntryParticipant entryParticipant = new EntryParticipant(_service);
            entryParticipant.Show();
        }

        public void Notify()
        {
            UpdateList();
        }
    }
}