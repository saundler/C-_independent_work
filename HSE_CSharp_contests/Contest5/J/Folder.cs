using System.Collections.Generic;

internal sealed partial class Folder
{
    List<File> files = new List<File>();
    
    public Backup GetBackup()
    {
        return new Backup(this);
    }

    public void RestoreBackup(Backup backup)
    {
        Backup.Restore(this, backup);
    }
}