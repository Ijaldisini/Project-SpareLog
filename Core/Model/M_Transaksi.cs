using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SpareLog.Core.Model
{
    public class M_Transaksi
    {
        public int pelanggan_id_pelanggan { get; set; }
        public int user_id_user { get; set; }

        public int barang_id_barang { get; set; }
        public int jumlah_detail_transaksi { get; set; }
        public int harga_detail_transaksi { get; set; }
    }
}
