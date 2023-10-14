# Tomori.Epartner

## Install Tool
klik kanan di project Tomori.Epartner.Data kemudian pilih open in terminal kemudian ketik :
```powershell
dotnet tool install --global dotnet-ef 
atau
dotnet tool update --global dotnet-ef
```

## Scaffolding
```scaffold
dotnet ef dbcontext scaffold "Data Source=localhost;Initial Catalog=Tomori.Epartner;User Id=sa;Password=Pass@w0rd; TrustServerCertificate=Yes" Microsoft.EntityFrameworkCore.SqlServer --output-dir "..\Tomori.Epartner.Data\Model" -c ApplicationDBContext --context-dir "..\Tomori.Epartner.Data" --namespace "Tomori.Epartner.Data.Model" --context-namespace "Tomori.Epartner.Data" --no-pluralize -f --no-onconfiguring --schema "dbo" --schema "general" --schema "identity" --schema "log"
```

## Generated file
show all files di project Tomori.Epartner.Data maka akan terbentuk file *generated" dan didalamnya terdapat backend dan infrastructure disana tinggal copy paste saja kedalam core untuk kebutuhan table.

## Use DAL
untuk cara pemakain bisa dibaca di [Vleko.DAL](https://github.com/Vlekops/DAL)

