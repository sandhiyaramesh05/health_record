using System;
using MySql.Data.MySqlClient;

class persnal_health_record
{

static string conn = "server=localhost;user=root;password=Reset@123;database=relevantzzz;port=3306";

public static void AddData()
{
    Console.WriteLine("Enter Patient Details");
    Console.WriteLine("---------------------");
    Console.WriteLine("Enter Patient ID :");
    int patient_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Patient Name :");
    string patient_name = Console.ReadLine();
    Console.WriteLine("Enter Patient Disease :");
    string patient_disease = Console.ReadLine();
    Console.WriteLine("Enter Appoinment Date :");
    DateTime appoinment_date = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Enter Consulting Doctor Name :");
    string consulting_doctor_name = Console.ReadLine();
    Console.WriteLine("Enter Patient Prescription :");
    string patient_prescription = Console.ReadLine();
    Console.WriteLine("Enter Patient Report :");
    string patient_report = Console.ReadLine();

    var connection = new MySqlConnection(conn);
    connection.Open();
    var cmd = connection.CreateCommand();

    cmd.CommandText = "insert into health_record values(@patient_id,@patient_name,@patient_disease,@appoinment_date,@consulting_doctor_name,@patient_prescription,@patient_report)";
    cmd.Parameters.AddWithValue("@patient_id", patient_id);
    cmd.Parameters.AddWithValue("@patient_name", patient_name);
    cmd.Parameters.AddWithValue("@patient_disease", patient_disease);
    cmd.Parameters.AddWithValue("@appoinment_date", appoinment_date);
    cmd.Parameters.AddWithValue("@consulting_doctor_name", consulting_doctor_name);
    cmd.Parameters.AddWithValue("@patient_prescription", patient_prescription);
    cmd.Parameters.AddWithValue("@patient_report", patient_report);
    cmd.ExecuteNonQuery();
    connection.Close();
    Console.WriteLine("Patient Record Added Successfully");

}

public static void SearchData()
{
    Console.WriteLine("Enter Patient ID :");
    int patient_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("--------------------");
    var connection = new MySqlConnection(conn);
    connection.Open();
    var cmd = connection.CreateCommand();
    cmd.CommandText = "select * from health_record where patient_id = @patient_id";
    cmd.Parameters.AddWithValue("@patient_id", patient_id);
    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine("Patient ID : " + reader["patient_id"]);
        Console.WriteLine("Patient Name : " + reader["patient_name"]);
        Console.WriteLine("Patient Disease : " + reader["patient_disease"]);
        Console.WriteLine("Appoinment Date : " + reader["appoinment_date"]);
        Console.WriteLine("Consulting Doctor Name : " + reader["consulting_doctor_name"]);
        Console.WriteLine("Patient Prescription : " + reader["patient_prescription"]);
        Console.WriteLine("Patient Report : " + reader["patient_report"]);
    }
    reader.Close();
    connection.Close();
}

public static void UpdateData()
{
    Console.WriteLine("Enter Patient ID :");
    int patient_id = Convert.ToInt32(Console.ReadLine());
    Console.WriteLine("Enter Patient Name :");
    string patient_name = Console.ReadLine();
    Console.WriteLine("Enter Patient Disease :");
    string patient_disease = Console.ReadLine();
    Console.WriteLine("Enter Appoinment Date :");
    DateTime appoinment_date = Convert.ToDateTime(Console.ReadLine());
    Console.WriteLine("Enter Consulting Doctor Name :");
    string consulting_doctor_name = Console.ReadLine();
    Console.WriteLine("Enter Patient Prescription :");
    string patient_prescription = Console.ReadLine();
    Console.WriteLine("Enter Patient Report :");
    string patient_report = Console.ReadLine();

    var connection = new MySqlConnection(conn);
    connection.Open();
    var cmd = connection.CreateCommand();
    cmd.CommandText = "update health_record set patient_name = @patient_name, patient_disease = @patient_disease, appoinment_date = @appoinment_date, consulting_doctor_name = @consulting_doctor_name, patient_prescription = @patient_prescription, patient_report = @patient_report where patient_id = @patient_id";
    cmd.Parameters.AddWithValue("@patient_id", patient_id);
    cmd.Parameters.AddWithValue("@patient_name", patient_name);
    cmd.Parameters.AddWithValue("@patient_disease", patient_disease);
    cmd.Parameters.AddWithValue("@appoinment_date", appoinment_date);
    cmd.Parameters.AddWithValue("@consulting_doctor_name", consulting_doctor_name);
    cmd.Parameters.AddWithValue("@patient_prescription", patient_prescription);
    cmd.Parameters.AddWithValue("@patient_report", patient_report);
    cmd.ExecuteNonQuery();
    connection.Close();
    Console.WriteLine("Patient Record Updated Successfully");

}


public static void DeleteData()
{
    Console.WriteLine("Enter Patient ID :");
    int patient_id = Convert.ToInt32(Console.ReadLine());
    var connection = new MySqlConnection(conn);
    connection.Open();
    var cmd = connection.CreateCommand();
    cmd.CommandText = "delete from health_record where patient_id = @patient_id";
    cmd.Parameters.AddWithValue("@patient_id", patient_id);
    cmd.ExecuteNonQuery();
    connection.Close();
    Console.WriteLine("Patient Record Deleted Successfully");
}

public static void ViewData()
{
    var connection = new MySqlConnection(conn);
    connection.Open();
    var cmd = connection.CreateCommand();
    cmd.CommandText = "select * from health_record";
    var reader = cmd.ExecuteReader();
    while (reader.Read())
    {
        Console.WriteLine("Patient ID : " + reader["patient_id"]);
        Console.WriteLine("Patient Name : " + reader["patient_name"]);
        Console.WriteLine("Patient Disease : " + reader["patient_disease"]);
        Console.WriteLine("Appoinment Date : " + reader["appoinment_date"]);
        Console.WriteLine("Consulting Doctor Name : " + reader["consulting_doctor_name"]);
        Console.WriteLine("Patient Prescription : " + reader["patient_prescription"]);
        Console.WriteLine("Patient Report : " + reader["patient_report"]);
        Console.WriteLine("---------------------");
    }
    reader.Close();
    connection.Close();
}


}

class Program
{
    public static void Main(String[]args)
    {
        while (true)
        {
            Console.WriteLine("Welcome to Health Record Management System");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1.Add Data");
            Console.WriteLine("2.Search Data");
            Console.WriteLine("3.Update Data");
            Console.WriteLine("4.Delete Data");
            Console.WriteLine("5.View Data");
            Console.WriteLine("6.Exit");
            Console.WriteLine("Enter Your Choice");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    persnal_health_record.AddData();
                    break;
                case 2:
                    persnal_health_record.SearchData();
                    break;
                case 3:
                    persnal_health_record.UpdateData();
                    break;
                case 4:
                    persnal_health_record.DeleteData();
                    break;
                case 5:
                    persnal_health_record.ViewData();
                    break;
                case 6:
                    Console.WriteLine("Exit");
                    break;
                    
                default:
                    Console.WriteLine("Invalid Choice");
                    break;
            }
        }

    }

}