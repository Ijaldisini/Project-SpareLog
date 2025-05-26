using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SpareLog.Model
{
    public class M_DetailTransaksi
    {
        public int id_detail_transaksi {  get; set; }
        public int id_transaksi { get; set; }
        public DateTime tanggal_transaksi { get; set; }
        public string nopol {  get; set; }
        public int id_barang { get; set; }
        public int jumlah_barang { get; set; }
        public int harga_barang { get; set; }
        public int total_harga { get; set; }
    }
}
