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
    public partial class Authorization : Form
    {
        private readonly string connString = @"Data Source=Apteka.db;Version=3;";
        public Authorization()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            Form fAuthorization = new Registration();
            fAuthorization.Show();
            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
            this.Hide();
        }
        private void form_FormClosed(object sender, EventArgs e)
        { 
            Application.Exit();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM Users WHERE Login=@Login AND Parol=@Parol";

            using (SQLiteConnection connection = new SQLiteConnection(connString))
            {
                connection.Open();
                using (SQLiteCommand command = new SQLiteCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@Login", LoginTextBox.Text);
                    command.Parameters.AddWithValue("@Parol", PassTextBox.Text);
                    using (SQLiteDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("Авторизация прошла успешно");
                            // код для входа обычного пользователя
                            Form fAuthorization = new Home();
                            fAuthorization.Show();
                            fAuthorization.FormClosed += new FormClosedEventHandler(form_FormClosed);
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Логин или пароль были неверны.");
                        }
                    }
                }
            }
        }
    }
}
