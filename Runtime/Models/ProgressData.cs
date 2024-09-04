namespace AceLand.Library.Models
{
    public class ProgressData
    {
        public long TotalValue { get; set; }
        public long CurrentValue { get; set; }
        public bool IsDone { get; set; }

        public ProgressData(long totalValue, long currentValue)
        {
            TotalValue = totalValue;
            CurrentValue = currentValue;
            IsDone = false;
        }

        public float CompletedPercent => IsDone || TotalValue <= 0 
            ? 1 
            : CurrentValue / TotalValue;
    }
}