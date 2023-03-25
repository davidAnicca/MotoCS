using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Motocliclisti.Entity;
using Motocliclisti.Repo;
using Motocliclisti.Srv;

namespace Motocliclisti
{
    public partial class Main : Form
    {
        private Service _service;

        public Main(Service service)
        {
            _service = service;
            InitializeComponent();

            List<Probe> probesData = _service.getProbes();
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

        private void button1_Click(object sender, EventArgs e)
        {
            String team = teamText.Text;
            List<Participant> participants = _service.getParticipantsByTeam(team);

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
    }
}