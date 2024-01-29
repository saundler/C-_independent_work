using System;
using System.Linq;
using System.IO;

internal class BinaryFileReader
{
    string path;
    public BinaryFileReader(string path)
    {
        this.path = path;
    }

    public int GetDifference()
    {
        int sum32 = 0, sum16 = 0;
        byte[] bt = new byte[4];
        using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        {
            while (fs.Position < fs.Length)
            {
                fs.Read(bt, 0, 4);
                sum16 += BitConverter.ToInt16(bt, 0) + BitConverter.ToInt16(bt, 2);
                sum32 += BitConverter.ToInt32(bt, 0);
            }
        }
        return Math.Abs(sum16 - sum32);
    }
}