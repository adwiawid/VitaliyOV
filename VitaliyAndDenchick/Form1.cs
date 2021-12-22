using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using Microsoft.VisualBasic;
using LiveCharts;
using LiveCharts.Wpf;

namespace DataBase
{
    public partial class Form1 : Form
    {
        string connectionString = @"Provider=Microsoft.Jet.OleDb.4.0;Data Source = bd.mdb";

        OleDbConnection connection;

        public Form1()
        {
            InitializeComponent();
        }       

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new OleDbConnection(connectionString);            connection.Open();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            connection.Close();
        }

        private void btnSelectAll_Click(object sender, EventArgs e)
        {
            string commandString = "SELECT * FROM [Корпуса]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(commandString, connection);            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView2.DataSource = table;
        }

        private void btn_input_t1_Click(object sender, EventArgs e)
        {
            string inpFrame = Microsoft.VisualBasic.Interaction.InputBox("Введите номер корпуса");
            string inpAudience = Microsoft.VisualBasic.Interaction.InputBox("Введите аудиторию");
            string inpResponsible = Microsoft.VisualBasic.Interaction.InputBox("Введите ответсвенного");
            string inpDateStart = Microsoft.VisualBasic.Interaction.InputBox("Введите дату начала");
            string inpDateFinish = Microsoft.VisualBasic.Interaction.InputBox("Введите дату окончания");
            string inpResult = Microsoft.VisualBasic.Interaction.InputBox("Введите результат");

            string commandString = $"INSERT INTO [Корпуса] ([N корпуса], [N аудитории], [Ответсвенный], [Дата начала], [Дата окончания], [Результат]) VALUES ('{inpFrame}', '{inpAudience}', '{inpResponsible}', '{inpDateStart}', '{inpDateFinish}', '{inpResult}')";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_upp_t1_Click(object sender, EventArgs e)
        {
            string inpResponsible = Microsoft.VisualBasic.Interaction.InputBox("Введите ответсвенного");
            string inpAudience = Microsoft.VisualBasic.Interaction.InputBox("Введите аудиторию");

            string commandString = $"UPDATE [Корпуса] SET [N аудитории] = '{inpAudience}' WHERE [Ответсвенный] = '{inpResponsible}'";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_del_t1_Click(object sender, EventArgs e)
        {
            string inpResponsible = Microsoft.VisualBasic.Interaction.InputBox("Введите ответсвенного");

            string commandString = $"DELETE FROM [Корпуса] WHERE [Ответсвенный] = '{inpResponsible}' ";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_sel_t2_Click(object sender, EventArgs e)
        {
            string commandString = "SELECT * FROM [Оборудование]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(commandString, connection);            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView1.DataSource = table;
        }

        private void btn_inp_t2_Click(object sender, EventArgs e)
        {
            string inpИНВ = Microsoft.VisualBasic.Interaction.InputBox("Введите дату ИНВ");
            string inpType = Microsoft.VisualBasic.Interaction.InputBox("Введите тип");
            string inpDev = Microsoft.VisualBasic.Interaction.InputBox("Введите производителя");
            string inpValue = Microsoft.VisualBasic.Interaction.InputBox("Введите количество");
            
            string commandString = $"INSERT INTO [Оборудование] ([ИНВ N], [Тип], [Производитель], [Кол-во]) VALUES ('{inpИНВ}', '{inpType}', '{inpDev}', '{inpValue}')";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_upp_t2_Click(object sender, EventArgs e)
        {
            string inpDev = Microsoft.VisualBasic.Interaction.InputBox("Введите производителя");
            string inpType = Microsoft.VisualBasic.Interaction.InputBox("Введите тип");

            string commandString = $"UPDATE [Оборудование] SET [Тип] = '{inpType}' WHERE [Производитель] = '{inpDev}'";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_del_t2_Click(object sender, EventArgs e)
        {
            string inpDev = Microsoft.VisualBasic.Interaction.InputBox("Введите производителя");

            string commandString = $"DELETE FROM [Оборудование] WHERE [Производитель] = '{inpDev}' ";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_sel_t3_Click(object sender, EventArgs e)
        {
            string commandString = "SELECT * FROM [Сотрудники]";
            OleDbDataAdapter adapter = new OleDbDataAdapter(commandString, connection);            DataTable table = new DataTable();

            adapter.Fill(table);

            dataGridView3.DataSource = table;
        }

        private void btn__inp_t3_Click(object sender, EventArgs e)
        {

            string inpName = Microsoft.VisualBasic.Interaction.InputBox("Введите ФИО");
            string inpPosition = Microsoft.VisualBasic.Interaction.InputBox("Введите должность");
            string inpAge = Microsoft.VisualBasic.Interaction.InputBox("Введите возраст");

            string commandString = $"INSERT INTO [Сотрудники] ([ФИО], [Должность], [Возраст]) VALUES ('{inpName}', '{inpPosition}', '{inpAge}')";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_upp_t3_Click(object sender, EventArgs e)
        {
            string inpName = Microsoft.VisualBasic.Interaction.InputBox("Введите ФИО");
            string inpPosition = Microsoft.VisualBasic.Interaction.InputBox("Введите должность");

            string commandString = $"UPDATE [Сотрудники] SET [Должность] = '{inpPosition}' WHERE [ФИО] = '{inpName}'";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void btn_del_t3_Click(object sender, EventArgs e)
        {
            string inpName = Microsoft.VisualBasic.Interaction.InputBox("Введите ФИО");

            string commandString = $"DELETE FROM [Сотрудники] WHERE [ФИО] = '{inpName}' ";
            OleDbCommand command = new OleDbCommand(commandString, connection);
            command.ExecuteNonQuery();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChartValues<int> parabola = new ChartValues<int>();

            List<string> x_values = new List<string>();
            List<string> y_values = new List<string>();

            int[] x = new int[] { 2, 3, 4, 1, 6 };

            for (int i = 0; i < x.Length; i++)
            {
                parabola.Add(x[i] * x[i]);
                x_values.Add(x[i].ToString());
                y_values.Add((x[i] * x[i]).ToString());
            }

            cartesianChart1.AxisX.Clear();
            cartesianChart1.AxisX.Add(new Axis()
            {
                Title = "Ось Х",
                Labels = x_values
            });

            cartesianChart1.AxisY.Clear();
            cartesianChart1.AxisY.Add(new Axis()
            {
                Title = "Ось Y",
                Labels = y_values
            });

            LineSeries line = new LineSeries();
            line.Title = "Кривая";
            line.Values = parabola;

            SeriesCollection series = new SeriesCollection();
            series.Add(line);

            cartesianChart1.Series = series;
            cartesianChart1.LegendLocation = LegendLocation.Top;
        }

        private void График_Click(object sender, EventArgs e)
        {

        }
    }
}
