using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.App.Core;
using Project_SpareLog.Core.Interface;

namespace Project_SpareLog.Core.Model
{
    public class M_Barang
    {
        public int id_barang { get; set; }
        public string nama_barang { get; set; }
        public int stok_barang { get; set; }
        public int harga_barang { get; set; }
        public int hpp { get; set; }
        public int supplier_id_supplier { get; set; }
    }
}
