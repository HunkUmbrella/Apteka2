using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    public partial class Zaprosi : Form
    {
        private const string connectionString = "Data Source=Apteka.db;Version=3;";
        public Zaprosi()
        {
            InitializeComponent();
        }

        private void RegistrationButton_Click(object sender, EventArgs e)
        {
            string query = "SELECT m.IndicationsForUse, COUNT(*) AS Frequency " +
                           "FROM Availabilityofmedicinesinthepharmacy a " +
                           "JOIN Medicines m ON a.Nameofmedicine = m.NameofMedicine " +
                           "JOIN Pharmacyinformation p ON a.Pharmacynumber = p.PharmacyNumber " +
                           "WHERE p.Area = 'Киевский' " +
                           "GROUP BY m.IndicationsForUse " +
                           "ORDER BY Frequency DESC " +
                           "LIMIT 1;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    StringBuilder results = new StringBuilder();
                    while (reader.Read())
                    {
                        string indicationsForUse = reader.GetString(0);
                        int frequency = reader.GetInt32(1);
                        string result = $"{indicationsForUse}: {frequency}";
                        results.AppendLine(result);
                    }

                    label1.Text = results.ToString();
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                Console.WriteLine(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "SELECT SUM(CAST(t.\"Price\" AS DECIMAL) * CAST(t.\"Quantity\" AS INTEGER)) AS \"Total Loss\" " +
                   "FROM \"Availabilityofmedicinesinthepharmacy\" AS t " +
                   "WHERE t.\"Pharmacynumber\" = '47' AND DATE(t.\"Bestbeforedate\") <= DATE('now', '+1 month');";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    object result = command.ExecuteScalar();

                    if (result != null && result != DBNull.Value)
                    {
                        decimal totalLoss = Convert.ToDecimal(result);
                        label1.Text = $"Total Loss: {totalLoss}";

                        // Дополнительный код для обработки результата, если необходимо
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                Console.WriteLine(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string query = "SELECT P.\"Pharmacynumber\", A.\"Price\" " +
                  "FROM \"Availabilityofmedicinesinthepharmacy\" A " +
                  "JOIN \"Medicines\" M ON LOWER(A.\"Nameofmedicine\") = LOWER(M.\"NameofMedicine\") " +
                  "JOIN \"Pharmacyinformation\" P ON A.\"Pharmacynumber\" = P.\"Pharmacynumber\" " +
                  "WHERE LOWER(M.\"NameofMedicine\") = 'Анальгин' " +
                  "ORDER BY CAST(A.\"Price\" AS INTEGER) " +
                  "LIMIT 1;";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (reader.Read())
                    {
                        string pharmacyNumber = reader["Pharmacynumber"].ToString();
                        decimal price = Convert.ToDecimal(reader["Price"]);

                        label1.Text = $"Lowest price: {price} in pharmacy {pharmacyNumber}";

                        // Дополнительный код для обработки результата, если необходимо
                    }
                    else
                    {
                        label1.Text = "No results found";
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                Console.WriteLine(ex.Message);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string query = "SELECT M.\"NameofMedicine\" " +
                   "FROM \"Medicines\" M " +
                   "WHERE M.\"IndicationsForUse\" LIKE '%цирроз печени%' " +
                   " OR M.\"IndicationsForUse\" LIKE '%ветрянка%';";

            try
            {
                using (SQLiteConnection connection = new SQLiteConnection(connectionString))
                {
                    connection.Open();
                    SQLiteCommand command = new SQLiteCommand(query, connection);
                    SQLiteDataReader reader = command.ExecuteReader();

                    if (reader.HasRows)
                    {
                        StringBuilder resultBuilder = new StringBuilder();

                        while (reader.Read())
                        {
                            string medicineName = reader["NameofMedicine"].ToString();
                            resultBuilder.AppendLine(medicineName);
                        }

                        label1.Text = resultBuilder.ToString();

                        // Дополнительный код для обработки результата, если необходимо
                    }
                    else
                    {
                        label1.Text = "No results found";
                    }
                }
            }
            catch (Exception ex)
            {
                // Обработка исключения
                Console.WriteLine(ex.Message);
            }
        }
    }
}