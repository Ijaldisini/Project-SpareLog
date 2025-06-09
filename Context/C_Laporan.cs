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
using Project_SpareLog.View;

namespace Project_SpareLog.Context
{
    public class C_Laporan : ALaporanService
    {
        private DatabaseWrapper db;

        public C_Laporan()
        {
            db = new DatabaseWrapper();
        }

        public override List<M_Laporan> GetLaporanPenjualan()
        {
            string query = @"
                SELECT 
                    b.id_barang,
                    b.nama_barang,
                    SUM(d.jumlah_detail_transaksi) AS jumlah_terjual,
                    d.harga_detail_transaksi AS harga_jual,
                    SUM(d.jumlah_detail_transaksi * d.harga_detail_transaksi) AS total_harga
                FROM transaksi t
                JOIN detail_transaksi d ON d.id_transaksi = t.id_transaksi
                JOIN barang b ON d.barang_id_barang = b.id_barang
                GROUP BY b.id_barang, b.nama_barang, d.harga_detail_transaksi
            ";

            DataTable dt = db.queryExecutor(query);
            List<M_Laporan> laporanList = new List<M_Laporan>();

            foreach (DataRow row in dt.Rows)
            {
                laporanList.Add(new M_Laporan
                {
                    id_barang = Convert.ToInt32(row["id_barang"]),
                    nama_barang = row["nama_barang"].ToString(),
                    jumlah_terjual = Convert.ToInt32(row["jumlah_terjual"]),
                    harga_jual = Convert.ToInt32(row["harga_jual"]),
                    harga_total = Convert.ToInt32(row["total_harga"]),
                });
            }

            return laporanList;
        }

        public override List<M_Laporan> GetLaporanPenjualanByTanggal(DateTime tanggal)
        {
            List<M_Laporan> laporanList = new List<M_Laporan>();

            string query = @"
                SELECT 
                    d.barang_id_barang AS id_barang,
                    b.nama_barang,
                    SUM(d.jumlah_detail_transaksi) AS jumlah_terjual,
                    d.harga_detail_transaksi AS harga_jual,
                    SUM(d.jumlah_detail_transaksi * d.harga_detail_transaksi) AS total_harga
                FROM transaksi t
                JOIN detail_transaksi d ON t.id_transaksi = d.id_transaksi
                JOIN barang b ON d.barang_id_barang = b.id_barang
                WHERE t.tanggal_transaksi = @tanggal
                GROUP BY d.barang_id_barang, b.nama_barang, d.harga_detail_transaksi
                ORDER BY b.nama_barang;
            ";

            var parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@tanggal", tanggal)
            };

            DataTable dt = db.queryExecutor(query, parameters);

            foreach (DataRow row in dt.Rows)
            {
                laporanList.Add(new M_Laporan
                {
                    id_barang = Convert.ToInt32(row["id_barang"]),
                    nama_barang = row["nama_barang"].ToString(),
                    jumlah_terjual = Convert.ToInt32(row["jumlah_terjual"]),
                    harga_jual = Convert.ToInt32(row["harga_jual"]),
                    harga_total = Convert.ToInt32(row["total_harga"]),
                });
            }

            return laporanList;
        }

        public override List<M_Laporan> GetLaporanPembelian()
        {
            string query = @"
                SELECT 
                    b.id_barang,
                    b.nama_barang,
                    a.jumlah_barang AS jumlah_dibeli,
                    a.hpp_saat_ini AS harga_beli,
                    (a.jumlah_barang * a.hpp_saat_ini) AS total_harga
                FROM aktivitas_stok a
                JOIN barang b ON a.barang_id_barang = b.id_barang
                ORDER BY a.tanggal ASC
            ";

            DataTable dt = db.queryExecutor(query);
            List<M_Laporan> laporanList = new List<M_Laporan>();

            foreach (DataRow row in dt.Rows)
            {
                laporanList.Add(new M_Laporan
                {
                    id_barang = Convert.ToInt32(row["id_barang"]),
                    nama_barang = row["nama_barang"].ToString(),
                    jumlah_dibeli = Convert.ToInt32(row["jumlah_dibeli"]),
                    harga_beli = Convert.ToInt32(row["harga_beli"]),
                    harga_total = Convert.ToInt32(row["total_harga"]),
                });
            }

            return laporanList;
        }

        public override List<M_Laporan> GetLaporanPembelianByTanggal(DateTime tanggal)
        {
            string query = @"
                SELECT 
                    b.id_barang,
                    b.nama_barang,
                    a.jumlah_barang AS jumlah_dibeli,
                    a.hpp_saat_ini AS harga_beli,
                    (a.jumlah_barang * a.hpp_saat_ini) AS total_harga
                FROM aktivitas_stok a
                JOIN barang b ON a.barang_id_barang = b.id_barang
                WHERE a.tanggal = @tanggal
                ORDER BY a.tanggal ASC
            ";

            NpgsqlParameter[] parameters = new NpgsqlParameter[]
            {
                new NpgsqlParameter("@tanggal", tanggal)
            };

            DataTable dt = db.queryExecutor(query, parameters);
            List<M_Laporan> laporanList = new List<M_Laporan>();

            foreach (DataRow row in dt.Rows)
            {
                laporanList.Add(new M_Laporan
                {
                    id_barang = Convert.ToInt32(row["id_barang"]),
                    nama_barang = row["nama_barang"].ToString(),
                    jumlah_dibeli = Convert.ToInt32(row["jumlah_dibeli"]),
                    harga_beli = Convert.ToInt32(row["harga_beli"]),
                    harga_total = Convert.ToInt32(row["total_harga"]),
                });
            }

            return laporanList;
        }

    }
}