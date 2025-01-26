using _17_AdoNetExample.DbService.Abstract;
using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbService.Concrete
{
    public class DbService : IDbService
    {
        private readonly string _connectionString;
        public DbService(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");//appsettings.json dosyasındaki bağlantı dizesini alır.
        }

        //Sql sorgularını(Update,Insert,Delete) çalıştırmak için kullanılır.
        public void ExecuteNonQuery(string query)
        {
            using (var connetion = new SqlConnection(_connectionString))//Sql Bağlantısını oluşturur.
            {
                using (var command = new SqlCommand(query, connetion))//Sql komutunu oluşturur.
                {
                    connetion.Open();//Bağlantı açılır.
                    command.ExecuteNonQuery();//Komut çalıştırılır, etkilenen satır sayısını döndürür.
                }
            }
        }
        //Parametrik Sql sorgularını çalıştırmak için kullanılır.Sql Injection(Bağımlılık) riskini azaltır.
        public void ExecuteNonQuery(string query, SqlParameter[] parameters)
        {
            using (var connetion = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connetion))
                {
                    if (parameters!=null)
                    {
                        command.Parameters.AddRange(parameters);//Parametreler varsa ekle.
                    }
                    connetion.Open();
                    command.ExecuteNonQuery();
                }

            }
        }

        //Select Sorgularını  Çalıştırmak ve Veri Setini Döndürmek İçin Kullanılır.
        public List<Student> ExecuteReader(string query)
        {
            var result = new List<Student>();//Sonuçlar için bir liste oluştur.
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    using (var reader = command.ExecuteReader())//Veri okuyucu oluşturulur.
                    {
                        while (reader.Read())//Okunan her satır için döngü çalışır.
                        {
                            var model = new Student()
                            {
                                FirstName = reader["FirstName"].ToString(),//Ad bilgisini alır
                                LastName = reader["LastName"].ToString(),//Soyad bilgisini alır
                                Age = Convert.ToInt32(reader["Age"])//Yaş bilgisini alır
                            };
                            result.Add(model);//Öğrenci modeli listeye eklenir
                        }
                    }
                }
            }
            return result;//Öğrenci listesi döndürülür.
        }

        //Tek bir Değer döndüren Sql sorguları için kullanılan yapı Aggragete functionlar gibi(Sum Count Max Min Avg)
        public object ExecuteScalar(string query)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                using (var command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    return command.ExecuteScalar();//Tek bir değer döndürülür.
                }
            }
        }
    }
}
