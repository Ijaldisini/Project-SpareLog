using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Project_SpareLog.App.Core;
using Project_SpareLog.Model;
using Project_SpareLog.Core.Interface;

namespace Project_SpareLog.Controller
{
    public class C_Barang : IBarangService
    {
        private DatabaseWrapper db;

        public C_Barang()
        {
            db = new DatabaseWrapper();
        }
        public DataTable GetAllBarang()
        {
            string query = "SELECT * FROM barang";
            return db.queryExecutor(query);
        }

        public int GetNextIdBarang()
        {
            string query = "SELECT MAX(id_barang) AS max_id FROM barang";
            DataTable dt = db.queryExecutor(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["max_id"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["max_id"]) + 1;
            }
            return 1;
        }

        public int? GetIdBarangByNama(string nama)
        {
            string query = $"SELECT id_barang FROM barang WHERE nama_barang = '{nama}'";
            DataTable dt = db.queryExecutor(query);

            if (dt.Rows.Count > 0 && dt.Rows[0]["id_barang"] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0]["id_barang"]);
            }
            return null;
        }

        public string GetNamaBarangById(int id)
        {
            string query = $"SELECT nama_barang FROM barang WHERE id_barang = '{id}'";
            DataTable dt = db.queryExecutor(query);

            if (dt.Rows.Count > 0)
            {
                return dt.Rows[0]["nama_barang"].ToString();
            }
            return null;
        }

        public DataTable GetSuppliers()
        {
            return db.queryExecutor("SELECT id_supplier, nama_supplier FROM supplier");
        }

        public bool SimpanBarang(M_Barang barang)
        {
            if (IsBarangExists(barang.id_barang))
            {
                string updateQuery = "UPDATE barang SET stok_barang = stok_barang + @tambahStok WHERE id_barang = @id";
                var updateParams = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@tambahStok", barang.stok_barang),
                    new NpgsqlParameter("@id", barang.id_barang)
                };
                return db.ExecuteNonQuery(updateQuery, updateParams) > 0;
            }
            else
            {
                string insertQuery = "INSERT INTO barang (id_barang, nama_barang, stok_barang, harga_barang, hpp, supplier_id_supplier) " +
                                     "VALUES (@id, @nama, @stok, @harga, @hpp, @supplier)";
                var insertParams = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@id", barang.id_barang),
                    new NpgsqlParameter("@nama", barang.nama_barang),
                    new NpgsqlParameter("@stok", barang.stok_barang),
                    new NpgsqlParameter("@harga", barang.harga_barang),
                    new NpgsqlParameter("@hpp", barang.hpp),
                    new NpgsqlParameter("@supplier", barang.supplier_id_supplier)
                };
                return db.ExecuteNonQuery(insertQuery, insertParams) > 0;
            }
        }

        public bool IsBarangExists(int idBarang)
        {
            string query = "SELECT COUNT(*) FROM barang WHERE id_barang = @id";
            var parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@id", idBarang)
            };
            DataTable dt = db.queryExecutor(query, parameters);
            return Convert.ToInt32(dt.Rows[0][0]) > 0;
        }

        public DataTable GetBarangPerluRestock()
        {
            string query = @"SELECT b.id_barang, b.nama_barang, b.stok_barang, b.harga_barang, b.hpp, s.nama_supplier
                    FROM barang b
                    JOIN supplier s ON b.supplier_id_supplier = s.id_supplier
                    WHERE b.stok_barang < 10
                    ORDER BY b.stok_barang ASC";
            return db.queryExecutor(query);
        }

        public bool HapusBarang(int idBarang)
        {
            string query = "DELETE FROM barang WHERE id_barang = @id";
            var parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@id", idBarang)
            };
            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
