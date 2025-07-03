# Backgammon

## VankoSoft Build
- Create Some User Records in Database
```
sqlcmd -S localhost -U SA -P 'RootPassword' -d Backgammon -Q "INSERT INTO Users (Id, Name, ShowPhoto, Elo, GameCount, Admin, EmailNotifications, EmailUnsubscribeId, Gold, LastFreeGold, PassHash, MuteIntro) VALUES ('ECC9A1FC-3E5C-45E6-BCE3-7C24DFE82A99', 'Admin', 'FALSE', 0, 0, 'TRUE', 'FALSE', 'ECC9A1FC-3E5C-45E6-BCE3-7C24DFE82A99', 100, GETDATE(), 0, 'FALSE')"
sqlcmd -S localhost -U SA -P 'RootPassword' -d Backgammon -Q "INSERT INTO Users (Id, Name, ShowPhoto, Elo, GameCount, Admin, EmailNotifications, EmailUnsubscribeId, Gold, LastFreeGold, PassHash, MuteIntro) VALUES ('FB5046FE-DE10-48A7-901E-E5E95251E996', 'Game', 'FALSE', 0, 0, 'FALSE', 'FALSE', 'FB5046FE-DE10-48A7-901E-E5E95251E996', 100, GETDATE(), 0, 'FALSE')"
sqlcmd -S localhost -U SA -P 'RootPassword' -d Backgammon -Q "INSERT INTO Users (Id, Name, ShowPhoto, Elo, GameCount, Admin, EmailNotifications, EmailUnsubscribeId, Gold, LastFreeGold, PassHash, MuteIntro) VALUES ('ECC9A1FC-3E5C-45E6-BCE3-7C24DFE82C98', 'Aina', 'FALSE', 0, 0, 'FALSE', 'FALSE', 'ECC9A1FC-3E5C-45E6-BCE3-7C24DFE82C98', 100, GETDATE(), 0, 'FALSE')"
```

- Build Frontend from ui Directory Run:
```
yarn install --no-bin-links
yarn run build
```

- Build and Publish Backend
```
dotnet publish -c Debug -o /srv/Backgammon/
sudo service BackgammonBackend restart
```

- Create a file pw.txt with Database Root Password and copy the file into /srv/Backgammon

- Create a New Database Backup
```
sqlcmd -S localhost -U SA -P 'RootPassword' -Q "BACKUP DATABASE [Backgammon] TO DISK='/var/DotNetBackup/Backgammon.bac'"
sudo mv /var/DotNetBackup/Backgammon.bac /dropbox-files/databases/Backgammon.bac
```

- Restore Database From Backup
```
cp /dropbox-files/databases/Backgammon.bac /var/DotNetBackup/Backgammon.bac
sqlcmd -S localhost -U SA -P 'RootPassword' -Q "DROP DATABASE Backgammon"
sqlcmd -S localhost -U SA -P 'RootPassword' -Q "RESTORE DATABASE [Backgammon] FROM DISK='/var/DotNetBackup/Backgammon.bac'"
sudo rm /var/DotNetBackup/Backgammon.bac
```

- Check Websocket Connections
```
telsocket -url wss://api.backgammon.lh:5001/ws/game
telsocket -url wss://api.backgammon.lh:5001/ws/chat
```

- Debug Backend Communication
```
tail -f /srv/Backgammon/Backend.log
```

Online game player vs player.

[Codeproject article](https://www.codeproject.com/Articles/5297405/Online-Backgammon)

## These might be the steps to set it up locally

(But dont try this unless you know Angular, .net core and Entity Framework. It might be to complicated, just saying)

- Install Visual Studio 2019
- Get a connection string for a sql server database (use your own).
- Edit the connection string in the source.
- Remove MTT typescript generation in Backgammon.csproj. (Add it back after first build)
- Compile backend
- Create a pw.txt file locally for your database.
- Run `Update-Databas`
- Run Backend Api from Visual Studio.
- Install npm and yarn.
- cd to ui folder.
- Run `yarn install`
- Run `yarn start`
- Open http://localhost:4200 in the browser.
- Open a second browser for the other player.
- Have fun.
