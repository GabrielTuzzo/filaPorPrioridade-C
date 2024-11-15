using static maisUmTeste.Pessoa;
using System.Windows.Forms;

namespace maisUmTeste
{
    public partial class Form1 : Form
    {
        private Queue<Pessoa> itemQueue;
        public Form1()
        {
            InitializeComponent();
            itemQueue = new Queue<Pessoa>();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TransferirPaciente(listBox3);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nome = textBox1.Text;
            Pulseira corPulseira = radioButton1.Checked ? Pulseira.Verde : radioButton2.Checked ? Pulseira.Amarela
            : Pulseira.Vermelha;
            Sexo sexoValue = radioButton4.Checked ? Sexo.Masculino : Sexo.Feminino;

            if (!string.IsNullOrEmpty(nome))
            {
                Pessoa pessoa = new Pessoa { Nome = nome, SexoValue = sexoValue, CorPulseira = corPulseira };

                if (corPulseira == Pulseira.Verde)
                {
                    listBox1.Items.Add(pessoa);
                    itemQueue.Enqueue(pessoa);
                }
                else if (corPulseira == Pulseira.Amarela)
                {
                    listBox3.Items.Add(pessoa);
                    itemQueue.Enqueue(pessoa);
                }
                else
                {
                    listBox2.Items.Add(pessoa);
                    itemQueue.Enqueue(pessoa);
                }


                textBox1.Text = "";
            }
            else
            {
                MessageBox.Show("Insira um nome válido");
            }
        }
        private void TransferirPaciente(ListBox listBoxOrigem)
        {
            if (listBoxOrigem.Items.Count > 0)
            {
                Pessoa paciente = (Pessoa)listBoxOrigem.Items[0];
                listBoxOrigem.Items.RemoveAt(0);

                InserirEmOrdemDePrioridade(paciente);
            }
            else
            {
                MessageBox.Show("Não há pacientes para transferir.");
            }
        }
        private void InserirEmOrdemDePrioridade(Pessoa paciente)
        {
            bool added = false;

            for (int i = 0; i < listBox4.Items.Count; i++)
            {
                Pessoa item = (Pessoa)listBox4.Items[i];
                if (paciente.CorPulseira > item.CorPulseira)
                {
                    listBox4.Items.Insert(i, paciente);
                    added = true;
                    break;
                }
            }

            if (!added)
            {
                listBox4.Items.Add(paciente);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            TransferirPaciente(listBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TransferirPaciente(listBox2);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
        }
    }
}
