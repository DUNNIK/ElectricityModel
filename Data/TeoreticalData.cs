namespace Data
{
    public static class TeoreticalData
    {
        public static double FMax { get; set; }
        public static double Q1R1 { get; set; }
        public static double Q2R2 { get; set; }
        public static double ΩrR1 { get; set; }
        public static double ΩcR1 { get; set; }
        public static double ΩlR1 { get; set; }
        public static double ΩrR3 { get; set; }
        public static double ΩcR3 { get; set; }
        public static double ΩlR3 { get; set; }
        public new static string ToString()
        {
            return $"f = {FMax} кГц\n" 
                   + $"Q1(R1) = {Q1R1}\n"
                   + $"Q2(R2) = {Q2R2}\n"
                   +  "При R = 1\n" +
                   $"\tΩ_Rres = {ΩrR1} кГц\n" +
                   $"\tΩ_Cres = {ΩcR1} кГц\n" +
                   $"\tΩ_Lres = {ΩlR1} кГц\n" +
                   "При R = 3\n" +
                   $"\tΩ_Rres = {ΩrR3} кГц\n" +
                   $"\tΩ_Cres = {ΩcR3} кГц\n" +
                   $"\tΩ_Lres = {ΩlR3} кГц\n";
        }
    }
}