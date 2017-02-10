Hello,
Here's a high level overview that might help reverse engineering a little easier.

* Code interacts with folders and with a MS SQL database table (one table).
* A configuration file "photo_transfer_data.txt" contains paths to these folders. Make certain
  to create them and to alter this file.
* There are two SQL queries located in Form1.cs file. One writes data to the DB and the other
  queries everything. I've removed our authentication details and included these placeholders
  for the parameters: SERVER,DBNAME,USER,PWD DB queries are managed by SQL_Class.cs.
* DB table is minimal with only 3 fields: ID (autoincrement), PhotoName varchar(20), and 
  Filepath varchar(512)
