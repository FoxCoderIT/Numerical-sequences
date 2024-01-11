using System;
using System.Windows.Forms;

namespace laba4
{
    public partial class Form : System.Windows.Forms.Form
    {
        private readonly SequenceContainer sequenceContainer = new SequenceContainer();

        public Form()
        {
            InitializeComponent();
            button1.Click += Button1_Click;
            button2.Click += Button2_Click;
            button3.Click += Button3_Click;
            button4.Click += Button4_Click;

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (TryGetSequenceParameters(out decimal start, out decimal step, out int end))
            {
                ArifmeticalSeq arifmeticalSeq = new ArifmeticalSeq(start, step, end);
                DisplaySequence(arifmeticalSeq);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if (TryGetSequenceParameters(out decimal start, out decimal step, out int end))
            {
                GeometricalSeq geometricalSeq = new GeometricalSeq(start, step, end);
                DisplaySequence(geometricalSeq);
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (TryGetSequenceParameters(out _, out _, out int end))
            {
                FibonnachSeq fibonnachSeq = new FibonnachSeq(end);
                DisplaySequence(fibonnachSeq);
            }
        }
        private void Button4_Click(object sender, EventArgs e)
        {
            // Очищаю попередні послідовності
            sequenceContainer.Clear();

            // Додаю нові послідовності
            decimal start, step;
            int end;

            if (TryGetSequenceParameters(out start, out step, out end))
            {
                ArifmeticalSeq arifmeticalSeq = new ArifmeticalSeq(start, step, end);
                sequenceContainer.AddSequence(arifmeticalSeq);
                DisplaySequence(arifmeticalSeq);
            }

            if (TryGetSequenceParameters(out start, out step, out end))
            {
                GeometricalSeq geometricalSeq = new GeometricalSeq(start, step, end);
                sequenceContainer.AddSequence(geometricalSeq);
                DisplaySequence(geometricalSeq);
            }

            if (TryGetSequenceParameters(out _, out _, out end))
            {
                FibonnachSeq fibonnachSeq = new FibonnachSeq(end);
                sequenceContainer.AddSequence(fibonnachSeq);
                DisplaySequence(fibonnachSeq);
            }

            // Викликаю Calculate після додавання нових послідовностей
            string result = sequenceContainer.Calculate();
            textBox4.Text = result;
        }

        private bool TryGetSequenceParameters(out decimal start, out decimal step, out int end)
        {
            if (decimal.TryParse(textBox1.Text, out start) &&
                decimal.TryParse(textBox2.Text, out step) &&
                int.TryParse(textBox3.Text, out end))
            {
                return true;
            }
            else
            {
                MessageBox.Show("Invalid input. Please enter valid numeric values.");
                start = step = 0;
                end = 0;
                return false;
            }
        }

        private void DisplaySequence(AbsSequence sequence)
        {
            Результат.Items.Clear();

            string[] sequenceArray = sequence.GetSequenceInfo().Split(new[] { "\r\n" }, StringSplitOptions.None);

            foreach (string item in sequenceArray)
            {
                Результат.Items.Add(item);
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}