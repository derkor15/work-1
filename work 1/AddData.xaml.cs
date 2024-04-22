using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Configuration;
namespace work_1
{
    /// <summary>
    /// Логика взаимодействия для AddData.xaml
    /// </summary>
    public partial class AddData : Page
    {
        string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        SqlDataAdapter adapter;
        DataTable AeroportTable;
        SqlConnection connection = null;
        public AddData()
        {
            InitializeComponent();
        }

        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            if(air_name_box.Text!=""&&date_box.Text!=""&&capacity_box.Text!=""&&to_box.Text!=""&&flight_hours_box.Text!="")
            {
                string sql = $"insert into Airplanes values ('{air_name_box.Text}','{date_box.Text}',{capacity_box.Text},'{to_box.Text}',{flight_hours_box.Text})";
                AeroportTable = new DataTable();

                try
                {
                    connection = new SqlConnection(connectionString);
                    connection.Open();
                    SqlCommand command = new SqlCommand(sql, connection);
                    command.ExecuteNonQuery();
                    adapter = new SqlDataAdapter(command);
                    MessageBox.Show("Данные добавлены");
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
