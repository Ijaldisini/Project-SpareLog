using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SpareLog.Model
{
    public class M_Transaksi
    {
        public int? id_transaksi { get; set; } // Optional, karena auto-increment
        public string nama_transaksi { get; set; }
        public DateTime tanggal_transaksi { get; set; }
        public int jumlah_barang { get; set; }
        public decimal total_transaksi { get; set; }
    }
}
