using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Apteka
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Authorization());
        }
    }
    static class database
    {
        public static string connectionString = @"Data Source=Apteka.db;Integrated Security=False; MultipleActiveResultSets=True";

    }

    static class table_lekarstva
    {
        public static string main = "Medicines";
        public static string idMedicines = "idMedicines";
        public static string NameofMedicine = "NameofMedicine";
        public static string IndicationsForUse = "IndicationsForUse";
        public static string Contraindications = "Contraindications";
        public static string Manufacturer = "Manufacturer";
        public static string Type = "Type";

    }
    static class table_info
    {
        public static string main = "Pharmacyinformation";
        public static string idPharmacyinformation  = "idPharmacyinformation";
        public static string Pharmacynumber = "Pharmacynumber";
        public static string Pharmacyspecialization = "Pharmacyspecialization";
        public static string Area = "Area";
        public static string Telephone = "Telephone";

    }
    static class table_nalichielekarstva
    {
        public static string main = "Availabilityofmedicinesinthepharmacy";
        public static string IdAvailabilityofmedicines = "IdAvailabilityofmedicines";
        public static string Nameofmedicine = "Nameofmedicine";
        public static string Pharmacynumber = "Pharmacynumber";
        public static string Type = "Type";
        public static string Dosage = "Dosage";
        public static string Price = "Price";
        public static string Quantity = "Quantity";
        public static string Bestbeforedate = "Bestbeforedate";

    }
}
