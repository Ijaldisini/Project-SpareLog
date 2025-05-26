using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.Model;

namespace Project_SpareLog.Core.Interface
{
    public interface ITransaksiService
    {
        int? SimpanTransaksi(M_Transaksi transaksi); // Ubah return type dari bool ke int?
        bool SimpanDetailTransaksi(int id_transaksi, int id_laporan, List<M_DetailTransaksi> details);
        bool SimpanPelanggan(string nopol, string nama);
        bool KurangiStokBarang(int id_barang, int jumlah_barang);
        DataTable GetDataBarang();
        int HitungTotalHarga(DataGridView dgv);
        DataTable GetRiwayatTransaksi();
        bool HapusTransaksi(int id_transaksi); // Tambahkan ini jika belum ada
    }
}
