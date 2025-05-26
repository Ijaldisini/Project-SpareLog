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
    public class C_Transaksi : ITransaksiService
    {
        private DatabaseWrapper db = new DatabaseWrapper();

        public int? SimpanTransaksi(M_Transaksi transaksi)
        {
            string query = @"INSERT INTO transaksi 
        (nama_transaksi, tanggal_transaksi, jumlah_barang) 
        VALUES (@nama, @tanggal, @jumlah)
        RETURNING id_transaksi";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
            new NpgsqlParameter("@nama", transaksi.nama_transaksi),
            new NpgsqlParameter("@tanggal", transaksi.tanggal_transaksi),
            new NpgsqlParameter("@jumlah", transaksi.jumlah_barang)
            };

            // Gunakan queryExecutor karena RETURNING mengembalikan hasil dalam DataTable
            DataTable result = db.queryExecutor(query, parameters);
            if (result.Rows.Count > 0)
            {
                return Convert.ToInt32(result.Rows[0]["id_transaksi"]);
            }
            return null;
        }

        public bool SimpanPelanggan(string nopol, string nama) // Added missing method to implement the interface
        {
            string query = @"INSERT INTO pelanggan (nopol, nama_pelanggan) VALUES (@nopol, @nama)";
            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                    new NpgsqlParameter("@nopol", nopol),
                    new NpgsqlParameter("@nama", nama)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool SimpanDetailTransaksi(int id_transaksi, int id_laporan, List<M_DetailTransaksi> details)
        {
            try
            {
                foreach (var detail in details)
                {
                    string query = @"INSERT INTO detail_transaksi 
                (transaksi_id_transaksi, barang_id_barang, pelanggan_nopol, laporan_penjualan_id_laporan)
                VALUES (@id_transaksi, @id_barang, @nopol, @id_laporan)";

                    var parameters = new NpgsqlParameter[]
                    {
                    new NpgsqlParameter("@id_transaksi", id_transaksi),
                    new NpgsqlParameter("@id_barang", detail.id_barang),
                    new NpgsqlParameter("@nopol", detail.nopol ?? (object)DBNull.Value),
                    new NpgsqlParameter("@id_laporan", id_laporan)
                    };

                    if (db.ExecuteNonQuery(query, parameters) <= 0)
                    {
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error SimpanDetailTransaksi: {ex.Message}");
                return false;
            }
        }

        public DataTable GetDetailTransaksi()
        {
            string query = @"SELECT 
        dt.id_detail_transaksi,
        t.id_transaksi,
        t.tanggal_transaksi,
        p.nopol,
        b.id_barang,
        b.nama_barang,
        b.harga_barang,
            1 as jumlah_barang,
            b.harga_barang as total_harga
            FROM detail_transaksi dt
            JOIN transaksi t ON dt.transaksi_id_transaksi = t.id_transaksi
            JOIN barang b ON dt.barang_id_barang = b.id_barang
            LEFT JOIN pelanggan p ON dt.pelanggan_nopol = p.nopol
        ORDER BY t.tanggal_transaksi DESC";

            return db.queryExecutor(query);
        }

        public bool HapusTransaksi(int id_transaksi)
        {
            string query = "DELETE FROM transaksi WHERE id_transaksi = @id";
            var param = new NpgsqlParameter("@id", id_transaksi);
            return db.ExecuteNonQuery(query, new NpgsqlParameter[] { param }) > 0;
        }

        public bool KurangiStokBarang(int id_barang, int jumlah_barang)
        {
            string query = @"UPDATE barang SET stok_barang = stok_barang - @jumlah 
                           WHERE id_barang = @id AND stok_barang >= @jumlah";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                    new NpgsqlParameter("@jumlah", jumlah_barang),
                    new NpgsqlParameter("@id", id_barang)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable GetDataBarang()
        {
            string query = "SELECT id_barang, nama_barang, harga_barang, stok_barang FROM barang";
            return db.queryExecutor(query);
        }

        public int HitungTotalHarga(DataGridView dgv)
        {
            int total = 0;
            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                // Pastikan nama kolom sesuai dengan DataGridView Anda
                if (int.TryParse(row.Cells["harga"].Value?.ToString(), out int harga))
                {
                    int qty = Convert.ToInt32(row.Cells["jumlah_barang"].Value ?? 1);
                    total += harga * qty;
                }
            }
            return total;
        }

        public bool UpdateTotalTransaksi(int idTransaksi)
        {
            string query = @"UPDATE transaksi t
            SET total_transaksi = (
            SELECT SUM(dt.jumlah_barang * b.harga_barang)
            FROM detail_transaksi dt
            JOIN barang b ON dt.barang_id_barang = b.id_barang
            WHERE dt.transaksi_id_transaksi = @idTransaksi
            )
            WHERE t.id_transaksi = @idTransaksi";

            var param = new NpgsqlParameter("@idTransaksi", idTransaksi);
            return db.ExecuteNonQuery(query, new[] { param }) > 0;
        }

        public int HitungTotalTransaksi(int idTransaksi)
        {
            string query = @"SELECT SUM(dt.jumlah_barang * b.harga_barang)
            FROM detail_transaksi dt
            JOIN barang b ON dt.barang_id_barang = b.id_barang
            WHERE dt.transaksi_id_transaksi = @idTransaksi";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@idTransaksi", idTransaksi)
            };

            DataTable dt = db.queryExecutor(query, parameters);
            if (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value)
            {
                return Convert.ToInt32(dt.Rows[0][0]);
            }
            return 0;
        }

        public DataTable GetRiwayatTransaksi()
        {
            string query = @"SELECT 
        dt.id_detail_transaksi,
        t.id_transaksi,
        t.tanggal_transaksi,
        t.nama_transaksi,
        t.jumlah_barang,
        p.nopol,
        p.nama_pelanggan,
        b.id_barang,
        b.nama_barang,
        b.harga_barang,
        b.harga_barang as subtotal,
        (SELECT SUM(b2.harga_barang)
                 FROM detail_transaksi dt2
                 JOIN barang b2 ON dt2.barang_id_barang = b2.id_barang
                 WHERE dt2.transaksi_id_transaksi = t.id_transaksi) as total_transaksi
                FROM transaksi t
                JOIN detail_transaksi dt ON t.id_transaksi = dt.transaksi_id_transaksi
                JOIN barang b ON dt.barang_id_barang = b.id_barang
                LEFT JOIN pelanggan p ON dt.pelanggan_nopol = p.nopol
        ORDER BY t.tanggal_transaksi DESC";

            return db.queryExecutor(query);
        }

        public bool CekStokBarang(int id_barang, int jumlah)
        {
            string query = "SELECT stok_barang FROM barang WHERE id_barang = @id";
            var param = new NpgsqlParameter[] { new NpgsqlParameter("@id", id_barang) };
            object result = db.queryExecutor(query, param);

            if (result != null && int.TryParse(result.ToString(), out int stok))
            {
                return stok >= jumlah;
            }
            return false;
        }

        public int? BuatLaporanPenjualan(DateTime tanggal)
        {
            string query = @"INSERT INTO laporan_penjualan (tanggal_periode) 
                   VALUES (@tanggal) RETURNING id_laporan";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
        new NpgsqlParameter("@tanggal", tanggal)
            };

            DataTable result = db.queryExecutor(query, parameters);
            return result.Rows.Count > 0 ? Convert.ToInt32(result.Rows[0]["id_laporan"]) : null;
        }
    }
}
