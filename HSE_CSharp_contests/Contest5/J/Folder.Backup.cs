using System;
using System.Collections.Generic;

internal sealed partial class Folder
{
    internal class Backup
    {
        public List<File> back;
        public Backup(Folder folder)
        {
            back = new List<File>(folder.files);
        }
        
        public static void Restore(Folder folder, Backup backup)
        {
            folder.files = new List<File>(backup.back);
        }
    }

    public void AddFile(string name, int size)
    {
        files.Add(new File(name, size));
    }
	
    public void RemoveFile(File file)
    {
        for(int i = 0; i < files.Count; i++)
        {
            if(files[i].Name == file.Name)
            {
                files.RemoveAt(i);
            }
        }
    }

    public File this[int i]
    {
        get
        {
            try
            {
                return files[i];
            }
            catch
            {
                throw new IndexOutOfRangeException("Not enough files or index less zero");
            }
        }
    }

    public File this[string filename]
    {
        get
        {
            foreach(var file in files)
            {
                if(filename == file.Name)
                {
                    return file;
                }
            }
            throw new ArgumentException("File not found");
        }
    }
    public override string ToString()
    {
        string str = "Files in folder:";
        foreach (var file in files)
        {
            str += "\n" + file ;
        }
        return str;
    }
}