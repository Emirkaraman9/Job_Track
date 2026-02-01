using jobTrack.Models;
using System;

namespace jobTrack.Services
{
    public class EvaluationService
    {
        private readonly EvaluationRepository _repository;

        public EvaluationService()
        {
            _repository = new EvaluationRepository();
        }

        /// <summary>
        /// Mülakatı tamamlanan başvurunun detaylarını getirir (Mock Data)
        /// Bu metot şu an kullanılmasa bile ilerde detay çekmek için kalabilir.
        /// </summary>
        public ProcessEvaluationModel GetEvaluationContext()
        {
            return new ProcessEvaluationModel
            {
                CompanyName = "Google",
                Position = "Veri Analisti",
                Status = "Mülakat",
                Date = new DateTime(2025, 09, 12),
                Location = "İstanbul (Hibrit)",
                Description = "Google veri analizi pozisyonu...",
                LogoPath = ""
            };
        }

        /// <summary>
        /// Kullanıcının yaptığı değerlendirmeyi Repository aracılığıyla kaydeder.
        /// </summary>
        public bool SaveEvaluation(ProcessEvaluationModel model)
        {
            // 1. İş Kuralı: En az 1 yıldız verilmiş mi?
            if (model.UserRating < 1)
                return false;

            // 2. Veritabanı İşlemi: Repository'i çağır
            return _repository.DegerlendirmeEkle(model);
        }
    }
}