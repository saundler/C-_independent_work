using System;
using System.Collections;
using System.Collections.Generic;

public class Files
{
    public static Hashtable hashtable = new Hashtable();
    public void CreateFile(string filename)
    {
        hashtable.Add(filename, new Permissions());
        hashtable[filename].
    }
    
    public void AddPermission(string filename, string permissionName)
    {
        int index = Array.IndexOf(name.ToArray(), filename);
        if(!permissions[index].Contains(PermissionBuilder.FromName(permissionName)))
        {
            permissions[index].Add(PermissionBuilder.FromName(permissionName));
        }
        
    }
    
    public void RemovePermission(string filename, string permissionName)
    {
        int index = Array.IndexOf(name.ToArray(), filename);
        permissions[index].Remove(PermissionBuilder.FromName(permissionName));
    }

    public override string ToString()
    {
        string line = "";
        for(int i = 0; i < name.Count; i++)
        {
            line += name[i] + ": " + string.Join(' ', permissions[i]) + "\n";
        }
        return line;
    }
}