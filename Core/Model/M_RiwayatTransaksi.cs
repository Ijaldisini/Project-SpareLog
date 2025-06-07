using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SpareLog.Core.Model
{
    public class M_RiwayatTransaksi
    {
        public int id_transaksi { get; set; }
        public DateTime tanggal_transaksi { get; set; }
        public int pelanggan_id_pelanggan { get; set; }

        public int barang_id_barang { get; set; }
        public int jumlah_detail_transaksi { get; set; }
        public int harga_detail_transaksi { get; set; }
    }
}
