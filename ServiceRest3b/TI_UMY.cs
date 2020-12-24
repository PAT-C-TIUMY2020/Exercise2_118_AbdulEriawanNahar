using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace ServiceRest3b
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class TI_UMY : ITI_UMY
    {
        public string CountMahasiswa()
        {
            string msg = "gagal";
            SqlConnection sqlcon = new SqlConnection("Data Source = DESKTOP-EJH2D6F\\ARYA; Initial Catalog = TI UMY; Persist Security Info = True; User ID = sa; Password = arya@cool123");
            string query = String.Format("select Count(NIM) From Mahasiswa");
            string stm = "SELECT COUNT(Mahasiswa) From NIM";
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);

            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                Int32 count = (Int32)sqlcom.ExecuteScalar();
                sqlcon.Close();
                msg = "Jumlah Data " + count;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public string CreateMahasiswa(Mahasiswa mhs)
        {
            string msg = "GAGAL";
            SqlConnection sqlcon = new SqlConnection("Data Source = DESKTOP-EJH2D6F\\ARYA; Initial Catalog = TI UMY; Persist Security Info = True; User ID = sa; Password = arya@cool123");
            string query = String.Format("insert into Mahasiswa values ('{0}','{1}','{2}','{3}')", mhs.nama, mhs.nim, mhs.prodi, mhs.angkatan);
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                msg = "Sukses";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }


            return msg;
        }

     
        

        public string DeleteMahasiswa(string nim)
        {
            string msg = "gagal";
            Mahasiswa mhs = new Mahasiswa();
            SqlConnection sqlcon = new SqlConnection("Data Source = DESKTOP-EJH2D6F\\ARYA; Initial Catalog = TI UMY; Persist Security Info = True; User ID = sa; Password = arya@cool123");
            string query = String.Format("delete from Mahasiswa where NIM =  '" + nim + "'");
            SqlCommand sqlcom = new SqlCommand(query, sqlcon);
            try
            {
                sqlcon.Open();
                Console.WriteLine(query);
                sqlcom.ExecuteNonQuery();
                sqlcon.Close();
                msg = "Sukses";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
                msg = "GAGAL";
            }

            return msg;
        }

        public List<Mahasiswa> GetAllMahasiswa()
        {
            List<Mahasiswa> mahas = new List<Mahasiswa>();

            SqlConnection con = new SqlConnection("Data Source = DESKTOP-EJH2D6F\\ARYA; Initial Catalog = TI UMY; Persist Security Info = True; User ID = sa; Password = arya@cool123");
            string query = "select Nama, NIM, Prodi, Angkatan from Mahasiswa";
            SqlCommand com = new SqlCommand(query, con); //yang dikirim ke sql

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader(); //mendapatkan data yang telah dieksekusi, dari select, hasil query ditaro direader

                while (reader.Read())
                {
                    Mahasiswa mhs = new Mahasiswa();
                    mhs.nama = reader.GetString(0); //0 itu array pertama diambil dari iservice
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);

                    mahas.Add(mhs);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mahas;
        }

        public Mahasiswa GetMahasiswaByNIM(string nim)
        {
            Mahasiswa mhs = new Mahasiswa();
            SqlConnection con = new SqlConnection("Data Source = DESKTOP-EJH2D6F\\ARYA; Initial Catalog = TI UMY; Persist Security Info = True; User ID = sa; Password = arya@cool123");
            string query = String.Format("select Nama, NIM, Prodi, Angkatan from Mahasiswa where NIM = '{0}'", nim);
            SqlCommand com = new SqlCommand(query, con);

            try
            {
                con.Open();
                SqlDataReader reader = com.ExecuteReader();

                while (reader.Read())
                {
                    mhs.nama = reader.GetString(0);
                    mhs.nim = reader.GetString(1);
                    mhs.prodi = reader.GetString(2);
                    mhs.angkatan = reader.GetString(3);
                }
                con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(query);
            }
            return mhs;
        }



        

        public string UpdateMahasiswa(string nim, string nama, string prodi, string angkatan)
        {
            try
            {
                string constring = "Data Source = DESKTOP-EJH2D6F\\ARYA; Initial Catalog = TI UMY; Persist Security Info = True; User ID = sa; Password = arya@cool123";
                SqlConnection connection;
                SqlCommand com;

                string sql2 = "update Mahasiswa SET Nama ='" + nama + "', Prodi ='" + prodi + "', Angkatan ='" + angkatan + "' where NIM = '" + nim + "'";
                connection = new SqlConnection(constring);
                com = new SqlCommand(sql2, connection);
                connection.Open();
                com.ExecuteNonQuery();
                connection.Close();

                return "sukses";
            }
            catch (Exception e)
            {
                return e.ToString();
            }
        }
    }
}
