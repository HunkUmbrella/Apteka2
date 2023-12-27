using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class NalichieLekarstva : Form
    {
        private SQLiteConnection Apteka;
        public NalichieLekarstva()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Home();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
        private void form_FormClosed(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private  async void NalichieLekarstva_Load(object sender, EventArgs e)
        {
            Apteka = new SQLiteConnection(database.connectionString);
            await Apteka.OpenAsync();
            LoadingTable();
        }
        private async void LoadingTable()
        {
            {
                dataGridView1.Rows.Clear();
                SQLiteDataReader sqlReader = null;
                SQLiteCommand command = new SQLiteCommand($"SELECT * FROM [{table_nalichielekarstva.main}]", Apteka);
                List<string[]> data = new List<string[]>();
                try
                {
                    sqlReader = (SQLiteDataReader)await command.ExecuteReaderAsync();
                    while (await sqlReader.ReadAsync())
                    {
                        data.Add(new string[8]);
                        //Указываем столбцы
                        data[data.Count - 1][0] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.IdAvailabilityofmedicines}"]}");
                        data[data.Count - 1][1] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Nameofmedicine}"]}");
                        data[data.Count - 1][2] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Pharmacynumber}"]}");
                        data[data.Count - 1][3] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Type}"]}");
                        data[data.Count - 1][4] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Dosage}"]}");
                        data[data.Count - 1][5] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Price}"]}");
                        data[data.Count - 1][6] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Quantity}"]}");
                        data[data.Count - 1][7] = Convert.ToString($"{sqlReader[$"{table_nalichielekarstva.Bestbeforedate}"]}");

                        data[data.Count - 1][5] = Convert.ToDecimal(sqlReader[$"{table_nalichielekarstva.Price}"]).ToString("C");

                    }

                    foreach (string[] s in data)
                    {
                        dataGridView1.Rows.Add(s);
                    }
                    dataGridView1.ClearSelection();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"{ex.Message}", $"{ex.Source}");
                }
                finally
                {
                    if (sqlReader != null)
                        sqlReader.Close();
                }
            }

        }
    }
}
