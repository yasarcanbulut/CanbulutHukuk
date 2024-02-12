namespace CanbulutHukuk.Infrastructure.ServiceInterfaces
{
    public class ServiceResult<T>
    {
        public ServiceResult(T sonuc, ServiceResultStatusEnum durum, string mesaj = null)
        {
            Durum = durum;
            Sonuc = sonuc;
            Mesaj = mesaj;
        }

        public ServiceResultStatusEnum Durum { get; set; }
        public T Sonuc { get; set; }
        public string Mesaj { get; set; }
    }
}