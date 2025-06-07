using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.Core.Model;

namespace Project_SpareLog.Core.Abstract
{
    public abstract class ATransaksiService
    {
        public abstract bool SimpanTransaksi(List<M_Transaksi> transaksiList);
        public abstract int GetNextIdTransaksi();
        public abstract int GetNextIdDetailTransaksi();
        public abstract int GetIdPelanggan(string namaPelanggan, string noPolisi);
        public abstract int GetIdToko(string namaPelanggan);
        public abstract int HitungTotalKeseluruhan(DataGridView dataGridView);
        public abstract int HitungTotalToko(DataGridView dataGridView);
    }
}
