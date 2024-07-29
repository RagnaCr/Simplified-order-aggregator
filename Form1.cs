using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WindowsFormsApp5
{
    public partial class Form1 : Form
    {
        public Order order;
        public List<Order> orders;
        public Form1()
        {
            InitializeComponent();
            order = new Order();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            HashSet<string> uniqueCooks = new HashSet<string>();
            try
            {
                string jsonFromFile = File.ReadAllText("orders.json");
                orders = JsonConvert.DeserializeObject<List<Order>>(jsonFromFile);
            }
            catch (FileNotFoundException ex)
            {
                MessageBox.Show($"The 'orders.json' file is not found. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            }
            catch (JsonException ex)
            {
                MessageBox.Show($"An error occurred during JSON deserialization. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred. {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); Application.Exit();
            }

            foreach (var order in orders)
            {
                comboBox1.Items.Add(order.CafeName);
            }
            foreach (var order in orders)
            {
                foreach (var dish in order.Dishes)
                {
                    string fullName = dish.FirstName + " " + dish.LastName;
                    if (!uniqueCooks.Contains(fullName))
                    {
                        comboCook.Items.Add(fullName);
                        uniqueCooks.Add(fullName);
                    }
                }
            }
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = new Order(comboBox1.SelectedItem.ToString());
            comboBoxDish.Items.Clear();
            comboBoxDish.Text = "Choose a dish...";
            comboDel1.Items.Clear();
            label2.Text = "";

            foreach (var ord in orders)
            {
                if (ord.CafeName == order.CafeName)
                {
                    foreach (var dish in ord.Dishes)
                    {
                        comboBoxDish.Items.Add(dish.Name);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e) // Add to order
        {
            if (comboBoxDish.SelectedItem != null)
            { 
                string selectedDishName = comboBoxDish.SelectedItem.ToString();

                Dish selectedDish = CreateDishByName(selectedDishName);

                order.AddDish(selectedDish);
                comboDel1.Items.Add(selectedDish.Name);
                ChangeInfo(fourstates, order);
            }
        }
        private void button2_Click(object sender, EventArgs e) // delete from order
        {
            if (comboDel1.SelectedItem != null)
            {
                string nameOfdel = comboDel1.SelectedItem.ToString();
                order.RemoveDish(nameOfdel);
                ChangeInfo(fourstates, order);
                comboDel1.Items.Remove(comboDel1.SelectedItem);
                comboDel1.Text = "Choose to delete...";
            }
        }

        private Dish CreateDishByName(string name)
        {
            foreach (var ord in orders)
            {
                foreach (var dish in ord.Dishes)
                {
                    if (name == dish.Name)
                    {
                        return dish;
                    }
                }
            }
            return new Dish();
        }
        private Cook CreateCookByName(string cookName)
        {
            foreach (var ord in orders)
            {
                foreach (var dish in ord.Dishes)
                {
                    if (cookName == dish.FirstName + " " + dish.LastName)
                    {
                        return new Cook(dish.FirstName, dish.LastName);
                    }
                }
            }
            return new Cook();
            
        }
        private int fourstates = 0;
        private void button3_Click(object sender, EventArgs e)//short-full info
        {
            label2.Text = "";
            if (fourstates == 0)
            {
                label2.Text += order.GetOrderInfo();
                fourstates = 1;
            }
            else if(fourstates == 1)
            {
                label2.Text += order.GetShortOrderInfo();
                fourstates = 2;
            }
            else if (fourstates == 2)
            {
                for (int i = 0; i < order.Count(); i++)
                {
                    label2.Text += order[i].GetInfo() + "\n"; ;
                }
                fourstates = 3;
            }
            else if (fourstates == 3)
            {
                for (int i = 0; i < order.Count(); i++)
                {
                    label2.Text += order[i].GetShortInfo() + "\n"; ;
                }
                fourstates = 0;
            }
        }
        private void ChangeInfo(int four, Order order)
        {
            label2.Text = "";
            if (four == 0) { four = 3; } else { four--; }
            switch (four)
            {
                case 0:
                    label2.Text = order.GetOrderInfo();
                    break;
                case 1:
                    label2.Text = order.GetShortOrderInfo();
                    break;
                case 2:
                    for (int i = 0; i < order.Count(); i++)
                    {
                        label2.Text += order[i].GetInfo() + "\n";
                    }
                    break;
                case 3:
                    for (int i = 0; i < order.Count(); i++)
                    {
                        label2.Text += order[i].GetShortInfo() + "\n";
                    }
                    break;
                default:
                    break;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            order.SortDishesByCost();
            ChangeInfo(fourstates, order);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (comboCook.SelectedItem != null)
            {
                Order temp = order.FilterByCook(CreateCookByName(comboCook.SelectedItem.ToString()));
                ChangeInfo(fourstates, temp);
            }
        }

        private void button6_Click(object sender, EventArgs e) //Save one order to file
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "JSON files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog.Title = "Save JSON File";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string fileName = saveFileDialog.FileName;

                try
                {
                    string jsonToSave = JsonConvert.SerializeObject(order, Formatting.Indented);
                    File.WriteAllText(fileName, jsonToSave);
                    MessageBox.Show($"File {fileName} saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred while saving the file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private int iter = 1;
        private List<Order> clones = new List<Order>();
        private void buttonPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (order.CafeName != "Unknown")
                {
                    comboOrders.Items.Add($"Order{iter}");
                    clones.Add((Order)order.Clone());
                    iter++;
                    label2.Text = "";
                    order = new Order();
                    comboDel1.Items.Clear(); comboDel1.Text = "Choose to delete...";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void comboOrders_SelectedIndexChanged(object sender, EventArgs e)
        {
            order = (Order)clones[comboOrders.SelectedIndex].Clone();
            ChangeInfo(fourstates, order);
            button1.Enabled = false;
            button2.Enabled = false;
            comboBoxDish.Text = "Choose a dish...";
            comboBox1.Text = "Choose a cafe...";
            buttonPay.Text = "Clone";
        }

        private void button7_Click(object sender, EventArgs e) // Realse pay menu
        {
            comboOrders.Text = "Choose payed order...";
            order = new Order();
            buttonPay.Text = "Pay";
            label2.Text = "";
            button1.Enabled = true;
            button2.Enabled = true;
        }
    }
}
