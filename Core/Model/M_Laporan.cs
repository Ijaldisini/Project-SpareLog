using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project_SpareLog.Core.Model
{
    public class M_Laporan
    {
        public int id_barang { get; set; }
        public string nama_barang { get; set; }
        public int jumlah_terjual { get; set; }
        public int harga_jual { get; set; }
        public int harga_total { get; set; }
    }
}
