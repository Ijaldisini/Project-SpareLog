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
        bool SimpanTransaksi(M_Transaksi transaksi);
        bool KurangiStokBarang(int id_barang, int jumlah_barang);
        DataTable GetDataBarang();
        int HitungTotalHarga(DataGridView dgv);
    }
}
