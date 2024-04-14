using System.Text.Json;
using System.Windows.Forms;

namespace WinFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {

            InitializeComponent();
        }
        public class Person
        {
            public string Name { get; set; }
            public string Surname { get; set; }
            public string Father_name { get; set; }
            public string Country { get; set; }
            public string City { get; set; }
            public string Number { get; set; }
            public string Birthday { get; set; }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var fileName = textBox1.Text.Trim() + ".json";

            if (!File.Exists(fileName))
            {
                MessageBox.Show("No data to load.");
                return;
            }

            var jsonData = File.ReadAllText(fileName);
            var data = JsonSerializer.Deserialize<Person>(jsonData);

            textBox2.Text = data.Name;
            textBox3.Text = data.Surname;
            textBox4.Text = data.Father_name;
            textBox5.Text = data.Country;
            textBox6.Text = data.City;
            textBox7.Text = data.Number;
            dateTimePicker1.Value = DateTime.ParseExact(data.Birthday, "dd MMMM yyyy, dddd", System.Globalization.CultureInfo.GetCultureInfo("az-AZ"));


        }

        private void button2_Click(object sender, EventArgs e)
        {
            var fileName = textBox1.Text.Trim() + ".json";
            var data = new
            {
                Name = textBox2.Text,
                Surname = textBox3.Text,
                Father_name = textBox4.Text,
                Country = textBox5.Text,
                City = textBox6.Text,
                Number = textBox7.Text,
                Birthday = dateTimePicker1.Value.ToString("dd MMMM yyyy, dddd")
            };

            var jsonData = JsonSerializer.Serialize(data);
            File.WriteAllText(fileName, jsonData);
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            dateTimePicker1.Value = DateTime.Now;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}