#!/bin/bash
# Cron job to clean up stale/unpaid orders older than 24 hours

DB_CONN="Server=your_sql_server;Database=your_db;User Id=your_user;Password=your_password;"

sqlcmd -S $DB_CONN -Q "DELETE FROM Orders WHERE Status = 'Pending' AND CreatedAt < DATEADD(hour, -24, GETUTCDATE())"
