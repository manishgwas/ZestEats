#!/bin/bash
# Cron job to clean up stale menus
# Run daily at midnight
mongo ZestEats --eval 'db.menus.deleteMany({"createdAt": { $lt: new Date(Date.now() - 30*24*60*60*1000) } })'
