using MetricsAgent.Models;

namespace MetricsAgent.Services.Impl
{
    public class CpuMetricsRepository : ICpuMetricsRepository
    {
        public void Create(CpuMetric item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IList<CpuMetric> GetAll()
        {
            throw new NotImplementedException();
        }

        public CpuMetric GetById(int id)
        {
            throw new NotImplementedException();
        }
        
        public IList<CpuMetric> GetByTimePeriod(TimeSpan timeFrom, TimeSpan timeTo)
        {
            throw new NotImplementedException();
        }

        public void Update(CpuMetric item)
        {
            throw new NotImplementedException();
        }
    }
}
