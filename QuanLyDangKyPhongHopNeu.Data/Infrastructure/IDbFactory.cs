using QuanLyDangKyPhongHopNeu.Model;
using System;

namespace QuanLyDangKyPhongHopNeu.Data.Infrastructure
{
    public interface IDbFactory :IDisposable
    {
        QuanLyDangKyPhongHopNeuDbContext Init();
    }
}
