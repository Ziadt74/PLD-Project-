using com.calitha.goldparser;

namespace ProgramingLanguageDesign_PLD_
{
    public partial class Form1 : Form
    {
        MyParser parser;
        public Form1()
        {
            InitializeComponent();
            parser = new MyParser("PLD.cgt", listBox1,listBox2);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            listBox2.Items.Clear();
            parser.Parse(textBox1.Text);
        }
    }
}
