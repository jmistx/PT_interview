namespace Domain
{
    public class FibonacciCalculator
    {
        public int GetNumberBySerialNumber(int serialNumber)
        {
            if (serialNumber == 0) return 0;
            if (serialNumber == 1) return 1;
            if (serialNumber == 2) return 1;
            return GetNumberBySerialNumber(serialNumber - 1) + GetNumberBySerialNumber(serialNumber - 2);
        }
    }
}