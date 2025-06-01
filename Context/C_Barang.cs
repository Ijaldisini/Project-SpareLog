using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Project_SpareLog.App.Core;
using Project_SpareLog.Core.Interface;
using Project_SpareLog.Core.Model;

namespace Project_SpareLog.Context
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
            string query = "SELECT * FROM barang WHERE terhapus = false";
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

        public bool TambahAktivitasStok(int idBarang, int idSupplier, int jumlah, int hpp_saat_ini)
        {
            string query = @"INSERT INTO aktivitas_stok 
                    (barang_id_barang, supplier_id_supplier, jumlah_barang, hpp_saat_ini, tanggal) 
                    VALUES (@idBarang, @idSupplier, @jumlah, @hpp_saat_ini, @tanggal)";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@idBarang", idBarang),
                new NpgsqlParameter("@idSupplier", idSupplier),
                new NpgsqlParameter("@jumlah", jumlah),
                new NpgsqlParameter("@hpp_saat_ini", hpp_saat_ini),
                new NpgsqlParameter("@tanggal", DateTime.Now)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SimpanBarang(M_Barang barang)
        {
            if (IsBarangExists(barang.id_barang))
            {
                MessageBox.Show("Barang dengan ID ini sudah ada.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
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
                bool success = db.ExecuteNonQuery(insertQuery, insertParams) > 0;

                if (success)
                {
                    TambahAktivitasStok(barang.id_barang, barang.supplier_id_supplier, barang.stok_barang, barang.hpp);
                }
                return success;
            }
        }

        public bool UpdateStokBarang(int idBarang, int jumlahStokBaru, int hppBaru)
        {
            string getInfoQuery = "SELECT supplier_id_supplier FROM barang WHERE id_barang = @id";
            var getInfoParams = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@id", idBarang)
            };
            DataTable dt = db.queryExecutor(getInfoQuery, getInfoParams);

            if (dt.Rows.Count == 0)
                return false;

            int supplierId = Convert.ToInt32(dt.Rows[0]["supplier_id_supplier"]);

            string query = "UPDATE barang SET stok_barang = stok_barang + @jumlah WHERE id_barang = @id";
            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@jumlah", jumlahStokBaru),
                new NpgsqlParameter("@id", idBarang)
            };
            bool success = db.ExecuteNonQuery(query, parameters) > 0;

            if (success)
            {
                // Simpan aktivitas stok dengan HPP baru yang diberikan
                TambahAktivitasStok(idBarang, supplierId, jumlahStokBaru, hppBaru);
            }
            return success;
        }


        public bool UpdateHPP(int idBarang, int hpp_saat_ini)
        {
            string query = "UPDATE barang SET hpp = @harga WHERE id_barang = @id";
            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@harga", hpp_saat_ini),
                new NpgsqlParameter("@id", idBarang)
            };
            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool UpdateHargaBarang(int idBarang, int hargaBaru)
        {
            string query = "UPDATE barang SET harga_barang = @harga WHERE id_barang = @id";
            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@harga", hargaBaru),
                new NpgsqlParameter("@id", idBarang)
            };
            return db.ExecuteNonQuery(query, parameters) > 0;
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
            string query = @"UPDATE barang 
                            SET terhapus = true, 
                                tanggal_hapus = @deletedAt 
                            WHERE id_barang = @id";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@id", idBarang),
                new NpgsqlParameter("@deletedAt", DateTime.Now)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }
    }
}
