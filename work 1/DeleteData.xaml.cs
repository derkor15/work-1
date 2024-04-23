using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace work_1
{
    /// <summary>
    /// Логика взаимодействия для DeleteData.xaml
    /// </summary>
    public partial class DeleteData : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public DeleteData()
        {
            InitializeComponent();
        }
        private void Del_btn_Click(object sender, RoutedEventArgs e)
        {
            if (Del_txt.Text != "")
            {
                string sql = $"delete from Airplanes where airplane_id = {Del_txt.Text}";
                AeroportTable = new DataTable();

                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    adapter = new SqlDataAdapter(command);
                    MessageBox.Show("Данные удалены");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {

                    if (connection != null)
                        connection.Close();
                }


            }
            else
            {
                MessageBox.Show("Не все поля заполнены!");
            }
        }
    }
}
