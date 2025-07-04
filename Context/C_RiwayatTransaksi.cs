﻿using System;
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
    public class C_RiwayatTransaksi : ARiwayatTransaksiService
    {
        private DatabaseWrapper db;

        public C_RiwayatTransaksi()
        {
            db = new DatabaseWrapper();
        }

        public override List<M_RiwayatTransaksi> GetAllRiwayatPelanggan()
        {
            try
            {
                string query = @"  
                    SELECT 
                        t.id_transaksi, 
                        t.tanggal_transaksi, 
                        t.pelanggan_id_pelanggan,  
                        d.barang_id_barang, 
                        d.jumlah_detail_transaksi, 
                        d.harga_detail_transaksi  
                    FROM 
                        transaksi t  
                    JOIN 
                        detail_transaksi d ON t.id_transaksi = d.id_transaksi  
                    JOIN 
                        pelanggan p ON t.pelanggan_id_pelanggan = p.id_pelanggan
                    WHERE 
                        p.nomor_polisi IS NOT NULL
                    ORDER BY 
                        t.tanggal_transaksi DESC
                ";

                DataTable dt = db.queryExecutor(query);
                return ConvertToListPelanggan(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllRiwayatPelanggan: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        public override List<M_RiwayatTransaksi> GetRiwayatByNamaPelanggan(string namaPelanggan)
        {
            try
            { 
                string query = @"  
                    SELECT   
                        t.id_transaksi,   
                        t.tanggal_transaksi,   
                        t.pelanggan_id_pelanggan,  
                        d.barang_id_barang,  
                        d.jumlah_detail_transaksi,  
                        d.harga_detail_transaksi,  
                        b.nama_barang  
                    FROM   
                        transaksi t  
                    JOIN   
                        detail_transaksi d ON t.id_transaksi = d.id_transaksi  
                    JOIN   
                        barang b ON d.barang_id_barang = b.id_barang  
                    JOIN   
                        pelanggan p ON t.pelanggan_id_pelanggan = p.id_pelanggan  
                    WHERE   
                        p.nama_pelanggan ILIKE @namaPelanggan  
                        AND p.nomor_polisi IS NOT NULL  
                        AND p.nomor_polisi <> ''
                ";

                var parameters = new NpgsqlParameter[]
                {
                    new NpgsqlParameter("@namaPelanggan", namaPelanggan)
                };

                DataTable dt = db.queryExecutor(query, parameters);
                return ConvertToListPelanggan(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRiwayatByNamaPelanggan: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        public override List<M_RiwayatTransaksi> GetRiwayatPelangganByTanggal(DateTime tanggal)
        {
            try
            { 
                string query = @"
                    SELECT   
                        t.id_transaksi,   
                        t.tanggal_transaksi,   
                        t.pelanggan_id_pelanggan,  
                        d.barang_id_barang,  
                        d.jumlah_detail_transaksi,  
                        d.harga_detail_transaksi,  
                        b.nama_barang  
                    FROM   
                        transaksi t  
                    JOIN   
                        detail_transaksi d ON t.id_transaksi = d.id_transaksi  
                    JOIN   
                        barang b ON d.barang_id_barang = b.id_barang  
                    JOIN   
                        pelanggan p ON t.pelanggan_id_pelanggan = p.id_pelanggan  
                    WHERE   
                        p.nomor_polisi IS NOT NULL  
                        AND p.nomor_polisi <> ''  
                        AND DATE(t.tanggal_transaksi) = @tanggal
                    ORDER BY 
                        t.tanggal_transaksi DESC
                ";

                var parameters = new Npgsql.NpgsqlParameter[]
                {
                    new Npgsql.NpgsqlParameter("@tanggal", tanggal.Date)
                };

                DataTable dt = db.queryExecutor(query, parameters);
                return ConvertToListPelanggan(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRiwayatPelangganByTanggal: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        private List<M_RiwayatTransaksi> ConvertToListPelanggan(DataTable dt)
        {
            try
            { 
                List<M_RiwayatTransaksi> list = new List<M_RiwayatTransaksi>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new M_RiwayatTransaksi
                    {
                        id_transaksi = Convert.ToInt32(row["id_transaksi"]),
                        tanggal_transaksi = Convert.ToDateTime(row["tanggal_transaksi"]),
                        pelanggan_id_pelanggan = Convert.ToInt32(row["pelanggan_id_pelanggan"]),
                        barang_id_barang = Convert.ToInt32(row["barang_id_barang"]),
                        jumlah_detail_transaksi = Convert.ToInt32(row["jumlah_detail_transaksi"]),
                        harga_detail_transaksi = Convert.ToInt32(row["harga_detail_transaksi"]),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ConvertToListPelanggan: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        private List<M_RiwayatTransaksi> ConvertToListToko(DataTable dt)
        {
            try
            {
                List<M_RiwayatTransaksi> list = new List<M_RiwayatTransaksi>();
                foreach (DataRow row in dt.Rows)
                {
                    list.Add(new M_RiwayatTransaksi
                    {
                        id_transaksi = Convert.ToInt32(row["id_transaksi"]),
                        tanggal_transaksi = Convert.ToDateTime(row["tanggal_transaksi"]),
                        pelanggan_id_pelanggan = Convert.ToInt32(row["pelanggan_id_pelanggan"]),
                        barang_id_barang = Convert.ToInt32(row["barang_id_barang"]),
                        jumlah_detail_transaksi = Convert.ToInt32(row["jumlah_detail_transaksi"]),
                        harga_barang = Convert.ToInt32(row["harga_barang"]),
                        harga_detail_transaksi = Convert.ToInt32(row["harga_detail_transaksi"]),
                    });
                }
                return list;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in ConvertToListToko: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        public override List<M_RiwayatTransaksi> GetAllRiwayatToko()
        {
            try
            {
                string query = @"  
                SELECT 
                    t.id_transaksi, 
                    t.tanggal_transaksi, 
                    t.pelanggan_id_pelanggan,  
                    d.barang_id_barang, 
                    d.jumlah_detail_transaksi, 
	                b.harga_barang,
                    d.harga_detail_transaksi  
                FROM 
                    transaksi t  
                JOIN 
	                detail_transaksi d ON t.id_transaksi = d.id_transaksi  
                JOIN
	                barang b ON d.barang_id_barang = b.id_barang
                JOIN 
                    pelanggan p ON t.pelanggan_id_pelanggan = p.id_pelanggan
                WHERE 
                    p.nomor_polisi IS NULL
                ORDER BY 
                    t.tanggal_transaksi DESC";

                DataTable dt = db.queryExecutor(query);
                return ConvertToListToko(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetAllRiwayatToko: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        public override List<M_RiwayatTransaksi> GetRiwayatByNamaToko(string namaPelanggan)
        {
            try
            {
                string query = @"
                SELECT   
                    t.id_transaksi,   
                    t.tanggal_transaksi,   
                    t.pelanggan_id_pelanggan,  
                    d.barang_id_barang,  
	                b.harga_barang,
                    d.jumlah_detail_transaksi,  
                    d.harga_detail_transaksi
                FROM   
                    transaksi t  
                JOIN   
                    detail_transaksi d ON t.id_transaksi = d.id_transaksi  
                JOIN   
                    barang b ON d.barang_id_barang = b.id_barang  
                JOIN   
                    pelanggan p ON t.pelanggan_id_pelanggan = p.id_pelanggan  
                WHERE   
                    p.nama_pelanggan ILIKE @namaPelanggan  
                    AND p.nomor_polisi IS NULL";

                var parameters = new NpgsqlParameter[]
                {
                new NpgsqlParameter("@namaPelanggan", namaPelanggan)
                };

                DataTable dt = db.queryExecutor(query, parameters);
                return ConvertToListToko(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRiwayatByNamaToko: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }

        public override List<M_RiwayatTransaksi> GetRiwayatTokoByTanggal(DateTime tanggal)
        {
            try
            {
                string query = @"  
                SELECT 
                    t.id_transaksi, 
                    t.tanggal_transaksi, 
                    t.pelanggan_id_pelanggan,  
                    d.barang_id_barang, 
                    d.jumlah_detail_transaksi, 
                    d.harga_detail_transaksi,
                    b.harga_barang
                FROM 
                    transaksi t  
                JOIN 
                    detail_transaksi d ON t.id_transaksi = d.id_transaksi  
                JOIN 
                    pelanggan p ON t.pelanggan_id_pelanggan = p.id_pelanggan
                JOIN
                    barang b ON d.barang_id_barang = b.id_barang
                WHERE 
                    p.nomor_polisi IS NULL AND
                    DATE(t.tanggal_transaksi) = @tanggal
                ORDER BY 
                    t.tanggal_transaksi DESC";

                var parameters = new NpgsqlParameter[]
                {
                new NpgsqlParameter("@tanggal", tanggal.Date)
                };

                DataTable dt = db.queryExecutor(query, parameters);
                return ConvertToListToko(dt);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetRiwayatTokoByTanggal: {ex.Message}");
                return new List<M_RiwayatTransaksi>();
            }
        }
    }
}
