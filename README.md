# DBPDevelop.LiaKontroll
 Håll koll på dina LIA sökningar

## Info
Byggt i ASP.NET MVC. Ingen factory pattern, service pattern, single responsibility eller annan SOLID följd. Quick and Dirty approach på denna :)

## Såhär får du igång programmet 
1. Skapa en ny lokaldb.
2. Lägg till connection string i appsettings.json
   "ConnectionStrings": {
     "DATAConnection": "Din anslutnings sträng"
   },
3. Kör "Add-Migration Init" i Package Manager Console.
4. Kör Update-Database i Package Manager Console.
5. Kör igång programmet !
