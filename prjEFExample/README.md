
create table tblContacts(
	[PersonID] int IDENTITY(1,1) NOT NULL PRIMARY KEY,
	[FirstName] varchar(255) not null,
	[LastName] varchar(255) not null,
	PhoneNumber varchar(10) not null,
	EmailAddress varchar(255) not null,
	Username varchar(255) not null,
	FOREIGN KEY (Username) REFERENCES tblUsers(Username)
);

create table tblUsers(
	Username varchar(255) not null PRIMARY KEY,
	[Password] varchar(255) not null
	);

insert into tblUsers values('Jack','1234'),('Reece','4321');

# Open Tools 
#cmd then Dev
then cd //Name of the folder( or do tab tab and will come up )

dotnet add package Microsoft.EntityFrameworkCore.SqlServer 

dotnet add package Microsoft.EntityFrameworkCore.Design

dotnet tool install --global dotnet-ef


dotnet ef dbcontext scaffold "Server=tcp:rwanvig.database.windows.net,1433;Initial Catalog=rwanvigdb;Persist Security Info=False;User ID=rwanvig;Password=@Password1;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -o Model

select
    'data source=' + @@servername +
    ';initial catalog=' + db_name() +
    case type_desc
        when 'WINDOWS_LOGIN' 
            then ';trusted_connection=true'
        else
            ';user id=' + suser_name() + ';password=<<YourPassword>>'
    end
    as ConnectionString
from sys.server_principals
where name = suser_name()


data source=VCECPELITPC2;initial catalog=dbAPI;trusted_connection=true



dotnet ef dbcontext scaffold "Server=VCECPELITPC2;Initial Catalog=dbAPI;Integrated Security=True;Encrypt=False;" Microsoft.EntityFrameworkCore.SqlServer -o Models


