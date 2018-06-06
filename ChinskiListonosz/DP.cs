namespace ChinskiListonosz
{
    public struct DP
    {
        public Wierzcholek Wierzcholek { get; set; }
        public double Koszt { get; set; }
        public int Poprzednik { get; set; }

        public override string ToString()
        {
            return string.Format("Koszt = {0}; Poprzednik = {1};", Koszt, Poprzednik);
        }
    }
}
