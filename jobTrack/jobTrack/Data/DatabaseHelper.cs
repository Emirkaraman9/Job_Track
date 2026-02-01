using System;

namespace jobTrack.Repository // Repository klasöründekilerin doğrudan görmesi için bu namespace'i kullanabilirsin
{
    public static class DatabaseHelper
    {
        // Bağlantı dizesini burada bir kez tanımlıyoruz.
        // Veritabanı sunucun değişirse sadece burayı değiştirmen yeterli olur.
        public static string ConnectionString = @"Server= EMIRVICTUS; Database=jobTrackDb; Integrated Security=True; TrustServerCertificate=True;";
    }
}
