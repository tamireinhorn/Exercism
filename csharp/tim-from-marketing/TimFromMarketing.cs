using System;

static class Badge
{
    public static string Print(int? id, string name, string? department)
    {
        string department2 = department ?? "owner";
        string id2;
        if (id == null){
            id2 = "";
        }
        else{
            id2 = $"[{id}] - ";
        }
        return $"{id2}{name} - {department2.ToUpper()}";
    }
}
