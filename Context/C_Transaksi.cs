using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using Project_SpareLog.App.Core;
using Project_SpareLog.Core.Abstract;
using Project_SpareLog.Core.Model;

namespace Project_SpareLog.Context
{
    public class C_Transaksi : ATransaksiService
    {
        private DatabaseWrapper db;

        public C_Transaksi()
        {
            db = new DatabaseWrapper();
        }

        public override int GetNextIdTransaksi()
        {
            string query = "SELECT MAX(id_transaksi) FROM transaksi";
            DataTable dt = db.queryExecutor(query);
            return (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0][0]) + 1 : 1;
        }

        public override int GetNextIdDetailTransaksi()
        {
            string query = "SELECT MAX(id_detail_transaksi) FROM detail_transaksi";
            DataTable dt = db.queryExecutor(query);
            return (dt.Rows.Count > 0 && dt.Rows[0][0] != DBNull.Value) ? Convert.ToInt32(dt.Rows[0][0]) + 1 : 1;
        }

        public override bool SimpanTransaksi(List<M_Transaksi> transaksiList)
        {
            if (transaksiList == null || transaksiList.Count == 0)
                return false;

            int idTransaksi = GetNextIdTransaksi();
            DateTime tanggal = DateTime.Now;
            int idPelanggan = transaksiList[0].pelanggan_id_pelanggan;
            int idUser = transaksiList[0].user_id_user;

            // 1. Insert transaksi dulu
            string insertTransaksi = "INSERT INTO transaksi " +
                                     "(id_transaksi, tanggal_transaksi, pelanggan_id_pelanggan, user_id_user) " +
                                     "VALUES (@id, @tanggal, @pelanggan, @user)";

            var paramTransaksi = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@id", idTransaksi),
                new NpgsqlParameter("@tanggal", tanggal),
                new NpgsqlParameter("@pelanggan", idPelanggan),
                new NpgsqlParameter("@user", idUser)
            };

            if (db.ExecuteNonQuery(insertTransaksi, paramTransaksi) <= 0)
                return false;

            // 2. Insert semua detail transaksi, dengan id_transaksi yang sama
            int currentDetailId = GetNextIdDetailTransaksi();

            foreach (var item in transaksiList)
            {
                string insertDetail = "INSERT INTO detail_transaksi " +
                                      "(id_detail_transaksi, id_transaksi, barang_id_barang, jumlah_detail_transaksi, harga_detail_transaksi, id_user) " +
                                      "VALUES (@id_detail, @id_transaksi, @id_barang, @jumlah, @harga, @id_user)";

                var paramDetail = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@id_detail", currentDetailId),
                    new NpgsqlParameter("@id_transaksi", idTransaksi),
                    new NpgsqlParameter("@id_barang", item.barang_id_barang),
                    new NpgsqlParameter("@jumlah", item.jumlah_detail_transaksi),
                    new NpgsqlParameter("@harga", item.harga_detail_transaksi),
                    new NpgsqlParameter("@id_user", item.user_id_user)
                };

                if (db.ExecuteNonQuery(insertDetail, paramDetail) <= 0)
                    return false;

                currentDetailId++;
            }

            return true;
        }



        public override int GetIdPelanggan(string namaPelanggan, string noPolisi)
        {
            string query = "SELECT id_pelanggan FROM pelanggan WHERE nama_pelanggan = @nama AND nomor_polisi = @nomor_polisi";
            var dt = db.queryExecutor(query, new NpgsqlParameter[]
            {
            new NpgsqlParameter("@nama", namaPelanggan),
            new NpgsqlParameter("@nomor_polisi", noPolisi)
            });

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["id_pelanggan"]);
            }
            else
            {
                string insert = "INSERT INTO pelanggan (nama_pelanggan, nomor_polisi) VALUES (@nama, @nomor_polisi) RETURNING id_pelanggan";
                var result = db.queryExecutor(insert, new NpgsqlParameter[]
                {
                new NpgsqlParameter("@nama", namaPelanggan),
                new NpgsqlParameter("@nomor_polisi", noPolisi)
                });

                return Convert.ToInt32(result.Rows[0]["id_pelanggan"]);
            }

        }

        public override int GetIdToko(string namaPelanggan)
        {
            string query = "SELECT id_pelanggan FROM pelanggan WHERE nama_pelanggan = @nama ";
            var dt = db.queryExecutor(query, new NpgsqlParameter[]
            {
                new NpgsqlParameter("@nama", namaPelanggan),
                //new NpgsqlParameter("@no_polisi", noPolisi)
            });

            if (dt.Rows.Count > 0)
            {
                return Convert.ToInt32(dt.Rows[0]["id_pelanggan"]);
            }
            else
            {
                string insert = "INSERT INTO pelanggan (nama_pelanggan) VALUES (@nama) RETURNING id_pelanggan";
                var result = db.queryExecutor(insert, new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@nama", namaPelanggan),
                });

                return Convert.ToInt32(result.Rows[0]["id_pelanggan"]);
            }
        }

        public override int HitungTotalKeseluruhan(DataGridView dataGridView)
        {
            int grandTotal = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells["jumlah"].Value?.ToString(), out int jumlah) &&
                    int.TryParse(row.Cells["harga"].Value?.ToString(), out int harga))
                {
                    grandTotal += jumlah * harga;
                }
            }
            return grandTotal;
        }

        public override int HitungTotalToko(DataGridView dataGridView)
        {
            int grandTotal = 0;

            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.IsNewRow) continue;

                if (int.TryParse(row.Cells["jumlah"].Value?.ToString(), out int jumlah) &&
                    int.TryParse(row.Cells["harga_diskon"].Value?.ToString(), out int harga))
                {
                    grandTotal += jumlah * harga;
                }
            }
            return grandTotal;
        }
    }
}
