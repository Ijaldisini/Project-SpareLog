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

        public bool SimpanTransaksi(M_Transaksi transaksi)
        {
            string query = @"INSERT INTO transaksi (nama_transaksi, tanggal_transaksi, jumlah_barang, total_transaksi)
                     VALUES (@nama, @tanggal, @jumlah_barang, @total);";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@nama", transaksi.nama_transaksi),
                new NpgsqlParameter("@tanggal", transaksi.tanggal_transaksi),
                new NpgsqlParameter("@jumlah_barang", transaksi.jumlah_barang),
                new NpgsqlParameter("@total", transaksi.total_transaksi)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public bool KurangiStokBarang(int id_barang, int jumlah_barang)
        {
            string query = @"UPDATE barang SET stok_barang = stok_barang - @jumlah_barang WHERE id_barang = @id;";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@jumlah_barang", jumlah_barang),
                new NpgsqlParameter("@id", id_barang)
            };

            return db.ExecuteNonQuery(query, parameters) > 0;
        }

        public DataTable GetDataBarang()
        {
            string query = "SELECT id_barang, nama_barang, harga_barang FROM barang";
            return db.queryExecutor(query);
        }

        public int HitungTotalHarga(DataGridView dgv)
        {
            int total = 0;

            foreach (DataGridViewRow row in dgv.Rows)
            {
                if (row.IsNewRow) continue;

                // Akses berdasarkan index:
                // Jumlah Barang = kolom ke-2
                // Harga = kolom ke-3
                if (int.TryParse(row.Cells[2].Value?.ToString(), out int qty) &&
                    int.TryParse(row.Cells[3].Value?.ToString(), out int harga))
                {
                    total += qty * harga;
                }
            }

            return total;
        }

    }
}
