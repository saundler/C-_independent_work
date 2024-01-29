using System;

[Flags]
public enum Permissions
{
    Default = 1,           // 0
    UserRead = 2,          // 1
    UserWrite = 4,         // 2
    UserExecute = 8,       // 3 
    GroupRead = 16,        // 4
    GroupWrite = 32,       // 5
    GroupExecute = 64,     // 6
    EveryoneRead = 128,    // 7 
    EveryoneWrite = 256,   // 8
    EveryoneExecute = 512  // 9   
}