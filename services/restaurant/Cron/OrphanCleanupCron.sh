#!/bin/bash
# Cron job to clean up stale restaurants
# Run daily at midnight
# 0 0 * * * /path/to/OrphanCleanupCron.sh

sqlcmd -S localhost -d ZestEats -U sa -P your_password -Q "DELETE FROM Restaurants WHERE IsActive = 0 AND DATEDIFF(day, CreatedAt, GETDATE()) > 30;"
