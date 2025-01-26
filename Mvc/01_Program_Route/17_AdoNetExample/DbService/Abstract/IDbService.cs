using _17_AdoNetExample.Models;
using Microsoft.Data.SqlClient;

namespace _17_AdoNetExample.DbService.Abstract
{
    public interface IDbService
    {
        void ExecuteNonQuery(string query);//Sql sorgularını (Insert,Update,Delete) çalıştırır
        void ExecuteNonQuery(string query, SqlParameter[] parameters);//Parametrin sql sorgularını güvenli bir şekilde çalıştırır.
        List<Student> ExecuteReader(string query);//Select sorgularını çalıştırır ve veri setini bir liste olarak döndürür.
        object ExecuteScalar(string query);//Tek bir değer döndüren Sql sorguları Örneğin (Count Max Sum) aggregate function için kullanılır.
    }
}
