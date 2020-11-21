namespace Common
{
    public struct MessageA
    {
        public int MemesInt;
        public string MemesStr;
    }

    public struct ResponseA
    {
        public int MemesInt;
        public string MemesStr;

        public override string ToString()
        {
            return $"({MemesInt}, {MemesStr})";
        }
    }

    public struct MessageB
    {
        public int MemesInt;
        public float MemesFloat;
    }

    public struct ResponseB
    {
        public int MemesInt;
        public float MemesFloat;

        public override string ToString()
        {
            return $"({MemesInt}, {MemesFloat})";
        }
    }
}