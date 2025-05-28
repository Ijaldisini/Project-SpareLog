using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project_SpareLog.Core.Model;

namespace Project_SpareLog.Core.Interface
{
    public interface IBarangService
    {
        DataTable GetAllBarang();
        int GetNextIdBarang();
        int? GetIdBarangByNama(string nama);
        string GetNamaBarangById(int id);
        DataTable GetSuppliers();
        bool SimpanBarang(M_Barang barang);
        bool IsBarangExists(int idBarang);
        DataTable GetBarangPerluRestock();
        bool HapusBarang(int id_barang);
        bool UpdateStokBarang(int idBarang, int jumlahStokBaru);
    }
}