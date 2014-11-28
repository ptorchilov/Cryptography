namespace Lab04
{
    using System;

    public class FiatShamir
    {
        public int Ksi1 { get; private set; }

        public int Ksi2 { get; private set; }

        public int M { get; private set; }

        public int Alpha { get; private set; }

        public int Beta { get; private set; }

        private readonly Random random;

        public FiatShamir(int ksi1, int ksi2)
        {
            Ksi1 = ksi1;
            Ksi2 = ksi2;

            random = new Random();
        }

        public void GenerateSignature()
        {
            M = Ksi1 * Ksi2;

            Alpha = random.Next(1, M - 1); //TODO: check this condition

            Beta = (int) Math.Pow(Alpha, 2) % M;
        }
    }
}
