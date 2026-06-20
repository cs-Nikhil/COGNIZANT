namespace BuilderPatternExample
{
    class Program
    {
        static void Main(string[] args)
        {
            Computer gamingPC = new Computer.Builder()
                .SetCPU("Intel Core i9")
                .SetRAM(32)
                .SetStorage(1000)
                .SetGraphicsCard("NVIDIA RTX 4080")
                .Build();

            Computer officePC = new Computer.Builder()
                .SetCPU("Intel Core i5")
                .SetRAM(16)
                .SetStorage(512)
                .Build();

            gamingPC.Display();
            officePC.Display();
        }
    }
}